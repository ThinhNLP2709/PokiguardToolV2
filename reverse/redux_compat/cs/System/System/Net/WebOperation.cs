/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class WebOperation // TypeDefIndex: 9169
	{
		// Fields
		[CompilerGenerated]
		private readonly HttpWebRequest _Request_k__BackingField; // 0x10
		[CompilerGenerated]
		private WebConnection _Connection_k__BackingField; // 0x18
		[CompilerGenerated]
		private ServicePoint _ServicePoint_k__BackingField; // 0x20
		[CompilerGenerated]
		private readonly BufferOffsetSize _WriteBuffer_k__BackingField; // 0x28
		[CompilerGenerated]
		private readonly bool _IsNtlmChallenge_k__BackingField; // 0x30
		private CancellationTokenSource cts; // 0x38
		private WebCompletionSource<WebRequestStream> requestTask; // 0x40
		private WebCompletionSource<WebRequestStream> requestWrittenTask; // 0x48
		private WebCompletionSource<WebResponseStream> responseTask; // 0x50
		private WebCompletionSource<ValueTuple<bool, WebOperation>> finishedTask; // 0x58
		private WebRequestStream writeStream; // 0x60
		private WebResponseStream responseStream; // 0x68
		private ExceptionDispatchInfo disposedInfo; // 0x70
		private ExceptionDispatchInfo closedInfo; // 0x78
		private WebOperation priorityRequest; // 0x80
		private int requestSent; // 0x88
		private int finished; // 0x8C
	
		// Properties
		public HttpWebRequest Request { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public WebConnection Connection { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public ServicePoint ServicePoint { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		public BufferOffsetSize WriteBuffer { [CompilerGenerated] get; } // 0x000000018033D240-0x000000018033D250 
		public bool IsNtlmChallenge { [CompilerGenerated] get; } // 0x00000001802E8950-0x00000001802E8960 
		public bool Aborted { get; } // 0x0000000181B22CC0-0x0000000181B22D10 
		public bool Closed { get; } // 0x0000000181B22D10-0x0000000181B22D70 
		public WebRequestStream WriteStream { get; } // 0x0000000181B22D70-0x0000000181B22DD0 
		internal WebCompletionSource<ValueTuple<bool, WebOperation>> Finished { get; } // 0x00000001802F4000-0x00000001802F4010 
	
		// Nested types
		[CompilerGenerated]
		private struct _Run_d__58 : IAsyncStateMachine // TypeDefIndex: 9170
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncVoidMethodBuilder __t__builder; // 0x08
			public WebOperation __4__this; // 0x28
			private WebRequestStream _requestStream_5__2; // 0x30
			private WebResponseStream _stream_5__3; // 0x38
			private ConfiguredTaskAwaitable<WebRequestStream> __u__1; // 0x40
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x50
	
			// Methods
			private void MoveNext(); // 0x0000000181B1BFF0-0x0000000181B1C770
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000180457D10-0x0000000180457D20
		}
	
		// Constructors
		public WebOperation(HttpWebRequest request, BufferOffsetSize writeBuffer, bool isNtlmChallenge, CancellationToken cancellationToken); // 0x0000000181B22B00-0x0000000181B22CC0
	
		// Methods
		public void Abort(); // 0x0000000181B21B90-0x0000000181B21BF0
		public void Close(); // 0x0000000181B21D40-0x0000000181B21DA0
		private void SetCanceled(); // 0x0000000181B22470-0x0000000181B22540
		private void SetError(Exception error); // 0x0000000181B22620-0x0000000181B226C0
		private ValueTuple<ExceptionDispatchInfo, bool> SetDisposed(ref ExceptionDispatchInfo field); // 0x0000000181B22540-0x0000000181B22620
		internal ExceptionDispatchInfo CheckDisposed(CancellationToken cancellationToken); // 0x0000000181B21BF0-0x0000000181B21CD0
		internal void ThrowIfDisposed(); // 0x0000000181B22A60-0x0000000181B22AC0
		internal void ThrowIfDisposed(CancellationToken cancellationToken); // 0x0000000181B22980-0x0000000181B22A60
		internal void ThrowIfClosedOrDisposed(); // 0x0000000181B22840-0x0000000181B228A0
		internal void ThrowIfClosedOrDisposed(CancellationToken cancellationToken); // 0x0000000181B228A0-0x0000000181B22980
		private ExceptionDispatchInfo CheckThrowDisposed(bool throwIt, ref ExceptionDispatchInfo field); // 0x0000000181B21CD0-0x0000000181B21D40
		internal void RegisterRequest(ServicePoint servicePoint, WebConnection connection); // 0x0000000181B22160-0x0000000181B223F0
		public void SetPriorityRequest(WebOperation operation); // 0x0000000181B226C0-0x0000000181B22840
		internal Task<WebRequestStream> GetRequestStreamInternal(); // 0x0000000181B220C0-0x0000000181B22110
		public Task<WebResponseStream> GetResponseStream(); // 0x0000000181B22110-0x0000000181B22160
		internal async void Run(); // 0x0000000181B223F0-0x0000000181B22470
		internal void CompleteRequestWritten(WebRequestStream stream, Exception error = null); // 0x0000000181B21DA0-0x0000000181B21E30
		internal void Finish(bool ok, Exception error = null); // 0x0000000181B21E30-0x0000000181B220C0
		[CompilerGenerated]
		private void _RegisterRequest_b__48_0(); // 0x0000000181B22AC0-0x0000000181B22B00
	}
}
