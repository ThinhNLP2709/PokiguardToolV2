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
	public class Vector4Parameter : VolumeParameter<Vector4> // TypeDefIndex: 5837
	{
		// Constructors
		public Vector4Parameter(Vector4 value, bool overrideState = false /* Metadata: 0x00661B61 */); // 0x0000000181EC34F0-0x0000000181EC3510
	
		// Methods
		public override void Interp(Vector4 from, Vector4 to, float t); // 0x0000000181EBCC80-0x0000000181EBCCF0
	}
}
