/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using Mono;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Cryptography.X509Certificates
{
	internal static class X509Helper // TypeDefIndex: 2854
	{
		// Properties
		private static ISystemCertificateProvider CertificateProvider { get; } // 0x00000001814CE360-0x00000001814CE4E0 
	
		// Methods
		public static X509CertificateImpl InitFromCertificate(X509Certificate cert); // 0x00000001814CE200-0x00000001814CE2D0
		public static X509CertificateImpl InitFromCertificate(X509CertificateImpl impl); // 0x00000001814CE2D0-0x00000001814CE2F0
		public static bool IsValid(X509CertificateImpl impl); // 0x00000001814CE2F0-0x00000001814CE310
		internal static void ThrowIfContextInvalid(X509CertificateImpl impl); // 0x00000001814CE310-0x00000001814CE360
		internal static Exception GetInvalidContextException(); // 0x00000001814CDFC0-0x00000001814CE030
		public static X509CertificateImpl Import(byte[] rawData); // 0x00000001814CE140-0x00000001814CE200
		public static X509CertificateImpl Import(byte[] rawData, SafePasswordHandle password, X509KeyStorageFlags keyStorageFlags); // 0x00000001814CE030-0x00000001814CE140
	}
}
