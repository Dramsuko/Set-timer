Imports Microsoft.Win32

Namespace WaveFlat.SetTimer

    Public Class RegistrySetting

        Private Const BaseKey As String = "Software\WaveFlat\SetTimer"

        Public Sub SaveValue(keyName As String, value As Object)
            Using regKey = Registry.CurrentUser.CreateSubKey(BaseKey)
                regKey.SetValue(keyName, value)
            End Using
        End Sub

        Public Function GetValue(Of T)(keyName As String, defaultValue As T) As T
            Using regKey = Registry.CurrentUser.OpenSubKey(BaseKey)
                If regKey Is Nothing Then Return defaultValue
                Try
                    Dim value = regKey.GetValue(keyName)
                    If value IsNot Nothing Then
                        Return CType(Convert.ChangeType(value, GetType(T)), T)
                    End If
                Catch
                    ' 無効な型変換など
                End Try
                Return defaultValue
            End Using
        End Function

        Public Sub DeleteValue(keyName As String)
            Using regKey = Registry.CurrentUser.OpenSubKey(BaseKey, writable:=True)
                regKey?.DeleteValue(keyName, throwOnMissingValue:=False)
            End Using
        End Sub

        Public Sub DeleteAll()
            Registry.CurrentUser.DeleteSubKeyTree(BaseKey, throwOnMissingSubKey:=False)
        End Sub

    End Class

End Namespace