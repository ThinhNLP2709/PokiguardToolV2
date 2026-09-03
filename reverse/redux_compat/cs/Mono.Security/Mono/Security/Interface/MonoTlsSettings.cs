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

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.Interface
{
	public sealed class MonoTlsSettings // TypeDefIndex: 13873
	{
		// Fields
		[CompilerGenerated]
		private MonoRemoteCertificateValidationCallback _RemoteCertificateValidationCallback_k__BackingField; // 0x10
		[CompilerGenerated]
		private MonoLocalCertificateSelectionCallback _ClientCertificateSelectionCallback_k__BackingField; // 0x18
		[CompilerGenerated]
		private DateTime? _CertificateValidationTime_k__BackingField; // 0x20
		[CompilerGenerated]
		private X509CertificateCollection _TrustAnchors_k__BackingField; // 0x30
		[CompilerGenerated]
		private object _UserSettings_k__BackingField; // 0x38
		[CompilerGenerated]
		private string[] _CertificateSearchPaths_k__BackingField; // 0x40
		[CompilerGenerated]
		private bool _SendCloseNotify_k__BackingField; // 0x48
		[CompilerGenerated]
		private string[] _ClientCertificateIssuers_k__BackingField; // 0x50
		[CompilerGenerated]
		private bool _DisallowUnauthenticatedCertificateRequest_k__BackingField; // 0x58
		[CompilerGenerated]
		private TlsProtocols? _EnabledProtocols_k__BackingField; // 0x5C
		[CompilerGenerated]
		private CipherSuiteCode[] _EnabledCiphers_k__BackingField; // 0x68
		private bool cloned; // 0x70
		private bool checkCertName; // 0x71
		private bool checkCertRevocationStatus; // 0x72
		private bool? useServicePointManagerCallback; // 0x73
		private bool skipSystemValidators; // 0x75
		private bool callbackNeedsChain; // 0x76
		private ICertificateValidator certificateValidator; // 0x78
		private static MonoTlsSettings defaultSettings; // 0x00
	
		// Properties
		public MonoRemoteCertificateValidationCallback RemoteCertificateValidationCallback { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public MonoLocalCertificateSelectionCallback ClientCertificateSelectionCallback { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public bool? UseServicePointManagerCallback { get; set; } // 0x0000000181424770-0x0000000181424780 0x00000001814247B0-0x00000001814247C0
		public bool CallbackNeedsCertificateChain { get; } // 0x00000001814246B0-0x00000001814246C0 
		public DateTime? CertificateValidationTime { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180D91A40-0x0000000180D91A50 0x0000000181424780-0x0000000181424790
		public X509CertificateCollection TrustAnchors { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public object UserSettings { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		internal string[] CertificateSearchPaths { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		internal bool SendCloseNotify { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001804EFDA0-0x00000001804EFDB0 0x0000000180C47C30-0x0000000180C47C40
		public string[] ClientCertificateIssuers { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		public bool DisallowUnauthenticatedCertificateRequest { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181424750-0x0000000181424760 0x0000000181424790-0x00000001814247A0
		public TlsProtocols? EnabledProtocols { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181424760-0x0000000181424770 0x00000001814247A0-0x00000001814247B0
		[CLSCompliant(false)]
		public CipherSuiteCode[] EnabledCiphers { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
		public static MonoTlsSettings DefaultSettings { get; } // 0x00000001814246C0-0x0000000181424750 
		[Obsolete("Do not use outside System.dll!")]
		public ICertificateValidator CertificateValidator { get; } // 0x000000018033D4E0-0x000000018033D4F0 
	
		// Constructors
		public MonoTlsSettings(); // 0x00000001814246A0-0x00000001814246B0
		private MonoTlsSettings(MonoTlsSettings other); // 0x0000000181424510-0x00000001814246A0
	
		// Methods
		public static MonoTlsSettings CopyDefaultSettings(); // 0x0000000181424430-0x0000000181424510
		[Obsolete("Do not use outside System.dll!")]
		public MonoTlsSettings CloneWithValidator(ICertificateValidator validator); // 0x0000000181424330-0x00000001814243D0
		public MonoTlsSettings Clone(); // 0x00000001814243D0-0x0000000181424430
	}
}
