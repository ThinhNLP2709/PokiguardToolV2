/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[DebuggerDisplay("Resource ({GetType().Name}:{GetName()})")]
	internal abstract class RenderGraphResource<DescType, ResType> : IRenderGraphResource // TypeDefIndex: 5972
		where DescType : struct
		where ResType : class
	{
		// Fields
		public DescType desc;
		public bool validDesc;
		public ResType graphicsResource;
		protected RenderGraphResourcePool<ResType> m_Pool;
	
		// Constructors
		protected RenderGraphResource();
	
		// Methods
		public override void Reset(IRenderGraphResourcePool pool = null);
		public override bool IsCreated();
		public override void ReleaseGraphicsResource();
		public override void CreatePooledGraphicsResource(int frameIndex, int executionCount);
		public override void ReleasePooledGraphicsResource(int frameIndex, int executionCount);
	}
}
