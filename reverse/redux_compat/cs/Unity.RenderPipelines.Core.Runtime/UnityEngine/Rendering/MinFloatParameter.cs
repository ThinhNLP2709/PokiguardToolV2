/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	public class MinFloatParameter : FloatParameter // TypeDefIndex: 5823
	{
		// Fields
		[NonSerialized]
		public float min; // 0x20
	
		// Properties
		public override float value { get; set; } // 0x00000001806CB0A0-0x00000001806CB0B0 0x0000000181EC30E0-0x0000000181EC30F0
	
		// Constructors
		public MinFloatParameter(float value, float min, bool overrideState = false /* Metadata: 0x00661B51 */); // 0x0000000181EC1F80-0x0000000181EC1FB0
	}
}
