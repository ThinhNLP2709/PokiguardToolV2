/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	public static class Directory // TypeDefIndex: 3674
	{
		// Methods
		public static DirectoryInfo CreateDirectory(string path); // 0x00000001815BF650-0x00000001815BF7F0
		public static bool Exists(string path); // 0x00000001815BF9E0-0x00000001815BFAA0
		public static string[] GetFiles(string path, string searchPattern); // 0x00000001815BFAB0-0x00000001815BFBA0
		public static string[] GetFiles(string path, string searchPattern, EnumerationOptions enumerationOptions); // 0x00000001815BFBA0-0x00000001815BFC10
		internal static IEnumerable<string> InternalEnumeratePaths(string path, string searchPattern, SearchTarget searchTarget, EnumerationOptions options); // 0x00000001815BFCA0-0x00000001815BFE70
		public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption); // 0x00000001815BF810-0x00000001815BF9E0
		public static IEnumerable<string> EnumerateDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions); // 0x00000001815BF7F0-0x00000001815BF810
		internal static string InternalGetDirectoryRoot(string path); // 0x00000001815BFE70-0x00000001815BFF10
		public static string GetCurrentDirectory(); // 0x00000001815BFAA0-0x00000001815BFAB0
		internal static string InsecureGetCurrentDirectory(); // 0x00000001815BFC10-0x00000001815BFCA0
	}
}
