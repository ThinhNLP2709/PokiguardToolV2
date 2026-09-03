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
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data.SqlTypes
{
	[Serializable]
	[DefaultMember("Item")]
	[XmlSchemaProvider("GetXsdType")]
	public sealed class SqlBytes : INullable, IXmlSerializable, ISerializable // TypeDefIndex: 11351
	{
		// Fields
		internal byte[] _rgbBuf; // 0x10
		private long _lCurLen; // 0x18
		internal Stream _stream; // 0x20
		private SqlBytesCharsState _state; // 0x28
		private byte[] _rgbWorkBuf; // 0x30
	
		// Properties
		public bool IsNull { get; } // 0x0000000180CC72F0-0x0000000180CC7300 
		public byte[] Buffer { get; } // 0x00000001818DBD40-0x00000001818DBED0 
		public long Length { get; } // 0x00000001818DBED0-0x00000001818DBF60 
		public byte[] Value { get; } // 0x00000001818DBFB0-0x00000001818DC200 
		public static SqlBytes Null { get; } // 0x00000001818DBF60-0x00000001818DBFB0 
	
		// Constructors
		public SqlBytes(); // 0x00000001818DBBF0-0x00000001818DBC30
		public SqlBytes(byte[] buffer); // 0x00000001818DBCB0-0x00000001818DBD40
		public SqlBytes(SqlBinary value); // 0x00000001818DBC30-0x00000001818DBCB0
	
		// Methods
		public void SetNull(); // 0x00000001818DB7F0-0x00000001818DB830
		private void CopyStreamToBuffer(); // 0x00000001818DB580-0x00000001818DB710
		internal bool FStream(); // 0x00000001818DB710-0x00000001818DB720
		private void SetBuffer(byte[] buffer); // 0x00000001818DB790-0x00000001818DB7F0
		XmlSchema IXmlSerializable.GetSchema(); // 0x00000001802E7860-0x00000001802E7870
		void IXmlSerializable.ReadXml(XmlReader r); // 0x00000001818DB870-0x00000001818DBA60
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x00000001818DBA60-0x00000001818DBBF0
		public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet); // 0x00000001818DB720-0x00000001818DB790
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001818DB830-0x00000001818DB870
	}
}
