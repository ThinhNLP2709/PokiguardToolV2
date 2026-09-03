/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public class UniversalCameraHistory : ICameraHistoryReadAccess, ICameraHistoryWriteAccess, IPerFrameHistoryAccessTracker, IDisposable // TypeDefIndex: 9822
	{
		// Fields
		private const int k_ValidVersionCount = 2; // Metadata: 0x0069F236
		[NoAutoStaticsCleanup]
		private static uint s_TypeCount; // 0x00
		private Item[] m_Items; // 0x10
		private int m_Version; // 0x18
		private BufferedRTHandleSystem m_HistoryTextures; // 0x20
		[CompilerGenerated]
		private ICameraHistoryReadAccess.HistoryRequestDelegate OnGatherHistoryRequests; // 0x28
	
		// Events
		public event ICameraHistoryReadAccess.HistoryRequestDelegate OnGatherHistoryRequests {
			add; // 0x0000000181FFE700-0x0000000181FFE7A0
			remove; // 0x0000000181FFE7A0-0x0000000181FFE840
		}
	
		// Nested types
		private static class TypeId<T> // TypeDefIndex: 9823
		{
			// Fields
			[NoAutoStaticsCleanup]
			public static uint value;
	
			// Constructors
			static TypeId();
		}
	
		private struct Item // TypeDefIndex: 9824
		{
			// Fields
			public ContextItem storage; // 0x00
			public int requestVersion; // 0x08
			public int writeVersion; // 0x0C
	
			// Methods
			public void Reset(); // 0x0000000181FF7810-0x0000000181FF7850
		}
	
		// Constructors
		internal UniversalCameraHistory(); // 0x0000000181FFE5E0-0x0000000181FFE700
	
		// Methods
		public void RequestAccess<Type>()
			where Type : ContextItem;
		public Type GetHistoryForRead<Type>()
			where Type : ContextItem;
		public bool IsAccessRequested<Type>()
			where Type : ContextItem;
		public Type GetHistoryForWrite<Type>()
			where Type : ContextItem, new();
		public bool IsWritten<Type>()
			where Type : ContextItem;
		public void Dispose(); // 0x0000000181FFE3C0-0x0000000181FFE480
		internal void GatherHistoryRequests(); // 0x0000000181FFE480-0x0000000181FFE4A0
		private bool IsValidRequest(int i); // 0x0000000181FFE4A0-0x0000000181FFE4E0
		private bool IsValid(int i); // 0x0000000181FFE4E0-0x0000000181FFE520
		internal void ReleaseUnusedHistory(); // 0x0000000181FFE520-0x0000000181FFE5C0
		internal void SwapAndSetReferenceSize(int cameraWidth, int cameraHeight); // 0x0000000181FFE5C0-0x0000000181FFE5E0
	}
}
