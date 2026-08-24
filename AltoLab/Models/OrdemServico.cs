using System;
using System.Collections.Generic;

namespace AltoLab.Models
{
    public class OrdemServico
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNome { get; set; }
        public string Equipamento { get; set; }
        public string ProblemaRelatado { get; set; }
        public string Status { get; set; } // Aberta, Em andamento, Concluída, Entregue
        public DateTime DataAbertura { get; set; }
        public DateTime? DataConclusao { get; set; }
        public decimal ValorTotal { get; set; }

        public List<ItemOS> Itens { get; set; }

        public OrdemServico()
        {
            Status = "Aberta";
            DataAbertura = DateTime.Now;
            Itens = new List<ItemOS>();
        }
    }
}
