/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mono.Security.X509;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.X509.Extensions
{
	public class AuthorityKeyIdentifierExtension : X509Extension // TypeDefIndex: 13850
	{
		// Fields
		private byte[] aki; // 0x28
	
		// Properties
		public byte[] Identifier { get; } // 0x0000000181400C00-0x0000000181400C80 
	
		// Constructors
		public AuthorityKeyIdentifierExtension(X509Extension extension); // 0x0000000181400BF0-0x0000000181400C00
	
		// Methods
		protected override void Decode(); // 0x00000001814007A0-0x00000001814008F0
		protected override void Encode(); // 0x00000001814008F0-0x0000000181400A60
		public override string ToString(); // 0x0000000181400A60-0x0000000181400BF0
	}
}
