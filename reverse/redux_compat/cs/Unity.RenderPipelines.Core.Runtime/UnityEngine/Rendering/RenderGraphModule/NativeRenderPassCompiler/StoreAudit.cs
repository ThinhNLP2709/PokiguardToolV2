/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler
{
	[DebuggerDisplay("{reason} : {passId} / MSAA {msaaReason} : {msaaPassId}")]
	[IsReadOnly]
	internal struct StoreAudit // TypeDefIndex: 6004
	{
		// Fields
		public static readonly string[] StoreReasonMessages; // 0x00
		public readonly StoreReason reason; // 0x00
		public readonly int passId; // 0x04
		public readonly StoreReason msaaReason; // 0x08
		public readonly int msaaPassId; // 0x0C
	
		// Constructors
		public StoreAudit(StoreReason setReason, int setPassId = -1 /* Metadata: 0x00662D0F */, StoreReason setMsaaReason = StoreReason.NoMSAABuffer /* Metadata: 0x00662D10 */, int setMsaaPassId = -1 /* Metadata: 0x00662D11 */); // 0x000000018192E480-0x000000018192E4A0
		static StoreAudit(); // 0x0000000181F03230-0x0000000181F033D0
	}
}
