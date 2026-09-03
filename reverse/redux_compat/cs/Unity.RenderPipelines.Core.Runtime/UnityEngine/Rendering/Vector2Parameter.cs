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
	public class Vector2Parameter : VolumeParameter<Vector2> // TypeDefIndex: 5833
	{
		// Constructors
		public Vector2Parameter(Vector2 value, bool overrideState = false /* Metadata: 0x00661B5D */); // 0x0000000181EC34B0-0x0000000181EC34C0
	
		// Methods
		public override void Interp(Vector2 from, Vector2 to, float t); // 0x0000000181EBF3E0-0x0000000181EBF430
	}
}
