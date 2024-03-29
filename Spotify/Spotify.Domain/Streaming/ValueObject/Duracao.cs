﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Streaming.ValueObject
{
    public record Duracao
    {
        public Duracao()
        {

        }

        public Duracao(int valor)
        {
            if (valor < 0)
                throw new ArgumentException("Duração da música não pode ser negativa.");

            this.Valor = valor;
        }

        public int Valor { get; set; }
        public string Formatado => ValorFormatado();

        public string ValorFormatado()
        {
            int minutos = Valor / 60;
            int segundos = Valor % 60;

            return $"{minutos.ToString().PadLeft(1, '0')}:{segundos.ToString().PadLeft(1, '0')}";
        }
        public override string ToString()
        {
            return ValorFormatado();
        }

        public static implicit operator int(Duracao d) => d.Valor;
        public static implicit operator Duracao(int valor) => new Duracao(valor);
    }
}
