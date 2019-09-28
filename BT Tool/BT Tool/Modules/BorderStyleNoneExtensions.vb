REM ***********************************************
REM              by Gegnjani                      *
REM "Gegnjani" CodeProject Account                *
REM "Toka Arbnore" Youtube Channel                *  
REM dont remove these comments                    *
REM ***********************************************

Option Explicit On
Option Strict On

Namespace BorderStyleNoneExtensions

    ''' <summary>
    '''Provides resizing functionality to a BorderStyle-None Form.
    ''' </summary>
    Partial Public NotInheritable Class Resizer
        Dim WithEvents sender As Form

        Sub New(ByRef invoker As Form)
            Initialize(invoker)
        End Sub
        Sub New(ByRef invoker As Form, ByVal [compass] As CardinalDirection)
            Me.Compass = [compass]
            Initialize(invoker)
        End Sub
        Public Sub Initialize(ByRef invoker As Form)
            If (Not TypeOf (invoker) Is Form) Then
                Throw New FormatException("The invoker must be a Form.")
            Else
                RollBack()
                Me.sender = invoker
                AddHandler sender.MouseDown, AddressOf _MouseDown
                AddHandler sender.MouseUp, AddressOf _MouseUp
                AddHandler sender.MouseMove, AddressOf _MouseMove
            End If
        End Sub
        Public Sub RollBack()
            If (Me.sender Is Nothing) Then Return
            If (TypeOf (Me.sender) Is Form) Then
                RemoveHandler sender.MouseDown, AddressOf _MouseDown
                RemoveHandler sender.MouseUp, AddressOf _MouseUp
                RemoveHandler sender.MouseMove, AddressOf _MouseMove
            End If
            Me.sender = Nothing
        End Sub
        Public Shadows Sub Dispose()
            RollBack()
            MyBase.Finalize()
        End Sub

        <Flags()>
        Public Enum CardinalDirection As Integer
            None = 0
            West = 1
            East = 2
            South = 4
            North = 8
            SouthWest = 16
            SouthEast = 32
            NorthEast = 64
            NorthWest = 128
            All = 255
        End Enum
        Private _Compass As CardinalDirection = CardinalDirection.All
        Public Property Compass As CardinalDirection
            Get
                Return _Compass
            End Get
            Set(value As CardinalDirection)
                If (value = CardinalDirection.None) Then
                    _Compass = CardinalDirection.None
                Else
                    _Compass = value
                End If
            End Set
        End Property

        Private DOES_OR_CAN_RESIZE As Boolean = False
        Dim MOUSE_STANDS_AT As CardinalDirection = CardinalDirection.None
        ''' <summary>
        '''This field serves as a criterion to prevent conflicts between Resizer() and Dragger(), 
        '''if both Classes are targets of the same invoker.
        ''' </summary>
        Public Shared ReadOnly RESERVED_BORDERMARGIN As Integer = 10

        Private Sub _MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            If e.Button = Windows.Forms.MouseButtons.Left Then
                If (Not (_Compass = CardinalDirection.None)) Then
                    Dim state = GetResizingState(Cursor.Position)
                    If (Not (state = CardinalDirection.None)) AndAlso (_Compass = (Compass Or state)) Then
                        MOUSE_STANDS_AT = state
                        DOES_OR_CAN_RESIZE = True
                    End If
                End If
            End If
        End Sub
        Private Sub _MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
            DOES_OR_CAN_RESIZE = False
            MOUSE_STANDS_AT = CardinalDirection.None
            Me.sender.Cursor = Cursors.Default
            Me.sender.Refresh()
        End Sub
        Private Sub _MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            If (_Compass = CardinalDirection.None) Then Return

            If (DOES_OR_CAN_RESIZE = False) Then

                'Apply appropriate cursors
                Dim state As CardinalDirection = GetResizingState(Cursor.Position)
                If (state = CardinalDirection.None) Then
                    If (Not Me.sender.Cursor = Cursors.Default) Then Me.sender.Cursor = Cursors.Default
                Else
                    If (_Compass = (_Compass Or state)) Then
                        Select Case state
                            Case CardinalDirection.East
                                Me.sender.Cursor = Cursors.SizeWE
                            Case CardinalDirection.West
                                Me.sender.Cursor = Cursors.SizeWE
                            Case CardinalDirection.South
                                Me.sender.Cursor = Cursors.SizeNS
                            Case CardinalDirection.North
                                Me.sender.Cursor = Cursors.SizeNS
                            Case CardinalDirection.SouthWest
                                Me.sender.Cursor = Cursors.SizeNESW
                            Case CardinalDirection.SouthEast
                                Me.sender.Cursor = Cursors.SizeNWSE
                            Case CardinalDirection.NorthWest
                                Me.sender.Cursor = Cursors.SizeNWSE
                            Case CardinalDirection.NorthEast
                                Me.sender.Cursor = Cursors.SizeNESW
                        End Select
                    End If
                End If

            ElseIf (DOES_OR_CAN_RESIZE = True) Then
                'Approprietaly resize the window
                Dim rect As Rectangle
                Select Case MOUSE_STANDS_AT
                    Case CardinalDirection.East
                        rect = Modify_East_Side(Cursor.Position)
                        Me.sender.Size = rect.Size
                        Me.sender.Location = rect.Location
                    Case CardinalDirection.South
                        rect = Modify_South_Side(Cursor.Position)
                        Me.sender.Size = rect.Size
                        Me.sender.Location = rect.Location
                    Case CardinalDirection.West
                        rect = Modify_West_Side(Cursor.Position)
                        Me.sender.Size = rect.Size
                        Me.sender.Location = rect.Location
                    Case CardinalDirection.North
                        rect = Modify_North_Side(Cursor.Position)
                        Me.sender.Size = rect.Size
                        Me.sender.Location = rect.Location
                    Case CardinalDirection.NorthEast
                        rect = Modify_East_Side(Cursor.Position)
                        Me.sender.Size = rect.Size
                        Me.sender.Location = rect.Location
                        rect = Modify_North_Side(Cursor.Position)
                        Me.sender.Size = rect.Size
                        Me.sender.Location = rect.Location
                    Case CardinalDirection.NorthWest
                        Dim pos As Point = Cursor.Position
                        rect = Modify_West_Side(pos)
                        Me.sender.Size = rect.Size
                        Me.sender.Location = rect.Location
                        rect = Modify_North_Side(pos)
                        Me.sender.Size = rect.Size
                        Me.sender.Location = rect.Location
                    Case CardinalDirection.SouthWest
                        rect = Modify_South_Side(Cursor.Position)
                        Me.sender.Size = rect.Size
                        Me.sender.Location = rect.Location
                        rect = Modify_West_Side(Cursor.Position)
                        Me.sender.Size = rect.Size
                        Me.sender.Location = rect.Location
                    Case CardinalDirection.SouthEast
                        rect = Modify_South_Side(Cursor.Position)
                        Me.sender.Size = rect.Size
                        Me.sender.Location = rect.Location
                        rect = Modify_East_Side(Cursor.Position)
                        Me.sender.Size = rect.Size
                        Me.sender.Location = rect.Location
                End Select
                Me.sender.Refresh()

            End If

        End Sub
        Private Function GetResizingState(pos As Point) As CardinalDirection
            Dim edge_scope As Short = 25
            Dim margin As Integer = (RESERVED_BORDERMARGIN - 1)

            If ((pos.X >= sender.Left) And (pos.X <= sender.Left + margin)) _
                    And ((pos.Y >= sender.Top + edge_scope) And (pos.Y <= sender.Bottom - edge_scope)) Then
                Return CardinalDirection.West
            ElseIf ((pos.X >= sender.Right - margin) And (pos.X <= sender.Right)) _
                    And ((pos.Y >= sender.Top + edge_scope) And (pos.Y <= sender.Bottom - edge_scope)) Then
                Return CardinalDirection.East
            ElseIf ((pos.X >= sender.Left + edge_scope) And (pos.X <= sender.Right - edge_scope)) _
                    And (pos.Y >= sender.Top) And (pos.Y <= (sender.Top + margin)) Then
                Return CardinalDirection.North
            ElseIf ((pos.X >= sender.Left + edge_scope) And (pos.X <= sender.Right - edge_scope)) _
                    And (pos.Y >= sender.Bottom - margin) And (pos.Y <= (sender.Bottom)) Then
                Return CardinalDirection.South

            ElseIf ((pos.X >= sender.Left) And (pos.X <= sender.Left + margin)) _
                    And ((pos.Y >= sender.Top) And (pos.Y <= sender.Top + margin)) Then
                Return CardinalDirection.NorthWest
            ElseIf ((pos.X >= sender.Left) And (pos.X <= sender.Left + margin)) _
                    And ((pos.Y >= sender.Bottom - margin) And (pos.Y <= sender.Bottom)) Then
                Return CardinalDirection.SouthWest
            ElseIf ((pos.X >= sender.Right - margin) And (pos.X <= sender.Right)) _
                    And ((pos.Y >= sender.Top) And (pos.Y <= sender.Top + margin)) Then
                Return CardinalDirection.NorthEast
            ElseIf ((pos.X >= sender.Right - margin) And (pos.X <= sender.Right)) _
                    And ((pos.Y >= sender.Bottom - margin) And (pos.Y <= sender.Bottom)) Then
                Return CardinalDirection.SouthEast

            Else
                Return CardinalDirection.None
            End If

        End Function

#Region "Virtually calculate the new invoker's DisplayRectangle according to Mouse Location"
        Private Function Modify_East_Side(cur_pos As Point) As Rectangle
            Dim rect As Rectangle = Me.sender.RectangleToScreen(Me.sender.DisplayRectangle)
            rect.Width = (cur_pos.X - rect.X)
            Return rect
        End Function
        Private Function Modify_South_Side(cur_pos As Point) As Rectangle
            Dim rect As Rectangle = Me.sender.RectangleToScreen(Me.sender.DisplayRectangle)
            rect.Height = (cur_pos.Y - rect.Y)
            Return rect
        End Function
        Private Function Modify_West_Side(cur_pos As Point) As Rectangle
            Dim rect As Rectangle = Me.sender.RectangleToScreen(Me.sender.DisplayRectangle)

            Dim loc_x As Integer = cur_pos.X
            Dim _width As Integer = (rect.X + rect.Width) - loc_x
            If (_width >= Me.sender.MinimumSize.Width) Then
                rect.Width = _width
                rect.X = (loc_x)
            End If
            Return rect
        End Function
        Private Function Modify_North_Side(cur_pos As Point) As Rectangle
            Dim rect As Rectangle = Me.sender.RectangleToScreen(Me.sender.DisplayRectangle)

            Dim loc_y As Integer = cur_pos.Y
            Dim _height As Integer = (rect.Y + rect.Height) - loc_y
            If (_height >= Me.sender.MinimumSize.Height) Then
                rect.Height = _height
                rect.Y = loc_y
            End If
            Return rect
        End Function
#End Region

    End Class

    ''' <summary>
    '''Provides dragging functionality to a BorderStyle-None Form.
    ''' </summary>
    Partial Public NotInheritable Class Dragger
        Dim senders As Object()
        Sub New(ByRef invokers As Object())
            Initialize(invokers)
        End Sub
        Public Sub Initialize(ByRef invokers As Object())
            RollBack()
            Me.senders = invokers
            'accepts only types of Control() or of Form()
            For Each invoker In senders
                If (TypeOf (invoker) Is Form) Or (TypeOf (invoker) Is Control) Then
                    Dim sender = If(TypeOf (invoker) Is Form, DirectCast(invoker, Form), DirectCast(invoker, Control))
                    AddHandler sender.MouseDown, AddressOf _MouseDown
                    AddHandler sender.MouseUp, AddressOf _MouseUp
                    AddHandler sender.MouseMove, AddressOf _MouseMove
                End If
            Next
        End Sub
        Public Sub RollBack()
            If (senders Is Nothing) Then Return

            'accepts only types of Control() or of Form()
            For Each invoker In senders
                If (TypeOf (invoker) Is Form) Or (TypeOf (invoker) Is Control) Then
                    Dim sender = If(TypeOf (invoker) Is Form, DirectCast(invoker, Form), DirectCast(invoker, Control))
                    RemoveHandler sender.MouseDown, AddressOf _MouseDown
                    RemoveHandler sender.MouseUp, AddressOf _MouseUp
                    RemoveHandler sender.MouseMove, AddressOf _MouseMove
                End If
            Next
            Me.senders = Nothing
        End Sub
        Public Shadows Sub Dispose()
            RollBack()
            MyBase.Finalize()
        End Sub

        Dim POS_X, POS_Y As Integer
        Dim DOES_OR_CAN_DRAG As Boolean = False
        Private Sub _MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
            If (e.Button = MouseButtons.Left) Then

                For Each parent In Me.senders
                    If (TypeOf (parent) Is Form) Then
                        POS_X = (Cursor.Position.X - DirectCast(parent, Form).Left)
                        POS_Y = (Cursor.Position.Y - DirectCast(parent, Form).Top)
                        Dim cur_pos As Point = Cursor.Position

                        If ((cur_pos.X >= DirectCast(parent, Form).Left + Resizer.RESERVED_BORDERMARGIN) And
                        (cur_pos.X <= DirectCast(parent, Form).Right - Resizer.RESERVED_BORDERMARGIN)) And
                        ((cur_pos.Y >= DirectCast(parent, Form).Top + Resizer.RESERVED_BORDERMARGIN) And
                        (cur_pos.Y <= DirectCast(parent, Form).Bottom - Resizer.RESERVED_BORDERMARGIN)) Then

                            DOES_OR_CAN_DRAG = True
                        End If

                        Exit For
                    End If
                Next
            End If
        End Sub
        Private Sub _MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
            DOES_OR_CAN_DRAG = False
        End Sub
        Private Sub _MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
            If DOES_OR_CAN_DRAG Then

                For Each parent In Me.senders
                    If (TypeOf (parent) Is Form) Then
                        DirectCast(parent, Form).Top = (Cursor.Position.Y - POS_Y)
                        DirectCast(parent, Form).Left = (Cursor.Position.X - POS_X)
                        Exit For
                    End If
                Next
            End If
        End Sub
    End Class

End Namespace