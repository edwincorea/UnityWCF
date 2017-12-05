
Public Class CustomerRepository
    Implements ICustomerRepository

    Private ReadOnly _customers As List(Of Customer) =
        New List(Of Customer) From {
                    New Customer(1,
                                 "Bill",
                                 "Smith"),
                     New Customer(2,
                                  "John",
                                  "Jones"),
                     New Customer(3,
                                  "Sarah",
                                  "Davis")}

    Public Function Query() As IQueryable(Of Customer) _
        Implements ICustomerRepository.Query

        Return _customers.AsQueryable()
    End Function

End Class
