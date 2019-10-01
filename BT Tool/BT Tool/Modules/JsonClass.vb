Public Class AutoFail
    Public Property sel As String
    Public Property feedback As String
End Class

Public Class q1
    Public Property sel1 As String
    Public Property feedback1 As String
    Public Property sel2 As String
    Public Property feedback2 As String
End Class

Public Class q2
    Public Property sel1 As String
    Public Property feedback1 As String
    Public Property sel2 As String
    Public Property feedback2 As String
End Class

Public Class q3
    Public Property sel1 As String
    Public Property feedback1 As String
    Public Property sel2 As String
    Public Property feedback2 As String
End Class

Public Class other
    Public Property words As String
    Public Property mistakes As String
End Class

Public Class returnfile
    Public Property user2_id As String 'second pr/bet assigned
    Public Property btpr_uid As String 'pr/bet name
    Public Property fixer_uid As String
    Public Property accuracy As String
    Public Property specs As String
    Public Property act_uid As String 'action by supervisor
    Public Property btpr_comment As String
    Public Property side_comment As String 'side-by-side feedback
    Public Property comment As String
End Class

Public Class BreakLogData
    Public Property filename As String
    Public Property bstart As String
    Public Property bend As String
    Public Property duration As String
End Class

Public Class GridHeaders
    Public Property width As Integer
    Public Property text As String
    Public Property index As Integer
    Public Property visible As Boolean = True
    Public Property makeReadOnly As Boolean = True
    Public Property type As Type
    Public Property align As DataGridViewContentAlignment
End Class