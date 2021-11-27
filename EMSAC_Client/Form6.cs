using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMSAC_Client
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Criar um objeto
            Product p1 = new Product(NomeProduto.Text, float.Parse(PrecoProduto.Text));
            // Inserir o produto numa lista
            Products.Add_Product(p1);

            // Enviar para o rest e depois meter na base de dados


            Form5 form5 = new Form5();
            form5.Show();

            this.Close();
        }
    }
}
