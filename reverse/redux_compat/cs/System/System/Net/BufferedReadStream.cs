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
	internal class BufferedReadStream : WebReadStream // TypeDefIndex: 9113
	{
		// Fields
		private readonly BufferOffsetSize readBuffer; // 0x40
	
		// Nested types
		[CompilerGenerated]
		private struct _ProcessReadAsync_d__2 : IAsyncStateMachine // TypeDefIndex: 9114
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<int> __t__builder; // 0x08
			public CancellationToken cancellationToken; // 0x20
			public BufferedReadStream __4__this; // 0x28
			public int size; // 0x30
			public byte[] buffer; // 0x38
			public int offset; // 0x40
			private ConfiguredTaskAwaitable<int> __u__1; // 0x48
	
			// Methods
			private void MoveNext(); // 0x0000000181C137E0-0x0000000181C13A80
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x0000000181C13A80-0x0000000181C13AE0
		}
	
		// Constructors
		public BufferedReadStream(WebOperation operation, Stream innerStream, BufferOffsetSize readBuffer); // 0x0000000181BFBBC0-0x0000000181BFBC00
	
		// Methods
		protected override async Task<int> ProcessReadAsync(byte[] buffer, int offset, int size, CancellationToken cancellationToken); // 0x0000000181BFB9F0-0x0000000181BFBB20
		internal bool TryReadFromBuffer(byte[] buffer, int offset, int size, out int result); // 0x0000000181BFBB20-0x0000000181BFBBC0
	}
}
