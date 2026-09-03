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
	public class IntParameter : VolumeParameter<int> // TypeDefIndex: 5813
	{
		// Constructors
		public IntParameter(int value, bool overrideState = false /* Metadata: 0x00661B47 */); // 0x00000001810FA880-0x00000001810FA890
	
		// Methods
		public sealed override void Interp(int from, int to, float t); // 0x0000000181EBF750-0x0000000181EBF780
	}
}
