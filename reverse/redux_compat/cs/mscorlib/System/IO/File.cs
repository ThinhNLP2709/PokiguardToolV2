/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	public static class File // TypeDefIndex: 3677
	{
		// Methods
		public static StreamReader OpenText(string path); // 0x00000001815C5B50-0x00000001815C5C00
		public static void Delete(string path); // 0x00000001815C5380-0x00000001815C5470
		public static bool Exists(string path); // 0x00000001815C5470-0x00000001815C5590
		public static FileStream Open(string path, FileMode mode); // 0x00000001815C5C80-0x00000001815C5D30
		public static FileStream Open(string path, FileMode mode, FileAccess access, FileShare share); // 0x00000001815C5D30-0x00000001815C5DD0
		public static FileAttributes GetAttributes(string path); // 0x00000001815C5590-0x00000001815C5630
		public static FileStream OpenRead(string path); // 0x00000001815C5AD0-0x00000001815C5B50
		public static FileStream OpenWrite(string path); // 0x00000001815C5C00-0x00000001815C5C80
		public static string ReadAllText(string path); // 0x00000001815C6500-0x00000001815C65E0
		private static string InternalReadAllText(string path, Encoding encoding); // 0x00000001815C5840-0x00000001815C5960
		public static void WriteAllText(string path, string contents); // 0x00000001815C6940-0x00000001815C6B00
		public static void WriteAllText(string path, string contents, Encoding encoding); // 0x00000001815C6710-0x00000001815C6940
		public static byte[] ReadAllBytes(string path); // 0x00000001815C61B0-0x00000001815C6420
		private static byte[] ReadAllBytesUnknownLength(FileStream fs); // 0x00000001815C5DD0-0x00000001815C61B0
		public static void WriteAllBytes(string path, byte[] bytes); // 0x00000001815C65E0-0x00000001815C6710
		private static void InternalWriteAllBytes(string path, byte[] bytes); // 0x00000001815C5960-0x00000001815C5AD0
		public static string[] ReadAllLines(string path); // 0x00000001815C6420-0x00000001815C6500
		private static string[] InternalReadAllLines(string path, Encoding encoding); // 0x00000001815C5630-0x00000001815C5840
		public static void AppendAllText(string path, string contents); // 0x00000001815C51C0-0x00000001815C5380
	}
}
