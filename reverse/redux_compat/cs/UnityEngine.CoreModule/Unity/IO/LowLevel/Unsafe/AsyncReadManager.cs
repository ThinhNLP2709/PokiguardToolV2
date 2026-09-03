/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.IO.LowLevel.Unsafe
{
	[NativeHeader("Runtime/File/AsyncReadManagerManagedApi.h")]
	public static class AsyncReadManager // TypeDefIndex: 7401
	{
		// Methods
		[FreeFunction("AsyncReadManagerManaged::GetFileInfo", IsThreadSafe = true)]
		private static unsafe ReadHandle GetFileInfoInternal(string filename, void* cmd); // 0x0000000182179DA0-0x0000000182179F30
		public static unsafe ReadHandle GetFileInfo(string filename, FileInfoResult* result); // 0x0000000182179F30-0x0000000182179FB0
		[FreeFunction("AsyncReadManagerManaged::ReadWithHandles_NativeCopy", IsThreadSafe = true)]
		private static unsafe ReadHandle ReadWithHandlesInternal_NativeCopy([IsReadOnly] in FileHandle fileHandle, void* readCmdArray); // 0x000000018217A270-0x000000018217A2D0
		public static ReadHandle Read([IsReadOnly] in FileHandle fileHandle, ReadCommandArray readCmdArray); // 0x000000018217A2D0-0x000000018217A3B0
		[FreeFunction("AsyncReadManagerManaged::ScheduleOpenRequest", IsThreadSafe = true)]
		private static FileHandle OpenFileAsync_Internal(string fileName); // 0x000000018217A000-0x000000018217A190
		public static FileHandle OpenFileAsync(string fileName); // 0x000000018217A190-0x000000018217A210
		[FreeFunction("AsyncReadManagerManaged::ScheduleCloseRequest", IsThreadSafe = true)]
		internal static JobHandle CloseFileAsync([IsReadOnly] in FileHandle fileHandle, JobHandle dependency); // 0x0000000182179CE0-0x0000000182179D40
		private static unsafe void GetFileInfoInternal_Injected(ref ManagedSpanWrapper filename, void* cmd, ); // 0x0000000182179D40-0x0000000182179DA0
		private static unsafe void ReadWithHandlesInternal_NativeCopy_Injected([IsReadOnly] in FileHandle fileHandle, void* readCmdArray, ); // 0x000000018217A210-0x000000018217A270
		private static void OpenFileAsync_Internal_Injected(ref ManagedSpanWrapper fileName, ); // 0x0000000182179FB0-0x000000018217A000
		private static void CloseFileAsync_Injected([IsReadOnly] in FileHandle fileHandle, in JobHandle dependency, ); // 0x0000000182179C80-0x0000000182179CE0
	}
}
