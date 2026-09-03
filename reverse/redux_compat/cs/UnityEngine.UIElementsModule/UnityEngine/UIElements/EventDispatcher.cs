/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public sealed class EventDispatcher // TypeDefIndex: 3946
	{
		// Fields
		internal ClickDetector m_ClickDetector; // 0x10
		private static readonly ObjectPool<Queue<EventRecord>> k_EventQueuePool; // 0x00
		private Queue<EventRecord> m_Queue; // 0x18
		[CompilerGenerated]
		private readonly PointerDispatchState _pointerState_k__BackingField; // 0x20
		private uint m_GateCount; // 0x28
		private uint m_GateDepth; // 0x2C
		private int m_DispatchStackFrame; // 0x30
		private EventBase m_CurrentEvent; // 0x38
		private Stack<DispatchContext> m_DispatchContexts; // 0x40
		private bool m_Immediate; // 0x48
		[CompilerGenerated]
		private bool _processingEvents_k__BackingField; // 0x49
	
		// Properties
		internal PointerDispatchState pointerState { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
		private bool dispatchImmediately { get; } // 0x000000018239F540-0x000000018239F560 
		private bool processingEvents { [CompilerGenerated] set; } // 0x0000000182042F70-0x0000000182042F80
	
		// Nested types
		private struct EventRecord // TypeDefIndex: 3947
		{
			// Fields
			public EventBase m_Event; // 0x00
			public BaseVisualElementPanel m_Panel; // 0x08
		}
	
		private struct DispatchContext // TypeDefIndex: 3948
		{
			// Fields
			public uint m_GateCount; // 0x00
			public Queue<EventRecord> m_Queue; // 0x08
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3949
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001823B2010-0x00000001823B2080
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Queue<EventRecord> _.cctor_b__35_0(); // 0x00000001823B1DE0-0x00000001823B1E40
		}
	
		// Constructors
		[Obsolete("Please use EventDispatcher.CreateDefault().")]
		internal EventDispatcher(); // 0x000000018239F3F0-0x000000018239F540
		static EventDispatcher(); // 0x000000018239F2E0-0x000000018239F3F0
	
		// Methods
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal static EventDispatcher CreateDefault(); // 0x000000018239E340-0x000000018239E4C0
		internal void Dispatch(EventBase evt, [NotNull] BaseVisualElementPanel panel, DispatchMode dispatchMode); // 0x000000018239E4C0-0x000000018239E6F0
		private bool HandleRecursiveState(EventBase evt); // 0x000000018239E6F0-0x000000018239EAF0
		internal void CloseGate(); // 0x000000018239E330-0x000000018239E340
		internal void OpenGate(); // 0x000000018239EAF0-0x000000018239EBF0
		private void ProcessEventQueue(); // 0x000000018239EBF0-0x000000018239EF00
		private void ProcessEvent(EventBase evt, [NotNull] BaseVisualElementPanel panel); // 0x000000018239EF00-0x000000018239F2E0
	}
}
