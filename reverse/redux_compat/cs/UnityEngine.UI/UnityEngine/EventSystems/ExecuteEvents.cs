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

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.EventSystems
{
	public static class ExecuteEvents // TypeDefIndex: 13193
	{
		// Fields
		private static readonly EventFunction<IPointerMoveHandler> s_PointerMoveHandler; // 0x00
		private static readonly EventFunction<IPointerEnterHandler> s_PointerEnterHandler; // 0x08
		private static readonly EventFunction<IPointerExitHandler> s_PointerExitHandler; // 0x10
		private static readonly EventFunction<IPointerDownHandler> s_PointerDownHandler; // 0x18
		private static readonly EventFunction<IPointerUpHandler> s_PointerUpHandler; // 0x20
		private static readonly EventFunction<IPointerClickHandler> s_PointerClickHandler; // 0x28
		private static readonly EventFunction<IInitializePotentialDragHandler> s_InitializePotentialDragHandler; // 0x30
		private static readonly EventFunction<IBeginDragHandler> s_BeginDragHandler; // 0x38
		private static readonly EventFunction<IDragHandler> s_DragHandler; // 0x40
		private static readonly EventFunction<IEndDragHandler> s_EndDragHandler; // 0x48
		private static readonly EventFunction<IDropHandler> s_DropHandler; // 0x50
		private static readonly EventFunction<IScrollHandler> s_ScrollHandler; // 0x58
		private static readonly EventFunction<IUpdateSelectedHandler> s_UpdateSelectedHandler; // 0x60
		private static readonly EventFunction<ISelectHandler> s_SelectHandler; // 0x68
		private static readonly EventFunction<IDeselectHandler> s_DeselectHandler; // 0x70
		private static readonly EventFunction<IMoveHandler> s_MoveHandler; // 0x78
		private static readonly EventFunction<ISubmitHandler> s_SubmitHandler; // 0x80
		private static readonly EventFunction<ICancelHandler> s_CancelHandler; // 0x88
		private static readonly List<Transform> s_InternalTransformList; // 0x90
	
		// Properties
		public static EventFunction<IPointerMoveHandler> pointerMoveHandler { get; } // 0x00000001825B24D0-0x00000001825B2520 
		public static EventFunction<IPointerEnterHandler> pointerEnterHandler { get; } // 0x00000001825B2430-0x00000001825B2480 
		public static EventFunction<IPointerExitHandler> pointerExitHandler { get; } // 0x00000001825B2480-0x00000001825B24D0 
		public static EventFunction<IPointerDownHandler> pointerDownHandler { get; } // 0x00000001825B23E0-0x00000001825B2430 
		public static EventFunction<IPointerUpHandler> pointerUpHandler { get; } // 0x00000001825B2520-0x00000001825B2570 
		public static EventFunction<IPointerClickHandler> pointerClickHandler { get; } // 0x00000001825B2390-0x00000001825B23E0 
		public static EventFunction<IInitializePotentialDragHandler> initializePotentialDrag { get; } // 0x00000001825B22F0-0x00000001825B2340 
		public static EventFunction<IBeginDragHandler> beginDragHandler { get; } // 0x00000001825B2100-0x00000001825B2150 
		public static EventFunction<IDragHandler> dragHandler { get; } // 0x00000001825B2200-0x00000001825B2250 
		public static EventFunction<IEndDragHandler> endDragHandler { get; } // 0x00000001825B22A0-0x00000001825B22F0 
		public static EventFunction<IDropHandler> dropHandler { get; } // 0x00000001825B2250-0x00000001825B22A0 
		public static EventFunction<IScrollHandler> scrollHandler { get; } // 0x00000001825B2570-0x00000001825B25C0 
		public static EventFunction<IUpdateSelectedHandler> updateSelectedHandler { get; } // 0x00000001825B2670-0x00000001825B26C0 
		public static EventFunction<ISelectHandler> selectHandler { get; } // 0x00000001825B25C0-0x00000001825B2610 
		public static EventFunction<IDeselectHandler> deselectHandler { get; } // 0x00000001825B21B0-0x00000001825B2200 
		public static EventFunction<IMoveHandler> moveHandler { get; } // 0x00000001825B2340-0x00000001825B2390 
		public static EventFunction<ISubmitHandler> submitHandler { get; } // 0x00000001825B2610-0x00000001825B2670 
		public static EventFunction<ICancelHandler> cancelHandler { get; } // 0x00000001825B2150-0x00000001825B21B0 
	
		// Nested types
		public delegate void EventFunction<T1>(T1 handler, BaseEventData eventData); // TypeDefIndex: 13194; 0x00000000-0x00000000
	
		// Constructors
		static ExecuteEvents(); // 0x00000001825B1920-0x00000001825B2100
	
		// Methods
		public static T ValidateEventData<T>(BaseEventData data)
			where T : class;
		private static void Execute(IPointerMoveHandler handler, BaseEventData eventData); // 0x00000001825B0F70-0x00000001825B1010
		private static void Execute(IPointerEnterHandler handler, BaseEventData eventData); // 0x00000001825B1290-0x00000001825B1330
		private static void Execute(IPointerExitHandler handler, BaseEventData eventData); // 0x00000001825B10B0-0x00000001825B1150
		private static void Execute(IPointerDownHandler handler, BaseEventData eventData); // 0x00000001825B1010-0x00000001825B10B0
		private static void Execute(IPointerUpHandler handler, BaseEventData eventData); // 0x00000001825B16C0-0x00000001825B1760
		private static void Execute(IPointerClickHandler handler, BaseEventData eventData); // 0x00000001825B11F0-0x00000001825B1290
		private static void Execute(IInitializePotentialDragHandler handler, BaseEventData eventData); // 0x00000001825B1620-0x00000001825B16C0
		private static void Execute(IBeginDragHandler handler, BaseEventData eventData); // 0x00000001825B1150-0x00000001825B11F0
		private static void Execute(IDragHandler handler, BaseEventData eventData); // 0x00000001825B1580-0x00000001825B1620
		private static void Execute(IEndDragHandler handler, BaseEventData eventData); // 0x00000001825B0E70-0x00000001825B0F10
		private static void Execute(IDropHandler handler, BaseEventData eventData); // 0x00000001825B1390-0x00000001825B1430
		private static void Execute(IScrollHandler handler, BaseEventData eventData); // 0x00000001825B0DD0-0x00000001825B0E70
		private static void Execute(IUpdateSelectedHandler handler, BaseEventData eventData); // 0x00000001825B1760-0x00000001825B17C0
		private static void Execute(ISelectHandler handler, BaseEventData eventData); // 0x00000001825B1520-0x00000001825B1580
		private static void Execute(IDeselectHandler handler, BaseEventData eventData); // 0x00000001825B0D70-0x00000001825B0DD0
		private static void Execute(IMoveHandler handler, BaseEventData eventData); // 0x00000001825B1430-0x00000001825B1520
		private static void Execute(ISubmitHandler handler, BaseEventData eventData); // 0x00000001825B1330-0x00000001825B1390
		private static void Execute(ICancelHandler handler, BaseEventData eventData); // 0x00000001825B0F10-0x00000001825B0F70
		private static void GetEventChain(GameObject root, IList<Transform> eventChain); // 0x00000001825B17C0-0x00000001825B1920
		public static bool Execute<T>(GameObject target, BaseEventData eventData, EventFunction<T> functor)
			where T : IEventSystemHandler;
		public static GameObject ExecuteHierarchy<T>(GameObject root, BaseEventData eventData, EventFunction<T> callbackFunction)
			where T : IEventSystemHandler;
		private static bool ShouldSendToComponent<T>(Component component)
			where T : IEventSystemHandler;
		private static void GetEventList<T>(GameObject go, IList<IEventSystemHandler> results)
			where T : IEventSystemHandler;
		public static bool CanHandleEvent<T>(GameObject go)
			where T : IEventSystemHandler;
		public static GameObject GetEventHandler<T>(GameObject root)
			where T : IEventSystemHandler;
	}
}
