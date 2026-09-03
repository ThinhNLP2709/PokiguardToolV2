/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.ComponentModel
{
	public class AttributeCollection : ICollection // TypeDefIndex: 8824
	{
		// Fields
		public static readonly AttributeCollection Empty; // 0x00
		private static Hashtable s_defaultAttributes; // 0x08
		private readonly Attribute[] _attributes; // 0x10
		private static readonly object s_internalSyncObject; // 0x10
		private AttributeEntry[] _foundAttributeTypes; // 0x18
		private int _index; // 0x20
	
		// Properties
		protected virtual Attribute[] Attributes { get; } // 0x0000000180377550-0x0000000180377560 
		public int Count { get; } // 0x0000000181B892E0-0x0000000181B89310 
		public virtual Attribute this[Type attributeType] { get => default; } // 0x0000000181B89600-0x0000000181B89BA0 
		bool ICollection.IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		object ICollection.SyncRoot { get; } // 0x00000001802E7860-0x00000001802E7870 
		int ICollection.Count { get; } // 0x0000000181B892E0-0x0000000181B89310 
	
		// Nested types
		private struct AttributeEntry // TypeDefIndex: 8825
		{
			// Fields
			public Type type; // 0x00
			public int index; // 0x08
		}
	
		// Constructors
		public AttributeCollection(params Attribute[] attributes); // 0x0000000181B894D0-0x0000000181B89600
		static AttributeCollection(); // 0x0000000181B89310-0x0000000181B894D0
	
		// Methods
		public bool Contains(Attribute attribute); // 0x0000000181B88C80-0x0000000181B88D00
		protected Attribute GetDefaultAttribute(Type attributeType); // 0x0000000181B88D90-0x0000000181B892B0
		public IEnumerator GetEnumerator(); // 0x0000000181B892B0-0x0000000181B892E0
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181B892B0-0x0000000181B892E0
		public void CopyTo(Array array, int index); // 0x0000000181B88D00-0x0000000181B88D90
	}
}
