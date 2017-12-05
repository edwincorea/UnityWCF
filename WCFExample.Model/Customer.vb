Public Class Customer

    Property Id As Integer

    Property FirstName As String

    Property LastName As String

    Sub New(ByVal id As Integer, ByVal firstName As String, ByVal lastName As String)
        Me.Id = id
        Me.FirstName = firstName
        Me.LastName = lastName
    End Sub

End Class