/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	[NativeClass("ColorRGBAf")]
	[NativeHeader("Runtime/Math/Color.h")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	public struct Color : IEquatable<UnityEngine.Color>, IFormattable // TypeDefIndex: 7655
	{
		// Fields
		public float r; // 0x00
		public float g; // 0x04
		public float b; // 0x08
		public float a; // 0x0C
	
		// Properties
		public Color linear { [IsReadOnly] get; } // 0x00000001821C84A0-0x00000001821C8500 
		public Color gamma { [IsReadOnly] get; } // 0x00000001821C83F0-0x00000001821C8450 
		public float maxColorComponent { [IsReadOnly] get; } // 0x00000001821C8520-0x00000001821C8530 
		public float this[int index] { [IsReadOnly] get => default; } // 0x00000001821C82C0-0x00000001821C8390 
		public static Color black { get; } // 0x00000001821C8390-0x00000001821C83B0 
		public static Color blue { get; } // 0x00000001821C83B0-0x00000001821C83D0 
		public static Color clear { get; } // 0x0000000180C32AD0-0x0000000180C32AE0 
		public static Color cyan { get; } // 0x00000001821C83D0-0x00000001821C83F0 
		public static Color gray { get; } // 0x00000001821C8470-0x00000001821C8480 
		public static Color grey { get; } // 0x00000001821C8470-0x00000001821C8480 
		public static Color gray5 { get; } // 0x00000001821C8450-0x00000001821C8470 
		public static Color green { get; } // 0x00000001821C8480-0x00000001821C84A0 
		public static Color magenta { get; } // 0x00000001821C8500-0x00000001821C8520 
		public static Color red { get; } // 0x00000001821C8530-0x00000001821C8550 
		public static Color white { get; } // 0x00000001821C8550-0x00000001821C8570 
		public static Color yellow { get; } // 0x00000001821C8570-0x00000001821C8590 
	
		// Constructors
		public Color(float r, float g, float b, float a); // 0x0000000182082140-0x0000000182082160
		public Color(float r, float g, float b); // 0x00000001821C82A0-0x00000001821C82C0
	
		// Methods
		[IsReadOnly]
		public override string ToString(); // 0x00000001821C8020-0x00000001821C8030
		[IsReadOnly]
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001821C8030-0x00000001821C82A0
		[IsReadOnly]
		public override int GetHashCode(); // 0x00000001808BE1A0-0x00000001808BE210
		[IsReadOnly]
		public override bool Equals(object other); // 0x00000001821C7E30-0x00000001821C7F30
		[IsReadOnly]
		public bool Equals(Color other); // 0x0000000182192DA0-0x0000000182192E20
		[IsReadOnly]
		public bool Equals([IsReadOnly] in Color other); // 0x0000000182192DA0-0x0000000182192E20
		public static Color operator +(Color a, Color b); // 0x0000000182082610-0x0000000182082660
		public static Color operator -(Color a, Color b); // 0x00000001821C86C0-0x00000001821C8710
		public static Color operator *(Color a, Color b); // 0x00000001821C8670-0x00000001821C86C0
		public static Color operator *(Color a, float b); // 0x0000000182082270-0x0000000182082290
		public static bool operator ==(Color lhs, Color rhs); // 0x00000001821C8590-0x00000001821C85F0
		public static bool operator !=(Color lhs, Color rhs); // 0x00000001821C8610-0x00000001821C8670
		public static Color Lerp(Color a, Color b, float t); // 0x00000001821C7FA0-0x00000001821C8020
		public static Color LerpUnclamped(Color a, Color b, float t); // 0x00000001821C7F30-0x00000001821C7FA0
		[IsReadOnly]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal Color RGBMultiplied(float multiplier); // 0x0000000180351740-0x0000000180351770
		public static implicit operator Vector4(Color c); // 0x00000001821C85F0-0x00000001821C8610
		public static implicit operator Color(Vector4 v); // 0x00000001821C85F0-0x00000001821C8610
	}
}
