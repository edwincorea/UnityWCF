Imports WCFExample.Model

Class FakeTestingRepository
    Implements ICustomerRepository

    Private ReadOnly _customers As List(Of Customer) =
        New List(Of Customer) From {
                    New Customer(111,
                                 "Jon",
                                 "Doe"),
                     New Customer(222,
                                  "Joan",
                                  "Doe"),
                     New Customer(333,
                                  "James",
                                  "Doe")}

    Public Function Query() As IQueryable(Of Customer) _
        Implements ICustomerRepository.Query

        Return _customers.AsQueryable()
    End Function

End Class
