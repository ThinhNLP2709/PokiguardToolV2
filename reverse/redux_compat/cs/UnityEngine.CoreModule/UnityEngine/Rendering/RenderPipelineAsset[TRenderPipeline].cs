/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public abstract class RenderPipelineAsset<TRenderPipeline> : RenderPipelineAsset // TypeDefIndex: 8425
		where TRenderPipeline : RenderPipeline
	{
		// Properties
		public sealed override Type pipelineType { get; }
		public override string renderPipelineShaderTag { get; }
		[Obsolete("This property is obsolete. Use pipelineType instead. #from(23.2)", false)]
		protected internal sealed override Type renderPipelineType { get; }
	
		// Constructors
		protected RenderPipelineAsset();
	}
}
