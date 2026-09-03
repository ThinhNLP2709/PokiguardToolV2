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
using UnityEngineInternal;

// Image 23: UnityEngine.IMGUIModule.dll - Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13910-13956

namespace UnityEngine
{
	[NativeHeader("Modules/IMGUI/GUI.bindings.h")]
	[NativeHeader("Modules/IMGUI/GUISkin.bindings.h")]
	public class GUI // TypeDefIndex: 13920
	{
		// Fields
		[NoAutoStaticsCleanup]
		private static int s_ScrollControlId; // 0x00
		[AutoStaticsCleanupOnCodeReload]
		private static int s_HotTextField; // 0x04
		private static readonly int s_BoxHash; // 0x08
		private static readonly int s_ButonHash; // 0x0C
		private static readonly int s_RepeatButtonHash; // 0x10
		private static readonly int s_ToggleHash; // 0x14
		private static readonly int s_ButtonGridHash; // 0x18
		private static readonly int s_SliderHash; // 0x1C
		private static readonly int s_BeginGroupHash; // 0x20
		private static readonly int s_ScrollviewHash; // 0x24
		[CompilerGenerated]
		private static int _scrollTroughSide_k__BackingField; // 0x28
		[CompilerGenerated]
		private static DateTime _nextScrollStepTime_k__BackingField; // 0x30
		[AutoStaticsCleanupOnCodeReload]
		private static GUISkin s_Skin; // 0x38
		[NoAutoStaticsCleanup]
		internal static Rect s_ToolTipRect; // 0x40
		[CompilerGenerated]
		private static GenericStack _scrollViewStates_k__BackingField; // 0x50
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x58
	
