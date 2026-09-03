/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[AddComponentMenu("Event/Graphic Raycaster")]
	[RequireComponent(typeof(Canvas))]
	[UGUIHelpURL("GraphicRaycaster")]
	public class GraphicRaycaster : BaseRaycaster // TypeDefIndex: 13036
	{
		// Fields
		protected const int kNoEventMaskSet = -1; // Metadata: 0x006A76E4
		[FormerlySerializedAs("ignoreReversedGraphics")]
		[SerializeField]
		private bool m_IgnoreReversedGraphics; // 0x28
		[FormerlySerializedAs("blockingObjects")]
		[SerializeField]
		private BlockingObjects m_BlockingObjects; // 0x2C
		[SerializeField]
		protected LayerMask m_BlockingMask; // 0x30
		private Canvas m_Canvas; // 0x38
		[NonSerialized]
		private List<Graphic> m_RaycastResults; // 0x40
		[NonSerialized]
		private static readonly List<Graphic> s_SortedGraphics; // 0x00
	
		// Properties
		public override int sortOrderPriority { get; } // 0x000000018236CF70-0x000000018236CFD0 
		public override int renderOrderPriority { get; } // 0x000000018236CF10-0x000000018236CF70 
		public bool ignoreReversedGraphics { get; set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
		public BlockingObjects blockingObjects { get; set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001803FE010-0x00000001803FE020
		public LayerMask blockingMask { get; set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
		private Canvas canvas { get; } // 0x000000018236CDA0-0x000000018236CE30 
		public override Camera eventCamera { get; } // 0x000000018236CE30-0x000000018236CF10 
	
		// Nested types
		public enum BlockingObjects // TypeDefIndex: 13037
		{
			None = 0,
			TwoD = 1,
			ThreeD = 2,
			All = 3
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 13038
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Comparison<Graphic> __9__27_0; // 0x08
	
			// Constructors
			static __c(); // 0x000000018237A250-0x000000018237A990
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal int _Raycast_b__27_0(Graphic g1, Graphic g2); // 0x000000018237A0A0-0x000000018237A110
		}
	
		// Constructors
		protected GraphicRaycaster(); // 0x000000018236CD10-0x000000018236CDA0
		static GraphicRaycaster(); // 0x000000018236CC80-0x000000018236CD10
	
		// Methods
		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList); // 0x000000018236BE80-0x000000018236CC80
		private static void Raycast(Canvas canvas, Camera eventCamera, Vector2 pointerPosition, IList<Graphic> foundGraphics, List<Graphic> results); // 0x000000018236B8B0-0x000000018236BE80
	}
}
