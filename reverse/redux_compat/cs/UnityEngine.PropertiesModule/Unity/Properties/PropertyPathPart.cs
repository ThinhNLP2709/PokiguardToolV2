/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 30: UnityEngine.PropertiesModule.dll - Assembly: UnityEngine.PropertiesModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14428-14600

namespace Unity.Properties
{
	[IsReadOnly]
	public struct PropertyPathPart : IEquatable<Unity.Properties.PropertyPathPart> // TypeDefIndex: 14456
	{
		// Fields
		private readonly PropertyPathPartKind m_Kind; // 0x00
		private readonly string m_Name; // 0x08
		private readonly int m_Index; // 0x10
		private readonly object m_Key; // 0x18
	
		// Properties
		public bool IsName { get; } // 0x00000001819337A0-0x00000001819337B0 
		public bool IsIndex { get; } // 0x0000000181D17490-0x0000000181D174A0 
		public PropertyPathPartKind Kind { get; } // 0x0000000180732D10-0x0000000180732D20 
		public string Name { get; } // 0x00000001822DD360-0x00000001822DD3C0 
		public int Index { get; } // 0x00000001822DD2A0-0x00000001822DD300 
		public object Key { get; } // 0x00000001822DD300-0x00000001822DD360 
	
		// Constructors
		public PropertyPathPart(string name); // 0x00000001822DD260-0x00000001822DD2A0
		public PropertyPathPart(int index); // 0x00000001822DD200-0x00000001822DD260
		public PropertyPathPart(object key); // 0x00000001822DD1A0-0x00000001822DD200
	
		// Methods
		private void CheckKind(PropertyPathPartKind type); // 0x00000001822DCE60-0x00000001822DCEB0
		public override string ToString(); // 0x00000001822DD090-0x00000001822DD1A0
		public bool Equals(PropertyPathPart other); // 0x00000001822DCF80-0x00000001822DCFE0
		public override bool Equals(object obj); // 0x00000001822DCEB0-0x00000001822DCF80
		public override int GetHashCode(); // 0x00000001822DCFE0-0x00000001822DD090
	}
}
