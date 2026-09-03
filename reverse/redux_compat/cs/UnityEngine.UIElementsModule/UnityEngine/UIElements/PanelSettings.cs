/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[HelpURL("UIE-Runtime-Panel-Settings")]
	public class PanelSettings : ScriptableObject, IPanelSettings // TypeDefIndex: 4188
	{
		// Fields
		private const int k_DefaultSortingOrder = 0; // Metadata: 0x0066052B
		private const float k_DefaultScaleValue = 1f; // Metadata: 0x0066052C
		internal const string k_DefaultStyleSheetPath = "Packages/com.unity.ui/PackageResources/StyleSheets/Generated/Default.tss.asset"; // Metadata: 0x00660530
		[SerializeField]
		private ThemeStyleSheet themeUss; // 0x18
		[SerializeField]
		private bool m_DisableNoThemeWarning; // 0x20
		[SerializeField]
		private RenderTexture m_TargetTexture; // 0x28
		[SerializeField]
		private PanelRenderMode m_RenderMode; // 0x30
		[FormerlySerializedAs("m_WorldInputMode")]
		[SerializeField]
		private ColliderUpdateMode m_ColliderUpdateMode; // 0x34
		[SerializeField]
		private bool m_ColliderIsTrigger; // 0x38
		[SerializeField]
		private PanelScaleMode m_ScaleMode; // 0x3C
		[SerializeField]
		private float m_ReferenceSpritePixelsPerUnit; // 0x40
		[SerializeField]
		private float m_PixelsPerUnit; // 0x44
		[SerializeField]
		private float m_Scale; // 0x48
		private const float DefaultDpi = 96f; // Metadata: 0x00660580
		[SerializeField]
		private float m_ReferenceDpi; // 0x4C
		[SerializeField]
		private float m_FallbackDpi; // 0x50
		[SerializeField]
		private Vector2Int m_ReferenceResolution; // 0x54
		[SerializeField]
		private PanelScreenMatchMode m_ScreenMatchMode; // 0x5C
		[Range(0f, 1f)]
		[SerializeField]
		private float m_Match; // 0x60
		[SerializeField]
		private float m_SortingOrder; // 0x64
		[SerializeField]
		private int m_TargetDisplay; // 0x68
		[SerializeField]
		private BindingLogLevel m_BindingLogLevel; // 0x6C
		[SerializeField]
		private bool m_ClearDepthStencil; // 0x70
		[SerializeField]
		private bool m_ClearColor; // 0x71
		[SerializeField]
		private Color m_ColorClearValue; // 0x74
		[SerializeField]
		private uint m_VertexBudget; // 0x84
		[SerializeField]
		private ExtraVertexChannels m_ExtraVertexChannels; // 0x88
		[SerializeField]
		private TextureSlotCount m_TextureSlotCount; // 0x8C
		private RuntimePanelAccess m_PanelAccess; // 0x90
		internal PanelComponentList m_AttachedPanelComponentsList; // 0x98
		[HideInInspector]
		[SerializeField]
		private DynamicAtlasSettings m_DynamicAtlasSettings; // 0xA0
		[HideInInspector]
		[SerializeField]
		private Shader m_AtlasBlitShader; // 0xA8
		[HideInInspector]
		[SerializeField]
		private Shader m_DefaultShader; // 0xB0
		[HideInInspector]
		[SerializeField]
		private Shader m_RuntimeGaussianBlurShader; // 0xB8
		[HideInInspector]
		[SerializeField]
		private Shader m_RuntimeColorEffectShader; // 0xC0
		[HideInInspector]
		[SerializeField]
		private Shader m_RuntimeDropShadowComposite; // 0xC8
		[HideInInspector]
		[SerializeField]
		private Shader m_SDFShader; // 0xD0
		[HideInInspector]
		[SerializeField]
		private Shader m_BitmapShader; // 0xD8
		[HideInInspector]
		[SerializeField]
		private Shader m_SpriteShader; // 0xE0
		[HideInInspector]
		[SerializeField]
		internal TextAsset m_ICUDataAsset; // 0xE8
		[SerializeField]
		public bool forceGammaRendering; // 0xF0
		[SerializeField]
		public PanelTextSettings textSettings; // 0xF8
		private Rect m_TargetRect; // 0x100
		private float m_ResolvedScale; // 0x110
		private StyleSheet m_OldThemeUss; // 0x118
		private IDebugPanelChangeReceiver m_PanelChangeReceiver; // 0x120
		private Func<Vector2, Vector3> m_AssignedScreenToPanel; // 0x128
	
		// Properties
		public ThemeStyleSheet themeStyleSheet { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001824A3980-0x00000001824A39B0
		internal bool disableNoThemeWarning { get; set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
		public RenderTexture targetTexture { get; set; } // 0x000000018033D240-0x000000018033D250 0x00000001824A3920-0x00000001824A3980
		public PanelRenderMode renderMode { get; set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
		PanelRenderMode IPanelSettings.renderMode { get; } // 0x000000018033D100-0x000000018033D110 
		internal ColliderUpdateMode colliderUpdateMode { get; set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018033E770-0x000000018033E780
		internal bool colliderIsTrigger { get; set; } // 0x0000000180476380-0x0000000180476390 0x00000001804763A0-0x00000001804763B0
		public PanelScaleMode scaleMode { get; set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x00000001805D5550-0x00000001805D5560
		public float referenceSpritePixelsPerUnit { get; set; } // 0x0000000181D8CC60-0x0000000181D8CC70 0x0000000181F56C00-0x0000000181F56C10
		internal float pixelsPerUnit { get; set; } // 0x0000000180349420-0x0000000180349430 0x0000000180349430-0x0000000180349440
		float IPanelSettings.pixelsPerUnit { get; } // 0x0000000180349420-0x0000000180349430 
		public float scale { get; set; } // 0x000000018047EDF0-0x000000018047EE00 0x0000000181D8BEF0-0x0000000181D8BF00
		public float referenceDpi { get; set; } // 0x0000000181D8CC50-0x0000000181D8CC60 0x00000001824A3850-0x00000001824A3880
		public float fallbackDpi { get; set; } // 0x0000000181D8CC80-0x0000000181D8CC90 0x00000001824A3800-0x00000001824A3830
		public Vector2Int referenceResolution { get; set; } // 0x00000001824A3750-0x00000001824A3760 0x00000001824A3880-0x00000001824A3890
		public PanelScreenMatchMode screenMatchMode { get; set; } // 0x000000018033D270-0x000000018033D280 0x000000018033E880-0x000000018033E890
		public float match { get; set; } // 0x0000000181D8CCA0-0x0000000181D8CCB0 0x0000000181DB5660-0x0000000181DB5670
		public float sortingOrder { get; set; } // 0x0000000182141FA0-0x0000000182141FB0 0x00000001824A3890-0x00000001824A38E0
		public int targetDisplay { get; set; } // 0x00000001803002C0-0x00000001803002D0 0x00000001824A38E0-0x00000001824A3920
		public BindingLogLevel bindingLogLevel { get; set; } // 0x0000000180C55C40-0x0000000180C55C50 0x00000001824A37A0-0x00000001824A37F0
		public bool clearDepthStencil { get; set; } // 0x0000000180643BD0-0x0000000180643BE0 0x0000000180C4A240-0x0000000180C4A250
		public float depthClearValue { get; } // 0x00000001824A36D0-0x00000001824A36E0 
		public bool clearColor { get; set; } // 0x000000018030D9D0-0x000000018030D9E0 0x00000001803CB1F0-0x00000001803CB200
		public Color colorClearValue { get; set; } // 0x00000001824A36C0-0x00000001824A36D0 0x00000001824A37F0-0x00000001824A3800
		public uint vertexBudget { get; set; } // 0x0000000180BE5CE0-0x0000000180BE5CF0 0x0000000180BE5D70-0x0000000180BE5D80
		public ExtraVertexChannels extraVertexChannels { get; set; } // 0x000000018033D620-0x000000018033D630 0x000000018033EC00-0x000000018033EC10
		public TextureSlotCount textureSlotCount { get; set; } // 0x000000018033D640-0x000000018033D650 0x000000018033EC20-0x000000018033EC30
		internal BaseRuntimePanel panel { [VisibleToOtherModules(new string[1] {"UnityEditor.VectorGraphicsModule" })] get; } // 0x00000001824A3720-0x00000001824A3750 
		internal bool isInitialized { get; } // 0x00000001824A36E0-0x00000001824A3700 
		[VisibleToOtherModules(new string[1] {"UnityEditor.VectorGraphicsModule" })]
		internal bool isTransient { get; set; } // 0x00000001824A3700-0x00000001824A3720 0x00000001824A3830-0x00000001824A3850
		internal VisualElement visualTree { get; } // 0x00000001824A3760-0x00000001824A37A0 
		public DynamicAtlasSettings dynamicAtlasSettings { get; set; } // 0x00000001805B5990-0x00000001805B59A0 0x00000001806CCE40-0x00000001806CCE60
		bool IPanelSettings.forceGammaRendering { get; } // 0x0000000181708F30-0x0000000181708F40 
		Rect IPanelSettings.targetRect { get; } // 0x0000000181C2D350-0x0000000181C2D360 
		float IPanelSettings.resolvedScale { get; } // 0x0000000182378CE0-0x0000000182378CF0 
		float IPanelSettings.screenDpi { get; } // 0x00000001824A2FB0-0x00000001824A2FC0 
	
		// Nested types
		private class RuntimePanelAccess // TypeDefIndex: 4189
		{
			// Fields
			private readonly PanelSettings m_Settings; // 0x10
			private BaseRuntimePanel m_RuntimePanel; // 0x18
			[CompilerGenerated]
			private bool _isTransient_k__BackingField; // 0x20
	
			// Properties
			internal bool isInitialized { get; } // 0x0000000180DAB6D0-0x0000000180DAB6E0 
			internal bool isTransient { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
			internal BaseRuntimePanel panel { get; } // 0x00000001824A7BD0-0x00000001824A7F40 
	
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 4190
			{
				// Fields
				public static UIElementsRuntimeUtility.CreateRuntimePanelDelegate _0___Create; // 0x00
			}
	
			// Constructors
			internal RuntimePanelAccess(PanelSettings settings); // 0x00000001803855F0-0x0000000180385630
	
			// Methods
			internal void DisposePanel(); // 0x00000001824A79A0-0x00000001824A7A40
			internal void SetTargetTexture(); // 0x00000001824A7B90-0x00000001824A7BD0
			internal void SetSortingPriority(); // 0x00000001824A7B20-0x00000001824A7B60
			internal void SetTargetDisplay(); // 0x00000001824A7B60-0x00000001824A7B90
			internal void SetPanelChangeReceiver(); // 0x00000001824A7AE0-0x00000001824A7B20
			private BaseRuntimePanel CreateRelatedRuntimePanel(); // 0x00000001824A7870-0x00000001824A79A0
			private void DisposeRelatedPanel(); // 0x00000001824A7A40-0x00000001824A7A90
			internal void MarkPotentiallyEmpty(); // 0x00000001824A7A90-0x00000001824A7AE0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass160_0 // TypeDefIndex: 4191
		{
			// Fields
			public Func<Vector2, Vector2> screenToPanelSpaceFunction; // 0x10
	
			// Constructors
			public __c__DisplayClass160_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Vector3 _SetScreenToPanelSpaceFunction_b__0(Vector2 p); // 0x00000001824AAAA0-0x00000001824AAB00
		}
	
		// Constructors
		private PanelSettings(); // 0x00000001824A3550-0x00000001824A36C0
	
		// Methods
		private float GetScreenDpiForScaleResolution(); // 0x00000001824A2FB0-0x00000001824A2FC0
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal void CacheDisplayRectAndScale(); // 0x00000001824A2C20-0x00000001824A2DC0
		internal void ApplySortingOrder(); // 0x00000001824A2900-0x00000001824A2940
		private void Reset(); // 0x00000001802E76C0-0x00000001802E76D0
		private void OnEnable(); // 0x00000001824A3380-0x00000001824A3390
		private void OnDisable(); // 0x00000001824A2E60-0x00000001824A2E90
		internal void DisposePanel(); // 0x00000001824A2E60-0x00000001824A2E90
		[Conditional("ENABLE_PROFILER")]
		public void SetPanelChangeReceiver(IDebugPanelChangeReceiver value); // 0x00000001824A3390-0x00000001824A33F0
		internal IDebugPanelChangeReceiver GetPanelChangeReceiver(); // 0x000000018170C2D0-0x000000018170C2E0
		private void ApplyThemeStyleSheet(VisualElement root = null); // 0x00000001824A2940-0x00000001824A2B30
		internal bool AssignICUData(); // 0x00000001802E7840-0x00000001802E7850
		private void InitializeShaders(); // 0x00000001824A2FC0-0x00000001824A3380
		[VisibleToOtherModules(new string[1] {"UnityEditor.VectorGraphicsModule" })]
		internal void ApplyPanelSettings(); // 0x00000001824A2720-0x00000001824A2900
		public void SetScreenToPanelSpaceFunction3D(Func<Vector2, Vector3> screenToPanelSpaceFunction); // 0x00000001824A33F0-0x00000001824A3450
		public void SetScreenToPanelSpaceFunction(Func<Vector2, Vector2> screenToPanelSpaceFunction); // 0x00000001824A3450-0x00000001824A3550
		internal Rect GetDisplayRect(); // 0x00000001824A2E90-0x00000001824A2FB0
		internal void AttachAndInsertPanelComponentToVisualTree(IPanelComponent panelComponent); // 0x00000001824A2B30-0x00000001824A2C20
		internal void DetachPanelComponent(IPanelComponent panelComponent); // 0x00000001824A2DC0-0x00000001824A2E60
	}
}
