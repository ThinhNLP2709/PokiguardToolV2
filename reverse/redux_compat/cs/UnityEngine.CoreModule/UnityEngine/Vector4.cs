/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IL2CPP.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	[Il2CppEagerStaticClassConstruction]
	[NativeClass("Vector4f")]
	[NativeHeader("Runtime/Math/Vector4.h")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	public struct Vector4 : IEquatable<UnityEngine.Vector4>, IFormattable // TypeDefIndex: 7671
	{
		// Fields
		public float x; // 0x00
		public float y; // 0x04
		public float z; // 0x08
		public float w; // 0x0C
		private static readonly Vector4 zeroVector; // 0x00
		private static readonly Vector4 oneVector; // 0x10
		private static readonly Vector4 positiveInfinityVector; // 0x20
		private static readonly Vector4 negativeInfinityVector; // 0x30
	
		// Properties
		public float this[int index] { [IsReadOnly] get => default; set {} } // 0x0000000181F30840-0x0000000181F308D0 0x0000000181E52A00-0x0000000181E52A90
		public Vector4 normalized { [IsReadOnly] get; } // 0x00000001821FDF00-0x00000001821FDF70 
		public float magnitude { [IsReadOnly] get; } // 0x00000001821FDE50-0x00000001821FDF00 
		public float sqrMagnitude { [IsReadOnly] get; } // 0x00000001821FDF90-0x00000001821FDFC0 
		public static Vector4 zero { get; } // 0x00000001820BF6E0-0x00000001820BF700 
		public static Vector4 one { get; } // 0x00000001821FDF70-0x00000001821FDF90 
	
		// Constructors
		public Vector4(float x, float y, float z, float w); // 0x0000000182082140-0x0000000182082160
		public Vector4(float x, float y, float z); // 0x00000001821FDE30-0x00000001821FDE50
		public Vector4(float x, float y); // 0x00000001821FDE20-0x00000001821FDE30
		static Vector4(); // 0x00000001821FDDB0-0x00000001821FDE20
	
		// Methods
		public static implicit operator float4(Vector4 v); // 0x00000001821C85F0-0x00000001821C8610
		public static implicit operator Vector4(float4 v); // 0x00000001821C85F0-0x00000001821C8610
		public void Set(float newX, float newY, float newZ, float newW); // 0x0000000182082140-0x0000000182082160
		public static Vector4 Lerp(Vector4 a, Vector4 b, float t); // 0x00000001821C7FA0-0x00000001821C8020
		public void Scale(Vector4 scale); // 0x00000001821FDAF0-0x00000001821FDB30
		[IsReadOnly]
		public override int GetHashCode(); // 0x00000001808BE1A0-0x00000001808BE210
		[IsReadOnly]
		public override bool Equals(object other); // 0x000000018074E2E0-0x000000018074E370
		[IsReadOnly]
		public bool Equals(Vector4 other); // 0x000000018192E0B0-0x000000018192E0F0
		[IsReadOnly]
		public bool Equals([IsReadOnly] in Vector4 other); // 0x000000018192E0B0-0x000000018192E0F0
		public static Vector4 Normalize([IsReadOnly] in Vector4 a); // 0x00000001821FDA80-0x00000001821FDAF0
		public static float Dot([IsReadOnly] in Vector4 a, [IsReadOnly] in Vector4 b); // 0x00000001821F68F0-0x00000001821F6930
		public static Vector4 operator +(Vector4 a, Vector4 b); // 0x0000000182082610-0x0000000182082660
		public static Vector4 operator -(Vector4 a, Vector4 b); // 0x00000001821C86C0-0x00000001821C8710
		public static Vector4 operator -(Vector4 a); // 0x00000001821FE050-0x00000001821FE340
		public static Vector4 operator *(Vector4 a, float d); // 0x0000000182082270-0x0000000182082290
		public static Vector4 operator *(float d, Vector4 a); // 0x00000001821FE030-0x00000001821FE050
		public static Vector4 operator /(Vector4 a, float d); // 0x00000001821FDFC0-0x00000001821FDFE0
		public static bool operator ==(Vector4 lhs, Vector4 rhs); // 0x00000001821C8590-0x00000001821C85F0
		public static bool operator !=(Vector4 lhs, Vector4 rhs); // 0x00000001821C8610-0x00000001821C8670
		public static implicit operator Vector4(Vector3 v); // 0x00000001821FDFE0-0x00000001821FE000
		public static implicit operator Vector3(Vector4 v); // 0x0000000181DF5340-0x0000000181DF5360
		public static implicit operator Vector4(Vector2 v); // 0x00000001821FE000-0x00000001821FE030
		public static implicit operator Vector2(Vector4 v); // 0x0000000181E6F9A0-0x0000000181E6F9C0
		[IsReadOnly]
		public override string ToString(); // 0x00000001821FDDA0-0x00000001821FDDB0
		[IsReadOnly]
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001821FDB30-0x00000001821FDDA0
	}
}
