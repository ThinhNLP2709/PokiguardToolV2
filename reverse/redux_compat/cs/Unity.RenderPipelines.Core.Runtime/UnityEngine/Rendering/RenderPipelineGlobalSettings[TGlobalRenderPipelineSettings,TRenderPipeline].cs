/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Scripting.LifecycleManagement;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public abstract class RenderPipelineGlobalSettings<TGlobalRenderPipelineSettings, TRenderPipeline> : RenderPipelineGlobalSettings // TypeDefIndex: 5655
		where TGlobalRenderPipelineSettings : RenderPipelineGlobalSettings
		where TRenderPipeline : RenderPipeline
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static Lazy<TGlobalRenderPipelineSettings> s_Instance;
	
		// Properties
		public static TGlobalRenderPipelineSettings instance { get; }
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5656
		{
			// Fields
			public static readonly __c<TGlobalRenderPipelineSettings, TRenderPipeline> __9;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal TGlobalRenderPipelineSettings _.cctor_b__5_0();
		}
	
		// Constructors
		protected RenderPipelineGlobalSettings();
		static RenderPipelineGlobalSettings();
	
		// Methods
		public virtual void Reset();
	}
}
