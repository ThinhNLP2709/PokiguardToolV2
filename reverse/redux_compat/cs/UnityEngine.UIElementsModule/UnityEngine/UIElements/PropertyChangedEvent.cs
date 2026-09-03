/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal class PropertyChangedEvent : EventBase<UnityEngine.UIElements.PropertyChangedEvent>, IProfilerIgnoredEvent // TypeDefIndex: 4945
	{
		// Fields
		[CompilerGenerated]
		private BindingId _property_k__BackingField; // 0x68
	
		// Properties
		public BindingId property { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001823CF880-0x00000001823CF900 0x00000001823CF900-0x00000001823CF980
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 4946
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x00000001823D3980-0x00000001823D39F0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal PropertyChangedEvent _.cctor_b__0_0(); // 0x00000001823D3420-0x00000001823D34C0
		}
	
		// Constructors
		static PropertyChangedEvent(); // 0x00000001823CF720-0x00000001823CF800
		public PropertyChangedEvent(); // 0x00000001823CF800-0x00000001823CF880
	
		// Methods
		public static PropertyChangedEvent GetPooled([IsReadOnly] in BindingId property); // 0x00000001823CF600-0x00000001823CF720
	}
}
