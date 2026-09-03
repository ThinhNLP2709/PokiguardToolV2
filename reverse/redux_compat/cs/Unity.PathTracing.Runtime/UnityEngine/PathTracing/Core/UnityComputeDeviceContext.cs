/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;
using UnityEngine.LightTransport;
using UnityEngine.Rendering;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	internal class UnityComputeDeviceContext : IDeviceContext // TypeDefIndex: 13607
	{
		// Fields
		private readonly Dictionary<BufferID, GraphicsBuffer> _buffers; // 0x10
		private readonly HashSet<EventID> _inProgressRequests; // 0x18
		private readonly HashSet<EventID> _failedRequests; // 0x20
		private readonly HashSet<EventID> _successfulRequests; // 0x28
		private uint _nextFreeBufferId; // 0x30
		private uint _nextFreeEventId; // 0x34
		private CommandBuffer _cmdBuffer; // 0x38
		private List<BufferID> _temporaryBuffers; // 0x40
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c__16<T> // TypeDefIndex: 13608
			where T : struct
		{
			// Fields
			public static readonly __c__16<T> __9;
			public static Action<AsyncGPUReadbackRequest> __9__16_0;
	
			// Constructors
			static __c__16();
			public __c__16();
	
			// Methods
			internal void _ReadBuffer_b__16_0(AsyncGPUReadbackRequest _p0_);
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass17_0<T> // TypeDefIndex: 13609
			where T : struct
		{
			// Fields
			public UnityComputeDeviceContext __4__this;
			public EventID id;
	
			// Constructors
			public __c__DisplayClass17_0();
	
			// Methods
			internal void _ReadBuffer_b__0(AsyncGPUReadbackRequest request);
		}
	
		// Constructors
		public UnityComputeDeviceContext(); // 0x0000000181E15B70-0x0000000181E15CD0
	
		// Methods
		private void CreateCommandBuffer(); // 0x0000000181E15470-0x0000000181E15510
		public BufferID CreateBuffer(ulong count, ulong stride); // 0x0000000181E15350-0x0000000181E15470
		public void DestroyBuffer(BufferID id); // 0x0000000181E15520-0x0000000181E155B0
		public void Dispose(); // 0x0000000181E156A0-0x0000000181E156D0
		public bool Flush(); // 0x0000000181E156D0-0x0000000181E15750
		public bool Initialize(); // 0x0000000181E15940-0x0000000181E15960
		public bool IsCompleted(EventID id); // 0x0000000181E15960-0x0000000181E159E0
		public bool Wait(EventID id); // 0x0000000181E15B00-0x0000000181E15B70
		public void ReadBuffer<T>(BufferSlice<T> src, NativeArray<T> result)
			where T : struct;
		public void ReadBuffer<T>(BufferSlice<T> src, NativeArray<T> result, EventID id)
			where T : struct;
		public void WriteBuffer<T>(BufferSlice<T> dst, NativeArray<T> src)
			where T : struct;
		public void WriteBuffer<T>(BufferSlice<T> dst, NativeArray<T> src, EventID id)
			where T : struct;
		public EventID CreateEvent(); // 0x0000000181E15510-0x0000000181E15520
		public void DestroyEvent(EventID id); // 0x0000000181E155B0-0x0000000181E156A0
		public GraphicsBuffer GetComputeBuffer(BufferID id); // 0x0000000181E15750-0x0000000181E157B0
		public CommandBuffer GetCommandBuffer(); // 0x00000001803272A0-0x00000001803272B0
		public BufferID GetTemporaryBuffer(ulong count, ulong stride); // 0x0000000181E157B0-0x0000000181E15940
		private void ReleaseTemporaryBuffers(); // 0x0000000181E159E0-0x0000000181E15B00
	}
}
