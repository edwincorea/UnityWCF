
Imports System.ServiceModel.Activation
Imports Microsoft.Practices.Unity

Public MustInherit Class UnityServiceHostFactory
    Inherits ServiceHostFactory

    Protected MustOverride Sub ConfigureContainer(ByVal container As IUnityContainer)

    Protected Overrides Function CreateServiceHost(ByVal serviceType As Type, ByVal baseAddresses As Uri()) As ServiceHost
        Dim container = New UnityContainer()

        ConfigureContainer(container)

        Return New UnityServiceHost(container, serviceType, baseAddresses)
    End Function

End Class
