using System.Collections.Generic;

namespace CadastroSeries.Interfaces
{
    public interface IRepositorio <T>
    {
        List<T> Lista();
        T RetornoPorId (int id);
        void Inserir(T objetoSerie);
        void Excluir (int id);
        void Atualizar (int id, T objetoSerie);
        int ProximoId();

            
    }
}