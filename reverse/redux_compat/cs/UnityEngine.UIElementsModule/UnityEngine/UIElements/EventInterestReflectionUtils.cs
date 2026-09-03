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
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal static class EventInterestReflectionUtils // TypeDefIndex: 4947
	{
		// Fields
		private static readonly Dictionary<Type, EventCategory> s_EventCategories; // 0x00
	
		// Constructors
		static EventInterestReflectionUtils(); // 0x00000001823CE250-0x00000001823CE2E0
	
		// Methods
		internal static void GetDefaultEventInterests(Type elementType, out VisualElement.DefaultEventInterests categories, out VisualElement.TypeData parentTypeData); // 0x00000001823CDE00-0x00000001823CE060
		private static int ComputeDefaultEventInterests(Type elementType, string methodName); // 0x00000001823CDBF0-0x00000001823CDE00
		internal static EventCategory GetEventCategory(Type eventType); // 0x00000001823CE060-0x00000001823CE250
	}
}
