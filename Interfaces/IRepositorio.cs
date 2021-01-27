// Interface repositório descreve como guardar nossas séries e 
// determina quais métodos esses repositórios vão - OBRIGATÓRIAMENTE - ter.

using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    // Cada repositório pode receber objetos de uma classe genérica "T"
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);
        void Insere(T entidade);
        void Exclui(int id);
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}