Public Class Customer

    Public Property Id As Integer

    Public Property FirstName As String

    Public Property LastName As String

    Public Sub New(ByVal id As Integer, ByVal firstName As String, ByVal lastName As String)
        Me.Id = id
        Me.FirstName = firstName
        Me.LastName = lastName
    End Sub

End Class