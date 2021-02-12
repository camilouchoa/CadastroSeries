using System;
using System.Collections.Generic;
using CadastroSeries.Interfaces;

namespace CadastroSeries
{
    public class SerieRepositorio : IRepositorio<Serie>
    {

        private List<Serie> listaSerie = new List<Serie>();

        public void Atualizar(int id, Serie objetoSerie)
        {
            listaSerie[id] = objetoSerie;
        }

        public void Excluir(int id)
        {
            listaSerie[id].Excluir();
        }

        public void Inserir(Serie objetoSerie)
        {
            listaSerie.Add(objetoSerie);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornoPorId(int id)
        {
            return listaSerie[id];
        }
    }
}