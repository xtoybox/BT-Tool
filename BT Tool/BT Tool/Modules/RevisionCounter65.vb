Imports MsWord = Microsoft.Office.Interop.Word
Module RevisionCounter65
    Private Rev_DeleteCount As Double = 0
    Private Rev_InsertCount As Double = 0
    Public Function WordCounter(ByRef TargetRange As MsWord.Range) As Double
        Dim Wordapp As New MsWord.Application
        Dim XW As MsWord.Range 'single word as range
        Dim XDR As MsWord.Range 'document range
        Dim AO As String 'stripped-down alpha only
        Dim ALPHA_WC As Double 'alpha only word count
        Dim NotALPHA_WC As Double 'not alpha word count
        Dim SPACE_WC As Double ' space jam
        XDR = TargetRange
        For Each XW In XDR.Words
            AO = AlphaNumericOnly(XW.Text)
            'not a word and not a space
            If AO = "" And Asc(XW.Text) <> 32 Then
                NotALPHA_WC = NotALPHA_WC + 1
                'not nothig
            ElseIf AO <> "" Then
                ALPHA_WC = ALPHA_WC + 1
            Else
                SPACE_WC = SPACE_WC + 1
            End If
        Next
        WordCounter = ALPHA_WC
        Debug.Print("WordCounter complete " & ALPHA_WC & "/" & XDR.Words.Count)
    End Function
    Public Function RevisionCounter(ByRef TargetRange As MsWord.Range)
        Dim XR As MsWord.Revision
        Dim XDR As MsWord.Range
        Dim AO As String
        Dim RC As Double = 0
        XDR = TargetRange
        For Each XR In XDR.Revisions
            AO = AlphaNumericOnly(XR.Range.Text)
            If (AO = "" And Asc(XR.Range.Text) <> 32) Or AO <> "" Then
                RC = RC + RRT(XR.Type)
            End If
        Next
        RevisionCounter = RC
        Debug.Print(Rev_DeleteCount + Rev_InsertCount)
        Debug.Print("RevisionCounter complete " & RC & "/" & XDR.Revisions.Count)
    End Function
    Private Function AlphaNumericOnly(ByVal StrSource As String) As String
        'turns text into alphanumeric shit
        Dim i As Long = 0
        Dim StrResult As String = ""
        Trim(StrSource)
        For i = 1 To Len(StrSource)
            Select Case Asc(Mid(StrSource, i, 1))
            '32, 48 To 57,
                Case 32, 48 To 57, 65 To 90, 97 To 122   'include 32 if you want to include space
                    StrResult = StrResult & Mid(StrSource, i, 1)
            End Select
        Next
        AlphaNumericOnly = Trim(StrResult)
    End Function
    Private Function RRT(ByVal TypeNumber As Double) As Integer 'As String
        Select Case TypeNumber
            Case 2
                Rev_DeleteCount = Rev_DeleteCount + 1
                RRT = 1'"wdRevisionDelete"
            Case 1
                Rev_InsertCount = Rev_InsertCount + 1
                RRT = 1 '"wdRevisionInsert"
            Case Else
                RRT = 0
        End Select
    End Function








End Module
