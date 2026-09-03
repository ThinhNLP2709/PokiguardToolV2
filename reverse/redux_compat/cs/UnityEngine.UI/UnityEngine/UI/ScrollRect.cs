/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	[AddComponentMenu("UI (Canvas)/Scroll Rect", 37)]
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[SelectionBase]
	[UGUIHelpURL("ScrollRect")]
	public class ScrollRect : UIBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IScrollHandler, ICanvasElement, ILayoutElement, ILayoutGroup // TypeDefIndex: 13105
	{
		// Fields
		[SerializeField]
		private RectTransform m_Content; // 0x20
		[SerializeField]
		private bool m_Horizontal; // 0x28
		[SerializeField]
		private bool m_Vertical; // 0x29
		[SerializeField]
		private MovementType m_MovementType; // 0x2C
		[SerializeField]
		private float m_Elasticity; // 0x30
		[SerializeField]
		private bool m_Inertia; // 0x34
		[SerializeField]
		private float m_DecelerationRate; // 0x38
		[SerializeField]
		private float m_ScrollSensitivity; // 0x3C
		[SerializeField]
		private RectTransform m_Viewport; // 0x40
		[SerializeField]
		private Scrollbar m_HorizontalScrollbar; // 0x48
		[SerializeField]
		private Scrollbar m_VerticalScrollbar; // 0x50
		[SerializeField]
		private ScrollbarVisibility m_HorizontalScrollbarVisibility; // 0x58
		[SerializeField]
		private ScrollbarVisibility m_VerticalScrollbarVisibility; // 0x5C
		[SerializeField]
		private float m_HorizontalScrollbarSpacing; // 0x60
		[SerializeField]
		private float m_VerticalScrollbarSpacing; // 0x64
		[SerializeField]
		private ScrollRectEvent m_OnValueChanged; // 0x68
		private Vector2 m_PointerStartLocalCursor; // 0x70
		protected Vector2 m_ContentStartPosition; // 0x78
		private RectTransform m_ViewRect; // 0x80
		protected Bounds m_ContentBounds; // 0x88
		private Bounds m_ViewBounds; // 0xA0
		private Vector2 m_Velocity; // 0xB8
		private bool m_Dragging; // 0xC0
		private bool m_Scrolling; // 0xC1
		private Vector2 m_PrevPosition; // 0xC4
		private Bounds m_PrevContentBounds; // 0xCC
		private Bounds m_PrevViewBounds; // 0xE4
		[NonSerialized]
		private bool m_HasRebuiltLayout; // 0xFC
		private bool m_HSliderExpand; // 0xFD
		private bool m_VSliderExpand; // 0xFE
		private float m_HSliderHeight; // 0x100
		private float m_VSliderWidth; // 0x104
		[NonSerialized]
		private RectTransform m_Rect; // 0x108
		private RectTransform m_HorizontalScrollbarRect; // 0x110
		private RectTransform m_VerticalScrollbarRect; // 0x118
		private DrivenRectTransformTracker m_Tracker; // 0x120
		private readonly Vector3[] m_Corners; // 0x128
	
		// Properties
		public RectTransform content { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public bool horizontal { get; set; } // 0x0000000180327270-0x0000000180327280 0x00000001804AE490-0x00000001804AE4A0
		public bool vertical { get; set; } // 0x000000018052D500-0x000000018052D510 0x000000018052D7C0-0x000000018052D7D0
		public MovementType movementType { get; set; } // 0x00000001803B5DE0-0x00000001803B5DF0 0x00000001803FE010-0x00000001803FE020
		public float elasticity { get; set; } // 0x00000001806CCB40-0x00000001806CCB50 0x00000001806CCD50-0x00000001806CCD60
		public bool inertia { get; set; } // 0x00000001816DAFD0-0x00000001816DAFE0 0x0000000181C10650-0x0000000181C10660
		public float decelerationRate { get; set; } // 0x0000000181C62E80-0x0000000181C62E90 0x0000000181C62E90-0x0000000181C62EA0
		public float scrollSensitivity { get; set; } // 0x0000000181C58AB0-0x0000000181C58AC0 0x0000000181DBEB40-0x0000000181DBEB50
		public RectTransform viewport { get; set; } // 0x0000000180377940-0x0000000180377950 0x00000001825A1950-0x00000001825A1980
		public Scrollbar horizontalScrollbar { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001825A15C0-0x00000001825A1730
		public Scrollbar verticalScrollbar { get; set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001825A17E0-0x00000001825A1950
		public ScrollbarVisibility horizontalScrollbarVisibility { get; set; } // 0x000000018033D260-0x000000018033D270 0x00000001825A15B0-0x00000001825A15C0
		public ScrollbarVisibility verticalScrollbarVisibility { get; set; } // 0x000000018033D270-0x000000018033D280 0x00000001825A17D0-0x00000001825A17E0
		public float horizontalScrollbarSpacing { get; set; } // 0x0000000181D8CCA0-0x0000000181D8CCB0 0x00000001825A15A0-0x00000001825A15B0
		public float verticalScrollbarSpacing { get; set; } // 0x0000000182141FA0-0x0000000182141FB0 0x00000001825A17C0-0x00000001825A17D0
		public ScrollRectEvent onValueChanged { get; set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
		protected RectTransform viewRect { get; } // 0x00000001825A1470-0x00000001825A1580 
		public Vector2 velocity { get; set; } // 0x00000001825A1340-0x00000001825A1360 0x00000001825A1790-0x00000001825A17A0
		private RectTransform rectTransform { get; } // 0x00000001825A1220-0x00000001825A12C0 
		public Vector2 normalizedPosition { get; set; } // 0x00000001825A11E0-0x00000001825A1220 0x00000001825A1730-0x00000001825A1790
		public float horizontalNormalizedPosition { get; set; } // 0x00000001825A10E0-0x00000001825A11E0 0x00000001825A1580-0x00000001825A15A0
		public float verticalNormalizedPosition { get; set; } // 0x00000001825A1360-0x00000001825A1470 0x00000001825A17A0-0x00000001825A17C0
		private bool hScrollingNeeded { get; } // 0x00000001825A1060-0x00000001825A10E0 
		private bool vScrollingNeeded { get; } // 0x00000001825A12C0-0x00000001825A1340 
		public virtual float minWidth { get; } // 0x0000000181D048F0-0x0000000181D04900 
		public virtual float maxWidth { get; } // 0x00000001820939A0-0x00000001820939B0 
		public virtual float preferredWidth { get; } // 0x0000000181D048F0-0x0000000181D04900 
		public virtual float flexibleWidth { get; } // 0x0000000181D048F0-0x0000000181D04900 
		public virtual float minHeight { get; } // 0x0000000181D048F0-0x0000000181D04900 
		public virtual float maxHeight { get; } // 0x00000001820939A0-0x00000001820939B0 
		public virtual float preferredHeight { get; } // 0x0000000181D048F0-0x0000000181D04900 
		public virtual float flexibleHeight { get; } // 0x0000000181D048F0-0x0000000181D04900 
		public virtual int layoutPriority { get; } // 0x00000001815418D0-0x00000001815418E0 
		Transform ICanvasElement.transform { get; } // 0x0000000182091C50-0x0000000182091C60 
	
		// Nested types
		public enum MovementType // TypeDefIndex: 13106
		{
			Unrestricted = 0,
			Elastic = 1,
			Clamped = 2
		}
	
		public enum ScrollbarVisibility // TypeDefIndex: 13107
		{
			Permanent = 0,
			AutoHide = 1,
			AutoHideAndExpandViewport = 2
		}
	
		[Serializable]
		public class ScrollRectEvent : UnityEvent<Vector2> // TypeDefIndex: 13108
		{
			// Constructors
			public ScrollRectEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		// Constructors
		protected ScrollRect(); // 0x00000001825A0F40-0x00000001825A1060
	
		// Methods
		public virtual void Rebuild(CanvasUpdate executing); // 0x000000018259EC90-0x000000018259ED00
		public virtual void LayoutComplete(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void GraphicUpdateComplete(); // 0x00000001802E76C0-0x00000001802E76D0
		private void UpdateCachedData(); // 0x00000001825A0420-0x00000001825A0740
		protected override void OnEnable(); // 0x000000018259E860-0x000000018259EA20
		protected override void OnDisable(); // 0x000000018259E3C0-0x000000018259E5B0
		public override bool IsActive(); // 0x000000018259D8B0-0x000000018259D920
		private void EnsureLayoutHasRebuilt(); // 0x000000018259D300-0x000000018259D390
		public virtual void StopMovement(); // 0x000000018259FDE0-0x000000018259FE10
		public virtual void OnScroll(PointerEventData data); // 0x000000018259EAB0-0x000000018259EC90
		public virtual void OnInitializePotentialDrag(PointerEventData eventData); // 0x000000018259EA50-0x000000018259EAA0
		public virtual void OnBeginDrag(PointerEventData eventData); // 0x000000018259E270-0x000000018259E3C0
		public virtual void OnEndDrag(PointerEventData eventData); // 0x000000018259EA20-0x000000018259EA50
		public virtual void OnDrag(PointerEventData eventData); // 0x000000018259E5B0-0x000000018259E860
		protected virtual void SetContentAnchoredPosition(Vector2 position); // 0x000000018259ED60-0x000000018259EE80
		protected virtual void LateUpdate(); // 0x000000018259D920-0x000000018259E270
		protected void UpdatePrevData(); // 0x00000001825A0830-0x00000001825A0930
		private void UpdateScrollbars(Vector2 offset); // 0x00000001825A0D80-0x00000001825A0F40
		private void SetHorizontalNormalizedPosition(float value); // 0x000000018259EFC0-0x000000018259F010
		private void SetVerticalNormalizedPosition(float value); // 0x000000018259FD90-0x000000018259FDE0
		protected virtual void SetNormalizedPosition(float value, int axis); // 0x000000018259F8D0-0x000000018259FD90
		private static float RubberDelta(float overStretching, float viewSize); // 0x000000018259ED00-0x000000018259ED60
		protected override void OnRectTransformDimensionsChange(); // 0x000000018259EAA0-0x000000018259EAB0
		public virtual void CalculateLayoutInputHorizontal(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void CalculateLayoutInputVertical(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void SetLayoutHorizontal(); // 0x000000018259F010-0x000000018259F750
		public virtual void SetLayoutVertical(); // 0x000000018259F750-0x000000018259F8D0
		private void UpdateScrollbarVisibility(); // 0x00000001825A0D20-0x00000001825A0D80
		private static void UpdateOneScrollbarVisibility(bool xScrollingNeeded, bool xAxisEnabled, ScrollbarVisibility scrollbarVisibility, Scrollbar scrollbar); // 0x00000001825A0740-0x00000001825A0830
		private void UpdateScrollbarLayout(); // 0x00000001825A0930-0x00000001825A0D20
		protected void UpdateBounds(); // 0x000000018259FE10-0x00000001825A0420
		internal static void AdjustBounds(ref Bounds viewBounds, ref Vector2 contentPivot, ref Vector3 contentSize, ref Vector3 contentPos); // 0x000000018259D110-0x000000018259D1B0
		private Bounds GetBounds(); // 0x000000018259D390-0x000000018259D4C0
		internal static Bounds InternalGetBounds(Vector3[] corners, ref Matrix4x4 viewWorldToLocalMatrix); // 0x000000018259D600-0x000000018259D8B0
		private Vector2 CalculateOffset(Vector2 delta); // 0x000000018259D1B0-0x000000018259D300
		internal static Vector2 InternalCalculateOffset(ref Bounds viewBounds, ref Bounds contentBounds, bool horizontal, bool vertical, MovementType movementType, ref Vector2 delta); // 0x000000018259D4C0-0x000000018259D600
		protected void SetDirty(); // 0x000000018259EF40-0x000000018259EFC0
		protected void SetDirtyCaching(); // 0x000000018259EE80-0x000000018259EF40
	}
}
