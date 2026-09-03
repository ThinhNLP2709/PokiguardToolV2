/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
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
	[AddComponentMenu("UI (Canvas)/Scrollbar", 36)]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[UGUIHelpURL("Scrollbar")]
	public class Scrollbar : Selectable, IBeginDragHandler, IDragHandler, IInitializePotentialDragHandler, ICanvasElement // TypeDefIndex: 13109
	{
		// Fields
		[SerializeField]
		private RectTransform m_HandleRect; // 0x100
		[SerializeField]
		private Direction m_Direction; // 0x108
		[Range(0f, 1f)]
		[SerializeField]
		private float m_Value; // 0x10C
		[Range(0f, 1f)]
		[SerializeField]
		private float m_Size; // 0x110
		[Range(0f, 11f)]
		[SerializeField]
		private int m_NumberOfSteps; // 0x114
		[SerializeField]
		[Space(6f)]
		private ScrollEvent m_OnValueChanged; // 0x118
		private RectTransform m_ContainerRect; // 0x120
		private Vector2 m_Offset; // 0x128
		private DrivenRectTransformTracker m_Tracker; // 0x130
		private Coroutine m_PointerDownRepeat; // 0x138
		private bool isPointerDownAndNotDragging; // 0x140
		private bool m_DelayedUpdateVisuals; // 0x141
	
		// Properties
		public RectTransform handleRect { get; set; } // 0x00000001816A28C0-0x00000001816A28D0 0x00000001825A3500-0x00000001825A3570
		public Direction direction { get; set; } // 0x0000000181D7F5A0-0x0000000181D7F5B0 0x00000001825A34A0-0x00000001825A3500
		public float value { get; set; } // 0x00000001825A3440-0x00000001825A34A0 0x00000001825A3650-0x00000001825A3660
		public float size { get; set; } // 0x0000000182378CE0-0x0000000182378CF0 0x00000001825A35E0-0x00000001825A3650
		public int numberOfSteps { get; set; } // 0x0000000181F63E50-0x0000000181F63E60 0x00000001825A3570-0x00000001825A35E0
		public ScrollEvent onValueChanged { get; set; } // 0x000000018171E0D0-0x000000018171E0E0 0x0000000180504EA0-0x0000000180504EC0
		private float stepSize { get; } // 0x00000001825A3410-0x00000001825A3440 
		private Axis axis { get; } // 0x00000001825A33D0-0x00000001825A33F0 
		private bool reverseValue { get; } // 0x00000001825A33F0-0x00000001825A3410 
		Transform ICanvasElement.transform { get; } // 0x0000000182091C50-0x0000000182091C60 
	
		// Nested types
		public enum Direction // TypeDefIndex: 13110
		{
			LeftToRight = 0,
			RightToLeft = 1,
			BottomToTop = 2,
			TopToBottom = 3
		}
	
		[Serializable]
		public class ScrollEvent : UnityEvent<float> // TypeDefIndex: 13111
		{
			// Constructors
			public ScrollEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		private enum Axis // TypeDefIndex: 13112
		{
			Horizontal = 0,
			Vertical = 1
		}
	
		[CompilerGenerated]
		private sealed class _ClickRepeat_d__59 : IEnumerator<object> // TypeDefIndex: 13113
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public Scrollbar __4__this; // 0x20
			public Vector2 screenPosition; // 0x28
			public Camera camera; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _ClickRepeat_d__59(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x00000001825AC3B0-0x00000001825AC520
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001825AC520-0x00000001825AC560
		}
	
		// Constructors
		protected Scrollbar(); // 0x00000001825A3310-0x00000001825A33D0
	
		// Methods
		public virtual void SetValueWithoutNotify(float input); // 0x00000001825A2A70-0x00000001825A2B20
		public virtual void Rebuild(CanvasUpdate executing); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void LayoutComplete(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void GraphicUpdateComplete(); // 0x00000001802E76C0-0x00000001802E76D0
		protected override void OnEnable(); // 0x00000001825A20C0-0x00000001825A2190
		protected override void OnDisable(); // 0x00000001825A1F10-0x00000001825A1F40
		protected virtual void Update(); // 0x00000001825A32F0-0x00000001825A3310
		private void UpdateCachedReferences(); // 0x00000001825A2C50-0x00000001825A2D30
		private void Set(float input, bool sendCallback = true /* Metadata: 0x006A7782 */); // 0x00000001825A2B20-0x00000001825A2C50
		protected override void OnRectTransformDimensionsChange(); // 0x00000001825A2860-0x00000001825A28A0
		private void UpdateVisuals(); // 0x00000001825A30C0-0x00000001825A32F0
		private void UpdateDrag(PointerEventData eventData); // 0x00000001825A2D30-0x00000001825A2E20
		private void UpdateDrag(RectTransform containerRect, Vector2 position, Camera camera); // 0x00000001825A2E20-0x00000001825A30C0
		private void DoUpdateDrag(Vector2 handleCorner, float remainingSize); // 0x00000001825A1AA0-0x00000001825A1B40
		private bool MayDrag(PointerEventData eventData); // 0x00000001825A1C00-0x00000001825A1C70
		public virtual void OnBeginDrag(PointerEventData eventData); // 0x00000001825A1C70-0x00000001825A1F10
		public virtual void OnDrag(PointerEventData eventData); // 0x00000001825A1F40-0x00000001825A20C0
		public override void OnPointerDown(PointerEventData eventData); // 0x00000001825A2710-0x00000001825A2820
		protected IEnumerator ClickRepeat(PointerEventData eventData); // 0x00000001825A1A20-0x00000001825A1AA0
		[IteratorStateMachine(typeof(_ClickRepeat_d__59))]
		protected IEnumerator ClickRepeat(Vector2 screenPosition, Camera camera); // 0x00000001825A1980-0x00000001825A1A20
		public override void OnPointerUp(PointerEventData eventData); // 0x00000001825A2820-0x00000001825A2860
		public override void OnMove(AxisEventData eventData); // 0x00000001825A21B0-0x00000001825A2710
		public override Selectable FindSelectableOnLeft(); // 0x00000001825A1B70-0x00000001825A1BA0
		public override Selectable FindSelectableOnRight(); // 0x00000001825A1BA0-0x00000001825A1BD0
		public override Selectable FindSelectableOnUp(); // 0x00000001825A1BD0-0x00000001825A1C00
		public override Selectable FindSelectableOnDown(); // 0x00000001825A1B40-0x00000001825A1B70
		public virtual void OnInitializePotentialDrag(PointerEventData eventData); // 0x00000001825A2190-0x00000001825A21B0
		public void SetDirection(Direction direction, bool includeRectLayouts); // 0x00000001825A28A0-0x00000001825A2A70
	}
}
