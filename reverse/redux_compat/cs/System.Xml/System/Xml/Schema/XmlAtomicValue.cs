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
using System.Xml.XPath;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	public sealed class XmlAtomicValue : XPathItem, ICloneable // TypeDefIndex: 7171
	{
		// Fields
		private XmlSchemaType xmlType; // 0x10
		private object objVal; // 0x18
		private TypeCode clrType; // 0x20
		private Union unionVal; // 0x28
		private NamespacePrefixForQName nsPrefix; // 0x30
	
		// Properties
		public override XmlSchemaType XmlType { get; } // 0x0000000180377550-0x0000000180377560 
		public override Type ValueType { get; } // 0x00000001819D7490-0x00000001819D74D0 
		public override object TypedValue { get; } // 0x00000001819D6D30-0x00000001819D6F40 
		public override bool ValueAsBoolean { get; } // 0x00000001819D6F40-0x00000001819D7050 
		public override DateTime ValueAsDateTime { get; } // 0x00000001819D7050-0x00000001819D7160 
		public override double ValueAsDouble { get; } // 0x00000001819D7160-0x00000001819D7270 
		public override int ValueAsInt { get; } // 0x00000001819D7270-0x00000001819D7380 
		public override long ValueAsLong { get; } // 0x00000001819D7380-0x00000001819D7490 
		public override string Value { get; } // 0x00000001819D74D0-0x00000001819D7610 
	
		// Nested types
		private struct Union // TypeDefIndex: 7172
		{
			// Fields
			public bool boolVal; // 0x00
			public double dblVal; // 0x00
			public long i64Val; // 0x00
			public int i32Val; // 0x00
			public DateTime dtVal; // 0x00
		}
	
		private class NamespacePrefixForQName : IXmlNamespaceResolver // TypeDefIndex: 7173
		{
			// Fields
			public string prefix; // 0x10
			public string ns; // 0x18
	
			// Constructors
			public NamespacePrefixForQName(string prefix, string ns); // 0x00000001819C8740-0x00000001819C8790
	
			// Methods
			public string LookupNamespace(string prefix); // 0x00000001819C86D0-0x00000001819C8710
			public string LookupPrefix(string namespaceName); // 0x00000001819C8710-0x00000001819C8740
			public IDictionary<string, string> GetNamespacesInScope(XmlNamespaceScope scope); // 0x00000001819C8630-0x00000001819C86D0
		}
	
		// Constructors
		internal XmlAtomicValue(XmlSchemaType xmlType, bool value); // 0x00000001819D63B0-0x00000001819D6450
		internal XmlAtomicValue(XmlSchemaType xmlType, DateTime value); // 0x00000001819D6BF0-0x00000001819D6C90
		internal XmlAtomicValue(XmlSchemaType xmlType, double value); // 0x00000001819D6C90-0x00000001819D6D30
		internal XmlAtomicValue(XmlSchemaType xmlType, int value); // 0x00000001819D6820-0x00000001819D68C0
		internal XmlAtomicValue(XmlSchemaType xmlType, long value); // 0x00000001819D6780-0x00000001819D6820
		internal XmlAtomicValue(XmlSchemaType xmlType, string value); // 0x00000001819D6B00-0x00000001819D6BF0
		internal XmlAtomicValue(XmlSchemaType xmlType, string value, IXmlNamespaceResolver nsResolver); // 0x00000001819D6540-0x00000001819D6780
		internal XmlAtomicValue(XmlSchemaType xmlType, object value); // 0x00000001819D6450-0x00000001819D6540
		internal XmlAtomicValue(XmlSchemaType xmlType, object value, IXmlNamespaceResolver nsResolver); // 0x00000001819D68C0-0x00000001819D6B00
	
		// Methods
		object ICloneable.Clone(); // 0x0000000180370C60-0x0000000180370C70
		public override object ValueAs(Type type, IXmlNamespaceResolver nsResolver); // 0x00000001819D61D0-0x00000001819D63B0
		public override string ToString(); // 0x00000001819D61B0-0x00000001819D61D0
		private string GetPrefixFromQName(string value); // 0x00000001819D6100-0x00000001819D61B0
	}
}
