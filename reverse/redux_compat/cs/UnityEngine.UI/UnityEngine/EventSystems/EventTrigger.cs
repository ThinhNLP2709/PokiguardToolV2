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
using UnityEngine.Events;
using UnityEngine.Serialization;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.EventSystems
{
	[AddComponentMenu("Event/Event Trigger")]
	[UGUIHelpURL("EventTrigger")]
	public class EventTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IScrollHandler, IUpdateSelectedHandler, ISelectHandler, IDeselectHandler, IMoveHandler, ISubmitHandler, ICancelHandler // TypeDefIndex: 13189
	{
		// Fields
		[FormerlySerializedAs("delegates")]
		[SerializeField]
		private List<Entry> m_Delegates; // 0x20
	
		// Properties
		public List<Entry> triggers { get; set; } // 0x00000001825B0CF0-0x00000001825B0D70 0x000000018033E830-0x000000018033E840
	
		// Nested types
		[Serializable]
		public class TriggerEvent : UnityEvent<BaseEventData> // TypeDefIndex: 13190
		{
			// Constructors
			public TriggerEvent(); // 0x00000001805EC9B0-0x00000001805EC9C0
		}
	
		[Serializable]
		public class Entry // TypeDefIndex: 13191
		{
			// Fields
			public EventTriggerType eventID; // 0x10
			public TriggerEvent callback; // 0x18
	
			// Constructors
			public Entry(); // 0x00000001825AE850-0x00000001825AE8C0
		}
	
		// Constructors
		protected EventTrigger(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void Execute(EventTriggerType id, BaseEventData eventData); // 0x00000001825B0A60-0x00000001825B0BE0
		public virtual void OnPointerEnter(PointerEventData eventData); // 0x00000001825B0C80-0x00000001825B0C90
		public virtual void OnPointerExit(PointerEventData eventData); // 0x00000001825B0C90-0x00000001825B0CA0
		public virtual void OnDrag(PointerEventData eventData); // 0x00000001825B0C10-0x00000001825B0C20
		public virtual void OnDrop(PointerEventData eventData); // 0x00000001825B0C20-0x00000001825B0C30
		public virtual void OnPointerDown(PointerEventData eventData); // 0x00000001825B0C70-0x00000001825B0C80
		public virtual void OnPointerUp(PointerEventData eventData); // 0x00000001825B0CA0-0x00000001825B0CB0
		public virtual void OnPointerClick(PointerEventData eventData); // 0x00000001825B0C60-0x00000001825B0C70
		public virtual void OnSelect(BaseEventData eventData); // 0x00000001825B0CC0-0x00000001825B0CD0
		public virtual void OnDeselect(BaseEventData eventData); // 0x00000001825B0C00-0x00000001825B0C10
		public virtual void OnScroll(PointerEventData eventData); // 0x00000001825B0CB0-0x00000001825B0CC0
		public virtual void OnMove(AxisEventData eventData); // 0x00000001825B0C50-0x00000001825B0C60
		public virtual void OnUpdateSelected(BaseEventData eventData); // 0x00000001825B0CE0-0x00000001825B0CF0
		public virtual void OnInitializePotentialDrag(PointerEventData eventData); // 0x00000001825B0C40-0x00000001825B0C50
		public virtual void OnBeginDrag(PointerEventData eventData); // 0x00000001825B0BE0-0x00000001825B0BF0
		public virtual void OnEndDrag(PointerEventData eventData); // 0x00000001825B0C30-0x00000001825B0C40
		public virtual void OnSubmit(BaseEventData eventData); // 0x00000001825B0CD0-0x00000001825B0CE0
		public virtual void OnCancel(BaseEventData eventData); // 0x00000001825B0BF0-0x00000001825B0C00
	}
}
