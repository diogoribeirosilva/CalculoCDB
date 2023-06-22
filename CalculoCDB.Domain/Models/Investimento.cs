namespace CalculoCDB.Domain.Models
{
    public class Investimento
    {
        public decimal ValorInicial { get; set; }
        public int PrazoMeses { get; set; }
        public decimal Cdi { get; set; }
        public decimal TaxaBanco { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal ValorLiquido { get; set; }
    }
}
