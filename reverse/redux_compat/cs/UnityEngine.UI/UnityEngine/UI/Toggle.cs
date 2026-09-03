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
	[AddComponentMenu("UI (Canvas)/Toggle", 30)]
	[RequireComponent(typeof(RectTransform))]
	[UGUIHelpURL("Toggle")]
	public class Toggle : Selectable, IPointerClickHandler, ISubmitHandler, ICanvasElement // TypeDefIndex: 13126
	{
		// Fields
		public ToggleTransition toggleTransition; // 0x100
		public Graphic graphic; // 0x108
		[SerializeField]
		private ToggleGroup m_Group; // 0x110
		public ToggleEvent onValueChanged; // 0x118
		[SerializeField]
		[Tooltip("Is the toggle currently on or off?")]
		private bool m_IsOn; // 0x120
	
		// Properties
		public ToggleGroup group { get; set; } // 0x000000018170B050-0x000000018170B060 0x00000001825AC370-0x00000001825AC3A0
		public bool isOn { get; set; } // 0x000000018170B040-0x000000018170B050 0x00000001825AC3A0-0x00000001825AC3B0
		Transform ICanvasElement.transform { get; } // 0x0000000182091C50-0x0000000182091C60 
	
		// Nested types
		public enum ToggleTransition // TypeDefIndex: 13127
		{
			None = 0,
			Fade = 1
		}
	
		[Serializable]
		public class ToggleEvent : UnityEvent<bool> // TypeDefIndex: 13128
		{
			// Constructors
			public ToggleEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		// Constructors
		protected Toggle(); // 0x00000001825AC2D0-0x00000001825AC370
	
		// Methods
		public virtual void Rebuild(CanvasUpdate executing); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void LayoutComplete(); // 0x00000001802E76C0-0x00000001802E76D0
		public virtual void GraphicUpdateComplete(); // 0x00000001802E76C0-0x00000001802E76D0
		protected override void OnDestroy(); // 0x00000001825ABB80-0x00000001825ABC10
		protected override void OnEnable(); // 0x00000001825ABD50-0x00000001825ABD90
		protected override void OnDisable(); // 0x00000001825ABD20-0x00000001825ABD50
		protected override void OnDidApplyAnimationProperties(); // 0x00000001825ABC10-0x00000001825ABD20
		private void SetToggleGroup(ToggleGroup newGroup, bool setMemberValue); // 0x00000001825ABEE0-0x00000001825AC130
		public void SetIsOnWithoutNotify(bool value); // 0x00000001825ABED0-0x00000001825ABEE0
		private void Set(bool value, bool sendCallback = true /* Metadata: 0x006A7799 */); // 0x00000001825AC130-0x00000001825AC2C0
		private void PlayEffect(bool instant); // 0x00000001825ABE10-0x00000001825ABED0
		protected override void Start(); // 0x00000001825AC2C0-0x00000001825AC2D0
		private void InternalToggle(); // 0x00000001825ABB20-0x00000001825ABB80
		public virtual void OnPointerClick(PointerEventData eventData); // 0x00000001825ABD90-0x00000001825ABE10
		public virtual void OnSubmit(BaseEventData eventData); // 0x00000001825ABB20-0x00000001825ABB80
	}
}
