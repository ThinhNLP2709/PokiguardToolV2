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
	public class TextureParameter : VolumeParameter<Texture> // TypeDefIndex: 5839
	{
		// Fields
		public TextureDimension dimension; // 0x20
	
		// Constructors
		public TextureParameter(Texture value, bool overrideState = false /* Metadata: 0x00661B63 */); // 0x0000000181ECDF00-0x0000000181ECDF20
		public TextureParameter(Texture value, TextureDimension dimension, bool overrideState = false /* Metadata: 0x00661B64 */); // 0x0000000181ECDED0-0x0000000181ECDF00
	
		// Methods
		public override int GetHashCode(); // 0x0000000181ECDDD0-0x0000000181ECDED0
	}
}
