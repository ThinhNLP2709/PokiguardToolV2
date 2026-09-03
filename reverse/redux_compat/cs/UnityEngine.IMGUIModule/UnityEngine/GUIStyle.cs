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
using UnityEngine.TextCore.Text;

// Image 23: UnityEngine.IMGUIModule.dll - Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13910-13956

namespace UnityEngine
{
	[Serializable]
	[NativeHeader("IMGUIScriptingClasses.h")]
	[NativeHeader("Modules/IMGUI/GUIStyle.bindings.h")]
	[RequiredByNativeCode]
	public sealed class GUIStyle // TypeDefIndex: 13938
	{
		// Fields
		[NonSerialized]
		internal IntPtr m_Ptr; // 0x10
		[NonSerialized]
		private GUIStyleState m_Normal; // 0x18
		[NonSerialized]
		private GUIStyleState m_Hover; // 0x20
		[NonSerialized]
		private GUIStyleState m_Active; // 0x28
		[NonSerialized]
		private GUIStyleState m_Focused; // 0x30
		[NonSerialized]
		private GUIStyleState m_OnNormal; // 0x38
		[NonSerialized]
		private GUIStyleState m_OnHover; // 0x40
		[NonSerialized]
		private GUIStyleState m_OnActive; // 0x48
		[NonSerialized]
		private GUIStyleState m_OnFocused; // 0x50
		[NonSerialized]
		private RectOffset m_Border; // 0x58
		[NonSerialized]
		private RectOffset m_Padding; // 0x60
		[NonSerialized]
		private RectOffset m_Margin; // 0x68
		[NonSerialized]
		private RectOffset m_Overflow; // 0x70
		[NonSerialized]
		private string m_Name; // 0x78
		[AutoStaticsCleanupOnCodeReload]
		internal static bool showKeyboardFocus; // 0x00
		[NoAutoStaticsCleanup]
		private static GUIStyle s_None; // 0x08
		[NoAutoStaticsCleanup]
		internal static bool? useAdvancedText; // 0x10
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x18
	
