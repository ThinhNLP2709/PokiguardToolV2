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
	internal class MonoChunkStream : WebReadStream // TypeDefIndex: 9140
	{
		// Fields
		[CompilerGenerated]
		private readonly WebHeaderCollection _Headers_k__BackingField; // 0x40
		[CompilerGenerated]
		private readonly MonoChunkParser _Decoder_k__BackingField; // 0x48
	
		// Properties
		protected MonoChunkParser Decoder { [CompilerGenerated] get; } // 0x00000001803272B0-0x00000001803272C0 
	
		// Nested types
		[CompilerGenerated]
		private struct _ProcessReadAsync_d__7 : IAsyncStateMachine // TypeDefIndex: 9141
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<int> __t__builder; // 0x08
			public CancellationToken cancellationToken; // 0x20
			public MonoChunkStream __4__this; // 0x28
			public byte[] buffer; // 0x30
			public int offset; // 0x38
			public int size; // 0x3C
			private byte[] _moreBytes_5__2; // 0x40
			private ConfiguredTaskAwaitable<int> __u__1; // 0x48
	
			// Methods
			private void MoveNext(); // 0x0000000181B19630-0x0000000181B19A20
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B19A20-0x0000000181B19A80
		}
	
		[CompilerGenerated]
		private struct _FinishReading_d__8 : IAsyncStateMachine // TypeDefIndex: 9142
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public MonoChunkStream __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x30
			private byte[] _buffer_5__2; // 0x40
			private ConfiguredTaskAwaitable<int> __u__2; // 0x48
	
			// Methods
			private void MoveNext(); // 0x0000000181B15970-0x0000000181B15EB0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181B15EB0-0x0000000181B15F10
		}
	
		// Constructors
		public MonoChunkStream(WebOperation operation, Stream innerStream, WebHeaderCollection headers); // 0x0000000181B11650-0x0000000181B117B0
	
		// Methods
		protected override async Task<int> ProcessReadAsync(byte[] buffer, int offset, int size, CancellationToken cancellationToken); // 0x0000000181B11390-0x0000000181B114C0
		internal override async Task FinishReading(CancellationToken cancellationToken); // 0x0000000181B11290-0x0000000181B11390
		private static void ThrowExpectingChunkTrailer(); // 0x0000000181B114C0-0x0000000181B11530
		[CompilerGenerated]
		[DebuggerHidden]
		private Task __n__0(CancellationToken cancellationToken); // 0x0000000181B11530-0x0000000181B11650
	}
}
