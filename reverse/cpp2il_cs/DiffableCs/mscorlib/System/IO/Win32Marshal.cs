namespace System.IO;

internal static class Win32Marshal
{

	internal static Exception GetExceptionForWin32Error(int errorCode, string path = "") { }

	internal static string GetMessage(int errorCode) { }

	internal static int MakeHRFromErrorCode(int errorCode) { }

}

