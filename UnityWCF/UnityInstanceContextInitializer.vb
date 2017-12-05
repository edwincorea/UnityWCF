Imports System.ServiceModel.Channels
Imports System.ServiceModel.Dispatcher

Public Class UnityInstanceContextInitializer
    Implements IInstanceContextInitializer

    Public Sub Initialize(ByVal instanceContext As InstanceContext, ByVal message As Message) _
        Implements IInstanceContextInitializer.Initialize

        instanceContext.Extensions.Add(New UnityInstanceContextExtension())
    End Sub
End Class