// Classe abstrata que possui aa propriedade ID compartilhada por 
// todas as séries

namespace DIO.Series
{
    public abstract class EntidadeBase
    {
        public int Id { get; protected set; }
    }
}