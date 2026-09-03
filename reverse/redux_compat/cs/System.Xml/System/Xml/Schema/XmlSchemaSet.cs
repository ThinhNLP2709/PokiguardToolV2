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
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	public class XmlSchemaSet // TypeDefIndex: 7245
	{
		// Fields
		private XmlNameTable nameTable; // 0x10
		private SchemaNames schemaNames; // 0x18
		private SortedList schemas; // 0x20
		private ValidationEventHandler internalEventHandler; // 0x28
		private ValidationEventHandler eventHandler; // 0x30
		private bool isCompiled; // 0x38
		private Hashtable schemaLocations; // 0x40
		private Hashtable chameleonSchemas; // 0x48
		private Hashtable targetNamespaces; // 0x50
		private bool compileAll; // 0x58
		private SchemaInfo cachedCompiledInfo; // 0x60
		private XmlReaderSettings readerSettings; // 0x68
		private XmlSchema schemaForSchema; // 0x70
		private XmlSchemaCompilationSettings compilationSettings; // 0x78
		internal XmlSchemaObjectTable elements; // 0x80
		internal XmlSchemaObjectTable attributes; // 0x88
		internal XmlSchemaObjectTable schemaTypes; // 0x90
		internal XmlSchemaObjectTable substitutionGroups; // 0x98
		private XmlSchemaObjectTable typeExtensions; // 0xA0
		private object internalSyncObject; // 0xA8
	
		// Properties
		internal object InternalSyncObject { get; } // 0x00000001819F08D0-0x00000001819F0940 
		public bool IsCompiled { get; } // 0x0000000180476380-0x0000000180476390 
		public XmlResolver XmlResolver { set; } // 0x00000001819F0B00-0x00000001819F0B20
		public XmlSchemaCompilationSettings CompilationSettings { get; set; } // 0x000000018033D4E0-0x000000018033D4F0 0x000000018033EA70-0x000000018033EA80
		public int Count { get; } // 0x00000001819F0720-0x00000001819F0750 
		public XmlSchemaObjectTable GlobalElements { get; } // 0x00000001819F07D0-0x00000001819F0850 
		public XmlSchemaObjectTable GlobalAttributes { get; } // 0x00000001819F0750-0x00000001819F07D0 
		public XmlSchemaObjectTable GlobalTypes { get; } // 0x00000001819F0850-0x00000001819F08D0 
		internal XmlSchemaObjectTable SubstitutionGroups { get; } // 0x00000001819F0940-0x00000001819F09C0 
		internal Hashtable SchemaLocations { get; } // 0x0000000180377940-0x0000000180377950 
		internal XmlSchemaObjectTable TypeExtensions { get; } // 0x00000001819F09C0-0x00000001819F0A40 
		internal SchemaInfo CompiledInfo { get; } // 0x0000000180333260-0x0000000180333490 
		internal XmlReaderSettings ReaderSettings { get; } // 0x0000000180316960-0x0000000180316970 
		internal SortedList SortedSchemas { get; } // 0x00000001802F8630-0x00000001802F8640 
	
		// Events
		public event ValidationEventHandler ValidationEventHandler {
			add; // 0x00000001819F05E0-0x00000001819F0720
			remove; // 0x00000001819F0A40-0x00000001819F0B00
		}
	
		// Constructors
		public XmlSchemaSet(); // 0x00000001819F0280-0x00000001819F02E0
		public XmlSchemaSet(XmlNameTable nameTable); // 0x00000001819F02E0-0x00000001819F05E0
	
		// Methods
		public void Add(XmlSchemaSet schemas); // 0x00000001819E9860-0x00000001819E9FE0
		public XmlSchema Add(XmlSchema schema); // 0x00000001819EA480-0x00000001819EA6A0
		public bool RemoveRecursive(XmlSchema schemaToRemove); // 0x00000001819ED870-0x00000001819EE100
		public bool Contains(string targetNamespace); // 0x00000001819EAE30-0x00000001819EAE80
		public void Compile(); // 0x00000001819EA8B0-0x00000001819EAE30
		public XmlSchema Reprocess(XmlSchema schema); // 0x00000001819EF330-0x00000001819EFB00
		public void CopyTo(XmlSchema[] schemas, int index); // 0x00000001819EC310-0x00000001819EC4B0
		public ICollection Schemas(); // 0x00000001819F0070-0x00000001819F00A0
		public ICollection Schemas(string targetNamespace); // 0x00000001819EFED0-0x00000001819F0070
		private XmlSchema Add(string targetNamespace, XmlSchema schema); // 0x00000001819E9800-0x00000001819E9860
		internal void Add(string targetNamespace, XmlReader reader, Hashtable validatedNamespaces); // 0x00000001819E9FE0-0x00000001819EA480
		internal XmlSchema FindSchemaByNSAndUrl(Uri schemaUri, string ns, DictionaryEntry[] locationsTable); // 0x00000001819EC4B0-0x00000001819EC780
		private void AddSchemaToSet(XmlSchema schema); // 0x00000001819E9050-0x00000001819E9450
		private void ProcessNewSubstitutionGroups(XmlSchemaObjectTable substitutionGroupsTable, bool resolve); // 0x00000001819ED4F0-0x00000001819ED870
		private void ResolveSubstitutionGroup(XmlSchemaSubstitutionGroup substitutionGroup, XmlSchemaObjectTable substTable); // 0x00000001819EFB00-0x00000001819EFED0
		internal XmlSchema Remove(XmlSchema schema, bool forceCompile); // 0x00000001819EEFF0-0x00000001819EF330
		private void ClearTables(); // 0x00000001819EA6A0-0x00000001819EA8B0
		internal bool PreprocessSchema(ref XmlSchema schema, string targetNamespace); // 0x00000001819ED390-0x00000001819ED4F0
		internal XmlSchema ParseSchema(string targetNamespace, XmlReader reader); // 0x00000001819ED260-0x00000001819ED390
		internal void CopyFromCompiledSet(XmlSchemaSet otherSet); // 0x00000001819EAE80-0x00000001819EC310
		internal XmlResolver GetResolver(); // 0x00000001819EC780-0x00000001819EC7A0
		internal ValidationEventHandler GetEventHandler(); // 0x000000018031E110-0x000000018031E120
		internal SchemaNames GetSchemaNames(XmlNameTable nt); // 0x00000001819EC920-0x00000001819EC9E0
		internal bool IsSchemaLoaded(Uri schemaUri, string targetNamespace, out XmlSchema schema); // 0x00000001819ECA70-0x00000001819ED260
		internal bool GetSchemaByUri(Uri schemaUri, out XmlSchema schema); // 0x00000001819EC7A0-0x00000001819EC920
		internal string GetTargetNamespace(XmlSchema schema); // 0x00000001819EC9E0-0x00000001819ECA20
		private void RemoveSchemaFromCaches(XmlSchema schema); // 0x00000001819EE100-0x00000001819EE580
		private void RemoveSchemaFromGlobalTables(XmlSchema schema); // 0x00000001819EE580-0x00000001819EEFF0
		private bool AddToTable(XmlSchemaObjectTable table, XmlQualifiedName qname, XmlSchemaObject item); // 0x00000001819E9450-0x00000001819E9800
		private void VerifyTables(); // 0x00000001819F0160-0x00000001819F0280
		private void InternalValidationCallback(object sender, ValidationEventArgs e); // 0x00000001819ECA20-0x00000001819ECA70
		private void SendValidationEvent(XmlSchemaException e, XmlSeverityType severity); // 0x00000001819F00A0-0x00000001819F0160
	}
}
