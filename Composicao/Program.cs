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

            // Classe      variável    recebe  na classe a variável digitada pelo usuário
            Departamento departamento = new Departamento(nomeDepartamento);

            // Classe     variável   recebe na classe as variáveis digitadas pelo usuário
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
                
                // Classe      variável recebe  na classe as variáveis do "For" (digitadas pelo usuário)
                HorasContrato contrato = new HorasContrato(data, valorPorHora, horas);
                
                // variável (que guarda os dados do func.) da classe "Trabalhador" adiciona o contrato
                trabalhador.AddContrato(contrato);

            }

            Console.WriteLine("---------------");
            Console.Write("Entre com o mês e o Ano para calcular os rendimentos (MM/YYYY): ");
            string mesEAno = Console.ReadLine();
            
            //Substring vai recortar 2 caracteres a partir do caracter 0 (08/2018) = 08
            int mes = int.Parse(mesEAno.Substring(0, 2));
            // Como MesEAno está como String e precisa ser transformado em inteiro, usar "int.Parse"

            //Substring vai recortar todos os caracteres a partir do caracter 3 (08/2018) = 2018
            int ano = int.Parse(mesEAno.Substring(3));
            // Como MesEAno está como String e precisa ser transformado em inteiro, usar "int.Parse"

            Console.WriteLine();
            Console.WriteLine("Nome: " + trabalhador.Nome);
            Console.WriteLine("Departamento: " + trabalhador.Departamento.Nome);
            Console.WriteLine("Rendimento para "
                + mesEAno + ": "
                + trabalhador.Rendimento(ano, mes).ToString("F2", CultureInfo.InvariantCulture));

            Console.WriteLine();
        }
    }
}