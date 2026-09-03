/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	internal static class MonoIO // TypeDefIndex: 3704
	{
		// Fields
		public static readonly IntPtr InvalidHandle; // 0x00
		private static bool dump_handles; // 0x08
	
		// Properties
		public static IntPtr ConsoleOutput { get; } // 0x00000001815C7D80-0x00000001815C7D90 
		public static IntPtr ConsoleInput { get; } // 0x00000001815C7D70-0x00000001815C7D80 
		public static IntPtr ConsoleError { get; } // 0x00000001815C7D60-0x00000001815C7D70 
		public static char VolumeSeparatorChar { get; } // 0x00000001815C7DB0-0x00000001815C7DC0 
		public static char DirectorySeparatorChar { get; } // 0x00000001815C7D90-0x00000001815C7DA0 
		public static char AltDirectorySeparatorChar { get; } // 0x00000001815C7D50-0x00000001815C7D60 
		public static char PathSeparator { get; } // 0x00000001815C7DA0-0x00000001815C7DB0 
	
		// Constructors
		static MonoIO(); // 0x00000001815C7CD0-0x00000001815C7D50
	
		// Methods
		public static Exception GetException(MonoIOError error); // 0x00000001815C7340-0x00000001815C7440
		public static Exception GetException(string path, MonoIOError error); // 0x00000001815C6C80-0x00000001815C7340
		public static string GetCurrentDirectory(out MonoIOError error); // 0x00000001815C6C70-0x00000001815C6C80
		private static MonoFileType GetFileType(IntPtr handle, out MonoIOError error); // 0x00000001815C7560-0x00000001815C7570
		public static MonoFileType GetFileType(SafeHandle safeHandle, out MonoIOError error); // 0x00000001815C7440-0x00000001815C7560
		public static bool FindCloseFile(IntPtr hnd); // 0x00000001815C6C60-0x00000001815C6C70
		private static unsafe IntPtr Open(char* filename, FileMode mode, FileAccess access, FileShare share, FileOptions options, out MonoIOError error); // 0x00000001815C76B0-0x00000001815C76C0
		public static IntPtr Open(string filename, FileMode mode, FileAccess access, FileShare share, FileOptions options, out MonoIOError error); // 0x00000001815C76C0-0x00000001815C7750
		private static bool Cancel_internal(IntPtr handle, out MonoIOError error); // 0x00000001815C6B00-0x00000001815C6B10
		internal static bool Cancel(SafeHandle safeHandle, out MonoIOError error); // 0x00000001815C6B10-0x00000001815C6C40
		public static bool Close(IntPtr handle, out MonoIOError error); // 0x00000001815C6C40-0x00000001815C6C50
		private static int Read(IntPtr handle, byte[] dest, int dest_offset, int count, out MonoIOError error); // 0x00000001815C78A0-0x00000001815C78B0
		public static int Read(SafeHandle safeHandle, byte[] dest, int dest_offset, int count, out MonoIOError error); // 0x00000001815C7750-0x00000001815C78A0
		private static int Write(IntPtr handle, in byte[] src, int src_offset, int count, out MonoIOError error); // 0x00000001815C7CC0-0x00000001815C7CD0
		public static int Write(SafeHandle safeHandle, byte[] src, int src_offset, int count, out MonoIOError error); // 0x00000001815C7B70-0x00000001815C7CC0
		private static long Seek(IntPtr handle, long offset, SeekOrigin origin, out MonoIOError error); // 0x00000001815C7A10-0x00000001815C7A20
		public static long Seek(SafeHandle safeHandle, long offset, SeekOrigin origin, out MonoIOError error); // 0x00000001815C78C0-0x00000001815C7A10
		private static long GetLength(IntPtr handle, out MonoIOError error); // 0x00000001815C7570-0x00000001815C7580
		public static long GetLength(SafeHandle safeHandle, out MonoIOError error); // 0x00000001815C7580-0x00000001815C76B0
		private static bool SetLength(IntPtr handle, long length, out MonoIOError error); // 0x00000001815C7A20-0x00000001815C7A30
		public static bool SetLength(SafeHandle safeHandle, long length, out MonoIOError error); // 0x00000001815C7A30-0x00000001815C7B70
		public static bool DuplicateHandle(IntPtr source_process_handle, IntPtr source_handle, IntPtr target_process_handle, out IntPtr target_handle, int access, int inherit, int options, out MonoIOError error); // 0x00000001815C6C50-0x00000001815C6C60
		private static void DumpHandles(); // 0x0000000181536B00-0x0000000181536B10
		public static bool RemapPath(string path, out string newPath); // 0x00000001815C78B0-0x00000001815C78C0
	}
}
