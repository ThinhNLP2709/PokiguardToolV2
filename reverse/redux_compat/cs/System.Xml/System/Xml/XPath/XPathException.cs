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

namespace System.Xml.XPath
{
	[Serializable]
	public class XPathException : SystemException // TypeDefIndex: 6903
	{
		// Fields
		private string res; // 0x90
		private string[] args; // 0x98
		private string message; // 0xA0
	
		// Properties
		public override string Message { get; } // 0x0000000181A970C0-0x0000000181A970E0 
	
		// Constructors
		protected XPathException(SerializationInfo info, StreamingContext context); // 0x0000000181A96D80-0x0000000181A97030
		public XPathException(); // 0x0000000181A96CC0-0x0000000181A96D80
		public XPathException(string message, Exception innerException); // 0x0000000181A96C00-0x0000000181A96CC0
		private XPathException(string res, string[] args); // 0x0000000181A96BE0-0x0000000181A96C00
		private XPathException(string res, string[] args, Exception inner); // 0x0000000181A97030-0x0000000181A970C0
	
		// Methods
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181A96B00-0x0000000181A96BE0
		internal static XPathException Create(string res); // 0x0000000181A96900-0x0000000181A96960
		internal static XPathException Create(string res, string arg); // 0x0000000181A96960-0x0000000181A96A20
		internal static XPathException Create(string res, string arg, string arg2); // 0x0000000181A96A20-0x0000000181A96B00
		private static string CreateMessage(string res, string[] args); // 0x0000000181A96850-0x0000000181A96900
	}
}
