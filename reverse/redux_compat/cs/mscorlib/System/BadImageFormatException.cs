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
	public class BadImageFormatException : SystemException // TypeDefIndex: 2219
	{
		// Fields
		private string _fileName; // 0x90
		private string _fusionLog; // 0x98
	
		// Properties
		public override string Message { get; } // 0x000000018155D740-0x000000018155D7D0 
	
		// Constructors
		public BadImageFormatException(); // 0x000000018155D6F0-0x000000018155D740
		public BadImageFormatException(string message); // 0x000000018155D690-0x000000018155D6B0
		public BadImageFormatException(string message, Exception inner); // 0x000000018155D670-0x000000018155D690
		public BadImageFormatException(string message, string fileName); // 0x000000018155D6B0-0x000000018155D6F0
		protected BadImageFormatException(SerializationInfo info, StreamingContext context); // 0x000000018155D5A0-0x000000018155D670
	
		// Methods
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x000000018155D220-0x000000018155D320
		private void SetMessageField(); // 0x000000018155D320-0x000000018155D3B0
		public override string ToString(); // 0x000000018155D3B0-0x000000018155D5A0
	}
}
