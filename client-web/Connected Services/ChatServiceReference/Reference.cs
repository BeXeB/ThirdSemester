﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatServiceReference
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ChatMessage", Namespace="http://schemas.datacontract.org/2004/07/HouseManagerService")]
    public partial class ChatMessage : object
    {
        
        private int IdField;
        
        private string MessageField;
        
        private System.DateTime SendDateField;
        
        private ChatServiceReference.Person SenderField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message
        {
            get
            {
                return this.MessageField;
            }
            set
            {
                this.MessageField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime SendDate
        {
            get
            {
                return this.SendDateField;
            }
            set
            {
                this.SendDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ChatServiceReference.Person Sender
        {
            get
            {
                return this.SenderField;
            }
            set
            {
                this.SenderField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Person", Namespace="http://schemas.datacontract.org/2004/07/HouseManagerService")]
    public partial class Person : object
    {
        
        private System.DateTime DateOfBirthField;
        
        private string EmailField;
        
        private string FirstNameField;
        
        private int IdField;
        
        private string LastNameField;
        
        private string PassWordField;
        
        private string PhoneField;
        
        private string UserNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DateOfBirth
        {
            get
            {
                return this.DateOfBirthField;
            }
            set
            {
                this.DateOfBirthField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email
        {
            get
            {
                return this.EmailField;
            }
            set
            {
                this.EmailField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName
        {
            get
            {
                return this.FirstNameField;
            }
            set
            {
                this.FirstNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName
        {
            get
            {
                return this.LastNameField;
            }
            set
            {
                this.LastNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PassWord
        {
            get
            {
                return this.PassWordField;
            }
            set
            {
                this.PassWordField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone
        {
            get
            {
                return this.PhoneField;
            }
            set
            {
                this.PhoneField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName
        {
            get
            {
                return this.UserNameField;
            }
            set
            {
                this.UserNameField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ChatServiceReference.IChatService")]
    public interface IChatService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/SendMessage", ReplyAction="http://tempuri.org/IChatService/SendMessageResponse")]
        System.Threading.Tasks.Task<bool> SendMessageAsync(ChatServiceReference.ChatMessage message, int houseid, string sessionid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IChatService/GetChatMessages", ReplyAction="http://tempuri.org/IChatService/GetChatMessagesResponse")]
        System.Threading.Tasks.Task<ChatServiceReference.ChatMessage[]> GetChatMessagesAsync(int houseid);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface IChatServiceChannel : ChatServiceReference.IChatService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class ChatServiceClient : System.ServiceModel.ClientBase<ChatServiceReference.IChatService>, ChatServiceReference.IChatService
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ChatServiceClient() : 
                base(ChatServiceClient.GetDefaultBinding(), ChatServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IChatService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ChatServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(ChatServiceClient.GetBindingForEndpoint(endpointConfiguration), ChatServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ChatServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ChatServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ChatServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ChatServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ChatServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<bool> SendMessageAsync(ChatServiceReference.ChatMessage message, int houseid, string sessionid)
        {
            return base.Channel.SendMessageAsync(message, houseid, sessionid);
        }
        
        public System.Threading.Tasks.Task<ChatServiceReference.ChatMessage[]> GetChatMessagesAsync(int houseid)
        {
            return base.Channel.GetChatMessagesAsync(houseid);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IChatService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IChatService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:8733/Design_Time_Addresses/HouseManagerService/ChatService/");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return ChatServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IChatService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return ChatServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IChatService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IChatService,
        }
    }
}
