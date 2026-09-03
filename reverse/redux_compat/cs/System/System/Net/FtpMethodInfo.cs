/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class FtpMethodInfo // TypeDefIndex: 9020
	{
		// Fields
		internal string Method; // 0x10
		internal FtpOperation Operation; // 0x18
		internal FtpMethodFlags Flags; // 0x1C
		internal string HttpCommand; // 0x20
		private static readonly FtpMethodInfo[] s_knownMethodInfo; // 0x00
	
		// Properties
		internal bool IsCommandOnly { get; } // 0x0000000181BE7D20-0x0000000181BE7D30 
		internal bool IsUpload { get; } // 0x0000000181BE7D30-0x0000000181BE7D40 
		internal bool IsDownload { get; } // 0x00000001819422D0-0x00000001819422E0 
		internal bool ShouldParseForResponseUri { get; } // 0x0000000181BE7D40-0x0000000181BE7D50 
	
		// Constructors
		internal FtpMethodInfo(string method, FtpOperation operation, FtpMethodFlags flags, string httpCommand); // 0x0000000181BE7CB0-0x0000000181BE7D20
		static FtpMethodInfo(); // 0x0000000181BE73F0-0x0000000181BE7CB0
	
		// Methods
		internal bool HasFlag(FtpMethodFlags flags); // 0x0000000181BE73E0-0x0000000181BE73F0
		internal static FtpMethodInfo GetMethodInfo(string method); // 0x0000000181BE7280-0x0000000181BE73E0
	}
}
