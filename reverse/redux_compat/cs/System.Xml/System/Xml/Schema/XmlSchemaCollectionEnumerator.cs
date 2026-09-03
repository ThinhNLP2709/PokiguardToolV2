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

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	public sealed class XmlSchemaCollectionEnumerator : IEnumerator // TypeDefIndex: 7187
	{
		// Fields
		private IDictionaryEnumerator enumerator; // 0x10
	
		// Properties
		object IEnumerator.Current { get; } // 0x00000001819D8920-0x00000001819D8930 
		public XmlSchema Current { get; } // 0x00000001819D8A10-0x00000001819D8AA0 
		internal XmlSchemaCollectionNode CurrentNode { get; } // 0x00000001819D8990-0x00000001819D8A10 
	
		// Constructors
		internal XmlSchemaCollectionEnumerator(Hashtable collection); // 0x00000001819D8930-0x00000001819D8990
	
		// Methods
		void IEnumerator.Reset(); // 0x00000001819D88D0-0x00000001819D8920
		bool IEnumerator.MoveNext(); // 0x00000001819D8880-0x00000001819D88D0
		public bool MoveNext(); // 0x00000001819D8830-0x00000001819D8880
	}
}
