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
	[AddComponentMenu("UI (Canvas)/Slider", 34)]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[UGUIHelpURL("Slider")]
	public class Slider : Selectable, IDragHandler, IInitializePotentialDragHandler, ICanvasElement // TypeDefIndex: 13118
	{
		// Fields
		[SerializeField]
		private RectTransform m_FillRect; // 0x100
		[SerializeField]
		private RectTransform m_HandleRect; // 0x108
		[SerializeField]
		[Space]
		private Direction m_Direction; // 0x110
		[SerializeField]
		private float m_MinValue; // 0x114
		[SerializeField]
		private float m_MaxValue; // 0x118
		[SerializeField]
		private bool m_WholeNumbers; // 0x11C
		[SerializeField]
		protected float m_Value; // 0x120
		[SerializeField]
		[Space]
		private SliderEvent m_OnValueChanged; // 0x128
		private Image m_FillImage; // 0x130
		private Transform m_FillTransform; // 0x138
		private RectTransform m_FillContainerRect; // 0x140
		private Transform m_HandleTransform; // 0x148
		private RectTransform m_HandleContainerRect; // 0x150
		private Vector2 m_Offset; // 0x158
		private DrivenRectTransformTracker m_Tracker; // 0x160
		private bool m_DelayedUpdateVisuals; // 0x161
	
		// Properties
		public RectTransform fillRect { get; set; } // 0x00000001816A28C0-0x00000001816A28D0 0x00000001825A7E20-0x00000001825A7E90
		public RectTransform handleRect { get; set; } // 0x0000000180CDC950-0x0000000180CDC960 0x00000001825A7E90-0x00000001825A7F00
		public Direction direction { get; set; } // 0x00000001825A7C50-0x00000001825A7C60 0x00000001825A7DC0-0x00000001825A7E20
		public float minValue { get; set; } // 0x00000001820CDE60-0x00000001820CDE70 0x00000001825A7F80-0x00000001825A8000
		public float maxValue { get; set; } // 0x00000001825A7C60-0x00000001825A7C70 0x00000001825A7F00-0x00000001825A7F80
		public bool wholeNumbers { get; set; } // 0x0000000181F63DE0-0x0000000181F63DF0 0x00000001825A8070-0x00000001825A80F0
		public virtual float value { get; set; } // 0x00000001825A7DA0-0x00000001825A7DC0 0x00000001825A8050-0x00000001825A8070
		public float normalizedValue { get; set; } // 0x00000001825A7C70-0x00000001825A7D50 0x00000001825A8000-0x00000001825A8050
		public SliderEvent onValueChanged { get; set; } // 0x0000000181CE5BD0-0x0000000181CE5BE0 0x0000000181380070-0x0000000181380090
		private float stepSize { get; } // 0x00000001825A7D70-0x00000001825A7DA0 
		private Axis axis { get; } // 0x00000001825A7C30-0x00000001825A7C50 
		private bool reverseValue { get; } // 0x00000001825A7D50-0x00000001825A7D70 
		Transform ICanvasElement.transform { get; } // 0x0000000182091C50-0x0000000182091C60 
	
		// Nested types
		public enum Direction // TypeDefIndex: 13119
		{
			LeftToRight = 0,
			RightToLeft = 1,
			BottomToTop = 2,
			TopToBottom = 3
		}
	
		[Serializable]
		public class SliderEvent : UnityEvent<float> // TypeDefIndex: 13120
		{
			// Constructors
			public SliderEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		private enum Axis // TypeDefIndex: 13121
		{
			Horizontal = 0,
			Vertical = 1
		}
	
		// Constructors
		protected Slider(); // 0x00000001825A7B70-0x00000001825A7C30
	
		// Methods
		public virtual void SetValueWithoutNotify(float input); // 0x00000001825A7120-0x00000001825A7140
		public virtual void Rebuild(CanvasUpdate executing); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void LayoutComplete(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void GraphicUpdateComplete(); // 0x00000001802E76C0-0x00000001802E76D0
		protected override void OnEnable(); // 0x00000001825A6840-0x00000001825A6890
		protected override void OnDisable(); // 0x00000001825A6790-0x00000001825A67C0
		protected virtual void Update(); // 0x00000001825A7B20-0x00000001825A7B70
		protected override void OnDidApplyAnimationProperties(); // 0x00000001825A6540-0x00000001825A6790
		private void UpdateCachedReferences(); // 0x00000001825A7230-0x00000001825A7540
		private float ClampValue(float input); // 0x00000001825A6450-0x00000001825A6480
		protected virtual void Set(float input, bool sendCallback = true /* Metadata: 0x006A7792 */); // 0x00000001825A7140-0x00000001825A7230
		protected override void OnRectTransformDimensionsChange(); // 0x00000001825A6F10-0x00000001825A6F50
		private void UpdateVisuals(); // 0x00000001825A77F0-0x00000001825A7B20
		private void UpdateDrag(PointerEventData eventData, Camera cam); // 0x00000001825A7540-0x00000001825A77F0
		private bool MayDrag(PointerEventData eventData); // 0x00000001825A1C00-0x00000001825A1C70
		public override void OnPointerDown(PointerEventData eventData); // 0x00000001825A6CE0-0x00000001825A6F10
		public virtual void OnDrag(PointerEventData eventData); // 0x00000001825A67C0-0x00000001825A6840
		public override void OnMove(AxisEventData eventData); // 0x00000001825A6890-0x00000001825A6CE0
		public override Selectable FindSelectableOnLeft(); // 0x00000001825A64B0-0x00000001825A64E0
		public override Selectable FindSelectableOnRight(); // 0x00000001825A64E0-0x00000001825A6510
		public override Selectable FindSelectableOnUp(); // 0x00000001825A6510-0x00000001825A6540
		public override Selectable FindSelectableOnDown(); // 0x00000001825A6480-0x00000001825A64B0
		public virtual void OnInitializePotentialDrag(PointerEventData eventData); // 0x00000001825A2190-0x00000001825A21B0
		public void SetDirection(Direction direction, bool includeRectLayouts); // 0x00000001825A6F50-0x00000001825A7120
	}
}
