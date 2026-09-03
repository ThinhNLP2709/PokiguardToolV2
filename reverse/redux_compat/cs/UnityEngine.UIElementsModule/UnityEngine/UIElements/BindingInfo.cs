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
	[IsReadOnly]
	public struct BindingInfo // TypeDefIndex: 3847
	{
		// Fields
		[CompilerGenerated]
		private readonly VisualElement _targetElement_k__BackingField; // 0x00
		[CompilerGenerated]
		private readonly BindingId _bindingId_k__BackingField; // 0x08
		[CompilerGenerated]
		private readonly Binding _binding_k__BackingField; // 0xA0
	
		// Properties
		public Binding binding { [CompilerGenerated] get; } // 0x00000001805B5990-0x00000001805B59A0 
	
		// Constructors
		private BindingInfo(VisualElement targetElement, [IsReadOnly] in BindingId bindingId, Binding binding); // 0x000000018237EBD0-0x000000018237ECB0
	
		// Methods
		internal static BindingInfo FromRequest(VisualElement target, [IsReadOnly] in PropertyPath targetPath, Binding binding); // 0x000000018237EAE0-0x000000018237EBD0
		internal static BindingInfo FromBindingData([IsReadOnly] in DataBindingManager.BindingData bindingData); // 0x000000018237EA60-0x000000018237EAE0
	}
}
