﻿' ################################################################################
' #                             EMBER MEDIA MANAGER                              #
' ################################################################################
' ################################################################################
' # This file is part of Ember Media Manager.                                    #
' #                                                                              #
' # Ember Media Manager is free software: you can redistribute it and/or modify  #
' # it under the terms of the GNU General Public License as published by         #
' # the Free Software Foundation, either version 3 of the License, or            #
' # (at your option) any later version.                                          #
' #                                                                              #
' # Ember Media Manager is distributed in the hope that it will be useful,       #
' # but WITHOUT ANY WARRANTY; without even the implied warranty of               #
' # MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                #
' # GNU General Public License for more details.                                 #
' #                                                                              #
' # You should have received a copy of the GNU General Public License            #
' # along with Ember Media Manager.  If not, see <http://www.gnu.org/licenses/>. #
' ################################################################################

Imports System.Windows.Forms

Public Class frmSplash

#Region "Delegates"

    Delegate Sub DelegateTo_SetLoadingMesg(strVersion As String)
    Delegate Sub DelegateTo_SetProgressBarStyle(style As ProgressBarStyle)
    Delegate Sub DelegateTo_SetProgressBarSize(size As Integer)
    Delegate Sub DelegateTo_Close()
    Delegate Sub DelegateTo_Show(owner As IWin32Window)
    Delegate Sub DelegateTo_Hide()

#End Region 'Delegates

#Region "Methods"

    Public Sub SetLoadingMesg(message As String, Optional aPart2 As String = "")
        If (InvokeRequired) Then
            Invoke(New DelegateTo_SetLoadingMesg(AddressOf SetLoadingMesg))
            Exit Sub
        End If

        LoadingMesg.Text = message
        Application.DoEvents()
    End Sub

    Public Sub SetVersionMesg(strVersion As String)
        If (InvokeRequired) Then
            Invoke(New DelegateTo_SetLoadingMesg(AddressOf SetVersionMesg))
            Exit Sub
        End If
        VersionNumber.Text = strVersion
        Application.DoEvents()
    End Sub

    Public Sub SetProgressBarStyle(style As ProgressBarStyle)
        If (InvokeRequired) Then
            Invoke(New DelegateTo_SetProgressBarStyle(AddressOf SetProgressBarStyle))
            Exit Sub
        End If

        LoadingBar.Style = style
    End Sub

    Public Sub SetProgressBarSize(size As Integer)
        If (InvokeRequired) Then
            Invoke(New DelegateTo_SetProgressBarSize(AddressOf SetProgressBarSize))
            Exit Sub
        End If

        LoadingBar.Maximum = size
    End Sub

    Public Overloads Sub Close()
        If (InvokeRequired) Then
            Invoke(New DelegateTo_Close(AddressOf Close))
            Exit Sub
        End If

        MyBase.Close()
        Dispose()
    End Sub

    Public Overloads Sub Show(owner As IWin32Window)
        If (InvokeRequired) Then
            Invoke(New DelegateTo_Show(AddressOf Show))
            Exit Sub
        End If

        MyBase.Show(owner)
    End Sub

    Public Overloads Sub Hide()
        If (InvokeRequired) Then
            Invoke(New DelegateTo_Hide(AddressOf Hide))
            Exit Sub
        End If

        MyBase.Hide()
    End Sub

#End Region 'Methods

End Class
