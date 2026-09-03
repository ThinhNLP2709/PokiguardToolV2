/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public static class CoreMatrixUtils // TypeDefIndex: 5747
	{
		// Methods
		public static void MatrixTimesTranslation(ref Matrix4x4 inOutMatrix, Vector3 translation); // 0x0000000181EACA40-0x0000000181EACAD0
		public static void TranslationTimesMatrix(ref Matrix4x4 inOutMatrix, Vector3 translation); // 0x0000000181EAD5A0-0x0000000181EAD690
		public static Matrix4x4 MultiplyPerspectiveMatrix(Matrix4x4 perspective, Matrix4x4 rhs); // 0x0000000181EAD0B0-0x0000000181EAD200
		private static Matrix4x4 MultiplyOrthoMatrixCentered(Matrix4x4 ortho, Matrix4x4 rhs); // 0x0000000181EACC80-0x0000000181EACDC0
		private static Matrix4x4 MultiplyGenericOrthoMatrix(Matrix4x4 ortho, Matrix4x4 rhs); // 0x0000000181EACAD0-0x0000000181EACC80
		public static Matrix4x4 MultiplyOrthoMatrix(Matrix4x4 ortho, Matrix4x4 rhs, bool centered); // 0x0000000181EACDC0-0x0000000181EAD0B0
		public static Matrix4x4 MultiplyProjectionMatrix(Matrix4x4 projMatrix, Matrix4x4 rhs, bool orthoCentered); // 0x0000000181EAD200-0x0000000181EAD5A0
		public static Vector3 GetWorldPositionFromOrthonormalViewMatrix([IsReadOnly] in Matrix4x4 viewMatrix); // 0x0000000181EAC9A0-0x0000000181EACA40
	}
}
