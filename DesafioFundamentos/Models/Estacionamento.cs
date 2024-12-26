using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private decimal faturamentoTotal = 0;
        

        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora, decimal faturamentoTotal)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.faturamentoTotal = faturamentoTotal;
        }

        public decimal BuscarFaturamentoTotal()
        {
            return faturamentoTotal; 
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            if (!ValidarPlaca(placa))
            {
                Console.WriteLine($"Placa {placa} inválida. Digite uma placa no formato AAA9999 ou ABC-1234");
                return;
            }
            veiculos.Add(placa);
            Console.WriteLine($"Veículo {placa} estacionado com sucesso!");
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                int horas = 0;
                int.TryParse(Console.ReadLine(), out horas);

                decimal valorTotal = precoInicial + (precoPorHora * horas); 
                faturamentoTotal += valorTotal;

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine($"Desculpe, esse veículo não está estacionado aqui. Confira se a placa {placa} está correta");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach (var veiculo in veiculos)
                    Console.WriteLine($"Placa {veiculo}");
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private bool ValidarPlaca(string placa)
        {
            string padrao = @"^[A-Z]{3}[0-9][A-Z0-9][0-9]{2}$";
            return Regex.IsMatch(placa.ToUpper(), padrao);
        }
    }
}
