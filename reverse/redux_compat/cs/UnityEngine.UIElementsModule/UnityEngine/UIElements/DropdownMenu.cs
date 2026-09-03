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
	public class DropdownMenu // TypeDefIndex: 3943
	{
		// Fields
		private List<DropdownMenuItem> m_MenuItems; // 0x10
		private DropdownMenuEventInfo m_DropdownMenuEventInfo; // 0x18
		[CompilerGenerated]
		private bool _repaintPanelBeforeDisplay_k__BackingField; // 0x20
	
		// Properties
		internal int Count { get; } // 0x0000000180B5F570-0x0000000180B5F590 
		internal bool repaintPanelBeforeDisplay { [CompilerGenerated] set; } // 0x00000001813C7380-0x00000001813C7390
	
		// Constructors
		public DropdownMenu(); // 0x000000018239C170-0x000000018239C1F0
	
		// Methods
		public List<DropdownMenuItem> MenuItems(); // 0x0000000180377550-0x0000000180377560
		public void AppendAction(string actionName, Action<DropdownMenuAction> action, Func<DropdownMenuAction, DropdownMenuAction.Status> actionStatusCallback, object userData = null); // 0x000000018239BD00-0x000000018239BE30
		public void InsertSeparator(string subMenuPath, int atIndex); // 0x000000018239BE30-0x000000018239BF50
		public void PrepareForDisplay(EventBase e); // 0x000000018239BF50-0x000000018239C170
	}
}
