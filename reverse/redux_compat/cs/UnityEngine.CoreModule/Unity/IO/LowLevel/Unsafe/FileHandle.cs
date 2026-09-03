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
	[IsReadOnly]
	public struct FileHandle // TypeDefIndex: 7399
	{
		// Fields
		[NativeDisableUnsafePtrRestriction]
		internal readonly IntPtr fileCommandPtr; // 0x00
		internal readonly int version; // 0x08
	
		// Properties
		public JobHandle JobHandle { get; } // 0x000000018218ECB0-0x000000018218ED80 
	
		// Methods
		public bool IsValid(); // 0x000000018218EC70-0x000000018218ECB0
		public JobHandle Close(JobHandle dependency = default); // 0x000000018218EAE0-0x000000018218EBD0
		[FreeFunction("AsyncReadManagerManaged::IsFileHandleValid")]
		private static bool IsFileHandleValid([IsReadOnly] in FileHandle handle); // 0x000000018218EC70-0x000000018218ECB0
		[FreeFunction("AsyncReadManagerManaged::GetJobFenceFromManagedHandle")]
		private static JobHandle GetJobHandle_Internal([IsReadOnly] in FileHandle handle); // 0x000000018218EC20-0x000000018218EC70
		private static void GetJobHandle_Internal_Injected([IsReadOnly] in FileHandle handle, ); // 0x000000018218EBD0-0x000000018218EC20
	}
}
