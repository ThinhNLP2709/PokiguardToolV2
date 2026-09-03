/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	public class ServicePoint // TypeDefIndex: 9144
	{
		// Fields
		private readonly Uri uri; // 0x10
		private DateTime lastDnsResolve; // 0x18
		private Version protocolVersion; // 0x20
		private IPHostEntry host; // 0x28
		private bool usesProxy; // 0x30
		private bool sendContinue; // 0x31
		private bool useConnect; // 0x32
		private object hostE; // 0x38
		private bool useNagle; // 0x40
		private BindIPEndPoint endPointCallback; // 0x48
		private bool tcp_keepalive; // 0x50
		private int tcp_keepalive_time; // 0x54
		private int tcp_keepalive_interval; // 0x58
		private bool disposed; // 0x5C
		private int connectionLeaseTimeout; // 0x60
		private int receiveBufferSize; // 0x64
		[CompilerGenerated]
		private readonly ServicePointManager.SPKey _Key_k__BackingField; // 0x68
		[CompilerGenerated]
		private ServicePointScheduler _Scheduler_k__BackingField; // 0x70
		private int connectionLimit; // 0x78
		private int maxIdleTime; // 0x7C
		private object m_ServerCertificateOrBytes; // 0x80
		private object m_ClientCertificateOrBytes; // 0x88
	
		// Properties
		internal ServicePointManager.SPKey Key { [CompilerGenerated] get; } // 0x0000000180316960-0x0000000180316970 
		private ServicePointScheduler Scheduler { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20
		public Uri Address { get; } // 0x0000000180377550-0x0000000180377560 
		public int ConnectionLimit { get; } // 0x000000018169BB50-0x000000018169BB60 
		public virtual Version ProtocolVersion { get; } // 0x00000001802F8630-0x00000001802F8640 
		public bool Expect100Continue { set; } // 0x0000000181B14860-0x0000000181B14870
		public bool UseNagleAlgorithm { get; set; } // 0x00000001803B1170-0x00000001803B1180 0x000000018042B340-0x000000018042B350
		internal bool SendContinue { get; set; } // 0x0000000181B147C0-0x0000000181B14850 0x0000000181B14860-0x0000000181B14870
		internal bool UsesProxy { get; set; } // 0x00000001802E8950-0x00000001802E8960 0x00000001802E8960-0x00000001802E8970
		internal bool UseConnect { get; set; } // 0x0000000181B14850-0x0000000181B14860 0x0000000181B14870-0x0000000181B14880
		private bool HasTimedOut { get; } // 0x0000000181B14210-0x0000000181B14340 
		internal IPHostEntry HostEntry { get; } // 0x0000000181B14340-0x0000000181B147C0 
	
		// Constructors
		internal ServicePoint(ServicePointManager.SPKey key, Uri uri, int connectionLimit, int maxIdleTime); // 0x0000000181B14110-0x0000000181B14210
	
		// Methods
		public void SetTcpKeepAlive(bool enabled, int keepAliveTime, int keepAliveInterval); // 0x0000000181B13F80-0x0000000181B14070
		internal void KeepAliveSetup(Socket socket); // 0x0000000181B13C70-0x0000000181B13DC0
		private static void PutBytes(byte[] bytes, uint v, int offset); // 0x0000000181B13DC0-0x0000000181B13E30
		internal void SetVersion(Version version); // 0x000000018033E830-0x000000018033E840
		internal void SendRequest(WebOperation operation, string groupName); // 0x0000000181B13E30-0x0000000181B13F80
		internal void FreeServicePoint(); // 0x0000000181B13C50-0x0000000181B13C70
		internal void UpdateServerCertificate(X509Certificate certificate); // 0x0000000181B140C0-0x0000000181B14110
		internal void UpdateClientCertificate(X509Certificate certificate); // 0x0000000181B14070-0x0000000181B140C0
		internal bool CallEndPointDelegate(Socket sock, IPEndPoint remote); // 0x0000000181B13B70-0x0000000181B13C50
	}
}
