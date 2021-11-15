using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EMSAC_WCF_WebService
{
    [ServiceContract]
    public interface IEmsacService
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        Infected GetDataUsingDataContract(Infected composite);

        [OperationContract]
        void RegisterInfected(Infected inf, List<Isolated> iso);
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

        [DataMember]
        public bool Name
        {
            get { return Name; }
            set { Name = value; }
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
}
