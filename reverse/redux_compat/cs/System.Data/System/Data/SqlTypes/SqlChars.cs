/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
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
	public sealed class SqlChars : INullable, IXmlSerializable, ISerializable // TypeDefIndex: 11352
	{
		// Fields
		internal char[] _rgchBuf; // 0x10
		private long _lCurLen; // 0x18
		internal SqlStreamChars _stream; // 0x20
		private SqlBytesCharsState _state; // 0x28
		private char[] _rgchWorkBuf; // 0x30
	
		// Properties
		public bool IsNull { get; } // 0x0000000180CC72F0-0x0000000180CC7300 
		public char[] Buffer { get; } // 0x00000001818DC810-0x00000001818DC9A0 
		public long Length { get; } // 0x00000001818DC9A0-0x00000001818DCA30 
		public char[] Value { get; } // 0x00000001818DCA80-0x00000001818DCCD0 
		public static SqlChars Null { get; } // 0x00000001818DCA30-0x00000001818DCA80 
	
		// Constructors
		public SqlChars(); // 0x00000001818DBBF0-0x00000001818DBC30
		public SqlChars(char[] buffer); // 0x00000001818DBCB0-0x00000001818DBD40
		public SqlChars(SqlString value); // 0x00000001818DC720-0x00000001818DC810
	
		// Methods
		public void SetNull(); // 0x00000001818DB7F0-0x00000001818DB830
		internal bool FStream(); // 0x00000001818DB710-0x00000001818DB720
		private void CopyStreamToBuffer(); // 0x00000001818DC200-0x00000001818DC390
		private void SetBuffer(char[] buffer); // 0x00000001818DB790-0x00000001818DB7F0
		XmlSchema IXmlSerializable.GetSchema(); // 0x00000001802E7860-0x00000001802E7870
		void IXmlSerializable.ReadXml(XmlReader r); // 0x00000001818DC440-0x00000001818DC5B0
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x00000001818DC5B0-0x00000001818DC720
		public static XmlQualifiedName GetXsdType(XmlSchemaSet schemaSet); // 0x00000001818DC390-0x00000001818DC400
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001818DC400-0x00000001818DC440
	}
}
