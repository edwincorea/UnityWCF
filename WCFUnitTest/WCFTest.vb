Imports Microsoft.Practices.Unity
Imports WCFExample
Imports WCFExample.Model

<TestClass()>
Public Class WCFTest

    Private Property UnityContainer As New UnityContainer

    Public Sub New()
        Me.UnityContainer.RegisterType(Of ICustomerRepository, FakeTestingRepository)
    End Sub


    <TestMethod()>
    Public Sub TestGetCustomer_CustomerFound_ReturnsCustomer()

        Dim customerRepository As ICustomerRepository = Me.UnityContainer.Resolve(Of ICustomerRepository)()
        Dim customerService As New CustomerService(customerRepository)

        Dim requestForJoanDoe As New GetCustomerRequest() With {
            .CustomerId = 222
        }

        Dim response As GetCustomerResponse = customerService.GetCustomer(requestForJoanDoe)
        Assert.IsTrue(String.Equals(response.FirstName, "Joan"))
        Assert.IsTrue(String.Equals(response.LastName, "Doe"))

    End Sub

    <TestMethod()>
    Public Sub TestGetCustomer_ProxyClassCustomerFound_ReturnsCustomer()

        Dim client As New CustomerServiceProxy.CustomerServiceClient()
        Dim requestForSarah As New CustomerServiceProxy.GetCustomerRequest() With {
            .CustomerId = 3
        }

        Dim response As CustomerServiceProxy.GetCustomerResponse = client.GetCustomer(requestForSarah)

        Assert.IsTrue(String.Equals(response.FirstName, "Sarah"))
        Assert.IsTrue(String.Equals(response.LastName, "Davis"))

    End Sub


End Class