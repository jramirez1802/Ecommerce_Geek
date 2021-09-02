namespace Ecommerce_Geek.Models
{
    public class InformacoesPagamento
    {
        public int Id { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public double Valor { get; set; }
        public int QuantidadeParcela { get; set; }

    }

    public enum TipoPagamento
    {
        Cartao, Debito, Boleto, Pix
    }
}