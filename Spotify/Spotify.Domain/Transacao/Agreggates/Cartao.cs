using Spotify.CrossCutting.Entity;
using Spotify.Domain.Core.ValueObject;
using Spotify.Domain.Transacao.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Transacao.Agreggates
{
    public class Cartao : Entity<Guid>
    {
        private const int INTERVALO_TRANSACAO = -2;
        private const int REPETICAO_TRANSACAO_MERCHANT = 1;

        public bool Ativo { get; set; }
        public Monetario Limite { get; set; }
        public string Numero { get; set; }
        public List<Transacao> Transacoes { get; set; } = new List<Transacao>();

        public void CriarTransacao(Merchant merchant, Monetario valor, string Descricao = "")
        {
            //Verificar se o cartão está ativo
            IsCartaoAtivo();

            Transacao transacao = new Transacao();
            transacao.Merchant = merchant;
            transacao.Valor = valor;
            transacao.Descricao = Descricao;
            transacao.DtTransacao = DateTime.Now;

            //Verifica limite disponivel
            VerificaLimite(transacao);

            //Verifica regras antifraude
            ValidarTransacao(transacao);

            //Cria numero de autorização
            transacao.Id = Guid.NewGuid();

            //Diminui o limite com o valor da transacao
            Limite = Limite - transacao.Valor;

            Transacoes.Add(transacao);

        }

        private void ValidarTransacao(Transacao transacao)
        {
            var ultimasTransacoes = Transacoes.Where(x =>
                                                          x.DtTransacao >= DateTime.Now.AddMinutes(INTERVALO_TRANSACAO));
            if (ultimasTransacoes?.Count() >= 3)
                throw new Exception("Cartão utilizado muitas vezes em um período curto");

            var transacaoRepetidaPorMerchant = ultimasTransacoes?
                                                .Where(x => x.Merchant.Nome.ToUpper() == transacao.Merchant.Nome.ToUpper()
                                                       && x.Valor == transacao.Valor)
                                                .Count() == REPETICAO_TRANSACAO_MERCHANT;

            if (transacaoRepetidaPorMerchant)
                throw new Exception("Transacao Duplicada para o mesmo cartão e o mesmo Comerciante");

        }

        private void VerificaLimite(Transacao transacao)
        {
            if (Limite < transacao.Valor)
                throw new Exception("Cartão não possui limite para esta transacao");
        }

        private void IsCartaoAtivo()
        {
            if (Ativo == false)
                throw new Exception("Cartão não está ativo");
        }
    }
}
