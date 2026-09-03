/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public static class EventCallback // TypeDefIndex: 3994
	{
		// Methods
		public static EventCallbackDefinition<TElement> Create<TEvent, TElement>(EventCallback<TEvent, TElement> userCallback, CallbackOptions callbackOptions = CallbackOptions.Default /* Metadata: 0x006604CF */)
			where TEvent : EventBase<TEvent>, new()
			where TElement : VisualElement;
		public static EventCallbackDefinition Create<TEvent, TArg>(EventCallback<TEvent, TArg> userCallback, EventArg<TArg> arg, CallbackOptions callbackOptions = CallbackOptions.Default /* Metadata: 0x006604D0 */)
			where TEvent : EventBase<TEvent>, new();
		private static EventCallbackDefinition Create<TEvent>(Delegate userCallback, int argId, CallbackOptionsInternal callbackOptions)
			where TEvent : EventBase<TEvent>, new();
		private static EventCallbackDefinition<TElement> Create<TEvent, TElement>(Delegate userCallback, int argId, CallbackOptionsInternal callbackOptions)
			where TEvent : EventBase<TEvent>, new()
			where TElement : VisualElement;
	}
}
