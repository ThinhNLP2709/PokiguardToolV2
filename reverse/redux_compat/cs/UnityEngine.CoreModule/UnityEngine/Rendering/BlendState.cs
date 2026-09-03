/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct BlendState : IEquatable<UnityEngine.Rendering.BlendState> // TypeDefIndex: 8392
	{
		// Fields
		private RenderTargetBlendState m_BlendState0; // 0x00
		private RenderTargetBlendState m_BlendState1; // 0x08
		private RenderTargetBlendState m_BlendState2; // 0x10
		private RenderTargetBlendState m_BlendState3; // 0x18
		private RenderTargetBlendState m_BlendState4; // 0x20
		private RenderTargetBlendState m_BlendState5; // 0x28
		private RenderTargetBlendState m_BlendState6; // 0x30
		private RenderTargetBlendState m_BlendState7; // 0x38
		private byte m_SeparateMRTBlendStates; // 0x40
		private byte m_AlphaToMask; // 0x41
		private short m_Padding; // 0x42
	
		// Properties
		public static BlendState defaultValue { get; } // 0x00000001822566F0-0x0000000182256800 
		public RenderTargetBlendState blendState0 { set; } // 0x0000000180CBE820-0x0000000180CBE830
	
		// Constructors
		public BlendState(bool separateMRTBlend = false /* Metadata: 0x0069DB82 */, bool alphaToMask = false /* Metadata: 0x0069DB83 */); // 0x00000001822565E0-0x00000001822566F0
	
		// Methods
		public bool Equals(BlendState other); // 0x0000000182256170-0x0000000182256410
		public override bool Equals(object obj); // 0x0000000182256410-0x00000001822564D0
		public override int GetHashCode(); // 0x00000001822564D0-0x00000001822565E0
	}
}
