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

End Class