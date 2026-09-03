/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule.NativeRenderPassCompiler
{
	[DebuggerDisplay("{reason} : {breakPass}")]
	[IsReadOnly]
	internal struct PassBreakAudit // TypeDefIndex: 6006
	{
		// Fields
		public readonly PassBreakReason reason; // 0x00
		public readonly int breakPass; // 0x04
		public static readonly string[] BreakReasonMessages; // 0x00
	
		// Constructors
		public PassBreakAudit(PassBreakReason reason, int breakPass); // 0x0000000180C55C70-0x0000000180C55C80
		static PassBreakAudit(); // 0x0000000181F00A60-0x0000000181F00E50
	}
}
