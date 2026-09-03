/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Rendering;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[DebuggerDisplay("RenderPass: {name} (Index:{index} Async:{enableAsyncCompute})")]
	internal abstract class BaseRenderGraphPass<PassData, TRenderGraphContext> : RenderGraphPass // TypeDefIndex: 5932
		where PassData : class, new()
	{
		// Fields
		internal PassData data;
		internal BaseRenderFunc<PassData, TRenderGraphContext> renderFunc;
	
		// Constructors
		protected BaseRenderGraphPass();
	
		// Methods
		public void Initialize(int passIndex, PassData passData, string passName, RenderGraphPassType passType, ProfilingSampler sampler);
		public override void Release(RenderGraphObjectPool pool);
		public override bool HasRenderFunc();
		public override int GetRenderFuncHash();
	}
}
