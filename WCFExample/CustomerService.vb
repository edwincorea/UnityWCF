Imports WCFExample.Model

Public Class CustomerService
    Implements ICustomerService

    Private ReadOnly _customerRepository As ICustomerRepository

    Public Sub New(ByVal customerRepository As ICustomerRepository)
        _customerRepository = customerRepository
    End Sub

    Public Function GetCustomer(ByVal request As GetCustomerRequest) As GetCustomerResponse _
        Implements ICustomerService.GetCustomer

        Dim query = From customer In _customerRepository.Query()
                    Where customer.Id = request.CustomerId
                    Select New GetCustomerResponse With {
                        .FirstName = customer.FirstName,
                        .LastName = customer.LastName
                        }

        Return query.FirstOrDefault()
    End Function
End Class