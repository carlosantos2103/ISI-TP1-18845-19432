﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMSAC_Client.EMSAC {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Infected", Namespace="http://schemas.datacontract.org/2004/07/EMSAC_WCF_WebService")]
    [System.SerializableAttribute()]
    public partial class Infected : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime BirthdayField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContactField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Pacient_numberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime Register_dateField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Birthday {
            get {
                return this.BirthdayField;
            }
            set {
                if ((this.BirthdayField.Equals(value) != true)) {
                    this.BirthdayField = value;
                    this.RaisePropertyChanged("Birthday");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Contact {
            get {
                return this.ContactField;
            }
            set {
                if ((object.ReferenceEquals(this.ContactField, value) != true)) {
                    this.ContactField = value;
                    this.RaisePropertyChanged("Contact");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Name {
            get {
                return this.NameField;
            }
            set {
                if ((this.NameField.Equals(value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pacient_number {
            get {
                return this.Pacient_numberField;
            }
            set {
                if ((object.ReferenceEquals(this.Pacient_numberField, value) != true)) {
                    this.Pacient_numberField = value;
                    this.RaisePropertyChanged("Pacient_number");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Register_date {
            get {
                return this.Register_dateField;
            }
            set {
                if ((this.Register_dateField.Equals(value) != true)) {
                    this.Register_dateField = value;
                    this.RaisePropertyChanged("Register_date");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Isolated", Namespace="http://schemas.datacontract.org/2004/07/EMSAC_WCF_WebService")]
    [System.SerializableAttribute()]
    public partial class Isolated : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AddressField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime BirthdayField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Cod_infectedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ContactField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Pacient_numberField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime Register_dateField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Address {
            get {
                return this.AddressField;
            }
            set {
                if ((object.ReferenceEquals(this.AddressField, value) != true)) {
                    this.AddressField = value;
                    this.RaisePropertyChanged("Address");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Birthday {
            get {
                return this.BirthdayField;
            }
            set {
                if ((this.BirthdayField.Equals(value) != true)) {
                    this.BirthdayField = value;
                    this.RaisePropertyChanged("Birthday");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Cod_infected {
            get {
                return this.Cod_infectedField;
            }
            set {
                if ((object.ReferenceEquals(this.Cod_infectedField, value) != true)) {
                    this.Cod_infectedField = value;
                    this.RaisePropertyChanged("Cod_infected");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Contact {
            get {
                return this.ContactField;
            }
            set {
                if ((object.ReferenceEquals(this.ContactField, value) != true)) {
                    this.ContactField = value;
                    this.RaisePropertyChanged("Contact");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Pacient_number {
            get {
                return this.Pacient_numberField;
            }
            set {
                if ((object.ReferenceEquals(this.Pacient_numberField, value) != true)) {
                    this.Pacient_numberField = value;
                    this.RaisePropertyChanged("Pacient_number");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Register_date {
            get {
                return this.Register_dateField;
            }
            set {
                if ((this.Register_dateField.Equals(value) != true)) {
                    this.Register_dateField = value;
                    this.RaisePropertyChanged("Register_date");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="EMSAC.IEmsacService")]
    public interface IEmsacService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmsacService/GetData", ReplyAction="http://tempuri.org/IEmsacService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmsacService/GetData", ReplyAction="http://tempuri.org/IEmsacService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmsacService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IEmsacService/GetDataUsingDataContractResponse")]
        EMSAC_Client.EMSAC.Infected GetDataUsingDataContract(EMSAC_Client.EMSAC.Infected composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmsacService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/IEmsacService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<EMSAC_Client.EMSAC.Infected> GetDataUsingDataContractAsync(EMSAC_Client.EMSAC.Infected composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmsacService/RegisterInfected", ReplyAction="http://tempuri.org/IEmsacService/RegisterInfectedResponse")]
        void RegisterInfected(EMSAC_Client.EMSAC.Infected inf, EMSAC_Client.EMSAC.Isolated[] iso);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmsacService/RegisterInfected", ReplyAction="http://tempuri.org/IEmsacService/RegisterInfectedResponse")]
        System.Threading.Tasks.Task RegisterInfectedAsync(EMSAC_Client.EMSAC.Infected inf, EMSAC_Client.EMSAC.Isolated[] iso);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IEmsacServiceChannel : EMSAC_Client.EMSAC.IEmsacService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class EmsacServiceClient : System.ServiceModel.ClientBase<EMSAC_Client.EMSAC.IEmsacService>, EMSAC_Client.EMSAC.IEmsacService {
        
        public EmsacServiceClient() {
        }
        
        public EmsacServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public EmsacServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmsacServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public EmsacServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public EMSAC_Client.EMSAC.Infected GetDataUsingDataContract(EMSAC_Client.EMSAC.Infected composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<EMSAC_Client.EMSAC.Infected> GetDataUsingDataContractAsync(EMSAC_Client.EMSAC.Infected composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public void RegisterInfected(EMSAC_Client.EMSAC.Infected inf, EMSAC_Client.EMSAC.Isolated[] iso) {
            base.Channel.RegisterInfected(inf, iso);
        }
        
        public System.Threading.Tasks.Task RegisterInfectedAsync(EMSAC_Client.EMSAC.Infected inf, EMSAC_Client.EMSAC.Isolated[] iso) {
            return base.Channel.RegisterInfectedAsync(inf, iso);
        }
    }
}
