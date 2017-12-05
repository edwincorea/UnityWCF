
Imports System.ServiceModel.Description
Imports Microsoft.Practices.Unity

Public Class UnityServiceHost
    Inherits ServiceHost

    Public Sub New(ByVal container As IUnityContainer, ByVal serviceType As Type, ParamArray baseAddresses As Uri())
        MyBase.New(serviceType, baseAddresses)

        If container Is Nothing Then
            Throw New ArgumentNullException("container")
        End If

        ApplyServiceBehaviors(container)

        ApplyContractBehaviors(container)

        For Each contractDescription In ImplementedContracts.Values
            Dim contractBehavior = New UnityContractBehavior(New UnityInstanceProvider(container, contractDescription.ContractType))
            contractDescription.Behaviors.Add(contractBehavior)
        Next
    End Sub

    Private Sub ApplyServiceBehaviors(ByVal container As IUnityContainer)
        Dim registeredServiceBehaviors = container.ResolveAll(Of IServiceBehavior)()
        For Each serviceBehavior In registeredServiceBehaviors
            Description.Behaviors.Add(serviceBehavior)
        Next
    End Sub

    Private Sub ApplyContractBehaviors(ByVal container As IUnityContainer)
        Dim registeredContractBehaviors = container.ResolveAll(Of IContractBehavior)()
        For Each contractBehavior In registeredContractBehaviors
            For Each contractDescription In ImplementedContracts.Values
                contractDescription.Behaviors.Add(contractBehavior)
            Next
        Next
    End Sub

End Class
