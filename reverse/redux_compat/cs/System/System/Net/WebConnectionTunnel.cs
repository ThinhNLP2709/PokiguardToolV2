/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class WebConnectionTunnel // TypeDefIndex: 9165
	{
		// Fields
		[CompilerGenerated]
		private readonly HttpWebRequest _Request_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly Uri _ConnectUri_k__BackingField; // 0x18
		private HttpWebRequest connectRequest; // 0x20
		private NtlmAuthState ntlmAuthState; // 0x28
		[CompilerGenerated]
		private bool _Success_k__BackingField; // 0x2C
		[CompilerGenerated]
		private bool _CloseConnection_k__BackingField; // 0x2D
		[CompilerGenerated]
		private int _StatusCode_k__BackingField; // 0x30
		[CompilerGenerated]
		private string _StatusDescription_k__BackingField; // 0x38
		[CompilerGenerated]
		private string[] _Challenge_k__BackingField; // 0x40
		[CompilerGenerated]
		private WebHeaderCollection _Headers_k__BackingField; // 0x48
		[CompilerGenerated]
		private Version _ProxyVersion_k__BackingField; // 0x50
		[CompilerGenerated]
		private byte[] _Data_k__BackingField; // 0x58
	
		// Properties
		public HttpWebRequest Request { [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public Uri ConnectUri { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public bool Success { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181B20770-0x0000000181B20780 0x0000000181B20790-0x0000000181B207A0
		public bool CloseConnection { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181B20760-0x0000000181B20770 0x0000000181B20780-0x0000000181B20790
		public int StatusCode { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D100-0x000000018033D110 0x000000018033E780-0x000000018033E790
		private string StatusDescription { [CompilerGenerated] set; } // 0x000000018033E850-0x000000018033E860
		public string[] Challenge { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377940-0x0000000180377950 0x0000000180378120-0x0000000180378130
		public WebHeaderCollection Headers { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		public Version ProxyVersion { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		public byte[] Data { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
	
		// Nested types
		private enum NtlmAuthState // TypeDefIndex: 9166
		{
			None = 0,
			Challenge = 1,
			Response = 2
		}
	
		[CompilerGenerated]
		private struct _Initialize_d__42 : IAsyncStateMachine // TypeDefIndex: 9167
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public WebConnectionTunnel __4__this; // 0x20
			public Stream stream; // 0x28
			public CancellationToken cancellationToken; // 0x30
			private bool _have_auth_5__2; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
			private ConfiguredTaskAwaitable<ValueTuple<WebHeaderCollection, byte[], int>> __u__2; // 0x50
	
			// Methods
			private void MoveNext(); // 0x0000000181B17680-0x0000000181B18470
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B18470-0x0000000181B184D0
		}
	
		[CompilerGenerated]
		private struct _ReadHeaders_d__43 : IAsyncStateMachine // TypeDefIndex: 9168
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<ValueTuple<WebHeaderCollection, byte[], int>> __t__builder; // 0x08
			public CancellationToken cancellationToken; // 0x20
			public Stream stream; // 0x28
			public WebConnectionTunnel __4__this; // 0x30
			private byte[] _retBuffer_5__2; // 0x38
			private int _status_5__3; // 0x40
			private byte[] _buffer_5__4; // 0x48
			private MemoryStream _ms_5__5; // 0x50
			private ConfiguredTaskAwaitable<int> __u__1; // 0x58
	
			// Methods
			private void MoveNext(); // 0x0000000181B1A600-0x0000000181B1AEE0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B1AEE0-0x0000000181B1AF40
		}
	
		// Constructors
		public WebConnectionTunnel(HttpWebRequest request, Uri connectUri); // 0x0000000180CB0730-0x0000000180CB0780
	
		// Methods
		internal async Task Initialize(Stream stream, CancellationToken cancellationToken); // 0x0000000181B20520-0x0000000181B20630
		private async Task<ValueTuple<WebHeaderCollection, byte[], int>> ReadHeaders(Stream stream, CancellationToken cancellationToken); // 0x0000000181B20630-0x0000000181B20760
		private void FlushContents(Stream stream, int contentLength); // 0x0000000181B20490-0x0000000181B20520
	}
}
