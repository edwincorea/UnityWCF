
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Dispatcher
Imports Microsoft.Practices.Unity

Public Class UnityInstanceProvider
    Implements IInstanceProvider

    Private ReadOnly _container As IUnityContainer
    Private ReadOnly _contractType As Type

    Public Sub New(ByVal container As IUnityContainer, ByVal contractType As Type)
        If container Is Nothing Then
            Throw New ArgumentNullException("container")
        End If

        If contractType Is Nothing Then
            Throw New ArgumentNullException("contractType")
        End If

        _container = container
        _contractType = contractType

    End Sub

    Public Function GetInstance(ByVal instanceContext As InstanceContext, ByVal message As Message) As Object _
        Implements IInstanceProvider.GetInstance

        Dim childContainer = instanceContext.Extensions.Find(Of UnityInstanceContextExtension)().GetChildContainer(_container)
        Return childContainer.Resolve(_contractType)
    End Function

    Public Function GetInstance(ByVal instanceContext As InstanceContext) As Object _
        Implements IInstanceProvider.GetInstance

        Return GetInstance(instanceContext, Nothing)
    End Function

    Public Sub ReleaseInstance(ByVal instanceContext As InstanceContext, ByVal instance As Object) _
        Implements IInstanceProvider.ReleaseInstance

        instanceContext.Extensions.Find(Of UnityInstanceContextExtension)().DisposeOfChildContainer()
    End Sub

End Class