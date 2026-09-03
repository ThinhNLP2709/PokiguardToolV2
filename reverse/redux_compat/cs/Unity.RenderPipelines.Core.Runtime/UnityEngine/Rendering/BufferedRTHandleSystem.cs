/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class BufferedRTHandleSystem : IDisposable // TypeDefIndex: 5703
	{
		// Fields
		private Dictionary<int, RTEntry[]> m_RTEntries; // 0x10
		private RTHandleSystem m_RTHandleSystem; // 0x18
		private bool m_DisposedValue; // 0x20
	
		// Properties
		public int maxWidth { get; } // 0x0000000181E8CF20-0x0000000181E8CF40 
		public int maxHeight { get; } // 0x0000000181E8CF00-0x0000000181E8CF20 
		public RTHandleProperties rtHandleProperties { get; } // 0x0000000181E8CF40-0x0000000181E8CF80 
	
		// Nested types
		private struct RTEntry // TypeDefIndex: 5704
		{
			// Fields
			public RTHandle handle; // 0x00
			public int stableIndex; // 0x08
		}
	
		// Constructors
		public BufferedRTHandleSystem(); // 0x0000000181E8CE50-0x0000000181E8CF00
	
		// Methods
		private bool TryGetFrameRenderTarget(int bufferId, int frameIndex, out RTEntry rt); // 0x0000000181E8CD60-0x0000000181E8CE50
		public RTHandle GetFrameRT(int bufferId, int frameIndex); // 0x0000000181E8C670-0x0000000181E8C6B0
		public int GetFrameRTStableIndex(int bufferId, int frameIndex); // 0x0000000181E8C630-0x0000000181E8C670
		public void ClearBuffers(CommandBuffer cmd); // 0x0000000181E8C3B0-0x0000000181E8C590
		public void AllocBuffer(int bufferId, Func<RTHandleSystem, int, RTHandle> allocator, int bufferCount); // 0x0000000181E8C150-0x0000000181E8C370
		public void AllocBuffer(int bufferId, int bufferCount, ref RenderTextureDescriptor descriptor, FilterMode filterMode = FilterMode.Point /* Metadata: 0x006617C2 */, TextureWrapMode wrapMode = TextureWrapMode.Repeat /* Metadata: 0x006617C3 */, bool isShadowMap = false /* Metadata: 0x006617C4 */, int anisoLevel = 1 /* Metadata: 0x006617C5 */, float mipMapBias = 0f /* Metadata: 0x006617C6 */, string name = "" /* Metadata: 0x006617CA */); // 0x0000000181E8BE70-0x0000000181E8C150
		public void ReleaseBuffer(int bufferId); // 0x0000000181E8C8C0-0x0000000181E8C9B0
		public void SwapAndSetReferenceSize(int width, int height); // 0x0000000181E8C9E0-0x0000000181E8CA40
		public void ResetReferenceSize(int width, int height); // 0x0000000181E8C9B0-0x0000000181E8C9E0
		public int GetNumFramesAllocated(int bufferId); // 0x0000000181E8C6B0-0x0000000181E8C740
		public Vector2 CalculateRatioAgainstMaxSize(int width, int height); // 0x0000000181E8C370-0x0000000181E8C3B0
		private void Swap(); // 0x0000000181E8CA40-0x0000000181E8CD60
		private void Dispose(bool disposing); // 0x0000000181E8C590-0x0000000181E8C5E0
		public void Dispose(); // 0x0000000181E8C5E0-0x0000000181E8C630
		public void ReleaseAll(); // 0x0000000181E8C740-0x0000000181E8C8C0
	}
}
