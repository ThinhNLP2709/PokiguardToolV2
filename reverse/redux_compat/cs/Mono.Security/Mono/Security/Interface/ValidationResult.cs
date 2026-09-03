/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.Interface
{
	public class ValidationResult // TypeDefIndex: 13864
	{
		// Fields
		private bool trusted; // 0x10
		private bool user_denied; // 0x11
		private int error_code; // 0x14
		private MonoSslPolicyErrors? policy_errors; // 0x18
	
		// Properties
		public bool Trusted { get; } // 0x00000001805625D0-0x00000001805625E0 
		public bool UserDenied { get; } // 0x0000000180E38E10-0x0000000180E38E20 
	
		// Constructors
		public ValidationResult(bool trusted, bool user_denied, int error_code, MonoSslPolicyErrors? policy_errors); // 0x000000018142BB80-0x000000018142BBD0
	}
}
