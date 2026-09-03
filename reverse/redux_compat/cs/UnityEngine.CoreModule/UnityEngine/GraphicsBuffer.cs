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
	[NativeHeader("Runtime/Shaders/GraphicsBuffer.h")]
	[NativeHeader("Runtime/Export/Graphics/GraphicsBuffer.bindings.h")]
	[UsedByNativeCode]
	public sealed class GraphicsBuffer : IDisposable // TypeDefIndex: 7575
	{
		// Fields
		internal IntPtr m_Ptr; // 0x10
	
		// Properties
		public int count { get; } // 0x00000001821A0480-0x00000001821A04E0 
		public int stride { get; } // 0x00000001821A0520-0x00000001821A0580 
		public Target target { get; } // 0x00000001821A05C0-0x00000001821A0620 
		public UsageFlags usageFlags { get; } // 0x000000018219F530-0x000000018219F590 
		public GraphicsBufferHandle bufferHandle { get; } // 0x00000001821A03D0-0x00000001821A0440 
		public string name { set; } // 0x00000001821A0620-0x00000001821A0630
	
		// Nested types
		[Flags]
		public enum Target // TypeDefIndex: 7576
		{
			Vertex = 1,
			Index = 2,
			CopySource = 4,
			CopyDestination = 8,
			Structured = 16,
			Raw = 32,
			Append = 64,
			Counter = 128,
			IndirectArguments = 256,
			Constant = 512
		}
	
		[Flags]
		public enum UsageFlags // TypeDefIndex: 7577
		{
			None = 0,
			LockBufferForWrite = 1
		}
	
		public struct IndirectDrawIndexedArgs // TypeDefIndex: 7578
		{
			// Fields
			[CompilerGenerated]
			private uint _indexCountPerInstance_k__BackingField; // 0x00
			[CompilerGenerated]
			private uint _instanceCount_k__BackingField; // 0x04
			[CompilerGenerated]
			private uint _startIndex_k__BackingField; // 0x08
			[CompilerGenerated]
			private uint _baseVertexIndex_k__BackingField; // 0x0C
			[CompilerGenerated]
			private uint _startInstance_k__BackingField; // 0x10
	
			// Properties
			public uint indexCountPerInstance { [CompilerGenerated] set; } // 0x0000000180732D50-0x0000000180732D60
			public uint instanceCount { [CompilerGenerated] set; } // 0x0000000180732D40-0x0000000180732D50
		}
	
		internal static class BindingsMarshaller // TypeDefIndex: 7579
		{
			// Methods
			public static GraphicsBuffer ConvertToManaged(IntPtr ptr); // 0x000000018219CDF0-0x000000018219CE50
			public static IntPtr ConvertToNative(GraphicsBuffer graphicsBuffer); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		private GraphicsBuffer(IntPtr ptr); // 0x000000018219D840-0x000000018219D870
		public GraphicsBuffer(Target target, int count, int stride); // 0x00000001821A0310-0x00000001821A0380
		public GraphicsBuffer(Target target, UsageFlags usageFlags, int count, int stride); // 0x00000001821A02B0-0x00000001821A0310
	
		// Methods
		~GraphicsBuffer(); // 0x000000018219EF30-0x000000018219EFF0
		public void Dispose(); // 0x000000018219ED10-0x000000018219EDD0
		private void Dispose(bool disposing); // 0x000000018219EDD0-0x000000018219EE90
		private static bool RequiresCompute(Target target); // 0x000000018219FEB0-0x000000018219FEC0
		private static bool IsCopyOnly(Target target); // 0x000000018219FDD0-0x000000018219FDE0
		private static bool HasVertexOrIndex(Target target); // 0x000000018219F590-0x000000018219F5A0
		[FreeFunction("GraphicsBuffer_Bindings::InitBuffer")]
		private static IntPtr InitBuffer(Target target, UsageFlags usageFlags, int count, int stride); // 0x000000018219F5A0-0x000000018219F600
		[FreeFunction("GraphicsBuffer_Bindings::DestroyBuffer")]
		private static void DestroyBuffer(GraphicsBuffer buf); // 0x000000018219ECD0-0x000000018219ED10
		private void InternalInitialization(Target target, UsageFlags usageFlags, int count, int stride); // 0x000000018219F740-0x000000018219FBA0
		public void Release(); // 0x000000018219ED10-0x000000018219EDD0
		[FreeFunction("GraphicsBuffer_Bindings::IsValidBuffer")]
		private static bool IsValidBuffer(GraphicsBuffer buf); // 0x000000018219FE20-0x000000018219FE60
		public bool IsValid(); // 0x000000018219FE60-0x000000018219FEB0
		[FreeFunction(Name = "GraphicsBuffer_Bindings::GetUsageFlags", HasExplicitThis = true)]
		private UsageFlags GetUsageFlags(); // 0x000000018219F530-0x000000018219F590
		public void SetData(Array data); // 0x000000018219FEC0-0x00000001821A00F0
		public void SetData<T>(NativeArray<T> data)
			where T : struct;
		public void SetData<T>(NativeArray<T> data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count)
			where T : struct;
		[FreeFunction(Name = "GraphicsBuffer_Bindings::InternalSetNativeData", HasExplicitThis = true, ThrowsException = true)]
		private void InternalSetNativeData(IntPtr data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize); // 0x000000018219FD50-0x000000018219FDD0
		[FreeFunction(Name = "GraphicsBuffer_Bindings::InternalSetData", HasExplicitThis = true, ThrowsException = true)]
		private void InternalSetData(Span<byte> data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize); // 0x000000018219FC10-0x000000018219FCE0
		public void GetData(Array data); // 0x000000018219EFF0-0x000000018219F230
		public void GetData(Array data, int managedBufferStartIndex, int computeBufferStartIndex, int count); // 0x000000018219F230-0x000000018219F4F0
		[FreeFunction(Name = "GraphicsBuffer_Bindings::InternalGetData", HasExplicitThis = true, ThrowsException = true)]
		private void InternalGetData(Span<byte> data, int managedBufferStartIndex, int computeBufferStartIndex, int count, int elemSize); // 0x000000018219F670-0x000000018219F740
		private unsafe void* BeginBufferWrite(int offset = 0 /* Metadata: 0x0069D293 */, int size = 0 /* Metadata: 0x0069D294 */); // 0x000000018219EC20-0x000000018219EC90
		public NativeArray<T> LockBufferForWrite<T>(int bufferStartIndex, int count)
			where T : struct;
		private void EndBufferWrite(int bytesWritten = 0 /* Metadata: 0x0069D295 */); // 0x000000018219EED0-0x000000018219EF30
		public void UnlockBufferAfterWrite<T>(int countWritten)
			where T : struct;
		[FreeFunction(Name = "GraphicsBuffer_Bindings::SetName", HasExplicitThis = true)]
		private void SetName(string name); // 0x00000001821A0140-0x00000001821A02B0
		private static void DestroyBuffer_Injected(IntPtr buf); // 0x000000018219EC90-0x000000018219ECD0
		private static bool IsValidBuffer_Injected(IntPtr buf); // 0x000000018219FDE0-0x000000018219FE20
		private static int get_count_Injected(IntPtr _unity_self); // 0x00000001821A0440-0x00000001821A0480
		private static int get_stride_Injected(IntPtr _unity_self); // 0x00000001821A04E0-0x00000001821A0520
		private static Target get_target_Injected(IntPtr _unity_self); // 0x00000001821A0580-0x00000001821A05C0
		private static UsageFlags GetUsageFlags_Injected(IntPtr _unity_self); // 0x000000018219F4F0-0x000000018219F530
		private static void get_bufferHandle_Injected(IntPtr _unity_self, ); // 0x00000001821A0380-0x00000001821A03D0
		private static void InternalSetNativeData_Injected(IntPtr _unity_self, IntPtr data, int nativeBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize); // 0x000000018219FCE0-0x000000018219FD50
		private static void InternalSetData_Injected(IntPtr _unity_self, ref ManagedSpanWrapper data, int managedBufferStartIndex, int graphicsBufferStartIndex, int count, int elemSize); // 0x000000018219FBA0-0x000000018219FC10
		private static void InternalGetData_Injected(IntPtr _unity_self, ref ManagedSpanWrapper data, int managedBufferStartIndex, int computeBufferStartIndex, int count, int elemSize); // 0x000000018219F600-0x000000018219F670
		private static unsafe void* BeginBufferWrite_Injected(IntPtr _unity_self, int offset, int size); // 0x000000018219EBD0-0x000000018219EC20
		private static void EndBufferWrite_Injected(IntPtr _unity_self, int bytesWritten); // 0x000000018219EE90-0x000000018219EED0
		private static void SetName_Injected(IntPtr _unity_self, ref ManagedSpanWrapper name); // 0x00000001821A00F0-0x00000001821A0140
	}
}
