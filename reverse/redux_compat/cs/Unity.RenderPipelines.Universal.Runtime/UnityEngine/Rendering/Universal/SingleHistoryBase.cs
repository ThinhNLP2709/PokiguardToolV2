/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	internal abstract class SingleHistoryBase : CameraHistoryItem // TypeDefIndex: 9490
	{
		// Fields
		private int m_Id; // 0x20
		private RenderTextureDescriptor m_Descriptor; // 0x24
		private Hash128 m_DescKey; // 0x58
	
		// Constructors
		protected SingleHistoryBase(); // 0x0000000181F98970-0x0000000181F98980
	
		// Methods
		public override void OnCreate(BufferedRTHandleSystem owner, uint typeId); // 0x0000000181F98740-0x0000000181F98770
		public RTHandle GetTexture(int frameIndex = 0 /* Metadata: 0x0069EBCE */); // 0x0000000181F98630-0x0000000181F98690
		public RTHandle GetCurrentTexture(); // 0x0000000181F985D0-0x0000000181F985E0
		public RTHandle GetPreviousTexture(); // 0x0000000181F985E0-0x0000000181F98630
		internal bool IsAllocated(); // 0x0000000181F98690-0x0000000181F986F0
		internal bool IsDirty(ref RenderTextureDescriptor desc); // 0x0000000181F986F0-0x0000000181F98740
		private void Alloc(ref RenderTextureDescriptor desc); // 0x0000000181F98510-0x0000000181F985D0
		public override void Reset(); // 0x0000000181F98770-0x0000000181F98780
		internal bool Update(ref RenderTextureDescriptor cameraDesc); // 0x0000000181F98780-0x0000000181F98970
		protected abstract int GetHistoryFrameCount();
		protected abstract string GetHistoryName();
		protected abstract RenderTextureDescriptor GetHistoryDescriptor(ref RenderTextureDescriptor cameraDesc);
	}
}
