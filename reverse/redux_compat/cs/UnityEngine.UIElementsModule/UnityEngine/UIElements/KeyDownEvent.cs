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
	public class KeyDownEvent : KeyboardEventBase<UnityEngine.UIElements.KeyDownEvent> // TypeDefIndex: 4045
	{
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4046
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824AB740-0x00000001824AB7B0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal KeyDownEvent _.cctor_b__0_0(); // 0x00000001824AA110-0x00000001824AA180
		}
	
		// Constructors
		static KeyDownEvent(); // 0x000000018249D130-0x000000018249D210
		public KeyDownEvent(); // 0x000000018249D210-0x000000018249D250
	
		// Methods
		protected internal override void PostDispatch(IPanel panel); // 0x000000018249CA80-0x000000018249CB20
		private void SendEquivalentNavigationEventIfAny(IPanel panel); // 0x000000018249CB20-0x000000018249D130
	}
}
