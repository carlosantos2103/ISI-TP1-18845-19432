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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="VisitsStats", Namespace="http://schemas.datacontract.org/2004/07/EMSAC_WCF_WebService")]
    [System.SerializableAttribute()]
    public partial class VisitsStats : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private double Irregularities_percentField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Visits_countField;
        
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
        public double Irregularities_percent {
            get {
                return this.Irregularities_percentField;
            }
            set {
                if ((this.Irregularities_percentField.Equals(value) != true)) {
                    this.Irregularities_percentField = value;
                    this.RaisePropertyChanged("Irregularities_percent");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Visits_count {
            get {
                return this.Visits_countField;
            }
            set {
                if ((this.Visits_countField.Equals(value) != true)) {
                    this.Visits_countField = value;
                    this.RaisePropertyChanged("Visits_count");
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
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmsacService/RegisterInfected", ReplyAction="http://tempuri.org/IEmsacService/RegisterInfectedResponse")]
        void RegisterInfected(EMSAC_Client.EMSAC.Infected inf);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmsacService/RegisterInfected", ReplyAction="http://tempuri.org/IEmsacService/RegisterInfectedResponse")]
        System.Threading.Tasks.Task RegisterInfectedAsync(EMSAC_Client.EMSAC.Infected inf);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmsacService/RegisterIsolated", ReplyAction="http://tempuri.org/IEmsacService/RegisterIsolatedResponse")]
        void RegisterIsolated(EMSAC_Client.EMSAC.Isolated iso);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmsacService/RegisterIsolated", ReplyAction="http://tempuri.org/IEmsacService/RegisterIsolatedResponse")]
        System.Threading.Tasks.Task RegisterIsolatedAsync(EMSAC_Client.EMSAC.Isolated iso);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmsacService/Relatoriodigital", ReplyAction="http://tempuri.org/IEmsacService/RelatoriodigitalResponse")]
        void Relatoriodigital(string file, string extension);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmsacService/Relatoriodigital", ReplyAction="http://tempuri.org/IEmsacService/RelatoriodigitalResponse")]
        System.Threading.Tasks.Task RelatoriodigitalAsync(string file, string extension);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmsacService/GetLastVisits", ReplyAction="http://tempuri.org/IEmsacService/GetLastVisitsResponse")]
        EMSAC_Client.EMSAC.VisitsStats GetLastVisits();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IEmsacService/GetLastVisits", ReplyAction="http://tempuri.org/IEmsacService/GetLastVisitsResponse")]
        System.Threading.Tasks.Task<EMSAC_Client.EMSAC.VisitsStats> GetLastVisitsAsync();
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
        
        public void RegisterInfected(EMSAC_Client.EMSAC.Infected inf) {
            base.Channel.RegisterInfected(inf);
        }
        
        public System.Threading.Tasks.Task RegisterInfectedAsync(EMSAC_Client.EMSAC.Infected inf) {
            return base.Channel.RegisterInfectedAsync(inf);
        }
        
        public void RegisterIsolated(EMSAC_Client.EMSAC.Isolated iso) {
            base.Channel.RegisterIsolated(iso);
        }
        
        public System.Threading.Tasks.Task RegisterIsolatedAsync(EMSAC_Client.EMSAC.Isolated iso) {
            return base.Channel.RegisterIsolatedAsync(iso);
        }
        
        public void Relatoriodigital(string file, string extension) {
            base.Channel.Relatoriodigital(file, extension);
        }
        
        public System.Threading.Tasks.Task RelatoriodigitalAsync(string file, string extension) {
            return base.Channel.RelatoriodigitalAsync(file, extension);
        }
        
        public EMSAC_Client.EMSAC.VisitsStats GetLastVisits() {
            return base.Channel.GetLastVisits();
        }
        
        public System.Threading.Tasks.Task<EMSAC_Client.EMSAC.VisitsStats> GetLastVisitsAsync() {
            return base.Channel.GetLastVisitsAsync();
        }
    }
}
