/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public sealed class SHA1CryptoServiceProvider : SHA1 // TypeDefIndex: 2847
	{
		// Fields
		private SHA1Internal sha; // 0x28
	
		// Constructors
		public SHA1CryptoServiceProvider(); // 0x00000001814C65B0-0x00000001814C6620
	
		// Methods
		~SHA1CryptoServiceProvider(); // 0x00000001814A0E60-0x00000001814A0EE0
		protected override void Dispose(bool disposing); // 0x00000001814C6520-0x00000001814C6530
		protected override void HashCore(byte[] rgb, int ibStart, int cbSize); // 0x00000001814C6530-0x00000001814C6560
		protected override byte[] HashFinal(); // 0x00000001814C6560-0x00000001814C6590
		public override void Initialize(); // 0x00000001814C6590-0x00000001814C65B0
	}
}
