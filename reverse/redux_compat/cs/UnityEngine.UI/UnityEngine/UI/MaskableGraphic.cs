/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	public abstract class MaskableGraphic : Graphic, IClippable, IMaskable, IMaterialModifier // TypeDefIndex: 13091
	{
		// Fields
		[NonSerialized]
		protected bool m_ShouldRecalculateStencil; // 0xA8
		[NonSerialized]
		protected Material m_MaskMaterial; // 0xB0
		[NonSerialized]
		private RectMask2D m_ParentMask; // 0xB8
		[SerializeField]
		private bool m_Maskable; // 0xC0
		private bool m_IsMaskingGraphic; // 0xC1
		[SerializeField]
		private CullStateChangedEvent m_OnCullStateChanged; // 0xC8
		[NonSerialized]
		protected int m_StencilValue; // 0xD0
		private readonly Vector3[] m_Corners; // 0xD8
	
		// Properties
		public CullStateChangedEvent onCullStateChanged { get; set; } // 0x00000001806CCB50-0x00000001806CCB60 0x00000001806CCD60-0x00000001806CCD80
		public bool maskable { get; set; } // 0x000000018183E570-0x000000018183E580 0x00000001825992F0-0x0000000182599320
		public bool isMaskingGraphic { get; set; } // 0x00000001816A4210-0x00000001816A4220 0x00000001825992E0-0x00000001825992F0
		private Rect rootCanvasRect { get; } // 0x0000000182598ED0-0x00000001825992E0 
		GameObject IClippable.gameObject { get; } // 0x00000001824B8920-0x00000001824B8930 
	
		// Nested types
		[Serializable]
		public class CullStateChangedEvent : UnityEvent<bool> // TypeDefIndex: 13092
		{
			// Constructors
			public CullStateChangedEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		// Constructors
		protected MaskableGraphic(); // 0x0000000182598E00-0x0000000182598ED0
	
		// Methods
		public virtual Material GetModifiedMaterial(Material baseMaterial); // 0x0000000182598520-0x00000001825987A0
		public virtual void Cull(Rect clipRect, bool validRect); // 0x00000001825983D0-0x0000000182598520
		private void UpdateCull(bool cull); // 0x0000000182598D30-0x0000000182598E00
		public virtual void SetClipRect(Rect clipRect, bool validRect); // 0x0000000182598A50-0x0000000182598AB0
		public virtual void SetClipSoftness(Vector2 clipSoftness); // 0x0000000182598AB0-0x0000000182598AF0
		protected override void OnEnable(); // 0x00000001825988C0-0x0000000182598920
		protected override void OnDisable(); // 0x0000000182598800-0x00000001825988C0
		protected override void OnTransformParentChanged(); // 0x0000000182598920-0x0000000182598980
		protected override void OnCanvasHierarchyChanged(); // 0x00000001825987A0-0x0000000182598800
		private void UpdateClipParent(); // 0x0000000182598AF0-0x0000000182598D30
		public virtual void RecalculateClipping(); // 0x00000001825989B0-0x00000001825989C0
		public virtual void RecalculateMasking(); // 0x00000001825989C0-0x0000000182598A50
		public override bool Raycast(Vector2 sp, Camera eventCamera); // 0x0000000182598980-0x00000001825989B0
	}
}
