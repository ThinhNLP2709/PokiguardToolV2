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
	public class ClampedFloatParameter : FloatParameter // TypeDefIndex: 5827
	{
		// Fields
		[NonSerialized]
		public float min; // 0x20
		[NonSerialized]
		public float max; // 0x24
	
		// Properties
		public override float value { get; set; } // 0x00000001806CB0A0-0x00000001806CB0B0 0x0000000181EBCC00-0x0000000181EBCC20
	
		// Constructors
		public ClampedFloatParameter(float value, float min, float max, bool overrideState = false /* Metadata: 0x00661B55 */); // 0x0000000181EBCBB0-0x0000000181EBCC00
	}
}
