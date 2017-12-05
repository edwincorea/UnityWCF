Module Test

    Sub Main()
        Dim client As New CustomerServiceProxy.CustomerServiceClient
        Dim request As New CustomerServiceProxy.GetCustomerRequest With {.CustomerId = 1}
        Dim response As CustomerServiceProxy.GetCustomerResponse

        Try
            response = client.GetCustomer(request)
            Console.WriteLine("User found: {0} {1}", response.FirstName, response.LastName)
            Console.ReadKey()
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub

End Module
