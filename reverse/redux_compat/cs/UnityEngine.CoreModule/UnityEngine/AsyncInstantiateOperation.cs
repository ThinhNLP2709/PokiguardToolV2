/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
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
	[NativeHeader("Runtime/GameCode/AsyncInstantiate/AsyncInstantiateOperation.h")]
	[RequiredByNativeCode]
	public class AsyncInstantiateOperation : AsyncOperation // TypeDefIndex: 7705
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		internal static CancellationTokenSource s_GlobalCancellation; // 0x00
		internal Object[] m_Result; // 0x20
		private CancellationToken m_CancellationToken; // 0x28
		private CancellationTokenSource m_LinkedCancellation; // 0x30
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x08
	
		// Constructors
		protected AsyncInstantiateOperation(IntPtr ptr, CancellationToken cancellationToken); // 0x00000001821E19F0-0x00000001821E1C50
		static AsyncInstantiateOperation(); // 0x00000001821E1880-0x00000001821E19F0
	
		// Methods
		private void DisposeLinkedCancellation(AsyncOperation _); // 0x00000001821E1720-0x00000001821E1760
		[RequiredByNativeCode]
		private static bool IsCancellationRequested(AsyncInstantiateOperation self); // 0x00000001821E1760-0x00000001821E17C0
		internal virtual Object[] CreateResultArray(int size); // 0x00000001821E16C0-0x00000001821E1720
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001821E17C0-0x00000001821E1880
	}
}
