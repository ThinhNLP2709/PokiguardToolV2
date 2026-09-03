/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	[DefaultMember("Item")]
	[Il2CppEagerStaticClassConstruction]
	[NativeHeader("Runtime/Math/Vector2Int.h")]
	[UsedByNativeCode]
	public struct Vector2Int : IEquatable<UnityEngine.Vector2Int>, IFormattable // TypeDefIndex: 7669
	{
		// Fields
		private int m_X; // 0x00
		private int m_Y; // 0x04
		private static readonly Vector2Int s_Zero; // 0x00
		private static readonly Vector2Int s_One; // 0x08
		private static readonly Vector2Int s_Up; // 0x10
		private static readonly Vector2Int s_Down; // 0x18
		private static readonly Vector2Int s_Left; // 0x20
		private static readonly Vector2Int s_Right; // 0x28
	
		// Properties
		public int x { [IsReadOnly] get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public int y { [IsReadOnly] get; set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
		public float magnitude { [IsReadOnly] get; } // 0x00000001821FC3F0-0x00000001821FC480 
		public static Vector2Int zero { get; } // 0x00000001821FC4A0-0x00000001821FC4C0 
		public static Vector2Int one { get; } // 0x00000001821FC480-0x00000001821FC4A0 
	
		// Constructors
		public Vector2Int(int x, int y); // 0x0000000180C55C70-0x0000000180C55C80
		static Vector2Int(); // 0x00000001821FC320-0x00000001821FC3F0
	
		// Methods
		public static Vector2Int Max(Vector2Int lhs, Vector2Int rhs); // 0x00000001821FC1C0-0x00000001821FC240
		public static implicit operator Vector2(Vector2Int v); // 0x00000001821FC510-0x00000001821FC530
		public static Vector2Int FloorToInt(Vector2 v); // 0x00000001821FC0D0-0x00000001821FC1B0
		public static Vector2Int operator +(Vector2Int a, Vector2Int b); // 0x00000001821FC4C0-0x00000001821FC4E0
		public static Vector2Int operator -(Vector2Int a, Vector2Int b); // 0x00000001821FC570-0x00000001821FC590
		public static Vector2Int operator *(int a, Vector2Int b); // 0x00000001821FC550-0x00000001821FC570
		public static Vector2Int operator /(Vector2Int a, int b); // 0x00000001821FC4E0-0x00000001821FC510
		public static bool operator ==(Vector2Int lhs, Vector2Int rhs); // 0x000000018192DC90-0x000000018192DCB0
		public static bool operator !=(Vector2Int lhs, Vector2Int rhs); // 0x00000001821FC530-0x00000001821FC550
		[IsReadOnly]
		public override bool Equals(object other); // 0x00000001821FC050-0x00000001821FC0B0
		[IsReadOnly]
		public bool Equals(Vector2Int other); // 0x000000018219A7A0-0x000000018219A7C0
		[IsReadOnly]
		public bool Equals([IsReadOnly] in Vector2Int other); // 0x00000001821FC0B0-0x00000001821FC0D0
		[IsReadOnly]
		public override int GetHashCode(); // 0x00000001821FC1B0-0x00000001821FC1C0
		[IsReadOnly]
		public override string ToString(); // 0x00000001821FC310-0x00000001821FC320
		[IsReadOnly]
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001821FC240-0x00000001821FC310
	}
}
