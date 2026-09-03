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
	internal class EventCallbackInternal // TypeDefIndex: 3993
	{
		// Fields
		[CompilerGenerated]
		private EventBase.TypeData _eventData_k__BackingField; // 0x10
		[CompilerGenerated]
		private Delegate _userCallback_k__BackingField; // 0x18
		[CompilerGenerated]
		private CallbackOptionsInternal _callbackOptions_k__BackingField; // 0x20
		[CompilerGenerated]
		private int _argId_k__BackingField; // 0x24
	
		// Properties
		internal EventBase.TypeData eventData { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		internal Delegate userCallback { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		internal CallbackOptionsInternal callbackOptions { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		internal int argId { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
		internal long eventTypeId { get; } // 0x0000000180FB1BE0-0x0000000180FB1C00 
		internal int eventCategories { get; } // 0x0000000181F622A0-0x0000000181F622C0 
	
		// Constructors
		public EventCallbackInternal(); // 0x00000001802E5CB0-0x00000001802E5CC0
		internal EventCallbackInternal(EventBase.TypeData eventData, Delegate userCallback, CallbackOptionsInternal callbackOptions, int argId); // 0x0000000180E38A60-0x0000000180E38AD0
	
		// Methods
		internal void Reset<TEvent>(Delegate userCallback, int argId, CallbackOptionsInternal callbackOptions)
			where TEvent : EventBase<TEvent>, new();
		internal void Reset(); // 0x000000018239E190-0x000000018239E1D0
		public void Register(VisualElement element); // 0x000000018239E0E0-0x000000018239E190
		public void Unregister(VisualElement element); // 0x000000018239E1D0-0x000000018239E200
	}
}
