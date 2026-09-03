/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	internal static class FileSystem // TypeDefIndex: 3637
	{
		// Nested types
		private class UnitySafeFindHandle : SafeFindHandle // TypeDefIndex: 3638
		{
			// Fields
			private readonly IntPtr m_Handle; // 0x20
	
			// Properties
			public override bool IsInvalid { get; } // 0x0000000180E6C6E0-0x0000000180E6C6F0 
	
			// Constructors
			public UnitySafeFindHandle(IntPtr handle); // 0x00000001815BB890-0x00000001815BB8C0
	
			// Methods
			protected override void Dispose(bool disposing); // 0x00000001815BB870-0x00000001815BB890
		}
	
		// Methods
		public static void CreateDirectory(string fullPath); // 0x00000001815A84A0-0x00000001815A8980
		public static void DeleteFile(string fullPath); // 0x00000001815A8980-0x00000001815A8A90
		public static bool DirectoryExists(string fullPath); // 0x00000001815A8A90-0x00000001815A8AE0
		private static bool DirectoryExists(string path, out int lastError); // 0x00000001815A8AE0-0x00000001815A8B30
		internal static int FillAttributeInfo(string path, ref Interop.Kernel32.WIN32_FILE_ATTRIBUTE_DATA data, bool returnErrorOnNotFound); // 0x00000001815A8B80-0x00000001815A92B0
		public static bool FileExists(string fullPath); // 0x00000001815A8B30-0x00000001815A8B80
		public static FileAttributes GetAttributes(string fullPath); // 0x00000001815A92B0-0x00000001815A9320
		private static bool UnityCreateDirectory(string name); // 0x00000001815A9390-0x00000001815A9410
		private static bool UnityGetFileAttributesEx(string path, ref Interop.Kernel32.WIN32_FILE_ATTRIBUTE_DATA data); // 0x00000001815A9710-0x00000001815A9870
		internal static IntPtr UnityCreateFile_IntPtr(string lpFileName, int dwDesiredAccess, FileShare dwShareMode, FileMode dwCreationDisposition, int dwFlagsAndAttributes); // 0x00000001815A9410-0x00000001815A94C0
		private static bool UnityDeleteFile(string path); // 0x00000001815A94C0-0x00000001815A9580
		private static SafeFindHandle UnityFindFirstFile(string path, ref Interop.Kernel32.WIN32_FIND_DATA findData); // 0x00000001815A9580-0x00000001815A9710
		private static bool BrokeredCreateDirectory(string path); // 0x00000001815A8450-0x00000001815A8460
		private static bool BrokeredGetFileAttributes(string path, ref Interop.Kernel32.WIN32_FILE_ATTRIBUTE_DATA data); // 0x00000001815A8470-0x00000001815A8480
		private static IntPtr BrokeredOpenFile(string lpFileName, int dwDesiredAccess, int dwShareMode, int dwCreationDisposition, int dwFlagsAndAttributes); // 0x00000001815A8480-0x00000001815A8490
		private static bool BrokeredDeleteFile(string path); // 0x00000001815A8450-0x00000001815A8460
		private static IntPtr BrokeredFindFirstFile(string searchPath, ref string resultFilePath, ref uint attributes); // 0x00000001815A8460-0x00000001815A8470
		private static int BrokeredSafeFindHandleDispose(IntPtr handle); // 0x00000001815A8490-0x00000001815A84A0
		private static string RemoveExtendedPathPrefix(string path); // 0x00000001815A9320-0x00000001815A9390
	}
}
