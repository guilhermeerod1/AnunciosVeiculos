using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnunciosVeiculos.Entidades
{
    public class Veiculo
    {

        public int IdVeiculo { get; set; }
        public decimal Valor { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public int Quilometragem { get; set; }
        public DateTime DataCadastro { get; set; }
        
        public Modelo Modelo { get; set; }
        public Usuario Usuario { get; set; }

    }
}
