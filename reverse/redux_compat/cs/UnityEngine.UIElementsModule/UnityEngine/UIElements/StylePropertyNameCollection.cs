/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	public struct StylePropertyNameCollection : IEnumerable<UnityEngine.UIElements.StylePropertyName> // TypeDefIndex: 4132
	{
		// Fields
		internal List<StylePropertyName> propertiesList; // 0x00
	
		// Nested types
		public struct Enumerator : IEnumerator<StylePropertyName> // TypeDefIndex: 4133
		{
			// Fields
			private List<StylePropertyName> m_Enumerator; // 0x00
	
			// Properties
			public StylePropertyName Current { get; } // 0x00000001802E65B0-0x00000001802E65C0 
			object IEnumerator.Current { get; } // 0x00000001824916C0-0x0000000182491710 
	
			// Constructors
			internal Enumerator(List<StylePropertyName> enumerator); // 0x0000000182491710-0x0000000182491730
	
			// Methods
			public bool MoveNext(); // 0x00000001824916B0-0x00000001824916C0
			public void Reset(); // 0x00000001802E76C0-0x00000001802E76D0
			public void Dispose(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		internal StylePropertyNameCollection(List<StylePropertyName> list); // 0x0000000180E02C90-0x0000000180E02CA0
	
		// Methods
		public Enumerator GetEnumerator(); // 0x00000001824A8480-0x00000001824A84D0
		IEnumerator<StylePropertyName> IEnumerable<StylePropertyName>.GetEnumerator(); // 0x00000001824A84D0-0x00000001824A8560
		IEnumerator IEnumerable.GetEnumerator(); // 0x00000001824A8560-0x00000001824A85F0
	}
}
