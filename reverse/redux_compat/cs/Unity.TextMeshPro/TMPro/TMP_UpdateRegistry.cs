/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	public class TMP_UpdateRegistry // TypeDefIndex: 11923
	{
		// Fields
		private static TMP_UpdateRegistry s_Instance; // 0x00
		private readonly List<ICanvasElement> m_LayoutRebuildQueue; // 0x10
		private readonly HashSet<EntityId> m_LayoutQueueLookup; // 0x18
		private readonly List<ICanvasElement> m_GraphicRebuildQueue; // 0x20
		private readonly HashSet<EntityId> m_GraphicQueueLookup; // 0x28
	
		// Properties
		public static TMP_UpdateRegistry instance { get; } // 0x00000001820F35B0-0x00000001820F37B0 
	
		// Constructors
		protected TMP_UpdateRegistry(); // 0x00000001820F3430-0x00000001820F35B0
	
		// Methods
		public static void RegisterCanvasElementForLayoutRebuild(ICanvasElement element); // 0x00000001820F3090-0x00000001820F3220
		private bool InternalRegisterCanvasElementForLayoutRebuild(ICanvasElement element); // 0x00000001820F2890-0x00000001820F2A30
		public static void RegisterCanvasElementForGraphicRebuild(ICanvasElement element); // 0x00000001820F2F00-0x00000001820F3090
		private bool InternalRegisterCanvasElementForGraphicRebuild(ICanvasElement element); // 0x00000001820F26F0-0x00000001820F2890
		private void PerformUpdateForCanvasRendererObjects(); // 0x00000001820F2C30-0x00000001820F2EA0
		private void PerformUpdateForMeshRendererObjects(); // 0x00000001820F2EA0-0x00000001820F2F00
		public static void UnRegisterCanvasElementForRebuild(ICanvasElement element); // 0x00000001820F3220-0x00000001820F3430
		private void InternalUnRegisterCanvasElementForLayoutRebuild(ICanvasElement element); // 0x00000001820F2B30-0x00000001820F2C30
		private void InternalUnRegisterCanvasElementForGraphicRebuild(ICanvasElement element); // 0x00000001820F2A30-0x00000001820F2B30
	}
}
