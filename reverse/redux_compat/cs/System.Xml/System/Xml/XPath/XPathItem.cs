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
using System.Xml.Schema;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.XPath
{
	public abstract class XPathItem // TypeDefIndex: 6905
	{
		// Properties
		public abstract XmlSchemaType XmlType { get; }
		public abstract string Value { get; }
		public abstract object TypedValue { get; }
		public abstract Type ValueType { get; }
		public abstract bool ValueAsBoolean { get; }
		public abstract DateTime ValueAsDateTime { get; }
		public abstract double ValueAsDouble { get; }
		public abstract int ValueAsInt { get; }
		public abstract long ValueAsLong { get; }
	
		// Constructors
		protected XPathItem(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual object ValueAs(Type returnType); // 0x0000000181A970E0-0x0000000181A97100
		public abstract object ValueAs(Type returnType, IXmlNamespaceResolver nsResolver);
	}
}
