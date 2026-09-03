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

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[AddComponentMenu("UI (Canvas)/Rect Mask 2D", 14)]
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[UGUIHelpURL("RectMask2D")]
	public class RectMask2D : UIBehaviour, IClipper, ICanvasRaycastFilter // TypeDefIndex: 13100
	{
		// Fields
		[NonSerialized]
		private readonly RectangularVertexClipper m_VertexClipper; // 0x20
		[NonSerialized]
		private RectTransform m_RectTransform; // 0x28
		[NonSerialized]
		private HashSet<MaskableGraphic> m_MaskableTargets; // 0x30
		[NonSerialized]
		private HashSet<IClippable> m_ClipTargets; // 0x38
		[NonSerialized]
		private bool m_ShouldRecalculateClipRects; // 0x40
		[NonSerialized]
		private List<RectMask2D> m_Clippers; // 0x48
		[NonSerialized]
		private Rect m_LastClipRectCanvasSpace; // 0x50
		[NonSerialized]
		private bool m_ForceClip; // 0x60
		[SerializeField]
		private Vector4 m_Padding; // 0x64
		[SerializeField]
		private Vector2Int m_Softness; // 0x74
		[NonSerialized]
		private Canvas m_Canvas; // 0x80
		private Vector3[] m_Corners; // 0x88
	
		// Properties
		public Vector4 padding { get; set; } // 0x000000018259BD00-0x000000018259BD10 0x000000018259BF70-0x000000018259BF80
		public Vector2Int softness { get; set; } // 0x000000018259BF60-0x000000018259BF70 0x000000018259BF80-0x000000018259BFB0
		internal Canvas Canvas { get; } // 0x000000018259BB10-0x000000018259BC40 
		public Rect canvasRect { get; } // 0x000000018259BC40-0x000000018259BD00 
		public RectTransform rectTransform { get; } // 0x000000018259BD10-0x000000018259BD80 
		private Rect rootCanvasRect { get; } // 0x000000018259BD80-0x000000018259BF60 
	
		// Constructors
		protected RectMask2D(); // 0x000000018259B9A0-0x000000018259BB10
	
		// Methods
		protected override void OnEnable(); // 0x000000018259A950-0x000000018259A980
		protected override void OnDisable(); // 0x000000018259A8D0-0x000000018259A950
		protected override void OnDestroy(); // 0x000000018259A8B0-0x000000018259A8D0
		public virtual bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera); // 0x000000018259A760-0x000000018259A870
		public virtual void PerformClipping(); // 0x000000018259A980-0x000000018259B510
		public virtual void UpdateClipSoftness(); // 0x000000018259B6C0-0x000000018259B9A0
		public void AddClippable(IClippable clippable); // 0x000000018259A650-0x000000018259A760
		public void RemoveClippable(IClippable clippable); // 0x000000018259B510-0x000000018259B6C0
		protected override void OnTransformParentChanged(); // 0x000000018259A870-0x000000018259A8B0
		protected override void OnCanvasHierarchyChanged(); // 0x000000018259A870-0x000000018259A8B0
	}
}
