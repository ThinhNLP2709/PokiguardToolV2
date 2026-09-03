/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.IO
{
	[Serializable]
	public class StreamReader : TextReader // TypeDefIndex: 3654
	{
		// Fields
		public static readonly StreamReader Null; // 0x00
		private Stream _stream; // 0x18
		private Encoding _encoding; // 0x20
		private Decoder _decoder; // 0x28
		private byte[] _byteBuffer; // 0x30
		private char[] _charBuffer; // 0x38
		private int _charPos; // 0x40
		private int _charLen; // 0x44
		private int _byteLen; // 0x48
		private int _bytePos; // 0x4C
		private int _maxCharsPerBuffer; // 0x50
		private bool _detectEncoding; // 0x54
		private bool _checkPreamble; // 0x55
		private bool _isBlocked; // 0x56
		private bool _closable; // 0x57
		private Task _asyncReadTask; // 0x58
	
		// Properties
		public virtual Encoding CurrentEncoding { get; } // 0x00000001802F8630-0x00000001802F8640 
		public virtual Stream BaseStream { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		internal bool LeaveOpen { get; } // 0x00000001815B5AF0-0x00000001815B5B00 
	
		// Nested types
		private class NullStreamReader : StreamReader // TypeDefIndex: 3655
		{
			// Properties
			public override Stream BaseStream { get; } // 0x00000001815B16B0-0x00000001815B16F0 
			public override Encoding CurrentEncoding { get; } // 0x00000001815B16F0-0x00000001815B1700 
	
			// Constructors
			internal NullStreamReader(); // 0x00000001815B1570-0x00000001815B16B0
	
			// Methods
			protected override void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
			public override int Peek(); // 0x00000001815418D0-0x00000001815418E0
			public override int Read(); // 0x00000001815418D0-0x00000001815418E0
			public override int Read(char[] buffer, int index, int count); // 0x00000001802E7860-0x00000001802E7870
			public override string ReadLine(); // 0x00000001802E7860-0x00000001802E7870
			public override string ReadToEnd(); // 0x00000001815B1550-0x00000001815B1570
			internal override int ReadBuffer(); // 0x00000001802E7860-0x00000001802E7870
		}
	
		[CompilerGenerated]
		private struct _ReadAsyncInternal_d__66 : IAsyncStateMachine // TypeDefIndex: 3656
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncValueTaskMethodBuilder<int> __t__builder; // 0x08
			public StreamReader __4__this; // 0x28
			public Memory<char> buffer; // 0x30
			public CancellationToken cancellationToken; // 0x40
			private int _charsRead_5__2; // 0x48
			private bool _readToUserBuffer_5__3; // 0x4C
			private byte[] _tmpByteBuffer_5__4; // 0x50
			private Stream _tmpStream_5__5; // 0x58
			private int _count_5__6; // 0x60
			private ConfiguredTaskAwaitable<int> __u__1; // 0x68
			private int _n_5__7; // 0x78
			private ConfiguredValueTaskAwaitable<int> __u__2; // 0x80
	
			// Methods
			private void MoveNext(); // 0x00000001815B9120-0x00000001815BA110
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001815BA110-0x00000001815BA160
		}
	
		[CompilerGenerated]
		private struct _ReadBufferAsync_d__69 : IAsyncStateMachine // TypeDefIndex: 3657
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder<int> __t__builder; // 0x08
			public StreamReader __4__this; // 0x20
			private byte[] _tmpByteBuffer_5__2; // 0x28
			private Stream _tmpStream_5__3; // 0x30
			private ConfiguredValueTaskAwaitable<int> __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001815BA160-0x00000001815BADB0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001815BADB0-0x00000001815BAE10
		}
	
		// Constructors
		internal StreamReader(); // 0x00000001815B5430-0x00000001815B5500
		public StreamReader(Stream stream); // 0x00000001815B5A80-0x00000001815B5AD0
		public StreamReader(Stream stream, bool detectEncodingFromByteOrderMarks); // 0x00000001815B5500-0x00000001815B5560
		public StreamReader(Stream stream, Encoding encoding); // 0x00000001815B5400-0x00000001815B5430
		public StreamReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen); // 0x00000001815B5560-0x00000001815B57B0
		public StreamReader(string path); // 0x00000001815B5320-0x00000001815B5370
		public StreamReader(string path, bool detectEncodingFromByteOrderMarks); // 0x00000001815B5370-0x00000001815B53D0
		public StreamReader(string path, Encoding encoding); // 0x00000001815B53D0-0x00000001815B5400
		public StreamReader(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks); // 0x00000001815B5AD0-0x00000001815B5AF0
		public StreamReader(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize); // 0x00000001815B57B0-0x00000001815B5A80
		static StreamReader(); // 0x00000001815B5190-0x00000001815B5320
	
		// Methods
		private void CheckAsyncTaskInProgress(); // 0x00000001815B2EE0-0x00000001815B2F50
		private static void ThrowAsyncIOInProgress(); // 0x00000001815B5140-0x00000001815B5190
		private void Init(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen); // 0x00000001815B3340-0x00000001815B34A0
		internal void Init(Stream stream); // 0x00000001815B3320-0x00000001815B3340
		public override void Close(); // 0x00000001814CBE20-0x00000001814CBE40
		protected override void Dispose(bool disposing); // 0x00000001815B3290-0x00000001815B3320
		public override int Peek(); // 0x00000001815B35B0-0x00000001815B36D0
		public override int Read(); // 0x00000001815B4E60-0x00000001815B4F80
		public override int Read(char[] buffer, int index, int count); // 0x00000001815B4F80-0x00000001815B5140
		public override int Read(Span<char> buffer); // 0x00000001815B4DE0-0x00000001815B4E60
		private int ReadSpan(Span<char> buffer); // 0x00000001815B49E0-0x00000001815B4C80
		public override string ReadToEnd(); // 0x00000001815B4C80-0x00000001815B4DE0
		private void CompressBuffer(int n); // 0x00000001815B2F50-0x00000001815B2F90
		private void DetectEncoding(); // 0x00000001815B2FA0-0x00000001815B3290
		private bool IsPreamble(); // 0x00000001815B34A0-0x00000001815B35B0
		internal virtual int ReadBuffer(); // 0x00000001815B3C20-0x00000001815B40E0
		private int ReadBuffer(Span<char> userBuffer, out bool readToUserBuffer); // 0x00000001815B40E0-0x00000001815B4740
		public override string ReadLine(); // 0x00000001815B4740-0x00000001815B49E0
		public override Task<int> ReadAsync(char[] buffer, int index, int count); // 0x00000001815B3830-0x00000001815B3B30
		internal override async ValueTask<int> ReadAsyncInternal(Memory<char> buffer, CancellationToken cancellationToken); // 0x00000001815B36D0-0x00000001815B3830
		private async Task<int> ReadBufferAsync(); // 0x00000001815B3B30-0x00000001815B3C20
		internal bool DataAvailable(); // 0x00000001815B2F90-0x00000001815B2FA0
	}
}
