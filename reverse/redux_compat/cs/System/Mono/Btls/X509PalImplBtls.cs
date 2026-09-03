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
using Mono;
using Mono.Security.Interface;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Btls
{
	internal class X509PalImplBtls : X509PalImpl // TypeDefIndex: 8643
	{
		// Fields
		[CompilerGenerated]
		private readonly MonoBtlsProvider _Provider_k__BackingField; // 0x10
	
		// Properties
		private MonoBtlsProvider Provider { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		public X509PalImplBtls(MonoTlsProvider provider); // 0x0000000181B5C220-0x0000000181B5C550
	
		// Methods
		public override X509CertificateImpl Import(byte[] data); // 0x0000000181B5C1F0-0x0000000181B5C220
		public override X509Certificate2Impl Import(byte[] data, SafePasswordHandle password, X509KeyStorageFlags keyStorageFlags); // 0x0000000181B5C1A0-0x0000000181B5C1D0
		public override X509Certificate2Impl Import(X509Certificate cert); // 0x0000000181B5C1D0-0x0000000181B5C1F0
	}
}
