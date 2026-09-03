/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler
{
	[DebuggerDisplay("{reason} : {passId}")]
	[IsReadOnly]
	internal struct LoadAudit // TypeDefIndex: 6002
	{
		// Fields
		public static readonly string[] LoadReasonMessages; // 0x00
		public readonly LoadReason reason; // 0x00
		public readonly int passId; // 0x04
	
		// Constructors
		public LoadAudit(LoadReason setReason, int setPassId = -1 /* Metadata: 0x00662D06 */); // 0x0000000180C55C70-0x0000000180C55C80
		static LoadAudit(); // 0x0000000181EF15A0-0x0000000181EF1720
	}
}
