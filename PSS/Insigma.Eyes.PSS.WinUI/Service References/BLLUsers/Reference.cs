﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.17626
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Insigma.Eyes.PSS.WinUI.BLLUsers {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BLLUsers.IUserManagerService")]
    public interface IUserManagerService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUserManagerService/Login", ReplyAction="http://tempuri.org/IUserManagerService/LoginResponse")]
        Insigma.Eyes.PSS.Model.UserModel Login(string userName, string password);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUserManagerServiceChannel : Insigma.Eyes.PSS.WinUI.BLLUsers.IUserManagerService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UserManagerServiceClient : System.ServiceModel.ClientBase<Insigma.Eyes.PSS.WinUI.BLLUsers.IUserManagerService>, Insigma.Eyes.PSS.WinUI.BLLUsers.IUserManagerService {
        
        public UserManagerServiceClient() {
        }
        
        public UserManagerServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UserManagerServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserManagerServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UserManagerServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Insigma.Eyes.PSS.Model.UserModel Login(string userName, string password) {
            return base.Channel.Login(userName, password);
        }
    }
}
