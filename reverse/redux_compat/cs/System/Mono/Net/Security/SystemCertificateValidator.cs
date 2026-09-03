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
using Mono.Security.Interface;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Net.Security
{
	internal static class SystemCertificateValidator // TypeDefIndex: 8574
	{
		// Fields
		private static bool is_macosx; // 0x00
		private static X509KeyUsageFlags s_flags; // 0x04
	
		// Constructors
		static SystemCertificateValidator(); // 0x0000000181820230-0x0000000181820280
	
		// Methods
		internal static bool NeedsChain(MonoTlsSettings settings); // 0x00000001802E7840-0x00000001802E7850
	}
}
