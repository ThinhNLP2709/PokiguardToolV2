/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[DefaultMember("Item")]
	public struct VisualElementStyleSheetSet : IEquatable<UnityEngine.UIElements.VisualElementStyleSheetSet> // TypeDefIndex: 4962
	{
		// Fields
		private readonly VisualElement m_Element; // 0x00
	
		// Properties
		public int count { get; } // 0x00000001824039C0-0x0000000182403A00 
	
		// Constructors
		internal VisualElementStyleSheetSet(VisualElement element); // 0x0000000180E02C90-0x0000000180E02CA0
	
		// Methods
		public void Add(StyleSheet styleSheet); // 0x0000000182403460-0x0000000182403630
		public void Insert(int index, StyleSheet styleSheet); // 0x00000001824036C0-0x0000000182403870
		public bool Remove(StyleSheet styleSheet); // 0x0000000182403870-0x00000001824039C0
		public bool Equals(VisualElementStyleSheetSet other); // 0x0000000181302150-0x0000000181302160
		public override bool Equals(object obj); // 0x0000000182403630-0x00000001824036C0
		public override int GetHashCode(); // 0x0000000181302320-0x0000000181302340
	}
}
