/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
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
	public abstract class CallbackEventHandler : IEventHandler // TypeDefIndex: 4029
	{
		// Fields
		internal bool isIMGUIContainer; // 0x10
		internal EventCallbackRegistry m_CallbackRegistry; // 0x18
	
		// Constructors
		protected CallbackEventHandler(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void RegisterCallback<TEventType>(EventCallback<TEventType> callback, TrickleDown useTrickleDown = TrickleDown.NoTrickleDown /* Metadata: 0x006604EF */)
			where TEventType : EventBase<TEventType>, new();
		public void RegisterCallbackOnce<TEventType>(EventCallback<TEventType> callback, TrickleDown useTrickleDown = TrickleDown.NoTrickleDown /* Metadata: 0x006604F0 */)
			where TEventType : EventBase<TEventType>, new();
		private void AddEventCategories<TEventType>(CallbackOptionsInternal callbackOptions)
			where TEventType : EventBase<TEventType>, new();
		public void RegisterCallback<TEventType, TUserArgsType>(EventCallback<TEventType, TUserArgsType> callback, TUserArgsType userArgs, TrickleDown useTrickleDown = TrickleDown.NoTrickleDown /* Metadata: 0x006604F1 */)
			where TEventType : EventBase<TEventType>, new();
		public void RegisterCallback<TEventType>(EventCallback<TEventType> callback, CallbackOptions callbackOptions)
			where TEventType : EventBase<TEventType>, new();
		public void UnregisterCallback<TEventType>(EventCallback<TEventType> callback, TrickleDown useTrickleDown = TrickleDown.NoTrickleDown /* Metadata: 0x006604F2 */)
			where TEventType : EventBase<TEventType>, new();
		public void UnregisterCallback<TEventType, TUserArgsType>(EventCallback<TEventType, TUserArgsType> callback, TrickleDown useTrickleDown = TrickleDown.NoTrickleDown /* Metadata: 0x006604F3 */)
			where TEventType : EventBase<TEventType>, new();
		internal void AddListenersAndCategories<TEventType>(Delegate callback, CallbackOptionsInternal callbackOptions)
			where TEventType : EventBase<TEventType>, new();
		internal void RemoveListeners<TEventType>(Delegate callback)
			where TEventType : EventBase<TEventType>, new();
		public abstract void SendEvent(EventBase e);
		[VisibleToOtherModules(new string[1] {"UnityEngine.HierarchyModule" })]
		internal abstract void SendEvent(EventBase e, DispatchMode dispatchMode);
		[EventInterest(EventInterestOptions.Inherit)]
		[Obsolete("Use HandleEventBubbleUp. Before proceeding, make sure you understand the latest changes to UIToolkit event propagation rules by visiting Unity\'s manual page https://docs.unity3d.com/Manual/UIE-Events-Dispatching.html")]
		protected virtual void ExecuteDefaultActionAtTarget(EventBase evt); // 0x00000001802E76C0-0x00000001802E76D0
		[EventInterest(EventInterestOptions.Inherit)]
		protected virtual void HandleEventBubbleUp(EventBase evt); // 0x00000001802E76C0-0x00000001802E76D0
		[EventInterest(EventInterestOptions.Inherit)]
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal virtual void HandleEventBubbleUpDisabled(EventBase evt); // 0x00000001802E76C0-0x00000001802E76D0
		internal void HandleEventBubbleUpInternal(EventBase evt); // 0x000000018195C640-0x000000018195C660
		[EventInterest(EventInterestOptions.Inherit)]
		protected virtual void HandleEventTrickleDown(EventBase evt); // 0x00000001802E76C0-0x00000001802E76D0
		[EventInterest(EventInterestOptions.Inherit)]
		internal virtual void HandleEventTrickleDownDisabled(EventBase evt); // 0x00000001802E76C0-0x00000001802E76D0
		internal void HandleEventTrickleDownInternal(EventBase evt); // 0x0000000181CF8450-0x0000000181CF8470
		[EventInterest(EventInterestOptions.Inherit)]
		[Obsolete("Use HandleEventBubbleUp. Before proceeding, make sure you understand the latest changes to UIToolkit event propagation rules by visiting Unity\'s manual page https://docs.unity3d.com/Manual/UIE-Events-Dispatching.html")]
		protected virtual void ExecuteDefaultAction(EventBase evt); // 0x00000001802E76C0-0x00000001802E76D0
		[EventInterest(EventInterestOptions.Inherit)]
		[Obsolete("Use HandleEventBubbleUpDisabled.")]
		internal virtual void ExecuteDefaultActionDisabledAtTarget(EventBase evt); // 0x00000001802E76C0-0x00000001802E76D0
		[EventInterest(EventInterestOptions.Inherit)]
		[Obsolete("Use HandleEventBubbleUpDisabled.")]
		internal virtual void ExecuteDefaultActionDisabled(EventBase evt); // 0x00000001802E76C0-0x00000001802E76D0
		internal void ExecuteDefaultActionInternal(EventBase evt); // 0x0000000182273490-0x00000001822734B0
		internal void ExecuteDefaultActionDisabledInternal(EventBase evt); // 0x000000018248DF20-0x000000018248DF40
		internal void ExecuteDefaultActionAtTargetInternal(EventBase evt); // 0x000000018237CB00-0x000000018237CB20
		internal void ExecuteDefaultActionDisabledAtTargetInternal(EventBase evt); // 0x0000000181745CF0-0x0000000181745D10
		protected void NotifyPropertyChanged([IsReadOnly] in BindingId property); // 0x000000018248DF40-0x000000018248E0B0
	}
}
