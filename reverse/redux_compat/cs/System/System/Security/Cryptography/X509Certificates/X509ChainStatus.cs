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
	public struct X509ChainStatus // TypeDefIndex: 8792
	{
		// Fields
		private X509ChainStatusFlags status; // 0x00
		private string info; // 0x08
	
		// Properties
		public X509ChainStatusFlags Status { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public string StatusInformation { set; } // 0x0000000181B9F360-0x0000000181B9F370
	
		// Constructors
		internal X509ChainStatus(X509ChainStatusFlags flag); // 0x0000000181B9F330-0x0000000181B9F360
	
		// Methods
		internal static string GetInformation(X509ChainStatusFlags flags); // 0x0000000181B9F1B0-0x0000000181B9F330
	}
}
