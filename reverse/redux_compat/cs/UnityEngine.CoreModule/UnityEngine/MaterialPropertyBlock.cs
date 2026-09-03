/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Shaders/ShaderPropertySheet.h")]
	[NativeHeader("Runtime/Math/SphericalHarmonicsL2.h")]
	[NativeHeader("Runtime/Shaders/ComputeShader.h")]
	[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
	public sealed class MaterialPropertyBlock // TypeDefIndex: 7568
	{
		// Fields
		internal IntPtr m_Ptr; // 0x10
	
		// Nested types
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static class BindingsMarshaller // TypeDefIndex: 7569
		{
			// Methods
			public static IntPtr ConvertToNative(MaterialPropertyBlock materialPropertyBlock); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public MaterialPropertyBlock(); // 0x00000001821A7C30-0x00000001821A7C70
	
		// Methods
		[NativeMethod("SetIntFromScript", IsThreadSafe = true)]
		private void SetIntImpl(int name, int value); // 0x00000001821A6D20-0x00000001821A6D90
		[NativeMethod("SetFloatFromScript", IsThreadSafe = true)]
		private void SetFloatImpl(int name, float value); // 0x00000001821A6BD0-0x00000001821A6C40
		[NativeMethod("SetVectorFromScript", IsThreadSafe = true)]
		private void SetVectorImpl(int name, Vector4 value); // 0x00000001821A7AC0-0x00000001821A7B30
		[NativeMethod("SetColorFromScript", IsThreadSafe = true)]
		private void SetColorImpl(int name, Color value); // 0x00000001821A65D0-0x00000001821A6640
		[NativeMethod("SetMatrixFromScript", IsThreadSafe = true)]
		private void SetMatrixImpl(int name, Matrix4x4 value); // 0x00000001821A7220-0x00000001821A7290
		[NativeMethod("SetTextureFromScript", IsThreadSafe = true)]
		private void SetTextureImpl(int name, [NotNull] Texture value); // 0x00000001821A7550-0x00000001821A7620
		[NativeMethod("SetRenderTextureFromScript", IsThreadSafe = true)]
		private void SetRenderTextureImpl(int name, [NotNull] RenderTexture value, RenderTextureSubElement element); // 0x00000001821A7420-0x00000001821A7500
		[NativeMethod("SetBufferFromScript", IsThreadSafe = true)]
		private void SetBufferImpl(int name, ComputeBuffer value); // 0x00000001821A6460-0x00000001821A64E0
		[NativeMethod("SetConstantBufferFromScript", IsThreadSafe = true)]
		private void SetConstantBufferImpl(int name, ComputeBuffer value, int offset, int size); // 0x00000001821A67A0-0x00000001821A6840
		[NativeMethod("SetFloatArrayFromScript", IsThreadSafe = true)]
		private void SetFloatArrayImpl(int name, float[] values, int count); // 0x00000001821A68A0-0x00000001821A6970
		[NativeMethod("SetVectorArrayFromScript", IsThreadSafe = true)]
		private void SetVectorArrayImpl(int name, Vector4[] values, int count); // 0x00000001821A7760-0x00000001821A7830
		[NativeMethod("SetMatrixArrayFromScript", IsThreadSafe = true)]
		private void SetMatrixArrayImpl(int name, Matrix4x4[] values, int count); // 0x00000001821A6EF0-0x00000001821A6FC0
		[NativeMethod(Name = "MaterialPropertyBlockScripting::Create", IsFreeFunction = true)]
		private static IntPtr CreateImpl(); // 0x00000001821A6220-0x00000001821A6250
		[NativeMethod(Name = "MaterialPropertyBlockScripting::Destroy", IsFreeFunction = true, IsThreadSafe = true)]
		private static void DestroyImpl(IntPtr mpb); // 0x00000001821A6250-0x00000001821A6290
		[NativeMethod(IsThreadSafe = true)]
		private void Clear(bool keepMemory); // 0x00000001821A6160-0x00000001821A61C0
		public void Clear(); // 0x00000001821A61C0-0x00000001821A6220
		private void SetFloatArray(int name, float[] values, int count); // 0x00000001821A6970-0x00000001821A6B30
		private void SetVectorArray(int name, Vector4[] values, int count); // 0x00000001821A7860-0x00000001821A7A20
		private void SetMatrixArray(int name, Matrix4x4[] values, int count); // 0x00000001821A7010-0x00000001821A71D0
		~MaterialPropertyBlock(); // 0x00000001821A6320-0x00000001821A6410
		private void Dispose(); // 0x00000001821A6290-0x00000001821A6320
		public void SetInt(string name, int value); // 0x00000001821A6D90-0x00000001821A6E20
		public void SetInt(int nameID, int value); // 0x00000001821A6E20-0x00000001821A6E90
		public void SetFloat(string name, float value); // 0x00000001821A6C40-0x00000001821A6CD0
		public void SetFloat(int nameID, float value); // 0x00000001821A6BD0-0x00000001821A6C40
		public void SetInteger(int nameID, int value); // 0x00000001821A6D20-0x00000001821A6D90
		public void SetVector(string name, Vector4 value); // 0x00000001821A7BA0-0x00000001821A7C30
		public void SetVector(int nameID, Vector4 value); // 0x00000001821A7B30-0x00000001821A7BA0
		public void SetColor(string name, Color value); // 0x00000001821A66B0-0x00000001821A6740
		public void SetColor(int nameID, Color value); // 0x00000001821A6640-0x00000001821A66B0
		public void SetMatrix(string name, Matrix4x4 value); // 0x00000001821A7320-0x00000001821A73C0
		public void SetMatrix(int nameID, Matrix4x4 value); // 0x00000001821A7290-0x00000001821A7320
		public void SetBuffer(string name, ComputeBuffer value); // 0x00000001821A64E0-0x00000001821A6580
		public void SetBuffer(int nameID, ComputeBuffer value); // 0x00000001821A6460-0x00000001821A64E0
		public void SetTexture(string name, Texture value); // 0x00000001821A7620-0x00000001821A7700
		public void SetTexture(int nameID, Texture value); // 0x00000001821A7550-0x00000001821A7620
		public void SetTexture(int nameID, RenderTexture value, RenderTextureSubElement element); // 0x00000001821A7420-0x00000001821A7500
		public void SetConstantBuffer(int nameID, ComputeBuffer value, int offset, int size); // 0x00000001821A67A0-0x00000001821A6840
		public void SetFloatArray(string name, float[] values); // 0x00000001821A6B30-0x00000001821A6B80
		public void SetVectorArray(string name, Vector4[] values); // 0x00000001821A7A20-0x00000001821A7A70
		public void SetVectorArray(int nameID, Vector4[] values); // 0x00000001821A7830-0x00000001821A7860
		public void SetMatrixArray(string name, Matrix4x4[] values); // 0x00000001821A6FC0-0x00000001821A7010
		private static void SetIntImpl_Injected(IntPtr _unity_self, int name, int value); // 0x00000001821A6CD0-0x00000001821A6D20
		private static void SetFloatImpl_Injected(IntPtr _unity_self, int name, float value); // 0x00000001821A6B80-0x00000001821A6BD0
		private static void SetVectorImpl_Injected(IntPtr _unity_self, int name, in Vector4 value); // 0x00000001821A7A70-0x00000001821A7AC0
		private static void SetColorImpl_Injected(IntPtr _unity_self, int name, in Color value); // 0x00000001821A6580-0x00000001821A65D0
		private static void SetMatrixImpl_Injected(IntPtr _unity_self, int name, in Matrix4x4 value); // 0x00000001821A71D0-0x00000001821A7220
		private static void SetTextureImpl_Injected(IntPtr _unity_self, int name, IntPtr value); // 0x00000001821A7500-0x00000001821A7550
		private static void SetRenderTextureImpl_Injected(IntPtr _unity_self, int name, IntPtr value, RenderTextureSubElement element); // 0x00000001821A73C0-0x00000001821A7420
		private static void SetBufferImpl_Injected(IntPtr _unity_self, int name, IntPtr value); // 0x00000001821A6410-0x00000001821A6460
		private static void SetConstantBufferImpl_Injected(IntPtr _unity_self, int name, IntPtr value, int offset, int size); // 0x00000001821A6740-0x00000001821A67A0
		private static void SetFloatArrayImpl_Injected(IntPtr _unity_self, int name, ref ManagedSpanWrapper values, int count); // 0x00000001821A6840-0x00000001821A68A0
		private static void SetVectorArrayImpl_Injected(IntPtr _unity_self, int name, ref ManagedSpanWrapper values, int count); // 0x00000001821A7700-0x00000001821A7760
		private static void SetMatrixArrayImpl_Injected(IntPtr _unity_self, int name, ref ManagedSpanWrapper values, int count); // 0x00000001821A6E90-0x00000001821A6EF0
		private static void Clear_Injected(IntPtr _unity_self, bool keepMemory); // 0x00000001821A6110-0x00000001821A6160
	}
}
