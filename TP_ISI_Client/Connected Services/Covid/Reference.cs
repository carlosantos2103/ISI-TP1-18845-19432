﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TP_ISI_Client.Covid {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Covid.WebService1Soap")]
    public interface WebService1Soap {
        
        // CODEGEN: Generating message contract since element name infected from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddInfected", ReplyAction="*")]
        TP_ISI_Client.Covid.AddInfectedResponse AddInfected(TP_ISI_Client.Covid.AddInfectedRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/AddInfected", ReplyAction="*")]
        System.Threading.Tasks.Task<TP_ISI_Client.Covid.AddInfectedResponse> AddInfectedAsync(TP_ISI_Client.Covid.AddInfectedRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddInfectedRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddInfected", Namespace="http://tempuri.org/", Order=0)]
        public TP_ISI_Client.Covid.AddInfectedRequestBody Body;
        
        public AddInfectedRequest() {
        }
        
        public AddInfectedRequest(TP_ISI_Client.Covid.AddInfectedRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class AddInfectedRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string infected;
        
        public AddInfectedRequestBody() {
        }
        
        public AddInfectedRequestBody(string infected) {
            this.infected = infected;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class AddInfectedResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="AddInfectedResponse", Namespace="http://tempuri.org/", Order=0)]
        public TP_ISI_Client.Covid.AddInfectedResponseBody Body;
        
        public AddInfectedResponse() {
        }
        
        public AddInfectedResponse(TP_ISI_Client.Covid.AddInfectedResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class AddInfectedResponseBody {
        
        public AddInfectedResponseBody() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebService1SoapChannel : TP_ISI_Client.Covid.WebService1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebService1SoapClient : System.ServiceModel.ClientBase<TP_ISI_Client.Covid.WebService1Soap>, TP_ISI_Client.Covid.WebService1Soap {
        
        public WebService1SoapClient() {
        }
        
        public WebService1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        TP_ISI_Client.Covid.AddInfectedResponse TP_ISI_Client.Covid.WebService1Soap.AddInfected(TP_ISI_Client.Covid.AddInfectedRequest request) {
            return base.Channel.AddInfected(request);
        }
        
        public void AddInfected(string infected) {
            TP_ISI_Client.Covid.AddInfectedRequest inValue = new TP_ISI_Client.Covid.AddInfectedRequest();
            inValue.Body = new TP_ISI_Client.Covid.AddInfectedRequestBody();
            inValue.Body.infected = infected;
            TP_ISI_Client.Covid.AddInfectedResponse retVal = ((TP_ISI_Client.Covid.WebService1Soap)(this)).AddInfected(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TP_ISI_Client.Covid.AddInfectedResponse> TP_ISI_Client.Covid.WebService1Soap.AddInfectedAsync(TP_ISI_Client.Covid.AddInfectedRequest request) {
            return base.Channel.AddInfectedAsync(request);
        }
        
        public System.Threading.Tasks.Task<TP_ISI_Client.Covid.AddInfectedResponse> AddInfectedAsync(string infected) {
            TP_ISI_Client.Covid.AddInfectedRequest inValue = new TP_ISI_Client.Covid.AddInfectedRequest();
            inValue.Body = new TP_ISI_Client.Covid.AddInfectedRequestBody();
            inValue.Body.infected = infected;
            return ((TP_ISI_Client.Covid.WebService1Soap)(this)).AddInfectedAsync(inValue);
        }
    }
}
