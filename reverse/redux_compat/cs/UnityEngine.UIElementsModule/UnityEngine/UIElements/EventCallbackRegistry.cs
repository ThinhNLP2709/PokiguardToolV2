/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using JetBrains.Annotations;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class EventCallbackRegistry // TypeDefIndex: 4022
	{
		// Fields
		private static readonly EventCallbackListPool k_ListPool; // 0x00
		private ArgValueList m_ArgValues; // 0x10
		internal DynamicCallbackList m_TrickleDownCallbacks; // 0x20
		internal DynamicCallbackList m_BubbleUpCallbacks; // 0x38
		internal static readonly EventCallbackPool k_LocalCallbackPool; // 0x08
		[TupleElementNames(new string[2] {"registry", "callback" })]
		internal static readonly List<ValueTuple<EventCallbackRegistry, EventCallbackInternal>> k_UnregisteredLocalCallbacksDuringInvoke; // 0x10
		internal static int s_GlobalInvokeCount; // 0x18
		private bool m_HasLocalCallbacks; // 0x50
		private static readonly ObjectPool<EventCallbackRegistry> k_RegistryPool; // 0x20
	
		// Nested types
		internal struct DynamicCallbackList // TypeDefIndex: 4023
		{
			// Fields
			[NotNull]
			private EventCallbackList m_Callbacks; // 0x00
			[CanBeNull]
			private EventCallbackList m_TemporaryCallbacks; // 0x08
			private int m_IsInvoking; // 0x10
	
			// Properties
			public bool isInvoking { get; } // 0x0000000182471100-0x0000000182471110 
	
			// Methods
			public static DynamicCallbackList Create(); // 0x00000001824706D0-0x0000000182470760
			[NotNull]
			public EventCallbackList GetCallbackListForWriting(); // 0x0000000182470AA0-0x0000000182470B90
			[IsReadOnly]
			[NotNull]
			public EventCallbackList GetCallbackListForReading(); // 0x0000000182470980-0x0000000182470990
			[NotNull]
			public EventCallbackList GetCallbackListForRemoving(); // 0x0000000182470A10-0x0000000182470AA0
			[NotNull]
			public EventCallbackList GetCallbackListForRemovingOutsideInvoke(); // 0x00000001808BADD0-0x00000001808BADE0
			[NotNull]
			public EventCallbackList GetCallbackListForRemovingDuringInvoke(); // 0x0000000182470990-0x0000000182470A10
			public void Invoke(EventBase evt, BaseVisualElementPanel panel, VisualElement target, EventCallbackRegistry registry); // 0x0000000182470B90-0x0000000182471100
			public void Clear(); // 0x0000000182470620-0x00000001824706D0
			private void BeginInvoke(); // 0x00000001824705C0-0x0000000182470620
			private void EndInvoke(); // 0x0000000182470760-0x0000000182470980
		}
	
		private struct ArgValueList // TypeDefIndex: 4024
		{
			// Fields
			private EventArgValue m_FirstArg; // 0x00
			private int m_PrevLocalArgId; // 0x08
	
			// Methods
			public bool Find(int argId, out EventArgValue arg); // 0x000000018246F890-0x000000018246F900
			public bool FindByValue<TArg>([IsReadOnly] in ref TArg value, out EventArgValue arg);
			public bool Remove(int argId); // 0x000000018246F990-0x000000018246FA00
			public void Add<TArg>(int argId, [IsReadOnly] in ref TArg value);
			public int AcquireTemporary<TArg>([IsReadOnly] in ref TArg value);
			public void ReleaseTemporary(int argId); // 0x000000018246F920-0x000000018246F990
			public void Clear(); // 0x000000018246F820-0x000000018246F890
			private void Append(EventArgValue argValue); // 0x000000018246F7D0-0x000000018246F820
			private int GenerateLocallyUniqueTemporaryId(); // 0x000000018246F900-0x000000018246F910
			public static bool IsTemporaryId(int argId); // 0x000000018246F910-0x000000018246F920
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4025
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x0000000182477EF0-0x0000000182477F60
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal EventCallbackRegistry _.cctor_b__42_0(); // 0x0000000182477C60-0x0000000182477DE0
		}
	
		// Constructors
		public EventCallbackRegistry(); // 0x0000000182472EB0-0x0000000182473000
		static EventCallbackRegistry(); // 0x0000000182472B80-0x0000000182472EB0
	
		// Methods
		[NotNull]
		private static EventCallbackList GetCallbackList(); // 0x0000000182472030-0x00000001824720C0
		[NotNull]
		private static EventCallbackList GetCallbackList([NotNull] EventCallbackList initializer); // 0x0000000182471F70-0x0000000182472030
		private static void ReleaseCallbackList(EventCallbackList toRelease); // 0x0000000182472300-0x00000001824723C0
		internal IEventInvoker GetEventInvoker(int argId, VisualElement target); // 0x00000001824720D0-0x00000001824721D0
		internal ref DynamicCallbackList GetDynamicCallbackList(CallbackOptionsInternal callbackOptions); // 0x00000001824720C0-0x00000001824720D0
		public void RegisterArg<TArg>(int argId, [IsReadOnly] in ref TArg value);
		public bool UnregisterArg(int argId); // 0x00000001824724C0-0x0000000182472530
		public void RegisterCallback<TEventType>([NotNull] EventCallback<TEventType> userCallback, CallbackOptionsInternal callbackOptions = CallbackOptionsInternal.Default /* Metadata: 0x006604E5 */)
			where TEventType : EventBase<TEventType>, new();
		public void RegisterCallback<TEventType, TCallbackArgs>([NotNull] EventCallback<TEventType, TCallbackArgs> userCallback, CallbackEventHandler element, TCallbackArgs userArgs, CallbackOptionsInternal callbackOptions = CallbackOptionsInternal.Default /* Metadata: 0x006604E6 */)
			where TEventType : EventBase<TEventType>, new();
		private void _RegisterLocalCallback(EventCallbackInternal callback); // 0x00000001824726D0-0x0000000182472900
		public void RegisterCallback(EventCallbackInternal callback); // 0x00000001824722B0-0x0000000182472300
		public bool UnregisterCallback<TEventType>([NotNull] EventCallback<TEventType> callback, CallbackOptionsInternal callbackOptions = CallbackOptionsInternal.Default /* Metadata: 0x006604E7 */)
			where TEventType : EventBase<TEventType>, new();
		public bool UnregisterCallback<TEventType, TCallbackArgs>([NotNull] EventCallback<TEventType, TCallbackArgs> callback, CallbackOptionsInternal callbackOptions = CallbackOptionsInternal.Default /* Metadata: 0x006604E8 */)
			where TEventType : EventBase<TEventType>, new();
		public bool UnregisterCallback(EventCallbackInternal callback); // 0x0000000182472530-0x00000001824726D0
		private bool _UnregisterLocalCallback(Delegate userCallback, long eventTypeId, CallbackOptionsInternal callbackOptions); // 0x0000000182472900-0x0000000182472B80
		internal void ReleaseLocalCallback(EventCallbackInternal c); // 0x00000001824723C0-0x00000001824724C0
		public void InvokeCallbacksTrickleDown(EventBase evt, BaseVisualElementPanel panel, VisualElement target); // 0x0000000182472280-0x00000001824722B0
		public void InvokeCallbacksBubbleUp(EventBase evt, BaseVisualElementPanel panel, VisualElement target); // 0x0000000182472250-0x0000000182472280
		public void Clear(); // 0x0000000182471B70-0x0000000182471EE0
		public static EventCallbackRegistry GetPooled(); // 0x00000001824721D0-0x0000000182472250
		public void Dispose(); // 0x0000000182471EE0-0x0000000182471F70
	}
}
