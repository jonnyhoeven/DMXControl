Imports Microsoft.VisualBasic

Imports System
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Threading

Public Module FTD

    Public buffer(512) As Byte
    Public handle As Int16
    Public done As Boolean = False
    Public byteswritten As Int16 = 0

    Public status As FT_STATUS2

    Public Const BITS_8 As Byte = 8
    Public Const STOP_BITS_2 As Byte = 2
    Public Const PARITY_NONE As Byte = 0
    Public Const FLOW_NONE As Int16 = 0
    Public Const PURGE_RX As Byte = 0
    Public Const PURGE_TX As Byte = 2

    Public Enum FT_STATUS2
        FT_OK = 0
        FT_INVALID_HANDLE = 1
        FT_DEVICE_NOT_FOUND = 2
        FT_DEVICE_NOT_OPENED = 3
        FT_IO_ERROR = 4
        FT_INSUFFICIENT_RESOURCES = 5
        FT_INVALID_PARAMETER = 6
        FT_INVALID_BAUD_RATE = 7
        FT_DEVICE_NOT_OPENED_FOR_ERASE = 8
        FT_DEVICE_NOT_OPENED_FOR_WRITE = 9
        FT_FAILED_TO_WRITE_DEVICE = 10
        FT_EEPROM_READ_FAILED = 11
        FT_EEPROM_WRITE_FAILED = 12
        FT_EEPROM_ERASE_FAILED = 13
        FT_EEPROM_NOT_PRESENT = 14
        FT_EEPROM_NOT_PROGRAMMED = 15
        FT_INVALID_ARGS = 16
    End Enum

    <DllImport("FTD2XX.dll", EntryPoint:="FT_Open", ExactSpelling:=False, CharSet:=CharSet.Unicode)> _
    Public Function FT_Open(ByVal uiPort As UInt32, ByRef ftHandle As UInt16) As FT_STATUS2
    End Function
    <DllImport("FTD2XX.dll", EntryPoint:="FT_Close", ExactSpelling:=False, CharSet:=CharSet.Unicode)> _
    Public Function FT_Close(ByVal ftHandle As UInt16) As FT_STATUS2
    End Function
    <DllImport("FTD2XX.dll", EntryPoint:="FT_Read", ExactSpelling:=False, CharSet:=CharSet.Unicode)> _
    Public Function FT_Read(ByVal ftHandle As UInt16, ByVal lpBuffer As IntPtr, ByVal dwBytesToRead As UInt32, ByRef lpdwBytesReturned As UInt32) As FT_STATUS2
    End Function
    <DllImport("FTD2XX.dll", EntryPoint:="FT_Write", ExactSpelling:=False, CharSet:=CharSet.Unicode)> _
    Public Function FT_Write(ByVal ftHandle As UInt16, ByVal lpBuffer As IntPtr, ByVal dwBytesToRead As UInt32, ByRef lpdwBytesWritten As UInt32) As FT_STATUS2
    End Function
    <DllImport("FTD2XX.dll", EntryPoint:="FT_SetDataCharacteristics", ExactSpelling:=False, CharSet:=CharSet.Unicode)> _
    Public Function FT_SetDataCharacteristics(ByVal ftHandle As UInt16, ByVal uWordLength As Byte, ByVal uStopBits As Byte, ByVal uParity As Byte) As FT_STATUS2
    End Function
    <DllImport("FTD2XX.dll", EntryPoint:="FT_SetFlowControl", ExactSpelling:=False, CharSet:=CharSet.Unicode)> _
    Public Function FT_SetFlowControl(ByVal ftHandle As UInt16, ByVal usFlowControl As Char, ByVal uXon As Byte, ByVal uXoff As Byte) As FT_STATUS2
    End Function
    <DllImport("FTD2XX.dll", EntryPoint:="FT_GetModemStatus", ExactSpelling:=False, CharSet:=CharSet.Unicode)> _
    Public Function FT_GetModemStatus(ByVal ftHandle As UInt16, ByRef lpdwModemStatus As UInt32) As FT_STATUS2
    End Function
    <DllImport("FTD2XX.dll", EntryPoint:="FT_Purge", ExactSpelling:=False, CharSet:=CharSet.Unicode)> _
    Public Function FT_Purge(ByVal ftHandle As UInt16, ByRef dwMask As UInt32) As FT_STATUS2
    End Function
    <DllImport("FTD2XX.dll", EntryPoint:="FT_SetBreakOn", ExactSpelling:=False, CharSet:=CharSet.Unicode)> _
    Public Function FT_SetBreakOn(ByVal ftHandle As UInt16) As FT_STATUS2
    End Function
    <DllImport("FTD2XX.dll", EntryPoint:="FT_SetBreakOff", ExactSpelling:=False, CharSet:=CharSet.Unicode)> _
    Public Function FT_SetBreakOff(ByVal ftHandle As UInt16) As FT_STATUS2
    End Function
    <DllImport("FTD2XX.dll", EntryPoint:="FT_GetStatus", ExactSpelling:=False, CharSet:=CharSet.Unicode)> _
    Public Function FT_GetStatus(ByVal ftHandle As UInt16, ByRef lpdwAmountInRxQueue As UInt32, ByRef lpdwAmountInTxQueue As UInt32, ByRef lpdwEventStatus As UInt32) As FT_STATUS2
    End Function
    <DllImport("FTD2XX.dll", EntryPoint:="FT_ResetDevice", ExactSpelling:=False, CharSet:=CharSet.Unicode)> _
    Public Function FT_ResetDevice(ByVal ftHandle As UInt16) As FT_STATUS2
    End Function
    <DllImport("FTD2XX.dll", EntryPoint:="FT_SetDivisor", ExactSpelling:=False, CharSet:=CharSet.Unicode)> _
    Public Function FT_SetDivisor(ByVal ftHandle As UInt16, ByVal usDivisor As Char) As FT_STATUS2
    End Function


    Public Sub start()
        Dim handle As UInt16 = 0
        Try
            Dim status As Object = FTD.FT_Open(0, handle)
            Dim mythread As New Thread(AddressOf writeData)
            mythread.Start()
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try

    End Sub


    Public Sub setDmxValue(ByVal channel As UInt16, ByVal value As Byte)
        buffer(channel) = value
    End Sub

    Public Sub writeData()
        Do While Not done
            initOpenDMX()
            FTD.FT_SetBreakOn(handle)
            byteswritten = FTD.write(handle, buffer, buffer.Length)
            System.Threading.Thread.Sleep(50)
        Loop
    End Sub

    Public Function write(ByVal handle As UInt16, ByVal data() As Byte, ByVal length As UInt16) As UInt16
        Dim ptr As IntPtr = Marshal.AllocHGlobal(length)
        Marshal.Copy(data, 0, ptr, length)
        Dim byteswritten As UInt16 = 0
        FTD.FT_Write(handle, ptr, length, byteswritten)
        Return byteswritten
    End Function

    Public Sub initOpenDMX()
        Dim mychar As Char = 12.ToString
        Dim myflow As Char = FTD.FLOW_NONE.ToString

        Try
            status = FTD.FT_ResetDevice(handle)
            status = FTD.FT_SetDivisor(handle, mychar)
            status = FTD.FT_SetDataCharacteristics(handle, FTD.BITS_8, FTD.STOP_BITS_2, FTD.PARITY_NONE)
            status = FTD.FT_SetFlowControl(handle, myflow, 0, 0)
            status = FTD.FT_Purge(handle, FTD.PURGE_TX)
            status = FTD.FT_Purge(handle, FTD.PURGE_RX)
        Catch ex As Exception
            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub






End Module
