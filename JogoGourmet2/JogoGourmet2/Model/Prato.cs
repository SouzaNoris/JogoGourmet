using System.Collections.Generic;

namespace JogoGourmet2.Model
{
    public class Prato
    {
        public string Nome { get; set; }
        public TipoPrato TipoPrato { get; set; }
    }

    public class PratoList
    {
        public IList<Prato> Pratos { get; set; }

        public PratoList()
        {
            SetDadosDefault();
        }

        private void SetDadosDefault()
        {
            Pratos = new List<Prato>();
            Pratos.Add(new Prato { Nome = "Lazanha", TipoPrato = new TipoPrato() { Descricao = "Massa" } });
            Pratos.Add(new Prato { Nome = "Bolo de chocolate", TipoPrato = new TipoPrato() { Descricao = "Bolo" } });
        }

        public void AddPrato(string nome, string tipo)
        {
            Pratos.Add(new Prato { Nome = nome, TipoPrato = new TipoPrato { Descricao = tipo } });
        }
    }
}
