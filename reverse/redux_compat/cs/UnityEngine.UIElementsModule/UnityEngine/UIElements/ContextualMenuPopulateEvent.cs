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
	public class ContextualMenuPopulateEvent : MouseEventBase<UnityEngine.UIElements.ContextualMenuPopulateEvent> // TypeDefIndex: 4075
	{
		// Fields
		[CompilerGenerated]
		private DropdownMenu _menu_k__BackingField; // 0xB8
		[CompilerGenerated]
		private EventBase _triggerEvent_k__BackingField; // 0xC0
		private ContextualMenuManager m_ContextualMenuManager; // 0xC8
	
		// Properties
		public DropdownMenu menu { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806CCB90-0x00000001806CCBA0 0x00000001806CCDE0-0x00000001806CCE00
		public EventBase triggerEvent { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806CCB70-0x00000001806CCB80 0x00000001806CCDA0-0x00000001806CCDC0
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4076
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824AADA0-0x00000001824AAE10
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal ContextualMenuPopulateEvent _.cctor_b__0_0(); // 0x00000001824A98D0-0x00000001824A9940
		}
	
		// Constructors
		static ContextualMenuPopulateEvent(); // 0x000000018248E8F0-0x000000018248E9D0
		public ContextualMenuPopulateEvent(); // 0x000000018248E9D0-0x000000018248EA20
	
		// Methods
		public static ContextualMenuPopulateEvent GetPooled(EventBase triggerEvent, DropdownMenu menu, IEventHandler target, ContextualMenuManager menuManager); // 0x000000018248E420-0x000000018248E7A0
		protected override void Init(); // 0x000000018248E7A0-0x000000018248E7C0
		private new void LocalInit(); // 0x000000018248E7C0-0x000000018248E850
		protected internal override void PostDispatch(IPanel panel); // 0x000000018248E850-0x000000018248E8F0
	}
}
