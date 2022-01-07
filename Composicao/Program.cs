using System;
using System.Globalization;
using Composicao.Entidades;
using Composicao.Entidades.Enumeracoes;

namespace Composicao {
    class Program {
        static void Main(string[] args) {
            Console.Write("Entre com o nome do Departamento: ");
            string nomeDepartamento = Console.ReadLine();
            Console.WriteLine("Entre com os dados do Trabalhador:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Nível (Junior/Intermediário/Senior): ");
            NivelTrabalhador nivel = Enum.Parse<NivelTrabalhador>(Console.ReadLine());
            Console.Write("Salário Base: ");
            double SalarioBase = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Departamento departamento = new Departamento(nomeDepartamento);
            Trabalhador trabalhador = new Trabalhador(nome, nivel, SalarioBase, departamento);

            Console.Write("Quantos contratos para esse trabalhador? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++) {
                Console.WriteLine($"Entre #{i} Contrato data:");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime data = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por Hora: ");
                double valorPorHora = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.Write("Duração (em horas): ");
                int horas = int.Parse(Console.ReadLine());
                HorasContrato contrato = new HorasContrato(data, valorPorHora, horas);
                trabalhador.AddContrato(contrato);

            }

            Console.WriteLine("---------------");
            Console.Write("Entre com o mês e o Ano para calcular os rendimentos (MM/YYYY): ");
            string mesEAno = Console.ReadLine();
            int mes = int.Parse(mesEAno.Substring(0, 2));
            int ano = int.Parse(mesEAno.Substring(3));

            Console.WriteLine();
            Console.WriteLine("Nome: " + trabalhador.Nome);
            Console.WriteLine("Departamento: " + trabalhador.Departamento.Nome);
            Console.WriteLine("Redimento para "
                + mesEAno + ": "
                + trabalhador.Rendimento(ano, mes).ToString("F2", CultureInfo.InvariantCulture));

            Console.WriteLine();
        }
    }
}