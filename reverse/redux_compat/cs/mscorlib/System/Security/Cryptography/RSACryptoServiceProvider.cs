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
	public sealed class RSACryptoServiceProvider : RSA // TypeDefIndex: 2818
	{
		// Fields
		private static CspProviderFlags s_UseMachineKeyStore; // 0x00
		private KeyPairPersistence store; // 0x20
		private bool persistKey; // 0x28
		private bool persisted; // 0x29
		private bool privateKeyExportable; // 0x2A
		private bool m_disposed; // 0x2B
		private RSAManaged rsa; // 0x30
	
		// Properties
		public static bool UseMachineKeyStore { get; } // 0x0000000181495C40-0x0000000181495C90 
		public override int KeySize { get; } // 0x0000000181495BF0-0x0000000181495C20 
		[ComVisible(false)]
		public bool PublicOnly { get; } // 0x0000000181495C20-0x0000000181495C40 
	
		// Constructors
		public RSACryptoServiceProvider(); // 0x0000000181495BC0-0x0000000181495BF0
		public RSACryptoServiceProvider(CspParameters parameters); // 0x0000000181495A70-0x0000000181495BC0
		public RSACryptoServiceProvider(int dwKeySize); // 0x00000001814958E0-0x0000000181495920
		public RSACryptoServiceProvider(int dwKeySize, CspParameters parameters); // 0x0000000181495920-0x0000000181495A70
	
		// Methods
		private void Common(int dwKeySize, bool parameters); // 0x00000001814949D0-0x0000000181494C60
		private void Common(CspParameters p); // 0x0000000181494C60-0x0000000181494D90
		~RSACryptoServiceProvider(); // 0x0000000181428550-0x00000001814285D0
		public override byte[] EncryptValue(byte[] rgb); // 0x0000000181494DE0-0x0000000181494E10
		public override RSAParameters ExportParameters(bool includePrivateParameters); // 0x0000000181494E10-0x0000000181494FB0
		public override void ImportParameters(RSAParameters parameters); // 0x00000001814954C0-0x0000000181495520
		private string GetHashNameFromOID(string oid); // 0x0000000181494FB0-0x0000000181495160
		public bool VerifyHash(byte[] rgbHash, string str, byte[] rgbSignature); // 0x00000001814955B0-0x00000001814958E0
		protected override void Dispose(bool disposing); // 0x0000000181494D90-0x0000000181494DE0
		private void OnKeyGenerated(object sender, EventArgs e); // 0x0000000181495520-0x00000001814955B0
		[ComVisible(false)]
		public void ImportCspBlob(byte[] keyBlob); // 0x0000000181495160-0x00000001814954C0
	}
}
