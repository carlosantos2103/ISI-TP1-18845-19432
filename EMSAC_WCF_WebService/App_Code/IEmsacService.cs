/*
 * <copyright file="Docente.cs" Company = "IPCA - Instituto Politecnico do Cavado e do Ave">
 *      Copyright IPCA-EST. All rights reserved.
 * </copyright>
 * <version>0.2</version>
 *  <user> Joao Ricardo / localhost Santos </users>
 * <number> 18845 / 19432 <number>                                     
 * <email> a18845@alunos.ipca.pt / a19432@alunos.ipca.pt<email>
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace EMSAC_WCF_WebService
{
    [ServiceContract()]
    public interface IEmsacService
    {
        [OperationContract]
        /// Registo de um Infetado
        void RegisterInfected(Infected inf);

        [OperationContract]
        // Registo Isolados
        void RegisterIsolated(Isolated iso);

        [OperationContract]
        //Importar ficherios Json/Xml
        void Relatoriodigital(string file, string extension);

        [OperationContract]
        // Registar Visitas
        VisitsStats GetLastVisits();
    }

    #region Classes

    [DataContract]
    // Classe que gere Infetados
    public class Infected :IInfected
    {
        #region Atributos
        private string name;
        private DateTime birthday;
        private string pacient_number;
        private string contact;
        private string address;
        private DateTime register_date;

        #endregion

        #region Construtor

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

        #endregion

        #region Propriedades


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

        #endregion

    }

    [DataContract]
    // Classe que gere Isolados
    public class Isolated : IIsolated
    {
        #region Atributos

        private string cod_infected;
        private string name;
        private DateTime birthday;
        private string pacient_number;
        private string contact;
        private string address;
        private DateTime register_date;
        #endregion

        #region Contrutor

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

        #endregion

        #region Porpriedades

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
#endregion

    }

    [DataContract]
    // Classe que gere Visitas
    public class VisitsStats
    {
        #region Atributos

        private int visits_count;
        private float irregularities_percent;
        #endregion

        #region Contrutor

        public VisitsStats()
        {
            this.visits_count = 0;
            this.irregularities_percent = 0;
        }

        public VisitsStats(int count, float irreg)
        {
            this.visits_count = count;
            this.irregularities_percent = irreg;
        }

        #endregion

        #region Porpriedades

        [DataMember]
        public int Visits_count
        {
            get { return visits_count; }
            set { visits_count = value; }
        }

        [DataMember]
        public float Irregularities_percent
        {
            get { return irregularities_percent; }
            set { irregularities_percent = value; }
        }

        #endregion

    }

    #region Interfaces

    /// <summary>
    /// Interface Infetados
    /// </summary>
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

    /// <summary>
    ///  Interface Isolados
    /// </summary>
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

    #endregion
}
