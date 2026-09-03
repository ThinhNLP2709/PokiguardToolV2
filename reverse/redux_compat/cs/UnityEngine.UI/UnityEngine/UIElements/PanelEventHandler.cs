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

namespace UnityEngine.UIElements
{
	[AddComponentMenu("UI Toolkit/Panel Event Handler (UI Toolkit)")]
	[UGUIHelpURL("PanelEventHandler")]
	public class PanelEventHandler : UIBehaviour, IPointerMoveHandler, IPointerUpHandler, IPointerDownHandler, ISubmitHandler, ICancelHandler, IMoveHandler, IScrollHandler, ISelectHandler, IDeselectHandler, IPointerExitHandler, IPointerEnterHandler, IRuntimePanelComponent, IPointerClickHandler // TypeDefIndex: 13153
	{
		// Fields
		private IRuntimePanel m_Panel; // 0x20
		private readonly PointerEvent m_PointerEvent; // 0x28
		private readonly List<PointerEventData> m_ContainedPointers; // 0x30
		private float m_LastClickTime; // 0x38
		private bool m_Selecting; // 0x3C
		private Event m_Event; // 0x40
		private static EventModifiers s_Modifiers; // 0x00
	
		// Properties
		public IPanel panel { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x00000001825B5500-0x00000001825B55B0
		private GameObject selectableGameObject { get; } // 0x00000001825B54B0-0x00000001825B5500 
		private EventSystem eventSystem { get; } // 0x00000001825B52E0-0x00000001825B53B0 
		private bool isCurrentFocusedPanel { get; } // 0x00000001825B53B0-0x00000001825B54B0 
		private IEventHandler currentFocusedElement { get; } // 0x00000001825B5290-0x00000001825B52E0 
	
		// Nested types
		private enum PointerEventType // TypeDefIndex: 13154
		{
			Default = 0,
			Down = 1,
			Up = 2
		}
	
		private class PointerEvent : IPointerEvent // TypeDefIndex: 13155
		{
			// Fields
			[CompilerGenerated]
			private int _pointerId_k__BackingField; // 0x10
			[CompilerGenerated]
			private string _pointerType_k__BackingField; // 0x18
			[CompilerGenerated]
			private bool _isPrimary_k__BackingField; // 0x20
			[CompilerGenerated]
			private int _button_k__BackingField; // 0x24
			[CompilerGenerated]
			private int _pressedButtons_k__BackingField; // 0x28
			[CompilerGenerated]
			private Vector3 _position_k__BackingField; // 0x2C
			[CompilerGenerated]
			private Vector3 _localPosition_k__BackingField; // 0x38
			[CompilerGenerated]
			private Vector3 _deltaPosition_k__BackingField; // 0x44
			[CompilerGenerated]
			private float _deltaTime_k__BackingField; // 0x50
			[CompilerGenerated]
			private int _clickCount_k__BackingField; // 0x54
			[CompilerGenerated]
			private float _pressure_k__BackingField; // 0x58
			[CompilerGenerated]
			private float _tangentialPressure_k__BackingField; // 0x5C
			[CompilerGenerated]
			private float _altitudeAngle_k__BackingField; // 0x60
			[CompilerGenerated]
			private float _azimuthAngle_k__BackingField; // 0x64
			[CompilerGenerated]
			private float _twist_k__BackingField; // 0x68
			[CompilerGenerated]
			private Vector2 _tilt_k__BackingField; // 0x6C
			[CompilerGenerated]
			private PenStatus _penStatus_k__BackingField; // 0x74
			[CompilerGenerated]
			private Vector2 _radius_k__BackingField; // 0x78
			[CompilerGenerated]
			private Vector2 _radiusVariance_k__BackingField; // 0x80
			[CompilerGenerated]
			private EventModifiers _modifiers_k__BackingField; // 0x88
			[CompilerGenerated]
			private Vector3 _screenPosition_k__BackingField; // 0x8C
			[CompilerGenerated]
			private Vector3 _screenDelta_k__BackingField; // 0x98
			[CompilerGenerated]
			private Ray _worldRay_k__BackingField; // 0xA4
			[CompilerGenerated]
			private IPanelComponent _panelComponent_k__BackingField; // 0xC0
			internal IEventHandler m_elementTarget; // 0xC8
			internal IEventHandler m_elementUnderPointer; // 0xD0
	
			// Properties
			public int pointerId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
			public string pointerType { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
			public bool isPrimary { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180F1D2E0-0x0000000180F1D2F0 0x00000001813C7380-0x00000001813C7390
			public int button { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
			public int pressedButtons { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
			public Vector3 position { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181E5ACF0-0x0000000181E5AD10 0x00000001825B92F0-0x00000001825B9300
			public Vector3 localPosition { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D8BE50-0x0000000181D8BE70 0x0000000181D8BEC0-0x0000000181D8BED0
			public Vector3 deltaPosition { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001825B9150-0x00000001825B9170 0x00000001825B92E0-0x00000001825B92F0
			public float deltaTime { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D8CC80-0x0000000181D8CC90 0x0000000182141FC0-0x0000000182141FD0
			public int clickCount { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180CC1EB0-0x0000000180CC1EC0 0x0000000181ADB600-0x0000000181ADB610
			public float pressure { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018042C5E0-0x000000018042C5F0 0x0000000181DB54E0-0x0000000181DB54F0
			public float tangentialPressure { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D8CCB0-0x0000000181D8CCC0 0x0000000181DB54F0-0x0000000181DB5500
			public float altitudeAngle { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181D8CCA0-0x0000000181D8CCB0 0x0000000181DB5660-0x0000000181DB5670
			public float azimuthAngle { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000182141FA0-0x0000000182141FB0 0x0000000182141FF0-0x0000000182142000
			public float twist { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C245B0-0x0000000180C245C0 0x0000000180C24770-0x0000000180C24780
			public Vector2 tilt { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180BE5D50-0x0000000180BE5D70 0x0000000180BE5EF0-0x0000000180BE5F00
			public PenStatus penStatus { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181974810-0x0000000181974820 0x000000018198E760-0x000000018198E770
			public Vector2 radius { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000182584CE0-0x0000000182584D00 0x00000001825B9310-0x00000001825B9320
			public Vector2 radiusVariance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001825B9250-0x00000001825B9270 0x00000001825B9300-0x00000001825B9310
			public EventModifiers modifiers { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D620-0x000000018033D630 0x000000018033EC00-0x000000018033EC10
			public bool shiftKey { get; } // 0x00000001825B92B0-0x00000001825B92C0 
			public bool ctrlKey { get; } // 0x00000001825B9140-0x00000001825B9150 
			public bool commandKey { get; } // 0x00000001825B9130-0x00000001825B9140 
			public bool altKey { get; } // 0x00000001825B9120-0x00000001825B9130 
			public bool actionKey { get; } // 0x00000001825B90A0-0x00000001825B9120 
			public Vector3 screenPosition { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001825B9290-0x00000001825B92B0 0x00000001825B9340-0x00000001825B9360
			public Vector3 screenDelta { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001825B9270-0x00000001825B9290 0x00000001825B9320-0x00000001825B9340
			public Ray worldRay { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001825B92C0-0x00000001825B92E0 0x00000001825B9360-0x00000001825B9380
			public IPanelComponent panelComponent { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806CCB70-0x00000001806CCB80 0x00000001806CCDA0-0x00000001806CCDC0
			public VisualElement elementTarget { get; } // 0x00000001825B9170-0x00000001825B91E0 
			public VisualElement elementUnderPointer { get; } // 0x00000001825B91E0-0x00000001825B9250 
	
			// Constructors
			public PointerEvent(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public void Read(PanelEventHandler self, PointerEventData eventData, PointerEventType eventType); // 0x00000001825B8980-0x00000001825B9080
			public bool ComputeTarget(IRuntimePanel panel); // 0x00000001825B8470-0x00000001825B8980
			[CompilerGenerated]
			internal static bool _Read_g__InRange_112_0(int i, int start, int count); // 0x00000001825B9080-0x00000001825B90A0
		}
	
		// Constructors
		public PanelEventHandler(); // 0x00000001825B51A0-0x00000001825B5290
	
		// Methods
		protected override void OnEnable(); // 0x00000001825B3680-0x00000001825B36A0
		protected override void OnDisable(); // 0x00000001825B3580-0x00000001825B35A0
		private void RegisterCallbacks(); // 0x00000001825B48F0-0x00000001825B49F0
		private void UnregisterCallbacks(); // 0x00000001825B4D00-0x00000001825B4E00
		private void OnPanelDestroyed(); // 0x00000001825B3810-0x00000001825B3870
		private void OnElementFocus(); // 0x00000001825B35A0-0x00000001825B3680
		public void OnSelect(BaseEventData eventData); // 0x00000001825B4280-0x00000001825B4330
		public void OnDeselect(BaseEventData eventData); // 0x00000001825B3530-0x00000001825B3580
		public void OnPointerMove(PointerEventData eventData); // 0x00000001825B3F50-0x00000001825B4010
		public void OnPointerUp(PointerEventData eventData); // 0x00000001825B4010-0x00000001825B40D0
		public void OnPointerDown(PointerEventData eventData); // 0x00000001825B3890-0x00000001825B3B90
		public void OnPointerExit(PointerEventData eventData); // 0x00000001825B3D30-0x00000001825B3F50
		public void OnPointerEnter(PointerEventData eventData); // 0x00000001825B3B90-0x00000001825B3D30
		public void OnPointerClick(PointerEventData eventData); // 0x00000001825B3870-0x00000001825B3890
		public void OnSubmit(BaseEventData eventData); // 0x00000001825B4330-0x00000001825B4490
		public void OnCancel(BaseEventData eventData); // 0x00000001825B33D0-0x00000001825B3530
		public void OnMove(AxisEventData eventData); // 0x00000001825B36A0-0x00000001825B3810
		public void OnScroll(PointerEventData eventData); // 0x00000001825B40D0-0x00000001825B4280
		public void Update(); // 0x00000001825B5030-0x00000001825B51A0
		private void LateUpdate(); // 0x00000001825B33C0-0x00000001825B33D0
		private void ProcessImguiEvents(IEventHandler target); // 0x00000001825B4490-0x00000001825B4600
		private void ProcessKeyboardEvent(Event e, IEventHandler target); // 0x00000001825B4600-0x00000001825B4700
		private void ProcessTabEvent(Event e, IEventHandler target); // 0x00000001825B4700-0x00000001825B47F0
		private void SendTabEvent(Event e, NavigationMoveDirection direction, IEventHandler target); // 0x00000001825B4C50-0x00000001825B4D00
		private void SendKeyUpEvent(Event e, IEventHandler target); // 0x00000001825B4B90-0x00000001825B4C50
		private void SendKeyDownEvent(Event e, IEventHandler target); // 0x00000001825B49F0-0x00000001825B4B90
		private bool ReadPointerData(PointerEvent pe, PointerEventData eventData, PointerEventType eventType = PointerEventType.Default /* Metadata: 0x006A77B2 */); // 0x00000001825B47F0-0x00000001825B48F0
		private NavigationDeviceType GetDeviceType(BaseEventData eventData); // 0x00000001825B32E0-0x00000001825B33C0
		private void UpdateWorldSpacePointers(); // 0x00000001825B4E00-0x00000001825B5030
	}
}
