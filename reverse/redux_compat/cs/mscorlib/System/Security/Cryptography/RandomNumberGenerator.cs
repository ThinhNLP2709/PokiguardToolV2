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
	public abstract class RandomNumberGenerator : IDisposable // TypeDefIndex: 2807
	{
		// Constructors
		protected RandomNumberGenerator(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static RandomNumberGenerator Create(); // 0x0000000181496670-0x00000001814966C0
		public void Dispose(); // 0x00000001814966C0-0x0000000181496730
		protected virtual void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
		public abstract void GetBytes(byte[] data);
	}
}
