using AnunciosVeiculos.DataAccess;
using AnunciosVeiculos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnunciosVeiculos.Bussiness
{
    public class VeiculoBO
    {
        private VeiculoDA veiculoDA;

        public VeiculoBO()
        {
            veiculoDA = new VeiculoDA();
        }

        public int InserirVeiculo(Veiculo v)
        {
            return veiculoDA.InserirVeiculo(v);
        }

        public Veiculo RetornarVeiculo(int idVeiculo)
        {
            return veiculoDA.RetornarVeiculo(idVeiculo);
        }

        public int AtualizarVeiculo(Veiculo v)
        {
            return veiculoDA.AtualizarVeiculo(v);
        }

        public int RemoverVeiculo(int idVeiculo)
        {
            return veiculoDA.RemoverVeiculo(idVeiculo);
        }

        public List<Veiculo> RetornarVeiculos()
        {
            return veiculoDA.RetornarVeiculos();
        }
        
    }

}
