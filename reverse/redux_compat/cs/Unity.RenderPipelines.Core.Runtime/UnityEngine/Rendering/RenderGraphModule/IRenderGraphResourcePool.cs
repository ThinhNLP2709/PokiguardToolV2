/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	internal abstract class IRenderGraphResourcePool // TypeDefIndex: 5947
	{
		// Fields
		[CompilerGenerated]
		private bool _IntraFrameMemoryAliasing_k__BackingField; // 0x10
	
		// Properties
		public bool IntraFrameMemoryAliasing { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
	
		// Constructors
		protected IRenderGraphResourcePool(); // 0x0000000181C82DF0-0x0000000181C82E00
	
		// Methods
		public abstract void PurgeUnusedResources(int currentFrameIndex);
		public abstract void Cleanup();
		public abstract void CheckFrameAllocation(bool onException, int frameIndex);
	}
}
