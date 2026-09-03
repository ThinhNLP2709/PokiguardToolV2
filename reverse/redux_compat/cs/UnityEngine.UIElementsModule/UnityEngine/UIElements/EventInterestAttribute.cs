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
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public class EventInterestAttribute : Attribute // TypeDefIndex: 4951
	{
		// Fields
		internal Type[] eventTypes; // 0x10
		internal EventCategoryFlags categoryFlags; // 0x18
	
		// Constructors
		public EventInterestAttribute(params Type[] eventTypes); // 0x00000001802E7420-0x00000001802E7460
		public EventInterestAttribute(EventInterestOptions interests); // 0x00000001822E70C0-0x00000001822E70F0
	}
}
