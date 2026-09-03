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

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	[Serializable]
	public class XmlSchemaException : SystemException // TypeDefIndex: 7201
	{
		// Fields
		private string res; // 0x90
		private string[] args; // 0x98
		private string sourceUri; // 0xA0
		private int lineNumber; // 0xA8
		private int linePosition; // 0xAC
		[NonSerialized]
		private XmlSchemaObject sourceSchemaObject; // 0xB0
		private string message; // 0xB8
	
		// Properties
		internal string GetRes { get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
		internal string[] Args { get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
		public string SourceUri { get; } // 0x00000001805B5990-0x00000001805B59A0 
		public int LineNumber { get; } // 0x00000001806671D0-0x00000001806671E0 
		public int LinePosition { get; } // 0x000000018158AF80-0x000000018158AF90 
		public XmlSchemaObject SourceSchemaObject { get; } // 0x00000001806BAE60-0x00000001806BAE70 
		public override string Message { get; } // 0x00000001819DE2F0-0x00000001819DE310 
	
		// Constructors
		protected XmlSchemaException(SerializationInfo info, StreamingContext context); // 0x00000001819DD990-0x00000001819DDDC0
		public XmlSchemaException(); // 0x00000001819DDE90-0x00000001819DDEC0
		public XmlSchemaException(string message); // 0x00000001819DE070-0x00000001819DE090
		public XmlSchemaException(string message, Exception innerException); // 0x00000001819DDEC0-0x00000001819DDEE0
		public XmlSchemaException(string message, Exception innerException, int lineNumber, int linePosition); // 0x00000001819DE0E0-0x00000001819DE1E0
		internal XmlSchemaException(string res, string[] args); // 0x00000001819DE1E0-0x00000001819DE210
		internal XmlSchemaException(string res, string arg); // 0x00000001819DDEE0-0x00000001819DDFA0
		internal XmlSchemaException(string res, string arg, string sourceUri, int lineNumber, int linePosition); // 0x00000001819DDDC0-0x00000001819DDE90
		internal XmlSchemaException(string res, string sourceUri, int lineNumber, int linePosition); // 0x00000001819DD900-0x00000001819DD940
		internal XmlSchemaException(string res, string[] args, string sourceUri, int lineNumber, int linePosition); // 0x00000001819DD8C0-0x00000001819DD900
		internal XmlSchemaException(string res, XmlSchemaObject source); // 0x00000001819DD940-0x00000001819DD990
		internal XmlSchemaException(string res, string arg, XmlSchemaObject source); // 0x00000001819DE210-0x00000001819DE2F0
		internal XmlSchemaException(string res, string[] args, XmlSchemaObject source); // 0x00000001819DE090-0x00000001819DE0E0
		internal XmlSchemaException(string res, string[] args, Exception innerException, string sourceUri, int lineNumber, int linePosition, XmlSchemaObject source); // 0x00000001819DDFA0-0x00000001819DE070
	
		// Methods
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001819DD6B0-0x00000001819DD800
		internal static string CreateMessage(string res, string[] args); // 0x00000001819DD660-0x00000001819DD6B0
		internal void SetSource(string sourceUri, int lineNumber, int linePosition); // 0x00000001819DD800-0x00000001819DD850
		internal void SetSchemaObject(XmlSchemaObject source); // 0x00000001806C0C00-0x00000001806C0C20
		internal void SetSource(XmlSchemaObject source); // 0x00000001819DD850-0x00000001819DD8C0
	}
}
