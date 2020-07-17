using JogoGourmet2.Model;
using JogoGourmet2.Service.Base;
using JogoGourmet2.Singleton;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JogoGourmet2.Service
{
    public class GerenciadorService
    {
        public List<Prato> PratoList { get; set; }
        public List<TipoPrato> TipoPrato { get; set; }

        public TipoPratoService TipoPratoService { get; set; }
        public PratoService PratoService { get; set; }
        public AddNewDadosService AddNewDadosService { get; set; }

        private int ContadorList { get; set; } = 0;

        private IList<BaseAbstract> ListServices { get; set; }

        public GerenciadorService()
        {
            GetDadosDefaultPrato();

            GetDefaultTipoPrato();

            GetInstanceServices();

            GetPopulateListService();
        }

        private void GetPopulateListService()
        {
            ListServices = new List<BaseAbstract>();

            ListServices.Add(TipoPratoService);
            ListServices.Add(PratoService);
            ListServices.Add(AddNewDadosService);
        }

        private void GetDadosDefaultPrato()
        {
            PratoList = Singleton<List<Prato>>.Instance();

            if (PratoList.Count == 0)
            {
                PratoList.Add(
                    new Prato
                    {
                        Nome = "Lazanha",
                        TipoPrato = new TipoPrato() { Tipo = "Massa" }
                    });
                PratoList.Add(
                    new Prato
                    {
                        Nome = "Bolo de chocolate",
                        TipoPrato = new TipoPrato() { Tipo = "Bolo" }
                    });
            }
        }

        private void GetDefaultTipoPrato()
        {
            TipoPrato = Singleton<List<TipoPrato>>.Instance();

            if (TipoPrato.Count == 0)
            {
                this.TipoPrato.Add(new TipoPrato { Tipo = "Massa" });
                this.TipoPrato.Add(new TipoPrato { Tipo = "Bolo" });
            }
        }

        private void GetInstanceServices()
        {
            TipoPratoService = Singleton<TipoPratoService>.Instance();
            PratoService = Singleton<PratoService>.Instance();
            AddNewDadosService = Singleton<AddNewDadosService>.Instance();

            TipoPratoService.NextMessage(PratoService).NextMessage(AddNewDadosService);
        }

        public void IniciaJogo(BaseAbstract handler, int contador = 0, TipoPrato tipoPrato = null)
        {
            var service = ListServices[ContadorList];

            var dialog = handler.GetMessageHandle(service, contador, tipoPrato);

            switch (dialog.Item1)
            {
                case DialogResult.Abort:
                    ContadorList = 2;
                    IniciaJogo(ListServices[ContadorList], 0, tipoPrato);
                    break;
                case DialogResult.Yes:
                    ContadorList++;
                    IniciaJogo(ListServices[ContadorList], 0, dialog.Item2);
                    break;
                case DialogResult.No:
                    contador++;
                    IniciaJogo(ListServices[ContadorList], contador, dialog.Item2);
                    break;
                case DialogResult.Retry:
                    break;
                case DialogResult.OK:
                    GetMessageAcerto();
                    break;
                default:
                    break;
            }
        }

        public void GetMessageAcerto()
        {
            MessageBox.Show("Acertei de novo!", "Jogo Gourmet", MessageBoxButtons.OK);
        }
    }
}
