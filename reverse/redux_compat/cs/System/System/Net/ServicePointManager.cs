/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net.Security;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	public class ServicePointManager // TypeDefIndex: 9145
	{
		// Fields
		private static ConcurrentDictionary<SPKey, ServicePoint> servicePoints; // 0x00
		private static ICertificatePolicy policy; // 0x08
		private static int defaultConnectionLimit; // 0x10
		private static int maxServicePointIdleTime; // 0x14
		private static int maxServicePoints; // 0x18
		private static int dnsRefreshTimeout; // 0x1C
		private static bool _checkCRL; // 0x20
		private static SecurityProtocolType _securityProtocol; // 0x24
		private static bool expectContinue; // 0x28
		private static bool useNagle; // 0x29
		private static ServerCertValidationCallback server_cert_cb; // 0x30
		private static bool tcp_keepalive; // 0x38
		private static int tcp_keepalive_time; // 0x3C
		private static int tcp_keepalive_interval; // 0x40
	
		// Properties
		[MonoTODO("CRL checks not implemented")]
		public static bool CheckCertificateRevocationList { get; } // 0x0000000181B12570-0x0000000181B125C0 
		public static int DnsRefreshTimeout { get; } // 0x0000000181B125C0-0x0000000181B12610 
		public static SecurityProtocolType SecurityProtocol { get; } // 0x0000000181B12610-0x0000000181B12660 
		internal static ServerCertValidationCallback ServerCertValidationCallback { get; } // 0x0000000181B12660-0x0000000181B126B0 
		public static RemoteCertificateValidationCallback ServerCertificateValidationCallback { get; } // 0x0000000181B126B0-0x0000000181B12710 
	
		// Nested types
		internal class SPKey // TypeDefIndex: 9146
		{
			// Fields
			private Uri uri; // 0x10
			private Uri proxy; // 0x18
			private bool use_connect; // 0x20
	
			// Properties
			public bool UsesProxy { get; } // 0x0000000181B11B20-0x0000000181B11B70 
	
			// Constructors
			public SPKey(Uri uri, Uri proxy, bool use_connect); // 0x00000001815014B0-0x0000000181501520
	
			// Methods
			public override int GetHashCode(); // 0x0000000181B11A40-0x0000000181B11B20
			public override bool Equals(object obj); // 0x0000000181B11930-0x0000000181B11A40
		}
	
		// Constructors
		static ServicePointManager(); // 0x0000000181B12460-0x0000000181B12570
	
		// Methods
		internal static ICertificatePolicy GetLegacyCertificatePolicy(); // 0x0000000181B12380-0x0000000181B123D0
		public static ServicePoint FindServicePoint(Uri address, IWebProxy proxy); // 0x0000000181B11B70-0x0000000181B12380
		internal static void RemoveServicePoint(ServicePoint sp); // 0x0000000181B123D0-0x0000000181B12460
	}
}
