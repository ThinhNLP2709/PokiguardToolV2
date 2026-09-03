/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 23: UnityEngine.IMGUIModule.dll - Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13910-13956

namespace UnityEngine
{
	[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
	internal struct EventInterests // TypeDefIndex: 13919
	{
		// Fields
		[CompilerGenerated]
		private bool _wantsMouseMove_k__BackingField; // 0x00
		[CompilerGenerated]
		private bool _wantsMouseEnterLeaveWindow_k__BackingField; // 0x01
		[CompilerGenerated]
		private bool _wantsLessLayoutEvents_k__BackingField; // 0x02
	
		// Properties
		public bool wantsMouseMove { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180333490-0x00000001803334A0 0x0000000180F21780-0x0000000180F21790
		public bool wantsMouseEnterLeaveWindow { [CompilerGenerated] [IsReadOnly] get; [CompilerGenerated] set; } // 0x0000000180C572C0-0x0000000180C572D0 0x0000000181CE2B40-0x0000000181CE2B50
		public bool wantsLessLayoutEvents { [IsReadOnly] [CompilerGenerated] get; } // 0x000000018166C8F0-0x000000018166C900 
	
		// Methods
		public bool WantsEvent(EventType type); // 0x0000000182277030-0x0000000182277050
		public bool WantsLayoutPass(EventType type); // 0x0000000182277050-0x0000000182277150
	}
}
