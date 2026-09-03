/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[ExcludeFromPreset]
	public abstract class ScriptableRendererFeature : ScriptableObject, IDisposable // TypeDefIndex: 9768
	{
		// Fields
		[HideInInspector]
		[SerializeField]
		private bool m_Active; // 0x18
		[CompilerGenerated]
		private ScriptableRenderer.RenderingFeatures _supportedRenderingFeatures_k__BackingField; // 0x20
	
		// Properties
		public bool isActive { get; } // 0x0000000180F9E350-0x0000000180F9E360 
		[Obsolete("This property is not used. #from(6000.3)", false)]
		protected virtual IntermediateTextureUsage useIntermediateTextures { get; } // 0x00000001802E7860-0x00000001802E7870 
		internal ScriptableRenderer.RenderingFeatures supportedRenderingFeatures { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
	
		// Nested types
		[Obsolete("This enum is not used. #from(6000.3)", false)]
		public enum IntermediateTextureUsage // TypeDefIndex: 9769
		{
			Unknown = 0,
			Required = 1,
			NotRequired = 2
		}
	
		// Constructors
		protected ScriptableRendererFeature(); // 0x0000000181FE4A10-0x0000000181FE4A80
	
		// Methods
		public abstract void Create();
		public virtual void OnCameraPreCull(ScriptableRenderer renderer, [IsReadOnly] in CameraData cameraData); // 0x00000001802E76C0-0x00000001802E76D0
		public abstract void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData);
		private void OnEnable(); // 0x0000000181FE4850-0x0000000181FE4930
		private void OnValidate(); // 0x0000000181FE4930-0x0000000181FE4A10
		internal virtual bool RequireRenderingLayers(bool isDeferred, bool needsGBufferAccurateNormals, out RenderingLayerUtils.Event atEvent, out RenderingLayerUtils.MaskSize maskSize); // 0x0000000181FC32E0-0x0000000181FC3300
		public void SetActive(bool active); // 0x00000001804C2E10-0x00000001804C2E20
		public void Dispose(); // 0x0000000181FE47E0-0x0000000181FE4850
		protected virtual void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
