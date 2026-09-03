/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data.SqlTypes
{
	[Serializable]
	[XmlSchemaProvider("GetXsdType")]
	public sealed class SqlXml : INullable, IXmlSerializable // TypeDefIndex: 11369
	{
		// Fields
		private static readonly Func<Stream, XmlReaderSettings, XmlParserContext, XmlReader> s_sqlReaderDelegate; // 0x00
		private static readonly XmlReaderSettings s_defaultXmlReaderSettings; // 0x08
		private static readonly XmlReaderSettings s_defaultXmlReaderSettingsCloseInput; // 0x10
		private static MethodInfo s_createSqlReaderMethodInfo; // 0x18
		private MethodInfo _createSqlReaderMethodInfo; // 0x10
		private bool _fNotNull; // 0x18
		private Stream _stream; // 0x20
		private bool _firstCreateReader; // 0x28
	
		// Properties
		private static MethodInfo CreateSqlReaderMethodInfo { get; } // 0x00000001818F78D0-0x00000001818F7A90 
		public bool IsNull { get; } // 0x00000001818F51A0-0x00000001818F51B0 
	
		// Constructors
		public SqlXml(); // 0x00000001818F7890-0x00000001818F78D0
		static SqlXml(); // 0x00000001818F7690-0x00000001818F7890
	
		// Methods
		public XmlReader CreateReader(); // 0x00000001818F6EB0-0x00000001818F7060
		internal static XmlReader CreateSqlXmlReader(Stream stream, bool closeInput = false /* Metadata: 0x006A176D */, bool throwTargetInvocationExceptions = false /* Metadata: 0x006A176E */); // 0x00000001818F7140-0x00000001818F72A0
		private static Func<Stream, XmlReaderSettings, XmlParserContext, XmlReader> CreateSqlReaderDelegate(); // 0x00000001818F7060-0x00000001818F7140
		private void SetNull(); // 0x00000001818F7310-0x00000001818F7340
		XmlSchema IXmlSerializable.GetSchema(); // 0x00000001802E7860-0x00000001802E7870
		void IXmlSerializable.ReadXml(XmlReader r); // 0x00000001818F7340-0x00000001818F7540
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x00000001818F7540-0x00000001818F7690
		public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet); // 0x00000001818F72A0-0x00000001818F7310
	}
}
