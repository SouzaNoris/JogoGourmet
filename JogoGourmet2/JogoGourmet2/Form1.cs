using JogoGourmet2.Model;
using System;
using System.Windows.Forms;

namespace JogoGourmet2
{
    public partial class Form1 : Form
    {
        public GerenciadorDePratos GerenciadorDePratos { get; set; }
        public PratoList PratoList { get; set; }
        public TipoPratoList TipoPratoList { get; set; }

        public Form1()
        {
            InitializeComponent();

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            PratoList = new PratoList();
            TipoPratoList = new TipoPratoList();

            GerenciadorDePratos = new GerenciadorDePratos(PratoList, TipoPratoList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GerenciadorDePratos.IniciaJogo();
        }
    }
}
