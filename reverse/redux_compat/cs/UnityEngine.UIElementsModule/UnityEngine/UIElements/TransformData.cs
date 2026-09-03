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
	internal struct TransformData : IStyleDataGroup<UnityEngine.UIElements.TransformData>, IEquatable<UnityEngine.UIElements.TransformData> // TypeDefIndex: 4625
	{
		// Fields
		public Scale scale; // 0x00
		public Rotate rotate; // 0x10
		public Translate translate; // 0x28
		public TransformOrigin transformOrigin; // 0x40
	
		// Methods
		public TransformData GetDefault(); // 0x0000000182547020-0x0000000182547040
		public TransformData Copy(); // 0x0000000182546D70-0x0000000182546DB0
		public void CopyFrom(ref TransformData other); // 0x0000000182546D30-0x0000000182546D70
		public void Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		public static bool operator ==(TransformData lhs, TransformData rhs); // 0x00000001825470C0-0x0000000182547260
		public bool Equals(TransformData other); // 0x0000000182546DB0-0x0000000182546F50
		public override bool Equals(object obj); // 0x0000000182546F50-0x0000000182547020
		public override int GetHashCode(); // 0x0000000182547040-0x00000001825470C0
	}
}
