﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EMSAC_WCF_WebService
{
    [ServiceContract()]
    public interface IEmsacService
    {
        [OperationContract]
        void RegisterInfected(Infected inf);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Infected 
    {
        private string name;
        private DateTime birthday;
        private string pacient_number;
        private string contact;
        private string address;
        private DateTime register_date;


        public Infected()
        {
            this.Name = "";
            this.Birthday = DateTime.Today;
            this.Pacient_number = "";
            this.Contact = "";
            this.Address = "";
            this.Register_date = DateTime.Now;
        }

        public Infected(string name, DateTime birthday, string pacient_number, string contact, string address, DateTime register_date)
        {
            this.Name = name;
            this.Birthday = birthday;
            this.Pacient_number = pacient_number;
            this.Contact = contact;
            this.Address = address;
            this.Register_date = register_date;
        }


        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        [DataMember]
        public string Pacient_number
        {
            get { return pacient_number; }
            set { pacient_number = value; }
        }

        [DataMember]
        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        [DataMember]
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
    }
    
    [DataContract]
    public class Isolated 
    {
        private string cod_infected;
        private string name;
        private DateTime birthday;
        private string pacient_number;
        private string contact;
        private string address;
        private DateTime register_date;

        public Isolated()
        {
            this.Cod_infected = "0";
            this.Name = "";
            this.Birthday = DateTime.Today;
            this.Pacient_number = "";
            this.Contact = "";
            this.Address = "";
            this.Register_date = DateTime.Now;
        }

        public Isolated(string cod_infected, string name, DateTime birthday, string pacient_number, string contact, string address, DateTime register_date)
        {
            this.Cod_infected = cod_infected;
            this.Name = name;
            this.Birthday = birthday;
            this.Pacient_number = pacient_number;
            this.Contact = contact;
            this.Address = address;
            this.Register_date = register_date;
        }


        [DataMember]
        public string Cod_infected
        {
            get { return cod_infected; }
            set { cod_infected = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        [DataMember]
        public string Pacient_number
        {
            get { return pacient_number; }
            set { pacient_number = value; }
        }

        [DataMember]
        public string Contact
        {
            get { return contact; }
            set { contact = value; }
        }

        [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        [DataMember]
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
    }

    #region Interfaces

    public interface IInfected
    {
        /// <summary>
        /// Manipula o atributo 
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Manipula o atributo 
        /// </summary>
        DateTime Birthday
        {
            get;
            set;
        }

        /// <summary>
        /// Manipula o atributo 
        /// </summary>
        string Pacient_number
        {
            get;
            set;
        }


        /// <summary>
        /// Manipula o atributo 
        /// </summary>
        string Contact
        {
            get;
            set;
        }

        /// <summary>
        /// Manipula o atributo 
        /// </summary>
        string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Manipula o atributo 
        /// </summary>
        DateTime Register_date
        {
            get;
            set;
        }
    }

    public interface IIsolated
    {

        /// <summary>
        /// Manipula o atributo 
        /// </summary>
        string Cod_infected
        {
            get;
            set;
        }
        /// <summary>
        /// Manipula o atributo 
        /// </summary>
        string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Manipula o atributo 
        /// </summary>
        DateTime Birthday
        {
            get;
            set;
        }

        /// <summary>
        /// Manipula o atributo 
        /// </summary>
        string Pacient_number
        {
            get;
            set;
        }


        /// <summary>
        /// Manipula o atributo 
        /// </summary>
        string Contact
        {
            get;
            set;
        }

        /// <summary>
        /// Manipula o atributo 
        /// </summary>
        string Address
        {
            get;
            set;
        }

        /// <summary>
        /// Manipula o atributo 
        /// </summary>
        DateTime Register_date
        {
            get;
            set;
        }
    }

    #endregion
}
