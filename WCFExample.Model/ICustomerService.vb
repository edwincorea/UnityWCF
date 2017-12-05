
Imports System.ServiceModel

<ServiceContract>
Public Interface ICustomerService

    <OperationContract>
    Function GetCustomer(ByVal request As GetCustomerRequest) As GetCustomerResponse

End Interface
