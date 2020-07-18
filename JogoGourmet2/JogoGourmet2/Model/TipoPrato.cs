using System.Collections.Generic;

namespace JogoGourmet2.Model
{
    public class TipoPrato
    {
        public string Descricao { get; set; }
    }

    public class TipoPratoList
    {
        public IList<TipoPrato> Tipos { get; set; }

        public TipoPratoList()
        {
            this.SetDadosDefault();
        }

        private void SetDadosDefault()
        {
            Tipos = new List<TipoPrato>();
            this.Tipos.Add(new TipoPrato { Descricao = "Massa" });
            this.Tipos.Add(new TipoPrato { Descricao = "Bolo" });
        }

        public void AddTipoPrato(string tipo)
        {
            Tipos.Add(new TipoPrato { Descricao = tipo });
        }
    }
}
