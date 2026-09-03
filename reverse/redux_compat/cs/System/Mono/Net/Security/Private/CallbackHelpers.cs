/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Net.Security;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Mono.Security.Interface;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Net.Security.Private
{
	internal static class CallbackHelpers // TypeDefIndex: 8575
	{
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass0_0 // TypeDefIndex: 8576
		{
			// Fields
			public RemoteCertificateValidationCallback callback; // 0x10
	
			// Constructors
			public __c__DisplayClass0_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _PublicToMono_b__0(string h, X509Certificate c, X509Chain ch, MonoSslPolicyErrors e); // 0x0000000181823660-0x0000000181823690
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass6_0 // TypeDefIndex: 8577
		{
			// Fields
			public MonoLocalCertificateSelectionCallback callback; // 0x10
	
			// Constructors
			public __c__DisplayClass6_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal X509Certificate _MonoToInternal_b__0(string t, X509CertificateCollection lc, X509Certificate rc, string[] ai); // 0x0000000181823660-0x0000000181823690
		}
	
		// Methods
		internal static MonoRemoteCertificateValidationCallback PublicToMono(RemoteCertificateValidationCallback callback); // 0x0000000181810330-0x00000001818103F0
		internal static LocalCertSelectionCallback MonoToInternal(MonoLocalCertificateSelectionCallback callback); // 0x0000000181810270-0x0000000181810330
	}
}
