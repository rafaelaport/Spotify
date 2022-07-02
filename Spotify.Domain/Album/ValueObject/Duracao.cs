using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Album.ValueObject
{
    public class Duracao
    {
        public Duracao()
        {

        }

        public Duracao(decimal valor)
        {

        }

        public int Valor { get; set; }
        public string Formatado => ValorFormatado();

        public string ValorFormatado()
        {
            var horas = Convert.ToInt32(Math.Floor(Convert.ToDecimal(this.Valor / 3600)));
            var duracao = horas % 3600;

            var minutos = Convert.ToInt32(Math.Floor(Convert.ToDecimal(duracao / 60)));
            var segundos = duracao % 60;

            if(horas > 0)
            {
                return $"{horas.ToString().PadLeft(2, '0')}:{minutos.ToString().PadLeft(2, '0')}:{segundos.ToString().PadLeft(2,'0')}";
            }

            return $"{minutos.ToString().PadLeft(2, '0')}:{segundos.ToString().PadLeft(2, '0')}";
        }

        //public override string ToString()
        //{
        //    return ValorFormatado();
        //}
    }
}
