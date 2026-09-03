/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Security.Cryptography.X509Certificates
{
	public sealed class X509ChainPolicy // TypeDefIndex: 8791
	{
		// Fields
		private OidCollection apps; // 0x10
		private OidCollection cert; // 0x18
		private X509CertificateCollection store; // 0x20
		private X509Certificate2Collection store2; // 0x28
		private X509RevocationFlag rflag; // 0x30
		private X509RevocationMode mode; // 0x34
		private TimeSpan timeout; // 0x38
		private X509VerificationFlags vflags; // 0x40
		private DateTime vtime; // 0x48
	
		// Properties
		public X509Certificate2Collection ExtraStore { get; internal set; } // 0x0000000181B9ED50-0x0000000181B9F0D0 0x000000018033E840-0x000000018033E850
		public X509RevocationFlag RevocationFlag { get; } // 0x000000018033D100-0x000000018033D110 
		public X509RevocationMode RevocationMode { get; set; } // 0x000000018033D0F0-0x000000018033D100 0x0000000181B9F0D0-0x0000000181B9F140
		public X509VerificationFlags VerificationFlags { get; set; } // 0x000000018033D790-0x000000018033D7A0 0x0000000181B9F140-0x0000000181B9F1B0
		public DateTime VerificationTime { get; } // 0x00000001803272B0-0x00000001803272C0 
	
		// Constructors
		public X509ChainPolicy(); // 0x0000000181B9EC30-0x0000000181B9ED50
	
		// Methods
		public void Reset(); // 0x0000000181B9EB20-0x0000000181B9EC30
	}
}
