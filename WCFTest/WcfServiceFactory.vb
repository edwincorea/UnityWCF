
Imports Microsoft.Practices.Unity
Imports Unity.WCF

Public Class WcfServiceFactory
    Inherits UnityServiceHostFactory

    Protected Overrides Sub ConfigureContainer(ByVal container As IUnityContainer)

        container.
            RegisterType(Of ICustomerService, CustomerService)().
            RegisterType(Of ICustomerRepository, CustomerRepository)()
    End Sub
End Class
