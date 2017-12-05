Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description
Imports System.ServiceModel.Dispatcher

Public Class UnityContractBehavior
    Implements IContractBehavior

    Private ReadOnly _instanceProvider As IInstanceProvider

    Public Sub New(ByVal instanceProvider As IInstanceProvider)
        If instanceProvider Is Nothing Then
            Throw New ArgumentNullException("instanceProvider")
        End If

        _instanceProvider = instanceProvider
    End Sub

    Public Sub AddBindingParameters(ByVal contractDescription As ContractDescription, ByVal endpoint As ServiceEndpoint, ByVal bindingParameters As BindingParameterCollection) _
        Implements IContractBehavior.AddBindingParameters
    End Sub

    Public Sub ApplyClientBehavior(ByVal contractDescription As ContractDescription, ByVal endpoint As ServiceEndpoint, ByVal clientRuntime As ClientRuntime) _
        Implements IContractBehavior.ApplyClientBehavior
    End Sub

    Public Sub ApplyDispatchBehavior(ByVal contractDescription As ContractDescription, ByVal endpoint As ServiceEndpoint, ByVal dispatchRuntime As DispatchRuntime) _
        Implements IContractBehavior.ApplyDispatchBehavior

        dispatchRuntime.InstanceProvider = _instanceProvider
        dispatchRuntime.InstanceContextInitializers.Add(New UnityInstanceContextInitializer())
    End Sub

    Public Sub Validate(ByVal contractDescription As ContractDescription, ByVal endpoint As ServiceEndpoint) _
        Implements IContractBehavior.Validate
    End Sub
End Class


