/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal struct UnmanagedMaterialPropertyValue : IEquatable<UnmanagedMaterialPropertyValue> // TypeDefIndex: 4643
	{
		// Fields
		public int name; // 0x00
		public MaterialPropertyValueType type; // 0x04
		public Vector4 packedValue; // 0x08
		public EntityId textureValue; // 0x18
	
		// Methods
		public static implicit operator UnmanagedMaterialPropertyValue(MaterialPropertyValue mpv); // 0x0000000182571050-0x0000000182571170
		public bool Equals(UnmanagedMaterialPropertyValue other); // 0x0000000182570F70-0x0000000182571030
		public float GetFloat(); // 0x00000001802DB050-0x00000001802DB060
		public Vector4 GetVector(); // 0x0000000180C57230-0x0000000180C57240
		public Color GetColor(); // 0x0000000182571030-0x0000000182571050
	}
}
