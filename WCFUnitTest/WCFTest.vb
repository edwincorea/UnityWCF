Imports System.ServiceModel
Imports Microsoft.Practices.Unity
Imports Moq
Imports WCFExample
Imports WCFExample.Model

<TestClass()>
Public Class WCFTest

    Private Property CustomerService As ICustomerService

    Public Sub New()
        Dim uri As New Uri("http://coreabe-p.central.bccr.fi.cr/WCFDIExample/CustomerService.svc")
        Dim address As New EndpointAddress(uri)
        Dim binding As New BasicHttpBinding()

        Dim factory As New ChannelFactory(Of ICustomerService)(binding, address)
        Me.CustomerService = factory.CreateChannel()
    End Sub

    <TestMethod()>
    Public Sub TestGetCustomerMockRepository_CustomerFound_ReturnsCustomer()

        Dim _customers As List(Of Customer) =
            New List(Of Customer) From {
                    New Customer(666,
                                 "Alice",
                                 "Snow"),
                     New Customer(777,
                                  "Jack",
                                  "Reacher"),
                     New Customer(888,
                                  "Tom",
                                  "Bolt")}

        Dim customerRepositoryMock As New Mock(Of ICustomerRepository)()
        customerRepositoryMock.Setup(Function(m) m.Query).Returns(_customers.AsQueryable)

        Dim customerService As ICustomerService = New CustomerService(customerRepositoryMock.Object)

        Dim request As New GetCustomerRequest() With {
            .CustomerId = 777
        }

        Dim response As GetCustomerResponse = customerService.GetCustomer(request)

        Assert.IsTrue(String.Equals(response.FirstName, "Jack"))
        Assert.IsTrue(String.Equals(response.LastName, "Reacher"))

    End Sub

    <TestMethod()>
    Public Sub TestGetCustomer_ProxyClassCustomerFound_ReturnsCustomer()
        Dim request As New GetCustomerRequest() With {
            .CustomerId = 3
        }

        Dim response As GetCustomerResponse = Me.CustomerService.GetCustomer(request)

        Assert.IsTrue(String.Equals(response.FirstName, "Sarah"))
        Assert.IsTrue(String.Equals(response.LastName, "Davis"))

    End Sub


End Class