using AnunciosVeiculos.DataAccess;
using AnunciosVeiculos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnunciosVeiculos.Bussiness
{
    public class MarcaBO
    {

        private MarcaDA marcaDA;

        public MarcaBO()
        {
            marcaDA = new MarcaDA();
        }

        public int InserirMarca(Marca m)
        {
            return marcaDA.InserirMarca(m);
        }

        public Marca RetornarMarca(int idMarca)
        {
            return marcaDA.RetornarMarca(idMarca);
        }

        public int AtualizarMarca(Marca m)
        {
            return marcaDA.AtualizarMarca(m);
        }

        public int RemoverMarca(int idMarca)
        {
            return marcaDA.RemoverMarca(idMarca);
        }

        public List<Marca> RetornarMarcas()
        {
            return marcaDA.RetornarMarcas();
        }
        
    }
}
