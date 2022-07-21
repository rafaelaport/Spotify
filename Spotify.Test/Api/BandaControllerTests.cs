using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Spotify.Api.Controllers;
using Spotify.Application.Album.Dto;
using Spotify.Application.Album.Handler.Query;
using Spotify.Application.Album.Service;
using Spotify.Domain.Album;
using Spotify.Domain.Album.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Test.Api
{
    public class BandaControllerTests
    {
        [Fact]
        public async Task DeveBuscarTodasBandasComSucesso()
        {
            Mock<IMediator> mockMediator = new Mock<IMediator>();
            Mock<IBandaRepository> mockRepository = new Mock<IBandaRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            List<Banda> bandas = new List<Banda>()
            {
                new Banda()
                {
                    Nome = "Banda 1",
                    CaminhoFoto = "https://xpto.com/foto.png",
                    Descricao = "Lorem ipsum da banda 1"
                },

                new Banda()
                {
                    Nome = "Banda 2",
                    CaminhoFoto = "https://xpto.com/foto.png",
                    Descricao = "Lorem ipsum da banda 2"
                }
            };

            List<BandaOutputDto> bandaOutputDto = new List<BandaOutputDto>()
            {
                new BandaOutputDto(Guid.NewGuid(), "Banda 1","https://xpto.com/foto.png","Lorem ipsum da banda 1"),
                new BandaOutputDto(Guid.NewGuid(), "Banda 2","https://xpto.com/foto.png","Lorem ipsum da banda 2")
            };

            mockRepository.Setup(x => x.GetAll()).ReturnsAsync(bandas.AsEnumerable());
            mockMapper.Setup(x => x.Map<List<BandaOutputDto>>(bandas)).Returns(bandaOutputDto);

            var service = new BandaService(mockRepository.Object, mockMapper.Object);
            var result = await service.ObterTodos();

            mockMediator.Setup(x => x.Send(It.IsAny<ObterTodosBandaQuery>(), It.IsAny<CancellationToken>())).ReturnsAsync(new ObterTodosBandaQueryResponse(result));

            var controller = new BandaController(mockMediator.Object);
            var resultController = controller.ObterTodos();

            var okObjectResult = (OkObjectResult)resultController.Result;
            Assert.NotNull(okObjectResult);

            var response = okObjectResult.Value as ObterTodosBandaQueryResponse;
            Assert.NotNull(response.Bandas);

        }
    }
}
