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
using UnityEngine.UIElements.StyleSheets;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[IsByRefLike]
	[IsReadOnly]
	[Obsolete("Types with embedded references are not supported in this version of your compiler.", true)]
	[VisibleToOtherModules(new string[1] {"UnityEditor.UIBuilderModule" })]
	internal struct CustomPropertyListRef // TypeDefIndex: 4371
	{
		// Fields
		private readonly CustomPropertyList m_Self; // 0x00
	
		// Properties
		public int Count { get; } // 0x0000000182523AB0-0x0000000182523AF0 
	
		// Constructors
		public CustomPropertyListRef(CustomPropertyList self); // 0x0000000180CBE820-0x0000000180CBE830
	
		// Methods
		public bool TryGetValue(UniqueStyleString name, out StylePropertyValue value); // 0x00000001825239D0-0x0000000182523AB0
		public bool ContainsKey(UniqueStyleString name); // 0x00000001825238D0-0x0000000182523950
		public void Remove(UniqueStyleString name); // 0x0000000182523950-0x00000001825239D0
		public static implicit operator CustomPropertyListRef(CustomPropertyList list); // 0x0000000180370C60-0x0000000180370C70
	}
}
