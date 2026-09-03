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

namespace System.IO
{
	[Serializable]
	public class FileNotFoundException : IOException // TypeDefIndex: 3645
	{
		// Fields
		[CompilerGenerated]
		private readonly string _FileName_k__BackingField; // 0x90
		[CompilerGenerated]
		private readonly string _FusionLog_k__BackingField; // 0x98
	
		// Properties
		public override string Message { get; } // 0x00000001815A8370-0x00000001815A8450 
		public string FileName { [CompilerGenerated] get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
		public string FusionLog { [CompilerGenerated] get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
	
		// Constructors
		public FileNotFoundException(); // 0x00000001815A81F0-0x00000001815A8240
		public FileNotFoundException(string message); // 0x00000001815A8310-0x00000001815A8330
		public FileNotFoundException(string message, string fileName); // 0x00000001815A8330-0x00000001815A8370
		protected FileNotFoundException(SerializationInfo info, StreamingContext context); // 0x00000001815A8240-0x00000001815A8310
	
		// Methods
		private void SetMessageField(); // 0x00000001815A7F30-0x00000001815A8000
		public override string ToString(); // 0x00000001815A8000-0x00000001815A81F0
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001815A7E30-0x00000001815A7F30
	}
}
