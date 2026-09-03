/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net.Cache;
using System.Net.Security;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Mono.Net.Security;
using Mono.Security.Interface;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	[Serializable]
	public class HttpWebRequest : WebRequest, ISerializable // TypeDefIndex: 9127
	{
		// Fields
		private Uri requestUri; // 0x38
		private Uri actualUri; // 0x40
		private bool hostChanged; // 0x48
		private bool allowAutoRedirect; // 0x49
		private bool allowBuffering; // 0x4A
		private X509CertificateCollection certificates; // 0x50
		private string connectionGroup; // 0x58
		private bool haveContentLength; // 0x60
		private long contentLength; // 0x68
		private HttpContinueDelegate continueDelegate; // 0x70
		private CookieContainer cookieContainer; // 0x78
		private ICredentials credentials; // 0x80
		private bool haveResponse; // 0x88
		private bool requestSent; // 0x89
		private WebHeaderCollection webHeaders; // 0x90
		private bool keepAlive; // 0x98
		private int maxAutoRedirect; // 0x9C
		private string mediaType; // 0xA0
		private string method; // 0xA8
		private string initialMethod; // 0xB0
		private bool pipelined; // 0xB8
		private bool preAuthenticate; // 0xB9
		private bool usedPreAuth; // 0xBA
		private Version version; // 0xC0
		private bool force_version; // 0xC8
		private Version actualVersion; // 0xD0
		private IWebProxy proxy; // 0xD8
		private bool sendChunked; // 0xE0
		private ServicePoint servicePoint; // 0xE8
		private int timeout; // 0xF0
		private int continueTimeout; // 0xF4
		private WebRequestStream writeStream; // 0xF8
		private HttpWebResponse webResponse; // 0x100
		private WebCompletionSource responseTask; // 0x108
		private WebOperation currentOperation; // 0x110
		private int aborted; // 0x118
		private bool gotRequestStream; // 0x11C
		private int redirects; // 0x120
		private bool expectContinue; // 0x124
		private bool getResponseCalled; // 0x125
		private object locker; // 0x128
		private bool finished_reading; // 0x130
		private DecompressionMethods auto_decomp; // 0x134
		private static int defaultMaxResponseHeadersLength; // 0x00
		private static int defaultMaximumErrorResponseLength; // 0x04
		private static RequestCachePolicy defaultCachePolicy; // 0x08
		private int readWriteTimeout; // 0x138
		private MobileTlsProvider tlsProvider; // 0x140
		private MonoTlsSettings tlsSettings; // 0x148
		private ServerCertValidationCallback certValidationCallback; // 0x150
		private bool hostHasPort; // 0x158
		private Uri hostUri; // 0x160
		private AuthorizationState auth_state; // 0x168
		private AuthorizationState proxy_auth_state; // 0x178
		[NonSerialized]
		internal Func<Stream, Task> ResendContentFactory; // 0x188
		[CompilerGenerated]
		private bool _ThrowOnError_k__BackingField; // 0x190
		private bool unsafe_auth_blah; // 0x191
	
		// Properties
		public Uri Address { get; } // 0x0000000180377940-0x0000000180377950 
		public virtual bool AllowWriteStreamBuffering { get; } // 0x0000000181A42140-0x0000000181A42150 
		public DecompressionMethods AutomaticDecompression { get; } // 0x0000000181C0F3A0-0x0000000181C0F3B0 
		internal bool InternalAllowBuffering { get; } // 0x0000000181C0F5A0-0x0000000181C0F5B0 
		private bool MethodWithBuffer { get; } // 0x0000000181C0F5B0-0x0000000181C0F690 
		internal MobileTlsProvider TlsProvider { get; } // 0x0000000181C0F740-0x0000000181C0F750 
		internal MonoTlsSettings TlsSettings { get; } // 0x000000018033D220-0x000000018033D230 
		public X509CertificateCollection ClientCertificates { get; } // 0x0000000181C0F3B0-0x0000000181C0F420 
		public override long ContentLength { get; } // 0x0000000180316960-0x0000000180316970 
		internal long InternalContentLength { set; } // 0x000000018033EA60-0x000000018033EA70
		internal bool ThrowOnError { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181C0F720-0x0000000181C0F730 0x0000000181C0FB90-0x0000000181C0FBA0
		public override ICredentials Credentials { get; set; } // 0x000000018033D4A0-0x000000018033D4B0 0x000000018033EA30-0x000000018033EA40
		[MonoTODO]
		public static int DefaultMaximumErrorResponseLength { get; } // 0x0000000181C0F420-0x0000000181C0F470 
		public override WebHeaderCollection Headers { get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
		public string Host { get; } // 0x0000000181C0F480-0x0000000181C0F5A0 
		public bool KeepAlive { get; } // 0x0000000180665210-0x0000000180665220 
		public int ReadWriteTimeout { get; } // 0x0000000181C0F6C0-0x0000000181C0F6D0 
		public override string Method { get; set; } // 0x000000018033D510-0x000000018033D520 0x0000000181C0F840-0x0000000181C0FAF0
		public Version ProtocolVersion { get; } // 0x00000001806CCB70-0x00000001806CCB80 
		public override IWebProxy Proxy { get; set; } // 0x00000001806CCBB0-0x00000001806CCBC0 0x0000000181C0FAF0-0x0000000181C0FB90
		public override Uri RequestUri { get; } // 0x00000001803272A0-0x00000001803272B0 
		public bool SendChunked { get; } // 0x0000000181C0F6D0-0x0000000181C0F6E0 
		public ServicePoint ServicePoint { get; } // 0x0000000181C0F710-0x0000000181C0F720 
		internal ServicePoint ServicePointNoLock { get; } // 0x00000001806BAE70-0x00000001806BAE80 
		public override int Timeout { get; } // 0x0000000181C0F730-0x0000000181C0F740 
		public string TransferEncoding { get; } // 0x0000000181C0F750-0x0000000181C0F7A0 
		public override bool UseDefaultCredentials { get; } // 0x0000000181C0F7B0-0x0000000181C0F830 
		public bool UnsafeAuthenticatedConnectionSharing { get; } // 0x0000000181C0F7A0-0x0000000181C0F7B0 
		internal bool ExpectContinue { get; set; } // 0x0000000181C0F470-0x0000000181C0F480 0x0000000181C0F830-0x0000000181C0F840
		internal Uri AuthUri { get; } // 0x0000000180377940-0x0000000180377950 
		internal bool ProxyQuery { get; } // 0x0000000181C0F690-0x0000000181C0F6C0 
		internal ServerCertValidationCallback ServerCertValidationCallback { get; } // 0x0000000181C0F6E0-0x0000000181C0F6F0 
		public RemoteCertificateValidationCallback ServerCertificateValidationCallback { get; } // 0x0000000181C0F6F0-0x0000000181C0F710 
		internal bool FinishedReading { set; } // 0x00000001805580F0-0x0000000180558100
		internal bool Aborted { get; } // 0x0000000181C0F380-0x0000000181C0F3A0 
	
		// Nested types
		private enum NtlmAuthState // TypeDefIndex: 9128
		{
			None = 0,
			Challenge = 1,
			Response = 2
		}
	
		private struct AuthorizationState // TypeDefIndex: 9129
		{
			// Fields
			private readonly HttpWebRequest request; // 0x00
			private readonly bool isProxy; // 0x08
			private bool isCompleted; // 0x09
			private NtlmAuthState ntlm_auth_state; // 0x0C
	
			// Properties
			public bool IsCompleted { get; } // 0x0000000181577100-0x0000000181577110 
			public NtlmAuthState NtlmAuthState { get; } // 0x0000000180732D30-0x0000000180732D40 
			public bool IsNtlmAuthenticated { get; } // 0x0000000181B0ED20-0x0000000181B0ED40 
	
			// Constructors
			public AuthorizationState(HttpWebRequest request, bool isProxy); // 0x0000000181B0ECE0-0x0000000181B0ED20
	
			// Methods
			public bool CheckAuthorization(WebResponse response, HttpStatusCode code); // 0x0000000181B0E900-0x0000000181B0EB90
			public void Reset(); // 0x0000000181B0EB90-0x0000000181B0EC10
			public override string ToString(); // 0x0000000181B0EC10-0x0000000181B0ECE0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c__241<T> // TypeDefIndex: 9130
		{
			// Fields
			public static readonly __c__241<T> __9;
			public static Func<Task<T>, int?> __9__241_0;
	
			// Constructors
			static __c__241();
			public __c__241();
	
			// Methods
			internal int? _RunWithTimeoutWorker_b__241_0(Task<T> t);
		}
	
		[CompilerGenerated]
		private struct _RunWithTimeoutWorker_d__241<T> : IAsyncStateMachine // TypeDefIndex: 9131
		{
			// Fields
			public int __1__state;
			public AsyncTaskMethodBuilder<T> __t__builder;
			public Task<T> workerTask;
			public int timeout;
			public CancellationTokenSource cts;
			public Action abort;
			public Func<bool> aborted;
			private ConfiguredTaskAwaitable<bool> __u__1;
	
			// Methods
			private void MoveNext();
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine);
		}
	
		[CompilerGenerated]
		private struct _MyGetResponseAsync_d__243 : IAsyncStateMachine // TypeDefIndex: 9132
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<HttpWebResponse> __t__builder; // 0x08
			public HttpWebRequest __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			private WebCompletionSource _completion_5__2; // 0x30
			private WebOperation _operation_5__3; // 0x38
			private WebException _throwMe_5__4; // 0x40
			private HttpWebResponse _response_5__5; // 0x48
			private WebResponseStream _stream_5__6; // 0x50
			private bool _redirect_5__7; // 0x58
			private bool _mustReadAll_5__8; // 0x59
			private WebOperation _ntlm_5__9; // 0x60
			private BufferOffsetSize _writeBuffer_5__10; // 0x68
			private ConfiguredTaskAwaitable<WebRequestStream> __u__1; // 0x70
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x80
			private TaskAwaiter<WebResponseStream> __u__3; // 0x90
			[TupleElementNames(new string[5] {"response", "redirect", "mustReadAll", "writeBuffer", "ntlm" })]
			private ConfiguredTaskAwaitable<ValueTuple<HttpWebResponse, bool, bool, BufferOffsetSize, WebOperation>> __u__4; // 0x98
	
			// Methods
			private void MoveNext(); // 0x0000000181B184D0-0x0000000181B195D0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B195D0-0x0000000181B19630
		}
	
		[CompilerGenerated]
		private struct _GetResponseFromData_d__244 : IAsyncStateMachine // TypeDefIndex: 9133
		{
			// Fields
			public int __1__state; // 0x00
			[TupleElementNames(new string[5] {"response", "redirect", "mustReadAll", "writeBuffer", "ntlm" })]
			public AsyncTaskMethodBuilder<ValueTuple<HttpWebResponse, bool, bool, BufferOffsetSize, WebOperation>> __t__builder; // 0x08
			public HttpWebRequest __4__this; // 0x20
			public WebResponseStream stream; // 0x28
			public CancellationToken cancellationToken; // 0x30
			private HttpWebResponse _response_5__2; // 0x38
			private WebException _throwMe_5__3; // 0x40
			private bool _redirect_5__4; // 0x48
			private bool _mustReadAll_5__5; // 0x49
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x50
			private ConfiguredTaskAwaitable<BufferOffsetSize> __u__2; // 0x60
	
			// Methods
			private void MoveNext(); // 0x0000000181B162C0-0x0000000181B16B70
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B16B70-0x0000000181B16BD0
		}
	
		[CompilerGenerated]
		private struct __GetRewriteHandler_b__271_0_d : IAsyncStateMachine // TypeDefIndex: 9134
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<BufferOffsetSize> __t__builder; // 0x08
			public HttpWebRequest __4__this; // 0x20
			private MemoryStream _ms_5__2; // 0x28
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x0000000181B1CE60-0x0000000181B1D240
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B1D240-0x0000000181B1D2A0
		}
	
		// Constructors
		static HttpWebRequest(); // 0x0000000181C0EE50-0x0000000181C0EF00
		public HttpWebRequest(Uri uri); // 0x0000000181C0EF30-0x0000000181C0F1B0
		[Obsolete("Serialization is obsoleted for this type.  http://go.microsoft.com/fwlink/?linkid=14202")]
		protected HttpWebRequest(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181C0F1B0-0x0000000181C0F380
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Obsolete("This API supports the .NET Framework infrastructure and is not intended to be used directly from your code.", true)]
		public HttpWebRequest(); // 0x0000000181C0EF00-0x0000000181C0EF30
	
		// Methods
		private void ResetAuthorization(); // 0x0000000181C0E9A0-0x0000000181C0EA20
		internal ServicePoint GetServicePoint(); // 0x0000000181C0DDA0-0x0000000181C0DEE0
		private WebOperation SendRequest(bool redirecting, BufferOffsetSize writeBuffer, CancellationToken cancellationToken); // 0x0000000181C0EAA0-0x0000000181C0ED30
		internal static Task<T> RunWithTimeout<T>(Func<CancellationToken, Task<T>> func, int timeout, Action abort, Func<bool> aborted, CancellationToken cancellationToken);
		private static async Task<T> RunWithTimeoutWorker<T>(Task<T> workerTask, int timeout, Action abort, Func<bool> aborted, CancellationTokenSource cts);
		private Task<T> RunWithTimeout<T>(Func<CancellationToken, Task<T>> func);
		private async Task<HttpWebResponse> MyGetResponseAsync(CancellationToken cancellationToken); // 0x0000000181C0E3A0-0x0000000181C0E490
		private async Task<ValueTuple<HttpWebResponse, bool, bool, BufferOffsetSize, WebOperation>> GetResponseFromData(WebResponseStream stream, CancellationToken cancellationToken); // 0x0000000181C0DA00-0x0000000181C0DB30
		internal static Exception FlattenException(Exception e); // 0x0000000181C0CE20-0x0000000181C0CEE0
		private WebException GetWebException(Exception e); // 0x0000000181C0E120-0x0000000181C0E1A0
		private static WebException GetWebException(Exception e, bool aborted); // 0x0000000181C0DEE0-0x0000000181C0E120
		internal static WebException CreateRequestAbortedException(); // 0x0000000181C0CAB0-0x0000000181C0CB50
		public override IAsyncResult BeginGetResponse(AsyncCallback callback, object state); // 0x0000000181C0C3B0-0x0000000181C0C580
		public override WebResponse EndGetResponse(IAsyncResult asyncResult); // 0x0000000181C0CD50-0x0000000181C0CE20
		public override WebResponse GetResponse(); // 0x0000000181C0DB30-0x0000000181C0DBB0
		public override void Abort(); // 0x0000000181C0C2F0-0x0000000181C0C3B0
		new void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181C0ED30-0x0000000181C0ED70
		protected override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181C0D5D0-0x0000000181C0D610
		private void CheckRequestStarted(); // 0x0000000181C0CA40-0x0000000181C0CAB0
		internal void DoContinueDelegate(int statusCode, WebHeaderCollection headers); // 0x0000000181C0CB50-0x0000000181C0CB70
		private void RewriteRedirectToGet(); // 0x0000000181C0EA20-0x0000000181C0EAA0
		private bool Redirect(HttpStatusCode code, WebResponse response); // 0x0000000181C0E490-0x0000000181C0E9A0
		private string GetHeaders(); // 0x0000000181C0CEE0-0x0000000181C0D5D0
		private void DoPreAuthenticate(); // 0x0000000181C0CB70-0x0000000181C0CD50
		internal byte[] GetRequestHeaders(); // 0x0000000181C0D610-0x0000000181C0DA00
		private ValueTuple<WebOperation, bool> HandleNtlmAuth(WebResponseStream stream, HttpWebResponse response, BufferOffsetSize writeBuffer, CancellationToken cancellationToken); // 0x0000000181C0E1A0-0x0000000181C0E3A0
		private bool CheckAuthorization(WebResponse response, HttpStatusCode code); // 0x0000000181C0C580-0x0000000181C0C5B0
		private ValueTuple<Task<BufferOffsetSize>, WebException> GetRewriteHandler(HttpWebResponse response, bool redirect); // 0x0000000181C0DBB0-0x0000000181C0DDA0
		private ValueTuple<bool, bool, Task<BufferOffsetSize>, WebException> CheckFinalStatus(HttpWebResponse response); // 0x0000000181C0C5B0-0x0000000181C0CA40
		[CompilerGenerated]
		private bool _RunWithTimeout_b__242_0<T>();
		[CompilerGenerated]
		private async Task<BufferOffsetSize> _GetRewriteHandler_b__271_0(); // 0x0000000181C0ED70-0x0000000181C0EE50
	}
}
