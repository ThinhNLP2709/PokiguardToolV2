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

namespace System.Security.Cryptography.X509Certificates
{
	public class X509ChainElement // TypeDefIndex: 8786
	{
		// Fields
		private X509Certificate2 certificate; // 0x10
		private X509ChainStatus[] status; // 0x18
		private string info; // 0x20
		private X509ChainStatusFlags compressed_status_flags; // 0x28
	
		// Properties
		public X509Certificate2 Certificate { get; } // 0x0000000180377550-0x0000000180377560 
		public X509ChainStatus[] ChainElementStatus { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		internal X509ChainStatusFlags StatusFlags { get; set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
	
		// Constructors
		internal X509ChainElement(X509Certificate2 certificate); // 0x0000000181B9AD10-0x0000000181B9AD60
	
		// Methods
		private int Count(X509ChainStatusFlags flags); // 0x0000000181B99DC0-0x0000000181B99DF0
		private void Set(X509ChainStatus[] status, ref int position, X509ChainStatusFlags flags, X509ChainStatusFlags mask); // 0x0000000181B99DF0-0x0000000181B99E70
		internal void UncompressFlags(); // 0x0000000181B99E70-0x0000000181B9AD10
	}
}
