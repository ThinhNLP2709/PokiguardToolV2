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
	public class ClampedIntParameter : IntParameter // TypeDefIndex: 5819
	{
		// Fields
		[NonSerialized]
		public int min; // 0x20
		[NonSerialized]
		public int max; // 0x24
	
		// Properties
		public override int value { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000181EBCC60-0x0000000181EBCC80
	
		// Constructors
		public ClampedIntParameter(int value, int min, int max, bool overrideState = false /* Metadata: 0x00661B4D */); // 0x0000000181EBCC20-0x0000000181EBCC60
	}
}
