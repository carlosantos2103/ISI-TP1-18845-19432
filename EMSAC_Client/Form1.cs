/*
 * <copyright file="Docente.cs" Company = "IPCA - Instituto Politecnico do Cavado e do Ave">
 *      Copyright IPCA-EST. All rights reserved.
 * </copyright>
 * <version>0.2</version>
 *  <user> Joao Ricardo / Carlos Santos </users>
 * <number> 18845 / 19432 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19432@alunos.ipca.pt<email>
 */

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
    /// <summary>
    /// Form que gere o registo de Infetados e Isolados
    /// </summary>
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
                // Instanciar o serviço
                EMSAC.EmsacServiceClient co = new EMSAC.EmsacServiceClient();
                // Verificar se estamos a enviar uma Pessoa Infetada ou uma Pessoa Isolada
                if (CodigoInfetado.Text.ToString().Length == 0)
                {
                    // Criar um Infetado
                    EMSAC.Infected inf = new EMSAC.Infected();
                    inf.Name = Nome.Text;
                    inf.Contact = Contacto.Text;
                    inf.Address = Morada.Text;
                    inf.Pacient_number = NumeroUtente.Text;
                    inf.Birthday = DataNascimento.Value;
                    inf.Register_date = Data.Value;

                    // Registar um Infetado
                    co.RegisterInfected(inf);
                }
                else
                {
                    // Criar um Isolado
                    EMSAC.Isolated iso = new EMSAC.Isolated();
                    iso.Name = Nome.Text;
                    iso.Contact = Contacto.Text;
                    iso.Address = Morada.Text;
                    iso.Pacient_number = NumeroUtente.Text;
                    iso.Birthday = DataNascimento.Value;
                    iso.Register_date = Data.Value;
                    iso.Cod_infected = CodigoInfetado.Text;

                    // Registar um Isolado
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
