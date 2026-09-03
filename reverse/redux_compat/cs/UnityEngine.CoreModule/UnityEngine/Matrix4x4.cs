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
	[NativeClass("Matrix4x4f")]
	[NativeHeader("Runtime/Math/Matrix4x4.h")]
	[NativeHeader("Runtime/Math/MathScripting.h")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	public struct Matrix4x4 : IEquatable<UnityEngine.Matrix4x4>, IFormattable // TypeDefIndex: 7664
	{
		// Fields
		[NativeName("m_Data[0]")]
		public float m00; // 0x00
		[NativeName("m_Data[1]")]
		public float m10; // 0x04
		[NativeName("m_Data[2]")]
		public float m20; // 0x08
		[NativeName("m_Data[3]")]
		public float m30; // 0x0C
		[NativeName("m_Data[4]")]
		public float m01; // 0x10
		[NativeName("m_Data[5]")]
		public float m11; // 0x14
		[NativeName("m_Data[6]")]
		public float m21; // 0x18
		[NativeName("m_Data[7]")]
		public float m31; // 0x1C
		[NativeName("m_Data[8]")]
		public float m02; // 0x20
		[NativeName("m_Data[9]")]
		public float m12; // 0x24
		[NativeName("m_Data[10]")]
		public float m22; // 0x28
		[NativeName("m_Data[11]")]
		public float m32; // 0x2C
		[NativeName("m_Data[12]")]
		public float m03; // 0x30
		[NativeName("m_Data[13]")]
		public float m13; // 0x34
		[NativeName("m_Data[14]")]
		public float m23; // 0x38
		[NativeName("m_Data[15]")]
		public float m33; // 0x3C
		private static readonly Matrix4x4 zeroMatrix; // 0x00
		private static readonly Matrix4x4 identityMatrix; // 0x40
	
		// Properties
		public Quaternion rotation { [IsReadOnly] get; } // 0x00000001821CF8C0-0x00000001821CF920 
		public Vector3 lossyScale { [IsReadOnly] get; } // 0x00000001821CF850-0x00000001821CF8C0 
		public float determinant { [IsReadOnly] get; } // 0x00000001821CE0D0-0x00000001821CE110 
		public FrustumPlanes decomposeProjection { [IsReadOnly] get; } // 0x00000001821CF7A0-0x00000001821CF810 
		public Matrix4x4 inverse { [IsReadOnly] get; } // 0x00000001821CE7B0-0x00000001821CE840 
		public Matrix4x4 transpose { [IsReadOnly] get; } // 0x00000001821CF920-0x00000001821CF9B0 
		public float this[int row, int column] { [IsReadOnly] get => default; set {} } // 0x00000001806E4040-0x00000001806E41A0 0x00000001821CFC50-0x00000001821CFC60
		public float this[int index] { [IsReadOnly] get => default; set {} } // 0x00000001806E3EE0-0x00000001806E4040 0x0000000181DEA7E0-0x0000000181DEAAA0
		public static Matrix4x4 zero { get; } // 0x00000001821CF9B0-0x00000001821CF9E0 
		public static Matrix4x4 identity { get; } // 0x00000001821CF810-0x00000001821CF850 
	
		// Constructors
		public Matrix4x4(Vector4 column0, Vector4 column1, Vector4 column2, Vector4 column3); // 0x00000001821CF730-0x00000001821CF7A0
		static Matrix4x4(); // 0x00000001821CF630-0x00000001821CF730
	
		// Methods
		[IsReadOnly]
		[NativeMethod(IsThreadSafe = true)]
		private Quaternion GetRotation(); // 0x00000001821CE220-0x00000001821CE270
		[IsReadOnly]
		[NativeMethod(IsThreadSafe = true)]
		private Vector3 GetLossyScale(); // 0x00000001821CE160-0x00000001821CE1B0
		[IsReadOnly]
		[NativeMethod(IsThreadSafe = true)]
		private float GetDeterminant(); // 0x00000001821CE0D0-0x00000001821CE110
		[IsReadOnly]
		[NativeMethod(IsThreadSafe = true)]
		private FrustumPlanes DecomposeProjection(); // 0x00000001821CDD00-0x00000001821CDD60
		[FreeFunction("MatrixScripting::TRS", IsThreadSafe = true)]
		private static Matrix4x4 Internal_TRS([IsReadOnly] in Vector3 pos, [IsReadOnly] in Quaternion q, [IsReadOnly] in Vector3 s); // 0x00000001821CE630-0x00000001821CE6B0
		public static Matrix4x4 TRS(Vector3 pos, Quaternion q, Vector3 s); // 0x00000001821CEE50-0x00000001821CEEF0
		[FreeFunction("MatrixScripting::SetTRS", IsThreadSafe = true)]
		private static void Internal_SetTRS(ref Matrix4x4 m, [IsReadOnly] in Vector3 pos, [IsReadOnly] in Quaternion q, [IsReadOnly] in Vector3 s); // 0x00000001821CE550-0x00000001821CE5C0
		public void SetTRS(Vector3 pos, Quaternion q, Vector3 s); // 0x00000001821CEDE0-0x00000001821CEE50
		[FreeFunction("MatrixScripting::Inverse3DAffine", IsThreadSafe = true)]
		private static bool Internal_Inverse3DAffine([IsReadOnly] in Matrix4x4 input, ref Matrix4x4 result); // 0x00000001821CE360-0x00000001821CE3B0
		public static bool Inverse3DAffine(Matrix4x4 input, ref Matrix4x4 result); // 0x00000001821CE760-0x00000001821CE7B0
		public static bool Inverse3DAffine([IsReadOnly] in Matrix4x4 input, ref Matrix4x4 result); // 0x00000001821CE360-0x00000001821CE3B0
		[FreeFunction("MatrixScripting::Inverse", IsThreadSafe = true)]
		private static Matrix4x4 Internal_Inverse([IsReadOnly] in Matrix4x4 m); // 0x00000001821CE400-0x00000001821CE460
		public static Matrix4x4 Inverse(Matrix4x4 m); // 0x00000001821CE7B0-0x00000001821CE840
		[FreeFunction("MatrixScripting::Transpose", IsThreadSafe = true)]
		private static Matrix4x4 Internal_Transpose([IsReadOnly] in Matrix4x4 m); // 0x00000001821CE700-0x00000001821CE760
		[FreeFunction("MatrixScripting::Ortho", IsThreadSafe = true)]
		public static Matrix4x4 Ortho(float left, float right, float bottom, float top, float zNear, float zFar); // 0x00000001821CEAF0-0x00000001821CEBA0
		[FreeFunction("MatrixScripting::Perspective", IsThreadSafe = true)]
		public static Matrix4x4 Perspective(float fov, float aspect, float zNear, float zFar); // 0x00000001821CEC20-0x00000001821CECB0
		[FreeFunction("MatrixScripting::LookAt", IsThreadSafe = true)]
		private static Matrix4x4 Internal_LookAt([IsReadOnly] in Vector3 from, [IsReadOnly] in Vector3 to, [IsReadOnly] in Vector3 up); // 0x00000001821CE4D0-0x00000001821CE550
		public static Matrix4x4 LookAt(Vector3 from, Vector3 to, Vector3 up); // 0x00000001821CE840-0x00000001821CE8E0
		[FreeFunction("MatrixScripting::Frustum", IsThreadSafe = true)]
		public static Matrix4x4 Frustum(float left, float right, float bottom, float top, float zNear, float zFar); // 0x00000001821CDF30-0x00000001821CDFE0
		public static Matrix4x4 Frustum(FrustumPlanes fp); // 0x00000001821CDE60-0x00000001821CDF30
		public static implicit operator float4x4(Matrix4x4 m); // 0x00000001821CF9E0-0x00000001821CFA30
		public static implicit operator Matrix4x4(float4x4 m); // 0x00000001821CFA30-0x00000001821CFAE0
		[IsReadOnly]
		public override int GetHashCode(); // 0x0000000180C58C30-0x0000000180C59E10
		[IsReadOnly]
		public override bool Equals(object other); // 0x00000001821CDD60-0x00000001821CDDE0
		[IsReadOnly]
		public bool Equals(Matrix4x4 other); // 0x000000018075F830-0x000000018075F930
		[IsReadOnly]
		public bool Equals([IsReadOnly] in Matrix4x4 other); // 0x000000018075F830-0x000000018075F930
		public static Matrix4x4 operator *(Matrix4x4 lhs, Matrix4x4 rhs); // 0x0000000181E1C5D0-0x0000000181E1D470
		public static Vector4 operator *(Matrix4x4 lhs, Vector4 vector); // 0x00000001821CFB50-0x00000001821CFC50
		public static bool operator ==(Matrix4x4 lhs, Matrix4x4 rhs); // 0x0000000181C40150-0x0000000181C405B0
		public static bool operator !=(Matrix4x4 lhs, Matrix4x4 rhs); // 0x00000001821CFAE0-0x00000001821CFB50
		[IsReadOnly]
		public Vector4 GetColumn(int index); // 0x00000001821CDFE0-0x00000001821CE0D0
		[IsReadOnly]
		public Vector4 GetRow(int index); // 0x00000001821CE270-0x00000001821CE360
		[IsReadOnly]
		public Vector3 GetPosition(); // 0x00000001821CE1B0-0x00000001821CE1D0
		public void SetColumn(int index, Vector4 column); // 0x00000001821CECF0-0x00000001821CED70
		public void SetRow(int index, Vector4 row); // 0x00000001821CED70-0x00000001821CEDE0
		[IsReadOnly]
		public Vector3 MultiplyPoint(Vector3 point); // 0x00000001821CE8E0-0x00000001821CE9E0
		[IsReadOnly]
		public Vector3 MultiplyPoint3x4(Vector3 point); // 0x00000001805E9F10-0x00000001805EA140
		[IsReadOnly]
		public Vector3 MultiplyVector(Vector3 vector); // 0x00000001821CE9E0-0x00000001821CEA70
		public static Matrix4x4 Scale(Vector3 vector); // 0x00000001821CECB0-0x00000001821CECF0
		public static Matrix4x4 Translate(Vector3 vector); // 0x00000001821CF5E0-0x00000001821CF630
		public static Matrix4x4 Rotate(Quaternion q); // 0x00000001820D2340-0x00000001820D2490
		[IsReadOnly]
		public override string ToString(); // 0x00000001821CEEF0-0x00000001821CEF00
		[IsReadOnly]
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001821CEF00-0x00000001821CF5E0
		private static void GetRotation_Injected(ref Matrix4x4 _unity_self, ); // 0x00000001821CE1D0-0x00000001821CE220
		private static void GetLossyScale_Injected(ref Matrix4x4 _unity_self, ); // 0x00000001821CE110-0x00000001821CE160
		private static void DecomposeProjection_Injected(ref Matrix4x4 _unity_self, ); // 0x00000001821CDCB0-0x00000001821CDD00
		private static void Internal_TRS_Injected([IsReadOnly] in Vector3 pos, [IsReadOnly] in Quaternion q, [IsReadOnly] in Vector3 s, ); // 0x00000001821CE5C0-0x00000001821CE630
		private static void Internal_Inverse_Injected([IsReadOnly] in Matrix4x4 m, ); // 0x00000001821CE3B0-0x00000001821CE400
		private static void Internal_Transpose_Injected([IsReadOnly] in Matrix4x4 m, ); // 0x00000001821CE6B0-0x00000001821CE700
		private static void Ortho_Injected(float left, float right, float bottom, float top, float zNear, float zFar, ); // 0x00000001821CEA70-0x00000001821CEAF0
		private static void Perspective_Injected(float fov, float aspect, float zNear, float zFar, ); // 0x00000001821CEBA0-0x00000001821CEC20
		private static void Internal_LookAt_Injected([IsReadOnly] in Vector3 from, [IsReadOnly] in Vector3 to, [IsReadOnly] in Vector3 up, ); // 0x00000001821CE460-0x00000001821CE4D0
		private static void Frustum_Injected(float left, float right, float bottom, float top, float zNear, float zFar, ); // 0x00000001821CDDE0-0x00000001821CDE60
	}
}
