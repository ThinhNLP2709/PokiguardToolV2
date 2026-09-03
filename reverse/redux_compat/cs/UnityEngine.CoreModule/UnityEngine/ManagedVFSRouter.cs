/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[RequiredByNativeCode]
	[VisibleToOtherModules(new string[1] {"UnityEngine.ContentLoadModule" })]
	internal static class ManagedVFSRouter // TypeDefIndex: 7861
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		private static readonly Dictionary<InternalManagedFileHandle, Binding> s_HandleToBinding; // 0x00
		[NoAutoStaticsCleanup]
		private static int s_NextHandle; // 0x08
		[NoAutoStaticsCleanup]
		private static readonly ReaderWriterLockSlim s_Lock; // 0x10
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x18
	
		// Nested types
		private struct Binding // TypeDefIndex: 7862
		{
			// Fields
			public IManagedVFSFileHandler handler; // 0x00
			public int handle; // 0x08
		}
	
		// Constructors
		static ManagedVFSRouter(); // 0x0000000182207660-0x00000001822078C0
	
		// Methods
		internal static InternalManagedFileHandle AllocateHandle(IManagedVFSFileHandler handler, int handle); // 0x0000000182206CD0-0x0000000182206E70
		private static Binding GetBinding(InternalManagedFileHandle handle); // 0x0000000182207120-0x00000001822072B0
		[RequiredByNativeCode]
		internal static long GetSize(InternalManagedFileHandle handle); // 0x00000001822072B0-0x0000000182207430
		[RequiredByNativeCode]
		internal static void ReadBytesAsync(InternalManagedFileHandle handle, long offset, IntPtr buffer, int count, ManagedReadAsyncCommand command); // 0x0000000182207430-0x0000000182207600
		[RequiredByNativeCode]
		internal static void CloseFile(InternalManagedFileHandle handle); // 0x0000000182206E70-0x0000000182207120
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x0000000182207600-0x0000000182207660
	}
}
