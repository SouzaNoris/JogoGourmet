using JogoGourmet2.Model;
using Microsoft.VisualBasic;
using System.Linq;
using System.Windows.Forms;

namespace JogoGourmet2
{
    public class GerenciadorDePratos
    {
        public PratoList Pratos { get; set; }
        public TipoPratoList Tipos { get; set; }
        public string PratoPensado { get; set; }
        public string TipoNovo { get; set; }

        public GerenciadorDePratos(PratoList pratos, TipoPratoList tipos)
        {
            Pratos = pratos;
            Tipos = tipos;
        }

        public void IniciaJogo()
        {
            VerificaTipoPratos();

            AddItemToList();
        }

        private void VerificaTipoPratos()
        {
            foreach (var tipo in Tipos.Tipos)
            {
                var result = ShowMessage($"O prato que você pensou é {tipo.Descricao}?", "Confirm", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    this.VerificaPrato(tipo);
                    break;
                }

                if (tipo == Tipos.Tipos.Last())
                    Desisto(Tipos.Tipos.Last().Descricao);
            }
        }

        private void VerificaPrato(TipoPrato tipo)
        {
            var pratosFilter = Pratos.Pratos.Where(x => x.TipoPrato.Descricao == tipo.Descricao);

            foreach (var prato in pratosFilter)
            {
                var result = ShowMessage($"O prato que você pensou é {prato.Nome}?", "Confirm", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    GetMessageAcerto();
                    break;
                }

                if (prato == pratosFilter.Last())
                    Desisto(prato.Nome);
            }
        }

        private void Desisto(string ultimoItemPassado)
        {
            PratoPensado = ShowMessageInput("Qual prato você pensou?", "Desisto");

            TipoNovo = ShowMessageInput($"{PratoPensado} é ________ mas {ultimoItemPassado} não.", "Complete");
        }

        private void LimpaInformacoes()
        {
            PratoPensado = string.Empty;
            TipoNovo = string.Empty;
        }

        private void AddItemToList()
        {
            Pratos.AddPrato(PratoPensado, TipoNovo);
            Tipos.AddTipoPrato(TipoNovo);

            LimpaInformacoes();
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
