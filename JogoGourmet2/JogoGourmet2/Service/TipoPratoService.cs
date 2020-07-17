using JogoGourmet2.Service.Base;
using JogoGourmet2.Singleton;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JogoGourmet2.Model
{
    public class TipoPratoService : BaseAbstract
    {
        private IList<TipoPrato> TipoPrato { get; set; }

        public TipoPratoService()
        {
            TipoPrato = Singleton<List<TipoPrato>>.Instance();
        }

        public override (object, TipoPrato) GetMessageHandle(object request, int contador, TipoPrato tipoPrato = null)
        {
            if (request is TipoPratoService)
            {
                var dialogResponse = GetMessage(contador);

                if (dialogResponse == DialogResult.Abort)
                    return (DialogResult.Abort, null);
                else if (dialogResponse == DialogResult.Yes)
                    return (dialogResponse, TipoPrato[contador]);
                else
                    return (dialogResponse, null);
            }

            return (base.GetMessageHandle(request, contador), null);
        }

        public DialogResult GetMessage(int contador)
        {
            if (contador >= TipoPrato.Count)
                return DialogResult.Abort;

            var message = contador <= this.TipoPrato.Count ? $"O prato que você pensou é {this.TipoPrato[contador].Tipo}?" : "Qual prato você pensou? ";
            var confirm = contador <= this.TipoPrato.Count ? "Confirm" : "Desisto";

            return MessageBox.Show(message, confirm, MessageBoxButtons.YesNo);
        }
    }
}
