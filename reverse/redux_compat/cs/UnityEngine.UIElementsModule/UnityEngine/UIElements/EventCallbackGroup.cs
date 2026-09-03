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
	public struct EventCallbackGroup // TypeDefIndex: 3998
	{
		// Fields
		internal readonly EventCallbackGroupInternal g; // 0x00
	
		// Constructors
		public EventCallbackGroup(params EventCallbackDefinition[] callbacks); // 0x0000000182471120-0x0000000182471270
	
		// Methods
		public void Register(VisualElement element); // 0x000000018122B650-0x000000018122B660
		public void Unregister(VisualElement element); // 0x000000018122B660-0x000000018122B670
		public bool IsRegistered(VisualElement element); // 0x0000000182471110-0x0000000182471120
	}
}
