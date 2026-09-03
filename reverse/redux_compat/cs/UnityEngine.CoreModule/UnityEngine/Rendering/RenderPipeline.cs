/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public abstract class RenderPipeline // TypeDefIndex: 8422
	{
		// Fields
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x10
	
		// Properties
		public bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
		public virtual RenderPipelineGlobalSettings defaultSettings { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Nested types
		public class StandardRequest // TypeDefIndex: 8423
		{
			// Fields
			public RenderTexture destination; // 0x10
			public int mipLevel; // 0x18
			public CubemapFace face; // 0x1C
			public int slice; // 0x20
			public bool isPreview; // 0x24
		}
	
		// Constructors
		protected RenderPipeline(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		[Obsolete("Render with an array parameter is deprecated. Use Render with a list parameter instead. If you\'re extending the RenderPipeline class, override the Render method with a List parameter to perform rendering in order to avoid unnecessary allocations and copies. #from 6000.1", false)]
		protected virtual void Render(ScriptableRenderContext context, Camera[] cameras); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void ProcessRenderRequests<RequestData>(ScriptableRenderContext context, Camera camera, RequestData renderRequest);
		protected internal virtual bool IsRenderRequestSupported<RequestData>(Camera camera, RequestData data);
		protected static void BeginContextRendering(ScriptableRenderContext context, List<Camera> cameras); // 0x00000001822627D0-0x00000001822628E0
		protected static void BeginCameraRendering(ScriptableRenderContext context, Camera camera); // 0x0000000182262710-0x00000001822627D0
		protected static void EndContextRendering(ScriptableRenderContext context, List<Camera> cameras); // 0x0000000182262A10-0x0000000182262B20
		protected static void EndCameraRendering(ScriptableRenderContext context, Camera camera); // 0x0000000182262950-0x0000000182262A10
		protected virtual void Render(ScriptableRenderContext context, List<Camera> cameras); // 0x0000000182262BB0-0x0000000182262C30
		internal void InternalRender(ScriptableRenderContext context, List<Camera> cameras); // 0x0000000182262B20-0x0000000182262BB0
		internal void InternalProcessRenderRequests<RequestData>(ScriptableRenderContext context, Camera camera, RequestData renderRequest);
		internal void Dispose(); // 0x00000001822628E0-0x0000000182262950
		protected virtual void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
