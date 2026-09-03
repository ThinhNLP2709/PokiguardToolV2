/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 41: UnityEngine.UIModule.dll - Assembly: UnityEngine.UIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15192-15207

namespace UnityEngine
{
	[NativeClass("UI::Canvas", PersistentTypeId = 223)]
	[NativeHeader("Modules/UI/UIStructs.h")]
	[NativeHeader("Modules/UI/Canvas.h")]
	[NativeHeader("Modules/UI/CanvasManager.h")]
	[RequireComponent(typeof(RectTransform))]
	[UIModuleHelpURL("class-Canvas")]
	public sealed class Canvas : Behaviour // TypeDefIndex: 15203
	{
		// Fields
		[CompilerGenerated]
		private static WillRenderCanvases preWillRenderCanvases; // 0x00
		[CompilerGenerated]
		private static WillRenderCanvases willRenderCanvases; // 0x08
		[CompilerGenerated]
		private static Action<int> _externBeginRenderOverlays_k__BackingField; // 0x10
		[CompilerGenerated]
		private static Action<int, int> _externRenderOverlaysBefore_k__BackingField; // 0x18
		[CompilerGenerated]
		private static Action<int> _externEndRenderOverlays_k__BackingField; // 0x20
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x28
	
		// Properties
		public static BatchingInterval batchingInterval { get; set; } // 0x000000018257DAD0-0x000000018257DB30 0x000000018257F290-0x000000018257F3E0
		public RenderMode renderMode { get; set; } // 0x000000018257E3E0-0x000000018257E470 0x000000018257FB10-0x000000018257FBB0
		public bool isRootCanvas { get; } // 0x000000018257DD30-0x000000018257DDC0 
		public Rect pixelRect { get; } // 0x000000018257E150-0x000000018257E200 
		public float scaleFactor { get; set; } // 0x000000018257E760-0x000000018257E7F0 0x000000018257FC00-0x000000018257FCA0
		public float referencePixelsPerUnit { get; set; } // 0x000000018257E310-0x000000018257E3A0 0x000000018257FA30-0x000000018257FAD0
		public bool overridePixelPerfect { get; set; } // 0x000000018257DED0-0x000000018257DF60 0x000000018257F670-0x000000018257F710
		public bool vertexColorAlwaysGammaSpace { get; set; } // 0x000000018257EE90-0x000000018257EF20 0x0000000182580450-0x00000001825804F0
		public bool useReflectionProbes { get; set; } // 0x000000018257EDC0-0x000000018257EE50 0x0000000182580360-0x0000000182580400
		public bool pixelPerfect { get; set; } // 0x000000018257E070-0x000000018257E100 0x000000018257F850-0x000000018257F8F0
		public float planeDistance { get; set; } // 0x000000018257E240-0x000000018257E2D0 0x000000018257F940-0x000000018257F9E0
		public int renderOrder { get; } // 0x000000018257E4B0-0x000000018257E540 
		public bool overrideSorting { get; set; } // 0x000000018257DFA0-0x000000018257E030 0x000000018257F760-0x000000018257F800
		public int sortingOrder { get; set; } // 0x000000018257EB50-0x000000018257EBE0 0x00000001825800B0-0x0000000182580150
		public int targetDisplay { get; set; } // 0x000000018257EC20-0x000000018257ECB0 0x0000000182580190-0x0000000182580230
		public int sortingLayerID { get; set; } // 0x000000018257E900-0x000000018257E990 0x000000018257FDC0-0x000000018257FE60
		public int cachedSortingLayerValue { get; } // 0x000000018257DB70-0x000000018257DC00 
		public AdditionalCanvasShaderChannels additionalShaderChannels { get; set; } // 0x000000018257DA40-0x000000018257DAD0 0x000000018257F1F0-0x000000018257F290
		public string sortingLayerName { get; set; } // 0x000000018257E9E0-0x000000018257EB10 0x000000018257FEB0-0x0000000182580070
		public Canvas rootCanvas { get; } // 0x000000018257E670-0x000000018257E720 
		public Vector2 renderingDisplaySize { get; } // 0x000000018257E590-0x000000018257E630 
		public StandaloneRenderResize updateRectTransformForStandalone { get; set; } // 0x000000018257ECF0-0x000000018257ED80 0x0000000182580270-0x0000000182580310
		[AutoStaticsCleanupOnCodeReload]
		internal static Action<int> externBeginRenderOverlays { [CompilerGenerated] get; [VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })] [CompilerGenerated] set; } // 0x000000018257DC00-0x000000018257DC50 0x000000018257F3E0-0x000000018257F450
		[AutoStaticsCleanupOnCodeReload]
		internal static Action<int, int> externRenderOverlaysBefore { [CompilerGenerated] get; [VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })] [CompilerGenerated] set; } // 0x000000018257DCA0-0x000000018257DCF0 0x000000018257F4C0-0x000000018257F530
		[AutoStaticsCleanupOnCodeReload]
		internal static Action<int> externEndRenderOverlays { [CompilerGenerated] get; [CompilerGenerated] [VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })] set; } // 0x000000018257DC50-0x000000018257DCA0 0x000000018257F450-0x000000018257F4C0
		[NativeProperty("Camera", false, TargetType.Function)]
		public Camera worldCamera { get; set; } // 0x000000018257EF60-0x000000018257F010 0x0000000182580540-0x0000000182580600
		[NativeProperty("SortingBucketNormalizedSize", false, TargetType.Function)]
		public float normalizedSortingGridSize { get; set; } // 0x000000018257DE00-0x000000018257DE90 0x000000018257F580-0x000000018257F620
		[NativeProperty("SortingBucketNormalizedSize", false, TargetType.Function)]
		[Obsolete("Setting normalizedSize via a int is not supported. Please use normalizedSortingGridSize", false)]
		public int sortingGridNormalizedSize { get; set; } // 0x000000018257E830-0x000000018257E8C0 0x000000018257FCE0-0x000000018257FD80
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event WillRenderCanvases preWillRenderCanvases {
			add; // 0x000000018257D860-0x000000018257D930
			remove; // 0x000000018257F010-0x000000018257F0E0
		}
		[AutoStaticsCleanupOnCodeReload]
		public static event WillRenderCanvases willRenderCanvases {
			add; // 0x000000018257D930-0x000000018257DA00
			remove; // 0x000000018257F0E0-0x000000018257F1B0
		}
	
		// Nested types
		public enum BatchingInterval // TypeDefIndex: 15204
		{
			GatedByRendering = 0,
			AlwaysUpdate = 1
		}
	
		public delegate void WillRenderCanvases(); // TypeDefIndex: 15205; 0x0000000180313920-0x00000001803139C0
	
		// Constructors
		public Canvas(); // 0x00000001802E7A70-0x00000001802E7BC0
		static Canvas(); // 0x000000018257D740-0x000000018257D860
	
		// Methods
		[FreeFunction("UI::CanvasManager::SetBatchingInterval")]
		internal static void Internal_SetBatchingInterval(int value); // 0x000000018257CF20-0x000000018257CF60
		[FreeFunction("UI::CanvasManager::GetBatchingInterval")]
		internal static int Internal_GetBatchingInterval(); // 0x000000018257CEF0-0x000000018257CF20
		[FreeFunction("UI::CanvasManager::SetExternalCanvasEnabled")]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static void SetExternalCanvasEnabled(bool enabled); // 0x000000018257D100-0x000000018257D140
		[FreeFunction("UI::GetDefaultUIMaterial")]
		[Obsolete("Shared default material now used for text and general UI elements, call Canvas.GetDefaultCanvasMaterial()", false)]
		public static Material GetDefaultCanvasTextMaterial(); // 0x000000018257CDC0-0x000000018257CE40
		[FreeFunction("UI::GetDefaultUIMaterial")]
		public static Material GetDefaultCanvasMaterial(); // 0x000000018257CD10-0x000000018257CD90
		[FreeFunction("UI::GetETC1SupportedCanvasMaterial")]
		public static Material GetETC1SupportedCanvasMaterial(); // 0x000000018257CE70-0x000000018257CEF0
		internal void UpdateCanvasRectTransform(bool alignWithCamera); // 0x000000018257D190-0x000000018257D230
		public static void ForceUpdateCanvases(); // 0x000000018257CBE0-0x000000018257CCE0
		[RequiredByNativeCode]
		private static void SendPreWillRenderCanvases(); // 0x000000018257D020-0x000000018257D090
		[RequiredByNativeCode]
		private static void SendWillRenderCanvases(); // 0x000000018257D090-0x000000018257D100
		[RequiredByNativeCode]
		private static void BeginRenderExtraOverlays(int displayIndex); // 0x000000018257CA80-0x000000018257CB30
		[RequiredByNativeCode]
		private static void RenderExtraOverlaysBefore(int displayIndex, int sortingOrder); // 0x000000018257CF60-0x000000018257D020
		[RequiredByNativeCode]
		private static void EndRenderExtraOverlays(int displayIndex); // 0x000000018257CB30-0x000000018257CBE0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x000000018257D230-0x000000018257D740
		private static RenderMode get_renderMode_Injected(IntPtr _unity_self); // 0x000000018257E3A0-0x000000018257E3E0
		private static void set_renderMode_Injected(IntPtr _unity_self, RenderMode value); // 0x000000018257FAD0-0x000000018257FB10
		private static bool get_isRootCanvas_Injected(IntPtr _unity_self); // 0x000000018257DCF0-0x000000018257DD30
		private static void get_pixelRect_Injected(IntPtr _unity_self, ); // 0x000000018257E100-0x000000018257E150
		private static float get_scaleFactor_Injected(IntPtr _unity_self); // 0x000000018257E720-0x000000018257E760
		private static void set_scaleFactor_Injected(IntPtr _unity_self, float value); // 0x000000018257FBB0-0x000000018257FC00
		private static float get_referencePixelsPerUnit_Injected(IntPtr _unity_self); // 0x000000018257E2D0-0x000000018257E310
		private static void set_referencePixelsPerUnit_Injected(IntPtr _unity_self, float value); // 0x000000018257F9E0-0x000000018257FA30
		private static bool get_overridePixelPerfect_Injected(IntPtr _unity_self); // 0x000000018257DE90-0x000000018257DED0
		private static void set_overridePixelPerfect_Injected(IntPtr _unity_self, bool value); // 0x000000018257F620-0x000000018257F670
		private static bool get_vertexColorAlwaysGammaSpace_Injected(IntPtr _unity_self); // 0x000000018257EE50-0x000000018257EE90
		private static void set_vertexColorAlwaysGammaSpace_Injected(IntPtr _unity_self, bool value); // 0x0000000182580400-0x0000000182580450
		private static bool get_useReflectionProbes_Injected(IntPtr _unity_self); // 0x000000018257ED80-0x000000018257EDC0
		private static void set_useReflectionProbes_Injected(IntPtr _unity_self, bool value); // 0x0000000182580310-0x0000000182580360
		private static bool get_pixelPerfect_Injected(IntPtr _unity_self); // 0x000000018257E030-0x000000018257E070
		private static void set_pixelPerfect_Injected(IntPtr _unity_self, bool value); // 0x000000018257F800-0x000000018257F850
		private static float get_planeDistance_Injected(IntPtr _unity_self); // 0x000000018257E200-0x000000018257E240
		private static void set_planeDistance_Injected(IntPtr _unity_self, float value); // 0x000000018257F8F0-0x000000018257F940
		private static int get_renderOrder_Injected(IntPtr _unity_self); // 0x000000018257E470-0x000000018257E4B0
		private static bool get_overrideSorting_Injected(IntPtr _unity_self); // 0x000000018257DF60-0x000000018257DFA0
		private static void set_overrideSorting_Injected(IntPtr _unity_self, bool value); // 0x000000018257F710-0x000000018257F760
		private static int get_sortingOrder_Injected(IntPtr _unity_self); // 0x000000018257EB10-0x000000018257EB50
		private static void set_sortingOrder_Injected(IntPtr _unity_self, int value); // 0x0000000182580070-0x00000001825800B0
		private static int get_targetDisplay_Injected(IntPtr _unity_self); // 0x000000018257EBE0-0x000000018257EC20
		private static void set_targetDisplay_Injected(IntPtr _unity_self, int value); // 0x0000000182580150-0x0000000182580190
		private static int get_sortingLayerID_Injected(IntPtr _unity_self); // 0x000000018257E8C0-0x000000018257E900
		private static void set_sortingLayerID_Injected(IntPtr _unity_self, int value); // 0x000000018257FD80-0x000000018257FDC0
		private static int get_cachedSortingLayerValue_Injected(IntPtr _unity_self); // 0x000000018257DB30-0x000000018257DB70
		private static AdditionalCanvasShaderChannels get_additionalShaderChannels_Injected(IntPtr _unity_self); // 0x000000018257DA00-0x000000018257DA40
		private static void set_additionalShaderChannels_Injected(IntPtr _unity_self, AdditionalCanvasShaderChannels value); // 0x000000018257F1B0-0x000000018257F1F0
		private static void get_sortingLayerName_Injected(IntPtr _unity_self, ); // 0x000000018257E990-0x000000018257E9E0
		private static void set_sortingLayerName_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value); // 0x000000018257FE60-0x000000018257FEB0
		private static IntPtr get_rootCanvas_Injected(IntPtr _unity_self); // 0x000000018257E630-0x000000018257E670
		private static void get_renderingDisplaySize_Injected(IntPtr _unity_self, ); // 0x000000018257E540-0x000000018257E590
		private static StandaloneRenderResize get_updateRectTransformForStandalone_Injected(IntPtr _unity_self); // 0x000000018257ECB0-0x000000018257ECF0
		private static void set_updateRectTransformForStandalone_Injected(IntPtr _unity_self, StandaloneRenderResize value); // 0x0000000182580230-0x0000000182580270
		private static IntPtr get_worldCamera_Injected(IntPtr _unity_self); // 0x000000018257EF20-0x000000018257EF60
		private static void set_worldCamera_Injected(IntPtr _unity_self, IntPtr value); // 0x00000001825804F0-0x0000000182580540
		private static float get_normalizedSortingGridSize_Injected(IntPtr _unity_self); // 0x000000018257DDC0-0x000000018257DE00
		private static void set_normalizedSortingGridSize_Injected(IntPtr _unity_self, float value); // 0x000000018257F530-0x000000018257F580
		private static int get_sortingGridNormalizedSize_Injected(IntPtr _unity_self); // 0x000000018257E7F0-0x000000018257E830
		private static void set_sortingGridNormalizedSize_Injected(IntPtr _unity_self, int value); // 0x000000018257FCA0-0x000000018257FCE0
		private static IntPtr GetDefaultCanvasTextMaterial_Injected(); // 0x000000018257CD90-0x000000018257CDC0
		private static IntPtr GetDefaultCanvasMaterial_Injected(); // 0x000000018257CCE0-0x000000018257CD10
		private static IntPtr GetETC1SupportedCanvasMaterial_Injected(); // 0x000000018257CE40-0x000000018257CE70
		private static void UpdateCanvasRectTransform_Injected(IntPtr _unity_self, bool alignWithCamera); // 0x000000018257D140-0x000000018257D190
	}
}
