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
	public class FloatParameter : VolumeParameter<float> // TypeDefIndex: 5821
	{
		// Constructors
		public FloatParameter(float value, bool overrideState = false /* Metadata: 0x00661B4F */); // 0x0000000181EBF3D0-0x0000000181EBF3E0
	
		// Methods
		public sealed override void Interp(float from, float to, float t); // 0x0000000181EBF3B0-0x0000000181EBF3D0
	}
}
