using JogoGourmet2.Service;
using System;
using System.Windows.Forms;

namespace JogoGourmet2
{
    public partial class Form1 : Form
    {
        public GerenciadorService GerenciadorService { get; set; }

        public Form1()
        {
            InitializeComponent();

            InitializeJogo();
        }
        
        private void InitializeJogo()
        {
            textLabel.Text = "Pense em um prato que você gosta";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GerenciadorService = new GerenciadorService();
            GerenciadorService.IniciaJogo(GerenciadorService.TipoPratoService);
        }
    }
}
