﻿using FluentValidation;
using Spotify.CrossCutting.Entity;
using Spotify.CrossCutting.Utils;
using Spotify.Domain.Account.Rules;
using Spotify.Domain.Account.ValueObject;
using Spotify.Domain.Core.ValueObject;
using Spotify.Domain.Streaming.Agreggates;
using Spotify.Domain.Transacao.Agreggates;
using Spotify.Domain.Transacao.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Account.Agreggates
{
    public class Usuario : Entity<Guid>
    {
        private const string NOME_PLAYLIST = "Favoritas";

        public string Nome { get; set; }
        public Email Email { get; set; }
        public Password Senha { get; set; }
        public DateTime DtNascimento { get; set; }
        public List<Cartao> Cartoes { get; set; } = new List<Cartao>();
        public List<Assinatura> Assinaturas { get; set; } = new List<Assinatura>();
        public List<Playlist> Playlists { get; set; } = new List<Playlist>();
        public List<Notificacao.Notificacao> Notificacoes { get; set; } = new List<Notificacao.Notificacao>();

        public void CriarConta(string nome, Email email, Password senha, DateTime dtNascimento, Plano plano, Cartao cartao)
        {
            Nome = nome;
            Email = email;
            DtNascimento = dtNascimento;

            //Criptografar a senha
            CriptografarSenha(senha);

            //Assinar um plano
            AssinarPlano(plano, cartao);

            //Adicionar cartão na conta do usuário
            AdicionarCartao(cartao);

            //Criar a playlist padrão do usuario
            CriarPlaylist(nome: NOME_PLAYLIST, publica: false);


        }

        public void CriarPlaylist(string nome, bool publica = true)
        {
            Playlists.Add(new Playlist()
            {
                Nome = nome,
                Publica = publica,
                DtCriacao = DateTime.Now,
                Usuario = this
            });
        }

        private void AdicionarCartao(Cartao cartao)
            => Cartoes.Add(cartao);

        private void AssinarPlano(Plano plano, Cartao cartao)
        {
            //Debitar o valor do plano no cartao
            cartao.CriarTransacao(new Merchant() { Nome = plano.Nome }, new Monetario(plano.Valor), plano.Descricao);

            //Desativo caso tenha alguma assinatura ativa
            DesativarAssinaturaAtiva();

            //Adiciona uma nova assinatura
            Assinaturas.Add(new Assinatura()
            {
                Ativo = true,
                Plano = plano,
                DtAtivacao = DateTime.Now,
            });

        }

        private void DesativarAssinaturaAtiva()
        {
            //Caso tenha alguma assintura ativa, deseativa ela
            if (Assinaturas.Count > 0 && Assinaturas.Any(x => x.Ativo))
            {
                var planoAtivo = Assinaturas.FirstOrDefault(x => x.Ativo);
                planoAtivo.Ativo = false;
            }
        }

        public void SetPassword()
        {
            Senha.Valor = SecurityUtils.HashSHA1(Senha.Valor);
        }

        private Password CriptografarSenha(Password senhaAberta)
        {
            SHA256 criptoProvider = SHA256.Create();

            byte[] btexto = Encoding.UTF8.GetBytes(senhaAberta.Valor);

            var criptoResult = criptoProvider.ComputeHash(btexto);

            var senha = Convert.ToHexString(criptoResult);

            return new Password(senha);
        }

        public void Validate() =>
            new UsuarioValidator().ValidateAndThrow(this);
    }
}
