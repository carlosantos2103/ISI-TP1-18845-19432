using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace EMSAC_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region Enviar ao Servico

            try
            {
                EMSAC.EmsacServiceClient co = new EMSAC.EmsacServiceClient();
                // Verificar se estamos a enviar uma Pessoa Infetada ou uma Pessoa Isolada
                if (CodigoInfetado.Text.ToString().Length == 0)
                {
                    // Infetado
                    EMSAC.Infected inf = new EMSAC.Infected();
                    inf.Name = Nome.Text;
                    inf.Contact = Contacto.Text;
                    inf.Address = Morada.Text;
                    inf.Pacient_number = NumeroUtente.Text;
                    inf.Birthday = DataNascimento.Value;
                    inf.Register_date = Data.Value;

                    co.RegisterInfected(inf);
                }
                else
                {
                    // Isolado
                    EMSAC.Isolated iso = new EMSAC.Isolated();
                    iso.Name = Nome.Text;
                    iso.Contact = Contacto.Text;
                    iso.Address = Morada.Text;
                    iso.Pacient_number = NumeroUtente.Text;
                    iso.Birthday = DataNascimento.Value;
                    iso.Register_date = Data.Value;
                    iso.Cod_infected = CodigoInfetado.Text;

                    co.RegisterIsolated(iso);
                }


            }
            catch (Exception excep)
            {
                MessageBox.Show(excep.Message);
            }

            #endregion
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Nome_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
