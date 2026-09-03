/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mono.Security.Cryptography;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Cryptography
{
	[ComVisible(true)]
	public sealed class DSACryptoServiceProvider : DSA // TypeDefIndex: 2840
	{
		// Fields
		private KeyPairPersistence store; // 0x20
		private bool persistKey; // 0x28
		private bool persisted; // 0x29
		private bool privateKeyExportable; // 0x2A
		private bool m_disposed; // 0x2B
		private DSAManaged dsa; // 0x30
		private static bool useMachineKeyStore; // 0x00
	
		// Properties
		public override int KeySize { get; } // 0x00000001814A0C00-0x00000001814A0C30 
		[ComVisible(false)]
		public bool PublicOnly { get; } // 0x00000001814A0C30-0x00000001814A0C50 
	
		// Constructors
		public DSACryptoServiceProvider(); // 0x00000001814A0BD0-0x00000001814A0C00
		public DSACryptoServiceProvider(int dwKeySize); // 0x00000001814A0B90-0x00000001814A0BD0
	
		// Methods
		private void Common(int dwKeySize, bool parameters); // 0x00000001814A07C0-0x00000001814A0A00
		~DSACryptoServiceProvider(); // 0x0000000181428550-0x00000001814285D0
		public override DSAParameters ExportParameters(bool includePrivateParameters); // 0x00000001814A0A00-0x00000001814A0AD0
		public override void ImportParameters(DSAParameters parameters); // 0x00000001814954C0-0x0000000181495520
		public override bool VerifySignature(byte[] rgbHash, byte[] rgbSignature); // 0x00000001814A0B60-0x00000001814A0B90
		protected override void Dispose(bool disposing); // 0x0000000181494D90-0x0000000181494DE0
		private void OnKeyGenerated(object sender, EventArgs e); // 0x00000001814A0AD0-0x00000001814A0B60
	}
}
