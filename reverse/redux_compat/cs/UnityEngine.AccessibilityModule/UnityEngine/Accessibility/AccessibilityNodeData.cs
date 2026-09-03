/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 55: UnityEngine.AccessibilityModule.dll - Assembly: UnityEngine.AccessibilityModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15611-15635

namespace UnityEngine.Accessibility
{
	[NativeHeader("Modules/Accessibility/Native/AccessibilityNodeData.h")]
	[RequiredByNativeCode]
	internal struct AccessibilityNodeData // TypeDefIndex: 15622
	{
		// Fields
		[CompilerGenerated]
		private int[] _childIds_k__BackingField; // 0x00
		[CompilerGenerated]
		private string _label_k__BackingField; // 0x08
		[CompilerGenerated]
		private string _value_k__BackingField; // 0x10
		[CompilerGenerated]
		private string _hint_k__BackingField; // 0x18
		[CompilerGenerated]
		private Rect _frame_k__BackingField; // 0x20
		[CompilerGenerated]
		private int _nodeId_k__BackingField; // 0x30
		[CompilerGenerated]
		private int _parentId_k__BackingField; // 0x34
		[CompilerGenerated]
		private AccessibilityRole _role_k__BackingField; // 0x38
		[CompilerGenerated]
		private AccessibilityState _state_k__BackingField; // 0x39
		[CompilerGenerated]
		private bool _isActive_k__BackingField; // 0x3A
		[CompilerGenerated]
		private bool _allowsDirectInteraction_k__BackingField; // 0x3B
		[CompilerGenerated]
		private bool _implementsInvoked_k__BackingField; // 0x3C
		[CompilerGenerated]
		private bool _implementsScrolled_k__BackingField; // 0x3D
		[CompilerGenerated]
		private bool _implementsDismissed_k__BackingField; // 0x3E
	
		// Properties
		public int[] childIds { [CompilerGenerated] set; } // 0x0000000180E02C90-0x0000000180E02CA0
		public string label { [CompilerGenerated] set; } // 0x0000000181B9F360-0x0000000181B9F370
		public string value { [CompilerGenerated] set; } // 0x00000001803780D0-0x00000001803780E0
		public string hint { [CompilerGenerated] set; } // 0x00000001802FAF70-0x00000001802FAF80
		public Rect frame { [CompilerGenerated] set; } // 0x0000000181424780-0x0000000181424790
		public int nodeId { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
		public int parentId { [CompilerGenerated] set; } // 0x000000018033E770-0x000000018033E780
		public AccessibilityRole role { [CompilerGenerated] set; } // 0x00000001804763A0-0x00000001804763B0
		public AccessibilityState state { [CompilerGenerated] set; } // 0x00000001816DA820-0x00000001816DA830
		public bool isActive { [CompilerGenerated] set; } // 0x00000001814CFF40-0x00000001814CFF50
		public bool allowsDirectInteraction { [CompilerGenerated] set; } // 0x000000018212B800-0x000000018212B810
		public bool implementsInvoked { [CompilerGenerated] set; } // 0x0000000180C263E0-0x0000000180C263F0
		public bool implementsScrolled { [CompilerGenerated] set; } // 0x000000018212B820-0x000000018212B830
		public bool implementsDismissed { [CompilerGenerated] set; } // 0x000000018212B810-0x000000018212B820
	
		// Constructors
		public AccessibilityNodeData(); // 0x000000018212B730-0x000000018212B800
	}
}
