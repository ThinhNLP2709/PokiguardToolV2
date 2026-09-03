/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;
using UnityEngine.Scripting;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	[NativeHeader("Modules/UIElements/Core/Native/Renderer/UIRendererUtility.h")]
	[VisibleToOtherModules(new string[1] {"Unity.UIElements" })]
	internal class Utility // TypeDefIndex: 5007
	{
		// Fields
		[CompilerGenerated]
		private static Action<bool> GraphicsResourcesRecreate; // 0x00
		[CompilerGenerated]
		private static Action EngineUpdate; // 0x08
		[CompilerGenerated]
		private static Action FlushPendingResources; // 0x10
		private static ProfilerMarker s_MarkerRaiseEngineUpdate; // 0x18
	
		// Events
		public static event Action<bool> GraphicsResourcesRecreate {
			add; // 0x0000000182402050-0x0000000182402140
			remove; // 0x00000001824022E0-0x00000001824023D0
		}
		public static event Action EngineUpdate {
			add; // 0x0000000182401EB0-0x0000000182401F80
			remove; // 0x0000000182402140-0x0000000182402210
		}
		public static event Action FlushPendingResources {
			add; // 0x0000000182401F80-0x0000000182402050
			remove; // 0x0000000182402210-0x00000001824022E0
		}
	
		// Nested types
		internal enum GPUBufferType // TypeDefIndex: 5008
		{
			Vertex = 0,
			Index = 1
		}
	
		public class GPUBuffer : IDisposable // TypeDefIndex: 5009
		{
			// Fields
			private IntPtr buffer; // 0x10
			private int elementCount; // 0x18
			private int elementStride; // 0x1C
	
			// Properties
			internal IntPtr BufferPointer { get; } // 0x0000000180377550-0x0000000180377560 
	
			// Constructors
			public GPUBuffer(int elementCount, int elementStride, GpuBufferFlags bufferFlags); // 0x00000001823F8F60-0x00000001823F9010
	
			// Methods
			public void Dispose(); // 0x00000001823F8E50-0x00000001823F8EC0
			public void UpdateRanges(NativeSlice<GfxUpdateBufferRange> ranges, int writeStart, int writeEnd); // 0x00000001823F8EC0-0x00000001823F8F60
		}
	
		// Constructors
		static Utility(); // 0x0000000182401E40-0x0000000182401EB0
	
		// Methods
		[RequiredByNativeCode]
		internal static void RaiseGraphicsResourcesRecreate(bool recreate); // 0x0000000182401A60-0x0000000182401AD0
		[RequiredByNativeCode]
		internal static void RaiseEngineUpdate(); // 0x00000001824018F0-0x00000001824019F0
		[RequiredByNativeCode]
		internal static void RaiseFlushPendingResources(); // 0x00000001824019F0-0x0000000182401A60
		[NativeMethod(IsThreadSafe = true)]
		private static IntPtr AllocateBuffer(int elementCount, int elementStride, int bufferFlags); // 0x00000001824011B0-0x0000000182401200
		[NativeMethod(IsThreadSafe = true)]
		private static void FreeBuffer(IntPtr buffer); // 0x00000001824014C0-0x0000000182401500
		private static void UpdateBufferRanges(IntPtr buffer, IntPtr ranges, int rangeCount, int writeRangeStart, int writeRangeEnd); // 0x0000000182401D90-0x0000000182401E00
		public static void CopyBufferRanges(IntPtr srcBuffer, IntPtr dstBuffer, IntPtr ranges, int rangeCount, GfxCopyBufferRangesFlags flags); // 0x00000001824012F0-0x0000000182401360
		public static void SyncJobFence(JobHandle fence); // 0x0000000182401CF0-0x0000000182401D60
		[NativeMethod(IsThreadSafe = true)]
		public static IntPtr GetVertexDeclaration(VertexAttributeDescriptor[] vertexAttributes); // 0x00000001824016B0-0x0000000182401770
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe void DrawRanges(IntPtr ib, IntPtr* vertexStreams, int streamCount, IntPtr ranges, int rangeCount, IntPtr vertexDecl, KickRangesReason kickReason); // 0x0000000182401440-0x00000001824014C0
		[NativeMethod(IsThreadSafe = true)]
		public static void SetPropertyBlock(MaterialPropertyBlock props); // 0x0000000182401B50-0x0000000182401BC0
		[NativeMethod(IsThreadSafe = true)]
		public static IntPtr AllocateTextureRef(Texture texture); // 0x0000000182401240-0x00000001824012B0
		[NativeMethod(IsThreadSafe = true)]
		public static void ReleaseTextureRef(IntPtr textureRef); // 0x0000000182401AD0-0x0000000182401B10
		[NativeMethod(IsThreadSafe = true)]
		public static void SetScissorRect(RectInt scissorRect); // 0x0000000182401C00-0x0000000182401C70
		[NativeMethod(IsThreadSafe = true)]
		public static void DisableScissor(); // 0x0000000182401410-0x0000000182401440
		[NativeMethod(IsThreadSafe = true)]
		public static IntPtr CreateStencilState(StencilState stencilState); // 0x00000001824013A0-0x0000000182401410
		[NativeMethod(IsThreadSafe = true)]
		public static void SetStencilState(IntPtr stencilState, int stencilRef); // 0x0000000182401C70-0x0000000182401CB0
		[NativeMethod(IsThreadSafe = true)]
		public static bool HasMappedBufferRange(); // 0x0000000182401770-0x00000001824017A0
		[NativeMethod(IsThreadSafe = true)]
		public static uint InsertCPUFence(); // 0x00000001824017A0-0x00000001824017D0
		[NativeMethod(IsThreadSafe = true)]
		public static bool CPUFencePassed(uint fence); // 0x00000001824012B0-0x00000001824012F0
		[NativeMethod(IsThreadSafe = true)]
		public static void WaitForCPUFencePassed(uint fence); // 0x0000000182401E00-0x0000000182401E40
		[NativeMethod(IsThreadSafe = true)]
		public static void SyncRenderThread(); // 0x0000000182401D60-0x0000000182401D90
		[NativeMethod(IsThreadSafe = true)]
		public static RectInt GetActiveViewport(); // 0x0000000182401540-0x00000001824015B0
		[NativeMethod(IsThreadSafe = true)]
		public static void ProfileDrawChainBegin(EntityId owner); // 0x0000000182401850-0x00000001824018C0
		[NativeMethod(IsThreadSafe = true)]
		public static void ProfileDrawChainEnd(); // 0x00000001824018C0-0x00000001824018F0
		public static void NotifyOfUIREvents(bool subscribe); // 0x00000001824017D0-0x0000000182401810
		[NativeMethod(IsThreadSafe = true)]
		public static Matrix4x4 GetUnityProjectionMatrix(); // 0x00000001824015F0-0x0000000182401670
		private static void SyncJobFence_Injected(in JobHandle fence); // 0x0000000182401CB0-0x0000000182401CF0
		private static IntPtr GetVertexDeclaration_Injected(ref ManagedSpanWrapper vertexAttributes); // 0x0000000182401670-0x00000001824016B0
		private static void SetPropertyBlock_Injected(IntPtr props); // 0x0000000182401B10-0x0000000182401B50
		private static IntPtr AllocateTextureRef_Injected(IntPtr texture); // 0x0000000182401200-0x0000000182401240
		private static void SetScissorRect_Injected(in RectInt scissorRect); // 0x0000000182401BC0-0x0000000182401C00
		private static IntPtr CreateStencilState_Injected(in StencilState stencilState); // 0x0000000182401360-0x00000001824013A0
		private static void GetActiveViewport_Injected(); // 0x0000000182401500-0x0000000182401540
		private static void ProfileDrawChainBegin_Injected(in EntityId owner); // 0x0000000182401810-0x0000000182401850
		private static void GetUnityProjectionMatrix_Injected(); // 0x00000001824015B0-0x00000001824015F0
	}
}
