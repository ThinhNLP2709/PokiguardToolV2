/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Internal.Cryptography.Pal
{
	internal struct CertificateData // TypeDefIndex: 8649
	{
		// Fields
		internal byte[] RawData; // 0x00
		internal byte[] SubjectPublicKeyInfo; // 0x08
		internal int Version; // 0x10
		internal byte[] SerialNumber; // 0x18
		internal AlgorithmIdentifier TbsSignature; // 0x20
		internal X500DistinguishedName Issuer; // 0x30
		internal DateTime NotBefore; // 0x38
		internal DateTime NotAfter; // 0x40
		internal X500DistinguishedName Subject; // 0x48
		internal AlgorithmIdentifier PublicKeyAlgorithm; // 0x50
		internal byte[] PublicKey; // 0x60
		internal byte[] IssuerUniqueId; // 0x68
		internal byte[] SubjectUniqueId; // 0x70
		internal List<X509Extension> Extensions; // 0x78
		internal AlgorithmIdentifier SignatureAlgorithm; // 0x80
		internal byte[] SignatureValue; // 0x90
	
		// Nested types
		internal struct AlgorithmIdentifier // TypeDefIndex: 8650
		{
			// Fields
			internal string AlgorithmId; // 0x00
			internal byte[] Parameters; // 0x08
		}
	
		[CompilerGenerated]
		private sealed class _ReadReverseRdns_d__21 : IEnumerable<KeyValuePair<string, string>>, IEnumerator<KeyValuePair<string, string>> // TypeDefIndex: 8651
		{
			// Fields
			private int __1__state; // 0x10
			private KeyValuePair<string, string> __2__current; // 0x18
			private int __l__initialThreadId; // 0x28
			private X500DistinguishedName name; // 0x30
			public X500DistinguishedName __3__name; // 0x38
			private Stack<DerSequenceReader> _rdnReaders_5__2; // 0x40
			private DerSequenceReader _rdnReader_5__3; // 0x48
	
			// Properties
			KeyValuePair<string, string> IEnumerator<System.Collections.Generic.KeyValuePair<System.String,System.String>>.Current { [DebuggerHidden] get; } // 0x0000000180A5E120-0x0000000180A5E130 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x0000000181B55C60-0x0000000181B55CB0 
	
			// Constructors
			[DebuggerHidden]
			public _ReadReverseRdns_d__21(int __1__state); // 0x0000000180A5E8A0-0x0000000180A5E8D0
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x0000000181B558F0-0x0000000181B55B80
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181B55C20-0x0000000181B55C60
			[DebuggerHidden]
			IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator(); // 0x0000000181B55B80-0x0000000181B55C20
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181B55B80-0x0000000181B55C20
		}
	
		// Constructors
		internal CertificateData(byte[] rawData); // 0x0000000181B42570-0x0000000181B42E90
	
		// Methods
		public string GetNameInfo(X509NameType nameType, bool forIssuer); // 0x0000000181B41CB0-0x0000000181B42170
		private static string GetSimpleNameInfo(X500DistinguishedName name); // 0x0000000181B42170-0x0000000181B424F0
		private static string FindAltNameMatch(byte[] extensionBytes, GeneralNameType matchType, string otherOid); // 0x0000000181B41B00-0x0000000181B41CB0
		[IteratorStateMachine(typeof(_ReadReverseRdns_d__21))]
		private static IEnumerable<KeyValuePair<string, string>> ReadReverseRdns(X500DistinguishedName name); // 0x0000000181B424F0-0x0000000181B42570
	}
}
