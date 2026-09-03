/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Win32.SafeHandles;
using Mono.Security.Interface;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono
{
	internal class SystemCertificateProvider : ISystemCertificateProvider // TypeDefIndex: 8475
	{
		// Fields
		private static MonoTlsProvider provider; // 0x00
		private static int initialized; // 0x08
		private static X509PalImpl x509pal; // 0x10
		private static object syncRoot; // 0x18
	
		// Properties
		public X509PalImpl X509Pal { get; } // 0x00000001818201D0-0x0000000181820230 
	
		// Constructors
		public SystemCertificateProvider(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static SystemCertificateProvider(); // 0x0000000181820160-0x00000001818201D0
	
		// Methods
		private static X509PalImpl GetX509Pal(); // 0x000000018181FA60-0x000000018181FC50
		private static void EnsureInitialized(); // 0x000000018181F700-0x000000018181FA60
		public X509CertificateImpl Import(byte[] data, CertificateImportFlags importFlags = CertificateImportFlags.None /* Metadata: 0x0069DC34 */); // 0x000000018181FC50-0x000000018181FCF0
		X509CertificateImpl ISystemCertificateProvider.Import(byte[] data, SafePasswordHandle password, X509KeyStorageFlags keyStorageFlags, CertificateImportFlags importFlags); // 0x000000018181FF20-0x000000018181FFE0
		public X509Certificate2Impl Import(byte[] data, SafePasswordHandle password, X509KeyStorageFlags keyStorageFlags, CertificateImportFlags importFlags = CertificateImportFlags.None /* Metadata: 0x0069DC35 */); // 0x000000018181FCF0-0x000000018181FDB0
		X509CertificateImpl ISystemCertificateProvider.Import(X509Certificate cert, CertificateImportFlags importFlags); // 0x000000018181FFE0-0x0000000181820160
		public X509Certificate2Impl Import(X509Certificate cert, CertificateImportFlags importFlags = CertificateImportFlags.None /* Metadata: 0x0069DC36 */); // 0x000000018181FDB0-0x000000018181FF20
	}
}
