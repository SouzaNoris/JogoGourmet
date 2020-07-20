using System.Collections.Generic;

namespace JogoGourmet2.Model
{
    public class Prato
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public List<Prato> NovoPrato { get; set; }

        public Prato()
        {
            NovoPrato = new List<Prato>();
        }
    }

    public class PratoList
    {
        public List<Prato> Pratos { get; set; }

        public PratoList()
        {
            SetDadosDefault();
        }

        private void SetDadosDefault()
        {
            Pratos = new List<Prato>();
            Pratos.Add(new Prato()
            {
                Nome = "lasanha",
                Tipo = "massa",
            });
            Pratos.Add(new Prato()
            {
                Nome = "Bolo de Chocolate",
                Tipo = ""
            });
        }
    }
}
