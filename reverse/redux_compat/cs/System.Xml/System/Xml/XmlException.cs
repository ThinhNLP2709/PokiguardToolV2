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

namespace System.Xml
{
	[Serializable]
	public class XmlException : SystemException // TypeDefIndex: 6889
	{
		// Fields
		private string res; // 0x90
		private string[] args; // 0x98
		private int lineNumber; // 0xA0
		private int linePosition; // 0xA4
		[OptionalField]
		private string sourceUri; // 0xA8
		private string message; // 0xB0
	
		// Properties
		public int LineNumber { get; } // 0x000000018033D1F0-0x000000018033D200 
		public int LinePosition { get; } // 0x000000018033D210-0x000000018033D220 
		public override string Message { get; } // 0x0000000181AA43E0-0x0000000181AA4400 
		internal string ResString { get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
	
		// Constructors
		protected XmlException(SerializationInfo info, StreamingContext context); // 0x0000000181AA3670-0x0000000181AA3AF0
		public XmlException(); // 0x0000000181AA3B20-0x0000000181AA3B50
		public XmlException(string message); // 0x0000000181AA3AF0-0x0000000181AA3B20
		public XmlException(string message, Exception innerException); // 0x0000000181AA3640-0x0000000181AA3670
		public XmlException(string message, Exception innerException, int lineNumber, int linePosition); // 0x0000000181AA3540-0x0000000181AA3570
		internal XmlException(string message, Exception innerException, int lineNumber, int linePosition, string sourceUri); // 0x0000000181AA3DE0-0x0000000181AA3FF0
		internal XmlException(string res, string[] args); // 0x0000000181AA3FF0-0x0000000181AA4020
		internal XmlException(string res, string arg); // 0x0000000181AA4270-0x0000000181AA4320
		internal XmlException(string res, string arg, string sourceUri); // 0x0000000181AA41B0-0x0000000181AA4270
		internal XmlException(string res, string arg, IXmlLineInfo lineInfo); // 0x0000000181AA3C80-0x0000000181AA3DA0
		internal XmlException(string res, string[] args, IXmlLineInfo lineInfo); // 0x0000000181AA40F0-0x0000000181AA41B0
		internal XmlException(string res, string[] args, IXmlLineInfo lineInfo, string sourceUri); // 0x0000000181AA4320-0x0000000181AA43E0
		internal XmlException(string res, string arg, int lineNumber, int linePosition); // 0x0000000181AA3570-0x0000000181AA3640
		internal XmlException(string res, string arg, int lineNumber, int linePosition, string sourceUri); // 0x0000000181AA3B80-0x0000000181AA3C50
		internal XmlException(string res, string[] args, int lineNumber, int linePosition); // 0x0000000181AA3C50-0x0000000181AA3C80
		internal XmlException(string res, string[] args, int lineNumber, int linePosition, string sourceUri); // 0x0000000181AA3DA0-0x0000000181AA3DE0
		internal XmlException(string res, string[] args, Exception innerException, int lineNumber, int linePosition); // 0x0000000181AA3B50-0x0000000181AA3B80
		internal XmlException(string res, string[] args, Exception innerException, int lineNumber, int linePosition, string sourceUri); // 0x0000000181AA4020-0x0000000181AA40F0
	
		// Methods
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181AA33F0-0x0000000181AA3540
		private static string FormatUserMessage(string message, int lineNumber, int linePosition); // 0x0000000181AA32E0-0x0000000181AA33F0
		private static string CreateMessage(string res, string[] args, int lineNumber, int linePosition); // 0x0000000181AA3130-0x0000000181AA32E0
		internal static string[] BuildCharExceptionArgs(string data, int invCharIndex); // 0x0000000181AA2DD0-0x0000000181AA2E40
		internal static string[] BuildCharExceptionArgs(char[] data, int length, int invCharIndex); // 0x0000000181AA30D0-0x0000000181AA3130
		internal static string[] BuildCharExceptionArgs(char invChar, char nextChar); // 0x0000000181AA2E40-0x0000000181AA30D0
	}
}
