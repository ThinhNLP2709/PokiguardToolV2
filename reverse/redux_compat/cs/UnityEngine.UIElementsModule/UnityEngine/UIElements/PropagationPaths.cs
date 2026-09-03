/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using JetBrains.Annotations;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class PropagationPaths : IDisposable // TypeDefIndex: 4126
	{
		// Fields
		private static readonly ObjectPool<PropagationPaths> s_Pool; // 0x00
		public readonly List<VisualElement> trickleDownPath; // 0x10
		public readonly List<VisualElement> bubbleUpPath; // 0x18
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4127
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824AAEF0-0x00000001824AAF60
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal PropagationPaths _.cctor_b__8_0(); // 0x00000001824AA8F0-0x00000001824AA9D0
		}
	
		// Constructors
		public PropagationPaths(); // 0x00000001824A77C0-0x00000001824A7870
		static PropagationPaths(); // 0x00000001824A76B0-0x00000001824A77C0
	
		// Methods
		[NotNull]
		public static PropagationPaths Build(VisualElement elem, EventBase evt, int eventCategories); // 0x00000001824A7340-0x00000001824A75D0
		public void Dispose(); // 0x00000001824A75D0-0x00000001824A76B0
	}
}
