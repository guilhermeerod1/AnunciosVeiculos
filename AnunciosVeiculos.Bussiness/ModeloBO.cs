using AnunciosVeiculos.DataAccess;
using AnunciosVeiculos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnunciosVeiculos.Bussiness
{
    public class ModeloBO
    {

        private ModeloDA modeloDA;

        public ModeloBO()
        {
            modeloDA = new ModeloDA();
        }

        public int InserirModelo(Modelo m)
        {
            return modeloDA.InserirModelo(m);
        }

        public Modelo RetornarModelo(int idModelo)
        {
            return modeloDA.RetornarModelo(idModelo);
        }

        public int AtualizarModelo(Modelo m)
        {
            return modeloDA.AtualizarModelo(m);
        }

        public int RemoverModelo(int idModelo)
        {
            return modeloDA.RemoverModelo(idModelo);
        }

        public List<Modelo> RetornarModelos()
        {
            return modeloDA.RetornarModelos();
        }
        
    }

}
