using AutoMapper;
using Moq;
using Spotify.Application.Album.Dto;
using Spotify.Application.Album.Service;
using Spotify.Domain.Album;
using Spotify.Domain.Album.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Test.Application
{
    public class BandaServiceTests
    {
        [Fact]
        public async Task DeveCriarBandaComSucesso()
        {
            BandaInputDto bandaInputDto = new BandaInputDto("XTPO", "https://xpto.com/foto.png", "Lorem ipsum da banda");
            BandaOutputDto bandaOutputDto = new BandaOutputDto(Guid.NewGuid(), "XTPO", "https://xpto.com/foto.png", "Lorem ipsum da banda");
            
            Mock<IBandaRepository> mockRepository = new Mock<IBandaRepository>();
            Mock<IMapper> mockMapper = new Mock<IMapper>();

            Banda banda = new Banda()
            {
                Nome = "XTPO",
                CaminhoFoto = "https://xpto.com/foto.png",
                Descricao = "Lorem ipsum da banda"
            };

            mockMapper.Setup(x => x.Map<Banda>(bandaInputDto)).Returns(banda);
            mockRepository.Setup(x => x.Save(It.IsAny<Banda>())).Returns(Task.FromResult(banda));
            mockMapper.Setup(x => x.Map<BandaOutputDto>(banda)).Returns(bandaOutputDto);

            var service = new BandaService(mockRepository.Object, mockMapper.Object);
            var result = await service.Criar(bandaInputDto);

            Assert.NotNull(result);


        }
    }
}
