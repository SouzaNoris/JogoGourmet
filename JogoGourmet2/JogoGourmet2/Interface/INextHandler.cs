using JogoGourmet2.Model;

namespace JogoGourmet2.Interface
{
    public interface INextHandler
    {
        INextHandler NextMessage(INextHandler handler);
        (object, TipoPrato) GetMessageHandle(object request, int contador, TipoPrato tipo = null);
    }
}
