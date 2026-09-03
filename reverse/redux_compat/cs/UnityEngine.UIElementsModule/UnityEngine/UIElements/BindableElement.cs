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
	[UxmlElement]
	public class BindableElement : VisualElement, IBindable // TypeDefIndex: 3816
	{
		// Fields
		[CompilerGenerated]
		private IBinding _binding_k__BackingField; // 0x1A8
		[CompilerGenerated]
		private string _bindingPath_k__BackingField; // 0x1B0
	
		// Properties
		public IBinding binding { [CompilerGenerated] get; } // 0x0000000180E224F0-0x0000000180E22500 
		[Tooltip("Default method to define a path to a serialized property. Most often used for Editor extensions and inspectors.")]
		[UxmlAttribute("binding-path")]
		public string bindingPath { [CompilerGenerated] set; } // 0x0000000181380130-0x0000000181380150
	
		// Constructors
		public BindableElement(); // 0x000000018237DD20-0x000000018237DD70
	}
}
