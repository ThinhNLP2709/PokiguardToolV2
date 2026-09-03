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
using Microsoft.Win32.SafeHandles;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Cryptography.X509Certificates
{
	internal abstract class X509CertificateImpl : IDisposable // TypeDefIndex: 2853
	{
		// Properties
		public abstract bool IsValid { get; }
		public abstract string Issuer { get; }
		public abstract string Subject { get; }
		public abstract byte[] RawData { get; }
		public abstract DateTime NotAfter { get; }
		public abstract DateTime NotBefore { get; }
		public abstract byte[] Thumbprint { get; }
		public abstract string KeyAlgorithm { get; }
		public abstract byte[] KeyAlgorithmParameters { get; }
		public abstract byte[] PublicKeyValue { get; }
		public abstract byte[] SerialNumber { get; }
		public abstract bool HasPrivateKey { get; }
	
		// Constructors
		protected X509CertificateImpl(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		protected void ThrowIfContextInvalid(); // 0x00000001814CBDD0-0x00000001814CBE20
		public abstract X509CertificateImpl Clone();
		public sealed override int GetHashCode(); // 0x00000001814CBD40-0x00000001814CBDD0
		public abstract RSA GetRSAPrivateKey();
		public abstract DSA GetDSAPrivateKey();
		public abstract byte[] Export(X509ContentType contentType, SafePasswordHandle password);
		public sealed override bool Equals(object obj); // 0x00000001814CBB20-0x00000001814CBCC0
		public void Dispose(); // 0x00000001814CBAB0-0x00000001814CBB20
		protected virtual void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
		~X509CertificateImpl(); // 0x00000001814CBCC0-0x00000001814CBD40
	}
}
