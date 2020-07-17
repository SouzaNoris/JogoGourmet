using JogoGourmet2.Model;
using JogoGourmet2.Service.Base;
using JogoGourmet2.Singleton;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace JogoGourmet2.Service
{
    public class AddNewDadosService : BaseAbstract
    {
        private IList<Prato> PratoList { get; set; }
        private IList<TipoPrato> TipoPratoList { get; set; }

        public AddNewDadosService()
        {
            PratoList = Singleton<List<Prato>>.Instance();
            TipoPratoList = Singleton<List<TipoPrato>>.Instance();
        }

        public override (object, TipoPrato) GetMessageHandle(object request, int contador, TipoPrato tipoPrato = null)
        {
            var prato = new Prato();
            prato.Nome = MontaMensage("Qual prato você pensou?", "Desisto");
            prato.TipoPrato = new TipoPrato
            {
                Tipo = MontaMensage($"{prato.Nome} é __________ mas {this.PratoList.LastOrDefault().Nome} não.", "Complete")
            };

            this.PratoList.Add(prato);

            if (!TipoPratoList.Contains(tipoPrato))
                this.TipoPratoList.Add(prato.TipoPrato);

            return (DialogResult.Retry, null);
        }

        private string MontaMensage(string message, string confirm)
        {
            return Interaction.InputBox(message, confirm);
        }
    }
}
