/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 57: UnityEngine.VFXModule.dll - Assembly: UnityEngine.VFXModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15667-15684

namespace UnityEngine.VFX
{
	[NativeHeader("Modules/VFX/Public/VFXSpawnerState.h")]
	[RequiredByNativeCode]
	public sealed class VFXSpawnerState : IDisposable // TypeDefIndex: 15679
	{
		// Fields
		private IntPtr m_Ptr; // 0x10
		private bool m_Owner; // 0x18
		private VFXEventAttribute m_WrapEventAttribute; // 0x20
	
		// Constructors
		internal VFXSpawnerState(IntPtr ptr, bool owner); // 0x00000001821778C0-0x0000000182177900
	
		// Methods
		[RequiredByNativeCode]
		internal static VFXSpawnerState CreateSpawnerStateWrapper(); // 0x00000001825D2560-0x00000001825D2670
		private void PrepareWrapper(); // 0x00000001825D2810-0x00000001825D2920
		[RequiredByNativeCode]
		internal void SetWrapValue(IntPtr ptrToSpawnerState, IntPtr ptrToEventAttribute); // 0x00000001825D2990-0x00000001825D2AA0
		private void Release(); // 0x00000001825D2920-0x00000001825D2990
		~VFXSpawnerState(); // 0x00000001825D2710-0x00000001825D27D0
		public void Dispose(); // 0x00000001825D2670-0x00000001825D2710
		[NativeMethod(IsThreadSafe = true)]
		private static void Internal_Destroy(IntPtr ptr); // 0x00000001825D27D0-0x00000001825D2810
	}
}
