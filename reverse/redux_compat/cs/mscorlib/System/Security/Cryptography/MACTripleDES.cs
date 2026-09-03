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
	public class MACTripleDES : KeyedHashAlgorithm // TypeDefIndex: 2804
	{
		// Fields
		private ICryptoTransform m_encryptor; // 0x30
		private CryptoStream _cs; // 0x38
		private TailStream _ts; // 0x40
		private int m_bytesPerBlock; // 0x48
		private TripleDES des; // 0x50
	
		// Constructors
		public MACTripleDES(); // 0x00000001814918E0-0x0000000181491A60
	
		// Methods
		public override void Initialize(); // 0x00000001814918C0-0x00000001814918E0
		protected override void HashCore(byte[] rgbData, int ibStart, int cbSize); // 0x0000000181491510-0x00000001814916D0
		protected override byte[] HashFinal(); // 0x00000001814916D0-0x00000001814918C0
		protected override void Dispose(bool disposing); // 0x0000000181491440-0x0000000181491510
	}
}
