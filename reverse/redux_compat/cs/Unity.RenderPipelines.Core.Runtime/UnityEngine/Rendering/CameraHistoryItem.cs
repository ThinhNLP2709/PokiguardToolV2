/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public abstract class CameraHistoryItem : ContextItem // TypeDefIndex: 5326
	{
		// Fields
		private BufferedRTHandleSystem m_Owner; // 0x10
		private uint m_TypeId; // 0x18
	
		// Properties
		protected BufferedRTHandleSystem storage { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		protected CameraHistoryItem(); // 0x0000000181E1E290-0x0000000181E1E2A0
	
		// Methods
		public virtual void OnCreate(BufferedRTHandleSystem owner, uint typeId); // 0x000000018164BDC0-0x000000018164BDF0
		protected int MakeId(uint index); // 0x0000000181E1E260-0x0000000181E1E270
		protected RTHandle AllocHistoryFrameRT(int id, int count, ref RenderTextureDescriptor desc, string name = "" /* Metadata: 0x00661492 */); // 0x0000000181E1E0B0-0x0000000181E1E120
		protected RTHandle AllocHistoryFrameRT(int id, int count, ref RenderTextureDescriptor desc, FilterMode filterMode, string name = "" /* Metadata: 0x00661493 */); // 0x0000000181E1E120-0x0000000181E1E1A0
		protected void ReleaseHistoryFrameRT(int id); // 0x0000000181E1E270-0x0000000181E1E290
		protected RTHandle GetPreviousFrameRT(int id); // 0x0000000181E1E230-0x0000000181E1E260
		protected RTHandle GetCurrentFrameRT(int id); // 0x0000000181E1E1D0-0x0000000181E1E200
		protected int GetPreviousFrameRTStableIndex(int id); // 0x0000000181E1E200-0x0000000181E1E230
		protected int GetCurrentFrameRTStableIndex(int id); // 0x0000000181E1E1A0-0x0000000181E1E1D0
	}
}
