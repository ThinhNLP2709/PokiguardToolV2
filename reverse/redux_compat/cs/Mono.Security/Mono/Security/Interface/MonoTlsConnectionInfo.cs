/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.Interface
{
	public class MonoTlsConnectionInfo // TypeDefIndex: 13867
	{
		// Fields
		[CompilerGenerated]
		private CipherSuiteCode _CipherSuiteCode_k__BackingField; // 0x10
		[CompilerGenerated]
		private TlsProtocols _ProtocolVersion_k__BackingField; // 0x14
		[CompilerGenerated]
		private string _PeerDomainName_k__BackingField; // 0x18
	
		// Properties
		[CLSCompliant(false)]
		public CipherSuiteCode CipherSuiteCode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181107840-0x0000000181107850 0x00000001814242B0-0x00000001814242C0
		public TlsProtocols ProtocolVersion { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		public string PeerDomainName { [CompilerGenerated] set; } // 0x00000001802FAF70-0x00000001802FAF80
	
		// Constructors
		public MonoTlsConnectionInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public override string ToString(); // 0x0000000181424210-0x00000001814242B0
	}
}
