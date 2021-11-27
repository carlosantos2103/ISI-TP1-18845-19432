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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Receber os Dados da Base de dados com a requesicoes
            try
            {
                //StringBuilder url = new StringBuilder();

                //url.Append("https://localhost/orders/getteamorders/" + idequipa.Text.ToString());


                //HttpWebRequest request = WebRequest.Create(url.ToString()) as HttpWebRequest;

                //using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                //{
                //    if (response.StatusCode != HttpStatusCode.OK)
                //    {
                //        string message = String.Format("Get falhou!!");

                //        throw new ApplicationException(message);
                //    }
                //}

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
