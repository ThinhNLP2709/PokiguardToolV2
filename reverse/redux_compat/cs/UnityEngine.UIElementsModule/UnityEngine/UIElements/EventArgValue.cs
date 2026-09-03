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
	internal abstract class EventArgValue : IEventInvoker // TypeDefIndex: 3982
	{
		// Fields
		public EventArgValue nextArg; // 0x10
		public int argId; // 0x18
		public int temporaryCount; // 0x1C
		public static readonly EventNoArgValue None; // 0x00
	
		// Constructors
		protected EventArgValue(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static EventArgValue(); // 0x000000018239D2E0-0x000000018239D360
	
		// Methods
		public static IEventInvoker Self(VisualElement ve); // 0x000000018239D2B0-0x000000018239D2E0
		public abstract void Dispose();
		public abstract void Invoke(EventBase evt, EventCallbackInternal c);
		public abstract bool ValueEquals<TArg>([IsReadOnly] in ref TArg other);
	}
}
