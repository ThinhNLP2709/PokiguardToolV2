/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Unity
{
	internal class X509ChainImplUnityTls : X509ChainImpl // TypeDefIndex: 8542
	{
		// Fields
		private X509ChainElementCollection elements; // 0x10
		private unsafe UnityTls.unitytls_x509list* ownedList; // 0x18
		private UnityTls.unitytls_x509list_ref nativeCertificateChain; // 0x20
		private X509ChainPolicy policy; // 0x28
		private List<X509ChainStatus> chainStatusList; // 0x30
		private bool reverseOrder; // 0x38
	
		// Properties
		public override bool IsValid { get; } // 0x0000000181827E30-0x0000000181827E60 
		internal UnityTls.unitytls_x509list_ref NativeCertificateChain { get; } // 0x00000001802F8630-0x00000001802F8640 
		public override X509ChainElementCollection ChainElements { get; } // 0x0000000181827AC0-0x0000000181827E30 
		public override X509ChainPolicy ChainPolicy { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Constructors
		internal X509ChainImplUnityTls(UnityTls.unitytls_x509list_ref nativeCertificateChain, bool reverseOrder = false /* Metadata: 0x0069DCD9 */); // 0x0000000181827A20-0x0000000181827AC0
		internal unsafe X509ChainImplUnityTls(UnityTls.unitytls_x509list* ownedList, UnityTls.unitytls_errorstate* errorState, bool reverseOrder = false /* Metadata: 0x0069DCDA */); // 0x0000000181827940-0x0000000181827A20
	
		// Methods
		public override void AddStatus(X509ChainStatusFlags error); // 0x0000000181827730-0x0000000181827870
		public override bool Build(X509Certificate2 certificate); // 0x00000001802E7840-0x00000001802E7850
		public override void Reset(); // 0x00000001818278B0-0x0000000181827940
		protected override void Dispose(bool disposing); // 0x0000000181827870-0x00000001818278B0
	}
}
