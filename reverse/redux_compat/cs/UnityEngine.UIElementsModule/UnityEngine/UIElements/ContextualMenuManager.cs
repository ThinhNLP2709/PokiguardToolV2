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
	public abstract class ContextualMenuManager // TypeDefIndex: 3873
	{
		// Fields
		[CompilerGenerated]
		private bool _displayMenuHandledOSX_k__BackingField; // 0x10
	
		// Properties
		internal bool displayMenuHandledOSX { [CompilerGenerated] set; } // 0x00000001804C2E20-0x00000001804C2E30
	
		// Methods
		internal virtual bool CheckIfEventMatches(EventBase evt); // 0x00000001802E7840-0x00000001802E7850
		public void DisplayMenu(EventBase triggerEvent, IEventHandler target); // 0x0000000182384AC0-0x0000000182384B50
		internal void DisplayMenu(EventBase triggerEvent, IEventHandler target, DropdownMenu menu); // 0x0000000182384820-0x0000000182384AC0
		protected internal abstract void DoDisplayMenu(DropdownMenu menu, EventBase triggerEvent);
		internal static void ResetPointerDown(int pointerId); // 0x0000000182384B50-0x0000000182384BA0
		internal void BeforePointerDown(); // 0x0000000181738210-0x0000000181738220
		internal void AfterPointerUp(); // 0x0000000181738210-0x0000000181738220
	}
}
