using System.Collections.Generic;
using Composicao.Entidades.Enumeracoes;

namespace Composicao.Entidades {
    internal class Trabalhador {
        public string Nome { get; set; }
        public NivelTrabalhador Nivel { get; set; }
        public double SalarioBase { get; set; }
        public Departamento Departamento { get; set; }
        public List<HorasContrato> Contratos { get; set; } = new List<HorasContrato>();

        public Trabalhador(string nome, NivelTrabalhador nivel, double salarioBase, Departamento departamento) {
            Nome = nome;
            Nivel = nivel;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }
        public void AddContrato(HorasContrato contrato) {
            Contratos.Add(contrato);
        }
        public void RemoveContrato(HorasContrato contrato) {
            Contratos.Remove(contrato);
        }

        public double Rendimento(int Ano, int mes) {
            double soma = SalarioBase;
            foreach (HorasContrato contrato in Contratos) {
                if (contrato.Data.Year == Ano && contrato.Data.Month == mes) {
                    soma += contrato.TotalHoras();
                }
            }
            return soma;
        }
    }
}
