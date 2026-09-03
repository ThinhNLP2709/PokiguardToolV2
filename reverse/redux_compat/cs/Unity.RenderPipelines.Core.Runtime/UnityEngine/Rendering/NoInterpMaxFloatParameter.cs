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
	public class NoInterpMaxFloatParameter : VolumeParameter<float> // TypeDefIndex: 5826
	{
		// Fields
		[NonSerialized]
		public float max; // 0x20
	
		// Properties
		public override float value { get; set; } // 0x00000001806CB0A0-0x00000001806CB0B0 0x0000000181EC1FB0-0x0000000181EC1FC0
	
		// Constructors
		public NoInterpMaxFloatParameter(float value, float max, bool overrideState = false /* Metadata: 0x00661B54 */); // 0x0000000181EC1F80-0x0000000181EC1FB0
	}
}
