/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering.RenderGraphModule
{
	[DebuggerDisplay("RenderPass: {name} (Index:{index} Async:{enableAsyncCompute})")]
	[Obsolete("RenderGraphPass is deprecated, use RasterRenderGraphPass/ComputeRenderGraphPass/UnsafeRenderGraphPass instead.")]
	internal sealed class RenderGraphPass<PassData> : BaseRenderGraphPass<PassData, UnityEngine.Rendering.RenderGraphModule.RenderGraphContext> // TypeDefIndex: 5933
		where PassData : class, new()
	{
		// Fields
		[NoAutoStaticsCleanup]
		internal static RenderGraphContext c;
	
		// Constructors
		public RenderGraphPass();
		static RenderGraphPass();
	
		// Methods
		public override void Execute(InternalRenderGraphContext renderGraphContext);
		public override void Release(RenderGraphObjectPool pool);
	}
}
