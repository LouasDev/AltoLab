namespace AltoLab.Models
{
    public class Servico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorPadrao { get; set; }

        public override string ToString()
        {
            return $"{Descricao} - R$ {ValorPadrao:N2}";
        }
    }
}
