/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	[DebuggerDisplay("{m_Value} ({m_OverrideState})")]
	public class FloatRangeParameter : VolumeParameter<Vector2> // TypeDefIndex: 5829
	{
		// Fields
		[NonSerialized]
		public float min; // 0x20
		[NonSerialized]
		public float max; // 0x24
	
		// Properties
		public override Vector2 value { get; set; } // 0x0000000180FAFC30-0x0000000180FAFC50 0x0000000181EBF480-0x0000000181EBF4B0
	
		// Constructors
		public FloatRangeParameter(Vector2 value, float min, float max, bool overrideState = false /* Metadata: 0x00661B57 */); // 0x0000000181EBF430-0x0000000181EBF480
	
		// Methods
		public override void Interp(Vector2 from, Vector2 to, float t); // 0x0000000181EBF3E0-0x0000000181EBF430
	}
}
