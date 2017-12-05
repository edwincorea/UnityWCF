Imports System.ServiceModel
Imports Microsoft.Practices.Unity
Imports WCFExample
Imports WCFExample.Model

<TestClass()>
Public Class WCFTest

    Private Property UnityContainer As New UnityContainer
    Private Property CustomerService As ICustomerService

    Public Sub New()
        Me.UnityContainer.RegisterType(Of ICustomerRepository, FakeTestingRepository)

        Dim uri As New Uri("http://coreabe-p.central.bccr.fi.cr/WCFDIExample/CustomerService.svc")
        Dim address As New EndpointAddress(uri)
        Dim binding As New BasicHttpBinding()

        Dim factory As New ChannelFactory(Of ICustomerService)(binding, address)
        Me.CustomerService = factory.CreateChannel()
    End Sub


    <TestMethod()>
    Public Sub TestGetCustomer_CustomerFound_ReturnsCustomer()

        Dim customerRepository As ICustomerRepository = Me.UnityContainer.Resolve(Of ICustomerRepository)()
        Dim customerService As ICustomerService = New CustomerService(customerRepository)

        Dim requestForJoanDoe As New GetCustomerRequest() With {
            .CustomerId = 222
        }

        Dim response As GetCustomerResponse = customerService.GetCustomer(requestForJoanDoe)
        Assert.IsTrue(String.Equals(response.FirstName, "Joan"))
        Assert.IsTrue(String.Equals(response.LastName, "Doe"))

    End Sub

    <TestMethod()>
    Public Sub TestGetCustomer_ProxyClassCustomerFound_ReturnsCustomer()
        Dim requestForSarah As New GetCustomerRequest() With {
            .CustomerId = 3
        }

        Dim response As GetCustomerResponse = Me.CustomerService.GetCustomer(requestForSarah)

        Assert.IsTrue(String.Equals(response.FirstName, "Sarah"))
        Assert.IsTrue(String.Equals(response.LastName, "Davis"))

    End Sub


End Class