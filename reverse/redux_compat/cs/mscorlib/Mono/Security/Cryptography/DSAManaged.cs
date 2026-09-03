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
using Mono.Math;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace Mono.Security.Cryptography
{
	internal class DSAManaged : DSA // TypeDefIndex: 2135
	{
		// Fields
		private bool keypairGenerated; // 0x20
		private bool m_disposed; // 0x21
		private BigInteger p; // 0x28
		private BigInteger q; // 0x30
		private BigInteger g; // 0x38
		private BigInteger x; // 0x40
		private BigInteger y; // 0x48
		private BigInteger j; // 0x50
		private BigInteger seed; // 0x58
		private int counter; // 0x60
		private bool j_missing; // 0x64
		private RandomNumberGenerator rng; // 0x68
		[CompilerGenerated]
		private KeyGeneratedEventHandler KeyGenerated; // 0x70
	
		// Properties
		private RandomNumberGenerator Random { get; } // 0x0000000181447050-0x0000000181447090 
		public override int KeySize { get; } // 0x0000000181446FC0-0x0000000181446FF0 
		public bool PublicOnly { get; } // 0x0000000181446FF0-0x0000000181447050 
	
		// Events
		public event KeyGeneratedEventHandler KeyGenerated {
			add; // 0x0000000181446E80-0x0000000181446F20
			remove; // 0x0000000181447090-0x0000000181447130
		}
	
		// Nested types
		public delegate void KeyGeneratedEventHandler(object sender, EventArgs e); // TypeDefIndex: 2136; 0x0000000180A70FB0-0x0000000180A70FC0
	
		// Constructors
		public DSAManaged(int dwKeySize); // 0x0000000181446DB0-0x0000000181446E80
	
		// Methods
		~DSAManaged(); // 0x0000000181428550-0x00000001814285D0
		private void Generate(); // 0x00000001814462F0-0x0000000181446340
		private void GenerateKeyPair(); // 0x00000001814456F0-0x0000000181445920
		private void add(byte[] a, byte[] b, int value); // 0x0000000181446F20-0x0000000181446FC0
		private void GenerateParams(int keyLength); // 0x0000000181445920-0x00000001814462F0
		private byte[] NormalizeArray(byte[] array); // 0x0000000181446790-0x0000000181446840
		public override DSAParameters ExportParameters(bool includePrivateParameters); // 0x0000000181445330-0x00000001814456F0
		public override void ImportParameters(DSAParameters parameters); // 0x0000000181446340-0x0000000181446790
		public override bool VerifySignature(byte[] rgbHash, byte[] rgbSignature); // 0x0000000181446840-0x0000000181446DB0
		protected override void Dispose(bool disposing); // 0x0000000181445110-0x0000000181445330
	}
}
