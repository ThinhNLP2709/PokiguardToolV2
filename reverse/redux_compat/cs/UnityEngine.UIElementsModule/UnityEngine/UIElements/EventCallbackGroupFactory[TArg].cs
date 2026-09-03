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
	internal class EventCallbackGroupFactory<TArg> // TypeDefIndex: 4012
	{
		// Fields
		private readonly Func<EventArg<TArg>, EventCallbackGroup> m_CreateGroup;
		private Group m_First;
	
		// Nested types
		public class Group // TypeDefIndex: 4013
		{
			// Fields
			internal EventCallbackGroupFactory<TArg> factory;
			internal EventArg<TArg> arg;
			internal EventCallbackGroup group;
			internal int refCount;
			internal Group<TArg> prev;
			internal Group<TArg> next;
	
			// Constructors
			public Group();
	
			// Methods
			public void Unregister(VisualElement ve);
		}
	
		// Constructors
		public EventCallbackGroupFactory(Func<EventArg<TArg>, EventCallbackGroup> createGroup);
	
		// Methods
		private Group GetNonRegisteredGroupForElement(VisualElement ve);
		public Group Register(VisualElement ve, TArg argValue);
		private void Unregister(Group group, VisualElement ve);
	}
}
