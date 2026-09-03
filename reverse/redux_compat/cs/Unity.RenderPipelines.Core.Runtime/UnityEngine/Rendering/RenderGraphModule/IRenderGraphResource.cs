/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	internal class IRenderGraphResource // TypeDefIndex: 5971
	{
		// Fields
		public bool imported; // 0x10
		public bool shared; // 0x11
		public bool sharedExplicitRelease; // 0x12
		public bool requestFallBack; // 0x13
		public uint writeCount; // 0x14
		public uint readCount; // 0x18
		public int cachedHash; // 0x1C
		public int transientPassIndex; // 0x20
		public int sharedResourceLastFrameUsed; // 0x24
		public bool isBackBuffer; // 0x28
	
		// Constructors
		public IRenderGraphResource(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual void Reset(IRenderGraphResourcePool _ = null); // 0x0000000181ED9DA0-0x0000000181ED9DC0
		public virtual string GetName(); // 0x0000000181ED9D40-0x0000000181ED9D70
		public virtual bool IsCreated(); // 0x00000001802E7840-0x00000001802E7850
		public virtual uint IncrementWriteCount(); // 0x0000000181ED9D70-0x0000000181ED9D80
		public virtual void IncrementReadCount(); // 0x000000018067A120-0x000000018067A130
		public virtual bool NeedsFallBack(); // 0x0000000181ED9D80-0x0000000181ED9DA0
		public virtual void CreatePooledGraphicsResource(int frameIndex, int executionCount); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void CreateGraphicsResource(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void UpdateGraphicsResource(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void ReleasePooledGraphicsResource(int frameIndex, int executionCount); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void ReleaseGraphicsResource(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual int GetSortIndex(); // 0x00000001802E7860-0x00000001802E7870
		public virtual int GetDescHashCode(); // 0x00000001802E7860-0x00000001802E7870
	}
}
