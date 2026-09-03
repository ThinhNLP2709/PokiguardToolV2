/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI.Collections;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	public class CanvasUpdateRegistry // TypeDefIndex: 13015
	{
		// Fields
		private static CanvasUpdateRegistry s_Instance; // 0x00
		private bool m_PerformingLayoutUpdate; // 0x10
		private bool m_PerformingGraphicUpdate; // 0x11
		private static readonly ProfilerMarker[] m_CanvasUpdateMarkers; // 0x08
		private static readonly ProfilerMarker m_LayoutSortMarker; // 0x10
		private static readonly ProfilerMarker m_CullingUpdateMarker; // 0x18
		private readonly IndexedSet<ICanvasElement> m_LayoutRebuildQueue; // 0x18
		private readonly IndexedSet<ICanvasElement> m_GraphicRebuildQueue; // 0x20
		private static readonly Comparison<ICanvasElement> s_SortLayoutFunction; // 0x20
	
		// Properties
		public static CanvasUpdateRegistry instance { get; } // 0x0000000182361880-0x0000000182361A20 
	
		// Constructors
		protected CanvasUpdateRegistry(); // 0x0000000182361770-0x0000000182361880
		static CanvasUpdateRegistry(); // 0x00000001823614F0-0x0000000182361770
	
		// Methods
		private bool ObjectValidForUpdate(ICanvasElement element); // 0x0000000182360570-0x0000000182360640
		private void CleanInvalidItems(); // 0x000000018235FB50-0x000000018235FD00
		private void PerformUpdate(); // 0x00000001823606F0-0x0000000182361080
		private static int ParentCount(Transform child); // 0x0000000182360640-0x00000001823606F0
		private static int SortLayoutList(ICanvasElement x, ICanvasElement y); // 0x0000000182361140-0x00000001823611F0
		public static void RegisterCanvasElementForLayoutRebuild(ICanvasElement element); // 0x00000001823610E0-0x0000000182361140
		public static bool TryRegisterCanvasElementForLayoutRebuild(ICanvasElement element); // 0x0000000182361250-0x00000001823612B0
		private bool InternalRegisterCanvasElementForLayoutRebuild(ICanvasElement element); // 0x0000000182360220-0x00000001823602B0
		public static void RegisterCanvasElementForGraphicRebuild(ICanvasElement element); // 0x0000000182361080-0x00000001823610E0
		public static bool TryRegisterCanvasElementForGraphicRebuild(ICanvasElement element); // 0x00000001823611F0-0x0000000182361250
		private bool InternalRegisterCanvasElementForGraphicRebuild(ICanvasElement element); // 0x0000000182360160-0x0000000182360220
		public static void UnRegisterCanvasElementForRebuild(ICanvasElement element); // 0x00000001823612B0-0x00000001823614F0
		public static void DisableCanvasElementForRebuild(ICanvasElement element); // 0x000000018235FD00-0x000000018235FF40
		private void InternalUnRegisterCanvasElementForLayoutRebuild(ICanvasElement element); // 0x00000001823603C0-0x00000001823604D0
		private void InternalUnRegisterCanvasElementForGraphicRebuild(ICanvasElement element); // 0x00000001823602B0-0x00000001823603C0
		private void InternalDisableCanvasElementForLayoutRebuild(ICanvasElement element); // 0x0000000182360050-0x0000000182360160
		private void InternalDisableCanvasElementForGraphicRebuild(ICanvasElement element); // 0x000000018235FF40-0x0000000182360050
		public static bool IsRebuildingLayout(); // 0x0000000182360520-0x0000000182360570
		public static bool IsRebuildingGraphics(); // 0x00000001823604D0-0x0000000182360520
	}
}
