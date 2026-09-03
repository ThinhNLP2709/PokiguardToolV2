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
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	[DefaultMember("Item")]
	[Il2CppEagerStaticClassConstruction]
	[UsedByNativeCode]
	public struct Vector3Int : IEquatable<UnityEngine.Vector3Int>, IFormattable // TypeDefIndex: 7670
	{
		// Fields
		private int m_X; // 0x00
		private int m_Y; // 0x04
		private int m_Z; // 0x08
		private static readonly Vector3Int s_Zero; // 0x00
		private static readonly Vector3Int s_One; // 0x0C
		private static readonly Vector3Int s_Up; // 0x18
		private static readonly Vector3Int s_Down; // 0x24
		private static readonly Vector3Int s_Left; // 0x30
		private static readonly Vector3Int s_Right; // 0x3C
		private static readonly Vector3Int s_Forward; // 0x48
		private static readonly Vector3Int s_Back; // 0x54
	
		// Properties
		public int x { [IsReadOnly] get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public int y { [IsReadOnly] get; set; } // 0x00000001802E7C60-0x00000001802E7DA0 0x0000000180732D40-0x0000000180732D50
		public int z { [IsReadOnly] get; set; } // 0x0000000180732D20-0x0000000180732D30 0x0000000180732D60-0x0000000180732D70
		public static Vector3Int zero { get; } // 0x00000001821FD9A0-0x00000001821FD9C0 
		public static Vector3Int one { get; } // 0x00000001821FD970-0x00000001821FD9A0 
	
		// Constructors
		public Vector3Int(int x, int y, int z); // 0x0000000180F46690-0x0000000180F466A0
		static Vector3Int(); // 0x00000001821FD830-0x00000001821FD970
	
		// Methods
		public static Vector3Int Min(Vector3Int lhs, Vector3Int rhs); // 0x00000001821FD670-0x00000001821FD720
		public static Vector3Int Max(Vector3Int lhs, Vector3Int rhs); // 0x00000001821FD5C0-0x00000001821FD670
		public static implicit operator Vector3(Vector3Int v); // 0x00000001821FDA10-0x00000001821FDA40
		public static Vector3Int operator +(Vector3Int a, Vector3Int b); // 0x00000001821FD9C0-0x00000001821FD9E0
		public static Vector3Int operator -(Vector3Int a, Vector3Int b); // 0x00000001821FDA60-0x00000001821FDA80
		public static Vector3Int operator *(Vector3Int a, int b); // 0x00000001821FDA40-0x00000001821FDA60
		public static Vector3Int operator /(Vector3Int a, int b); // 0x00000001821FD9E0-0x00000001821FDA10
		public static bool operator ==(Vector3Int lhs, Vector3Int rhs); // 0x00000001821FD540-0x00000001821FD560
		[IsReadOnly]
		public override bool Equals(object other); // 0x000000018074E1E0-0x000000018074E260
		[IsReadOnly]
		public bool Equals(Vector3Int other); // 0x00000001821FD540-0x00000001821FD560
		[IsReadOnly]
		public bool Equals([IsReadOnly] in Vector3Int other); // 0x00000001821FD540-0x00000001821FD560
		[IsReadOnly]
		public override int GetHashCode(); // 0x00000001821FD560-0x00000001821FD5C0
		[IsReadOnly]
		public override string ToString(); // 0x00000001821FD720-0x00000001821FD730
		[IsReadOnly]
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001821FD730-0x00000001821FD830
	}
}
