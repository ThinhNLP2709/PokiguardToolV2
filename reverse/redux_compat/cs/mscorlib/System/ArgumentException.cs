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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	public class ArgumentException : SystemException // TypeDefIndex: 2207
	{
		// Fields
		private string _paramName; // 0x90
	
		// Properties
		public override string Message { get; } // 0x000000018155C970-0x000000018155CA10 
	
		// Constructors
		public ArgumentException(); // 0x000000018155C7D0-0x000000018155C820
		public ArgumentException(string message); // 0x000000018155C7B0-0x000000018155C7D0
		public ArgumentException(string message, Exception innerException); // 0x000000018155C950-0x000000018155C970
		public ArgumentException(string message, string paramName, Exception innerException); // 0x000000018155C820-0x000000018155C870
		public ArgumentException(string message, string paramName); // 0x000000018155C870-0x000000018155C8B0
		protected ArgumentException(SerializationInfo info, StreamingContext context); // 0x000000018155C8B0-0x000000018155C950
	
		// Methods
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x000000018155C6F0-0x000000018155C7B0
	}
}
