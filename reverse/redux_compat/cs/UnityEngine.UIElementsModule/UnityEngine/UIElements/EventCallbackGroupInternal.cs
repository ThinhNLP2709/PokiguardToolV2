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
	[IsReadOnly]
	internal struct EventCallbackGroupInternal // TypeDefIndex: 3997
	{
		// Fields
		internal readonly EventCallbackInternal[] m_BubbleUpCallbacks; // 0x00
		internal readonly EventCallbackInternal[] m_TrickleDownCallbacks; // 0x08
		internal readonly int m_BubbleUpCount; // 0x10
		internal readonly int m_TrickleDownCount; // 0x14
		internal readonly int m_BubbleUpCategories; // 0x18
		internal readonly int m_TrickleDownCategories; // 0x1C
	
		// Constructors
		public EventCallbackGroupInternal(params EventCallbackInternal[] callbacks); // 0x000000018239DE00-0x000000018239E0E0
	
		// Methods
		internal void Register(VisualElement ve); // 0x000000018239DC10-0x000000018239DD10
		internal void Unregister(VisualElement ve); // 0x000000018239DD10-0x000000018239DE00
		internal bool IsRegistered(VisualElement ve); // 0x000000018239DB60-0x000000018239DC10
		internal void AddListenersAndCategories(VisualElement ve); // 0x000000018239DB30-0x000000018239DB60
	}
}
