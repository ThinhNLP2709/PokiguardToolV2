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
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
	internal class AuthoringChanges // TypeDefIndex: 3800
	{
		// Fields
		[CompilerGenerated]
		private readonly HashSet<VisualElement> _addedOrMovedElements_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly HashSet<VisualElement> _removedFromPanel_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly HashSet<VisualElement> _styleChanged_k__BackingField; // 0x20
		[CompilerGenerated]
		private readonly HashSet<VisualElement> _stylingContextChanged_k__BackingField; // 0x28
		[CompilerGenerated]
		private readonly HashSet<VisualElement> _bindingContextChanged_k__BackingField; // 0x30
	
		// Properties
		public HashSet<VisualElement> addedOrMovedElements { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public HashSet<VisualElement> removedFromPanel { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public HashSet<VisualElement> styleChanged { [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
		public HashSet<VisualElement> stylingContextChanged { [CompilerGenerated] get; } // 0x000000018033D240-0x000000018033D250 
		public HashSet<VisualElement> bindingContextChanged { [CompilerGenerated] get; } // 0x000000018031E110-0x000000018031E120 
	
		// Constructors
		public AuthoringChanges(); // 0x000000018237CE10-0x000000018237CF40
	
		// Methods
		public bool ContainsChanges(); // 0x000000018237CDA0-0x000000018237CE10
		public void Clear(); // 0x000000018237CD30-0x000000018237CDA0
	}
}
