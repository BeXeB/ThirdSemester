﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 16.0.30104.148
// 
namespace client_desktop.ListServiceReference {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MemoList", Namespace="http://schemas.datacontract.org/2004/07/HouseManagerService")]
    public partial class MemoList : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string DescriptionField;
        
        private int IdField;
        
        private client_desktop.ListServiceReference.Person PersonField;
        
        private string TitleField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public client_desktop.ListServiceReference.Person Person {
            get {
                return this.PersonField;
            }
            set {
                if ((object.ReferenceEquals(this.PersonField, value) != true)) {
                    this.PersonField = value;
                    this.RaisePropertyChanged("Person");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="Person", Namespace="http://schemas.datacontract.org/2004/07/HouseManagerService")]
    public partial class Person : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.DateTime DateOfBirthField;
        
        private string EmailField;
        
        private string FirstNameField;
        
        private int IdField;
        
        private string LastNameField;
        
        private string PassWordField;
        
        private string PhoneField;
        
        private string UserNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DateOfBirth {
            get {
                return this.DateOfBirthField;
            }
            set {
                if ((this.DateOfBirthField.Equals(value) != true)) {
                    this.DateOfBirthField = value;
                    this.RaisePropertyChanged("DateOfBirth");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email {
            get {
                return this.EmailField;
            }
            set {
                if ((object.ReferenceEquals(this.EmailField, value) != true)) {
                    this.EmailField = value;
                    this.RaisePropertyChanged("Email");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PassWord {
            get {
                return this.PassWordField;
            }
            set {
                if ((object.ReferenceEquals(this.PassWordField, value) != true)) {
                    this.PassWordField = value;
                    this.RaisePropertyChanged("PassWord");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Phone {
            get {
                return this.PhoneField;
            }
            set {
                if ((object.ReferenceEquals(this.PhoneField, value) != true)) {
                    this.PhoneField = value;
                    this.RaisePropertyChanged("Phone");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string UserName {
            get {
                return this.UserNameField;
            }
            set {
                if ((object.ReferenceEquals(this.UserNameField, value) != true)) {
                    this.UserNameField = value;
                    this.RaisePropertyChanged("UserName");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ListServiceReference.IListService")]
    public interface IListService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IListService/CreateList", ReplyAction="http://tempuri.org/IListService/CreateListResponse")]
        System.Threading.Tasks.Task<int> CreateListAsync(client_desktop.ListServiceReference.MemoList list, string sessionid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IListService/UpdateList", ReplyAction="http://tempuri.org/IListService/UpdateListResponse")]
        System.Threading.Tasks.Task<bool> UpdateListAsync(client_desktop.ListServiceReference.MemoList list, string sessionid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IListService/GetAllList", ReplyAction="http://tempuri.org/IListService/GetAllListResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<client_desktop.ListServiceReference.MemoList>> GetAllListAsync(string sessionid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IListService/DeleteList", ReplyAction="http://tempuri.org/IListService/DeleteListResponse")]
        System.Threading.Tasks.Task<bool> DeleteListAsync(client_desktop.ListServiceReference.MemoList list, string sessionid);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IListServiceChannel : client_desktop.ListServiceReference.IListService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ListServiceClient : System.ServiceModel.ClientBase<client_desktop.ListServiceReference.IListService>, client_desktop.ListServiceReference.IListService {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ListServiceClient() : 
                base(ListServiceClient.GetDefaultBinding(), ListServiceClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IListService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ListServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(ListServiceClient.GetBindingForEndpoint(endpointConfiguration), ListServiceClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ListServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ListServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ListServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ListServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ListServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<int> CreateListAsync(client_desktop.ListServiceReference.MemoList list, string sessionid) {
            return base.Channel.CreateListAsync(list, sessionid);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateListAsync(client_desktop.ListServiceReference.MemoList list, string sessionid) {
            return base.Channel.UpdateListAsync(list, sessionid);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<client_desktop.ListServiceReference.MemoList>> GetAllListAsync(string sessionid) {
            return base.Channel.GetAllListAsync(sessionid);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteListAsync(client_desktop.ListServiceReference.MemoList list, string sessionid) {
            return base.Channel.DeleteListAsync(list, sessionid);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IListService)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IListService)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:8733/Design_Time_Addresses/HouseManagerService/ListService/");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return ListServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IListService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return ListServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IListService);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_IListService,
        }
    }
}
