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
	public class NoInterpMaxIntParameter : VolumeParameter<int> // TypeDefIndex: 5818
	{
		// Fields
		[NonSerialized]
		public int max; // 0x20
	
		// Properties
		public override int value { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000181EC1FF0-0x0000000181EC2000
	
		// Constructors
		public NoInterpMaxIntParameter(int value, int max, bool overrideState = false /* Metadata: 0x00661B4C */); // 0x0000000181EC1FC0-0x0000000181EC1FF0
	}
}
