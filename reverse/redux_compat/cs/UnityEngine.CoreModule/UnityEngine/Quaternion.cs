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
	[DefaultMember("Item")]
	[Il2CppEagerStaticClassConstruction]
	[NativeHeader("Runtime/Math/Quaternion.h")]
	[NativeHeader("Runtime/Math/MathScripting.h")]
	[UsedByNativeCode]
	public struct Quaternion : IEquatable<UnityEngine.Quaternion>, IFormattable // TypeDefIndex: 7666
	{
		// Fields
		public float x; // 0x00
		public float y; // 0x04
		public float z; // 0x08
		public float w; // 0x0C
		private static readonly Quaternion identityQuaternion; // 0x00
	
		// Properties
		public static Quaternion identity { get; } // 0x000000018215C140-0x000000018215C160 
		public Vector3 eulerAngles { [IsReadOnly] get; } // 0x00000001821F77C0-0x00000001821F78D0 
		public Quaternion normalized { [IsReadOnly] get; } // 0x00000001821F7370-0x00000001821F7430 
	
		// Constructors
		public Quaternion(float x, float y, float z, float w); // 0x0000000182082140-0x0000000182082160
		static Quaternion(); // 0x00000001821F77A0-0x00000001821F77C0
	
		// Methods
		[FreeFunction("FromToQuaternionSafe", IsThreadSafe = true)]
		private static Quaternion Internal_FromToRotation([IsReadOnly] in Vector3 fromDirection, [IsReadOnly] in Vector3 toDirection); // 0x00000001821F6C70-0x00000001821F6CD0
		public static Quaternion FromToRotation(Vector3 fromDirection, Vector3 toDirection); // 0x00000001821F6A40-0x00000001821F6AB0
		[FreeFunction("QuaternionScripting::Inverse", IsThreadSafe = true)]
		private static Quaternion Internal_Inverse([IsReadOnly] in Quaternion rotation); // 0x00000001821F6D20-0x00000001821F6D70
		public static Quaternion Inverse(Quaternion rotation); // 0x00000001821F7180-0x00000001821F71E0
		[FreeFunction("QuaternionScripting::Slerp", IsThreadSafe = true)]
		private static Quaternion Internal_Slerp([IsReadOnly] in Quaternion a, [IsReadOnly] in Quaternion b, float t); // 0x00000001821F7010-0x00000001821F7080
		[FreeFunction("QuaternionScripting::Lerp", IsThreadSafe = true)]
		private static Quaternion Internal_Lerp([IsReadOnly] in Quaternion a, [IsReadOnly] in Quaternion b, float t); // 0x00000001821F6DE0-0x00000001821F6E50
		public static Quaternion Slerp(Quaternion a, Quaternion b, float t); // 0x00000001821F7430-0x00000001821F74B0
		public static Quaternion Lerp(Quaternion a, Quaternion b, float t); // 0x00000001821F71F0-0x00000001821F7270
		[FreeFunction("EulerToQuaternion", IsThreadSafe = true)]
		private static Quaternion Internal_FromEulerRad([IsReadOnly] in Vector3 euler); // 0x00000001821F6BC0-0x00000001821F6C10
		[FreeFunction("QuaternionScripting::ToEuler", IsThreadSafe = true)]
		private static Vector3 Internal_ToEulerRad([IsReadOnly] in Quaternion rotation); // 0x00000001821F7130-0x00000001821F7180
		[FreeFunction("QuaternionScripting::ToAxisAngle", IsThreadSafe = true)]
		private static void Internal_ToAxisAngleRad([IsReadOnly] in Quaternion q, out Vector3 axis, out float angle); // 0x00000001821F7080-0x00000001821F70E0
		[FreeFunction("QuaternionScripting::AngleAxis", IsThreadSafe = true)]
		private static Quaternion Internal_AngleAxis(float angle, [IsReadOnly] in Vector3 axis); // 0x00000001821F6B10-0x00000001821F6B70
		public static Quaternion AngleAxis(float angle, Vector3 axis); // 0x00000001821F6880-0x00000001821F68F0
		[FreeFunction("QuaternionScripting::LookRotation", IsThreadSafe = true)]
		private static Quaternion Internal_LookRotation([IsReadOnly] in Vector3 forward, [DefaultValue("Vector3.up")] [IsReadOnly] in Vector3 upwards); // 0x00000001821F6EB0-0x00000001821F6F10
		public static Quaternion LookRotation(Vector3 forward, [DefaultValue("Vector3.up")] Vector3 upwards); // 0x00000001821F7300-0x00000001821F7370
		[ExcludeFromDocs]
		public static Quaternion LookRotation(Vector3 forward); // 0x00000001821F7270-0x00000001821F7300
		public static implicit operator quaternion(Quaternion q); // 0x00000001821C85F0-0x00000001821C8610
		public static Quaternion operator *(Quaternion lhs, Quaternion rhs); // 0x00000001821F78D0-0x00000001821F79C0
		public static Vector3 operator *(Quaternion rotation, Vector3 point); // 0x00000001821F79C0-0x00000001821F7B30
		public static bool operator !=(Quaternion lhs, Quaternion rhs); // 0x0000000181DA8C60-0x0000000181DA9720
		private static bool IsEqualUsingDot(float dot); // 0x00000001821F71E0-0x00000001821F71F0
		public static float Dot([IsReadOnly] in Quaternion a, [IsReadOnly] in Quaternion b); // 0x00000001821F68F0-0x00000001821F6930
		private static Vector3 Internal_MakePositive(Vector3 euler); // 0x00000001821F6F10-0x00000001821F6FA0
		public static Quaternion Euler(float x, float y, float z); // 0x00000001821F69C0-0x00000001821F6A40
		public static Quaternion Euler(Vector3 euler); // 0x00000001821F6930-0x00000001821F69C0
		public void ToAngleAxis(out float angle, out Vector3 axis); // 0x00000001821F74B0-0x00000001821F7520
		public static Quaternion Normalize([IsReadOnly] in Quaternion q); // 0x00000001821F7370-0x00000001821F7430
		[IsReadOnly]
		public override int GetHashCode(); // 0x00000001808BE1A0-0x00000001808BE210
		[IsReadOnly]
		public override bool Equals(object other); // 0x0000000180765AC0-0x0000000180765EC0
		[IsReadOnly]
		public bool Equals(Quaternion other); // 0x0000000182192DA0-0x0000000182192E20
		[IsReadOnly]
		public bool Equals([IsReadOnly] in Quaternion other); // 0x0000000182192DA0-0x0000000182192E20
		[IsReadOnly]
		public override string ToString(); // 0x00000001821F7790-0x00000001821F77A0
		[IsReadOnly]
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001821F7520-0x00000001821F7790
		private static void Internal_FromToRotation_Injected([IsReadOnly] in Vector3 fromDirection, [IsReadOnly] in Vector3 toDirection, ); // 0x00000001821F6C10-0x00000001821F6C70
		private static void Internal_Inverse_Injected([IsReadOnly] in Quaternion rotation, ); // 0x00000001821F6CD0-0x00000001821F6D20
		private static void Internal_Slerp_Injected([IsReadOnly] in Quaternion a, [IsReadOnly] in Quaternion b, float t, ); // 0x00000001821F6FA0-0x00000001821F7010
		private static void Internal_Lerp_Injected([IsReadOnly] in Quaternion a, [IsReadOnly] in Quaternion b, float t, ); // 0x00000001821F6D70-0x00000001821F6DE0
		private static void Internal_FromEulerRad_Injected([IsReadOnly] in Vector3 euler, ); // 0x00000001821F6B70-0x00000001821F6BC0
		private static void Internal_ToEulerRad_Injected([IsReadOnly] in Quaternion rotation, ); // 0x00000001821F70E0-0x00000001821F7130
		private static void Internal_AngleAxis_Injected(float angle, [IsReadOnly] in Vector3 axis, ); // 0x00000001821F6AB0-0x00000001821F6B10
		private static void Internal_LookRotation_Injected([IsReadOnly] in Vector3 forward, [IsReadOnly] [DefaultValue("Vector3.up")] in Vector3 upwards, ); // 0x00000001821F6E50-0x00000001821F6EB0
	}
}
