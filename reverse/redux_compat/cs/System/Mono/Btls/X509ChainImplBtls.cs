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

namespace Mono.Btls
{
	internal class X509ChainImplBtls : X509ChainImpl // TypeDefIndex: 8642
	{
		// Fields
		private MonoBtlsX509StoreCtx storeCtx; // 0x10
		private MonoBtlsX509Chain chain; // 0x18
		private MonoBtlsX509Chain untrustedChain; // 0x20
		private X509ChainElementCollection elements; // 0x28
		private X509Certificate2Collection untrusted; // 0x30
		private X509Certificate2[] certificates; // 0x38
		private X509ChainPolicy policy; // 0x40
		private List<X509ChainStatus> chainStatusList; // 0x48
	
		// Properties
		public override bool IsValid { get; } // 0x0000000181B5C160-0x0000000181B5C180 
		internal MonoBtlsX509StoreCtx StoreCtx { get; } // 0x0000000181B5C180-0x0000000181B5C1A0 
		public override X509ChainElementCollection ChainElements { get; } // 0x0000000181B5BE90-0x0000000181B5C160 
		public override X509ChainPolicy ChainPolicy { get; } // 0x0000000180377940-0x0000000180377950 
	
		// Constructors
		internal X509ChainImplBtls(MonoBtlsX509Chain chain); // 0x0000000181B5BCF0-0x0000000181B5BE90
		internal X509ChainImplBtls(MonoBtlsX509StoreCtx storeCtx); // 0x0000000181B5B720-0x0000000181B5BCF0
	
		// Methods
		public override void AddStatus(X509ChainStatusFlags errorCode); // 0x0000000181B5B3D0-0x0000000181B5B510
		public override bool Build(X509Certificate2 certificate); // 0x00000001802E7840-0x00000001802E7850
		public override void Reset(); // 0x0000000181B5B670-0x0000000181B5B720
		protected override void Dispose(bool disposing); // 0x0000000181B5B510-0x0000000181B5B670
	}
}
