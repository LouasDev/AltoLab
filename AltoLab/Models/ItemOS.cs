namespace AltoLab.Models
{
    public class ItemOS
    {
        public int Id { get; set; }
        public int OrdemServicoId { get; set; }
        public int ServicoId { get; set; }
        public string ServicoDescricao { get; set; }
        public decimal Valor { get; set; }
    }
}
