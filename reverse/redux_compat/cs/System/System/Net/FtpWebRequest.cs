/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Cache;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	public sealed class FtpWebRequest : WebRequest // TypeDefIndex: 9021
	{
		// Fields
		private object _syncObject; // 0x38
		private ICredentials _authInfo; // 0x40
		private readonly Uri _uri; // 0x48
		private FtpMethodInfo _methodInfo; // 0x50
		private string _renameTo; // 0x58
		private bool _getRequestStreamStarted; // 0x60
		private bool _getResponseStarted; // 0x61
		private DateTime _startTime; // 0x68
		private int _timeout; // 0x70
		private int _remainingTimeout; // 0x74
		private long _contentLength; // 0x78
		private long _contentOffset; // 0x80
		private X509CertificateCollection _clientCertificates; // 0x88
		private bool _passive; // 0x90
		private bool _binary; // 0x91
		private bool _async; // 0x92
		private bool _aborted; // 0x93
		private bool _timedOut; // 0x94
		private Exception _exception; // 0x98
		private TimerThread.Queue _timerQueue; // 0xA0
		private TimerThread.Callback _timerCallback; // 0xA8
		private bool _enableSsl; // 0xB0
		private FtpControlStream _connection; // 0xB8
		private Stream _stream; // 0xC0
		private RequestStage _requestStage; // 0xC8
		private bool _onceFailed; // 0xCC
		private WebHeaderCollection _ftpRequestHeaders; // 0xD0
		private FtpWebResponse _ftpWebResponse; // 0xD8
		private int _readWriteTimeout; // 0xE0
		private ContextAwareResult _writeAsyncResult; // 0xE8
		private LazyAsyncResult _readAsyncResult; // 0xF0
		private LazyAsyncResult _requestCompleteAsyncResult; // 0xF8
		private static readonly NetworkCredential s_defaultFtpNetworkCredential; // 0x00
		private static readonly TimerThread.Queue s_DefaultTimerQueue; // 0x08
	
		// Properties
		internal FtpMethodInfo MethodInfo { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		public override string Method { get; set; } // 0x0000000181BECBF0-0x0000000181BECC10 0x0000000181BECEC0-0x0000000181BED060
		public string RenameTo { get; } // 0x00000001802F4000-0x00000001802F4010 
		public override ICredentials Credentials { get; set; } // 0x0000000180377940-0x0000000180377950 0x0000000181BECD40-0x0000000181BECEC0
		public override Uri RequestUri { get; } // 0x00000001803272B0-0x00000001803272C0 
		public override int Timeout { get; } // 0x0000000180CC2260-0x0000000180CC2270 
		internal int RemainingTimeout { get; } // 0x0000000181974810-0x0000000181974820 
		public int ReadWriteTimeout { get; } // 0x0000000181BECC10-0x0000000181BECC20 
		public long ContentOffset { get; } // 0x000000018033D4A0-0x000000018033D4B0 
		public override long ContentLength { get; } // 0x000000018033D4E0-0x000000018033D4F0 
		public override IWebProxy Proxy { get; set; } // 0x00000001802E7860-0x00000001802E7870 0x0000000181BED060-0x0000000181BED0D0
		internal bool Aborted { get; } // 0x0000000181845FA0-0x0000000181845FB0 
		private TimerThread.Queue TimerQueue { get; } // 0x0000000181BECC20-0x0000000181BECCA0 
		public override RequestCachePolicy CachePolicy { set; } // 0x0000000181BECCD0-0x0000000181BECD40
		public bool UseBinary { get; } // 0x0000000181845F90-0x0000000181845FA0 
		public bool UsePassive { get; } // 0x000000018033D630-0x000000018033D640 
		public X509CertificateCollection ClientCertificates { get; } // 0x0000000181BECA30-0x0000000181BECB30 
		public bool EnableSsl { get; } // 0x00000001807186D0-0x00000001807186E0 
		public override WebHeaderCollection Headers { get; } // 0x0000000181BECB30-0x0000000181BECBD0 
		public override bool UseDefaultCredentials { get; } // 0x0000000181BECCA0-0x0000000181BECCD0 
		private bool InUse { get; } // 0x0000000181BECBD0-0x0000000181BECBF0 
	
		// Nested types
		private enum RequestStage // TypeDefIndex: 9022
		{
			CheckForError = 0,
			RequestStarted = 1,
			WriteReady = 2,
			ReadReady = 3,
			ReleaseConnection = 4
		}
	
		[CompilerGenerated]
		private struct _CreateConnectionAsync_d__86 : IAsyncStateMachine // TypeDefIndex: 9023
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncVoidMethodBuilder __t__builder; // 0x08
			public FtpWebRequest __4__this; // 0x28
			private TcpClient _client_5__2; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x0000000181BF5430-0x0000000181BF56D0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000180457D10-0x0000000180457D20
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9024
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<X509CertificateCollection> __9__114_0; // 0x08
	
			// Constructors
			static __c(); // 0x0000000181BF5A40-0x0000000181BF5AB0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal X509CertificateCollection _get_ClientCertificates_b__114_0(); // 0x0000000181BF56D0-0x0000000181BF5720
		}
	
		// Constructors
		internal FtpWebRequest(Uri uri); // 0x0000000181BEC5E0-0x0000000181BECA30
		static FtpWebRequest(); // 0x0000000181BEC450-0x0000000181BEC5E0
	
		// Methods
		public override WebResponse GetResponse(); // 0x0000000181BEA800-0x0000000181BEAFE0
		public override IAsyncResult BeginGetResponse(AsyncCallback callback, object state); // 0x0000000181BE8FC0-0x0000000181BE9640
		public override WebResponse EndGetResponse(IAsyncResult asyncResult); // 0x0000000181BE98B0-0x0000000181BE9C10
		private void SubmitRequest(bool isAsync); // 0x0000000181BEB3F0-0x0000000181BEB9B0
		private Exception TranslateConnectException(Exception e); // 0x0000000181BEC370-0x0000000181BEC450
		private async void CreateConnectionAsync(); // 0x0000000181BE9660-0x0000000181BE96F0
		private FtpControlStream CreateConnection(); // 0x0000000181BE96F0-0x0000000181BE9800
		private Stream TimedSubmitRequestHelper(bool isAsync); // 0x0000000181BEBDC0-0x0000000181BEC2B0
		private void TimerCallback(TimerThread.Timer timer, int timeNoticed, object context); // 0x0000000181BEC2B0-0x0000000181BEC370
		private bool AttemptedRecovery(Exception e); // 0x0000000181BE8D00-0x0000000181BE8FC0
		private void SetException(Exception exception); // 0x0000000181BEB000-0x0000000181BEB3F0
		private void CheckError(); // 0x0000000181BE9640-0x0000000181BE9660
		internal void RequestCallback(object obj); // 0x0000000181BEAFE0-0x0000000181BEB000
		private void SyncRequestCallback(object obj); // 0x0000000181BEB9B0-0x0000000181BEBDC0
		private void AsyncRequestCallback(object obj); // 0x0000000181BE81E0-0x0000000181BE8D00
		private RequestStage FinishRequestStage(RequestStage stage); // 0x0000000181BEA2C0-0x0000000181BEA800
		public override void Abort(); // 0x0000000181BE7DB0-0x0000000181BE81E0
		private void EnsureFtpWebResponse(Exception exception); // 0x0000000181BE9C10-0x0000000181BEA2C0
		internal void DataStreamClosed(CloseExState closeState); // 0x0000000181BE9800-0x0000000181BE98B0
	}
}
