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
	public struct EventCallbackGroup<TElement> // TypeDefIndex: 3999
		where TElement : VisualElement
	{
		// Fields
		internal readonly EventCallbackGroupInternal g;
	
		// Constructors
		public EventCallbackGroup(params EventCallbackDefinition<TElement>[] callbacks);
	
		// Methods
		public void Register(TElement element);
		public void Unregister(TElement element);
	}
}
