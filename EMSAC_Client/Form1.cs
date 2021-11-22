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
            #region Informacao do Formulario
            //// Aqui mostra como temos de mandar as informacoes do formulario
            //MessageBox.Show("NOME: " + Nome.Text.ToString());
            //MessageBox.Show("Aniversario: " + Aniversario.Text.ToString());
            #endregion

            #region Enviar ao Servico

            try
            {
                // Verificar se estamos a enviar uma Pessoa Infetada ou uma Pessoa Isolada
                if (CodigoInfetado.Text.ToString().Length == 0)
                {
                    // Infetado
                    EMSAC.Infected p1 = new EMSAC.Infected();
                    p1.Name = "Joao";
                    p1.Address = "Famalicao";
                    p1.Pacient_number = "999666333";
                    p1.Register_date = DateTime.Today;
                    p1.Contact = "936936936";
                    p1.Birthday = DateTime.Today;

                    //EMSAC.Infected p1 = new EMSAC.Infected();
                    //EMSAC.Infected p1 = new EMSAC.Infected();


                    EMSAC.EmsacServiceClient co = new EMSAC.EmsacServiceClient();
                    co.RegisterInfected(p1);
                }
                else
                {
                    // Isolado
                    //EMSAC.Infected p1 = new EMSAC.Isolated(Codigo_Infetado ,Nome, Aniversario, Numero_Utente, Contacto, Morada, Data_Registo);

                    //EMSAC.EmsacServiceClient co = new EMSAC.EmsacServiceClient();
                    //co.RegisterIsolated(p1);
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

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