		// Properties
		[NativeProperty("Name", false, TargetType.Function)]
		internal string rawName { get; set; } // 0x0000000182288CE0-0x0000000182288E10 0x0000000182289580-0x0000000182289740
		[NativeProperty("Font", false, TargetType.Function)]
		public Font font { get; } // 0x00000001822883D0-0x0000000182288480 
		[NativeProperty("m_ImagePosition", false, TargetType.Field)]
		public ImagePosition imagePosition { get; } // 0x00000001822884C0-0x0000000182288550 
		[NativeProperty("m_Alignment", false, TargetType.Field)]
		public TextAnchor alignment { get; } // 0x0000000182287E00-0x0000000182287E90 
		[NativeProperty("m_WordWrap", false, TargetType.Field)]
		public bool wordWrap { get; set; } // 0x00000001822890C0-0x0000000182289150 0x0000000182289A60-0x0000000182289B00
		[NativeProperty("m_Clipping", false, TargetType.Field)]
		public TextClipping clipping { get; } // 0x0000000182287ED0-0x0000000182287F60 
		[NativeProperty("m_ContentOffset", false, TargetType.Field)]
		public Vector2 contentOffset { get; set; } // 0x0000000182287FB0-0x0000000182288050 0x0000000182289290-0x0000000182289330
		[NativeProperty("m_FixedWidth", false, TargetType.Field)]
		public float fixedWidth { get; } // 0x0000000182288160-0x00000001822881F0 
		[NativeProperty("m_FixedHeight", false, TargetType.Field)]
		public float fixedHeight { get; } // 0x0000000182288090-0x0000000182288120 
		[NativeProperty("m_StretchWidth", false, TargetType.Field)]
		public bool stretchWidth { get; set; } // 0x0000000182288FF0-0x0000000182289080 0x0000000182289970-0x0000000182289A10
		[NativeProperty("m_StretchHeight", false, TargetType.Field)]
		public bool stretchHeight { get; set; } // 0x0000000182288F20-0x0000000182288FB0 0x0000000182289880-0x0000000182289920
		[NativeProperty("m_FontSize", false, TargetType.Field)]
		public int fontSize { get; set; } // 0x0000000182288230-0x00000001822882C0 0x0000000182289370-0x0000000182289410
		[NativeProperty("m_FontStyle", false, TargetType.Field)]
		public FontStyle fontStyle { get; set; } // 0x0000000182288300-0x0000000182288390 0x0000000182289450-0x00000001822894F0
		[NativeProperty("m_RichText", false, TargetType.Field)]
		public bool richText { get; set; } // 0x0000000182288E50-0x0000000182288EE0 0x0000000182289790-0x0000000182289830
		[NativeProperty("m_ClipOffset", false, TargetType.Field)]
		internal Vector2 Internal_clipOffset { get; set; } // 0x0000000182287D20-0x0000000182287DC0 0x00000001822891A0-0x0000000182289240
		public string name { get; set; } // 0x00000001822889C0-0x0000000182288A00 0x00000001822894F0-0x0000000182289530
		public GUIStyleState normal { get; } // 0x0000000182288AA0-0x0000000182288BA0 
		public RectOffset margin { get; } // 0x00000001822888D0-0x00000001822889C0 
		public RectOffset padding { get; } // 0x0000000182288BA0-0x0000000182288C90 
		public float lineHeight { get; } // 0x00000001822886E0-0x00000001822888D0 
		public static GUIStyle none { get; } // 0x0000000182288A00-0x0000000182288AA0 
		public bool isHeightDependantOnWidth { get; } // 0x0000000182288550-0x00000001822886E0 
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 13939
		{
			// Methods
			public static IntPtr ConvertToNative(GUIStyle guiStyle); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public GUIStyle(); // 0x0000000182287C50-0x0000000182287CD0
		public GUIStyle(GUIStyle other); // 0x0000000182287B40-0x0000000182287C50
		static GUIStyle(); // 0x0000000182287A00-0x0000000182287B40
	
		// Methods
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_Create", IsThreadSafe = true)]
		private static IntPtr Internal_Create([UnityMarshalAs(NativeType.ScriptingObjectPtr)] GUIStyle self); // 0x0000000182286C80-0x0000000182286CC0
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_Copy", IsThreadSafe = true)]
		private static IntPtr Internal_Copy([UnityMarshalAs(NativeType.ScriptingObjectPtr)] GUIStyle self, GUIStyle other); // 0x0000000182286C00-0x0000000182286C80
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_Destroy", IsThreadSafe = true)]
		private static void Internal_Destroy(IntPtr self); // 0x0000000182286D00-0x0000000182286D40
		[FreeFunction(Name = "GUIStyle_Bindings::GetStyleStatePtr", IsThreadSafe = true, HasExplicitThis = true)]
		private IntPtr GetStyleStatePtr(int idx); // 0x00000001822863F0-0x0000000182286490
		[FreeFunction(Name = "GUIStyle_Bindings::GetRectOffsetPtr", HasExplicitThis = true)]
		private IntPtr GetRectOffsetPtr(int idx); // 0x0000000182286310-0x00000001822863B0
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_Draw", HasExplicitThis = true)]
		private void Internal_Draw(Rect screenRect, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus); // 0x0000000182287220-0x0000000182287310
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_Draw2", HasExplicitThis = true)]
		private void Internal_Draw2(Rect position, GUIContent content, int controlID, bool on); // 0x0000000182286DB0-0x0000000182286E80
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_DrawCursor", HasExplicitThis = true)]
		private void Internal_DrawCursor(Rect position, GUIContent content, Vector2 pos, Color cursorColor); // 0x0000000182286EF0-0x0000000182286FB0
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_DrawWithTextSelection", HasExplicitThis = true)]
		private void Internal_DrawWithTextSelection(Rect screenRect, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus, bool drawSelectionAsComposition, Vector2 cursorFirstPosition, Vector2 cursorLastPosition, Color cursorColor, Color selectionColor); // 0x0000000182287060-0x0000000182287190
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_CalcSizeWithConstraints", HasExplicitThis = true)]
		internal Vector2 Internal_CalcSizeWithConstraints(GUIContent content, Vector2 maxSize); // 0x0000000182286AF0-0x0000000182286BB0
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_CalcHeight", HasExplicitThis = true)]
		private float Internal_CalcHeight(GUIContent content, float width); // 0x00000001822842A0-0x0000000182284350
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_CalcMinMaxWidth", HasExplicitThis = true)]
		private Vector2 Internal_CalcMinMaxWidth(GUIContent content); // 0x00000001822869D0-0x0000000182286A80
		private static void ManagedSerializationPostDispatchHook(object wrapper, IntPtr nativePtr); // 0x0000000182287640-0x00000001822876B0
		[RequiredByNativeCode]
		internal static IntPtr GetGUIStylePostDispatchHookFunctionPointer(); // 0x00000001822860B0-0x00000001822860F0
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_GetTextRectOffset", HasExplicitThis = true)]
		internal Vector2 Internal_GetTextRectOffset(Rect screenRect, GUIContent content, Vector2 textSize); // 0x00000001822873B0-0x0000000182287470
		[FreeFunction(Name = "GUIStyle_Bindings::SetMouseTooltip")]
		internal static void SetMouseTooltip(string tooltip, Rect screenRect); // 0x00000001822877B0-0x0000000182287940
		[FreeFunction(Name = "GUIStyle_Bindings::IsTooltipActive")]
		internal static bool IsTooltipActive(string tooltip); // 0x00000001822874B0-0x0000000182287640
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_GetCursorFlashOffset")]
		private static float Internal_GetCursorFlashOffset(); // 0x0000000182287310-0x0000000182287340
		[FreeFunction(Name = "GUIStyle::SetDefaultFont")]
		internal static void SetDefaultFont(Font font); // 0x00000001822876F0-0x0000000182287760
		[FreeFunction(Name = "GUIStyle::GetDefaultFont")]
		internal static Font GetDefaultFont(); // 0x0000000182285F10-0x0000000182285F90
		[FreeFunction(Name = "GUIStyle_Bindings::Internal_DestroyTextGenerator")]
		internal static void Internal_DestroyTextGenerator(int meshInfoId); // 0x0000000182286CC0-0x0000000182286D00
		~GUIStyle(); // 0x00000001822858B0-0x0000000182285990
		internal void InternalOnAfterDeserialize(); // 0x0000000182286490-0x0000000182286910
		public void Draw(Rect position, bool isHover, bool isActive, bool on, bool hasKeyboardFocus); // 0x0000000182285490-0x00000001822855D0
		public void Draw(Rect position, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus); // 0x00000001822853A0-0x0000000182285490
		public void Draw(Rect position, GUIContent content, int controlID); // 0x00000001822855D0-0x0000000182285610
		public void Draw(Rect position, GUIContent content, int controlID, bool on); // 0x00000001822851D0-0x0000000182285210
		public void Draw(Rect position, GUIContent content, int controlID, bool on, bool hover); // 0x0000000182285610-0x00000001822857F0
		private void Draw(Rect position, GUIContent content, int controlId, bool isHover, bool isActive, bool on, bool hasKeyboardFocus); // 0x0000000182285210-0x00000001822853A0
		public void DrawCursor(Rect position, GUIContent content, int controlID, int character); // 0x0000000182284510-0x0000000182284850
		internal void DrawWithTextSelection(Rect position, GUIContent content, bool isActive, bool hasKeyboardFocus, int firstSelectedCharacter, int lastSelectedCharacter, bool drawSelectionAsComposition, Color selectionColor); // 0x0000000182284850-0x0000000182284D60
		internal void DrawWithTextSelection(Rect position, GUIContent content, int controlID, int firstSelectedCharacter, int lastSelectedCharacter, bool drawSelectionAsComposition); // 0x0000000182284F90-0x00000001822851D0
		public void DrawWithTextSelection(Rect position, GUIContent content, int controlID, int firstSelectedCharacter, int lastSelectedCharacter); // 0x0000000182284D60-0x0000000182284F90
		public Vector2 GetCursorPixelPosition(Rect position, GUIContent content, int cursorStringIndex); // 0x0000000182285990-0x0000000182285EE0
		internal Vector2 CalcSizeWithConstraints(GUIContent content, Vector2 constraints); // 0x0000000182284420-0x0000000182284510
		public float CalcHeight(GUIContent content, float width); // 0x00000001822842A0-0x0000000182284350
		internal Vector2 GetPreferredSize(string content, Rect rect); // 0x00000001822861E0-0x00000001822862D0
		public void CalcMinMaxWidth(GUIContent content, out float minWidth, out float maxWidth); // 0x0000000182284350-0x0000000182284420
		public override string ToString(); // 0x0000000182287940-0x00000001822879B0
		[RequiredByNativeCode]
		internal static void GetMeshInfo(GUIStyle style, Color color, string content, Rect rect, ref MeshInfoBindings[] meshInfos, ref Vector2 dimensions, ref int generationId); // 0x0000000182286120-0x00000001822861E0
		[RequiredByNativeCode]
		internal static void GetDimensions(GUIStyle style, Color color, string content, Rect rect, ref Vector2 dimensions); // 0x0000000182285F90-0x00000001822860B0
		[RequiredByNativeCode]
		internal static void GetLineHeight(GUIStyle style, ref float lineHeight); // 0x00000001822860F0-0x0000000182286120
		[RequiredByNativeCode]
		internal static void EmptyManagedCache(); // 0x00000001822857F0-0x00000001822858B0
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001822879B0-0x0000000182287A00
		private static void get_rawName_Injected(IntPtr _unity_self, ); // 0x0000000182288C90-0x0000000182288CE0
		private static void set_rawName_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value); // 0x0000000182289530-0x0000000182289580
		private static IntPtr get_font_Injected(IntPtr _unity_self); // 0x0000000182288390-0x00000001822883D0
		private static ImagePosition get_imagePosition_Injected(IntPtr _unity_self); // 0x0000000182288480-0x00000001822884C0
		private static TextAnchor get_alignment_Injected(IntPtr _unity_self); // 0x0000000182287DC0-0x0000000182287E00
		private static bool get_wordWrap_Injected(IntPtr _unity_self); // 0x0000000182289080-0x00000001822890C0
		private static void set_wordWrap_Injected(IntPtr _unity_self, bool value); // 0x0000000182289A10-0x0000000182289A60
		private static TextClipping get_clipping_Injected(IntPtr _unity_self); // 0x0000000182287E90-0x0000000182287ED0
		private static void get_contentOffset_Injected(IntPtr _unity_self, ); // 0x0000000182287F60-0x0000000182287FB0
		private static void set_contentOffset_Injected(IntPtr _unity_self, in Vector2 value); // 0x0000000182289240-0x0000000182289290
		private static float get_fixedWidth_Injected(IntPtr _unity_self); // 0x0000000182288120-0x0000000182288160
		private static float get_fixedHeight_Injected(IntPtr _unity_self); // 0x0000000182288050-0x0000000182288090
		private static bool get_stretchWidth_Injected(IntPtr _unity_self); // 0x0000000182288FB0-0x0000000182288FF0
		private static void set_stretchWidth_Injected(IntPtr _unity_self, bool value); // 0x0000000182289920-0x0000000182289970
		private static bool get_stretchHeight_Injected(IntPtr _unity_self); // 0x0000000182288EE0-0x0000000182288F20
		private static void set_stretchHeight_Injected(IntPtr _unity_self, bool value); // 0x0000000182289830-0x0000000182289880
		private static int get_fontSize_Injected(IntPtr _unity_self); // 0x00000001822881F0-0x0000000182288230
		private static void set_fontSize_Injected(IntPtr _unity_self, int value); // 0x0000000182289330-0x0000000182289370
		private static FontStyle get_fontStyle_Injected(IntPtr _unity_self); // 0x00000001822882C0-0x0000000182288300
		private static void set_fontStyle_Injected(IntPtr _unity_self, FontStyle value); // 0x0000000182289410-0x0000000182289450
		private static bool get_richText_Injected(IntPtr _unity_self); // 0x0000000182288E10-0x0000000182288E50
		private static void set_richText_Injected(IntPtr _unity_self, bool value); // 0x0000000182289740-0x0000000182289790
		private static void get_Internal_clipOffset_Injected(IntPtr _unity_self, ); // 0x0000000182287CD0-0x0000000182287D20
		private static void set_Internal_clipOffset_Injected(IntPtr _unity_self, in Vector2 value); // 0x0000000182289150-0x00000001822891A0
		private static IntPtr Internal_Copy_Injected(GUIStyle self, IntPtr other); // 0x0000000182286BB0-0x0000000182286C00
		private static IntPtr GetStyleStatePtr_Injected(IntPtr _unity_self, int idx); // 0x00000001822863B0-0x00000001822863F0
		private static IntPtr GetRectOffsetPtr_Injected(IntPtr _unity_self, int idx); // 0x00000001822862D0-0x0000000182286310
		private static void Internal_Draw_Injected(IntPtr _unity_self, in Rect screenRect, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus); // 0x0000000182287190-0x0000000182287220
		private static void Internal_Draw2_Injected(IntPtr _unity_self, in Rect position, GUIContent content, int controlID, bool on); // 0x0000000182286D40-0x0000000182286DB0
		private static void Internal_DrawCursor_Injected(IntPtr _unity_self, in Rect position, GUIContent content, in Vector2 pos, in Color cursorColor); // 0x0000000182286E80-0x0000000182286EF0
		private static void Internal_DrawWithTextSelection_Injected(IntPtr _unity_self, in Rect screenRect, GUIContent content, bool isHover, bool isActive, bool on, bool hasKeyboardFocus, bool drawSelectionAsComposition, in Vector2 cursorFirstPosition, in Vector2 cursorLastPosition, in Color cursorColor, in Color selectionColor); // 0x0000000182286FB0-0x0000000182287060
		private static void Internal_CalcSizeWithConstraints_Injected(IntPtr _unity_self, GUIContent content, in Vector2 maxSize, ); // 0x0000000182286A80-0x0000000182286AF0
		private static float Internal_CalcHeight_Injected(IntPtr _unity_self, GUIContent content, float width); // 0x0000000182286910-0x0000000182286970
		private static void Internal_CalcMinMaxWidth_Injected(IntPtr _unity_self, GUIContent content, ); // 0x0000000182286970-0x00000001822869D0
		private static void Internal_GetTextRectOffset_Injected(IntPtr _unity_self, in Rect screenRect, GUIContent content, in Vector2 textSize, ); // 0x0000000182287340-0x00000001822873B0
		private static void SetMouseTooltip_Injected(ref ManagedSpanWrapper tooltip, in Rect screenRect); // 0x0000000182287760-0x00000001822877B0
		private static bool IsTooltipActive_Injected(ref ManagedSpanWrapper tooltip); // 0x0000000182287470-0x00000001822874B0
		private static void SetDefaultFont_Injected(IntPtr font); // 0x00000001822876B0-0x00000001822876F0
		private static IntPtr GetDefaultFont_Injected(); // 0x0000000182285EE0-0x0000000182285F10
	}
}
