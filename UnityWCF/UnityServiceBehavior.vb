Imports System.Collections.ObjectModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description
Imports System.ServiceModel.Dispatcher
Imports Microsoft.Practices.Unity

Public Class UnityServiceBehavior
    Implements IServiceBehavior

    Private ReadOnly _container As IUnityContainer

    Public Sub New(ByVal container As IUnityContainer)
        Me._container = container
    End Sub

    Public Sub AddBindingParameters(ByVal serviceDescription As ServiceDescription,
                                    ByVal serviceHostBase As ServiceHostBase,
                                    ByVal endpoints As Collection(Of ServiceEndpoint),
                                    ByVal bindingParameters As BindingParameterCollection) _
                                    Implements IServiceBehavior.AddBindingParameters

    End Sub

    Public Sub ApplyDispatchBehavior(ByVal serviceDescription As ServiceDescription,
                                     ByVal serviceHostBase As ServiceHostBase) _
                                     Implements IServiceBehavior.ApplyDispatchBehavior

        For Each cdb As ChannelDispatcherBase In serviceHostBase.ChannelDispatchers
            Dim cd As ChannelDispatcher = CType(cdb, ChannelDispatcher)

            If Not cd Is Nothing Then

                For Each ed As EndpointDispatcher In cd.Endpoints
                    ed.DispatchRuntime.InstanceProvider = New UnityInstanceProvider(Me._container,
                                                                                    serviceDescription.ServiceType)
                Next

            End If
        Next

    End Sub

    Public Sub Validate(ByVal serviceDescription As ServiceDescription,
                        ByVal serviceHostBase As ServiceHostBase) _
                        Implements IServiceBehavior.Validate
    End Sub
End Class
