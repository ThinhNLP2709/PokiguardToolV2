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
	public class BasicConstraintsExtension : X509Extension // TypeDefIndex: 13851
	{
		// Fields
		private bool cA; // 0x28
		private int pathLenConstraint; // 0x2C
	
		// Properties
		public bool CertificateAuthority { get; } // 0x0000000180327270-0x0000000180327280 
	
		// Constructors
		public BasicConstraintsExtension(X509Extension extension); // 0x0000000181400BF0-0x0000000181400C00
	
		// Methods
		protected override void Decode(); // 0x0000000181400C80-0x0000000181400DC0
		protected override void Encode(); // 0x0000000181400DC0-0x0000000181400FA0
		public override string ToString(); // 0x0000000181400FA0-0x0000000181401100
	}
}
