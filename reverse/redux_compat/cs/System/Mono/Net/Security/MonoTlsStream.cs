/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Mono.Security.Interface;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Net.Security
{
	internal class MonoTlsStream : IDisposable // TypeDefIndex: 8571
	{
		// Fields
		private readonly MobileTlsProvider provider; // 0x10
		private readonly NetworkStream networkStream; // 0x18
		private readonly HttpWebRequest request; // 0x20
		private readonly MonoTlsSettings settings; // 0x28
		private SslStream sslStream; // 0x30
		private readonly object sslStreamLock; // 0x38
		private WebExceptionStatus status; // 0x40
		[CompilerGenerated]
		private bool _CertificateValidationFailed_k__BackingField; // 0x44
	
		// Properties
		internal HttpWebRequest Request { get; } // 0x00000001802F8630-0x00000001802F8640 
		internal WebExceptionStatus ExceptionStatus { get; } // 0x000000018033D790-0x000000018033D7A0 
		internal bool CertificateValidationFailed { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018180F140-0x000000018180F150 0x000000018180F150-0x000000018180F160
	
		// Nested types
		[CompilerGenerated]
		private struct _CreateStream_d__18 : IAsyncStateMachine // TypeDefIndex: 8572
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<Stream> __t__builder; // 0x08
			public MonoTlsStream __4__this; // 0x20
			public WebConnectionTunnel tunnel; // 0x28
			public CancellationToken cancellationToken; // 0x30
			private Socket _socket_5__2; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x0000000181820610-0x0000000181820CD0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181820CD0-0x0000000181820D30
		}
	
		// Constructors
		public MonoTlsStream(HttpWebRequest request, NetworkStream networkStream); // 0x000000018181EB30-0x000000018181EDA0
	
		// Methods
		internal async Task<Stream> CreateStream(WebConnectionTunnel tunnel, CancellationToken cancellationToken); // 0x000000018181E9F0-0x000000018181EB20
		public void Dispose(); // 0x000000018181EB20-0x000000018181EB30
		private void CloseSslStream(); // 0x000000018181E930-0x000000018181E9F0
	}
}
