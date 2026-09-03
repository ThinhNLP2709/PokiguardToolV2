/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	public class XmlSchemaObjectTable // TypeDefIndex: 7234
	{
		// Fields
		private Dictionary<XmlQualifiedName, XmlSchemaObject> table; // 0x10
		private List<XmlSchemaObjectEntry> entries; // 0x18
	
		// Properties
		public int Count { get; } // 0x0000000180F0C250-0x0000000180F0C270 
		public XmlSchemaObject this[XmlQualifiedName name] { get => default; } // 0x00000001819E81A0-0x00000001819E8220 
		public ICollection Values { get; } // 0x00000001819E8220-0x00000001819E82B0 
	
		// Nested types
		internal enum EnumeratorType // TypeDefIndex: 7235
		{
			Keys = 0,
			Values = 1,
			DictionaryEntry = 2
		}
	
		internal struct XmlSchemaObjectEntry // TypeDefIndex: 7236
		{
			// Fields
			internal XmlQualifiedName qname; // 0x00
			internal XmlSchemaObject xso; // 0x08
	
			// Constructors
			public XmlSchemaObjectEntry(XmlQualifiedName name, XmlSchemaObject value); // 0x0000000180CC3FE0-0x0000000180CC4020
		}
	
		internal class ValuesCollection : ICollection // TypeDefIndex: 7237
		{
			// Fields
			private List<XmlSchemaObjectEntry> entries; // 0x10
			private int size; // 0x18
	
			// Properties
			public int Count { get; } // 0x0000000180B23260-0x0000000180B23270 
			public object SyncRoot { get; } // 0x00000001819E0CF0-0x00000001819E0D40 
			public bool IsSynchronized { get; } // 0x00000001819E0CA0-0x00000001819E0CF0 
	
			// Constructors
			internal ValuesCollection(List<XmlSchemaObjectEntry> entries, int size); // 0x0000000180E02950-0x0000000180E029A0
	
			// Methods
			public void CopyTo(Array array, int arrayIndex); // 0x00000001819E0AE0-0x00000001819E0C10
			public IEnumerator GetEnumerator(); // 0x00000001819E0C10-0x00000001819E0CA0
		}
	
		internal class XSOEnumerator : IEnumerator // TypeDefIndex: 7238
		{
			// Fields
			private List<XmlSchemaObjectEntry> entries; // 0x10
			private EnumeratorType enumType; // 0x18
			protected int currentIndex; // 0x1C
			protected int size; // 0x20
			protected XmlQualifiedName currentKey; // 0x28
			protected XmlSchemaObject currentValue; // 0x30
	
			// Properties
			public object Current { get; } // 0x00000001819E1320-0x00000001819E1530 
	
			// Constructors
			internal XSOEnumerator(List<XmlSchemaObjectEntry> entries, int size, EnumeratorType enumType); // 0x00000001819E0D40-0x00000001819E0DA0
	
			// Methods
			public bool MoveNext(); // 0x00000001819E1230-0x00000001819E12E0
			public void Reset(); // 0x00000001819E12E0-0x00000001819E1320
		}
	
		internal class XSODictionaryEnumerator : XSOEnumerator, IDictionaryEnumerator // TypeDefIndex: 7239
		{
			// Properties
			public DictionaryEntry Entry { get; } // 0x00000001819E0DA0-0x00000001819E0F30 
			public object Key { get; } // 0x00000001819E0F30-0x00000001819E10B0 
			public object Value { get; } // 0x00000001819E10B0-0x00000001819E1230 
	
			// Constructors
			internal XSODictionaryEnumerator(List<XmlSchemaObjectEntry> entries, int size, EnumeratorType enumType); // 0x00000001819E0D40-0x00000001819E0DA0
		}
	
		// Constructors
		internal XmlSchemaObjectTable(); // 0x00000001819E80E0-0x00000001819E81A0
	
		// Methods
		internal void Add(XmlQualifiedName name, XmlSchemaObject value); // 0x00000001819E7AB0-0x00000001819E7BE0
		internal void Insert(XmlQualifiedName name, XmlSchemaObject value); // 0x00000001819E7DD0-0x00000001819E7F10
		internal void Replace(XmlQualifiedName name, XmlSchemaObject value); // 0x00000001819E7FC0-0x00000001819E80E0
		internal void Clear(); // 0x00000001819E7BE0-0x00000001819E7C40
		internal void Remove(XmlQualifiedName name); // 0x00000001819E7F10-0x00000001819E7FC0
		private int FindIndexByValue(XmlSchemaObject xso); // 0x00000001819E7CA0-0x00000001819E7D30
		public bool Contains(XmlQualifiedName name); // 0x00000001819E7C40-0x00000001819E7CA0
		public IDictionaryEnumerator GetEnumerator(); // 0x00000001819E7D30-0x00000001819E7DD0
	}
}
