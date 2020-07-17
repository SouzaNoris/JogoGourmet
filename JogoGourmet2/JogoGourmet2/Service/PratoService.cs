using JogoGourmet2.Service.Base;
using JogoGourmet2.Singleton;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace JogoGourmet2.Model
{
    public class PratoService : BaseAbstract
    {
        private IList<Prato> PratoList { get; set; }

        public PratoService()
        {
            PratoList = Singleton<List<Prato>>.Instance();
        }

        public override (object, TipoPrato) GetMessageHandle(object request, int contador, TipoPrato tipoPrato = null)
        {
            if (request is PratoService)
            {
                var dialog = GetMessage(contador, tipoPrato);

                if (dialog == DialogResult.Yes)
                    return (DialogResult.OK, null);
                else if (dialog == DialogResult.Abort)
                    return (DialogResult.Abort, null);
                else
                    return (DialogResult.No, tipoPrato);
            }

            return base.GetMessageHandle(request, contador);
        }

        public DialogResult GetMessage(int contador, TipoPrato tipoPrato)
        {
            var prato = PratoList.Where(x => x.TipoPrato.Tipo == tipoPrato.Tipo).ToList();

            if (contador >= prato.Count)
                return DialogResult.Abort;

            var message = contador <= this.PratoList.Count ? $"O prato que você pensou é {prato[contador].Nome}?" : "Qual prato você pensou? ";
            var confirm = contador <= this.PratoList.Count ? "Confirm" : "Desisto";

            return MontaMensage(message, confirm, MessageBoxButtons.YesNo);
        }

        private DialogResult MontaMensage(string message, string confirm, MessageBoxButtons buttons)
        {
            return MessageBox.Show(message, confirm, buttons);
        }
    }
}
