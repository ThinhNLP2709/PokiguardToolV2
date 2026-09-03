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

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[NativeHeader("Runtime/Graphics/GPUFence.h")]
	[UsedByNativeCode]
	public struct GraphicsFence // TypeDefIndex: 8305
	{
		// Fields
		internal IntPtr m_Ptr; // 0x00
		internal int m_Version; // 0x08
		internal GraphicsFenceType m_FenceType; // 0x0C
	
		// Methods
		internal void InitPostAllocation(); // 0x00000001822464F0-0x00000001822465A0
		internal bool IsFencePending(); // 0x00000001822465A0-0x0000000182246600
		internal void Validate(); // 0x0000000182246600-0x0000000182246670
		private int GetPlatformNotSupportedVersion(); // 0x00000001815418D0-0x00000001815418E0
		[FreeFunction("GPUFenceInternals::GetVersionNumber", ThrowsException = true)]
		private static int GetVersionNumber(IntPtr fencePtr); // 0x00000001822464B0-0x00000001822464F0
	}
}
