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
	public abstract class HMAC : KeyedHashAlgorithm // TypeDefIndex: 2795
	{
		// Fields
		private int blockSizeValue; // 0x30
		internal string m_hashName; // 0x38
		internal HashAlgorithm m_hash1; // 0x40
		internal HashAlgorithm m_hash2; // 0x48
		private byte[] m_inner; // 0x50
		private byte[] m_outer; // 0x58
		private bool m_hashing; // 0x60
	
		// Properties
		protected int BlockSizeValue { get; set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
		public override byte[] Key { get; set; } // 0x00000001814906D0-0x0000000181490750 0x0000000181490750-0x00000001814907D0
	
		// Constructors
		protected HMAC(); // 0x00000001814906C0-0x00000001814906D0
	
		// Methods
		private void UpdateIOPadBuffers(); // 0x0000000181490570-0x00000001814906C0
		internal void InitializeKey(byte[] key); // 0x0000000181490380-0x0000000181490510
		public static HMAC Create(); // 0x000000018148FE50-0x000000018148FF70
		public override void Initialize(); // 0x0000000181490510-0x0000000181490570
		protected override void HashCore(byte[] rgb, int ib, int cb); // 0x0000000181490050-0x0000000181490160
		protected override byte[] HashFinal(); // 0x0000000181490160-0x0000000181490380
		protected override void Dispose(bool disposing); // 0x000000018148FF70-0x0000000181490050
	}
}
