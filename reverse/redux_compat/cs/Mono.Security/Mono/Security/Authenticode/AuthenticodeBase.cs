/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.Authenticode
{
	public class AuthenticodeBase // TypeDefIndex: 13888
	{
		// Fields
		private byte[] fileblock; // 0x10
		private Stream fs; // 0x18
		private int blockNo; // 0x20
		private int blockLength; // 0x24
		private int peOffset; // 0x28
		private int dirSecurityOffset; // 0x2C
		private int dirSecuritySize; // 0x30
		private int coffSymbolTableOffset; // 0x34
		private bool pe64; // 0x38
	
		// Properties
		internal int PEOffset { get; } // 0x0000000181419BB0-0x0000000181419BE0 
	
		// Constructors
		public AuthenticodeBase(); // 0x0000000181419B50-0x0000000181419BB0
	
		// Methods
		internal void Open(string filename); // 0x0000000181419680-0x0000000181419740
		internal void Open(byte[] rawdata); // 0x0000000181419740-0x00000001814197F0
		internal void Close(); // 0x0000000181419070-0x00000001814190C0
		internal void ReadFirstBlock(); // 0x0000000181419A80-0x0000000181419B50
		internal int ProcessFirstBlock(); // 0x00000001814197F0-0x0000000181419A80
		internal byte[] GetSecurityEntry(); // 0x00000001814195B0-0x0000000181419680
		internal byte[] GetHash(HashAlgorithm hash); // 0x00000001814190C0-0x00000001814195B0
	}
}
