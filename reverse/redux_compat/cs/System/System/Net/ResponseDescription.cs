/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class ResponseDescription // TypeDefIndex: 9011
	{
		// Fields
		internal bool Multiline; // 0x10
		internal int Status; // 0x14
		internal string StatusDescription; // 0x18
		internal StringBuilder StatusBuffer; // 0x20
		internal string StatusCodeString; // 0x28
	
		// Properties
		internal bool PositiveIntermediate { get; } // 0x0000000181BF3E60-0x0000000181BF3E80 
		internal bool PositiveCompletion { get; } // 0x0000000181BF3E40-0x0000000181BF3E60 
		internal bool TransientFailure { get; } // 0x0000000181BF3E80-0x0000000181BF3EA0 
		internal bool PermanentFailure { get; } // 0x0000000181BF3E20-0x0000000181BF3E40 
		internal bool InvalidStatusCode { get; } // 0x0000000181BF3E00-0x0000000181BF3E20 
	
		// Constructors
		public ResponseDescription(); // 0x0000000181BF3DA0-0x0000000181BF3E00
	}
}
