/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal struct MaterialPropertyValue : IEquatable<MaterialPropertyValue> // TypeDefIndex: 4639
	{
		// Fields
		public string name; // 0x00
		public MaterialPropertyValueType type; // 0x08
		public Vector4 packedValue; // 0x0C
		public Texture textureValue; // 0x20
	
		// Methods
		public float GetFloat(); // 0x00000001802DB040-0x00000001802DB050
		public Vector4 GetVector(); // 0x0000000181D8BE90-0x0000000181D8BEA0
		public Color GetColor(); // 0x00000001825456D0-0x00000001825456F0
		public override string ToString(); // 0x00000001825458A0-0x0000000182545A00
		public static bool operator !=(MaterialPropertyValue lhs, MaterialPropertyValue rhs); // 0x0000000182545A00-0x0000000182545A40
		public override bool Equals(object obj); // 0x00000001825454F0-0x00000001825455A0
		public bool Equals(MaterialPropertyValue other); // 0x00000001825455A0-0x00000001825456D0
		public override int GetHashCode(); // 0x00000001825456F0-0x00000001825458A0
	}
}
