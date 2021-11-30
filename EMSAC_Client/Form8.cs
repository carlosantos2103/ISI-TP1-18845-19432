using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;                   //Referir "System.Text.Json" em References
using System.Windows.Forms;

namespace EMSAC_Client
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://emsacwebapi.azurewebsites.net/orders/login";
            string username = textBox_user.Text.ToString();
            string password = textBox_pwd.Text.ToString();

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Envio da requisição de autenticação + envio de token
                HttpResponseMessage respToken = client.PostAsync(url, new StringContent(JsonSerializer.Serialize(new
                { username = username, password = password }), Encoding.UTF8, "application/json")).Result;

                //obtém o token gerado
                string conteudo = respToken.Content.ReadAsStringAsync().Result;

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(AuthenticateResponse));
                var ms = new MemoryStream(Encoding.Unicode.GetBytes(conteudo));
                AuthenticateResponse t = (AuthenticateResponse)jsonSerializer.ReadObject(ms);

                if (t.token != "Microsoft.AspNetCore.Mvc.UnauthorizedResult")
                {
                    //Guarda o token para poder ser usado em outros requests
                    Program.token = t.token;

                    this.Hide();
                    var form3 = new Form3();
                    form3.Closed += (s, args) => this.Close();
                    form3.Show();
                }
                else
                    MessageBox.Show("Utilizador ou Password incorretos!");

            }
            catch (ApplicationException exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var form3 = new Form3();
            form3.Closed += (s, args) => this.Close();
            form3.Show();
        }
    }
}
