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
	public abstract class DepthHistory : CameraHistoryItem // TypeDefIndex: 9487
	{
		// Fields
		private int[] m_Ids; // 0x20
		protected readonly string[] m_Names; // 0x28
		private RenderTextureDescriptor m_Descriptor; // 0x30
		private Hash128 m_DescKey; // 0x68
		private Vector2[] m_JitterOffsets; // 0x78
	
		// Constructors
		protected DepthHistory(); // 0x0000000181F8C240-0x0000000181F8C360
	
		// Methods
		public override void OnCreate(BufferedRTHandleSystem owner, uint typeId); // 0x0000000181F8BD50-0x0000000181F8BE20
		public RTHandle GetCurrentTexture(int eyeIndex = 0 /* Metadata: 0x0069EBCA */); // 0x0000000181F8B150-0x0000000181F8B1A0
		public RTHandle GetPreviousTexture(int eyeIndex = 0 /* Metadata: 0x0069EBCB */); // 0x0000000181F8B290-0x0000000181F8B2E0
		public Vector2 GetCurrentJitter(int eyeIndex = 0 /* Metadata: 0x0069EBCC */); // 0x0000000181F8B0A0-0x0000000181F8B150
		public Vector2 GetPreviousJitter(int eyeIndex = 0 /* Metadata: 0x0069EBCD */); // 0x0000000181F8B1E0-0x0000000181F8B290
		private bool IsAllocated(); // 0x0000000181F8B2E0-0x0000000181F8B330
		private bool IsDirty(ref RenderTextureDescriptor desc); // 0x0000000181F8B330-0x0000000181F8B380
		private void Alloc(ref RenderTextureDescriptor desc, bool xrMultipassEnabled); // 0x0000000181F8AF90-0x0000000181F8B0A0
		public override void Reset(); // 0x0000000181F8B450-0x0000000181F8B4D0
		internal RenderTextureDescriptor GetHistoryDescriptor(ref RenderTextureDescriptor cameraDesc); // 0x0000000181F8BD10-0x0000000181F8BD50
		internal bool Update(UniversalCameraData cameraData, bool xrMultipassEnabled, [IsReadOnly] in RenderTextureDescriptor? cameraDescOverride = null); // 0x0000000181F8BE20-0x0000000181F8C240
	}
}
