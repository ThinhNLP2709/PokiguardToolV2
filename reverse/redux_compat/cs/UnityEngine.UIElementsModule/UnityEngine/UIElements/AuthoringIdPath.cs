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
	[Serializable]
	public struct AuthoringIdPath : IEquatable<AuthoringIdPath> // TypeDefIndex: 4297
	{
		// Fields
		[SerializeField]
		private int[] m_PathIds; // 0x00
	
		// Properties
		public ReadOnlySpan<int> path { get; } // 0x00000001824CD9E0-0x00000001824CDA80 
	
		// Constructors
		public AuthoringIdPath(); // 0x000000018103EDD0-0x000000018103EDE0
	
		// Methods
		public bool Equals(AuthoringIdPath other); // 0x00000001824CCC00-0x00000001824CCEC0
		public override int GetHashCode(); // 0x00000001824CCEC0-0x00000001824CD7E0
		private static int AggregateHashCode(ReadOnlySpan<int> path); // 0x00000001824CCB10-0x00000001824CCC00
		[VisibleToOtherModules(new string[1] {"UnityEditor.UIToolkitAuthoringModule" })]
		internal string PathToCsvString(char seperator); // 0x00000001824CD7E0-0x00000001824CD8D0
		public override string ToString(); // 0x00000001824CD8D0-0x00000001824CD9E0
	}
}
