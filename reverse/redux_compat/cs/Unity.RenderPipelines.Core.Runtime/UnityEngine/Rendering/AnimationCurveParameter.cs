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
	public class AnimationCurveParameter : VolumeParameter<AnimationCurve> // TypeDefIndex: 5849
	{
		// Constructors
		public AnimationCurveParameter(AnimationCurve value, bool overrideState = false /* Metadata: 0x00661B6C */); // 0x0000000181EBCB60-0x0000000181EBCB70
	
		// Methods
		public override void Interp(AnimationCurve lhsCurve, AnimationCurve rhsCurve, float t); // 0x0000000181EBCA80-0x0000000181EBCAD0
		public override void SetValue(VolumeParameter parameter); // 0x0000000181EBCAD0-0x0000000181EBCB60
		public override object Clone(); // 0x0000000181EBC900-0x0000000181EBC9E0
		public override int GetHashCode(); // 0x0000000181EBC9E0-0x0000000181EBCA80
	}
}
