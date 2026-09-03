/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("GraphicsBuffer")]
	[NativeHeader("Runtime/Export/Graphics/GraphicsBuffer.bindings.h")]
	[NativeHeader("Runtime/Shaders/GraphicsBuffer.h")]
	[UsedByNativeCode]
	public sealed class ComputeBuffer : IDisposable // TypeDefIndex: 7815
	{
		// Fields
		internal IntPtr m_Ptr; // 0x10
	
		// Properties
		public int count { get; } // 0x0000000182202450-0x00000001822024B0 
		public int stride { get; } // 0x00000001822024F0-0x0000000182202550 
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 7816
		{
			// Methods
			public static IntPtr ConvertToNative(ComputeBuffer computeBuffer); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public ComputeBuffer(int count, int stride); // 0x00000001822023E0-0x0000000182202410
		public ComputeBuffer(int count, int stride, ComputeBufferType type); // 0x0000000182202180-0x00000001822021B0
		public ComputeBuffer(int count, int stride, ComputeBufferType type, ComputeBufferMode usage); // 0x00000001822021B0-0x00000001822021E0
		private ComputeBuffer(int count, int stride, ComputeBufferType type, ComputeBufferMode usage, int stackDepth); // 0x00000001822021E0-0x00000001822023E0
	
		// Methods
		~ComputeBuffer(); // 0x00000001822017C0-0x0000000182201880
		public void Dispose(); // 0x0000000182201640-0x0000000182201700
		private void Dispose(bool disposing); // 0x0000000182201700-0x00000001822017C0
		[FreeFunction("GraphicsBuffer_Bindings::InitComputeBuffer")]
		private static IntPtr InitBuffer(int count, int stride, ComputeBufferType type, ComputeBufferMode usage); // 0x0000000182201AB0-0x0000000182201B10
		[FreeFunction("GraphicsBuffer_Bindings::DestroyComputeBuffer")]
		private static void DestroyBuffer(ComputeBuffer buf); // 0x0000000182201600-0x0000000182201640
		public void Release(); // 0x0000000182201640-0x0000000182201700
		[FreeFunction("GraphicsBuffer_Bindings::IsValidBuffer")]
		private static bool IsValidBuffer(ComputeBuffer buf); // 0x0000000182201EC0-0x0000000182201F00
		public bool IsValid(); // 0x0000000182201F00-0x0000000182201F50
		public void SetData(Array data); // 0x0000000182201F50-0x0000000182202180
		public void SetData<T>(NativeArray<T> data)
			where T : struct;
		public void SetData<T>(NativeArray<T> data, int nativeBufferStartIndex, int computeBufferStartIndex, int count)
			where T : struct;
		[FreeFunction(Name = "GraphicsBuffer_Bindings::InternalSetNativeData", HasExplicitThis = true, ThrowsException = true)]
		private void InternalSetNativeData(IntPtr data, int nativeBufferStartIndex, int computeBufferStartIndex, int count, int elemSize); // 0x0000000182201E00-0x0000000182201E80
		[FreeFunction(Name = "GraphicsBuffer_Bindings::InternalSetData", HasExplicitThis = true, ThrowsException = true)]
		private void InternalSetData(Span<byte> data, int managedBufferStartIndex, int computeBufferStartIndex, int count, int elemSize); // 0x0000000182201CC0-0x0000000182201D90
		public void GetData(Array data); // 0x0000000182201880-0x0000000182201AB0
		[FreeFunction(Name = "GraphicsBuffer_Bindings::InternalGetData", HasExplicitThis = true, ThrowsException = true)]
		private void InternalGetData(Span<byte> data, int managedBufferStartIndex, int computeBufferStartIndex, int count, int elemSize); // 0x0000000182201B80-0x0000000182201C50
		private static void DestroyBuffer_Injected(IntPtr buf); // 0x00000001822015C0-0x0000000182201600
		private static bool IsValidBuffer_Injected(IntPtr buf); // 0x0000000182201E80-0x0000000182201EC0
		private static int get_count_Injected(IntPtr _unity_self); // 0x0000000182202410-0x0000000182202450
		private static int get_stride_Injected(IntPtr _unity_self); // 0x00000001822024B0-0x00000001822024F0
		private static void InternalSetNativeData_Injected(IntPtr _unity_self, IntPtr data, int nativeBufferStartIndex, int computeBufferStartIndex, int count, int elemSize); // 0x0000000182201D90-0x0000000182201E00
		private static void InternalSetData_Injected(IntPtr _unity_self, ref ManagedSpanWrapper data, int managedBufferStartIndex, int computeBufferStartIndex, int count, int elemSize); // 0x0000000182201C50-0x0000000182201CC0
		private static void InternalGetData_Injected(IntPtr _unity_self, ref ManagedSpanWrapper data, int managedBufferStartIndex, int computeBufferStartIndex, int count, int elemSize); // 0x0000000182201B10-0x0000000182201B80
	}
}