		// Properties
		public static Color color { get; set; } // 0x0000000182295CC0-0x0000000182295D30 0x00000001822962C0-0x0000000182296330
		public static Color backgroundColor { get; set; } // 0x0000000182295A80-0x0000000182295AF0 0x00000001822961D0-0x0000000182296240
		public static Color contentColor { get; set; } // 0x0000000182295D70-0x0000000182295DE0 0x0000000182296370-0x00000001822963E0
		public static bool changed { get; set; } // 0x0000000182295C50-0x0000000182295C80 0x0000000182296240-0x0000000182296280
		public static bool enabled { get; set; } // 0x0000000182295DE0-0x0000000182295E10 0x00000001822963E0-0x0000000182296420
		internal static bool usePageScrollbars { get; } // 0x0000000182296160-0x0000000182296190 
		internal static Material blendMaterial { [FreeFunction("GetGUIBlendMaterial")] get; } // 0x0000000182295B20-0x0000000182295BA0 
		internal static Material blitMaterial { [FreeFunction("GetGUIBlitMaterial")] get; } // 0x0000000182295BD0-0x0000000182295C50 
		internal static Material roundedRectMaterial { [FreeFunction("GetGUIRoundedRectMaterial")] get; } // 0x0000000182295F10-0x0000000182295F90 
		internal static Material roundedRectWithColorPerBorderMaterial { [FreeFunction("GetGUIRoundedRectWithColorPerBorderMaterial")] get; } // 0x0000000182295FC0-0x0000000182296040 
		[NoAutoStaticsCleanup]
		internal static int scrollTroughSide { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182296040-0x0000000182296090 0x00000001822964E0-0x0000000182296540
		[NoAutoStaticsCleanup]
		internal static DateTime nextScrollStepTime { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182295E90-0x0000000182295EE0 0x0000000182296480-0x00000001822964E0
		public static GUISkin skin { get; set; } // 0x00000001822960E0-0x0000000182296160 0x00000001822965B0-0x0000000182296630
		public static Matrix4x4 matrix { get; set; } // 0x0000000182295E10-0x0000000182295E90 0x0000000182296420-0x0000000182296480
		[AutoStaticsCleanupOnCodeReload]
		internal static GenericStack scrollViewStates { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000182296090-0x00000001822960E0 0x0000000182296540-0x00000001822965B0
	
		// Nested types
		public delegate void WindowFunction(int id); // TypeDefIndex: 13921; 0x00000001804A78A0-0x00000001804A78B0
	
		// Constructors
		static GUI(); // 0x0000000182295670-0x0000000182295A40
	
		// Methods
		internal static void GrabMouseControl(int id); // 0x0000000182292710-0x0000000182292750
		internal static bool HasMouseControl(int id); // 0x0000000182293790-0x00000001822937D0
		internal static void ReleaseMouseControl(); // 0x0000000182293D70-0x0000000182293DA0
		internal static void InternalRepaintEditorWindow(); // 0x0000000182293A20-0x0000000182293A50
		internal static void DoSetSkin(GUISkin newSkin); // 0x000000018228F360-0x000000018228F5D0
		public static void Label(Rect position, string text); // 0x0000000182293A50-0x0000000182293B70
		public static void Label(Rect position, GUIContent content, GUIStyle style); // 0x0000000182293B70-0x0000000182293C10
		public static void DrawTexture(Rect position, Texture image); // 0x0000000182291380-0x0000000182291470
		public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode); // 0x00000001822912C0-0x0000000182291380
		public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend); // 0x000000018228FEC0-0x000000018228FF60
		public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect); // 0x0000000182290BE0-0x0000000182290FA0
		public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect, Color color, float borderWidth, float borderRadius); // 0x0000000182290FA0-0x00000001822912C0
		public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect, Color color, Vector4 borderWidths, float borderRadius); // 0x000000018228FF60-0x00000001822901A0
		public static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect, Color color, Vector4 borderWidths, Vector4 borderRadiuses); // 0x0000000182290A60-0x0000000182290BE0
		internal static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect, Color color, Vector4 borderWidths, Vector4 borderRadiuses, bool drawSmoothCorners); // 0x0000000182290910-0x0000000182290A60
		internal static void DrawTexture(Rect position, Texture image, ScaleMode scaleMode, bool alphaBlend, float imageAspect, Color leftColor, Color topColor, Color rightColor, Color bottomColor, Vector4 borderWidths, Vector4 borderRadiuses, bool drawSmoothCorners); // 0x00000001822901A0-0x0000000182290910
		internal static bool CalculateScaledTextureRects(Rect position, ScaleMode scaleMode, float imageAspect, ref Rect outScreenRect, ref Rect outSourceRect); // 0x000000018228DE40-0x000000018228E040
		public static void DrawTextureWithTexCoords(Rect position, Texture image, Rect texCoords); // 0x000000018228FA50-0x000000018228FAE0
		public static void DrawTextureWithTexCoords(Rect position, Texture image, Rect texCoords, bool alphaBlend); // 0x000000018228FAE0-0x000000018228FEC0
		public static void Box(Rect position, string text); // 0x000000018228D7E0-0x000000018228D8A0
		public static void Box(Rect position, GUIContent content); // 0x000000018228D750-0x000000018228D7E0
		public static void Box(Rect position, GUIContent content, GUIStyle style); // 0x000000018228D510-0x000000018228D750
		public static bool Button(Rect position, string text); // 0x000000018228D8A0-0x000000018228D960
		public static bool Button(Rect position, GUIContent content, GUIStyle style); // 0x000000018228D960-0x000000018228DC10
		internal static bool Button(Rect position, int id, GUIContent content, GUIStyle style); // 0x000000018228DC10-0x000000018228DE40
		private static bool DoRepeatButton(Rect position, GUIContent content, GUIStyle style, FocusType focusType); // 0x000000018228ED90-0x000000018228F360
		internal static string PasswordFieldGetStrToShow(string password, char maskChar); // 0x0000000182293C10-0x0000000182293D70
		internal static void DoTextField(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style); // 0x000000018228F5D0-0x000000018228F6C0
		internal static void DoTextField(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style, string secureText); // 0x000000018228F990-0x000000018228FA50
		internal static void DoTextField(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style, string secureText, char maskChar); // 0x000000018228F6C0-0x000000018228F990
		private static void HandleTextFieldEventForTouchscreen(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style, string secureText, char maskChar, TextEditor editor); // 0x0000000182293170-0x0000000182293790
		private static void HandleTextFieldEventForDesktop(Rect position, int id, GUIContent content, bool multiline, int maxLength, GUIStyle style, TextEditor editor); // 0x0000000182292750-0x0000000182293170
		internal static bool DoControl(Rect position, int id, bool on, bool hover, GUIContent content, GUIStyle style); // 0x000000018228E500-0x000000018228E980
		private static void DoLabel(Rect position, GUIContent content, GUIStyle style); // 0x000000018228E980-0x000000018228ED90
		internal static bool DoButton(Rect position, int id, GUIContent content, GUIStyle style); // 0x000000018228E390-0x000000018228E500
		public static float Slider(Rect position, float value, float size, float start, float end, GUIStyle slider, GUIStyle thumb, bool horiz, int id, GUIStyle thumbExtent = null); // 0x00000001822950C0-0x00000001822952A0
		public static float HorizontalScrollbar(Rect position, float value, float size, float leftValue, float rightValue, GUIStyle style); // 0x00000001822937D0-0x0000000182293A20
		internal static bool ScrollerRepeatButton(int scrollerID, Rect rect, GUIStyle style); // 0x00000001822941D0-0x0000000182294480
		public static float VerticalScrollbar(Rect position, float value, float size, float topValue, float bottomValue, GUIStyle style); // 0x00000001822952A0-0x00000001822954F0
		internal static float Scroller(Rect position, float value, float size, float leftValue, float rightValue, GUIStyle slider, GUIStyle thumb, GUIStyle leftButton, GUIStyle rightButton, bool horiz); // 0x0000000182294480-0x00000001822950C0
		public static void BeginGroup(Rect position, GUIContent content, GUIStyle style); // 0x000000018228C860-0x000000018228C910
		internal static void BeginGroup(Rect position, GUIContent content, GUIStyle style, Vector2 scrollOffset); // 0x000000018228C500-0x000000018228C860
		public static void EndGroup(); // 0x0000000182291470-0x00000001822914E0
		internal static Vector2 BeginScrollView(Rect position, Vector2 scrollPosition, Rect viewRect, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background); // 0x000000018228C910-0x000000018228D510
		public static void EndScrollView(bool handleScrollWheel); // 0x00000001822914E0-0x00000001822925B0
		internal static ScrollViewState GetTopScrollView(); // 0x00000001822925B0-0x0000000182292710
		public static bool ScrollTowards(Rect position, float maxDelta); // 0x0000000182294000-0x00000001822941D0
		[RequiredByNativeCode]
		internal static bool ScrollTowardsFromNative(float positionX, float positionY, float positionWidth, float positionHeight, float maxDelta); // 0x0000000182293DA0-0x0000000182294000
		[RequiredByNativeCode]
		internal static void CallWindowDelegate(WindowFunction func, int id, EntityId entityId, GUISkin _skin, int forceRect, float width, float height, GUIStyle style); // 0x000000018228E040-0x000000018228E390
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x00000001822954F0-0x0000000182295670
		private static void get_color_Injected(); // 0x0000000182295C80-0x0000000182295CC0
		private static void set_color_Injected(in Color value); // 0x0000000182296280-0x00000001822962C0
		private static void get_backgroundColor_Injected(); // 0x0000000182295A40-0x0000000182295A80
		private static void set_backgroundColor_Injected(in Color value); // 0x0000000182296190-0x00000001822961D0
		private static void get_contentColor_Injected(); // 0x0000000182295D30-0x0000000182295D70
		private static void set_contentColor_Injected(in Color value); // 0x0000000182296330-0x0000000182296370
		private static IntPtr get_blendMaterial_Injected(); // 0x0000000182295AF0-0x0000000182295B20
		private static IntPtr get_blitMaterial_Injected(); // 0x0000000182295BA0-0x0000000182295BD0
		private static IntPtr get_roundedRectMaterial_Injected(); // 0x0000000182295EE0-0x0000000182295F10
		private static IntPtr get_roundedRectWithColorPerBorderMaterial_Injected(); // 0x0000000182295F90-0x0000000182295FC0
	}
}
