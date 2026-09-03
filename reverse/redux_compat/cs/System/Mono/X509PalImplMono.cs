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
	internal class X509PalImplMono : X509PalImpl // TypeDefIndex: 8478
	{
		// Constructors
		public X509PalImplMono(); // 0x0000000181827E80-0x0000000181827ED0
	
		// Methods
		public override X509CertificateImpl Import(byte[] data); // 0x0000000181827E70-0x0000000181827E80
		public override X509Certificate2Impl Import(byte[] data, SafePasswordHandle password, X509KeyStorageFlags keyStorageFlags); // 0x0000000181827E60-0x0000000181827E70
		public override X509Certificate2Impl Import(X509Certificate cert); // 0x00000001802E7860-0x00000001802E7870
	}
}
