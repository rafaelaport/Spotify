﻿using MediatR;
using Spotify.Application.Album.Handler.Command;
using Spotify.Application.Album.Handler.Query;
using Spotify.Application.Album.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Application.Album.Handler
{
    public class BandaHandler : IRequestHandler<CriarBandaCommand, CriarBandaCommandResponse>,
                                IRequestHandler<EditarBandaCommand, EditarBandaCommandResponse>,
                                IRequestHandler<ExcluirBandaCommand, ExcluirBandaCommandResponse>,
                                IRequestHandler<ObterTodosBandaQuery, ObterTodosBandaQueryResponse>,
                                IRequestHandler<ObterPorIdBandaQuery, ObterPorIdBandaQueryResponse>
    {

        private readonly IBandaService _bandaService;

        public BandaHandler(IBandaService bandaService)
        {
            _bandaService = bandaService;
        }

        public async Task<ObterTodosBandaQueryResponse> Handle(ObterTodosBandaQuery request, CancellationToken cancellationToken)
        {
            var result = await _bandaService.ObterTodos();
            return new ObterTodosBandaQueryResponse(result);
        }

        public async Task<ObterPorIdBandaQueryResponse> Handle(ObterPorIdBandaQuery request, CancellationToken cancellationToken)
        {
            var result = await _bandaService.ObterPorId(request.Id);
            return new ObterPorIdBandaQueryResponse(result);
        }

        public async Task<CriarBandaCommandResponse> Handle(CriarBandaCommand request, CancellationToken cancellationToken)
        {
            var result = await _bandaService.Criar(request.Banda);
            return new CriarBandaCommandResponse(result);
        }

        public async Task<EditarBandaCommandResponse> Handle(EditarBandaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.Editar(request.Banda);

            return new EditarBandaCommandResponse(result);
        }

        public async Task<ExcluirBandaCommandResponse> Handle(ExcluirBandaCommand request, CancellationToken cancellationToken)
        {
            var result = await this._bandaService.Excluir(request.Id);

            return new ExcluirBandaCommandResponse(result);
        }
    }
}
