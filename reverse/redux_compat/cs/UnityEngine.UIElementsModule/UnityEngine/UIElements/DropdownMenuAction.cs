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
	public class DropdownMenuAction : DropdownMenuItem // TypeDefIndex: 3941
	{
		// Fields
		[CompilerGenerated]
		private readonly string _name_k__BackingField; // 0x10
		[CompilerGenerated]
		private Status _status_k__BackingField; // 0x18
		[CompilerGenerated]
		private DropdownMenuEventInfo _eventInfo_k__BackingField; // 0x20
		[CompilerGenerated]
		private object _userData_k__BackingField; // 0x28
		private readonly Action<DropdownMenuAction> actionCallback; // 0x30
		private readonly Func<DropdownMenuAction, Status> actionStatusCallback; // 0x38
	
		// Properties
		private Status status { [CompilerGenerated] set; } // 0x0000000180F9EB90-0x0000000180F9EBA0
		private DropdownMenuEventInfo eventInfo { [CompilerGenerated] set; } // 0x000000018033E830-0x000000018033E840
		private object userData { [CompilerGenerated] set; } // 0x000000018033E840-0x000000018033E850
	
		// Nested types
		[Flags]
		public enum Status // TypeDefIndex: 3942
		{
			None = 0,
			Normal = 1,
			Disabled = 2,
			Checked = 4,
			Hidden = 8
		}
	
		// Constructors
		public DropdownMenuAction(string actionName, Action<DropdownMenuAction> actionCallback, Func<DropdownMenuAction, Status> actionStatusCallback, object userData = null); // 0x000000018239B9E0-0x000000018239BA60
	
		// Methods
		public void UpdateActionStatus(DropdownMenuEventInfo eventInfo); // 0x000000018239B990-0x000000018239B9E0
	}
}
