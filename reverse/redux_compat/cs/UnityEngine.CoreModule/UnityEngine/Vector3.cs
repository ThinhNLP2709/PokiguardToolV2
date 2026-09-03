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
using UnityEngine.Internal;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	[Il2CppEagerStaticClassConstruction]
	[NativeClass("Vector3f")]
	[NativeHeader("Runtime/Math/Vector3.h")]
	[NativeHeader("Runtime/Math/MathScripting.h")]
	[NativeHeader("Runtime/Math/Vector3.h")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	public struct Vector3 : IEquatable<UnityEngine.Vector3>, IFormattable // TypeDefIndex: 7665
	{
		// Fields
		public float x; // 0x00
		public float y; // 0x04
		public float z; // 0x08
		private static readonly Vector3 zeroVector; // 0x00
		private static readonly Vector3 oneVector; // 0x0C
		private static readonly Vector3 upVector; // 0x18
		private static readonly Vector3 downVector; // 0x24
		private static readonly Vector3 leftVector; // 0x30
		private static readonly Vector3 rightVector; // 0x3C
		private static readonly Vector3 forwardVector; // 0x48
		private static readonly Vector3 backVector; // 0x54
		private static readonly Vector3 positiveInfinityVector; // 0x60
		private static readonly Vector3 negativeInfinityVector; // 0x6C
	
		// Properties
		public float this[int index] { [IsReadOnly] get => default; set {} } // 0x00000001806CAE90-0x00000001806CAF20 0x00000001821E0580-0x00000001821E0F00
		public Vector3 normalized { [IsReadOnly] get; } // 0x00000001821E0360-0x00000001821E03D0 
		public float magnitude { [IsReadOnly] get; } // 0x00000001821E02C0-0x00000001821E0360 
		public float sqrMagnitude { [IsReadOnly] get; } // 0x00000001821DFF20-0x00000001821DFF50 
		public static Vector3 zero { get; } // 0x000000018215C3E0-0x000000018215C400 
		public static Vector3 one { get; } // 0x00000001821E03D0-0x00000001821E0400 
		public static Vector3 forward { get; } // 0x00000001821E0260-0x00000001821E0290 
		public static Vector3 back { get; } // 0x00000001821E0200-0x00000001821E0230 
		public static Vector3 up { get; } // 0x00000001821E0430-0x00000001821E0460 
		public static Vector3 down { get; } // 0x00000001821E0230-0x00000001821E0260 
		public static Vector3 left { get; } // 0x00000001821E0290-0x00000001821E02C0 
		public static Vector3 right { get; } // 0x00000001821E0400-0x00000001821E0430 
	
		// Constructors
		public Vector3(float x, float y, float z); // 0x00000001821E01D0-0x00000001821E01E0
		public Vector3(float x, float y); // 0x00000001821E01E0-0x00000001821E0200
		static Vector3(); // 0x00000001821E0080-0x00000001821E01D0
	
		// Methods
		public static implicit operator Vector3(float3 v); // 0x0000000181DF5340-0x0000000181DF5360
		public static implicit operator float3(Vector3 v); // 0x0000000181DF5340-0x0000000181DF5360
		public static Vector3 Lerp(Vector3 a, Vector3 b, float t); // 0x00000001821DF7B0-0x00000001821DF810
		public static Vector3 LerpUnclamped(Vector3 a, Vector3 b, float t); // 0x00000001821DF760-0x00000001821DF7B0
		[ExcludeFromDocs]
		public static Vector3 SmoothDamp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime); // 0x00000001821DFE90-0x00000001821DFF20
		public static Vector3 SmoothDamp([IsReadOnly] in Vector3 current, [IsReadOnly] in Vector3 target, ref Vector3 currentVelocity, float smoothTime, [DefaultValue("Mathf.Infinity")] float maxSpeed, [DefaultValue("Time.deltaTime")] float deltaTime); // 0x00000001821DFB40-0x00000001821DFE90
		public static Vector3 Scale(Vector3 a, Vector3 b); // 0x00000001821DFA50-0x00000001821DFA90
		public static Vector3 Cross(Vector3 lhs, Vector3 rhs); // 0x00000001821DF5B0-0x00000001821DF610
		public static Vector3 Cross([IsReadOnly] in Vector3 lhs, [IsReadOnly] in Vector3 rhs); // 0x00000001821DF5B0-0x00000001821DF610
		[IsReadOnly]
		public override int GetHashCode(); // 0x00000001821DF700-0x00000001821DF760
		[IsReadOnly]
		public override bool Equals(object other); // 0x000000018074E260-0x000000018074E2E0
		[IsReadOnly]
		public bool Equals(Vector3 other); // 0x00000001820F4340-0x00000001820F4370
		[IsReadOnly]
		public bool Equals([IsReadOnly] in Vector3 other); // 0x00000001820F4340-0x00000001820F4370
		public static Vector3 Normalize(Vector3 value); // 0x00000001821DF890-0x00000001821DF920
		public static Vector3 Normalize([IsReadOnly] in Vector3 value); // 0x00000001821DF890-0x00000001821DF920
		public void Normalize(); // 0x00000001821DF920-0x00000001821DF980
		public static float Dot(Vector3 lhs, Vector3 rhs); // 0x00000001821DF6D0-0x00000001821DF700
		public static float Dot([IsReadOnly] in Vector3 lhs, [IsReadOnly] in Vector3 rhs); // 0x00000001821DF6D0-0x00000001821DF700
		public static Vector3 ProjectOnPlane(Vector3 vector, Vector3 planeNormal); // 0x00000001821DF980-0x00000001821DFA50
		public static float Angle([IsReadOnly] in Vector3 from, [IsReadOnly] in Vector3 to); // 0x00000001821DF360-0x00000001821DF4A0
		public static float SignedAngle(Vector3 from, Vector3 to, Vector3 axis); // 0x00000001821DFA90-0x00000001821DFB40
		public static float Distance(Vector3 a, Vector3 b); // 0x00000001821DF610-0x00000001821DF6D0
		public static Vector3 ClampMagnitude(Vector3 vector, float maxLength); // 0x00000001821DF4A0-0x00000001821DF5B0
		public static float SqrMagnitude(Vector3 vector); // 0x00000001821DFF20-0x00000001821DFF50
		public static Vector3 Min(Vector3 lhs, Vector3 rhs); // 0x00000001821DF850-0x00000001821DF890
		public static Vector3 Min([IsReadOnly] in Vector3 lhs, [IsReadOnly] in Vector3 rhs); // 0x00000001821DF850-0x00000001821DF890
		public static Vector3 Max(Vector3 lhs, Vector3 rhs); // 0x00000001821DF810-0x00000001821DF850
		public static Vector3 Max([IsReadOnly] in Vector3 lhs, [IsReadOnly] in Vector3 rhs); // 0x00000001821DF810-0x00000001821DF850
		public static Vector3 operator +(Vector3 a, Vector3 b); // 0x00000001803A7CD0-0x00000001803A7D10
		public static Vector3 operator -(Vector3 a, Vector3 b); // 0x00000001805C0670-0x00000001805C06B0
		public static Vector3 operator -(Vector3 a); // 0x00000001821E0540-0x00000001821E0580
		public static Vector3 operator *(Vector3 a, float d); // 0x00000001821E0510-0x00000001821E0540
		public static Vector3 operator *(float d, Vector3 a); // 0x00000001821E04E0-0x00000001821E0510
		public static Vector3 operator /(Vector3 a, float d); // 0x0000000180313B10-0x0000000180313B40
		public static bool operator ==(Vector3 lhs, Vector3 rhs); // 0x00000001821E0460-0x00000001821E04A0
		public static bool operator !=(Vector3 lhs, Vector3 rhs); // 0x00000001821E04A0-0x00000001821E04E0
		[IsReadOnly]
		public override string ToString(); // 0x00000001821DFF50-0x00000001821DFF60
		[IsReadOnly]
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001821DFF60-0x00000001821E0080
	}
}
