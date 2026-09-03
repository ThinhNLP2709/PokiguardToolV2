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
	public class InputEvent : EventBase<UnityEngine.UIElements.InputEvent> // TypeDefIndex: 4041
	{
		// Fields
		[CompilerGenerated]
		private string _previousData_k__BackingField; // 0x68
		[CompilerGenerated]
		private string _newData_k__BackingField; // 0x70
	
		// Properties
		protected string previousData { [CompilerGenerated] set; } // 0x0000000180316A40-0x0000000180316A50
		protected string newData { [CompilerGenerated] set; } // 0x0000000180434A10-0x0000000180434A20
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4042
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001824AB350-0x00000001824AB3C0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal InputEvent _.cctor_b__0_0(); // 0x00000001824A9FE0-0x00000001824AA0A0
		}
	
		// Constructors
		static InputEvent(); // 0x000000018249A090-0x000000018249A170
		public InputEvent(); // 0x000000018249A170-0x000000018249A200
	
		// Methods
		protected override void Init(); // 0x000000018249A000-0x000000018249A050
		private new void LocalInit(); // 0x000000018249A050-0x000000018249A090
		public static InputEvent GetPooled(string previousData, string newData); // 0x0000000182499F60-0x000000018249A000
	}
}
