/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Profiling;
using UnityEngine;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	public class TMP_UpdateManager // TypeDefIndex: 11922
	{
		// Fields
		private static TMP_UpdateManager s_Instance; // 0x00
		private readonly HashSet<EntityId> m_LayoutQueueLookup; // 0x10
		private readonly List<TMP_Text> m_LayoutRebuildQueue; // 0x18
		private readonly HashSet<EntityId> m_GraphicQueueLookup; // 0x20
		private readonly List<TMP_Text> m_GraphicRebuildQueue; // 0x28
		private readonly HashSet<EntityId> m_InternalUpdateLookup; // 0x30
		private readonly List<TMP_Text> m_InternalUpdateQueue; // 0x38
		private readonly HashSet<EntityId> m_CullingUpdateLookup; // 0x40
		private readonly List<TMP_Text> m_CullingUpdateQueue; // 0x48
		private static readonly ProfilerMarker k_RegisterTextObjectForUpdateMarker; // 0x08
		private static readonly ProfilerMarker k_RegisterTextElementForGraphicRebuildMarker; // 0x10
		private static readonly ProfilerMarker k_RegisterTextElementForCullingUpdateMarker; // 0x18
		private static readonly ProfilerMarker k_UnregisterTextObjectForUpdateMarker; // 0x20
		private static readonly ProfilerMarker k_UnregisterTextElementForGraphicRebuildMarker; // 0x28
	
		// Properties
		private static TMP_UpdateManager instance { get; } // 0x00000001820F2640-0x00000001820F26F0 
	
		// Constructors
		private TMP_UpdateManager(); // 0x00000001820F2400-0x00000001820F2640
		static TMP_UpdateManager(); // 0x00000001820F22B0-0x00000001820F2400
	
		// Methods
		internal static void RegisterTextObjectForUpdate(TMP_Text textObject); // 0x00000001820F1E90-0x00000001820F1FF0
		private void InternalRegisterTextObjectForUpdate(TMP_Text textObject); // 0x00000001820F1760-0x00000001820F1880
		public static void RegisterTextElementForLayoutRebuild(TMP_Text element); // 0x00000001820F1D30-0x00000001820F1E90
		private void InternalRegisterTextElementForLayoutRebuild(TMP_Text element); // 0x00000001820F1640-0x00000001820F1760
		public static void RegisterTextElementForGraphicRebuild(TMP_Text element); // 0x00000001820F1BD0-0x00000001820F1D30
		private void InternalRegisterTextElementForGraphicRebuild(TMP_Text element); // 0x00000001820F1520-0x00000001820F1640
		public static void RegisterTextElementForCullingUpdate(TMP_Text element); // 0x00000001820F1A70-0x00000001820F1BD0
		private void InternalRegisterTextElementForCullingUpdate(TMP_Text element); // 0x00000001820F1400-0x00000001820F1520
		private void OnCameraPreCull(); // 0x00000001820F1A60-0x00000001820F1A70
		private void DoRebuilds(); // 0x00000001820F1170-0x00000001820F1400
		internal static void UnRegisterTextObjectForUpdate(TMP_Text textObject); // 0x00000001820F21D0-0x00000001820F22B0
		public static void UnRegisterTextElementForRebuild(TMP_Text element); // 0x00000001820F1FF0-0x00000001820F21D0
		private void InternalUnRegisterTextElementForGraphicRebuild(TMP_Text element); // 0x00000001820F1880-0x00000001820F1920
		private void InternalUnRegisterTextElementForLayoutRebuild(TMP_Text element); // 0x00000001820F1920-0x00000001820F19C0
		private void InternalUnRegisterTextObjectForUpdate(TMP_Text textObject); // 0x00000001820F19C0-0x00000001820F1A60
	}
}
