namespace AltoLab.Models
{
    public class Despesa
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public decimal Valor { get; set; }
        public System.DateTime DataDespesa { get; set; }
    }
}
