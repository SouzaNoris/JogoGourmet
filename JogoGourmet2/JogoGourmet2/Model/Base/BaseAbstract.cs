using JogoGourmet2.Interface;
using JogoGourmet2.Model;

namespace JogoGourmet2.Service.Base
{
    public abstract class BaseAbstract : INextHandler
    {
        private INextHandler _nextMessage;

        public virtual (object, TipoPrato) GetMessageHandle(object request, int contador, TipoPrato tipo = null)
        {
            if (this._nextMessage != null)
                return (this._nextMessage.GetMessageHandle(request, contador), null);

            return (null, null);
        }

        public INextHandler NextMessage(INextHandler handler)
        {
            this._nextMessage = handler;

            return handler;
        }

    }
}
