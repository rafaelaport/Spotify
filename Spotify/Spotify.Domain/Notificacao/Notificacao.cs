﻿using Spotify.CrossCutting.Entity;
using Spotify.Domain.Account.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Notificacao
{
    public class Notificacao : Entity<Guid>
    {
        public DateTime DtNotificacao { get; set; }
        public String Mensagem { get; set; }
        public String Titulo { get; set; }
        public Usuario UsuarioDestino { get; set; }
        public Usuario? UsuarioRemetente { get; set; }
        public TipoNotificacao TipoNotificacao { get; set; }


        public static Notificacao Criar(string titulo, string mensagem, TipoNotificacao tipoNotificacao, Usuario destino, Usuario remetente = null)
        {
            if (tipoNotificacao == TipoNotificacao.Usuario && remetente == null)
                throw new ArgumentNullException("Para tipo de mensagem 'usuário', você deve informar quem foi o remetente");

            if (string.IsNullOrWhiteSpace(titulo))
                throw new ArgumentNullException("Informe o titulo da notificacao");

            if (string.IsNullOrWhiteSpace(mensagem))
                throw new ArgumentNullException("Informe o mensagem da notificacao");

            return new Notificacao()
            {
                DtNotificacao = DateTime.Now,
                Mensagem = mensagem,
                TipoNotificacao = tipoNotificacao,
                Titulo = titulo,
                UsuarioDestino = destino,
                UsuarioRemetente = remetente
            };
        }
    }

    public enum TipoNotificacao
    {
        Usuario = 1,
        Sistema = 2
    }
}

