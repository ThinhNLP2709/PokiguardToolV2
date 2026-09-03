/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.IO.LowLevel.Unsafe
{
	public struct ReadHandle : IDisposable // TypeDefIndex: 7400
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal IntPtr ptr; // 0x00
		internal int version; // 0x08
	
		// Properties
		public JobHandle JobHandle { get; } // 0x0000000182192BC0-0x0000000182192CA0 
		public ReadStatus Status { get; } // 0x0000000182192CA0-0x0000000182192D60 
	
		// Methods
		public bool IsValid(); // 0x0000000182192B00-0x0000000182192B40
		public void Dispose(); // 0x00000001821927A0-0x0000000182192960
		public void Cancel(); // 0x00000001821926E0-0x00000001821927A0
		[FreeFunction("AsyncReadManagerManaged::CancelReadRequest")]
		private static void CancelInternal(ReadHandle handle); // 0x00000001821926A0-0x00000001821926E0
		[FreeFunction("AsyncReadManagerManaged::GetReadStatus", IsThreadSafe = true)]
		private static ReadStatus GetReadStatus(ReadHandle handle); // 0x0000000182192A40-0x0000000182192A80
		[FreeFunction("AsyncReadManagerManaged::ReleaseReadHandle", IsThreadSafe = true)]
		private static void ReleaseReadHandle(ReadHandle handle); // 0x0000000182192B80-0x0000000182192BC0
		[FreeFunction("AsyncReadManagerManaged::IsReadHandleValid", IsThreadSafe = true)]
		private static bool IsReadHandleValid(ReadHandle handle); // 0x0000000182192AC0-0x0000000182192B00
		[FreeFunction("AsyncReadManagerManaged::GetJobHandle", IsThreadSafe = true)]
		private static JobHandle GetJobHandle(ReadHandle handle); // 0x00000001821929B0-0x0000000182192A00
		private static void CancelInternal_Injected(in ReadHandle handle); // 0x0000000182192660-0x00000001821926A0
		private static ReadStatus GetReadStatus_Injected(in ReadHandle handle); // 0x0000000182192A00-0x0000000182192A40
		private static void ReleaseReadHandle_Injected(in ReadHandle handle); // 0x0000000182192B40-0x0000000182192B80
		private static bool IsReadHandleValid_Injected(in ReadHandle handle); // 0x0000000182192A80-0x0000000182192AC0
		private static void GetJobHandle_Injected(in ReadHandle handle, ); // 0x0000000182192960-0x00000001821929B0
	}
}
