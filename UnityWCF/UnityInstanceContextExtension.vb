Imports Microsoft.Practices.Unity

Public Class UnityInstanceContextExtension
    Implements IExtension(Of InstanceContext)

    Private _childContainer As IUnityContainer

    Public Function GetChildContainer(ByVal container As IUnityContainer) As IUnityContainer
        If container Is Nothing Then
            Throw New ArgumentNullException("container")
        End If

        If _childContainer Is Nothing Then
            _childContainer = container.CreateChildContainer()
        End If

        Return _childContainer
    End Function

    Public Sub DisposeOfChildContainer()
        _childContainer?.Dispose()
    End Sub

    Public Sub Attach(ByVal owner As InstanceContext) _
        Implements IExtension(Of InstanceContext).Attach
    End Sub

    Public Sub Detach(ByVal owner As InstanceContext) _
        Implements IExtension(Of InstanceContext).Detach
    End Sub

    <Obsolete("Please refactor code that uses this function, it is a simple work-around to simulate inline assignment in VB!")>
    Private Shared Function __InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function

End Class


