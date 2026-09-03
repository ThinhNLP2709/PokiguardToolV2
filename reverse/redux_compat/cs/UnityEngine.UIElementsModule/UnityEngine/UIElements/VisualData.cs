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
	internal struct VisualData : IStyleDataGroup<VisualData>, IEquatable<VisualData> // TypeDefIndex: 4627
	{
		// Fields
		public Color backgroundColor; // 0x00
		public Color borderBottomColor; // 0x10
		public Color borderLeftColor; // 0x20
		public Color borderRightColor; // 0x30
		public Color borderTopColor; // 0x40
		public UnmanagedBackground backgroundImage; // 0x50
		public BackgroundRepeat backgroundRepeat; // 0x60
		public Length borderBottomLeftRadius; // 0x68
		public Length borderBottomRightRadius; // 0x70
		public Length borderTopLeftRadius; // 0x78
		public Length borderTopRightRadius; // 0x80
		public BackgroundPosition backgroundPositionX; // 0x88
		public BackgroundPosition backgroundPositionY; // 0x94
		public BackgroundSize backgroundSize; // 0xA0
		public float opacity; // 0xB4
	
		// Methods
		public VisualData GetDefault(); // 0x000000018255C330-0x000000018255C350
		public VisualData Copy(); // 0x000000018255BFD0-0x000000018255C0D0
		public void CopyFrom(ref VisualData other); // 0x000000018255BEE0-0x000000018255BFD0
		public void Dispose(); // 0x000000018255C0D0-0x000000018255C0E0
		public static bool operator ==(VisualData lhs, VisualData rhs); // 0x000000018255C650-0x000000018255D730
		public bool Equals(VisualData other); // 0x000000018255C0E0-0x000000018255C210
		public override bool Equals(object obj); // 0x000000018255C210-0x000000018255C330
		public override int GetHashCode(); // 0x000000018255C350-0x000000018255C650
	}
}
