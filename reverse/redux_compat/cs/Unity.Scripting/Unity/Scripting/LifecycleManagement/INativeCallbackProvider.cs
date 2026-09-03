/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Unity.Scripting;

// Image 34: Unity.Scripting.dll - Assembly: Unity.Scripting, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14806-14898

namespace Unity.Scripting.LifecycleManagement
{
	[NullableContext(1)]
	internal interface INativeCallbackProvider // TypeDefIndex: 14860
	{
		// Nested types
		[NullableContext(0)]
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void LifecycleNativeDelegate(IntPtr invocationContext, IntPtr context); // TypeDefIndex: 14861; 0x0000000180A70FB0-0x0000000180A70FC0
	
		// Methods
		IReadOnlyList<DelegateWithContext<LifecycleNativeDelegate>> GetInitLifecycleNativeEventHandlers(string lifecycleScopeName);
		IReadOnlyList<DelegateWithContext<LifecycleNativeDelegate>> GetCleanupLifecycleNativeEventHandlers(string lifecycleScopeName);
	}
}
