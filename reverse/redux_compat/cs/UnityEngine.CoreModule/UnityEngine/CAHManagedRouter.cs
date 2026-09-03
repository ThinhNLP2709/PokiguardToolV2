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
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[RequiredByNativeCode]
	internal static class CAHManagedRouter // TypeDefIndex: 7860
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static readonly List<ICAHArtifactHandler> s_Handlers; // 0x00
		[NoAutoStaticsCleanup]
		private static readonly ReaderWriterLockSlim s_Lock; // 0x08
		[NoAutoStaticsCleanup]
		private static readonly DelegateAutoCleanup s_CodeReloadCleanup; // 0x10
	
		// Constructors
		static CAHManagedRouter(); // 0x0000000182201150-0x00000001822013A0
	
		// Methods
		private static void OnCodeReloadCleanup(); // 0x0000000182200BA0-0x0000000182200CE0
		[RequiredByNativeCode]
		internal static bool Exists(Hash128 hash); // 0x0000000182200810-0x0000000182200BA0
		[RequiredByNativeCode]
		internal static bool OpenFile(Hash128 hash, int flags, IntPtr outHandle); // 0x0000000182200CE0-0x0000000182201150
	}
}
