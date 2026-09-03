/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Schema;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.XPath
{
	[DebuggerDisplay("{debuggerDisplayProxy}")]
	public abstract class XPathNavigator : XPathItem, ICloneable, IXmlNamespaceResolver // TypeDefIndex: 6907
	{
		// Fields
		internal static readonly XPathNavigatorKeyComparer comparer; // 0x00
		internal static readonly char[] NodeTypeLetter; // 0x08
		internal static readonly char[] UniqueIdTbl; // 0x10
		internal static readonly int[] ContentKindMasks; // 0x18
	
		// Properties
		public override XmlSchemaType XmlType { get; } // 0x0000000181A98BB0-0x0000000181A98C50 
		public override object TypedValue { get; } // 0x0000000181A97F30-0x0000000181A98120 
		public override Type ValueType { get; } // 0x0000000181A98AD0-0x0000000181A98BB0 
		public override bool ValueAsBoolean { get; } // 0x0000000181A98120-0x0000000181A98310 
		public override DateTime ValueAsDateTime { get; } // 0x0000000181A98310-0x0000000181A98500 
		public override double ValueAsDouble { get; } // 0x0000000181A98500-0x0000000181A986F0 
		public override int ValueAsInt { get; } // 0x0000000181A986F0-0x0000000181A988E0 
		public override long ValueAsLong { get; } // 0x0000000181A988E0-0x0000000181A98AD0 
		public abstract XmlNameTable NameTable { get; }
		public abstract XPathNodeType NodeType { get; }
		public abstract string LocalName { get; }
		public abstract string NamespaceURI { get; }
		public abstract string Prefix { get; }
		public virtual object UnderlyingObject { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual IXmlSchemaInfo SchemaInfo { get; } // 0x0000000181A97EF0-0x0000000181A97F30 
	
		// Constructors
		protected XPathNavigator(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static XPathNavigator(); // 0x0000000181A97D30-0x0000000181A97EF0
	
		// Methods
		public override string ToString(); // 0x00000001819D61B0-0x00000001819D61D0
		public override object ValueAs(Type returnType, IXmlNamespaceResolver nsResolver); // 0x0000000181A97B00-0x0000000181A97D30
		object ICloneable.Clone(); // 0x0000000181A233E0-0x0000000181A23400
		public virtual string LookupNamespace(string prefix); // 0x0000000181A97650-0x0000000181A97810
		public virtual string LookupPrefix(string namespaceURI); // 0x0000000181A97810-0x0000000181A97A50
		public virtual IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope); // 0x0000000181A97430-0x0000000181A97640
		public abstract XPathNavigator Clone();
		public virtual bool MoveToNamespace(string name); // 0x0000000181A97A50-0x0000000181A97B00
		public abstract bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope);
		public abstract bool MoveToNextNamespace(XPathNamespaceScope namespaceScope);
		public abstract bool MoveToParent();
		public abstract bool IsSamePosition(XPathNavigator other);
		internal static bool IsText(XPathNodeType type); // 0x0000000181A97640-0x0000000181A97650
	}
}
