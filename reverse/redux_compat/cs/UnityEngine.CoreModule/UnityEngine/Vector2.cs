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
using UnityEngine.Internal;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	[Il2CppEagerStaticClassConstruction]
	[NativeClass("Vector2f")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	public struct Vector2 : IEquatable<UnityEngine.Vector2>, IFormattable // TypeDefIndex: 7668
	{
		// Fields
		public float x; // 0x00
		public float y; // 0x04
		private static readonly Vector2 zeroVector; // 0x00
		private static readonly Vector2 oneVector; // 0x08
		private static readonly Vector2 upVector; // 0x10
		private static readonly Vector2 downVector; // 0x18
		private static readonly Vector2 leftVector; // 0x20
		private static readonly Vector2 rightVector; // 0x28
		private static readonly Vector2 positiveInfinityVector; // 0x30
		private static readonly Vector2 negativeInfinityVector; // 0x38
	
		// Properties
		public float this[int index] { [IsReadOnly] get => default; set {} } // 0x0000000181CE3A00-0x0000000181CE3A80 0x00000001821FD4C0-0x00000001821FD540
		public Vector2 normalized { [IsReadOnly] get; } // 0x00000001821FCAE0-0x00000001821FCB40 
		public float magnitude { [IsReadOnly] get; } // 0x00000001821FD0E0-0x00000001821FD170 
		public float sqrMagnitude { [IsReadOnly] get; } // 0x00000001821FD200-0x00000001821FD220 
		public static Vector2 zero { get; } // 0x0000000181E53EB0-0x0000000181E53ED0 
		public static Vector2 one { get; } // 0x00000001821FD170-0x00000001821FD1A0 
		public static Vector2 up { get; } // 0x00000001821FD220-0x00000001821FD250 
		public static Vector2 down { get; } // 0x00000001821FD080-0x00000001821FD0B0 
		public static Vector2 left { get; } // 0x00000001821FD0B0-0x00000001821FD0E0 
		public static Vector2 right { get; } // 0x00000001821FD1D0-0x00000001821FD200 
		public static Vector2 positiveInfinity { get; } // 0x00000001821FD1A0-0x00000001821FD1D0 
	
		// Constructors
		public Vector2(float x, float y); // 0x0000000180F37880-0x0000000180F37890
		static Vector2(); // 0x00000001821FCFB0-0x00000001821FD080
	
		// Methods
		public static implicit operator Vector2(float2 v); // 0x00000001821FD380-0x00000001821FD3A0
		public static implicit operator float2(Vector2 v); // 0x00000001821FD380-0x00000001821FD3A0
		public static Vector2 Lerp(Vector2 a, Vector2 b, float t); // 0x00000001821FCA00-0x00000001821FCA60
		public static Vector2 LerpUnclamped(Vector2 a, Vector2 b, float t); // 0x00000001821FC9B0-0x00000001821FCA00
		public static Vector2 Scale(Vector2 a, Vector2 b); // 0x00000001821FCB90-0x00000001821FCBD0
		public static Vector2 Normalize([IsReadOnly] in Vector2 value); // 0x00000001821FCAE0-0x00000001821FCB40
		public void Normalize(); // 0x00000001821FCB40-0x00000001821FCB90
		[IsReadOnly]
		public override string ToString(); // 0x00000001821FCEB0-0x00000001821FCEC0
		[IsReadOnly]
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001821FCEC0-0x00000001821FCFB0
		[IsReadOnly]
		public override int GetHashCode(); // 0x00000001821FC970-0x00000001821FC9B0
		[IsReadOnly]
		public override bool Equals(object other); // 0x00000001821FC8D0-0x00000001821FC940
		[IsReadOnly]
		public bool Equals(Vector2 other); // 0x00000001821FC940-0x00000001821FC970
		[IsReadOnly]
		public bool Equals([IsReadOnly] in Vector2 other); // 0x00000001821FC8B0-0x00000001821FC8D0
		public static float Dot(Vector2 lhs, Vector2 rhs); // 0x00000001821FC860-0x00000001821FC890
		public static float Dot([IsReadOnly] in Vector2 lhs, [IsReadOnly] in Vector2 rhs); // 0x00000001821FC890-0x00000001821FC8B0
		public static float Angle(Vector2 from, Vector2 to); // 0x00000001821FC590-0x00000001821FC6D0
		public static float Distance(Vector2 a, Vector2 b); // 0x00000001821FC7C0-0x00000001821FC860
		public static Vector2 ClampMagnitude(Vector2 vector, float maxLength); // 0x00000001821FC6D0-0x00000001821FC7C0
		public static Vector2 Min(Vector2 lhs, Vector2 rhs); // 0x00000001821FCAA0-0x00000001821FCAE0
		public static Vector2 Max(Vector2 lhs, Vector2 rhs); // 0x00000001821FCA60-0x00000001821FCAA0
		[ExcludeFromDocs]
		public static Vector2 SmoothDamp(Vector2 current, Vector2 target, ref Vector2 currentVelocity, float smoothTime); // 0x00000001821FCE50-0x00000001821FCEB0
		public static Vector2 SmoothDamp([IsReadOnly] in Vector2 current, [IsReadOnly] in Vector2 target, ref Vector2 currentVelocity, float smoothTime, [DefaultValue("Mathf.Infinity")] float maxSpeed, [DefaultValue("Time.deltaTime")] float deltaTime); // 0x00000001821FCBD0-0x00000001821FCE50
		public static Vector2 operator +(Vector2 a, Vector2 b); // 0x00000001821FD250-0x00000001821FD290
		public static Vector2 operator -(Vector2 a, Vector2 b); // 0x00000001821FD450-0x00000001821FD490
		public static Vector2 operator *(Vector2 a, Vector2 b); // 0x00000001821FCB90-0x00000001821FCBD0
		public static Vector2 operator /(Vector2 a, Vector2 b); // 0x00000001821FD2C0-0x00000001821FD300
		public static Vector2 operator -(Vector2 a); // 0x00000001821FD490-0x00000001821FD4C0
		public static Vector2 operator *(Vector2 a, float d); // 0x00000001821FD3F0-0x00000001821FD420
		public static Vector2 operator *(float d, Vector2 a); // 0x00000001821FD420-0x00000001821FD450
		public static Vector2 operator /(Vector2 a, float d); // 0x00000001821FD290-0x00000001821FD2C0
		public static bool operator ==(Vector2 lhs, Vector2 rhs); // 0x00000001821FD300-0x00000001821FD350
		public static bool operator !=(Vector2 lhs, Vector2 rhs); // 0x00000001821FD3A0-0x00000001821FD3F0
		public static implicit operator Vector2(Vector3 v); // 0x0000000181E6F9A0-0x0000000181E6F9C0
		public static implicit operator Vector3(Vector2 v); // 0x00000001821FD350-0x00000001821FD380
	}
}
