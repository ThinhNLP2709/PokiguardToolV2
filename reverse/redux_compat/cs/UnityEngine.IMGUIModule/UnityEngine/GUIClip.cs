/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 23: UnityEngine.IMGUIModule.dll - Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13910-13956

namespace UnityEngine
{
	[NativeHeader("Modules/IMGUI/GUIClip.h")]
	[NativeHeader("Modules/IMGUI/GUIState.h")]
	[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEditor.UIBuilderModule" })]
	internal sealed class GUIClip // TypeDefIndex: 13922
	{
		// Properties
		internal static Rect visibleRect { [FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.GetVisibleRect")] get; } // 0x000000018227A5F0-0x000000018227A630 
		internal static Rect topmostRect { [FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.GetTopMostPhysicalRect")] [VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })] get; } // 0x000000018227A570-0x000000018227A5B0 
	
		// Nested types
		[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEditor.UIBuilderModule" })]
		internal struct ParentClipScope : IDisposable // TypeDefIndex: 13923
		{
			// Fields
			private bool m_Disposed; // 0x00
	
			// Constructors
			public ParentClipScope(Matrix4x4 objectTransform, Rect clipRect); // 0x000000018229B450-0x000000018229B4E0
	
			// Methods
			public void Dispose(); // 0x000000018229B410-0x000000018229B450
		}
	
		// Methods
		internal static void Internal_Push(Rect screenRect, Vector2 scrollOffset, Vector2 renderOffset, bool resetOffset); // 0x000000018227A210-0x000000018227A270
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static void Internal_Pop(); // 0x000000018227A020-0x000000018227A050
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.GetCount")]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static int Internal_GetCount(); // 0x0000000182279FC0-0x0000000182279FF0
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.GetTopRect")]
		internal static Rect GetTopRect(); // 0x0000000182279F80-0x0000000182279FC0
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.Unclip")]
		private static Vector2 Unclip_Vector2(Vector2 pos); // 0x000000018227A490-0x000000018227A4E0
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.UnclipToWindow")]
		private static Vector2 UnclipToWindow_Vector2(Vector2 pos); // 0x000000018227A3A0-0x000000018227A3F0
		[FreeFunction("GetGUIState().m_CanvasGUIState.m_GUIClipState.GetUserMatrix")]
		internal static Matrix4x4 GetMatrix(); // 0x0000000182279EF0-0x0000000182279F40
		internal static void SetMatrix(Matrix4x4 m); // 0x000000018227A310-0x000000018227A350
		internal static void Internal_PushParentClip(Matrix4x4 objectTransform, Rect clipRect); // 0x000000018227A0B0-0x000000018227A140
		internal static void Internal_PushParentClip(Matrix4x4 renderTransform, Matrix4x4 inputTransform, Rect clipRect); // 0x000000018227A140-0x000000018227A1A0
		internal static void Internal_PopParentClip(); // 0x0000000182279FF0-0x000000018227A020
		internal static void Push(Rect screenRect, Vector2 scrollOffset, Vector2 renderOffset, bool resetOffset); // 0x000000018227A270-0x000000018227A2D0
		internal static void Pop(); // 0x000000018227A020-0x000000018227A050
		public static Vector2 Unclip(Vector2 pos); // 0x000000018227A4E0-0x000000018227A530
		public static Vector2 UnclipToWindow(Vector2 pos); // 0x000000018227A3F0-0x000000018227A440
		private static void get_visibleRect_Injected(); // 0x000000018227A5B0-0x000000018227A5F0
		private static void get_topmostRect_Injected(); // 0x000000018227A530-0x000000018227A570
		private static void Internal_Push_Injected(in Rect screenRect, in Vector2 scrollOffset, in Vector2 renderOffset, bool resetOffset); // 0x000000018227A1A0-0x000000018227A210
		private static void GetTopRect_Injected(); // 0x0000000182279F40-0x0000000182279F80
		private static void Unclip_Vector2_Injected(in Vector2 pos, ); // 0x000000018227A440-0x000000018227A490
		private static void UnclipToWindow_Vector2_Injected(in Vector2 pos, ); // 0x000000018227A350-0x000000018227A3A0
		private static void GetMatrix_Injected(); // 0x0000000182279EB0-0x0000000182279EF0
		private static void SetMatrix_Injected(in Matrix4x4 m); // 0x000000018227A2D0-0x000000018227A310
		private static void Internal_PushParentClip_Injected(in Matrix4x4 renderTransform, in Matrix4x4 inputTransform, in Rect clipRect); // 0x000000018227A050-0x000000018227A0B0
	}
}
