/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Mono.Net.Security;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class WebConnection : IDisposable // TypeDefIndex: 9159
	{
		// Fields
		private NetworkCredential ntlm_credentials; // 0x10
		private bool ntlm_authenticated; // 0x18
		private bool unsafe_sharing; // 0x19
		private Stream networkStream; // 0x20
		private Socket socket; // 0x28
		private MonoTlsStream monoTlsStream; // 0x30
		private WebConnectionTunnel tunnel; // 0x38
		private int disposed; // 0x40
		[CompilerGenerated]
		private readonly ServicePoint _ServicePoint_k__BackingField; // 0x48
		private DateTime idleSince; // 0x50
		private WebOperation currentOperation; // 0x58
	
		// Properties
		public ServicePoint ServicePoint { [CompilerGenerated] get; } // 0x00000001803272B0-0x00000001803272C0 
		public bool Closed { get; } // 0x0000000181B21B80-0x0000000181B21B90 
		public DateTime IdleSince { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		internal bool NtlmAuthenticated { get; set; } // 0x0000000180F9E350-0x0000000180F9E360 0x00000001804C2E10-0x00000001804C2E20
		internal NetworkCredential NtlmCredential { get; set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		internal bool UnsafeAuthenticatedConnectionSharing { get; set; } // 0x0000000181780E10-0x0000000181780E20 0x0000000181780E30-0x0000000181780E40
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 9160
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<IPEndPoint, AsyncCallback, object, IAsyncResult> __9__16_0; // 0x08
			public static Action<IAsyncResult> __9__16_1; // 0x10
	
			// Constructors
			static __c(); // 0x0000000181B1D460-0x0000000181B1D4D0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal IAsyncResult _Connect_b__16_0(IPEndPoint targetEndPoint, AsyncCallback callback, object state); // 0x0000000181B1D2A0-0x0000000181B1D340
			internal void _Connect_b__16_1(IAsyncResult asyncResult); // 0x0000000181B1D340-0x0000000181B1D3E0
		}
	
		[CompilerGenerated]
		private struct _Connect_d__16 : IAsyncStateMachine // TypeDefIndex: 9161
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public WebConnection __4__this; // 0x20
			public WebOperation operation; // 0x28
			public CancellationToken cancellationToken; // 0x30
			private Exception _connectException_5__2; // 0x38
			private IPAddress[] __7__wrap2; // 0x40
			private int __7__wrap3; // 0x48
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x50
	
			// Methods
			private void MoveNext(); // 0x0000000181B14880-0x0000000181B15100
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B15100-0x0000000181B15160
		}
	
		[CompilerGenerated]
		private struct _CreateStream_d__18 : IAsyncStateMachine // TypeDefIndex: 9162
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<bool> __t__builder; // 0x08
			public WebConnection __4__this; // 0x20
			public WebOperation operation; // 0x28
			public bool reused; // 0x30
			public CancellationToken cancellationToken; // 0x38
			private NetworkStream _stream_5__2; // 0x40
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x48
			private ConfiguredTaskAwaitable<Stream> __u__2; // 0x58
	
			// Methods
			private void MoveNext(); // 0x0000000181B15160-0x0000000181B15910
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B15910-0x0000000181B15970
		}
	
		[CompilerGenerated]
		private struct _InitConnection_d__19 : IAsyncStateMachine // TypeDefIndex: 9163
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<WebRequestStream> __t__builder; // 0x08
			public WebOperation operation; // 0x20
			public CancellationToken cancellationToken; // 0x28
			public WebConnection __4__this; // 0x30
			private bool _reused_5__2; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
			private ConfiguredTaskAwaitable<bool> __u__2; // 0x50
	
			// Methods
			private void MoveNext(); // 0x0000000181B16BD0-0x0000000181B17260
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B17260-0x0000000181B172C0
		}
	
		// Constructors
		public WebConnection(ServicePoint sPoint); // 0x0000000181B21B40-0x0000000181B21B80
	
		// Methods
		private bool CanReuse(); // 0x0000000181B20B10-0x0000000181B20B40
		private bool CheckReusable(); // 0x0000000181B20B40-0x0000000181B20B90
		private async Task Connect(WebOperation operation, CancellationToken cancellationToken); // 0x0000000181B20DD0-0x0000000181B20EE0
		private async Task<bool> CreateStream(WebOperation operation, bool reused, CancellationToken cancellationToken); // 0x0000000181B21050-0x0000000181B21180
		internal async Task<WebRequestStream> InitConnection(WebOperation operation, CancellationToken cancellationToken); // 0x0000000181B21310-0x0000000181B21440
		internal static WebException GetException(WebExceptionStatus status, Exception error); // 0x0000000181B211A0-0x0000000181B21310
		internal static bool ReadLine(byte[] buffer, ref int start, int max, ref string output); // 0x0000000181B21690-0x0000000181B21860
		internal bool CanReuseConnection(WebOperation operation); // 0x0000000181B207A0-0x0000000181B20B10
		private bool PrepareSharingNtlm(WebOperation operation); // 0x0000000181B21440-0x0000000181B21690
		private void Reset(); // 0x0000000181B21890-0x0000000181B21950
		private void Close(bool reset); // 0x0000000181B20D10-0x0000000181B20DD0
		private void CloseSocket(); // 0x0000000181B20B90-0x0000000181B20D10
		public bool StartOperation(WebOperation operation, bool reused); // 0x0000000181B21950-0x0000000181B21B40
		public bool Continue(WebOperation next); // 0x0000000181B20EE0-0x0000000181B21050
		private void Dispose(bool disposing); // 0x0000000181B21180-0x0000000181B211A0
		public void Dispose(); // 0x0000000181B21180-0x0000000181B211A0
		private void ResetNtlm(); // 0x0000000181B21860-0x0000000181B21890
	}
}
