using JogoGourmet2.Model;
using System;
using System.Windows.Forms;

namespace JogoGourmet2
{
    public partial class Form1 : Form
    {
        public GerenciadorDePratos GerenciadorDePratos { get; set; }
        public PratoList CategoriaList { get; set; }

        public Form1()
        {
            InitializeComponent();

            LoadDefaults();
        }

        private void LoadDefaults()
        {
            CategoriaList = new PratoList();
            GerenciadorDePratos = new GerenciadorDePratos(CategoriaList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GerenciadorDePratos.IniciaJogo();
        }
    }
}
