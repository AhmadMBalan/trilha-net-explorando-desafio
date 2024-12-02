namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
            Hospedes = new List<Pessoa>();
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verificar se a capacidade da suíte é suficiente para o número de hóspedes
            if (Suite != null && hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Lançar exceção caso a capacidade seja insuficiente
                throw new ArgumentException("A capacidade da suíte é menor do que o número de hóspedes.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade total de hóspedes
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
            {
                throw new InvalidOperationException("Nenhuma suíte foi cadastrada para esta reserva.");
            }

            // Calcula o valor total das diárias
            decimal valorTotal = DiasReservados * Suite.ValorDiaria;

            // Aplica desconto de 10% caso os dias reservados sejam 10 ou mais
            if (DiasReservados >= 10)
            {
                valorTotal -= valorTotal * 0.10m;
            }

            return valorTotal;
        }
    }
}
