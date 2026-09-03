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
using System.Threading;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	[Obsolete("Use System.Xml.Schema.XmlSchemaSet for schema compilation and validation. https://go.microsoft.com/fwlink/?linkid=14202")]
	public sealed class XmlSchemaCollection : ICollection // TypeDefIndex: 7185
	{
		// Fields
		private Hashtable collection; // 0x10
		private XmlNameTable nameTable; // 0x18
		private SchemaNames schemaNames; // 0x20
		private ReaderWriterLock wLock; // 0x28
		private int timeout; // 0x30
		private bool isThreadSafe; // 0x34
		private ValidationEventHandler validationEventHandler; // 0x38
		private XmlResolver xmlResolver; // 0x40
	
		// Properties
		public int Count { get; } // 0x00000001817BECF0-0x00000001817BED20 
		public XmlNameTable NameTable { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		internal XmlResolver XmlResolver { set; } // 0x0000000180378120-0x0000000180378130
		public XmlSchema this[string ns] { get => default; } // 0x00000001819D94E0-0x00000001819D9590 
		bool ICollection.IsSynchronized { get; } // 0x00000001802E7990-0x00000001802E79A0 
		object ICollection.SyncRoot { get; } // 0x0000000180370C60-0x0000000180370C70 
		int ICollection.Count { get; } // 0x00000001817BECF0-0x00000001817BED20 
		internal ValidationEventHandler EventHandler { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
	
		// Constructors
		public XmlSchemaCollection(XmlNameTable nametable); // 0x00000001819D93A0-0x00000001819D94E0
	
		// Methods
		IEnumerator IEnumerable.GetEnumerator(); // 0x00000001819D9310-0x00000001819D93A0
		public XmlSchemaCollectionEnumerator GetEnumerator(); // 0x00000001819D8F00-0x00000001819D8F90
		void ICollection.CopyTo(Array array, int index); // 0x00000001819D9100-0x00000001819D9310
		internal SchemaInfo GetSchemaInfo(string ns); // 0x00000001819D8F90-0x00000001819D9040
		internal SchemaNames GetSchemaNames(XmlNameTable nt); // 0x00000001819D9040-0x00000001819D9100
		internal XmlSchema Add(string ns, SchemaInfo schemaInfo, XmlSchema schema, bool compile); // 0x00000001819D8BF0-0x00000001819D8D80
		private XmlSchema Add(string ns, SchemaInfo schemaInfo, XmlSchema schema, bool compile, XmlResolver resolver); // 0x00000001819D8D80-0x00000001819D8F00
		private void Add(string ns, XmlSchemaCollectionNode node); // 0x00000001819D8AA0-0x00000001819D8BF0
	}
}
