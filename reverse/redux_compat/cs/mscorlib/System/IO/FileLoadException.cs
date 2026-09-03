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
	public class FileLoadException : IOException // TypeDefIndex: 3643
	{
		// Fields
		[CompilerGenerated]
		private readonly string _FileName_k__BackingField; // 0x90
		[CompilerGenerated]
		private readonly string _FusionLog_k__BackingField; // 0x98
	
		// Properties
		public override string Message { get; } // 0x00000001815A7DA0-0x00000001815A7E30 
		public string FileName { [CompilerGenerated] get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
		public string FusionLog { [CompilerGenerated] get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
	
		// Constructors
		public FileLoadException(); // 0x00000001815A7D50-0x00000001815A7DA0
		public FileLoadException(string message); // 0x00000001815A7D30-0x00000001815A7D50
		protected FileLoadException(SerializationInfo info, StreamingContext context); // 0x00000001815A7C60-0x00000001815A7D30
	
		// Methods
		public override string ToString(); // 0x00000001815A7A70-0x00000001815A7C60
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001815A7970-0x00000001815A7A70
		internal static string FormatFileLoadExceptionMessage(string fileName, int hResult); // 0x00000001815A7910-0x00000001815A7970
	}
}
