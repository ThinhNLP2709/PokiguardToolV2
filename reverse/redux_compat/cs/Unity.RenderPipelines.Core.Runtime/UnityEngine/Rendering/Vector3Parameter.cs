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
	public class Vector3Parameter : VolumeParameter<Vector3> // TypeDefIndex: 5835
	{
		// Constructors
		public Vector3Parameter(Vector3 value, bool overrideState = false /* Metadata: 0x00661B5F */); // 0x0000000181EC34C0-0x0000000181EC34F0
	
		// Methods
		public override void Interp(Vector3 from, Vector3 to, float t); // 0x0000000181ECE730-0x0000000181ECE780
	}
}
