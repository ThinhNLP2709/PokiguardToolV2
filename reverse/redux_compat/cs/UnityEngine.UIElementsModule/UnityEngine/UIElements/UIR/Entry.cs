/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class Entry // TypeDefIndex: 5060
	{
		// Fields
		public EntryType type; // 0x10
		public EntryFlags flags; // 0x12
		public NativeSlice<Vertex> vertices; // 0x18
		public NativeSlice<ushort> indices; // 0x28
		public NativeSlice<Vector4> texCoord1; // 0x38
		public NativeSlice<Vector4> texCoord2; // 0x48
		public NativeSlice<Vector4> texCoord3; // 0x58
		public NativeSlice<Vector3> normal; // 0x68
		public NativeSlice<Vector4> tangent; // 0x78
		public Texture texture; // 0x88
		public float textScale; // 0x90
		public float fontSharpness; // 0x94
		public VectorImage gradientsOwner; // 0x98
		public Material material; // 0xA0
		public MaterialPropertyBlock userProps; // 0xA8
		public Action immediateCallback; // 0xB0
		public TextureId textureId; // 0xB8
		public EntityId panelComponentId; // 0xC0
		public int userData; // 0xC8
		public Entry nextSibling; // 0xD0
		public Entry firstChild; // 0xD8
		public Entry lastChild; // 0xE0
	
		// Properties
		public DrawPhase phase { set; } // 0x000000018240F9D0-0x000000018240F9F0
	
		// Constructors
		public Entry(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void Reset(); // 0x000000018240F8D0-0x000000018240F9D0
	}
}
