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
	public class ColorParameter : VolumeParameter<Color> // TypeDefIndex: 5831
	{
		// Fields
		[NonSerialized]
		public bool hdr; // 0x28
		[NonSerialized]
		public bool showAlpha; // 0x29
		[NonSerialized]
		public bool showEyeDropper; // 0x2A
	
		// Constructors
		public ColorParameter(Color value, bool overrideState = false /* Metadata: 0x00661B59 */); // 0x0000000181EBCD70-0x0000000181EBCDA0
		public ColorParameter(Color value, bool hdr, bool showAlpha, bool showEyeDropper, bool overrideState = false /* Metadata: 0x00661B5A */); // 0x0000000181EBCCF0-0x0000000181EBCD70
	
		// Methods
		public override void Interp(Color from, Color to, float t); // 0x0000000181EBCC80-0x0000000181EBCCF0
	}
}
