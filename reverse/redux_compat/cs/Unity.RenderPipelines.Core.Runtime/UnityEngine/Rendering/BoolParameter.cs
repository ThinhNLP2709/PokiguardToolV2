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
	public class BoolParameter : VolumeParameter<bool> // TypeDefIndex: 5809
	{
		// Fields
		[NonSerialized]
		public DisplayType displayType; // 0x20
	
		// Nested types
		public enum DisplayType // TypeDefIndex: 5810
		{
			Checkbox = 0,
			EnumPopup = 1
		}
	
		// Constructors
		public BoolParameter(bool value, bool overrideState = false /* Metadata: 0x00661B41 */); // 0x0000000181EBCB70-0x0000000181EBCB80
		public BoolParameter(bool value, DisplayType displayType, bool overrideState = false /* Metadata: 0x00661B42 */); // 0x0000000181EBCB80-0x0000000181EBCBB0
	}
}
