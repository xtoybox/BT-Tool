Module restrictionMod

    Sub check_restriction()

        Select Case varMod.uDept

        End Select

    End Sub

    'Sub rest_main()

    '    With frm_main
    '        Select Case varMod.CurUserPos
    '            Case "admin"
    '                .btn_file.Enabled = True
    '                .btn_settings.Enabled = True
    '                .btn_archive.Enabled = True
    '                .btn_idle.Enabled = True
    '                .btn_wait.Enabled = True
    '                .cbo_bt.Enabled = True
    '                .cbo_qabt.Enabled = True
    '                .cbo_pr.Enabled = True
    '                .cbo_qapr.Enabled = True
    '                .cbo_st.Enabled = True
    '                .cbo_qast.Enabled = True
    '                .cbo_cc.Enabled = True
    '                .cbo_qacc.Enabled = True
    '                .gbox_constr.Visible = True
    '            Case "ts"
    '                .btn_settings.Enabled = True
    '                .btn_archive.Enabled = True
    '            Case "sched"
    '                Select Case varMod.CurUserDep
    '                    Case "bt"
    '                        .cbo_bt.Enabled = True
    '                        .cbo_qabt.Enabled = True
    '                    Case "pr"
    '                        .cbo_pr.Enabled = True
    '                        .cbo_qapr.Enabled = True
    '                    Case "bet"
    '                        If varMod.uDept = "st" Then
    '                            .cbo_st.Enabled = True
    '                            .cbo_qast.Enabled = True
    '                        ElseIf varMod.uDept = "cc" Then
    '                            .cbo_cc.Enabled = True
    '                            .cbo_qacc.Enabled = True
    '                        End If
    '                End Select
    '            Case "prod"
    '                .btn_file_eval.Enabled = False
    '                '.btn_monitoring.Enabled = False
    '                .btn_files_due.Enabled = False
    '                '.btn_report_log.Enabled = False
    '                '.btn_settings.Enabled = False
    '                .chk_blank.Enabled = False
    '                .chk_priority.Enabled = False
    '                .chk_rush.Enabled = False
    '                .btn_idle.Enabled = False
    '                .servPicker.Enabled = False
    '                .chk_rush.Enabled = False
    '                .txt_due.ReadOnly = True
    '                .txt_client.ReadOnly = True
    '                .txt_branch.ReadOnly = True
    '                .txt_duration.ReadOnly = True
    '                If varMod.uDept <> "pr" Then .txt_accuracy.ReadOnly = True
    '                .txt_page.ReadOnly = True

    '                Select Case varMod.CurUserDep
    '                    Case "bt"
    '                        '.btn_returnfile.Enabled = False
    '                    Case "pr"
    '                        .btn_file.Enabled = True
    '                        .btn_file_eval.Enabled = True
    '                    Case "bet"
    '                End Select
    '            Case "auditor"
    '        End Select

    '        If varMod.CurUserDep = "PR" Then
    '            'frm_main.btn_flagging.Enabled = True
    '        ElseIf varMod.CurUserDep = "BET" Then
    '            If varMod.CurUserPos <> "prod" Then
    '                'frm_main.btn_flagging.Enabled = True
    '            End If
    '        End If
    '    End With

    'End Sub

    'Public Sub ResetRestrictions()

    '    With frm_main

    '        '.btn_settings.Enabled = False
    '        .btn_idle.Enabled = False
    '        .btn_wait.Enabled = False
    '        .btn_report_log.Enabled = True
    '        .btn_userlist.Enabled = True
    '        .btn_files_due.Enabled = True
    '        .btn_workflow.Enabled = True
    '        .btn_apps.Enabled = True
    '        .btn_archive.Enabled = False

    '        .btn_file_eval.Enabled = True
    '        .btn_monitoring.Enabled = True
    '        .btn_hold.Enabled = False
    '        .chk_blank.Enabled = True
    '        .chk_priority.Enabled = True
    '        .chk_rush.Enabled = True
    '        .btn_returnfile.Enabled = True
    '        .btn_return.Enabled = True
    '        .btn_file.Enabled = False
    '        .btn_flagging.Enabled = True
    '        .chk_blank.Checked = False
    '        .chk_priority.Checked = False
    '        .chk_rush.Checked = False

    '        .cbo_qabt.Enabled = True
    '        .cbo_qapr.Enabled = True
    '        .cbo_qast.Enabled = True
    '        .cbo_qacc.Enabled = True

    '        .servPicker.Enabled = True

    '        .cbo_bt.Enabled = False
    '        .cbo_qabt.Enabled = False
    '        .cbo_pr.Enabled = False
    '        .cbo_qapr.Enabled = False
    '        .cbo_st.Enabled = False
    '        .cbo_qast.Enabled = False
    '        .cbo_cc.Enabled = False
    '        .cbo_qacc.Enabled = False

    '        .chk_rush.Enabled = True
    '        .txt_due.ReadOnly = False
    '        .txt_client.ReadOnly = False
    '        .txt_branch.ReadOnly = False
    '        .txt_duration.ReadOnly = False
    '        If varMod.uDept <> "pr" Then .txt_accuracy.ReadOnly = False
    '        .txt_page.ReadOnly = False
    '        .gbox_constr.Visible = False

    '    End With

    'End Sub
    Sub read_only(ByVal frm As Form, Optional ByVal ctrlcol As Control.ControlCollection = Nothing)

        If ctrlcol Is Nothing Then ctrlcol = frm.Controls
        For Each ctrl As Control In ctrlcol
            If TypeOf (ctrl) Is TextBox Then
                'ctl.Text = ""
                DirectCast(ctrl, TextBox).ReadOnly = True
            ElseIf TypeOf (ctrl) Is ComboBox Then
                DirectCast(ctrl, ComboBox).Enabled = False
            End If
        Next

    End Sub

    Sub read_only_combo(ByVal frm As Form, Optional ByVal ctrlcol As Control.ControlCollection = Nothing)

        If ctrlcol Is Nothing Then ctrlcol = frm.Controls

        For Each ctrl As Control In ctrlcol
            If TypeOf (ctrl) Is TextBox Then
                'ctl.Text = ""
                'DirectCast(ctrl, TextBox).ReadOnly = True
            ElseIf TypeOf (ctrl) Is ComboBox Then
                DirectCast(ctrl, ComboBox).Enabled = False
            End If
        Next

    End Sub

End Module
