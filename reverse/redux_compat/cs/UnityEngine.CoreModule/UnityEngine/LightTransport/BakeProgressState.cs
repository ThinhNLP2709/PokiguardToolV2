/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.LightTransport
{
	[NativeHeader("Runtime/Export/GI/BakeProgressState.bindings.h")]
	public class BakeProgressState // TypeDefIndex: 8183
	{
		// Fields
		internal IntPtr m_Ptr; // 0x10
		internal bool m_OwnsPtr; // 0x18
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 8184
		{
			// Methods
			public static IntPtr ConvertToNative(BakeProgressState obj); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Methods
		[NativeMethod(IsThreadSafe = true)]
		public void IncrementCompletedWorkSteps(ulong steps); // 0x000000018222AA60-0x000000018222AAC0
		private static void IncrementCompletedWorkSteps_Injected(IntPtr _unity_self, ulong steps); // 0x000000018222AA10-0x000000018222AA60
	}
}
