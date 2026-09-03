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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono
{
	internal abstract class X509PalImpl // TypeDefIndex: 8479
	{
		// Fields
		private static byte[] signedData; // 0x00
	
		// Properties
		public bool SupportsLegacyBasicConstraintsExtension { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Constructors
		protected X509PalImpl(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static X509PalImpl(); // 0x00000001818286B0-0x0000000181828740
	
		// Methods
		public abstract X509CertificateImpl Import(byte[] data);
		public abstract X509Certificate2Impl Import(byte[] data, SafePasswordHandle password, X509KeyStorageFlags keyStorageFlags);
		public abstract X509Certificate2Impl Import(X509Certificate cert);
		private static byte[] PEM(string type, byte[] data); // 0x0000000181828590-0x00000001818286B0
		protected static byte[] ConvertData(byte[] data); // 0x0000000181827ED0-0x0000000181828090
		internal X509Certificate2Impl ImportFallback(byte[] data); // 0x00000001818283B0-0x0000000181828510
		internal X509Certificate2Impl ImportFallback(byte[] data, SafePasswordHandle password, X509KeyStorageFlags keyStorageFlags); // 0x0000000181828510-0x0000000181828590
		public X509ContentType GetCertContentType(byte[] rawData); // 0x0000000181828090-0x00000001818283B0
	}
}
