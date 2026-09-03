/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Serialization;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	public abstract class XmlSchemaObject // TypeDefIndex: 7231
	{
		// Fields
		private int lineNum; // 0x10
		private int linePos; // 0x14
		private string sourceUri; // 0x18
		private XmlSerializerNamespaces namespaces; // 0x20
		private XmlSchemaObject parent; // 0x28
		private bool isProcessing; // 0x30
	
		// Properties
		[XmlIgnore]
		public int LineNumber { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		[XmlIgnore]
		public int LinePosition { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		[XmlIgnore]
		public string SourceUri { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		[XmlIgnore]
		public XmlSchemaObject Parent { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		[XmlNamespaceDeclarations]
		public XmlSerializerNamespaces Namespaces { get; set; } // 0x00000001819DF400-0x00000001819DF470 0x000000018033E830-0x000000018033E840
		[XmlIgnore]
		internal virtual string IdAttribute { get; set; } // 0x00000001802E7860-0x00000001802E7870 0x00000001802E76C0-0x00000001802E76D0
		[XmlIgnore]
		internal virtual string NameAttribute { get; set; } // 0x00000001802E7860-0x00000001802E7870 0x00000001802E76C0-0x00000001802E76D0
		[XmlIgnore]
		internal bool IsProcessing { get; set; } // 0x00000001802E8950-0x00000001802E8960 0x00000001802E8960-0x00000001802E8970
	
		// Constructors
		protected XmlSchemaObject(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal virtual void OnAdd(XmlSchemaObjectCollection container, object item); // 0x00000001802E76C0-0x00000001802E76D0
		internal virtual void OnRemove(XmlSchemaObjectCollection container, object item); // 0x00000001802E76C0-0x00000001802E76D0
		internal virtual void OnClear(XmlSchemaObjectCollection container); // 0x00000001802E76C0-0x00000001802E76D0
		internal virtual void SetUnhandledAttributes(XmlAttribute[] moreAttributes); // 0x00000001802E76C0-0x00000001802E76D0
		internal virtual void AddAnnotation(XmlSchemaAnnotation annotation); // 0x00000001802E76C0-0x00000001802E76D0
		internal virtual XmlSchemaObject Clone(); // 0x00000001819DF380-0x00000001819DF400
	}
}
