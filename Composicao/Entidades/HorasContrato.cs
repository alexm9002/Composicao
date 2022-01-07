using System;

namespace Composicao.Entidades {
    internal class HorasContrato {

        public DateTime Data { get; set; }
        public double ValorPorHora { get; set; }
        public int Horas { get; set; }

        public HorasContrato(DateTime data, double valorPorHora, int horas) {
            this.Data = data;
            this.ValorPorHora = valorPorHora;
            this.Horas = horas;
        }

        public double TotalHoras() {
            return Horas * ValorPorHora;
        }
    }


}
