/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Light))]
	public class UniversalAdditionalLightData : MonoBehaviour, ISerializationCallbackReceiver, IAdditionalData // TypeDefIndex: 9819
	{
		// Fields
		[SerializeField]
		[Tooltip("Controls if light Shadow Bias parameters use pipeline settings.")]
		private bool m_UsePipelineSettings; // 0x20
		public static readonly int AdditionalLightsShadowResolutionTierCustom; // 0x00
		public static readonly int AdditionalLightsShadowResolutionTierLow; // 0x04
		public static readonly int AdditionalLightsShadowResolutionTierMedium; // 0x08
		public static readonly int AdditionalLightsShadowResolutionTierHigh; // 0x0C
		public static readonly int AdditionalLightsShadowDefaultResolutionTier; // 0x10
		public static readonly int AdditionalLightsShadowDefaultCustomResolution; // 0x14
		[NonSerialized]
		private Light m_Light; // 0x28
		public static readonly int AdditionalLightsShadowMinimumResolution; // 0x18
		[SerializeField]
		[Tooltip("Controls if light shadow resolution uses pipeline settings.")]
		private int m_AdditionalLightsShadowResolutionTier; // 0x30
		[SerializeField]
		private bool m_CustomShadowLayers; // 0x34
		[SerializeField]
		private Vector2 m_LightCookieSize; // 0x38
		[SerializeField]
		private Vector2 m_LightCookieOffset; // 0x40
		[SerializeField]
		private SoftShadowQuality m_SoftShadowQuality; // 0x48
		[SerializeField]
		private RenderingLayerMask m_RenderingLayersMask; // 0x4C
		[SerializeField]
		private RenderingLayerMask m_ShadowRenderingLayersMask; // 0x50
		[SerializeField]
		private Version m_Version; // 0x54
		[Obsolete("This is obsolete, please use m_RenderingLayerMask instead. #from(2023.1)")]
		[SerializeField]
		private LightLayerEnum m_LightLayerMask; // 0x58
		[Obsolete("This is obsolete, please use m_RenderingLayerMask instead. #from(2023.1)")]
		[SerializeField]
		private LightLayerEnum m_ShadowLayerMask; // 0x5C
		[Obsolete("This is obsolete, please use m_RenderingLayersMask instead. #from(6000.2)")]
		[SerializeField]
		private uint m_RenderingLayers; // 0x60
		[Obsolete("This is obsolete, please use renderingLayersMask instead. #from(6000.2)")]
		[SerializeField]
		private uint m_ShadowRenderingLayers; // 0x64
	
		// Properties
		public bool usePipelineSettings { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
		internal Light light { get; } // 0x0000000181FFE1B0-0x0000000181FFE230 
		public int additionalLightsShadowResolutionTier { get; set; } // 0x000000018033D100-0x000000018033D110 0x0000000181FFE230-0x0000000181FFE2E0
		public bool customShadowLayers { get; set; } // 0x00000001816DAFD0-0x00000001816DAFE0 0x0000000181FFE2E0-0x0000000181FFE2F0
		[Tooltip("Controls the size of the cookie mask currently assigned to the light.")]
		public Vector2 lightCookieSize { get; set; } // 0x0000000181FFE190-0x0000000181FFE1B0 0x0000000181C048C0-0x0000000181C048D0
		[Tooltip("Controls the offset of the cookie mask currently assigned to the light.")]
		public Vector2 lightCookieOffset { get; set; } // 0x0000000181F7C3E0-0x0000000181F7C400 0x000000018172A470-0x000000018172A480
		[Tooltip("Controls the filtering quality of soft shadows. Higher quality has lower performance.")]
		public SoftShadowQuality softShadowQuality { get; set; } // 0x000000018033D1C0-0x000000018033D1D0 0x000000018033E7A0-0x000000018033E7B0
		public RenderingLayerMask renderingLayers { get; set; } // 0x000000018033D1B0-0x000000018033D1C0 0x0000000181FFE2F0-0x0000000181FFE360
		public RenderingLayerMask shadowRenderingLayers { get; set; } // 0x000000018033D660-0x000000018033D670 0x0000000181FFE360-0x0000000181FFE3C0
		[Obsolete("This is obsolete, please use renderingLayerMask instead. #from(2023.1) #breakingFrom(2023.1)", true)]
		public LightLayerEnum lightLayerMask { get; set; } // 0x000000018033D260-0x000000018033D270 0x000000018033E870-0x000000018033E880
		[Obsolete("This is obsolete, please use shadowRenderingLayerMask instead. #from(2023.1) #breakingFrom(2023.1)", true)]
		public LightLayerEnum shadowLayerMask { get; set; } // 0x000000018033D270-0x000000018033D280 0x000000018033E880-0x000000018033E890
	
		// Nested types
		private enum Version // TypeDefIndex: 9820
		{
			Initial = 0,
			RenderingLayers = 2,
			SoftShadowQuality = 3,
			RenderingLayersMask = 4,
			Count = 5
		}
	
		// Constructors
		public UniversalAdditionalLightData(); // 0x0000000181FFE000-0x0000000181FFE190
		static UniversalAdditionalLightData(); // 0x0000000181FFDF40-0x0000000181FFE000
	
		// Methods
		private void SyncLightAndShadowLayers(); // 0x0000000181FFDD60-0x0000000181FFDE20
		void ISerializationCallbackReceiver.OnBeforeSerialize(); // 0x0000000181FFDF30-0x0000000181FFDF40
		void ISerializationCallbackReceiver.OnAfterDeserialize(); // 0x0000000181FFDE20-0x0000000181FFDF30
	}
}
