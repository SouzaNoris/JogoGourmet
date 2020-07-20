using JogoGourmet2.Model;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace JogoGourmet2
{
    public class GerenciadorDePratos
    {
        public PratoList PratoList { get; set; }

        public GerenciadorDePratos(PratoList pratoList)
        {
            PratoList = pratoList;
        }

        public void IniciaJogo()
        {
            VerificaTipoPratos(PratoList.Pratos);
        }

        private void VerificaTipoPratos(List<Prato> pratos)
        {
            var pratosFilter = pratos.Where(x => !string.IsNullOrEmpty(x.Tipo))
                                     .OrderByDescending(x => !string.IsNullOrEmpty(x.Tipo));

            foreach (var prato in pratosFilter)
            {
                var result = ShowMessage($"O prato que você pensou é {(string.IsNullOrEmpty(prato.Tipo) ? prato.Nome : prato.Tipo) }?", "Confirm", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    VerificaPratos(prato);
                    break;
                }

                if (prato == pratosFilter.Last())
                    VerificaPratos(pratos.Where(x => string.IsNullOrEmpty(x.Tipo)).FirstOrDefault(), pratos);
            }
        }

        private void VerificaPratos(Prato prato, List<Prato> pratos = null)
        {
            if (prato.NovoPrato.Any())
            {
                if (VerificaPratosComNovosElementos(prato.NovoPrato, true)) return;
            }

            var result = ShowMessage($"O prato que você pensou é {prato.Nome}?", "Confirm", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                GetMessageAcerto();
                return;
            }

            Desisto(prato, pratos ?? new List<Prato>());
        }

        private bool VerificaPratosComNovosElementos(List<Prato> pratosList, bool novoPrato = false)
        {
            foreach (var prato in pratosList)
            {
                if (prato.NovoPrato.Any() && !novoPrato)
                {
                    if (VerificaPratosComNovosElementos(prato.NovoPrato, true))
                        break;
                }

                var result = ShowMessage($"O prato que você pensou é {prato.Tipo}?", "Confirm", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    VerificaPratos(prato);
                    return true;
                }
            }

            return false;
        }

        private void Desisto(Prato prato, List<Prato> pratos = null)
        {
            var pratoInformado = ShowMessageInput("Qual prato você pensou?", "Desisto");

            var tipo = ShowMessageInput($"{pratoInformado} é ________ mas {prato.Nome} não.", "Complete");

            if (pratos.Any())
            {
                pratos.Add(new Prato()
                {
                    Nome = pratoInformado,
                    Tipo = tipo
                });
            }
            else
                prato.NovoPrato.Add(new Prato()
                {
                    Nome = pratoInformado,
                    Tipo = tipo
                });
        }

        private DialogResult ShowMessage(string message, string msgConfirm, MessageBoxButtons buttons)
        {
            return MessageBox.Show(message, msgConfirm, buttons);
        }

        private void GetMessageAcerto()
        {
            MessageBox.Show("Acertei de novo!", "Jogo Gourmet", MessageBoxButtons.OK);
        }

        private string ShowMessageInput(string msg, string confirm)
        {
            return Interaction.InputBox(msg, confirm);
        }
    }
}
