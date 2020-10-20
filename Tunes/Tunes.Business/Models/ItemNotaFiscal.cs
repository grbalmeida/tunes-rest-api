namespace Tunes.Business.Models
{
    public class ItemNotaFiscal
    {
        public int ItemNotaFiscalId { get; set; }
        public decimal PrecoUnitario { get; set; }
        public int Quantidade { get; set; }

        public NotaFiscal NotaFiscal { get; set; }
        public Faixa Faixa { get; set; }
    }
}
