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
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using Mono.Security.Interface;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Unity
{
	internal static class UnityTlsConversions // TypeDefIndex: 8539
	{
		// Methods
		public static UnityTls.unitytls_protocol GetMinProtocol(SslProtocols protocols); // 0x0000000181826610-0x0000000181826640
		public static UnityTls.unitytls_protocol GetMaxProtocol(SslProtocols protocols); // 0x00000001818265E0-0x0000000181826610
		public static TlsProtocols ConvertProtocolVersion(UnityTls.unitytls_protocol protocol); // 0x00000001818265B0-0x00000001818265E0
		public static AlertDescription VerifyResultToAlertDescription(UnityTls.unitytls_x509verify_result verifyResult, AlertDescription defaultAlert = AlertDescription.InternalError /* Metadata: 0x0069DCD8 */); // 0x0000000181826640-0x00000001818266A0
		public static SslPolicyErrors VerifyResultToPolicyErrror(UnityTls.unitytls_x509verify_result verifyResult); // 0x00000001818266E0-0x0000000181826710
		public static X509ChainStatusFlags VerifyResultToChainStatus(UnityTls.unitytls_x509verify_result verifyResult); // 0x00000001818266A0-0x00000001818266E0
	}
}
