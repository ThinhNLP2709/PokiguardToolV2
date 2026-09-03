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
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("ComputeShader", PersistentTypeId = 72)]
	[NativeHeader("Runtime/Graphics/RayTracing/RayTracingAccelerationStructure.h")]
	[NativeHeader("Runtime/Graphics/ShaderScriptBindings.h")]
	[NativeHeader("Runtime/Shaders/ComputeShader.h")]
	[UsedByNativeCode]
	public sealed class ComputeShader : Object // TypeDefIndex: 7817
	{
		// Properties
		public LocalKeywordSpace keywordSpace { get; } // 0x0000000182203660-0x00000001822036D0 
		public string[] shaderKeywords { set; } // 0x0000000182203560-0x00000001822035C0
	
		// Constructors
		private ComputeShader(); // 0x00000001822035C0-0x0000000182203610
	
		// Methods
		[NativeMethod(Name = "ComputeShaderScripting::FindKernel", HasExplicitThis = true, IsFreeFunction = true, ThrowsException = true)]
		[RequiredByNativeCode]
		public int FindKernel(string name); // 0x0000000182202A00-0x0000000182202B80
		[FreeFunction(Name = "ComputeShaderScripting::HasKernel", HasExplicitThis = true)]
		public bool HasKernel(string name); // 0x0000000182202CB0-0x0000000182202E30
		[FreeFunction(Name = "ComputeShaderScripting::SetValue<int>", HasExplicitThis = true)]
		public void SetInt(int nameID, int val); // 0x0000000182203350-0x00000001822033C0
		[FreeFunction(Name = "ComputeShaderScripting::SetArray<int>", HasExplicitThis = true)]
		private void SetIntArray(int nameID, int[] values); // 0x0000000182203240-0x0000000182203300
		[FreeFunction(Name = "ComputeShaderScripting::SetBuffer", HasExplicitThis = true)]
		private void Internal_SetBuffer(int kernelIndex, int nameID, [NotNull] ComputeBuffer buffer); // 0x0000000182202E90-0x0000000182202F70
		[FreeFunction(Name = "ComputeShaderScripting::SetBuffer", HasExplicitThis = true)]
		private void Internal_SetGraphicsBuffer(int kernelIndex, int nameID, [NotNull] GraphicsBuffer buffer); // 0x0000000182202FD0-0x00000001822030B0
		public void SetBuffer(int kernelIndex, int nameID, ComputeBuffer buffer); // 0x0000000182202E90-0x0000000182202F70
		public void SetBuffer(int kernelIndex, int nameID, GraphicsBuffer buffer); // 0x0000000182202FD0-0x00000001822030B0
		[FreeFunction(Name = "ComputeShaderScripting::SetConstantBuffer", HasExplicitThis = true)]
		private void SetConstantComputeBuffer(int nameID, [NotNull] ComputeBuffer buffer, int offset, int size); // 0x00000001822030B0-0x0000000182203190
		[NativeMethod(Name = "ComputeShaderScripting::GetKernelThreadGroupSizes", HasExplicitThis = true, IsFreeFunction = true, ThrowsException = true)]
		public void GetKernelThreadGroupSizes(int kernelIndex, out uint x, out uint y, out uint z); // 0x0000000182202BE0-0x0000000182202C60
		[NativeName("DispatchComputeShader")]
		public void Dispatch(int kernelIndex, int threadGroupsX, int threadGroupsY, int threadGroupsZ); // 0x0000000182202770-0x00000001822027F0
		[FreeFunction("ComputeShaderScripting::EnableKeyword", HasExplicitThis = true)]
		public void EnableKeyword(string keyword); // 0x0000000182202840-0x00000001822029B0
		[FreeFunction("ComputeShaderScripting::DisableKeyword", HasExplicitThis = true)]
		public void DisableKeyword(string keyword); // 0x00000001822025A0-0x0000000182202710
		[FreeFunction("ComputeShaderScripting::SetKeyword", HasExplicitThis = true)]
		private void SetLocalKeyword(LocalKeyword keyword, bool value); // 0x00000001822034A0-0x0000000182203510
		public void SetKeyword([IsReadOnly] in LocalKeyword keyword, bool value); // 0x00000001822033C0-0x0000000182203440
		[FreeFunction("ComputeShaderScripting::SetShaderKeywords", HasExplicitThis = true)]
		private void SetShaderKeywords(string[] names); // 0x0000000182203560-0x00000001822035C0
		public void SetInts(int nameID, params int[] values); // 0x0000000182203240-0x0000000182203300
		public void SetConstantBuffer(int nameID, ComputeBuffer buffer, int offset, int size); // 0x00000001822030B0-0x0000000182203190
		private static int FindKernel_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name); // 0x00000001822029B0-0x0000000182202A00
		private static bool HasKernel_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name); // 0x0000000182202C60-0x0000000182202CB0
		private static void SetInt_Injected(IntPtr _unity_self, int nameID, int val); // 0x0000000182203300-0x0000000182203350
		private static void SetIntArray_Injected(IntPtr _unity_self, int nameID, ref ManagedSpanWrapper values); // 0x00000001822031F0-0x0000000182203240
		private static void Internal_SetBuffer_Injected(IntPtr _unity_self, int kernelIndex, int nameID, IntPtr buffer); // 0x0000000182202E30-0x0000000182202E90
		private static void Internal_SetGraphicsBuffer_Injected(IntPtr _unity_self, int kernelIndex, int nameID, IntPtr buffer); // 0x0000000182202F70-0x0000000182202FD0
		private static void SetConstantComputeBuffer_Injected(IntPtr _unity_self, int nameID, IntPtr buffer, int offset, int size); // 0x0000000182203190-0x00000001822031F0
		private static void GetKernelThreadGroupSizes_Injected(IntPtr _unity_self, int kernelIndex, out uint x, out uint y, out uint z); // 0x0000000182202B80-0x0000000182202BE0
		private static void Dispatch_Injected(IntPtr _unity_self, int kernelIndex, int threadGroupsX, int threadGroupsY, int threadGroupsZ); // 0x0000000182202710-0x0000000182202770
		private static void get_keywordSpace_Injected(IntPtr _unity_self, ); // 0x0000000182203610-0x0000000182203660
		private static void EnableKeyword_Injected(IntPtr _unity_self, ref ManagedSpanWrapper keyword); // 0x00000001822027F0-0x0000000182202840
		private static void DisableKeyword_Injected(IntPtr _unity_self, ref ManagedSpanWrapper keyword); // 0x0000000182202550-0x00000001822025A0
		private static void SetLocalKeyword_Injected(IntPtr _unity_self, in LocalKeyword keyword, bool value); // 0x0000000182203440-0x00000001822034A0
		private static void SetShaderKeywords_Injected(IntPtr _unity_self, string[] names); // 0x0000000182203510-0x0000000182203560
	}
}
