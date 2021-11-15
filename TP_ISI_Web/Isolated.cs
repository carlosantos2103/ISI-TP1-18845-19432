using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_ISI_Web
{
    [Serializable]
    public class Isolated
    {
        private string cod_infected;
        private string name;
        private DateTime birthday;
        private string pacient_number;
        private string contact;
        private string address;
        private DateTime register_date;


        //Propriedades
        public string Cod_infected
        {
            get { return cod_infected; }
            set { cod_infected = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public string Pacient_number
        {
            get { return pacient_number; }
            set { pacient_number = value; }
        }

        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public DateTime Register_date
        {
            get { return register_date; }
            set
            {
                DateTime aux;
                if (DateTime.TryParse(value.ToString(), out aux) == true)
                {
                    register_date = value;
                }
            }
        }

        // Construtor
        public Isolated()
        {
            this.Name = "";
            this.Pacient_number = "";
            this.Birthday = DateTime.Now;
            this.Contact = "";
            this.Address = "";
            this.Register_date = DateTime.Now;
        }

        public Isolated(string name, DateTime birthday, string pacient_number, string contact, string address, DateTime register_date, string cod_infected)
        {
            this.Name = name;
            this.Pacient_number = pacient_number;
            this.Birthday = birthday;
            this.Contact = contact;
            this.Address = address;
            this.Register_date = register_date;
            this.Cod_infected = cod_infected;
        }

        // Metodos
        public void describe()
        {
            Console.WriteLine("\n===========================================================");
            Console.WriteLine("\nNome do Infetado: " + name);
            Console.WriteLine("\n-> Nascimento: " + birthday);
            Console.WriteLine("\n-> Numero de Paciente: " + pacient_number);
            Console.WriteLine("\n-> Contacto: " + contact);
            Console.WriteLine("\n-> Morada: " + address);
            Console.WriteLine("\n-> Data registo: " + register_date);
            Console.WriteLine("\n===========================================================");
        }
    }
}