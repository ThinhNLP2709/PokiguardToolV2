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
	public class StreamWriter : TextWriter // TypeDefIndex: 3658
	{
		// Fields
		public static readonly StreamWriter Null; // 0x00
		private Stream _stream; // 0x30
		private Encoding _encoding; // 0x38
		private Encoder _encoder; // 0x40
		private byte[] _byteBuffer; // 0x48
		private char[] _charBuffer; // 0x50
		private int _charPos; // 0x58
		private int _charLen; // 0x5C
		private bool _autoFlush; // 0x60
		private bool _haveWrittenPreamble; // 0x61
		private bool _closable; // 0x62
		private Task _asyncWriteTask; // 0x68
	
		// Properties
		private static Encoding UTF8NoBOM { get; } // 0x00000001815B8420-0x00000001815B8460 
		public virtual bool AutoFlush { set; } // 0x00000001815B8460-0x00000001815B84F0
		public virtual Stream BaseStream { get; } // 0x000000018031E110-0x000000018031E120 
		internal bool LeaveOpen { get; } // 0x00000001815B8410-0x00000001815B8420 
		public override Encoding Encoding { get; } // 0x00000001803272A0-0x00000001803272B0 
		private int CharPos_Prop { set; } // 0x000000018033E870-0x000000018033E880
		private bool HaveWrittenPreamble_Prop { set; } // 0x00000001815B84F0-0x00000001815B8500
	
		// Nested types
		[CompilerGenerated]
		private struct _WriteAsyncInternal_d__57 : IAsyncStateMachine // TypeDefIndex: 3659
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public int charPos; // 0x20
			public int charLen; // 0x24
			public StreamWriter _this; // 0x28
			public char[] charBuffer; // 0x30
			public char value; // 0x38
			public bool appendNewLine; // 0x3A
			public char[] coreNewLine; // 0x40
			public bool autoFlush; // 0x48
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x50
			private int _i_5__2; // 0x60
	
			// Methods
			private void MoveNext(); // 0x00000001815BAE10-0x00000001815BB2D0
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001815BB2D0-0x00000001815BB330
		}
	
		[CompilerGenerated]
		private struct _WriteAsyncInternal_d__59 : IAsyncStateMachine // TypeDefIndex: 3660
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public string value; // 0x20
			public int charPos; // 0x28
			public int charLen; // 0x2C
			public StreamWriter _this; // 0x30
			public char[] charBuffer; // 0x38
			public bool appendNewLine; // 0x40
			public char[] coreNewLine; // 0x48
			public bool autoFlush; // 0x50
			private int _count_5__2; // 0x54
			private int _index_5__3; // 0x58
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x60
			private int _i_5__4; // 0x70
	
			// Methods
			private void MoveNext(); // 0x00000001815BB330-0x00000001815BB810
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001815BB810-0x00000001815BB870
		}
	
		[CompilerGenerated]
		private struct _WriteAsyncInternal_d__62 : IAsyncStateMachine // TypeDefIndex: 3661
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public int charPos; // 0x20
			public int charLen; // 0x24
			public StreamWriter _this; // 0x28
			public char[] charBuffer; // 0x30
			public CancellationToken cancellationToken; // 0x38
			public ReadOnlyMemory<char> source; // 0x40
			public bool appendNewLine; // 0x50
			public char[] coreNewLine; // 0x58
			public bool autoFlush; // 0x60
			private int _copied_5__2; // 0x64
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x68
			private int _i_5__3; // 0x78
	
			// Methods
			private void MoveNext(); // 0x00000001815D5300-0x00000001815D5910
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001815D5910-0x00000001815D5970
		}
	
		[CompilerGenerated]
		private struct _FlushAsyncInternal_d__74 : IAsyncStateMachine // TypeDefIndex: 3662
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public bool haveWrittenPreamble; // 0x20
			public StreamWriter _this; // 0x28
			public Encoding encoding; // 0x30
			public Stream stream; // 0x38
			public CancellationToken cancellationToken; // 0x40
			public Encoder encoder; // 0x48
			public char[] charBuffer; // 0x50
			public int charPos; // 0x58
			public byte[] byteBuffer; // 0x60
			public bool flushEncoder; // 0x68
			public bool flushStream; // 0x69
			private ConfiguredValueTaskAwaitable.ConfiguredValueTaskAwaiter __u__1; // 0x70
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x80
	
			// Methods
			private void MoveNext(); // 0x00000001815D3F10-0x00000001815D4550
			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine); // 0x00000001815D4550-0x00000001815D45B0
		}
	
		// Constructors
		internal StreamWriter(); // 0x00000001815B8320-0x00000001815B83F0
		public StreamWriter(Stream stream); // 0x00000001815B80E0-0x00000001815B8190
		public StreamWriter(Stream stream, Encoding encoding); // 0x00000001815B7DE0-0x00000001815B7E10
		public StreamWriter(Stream stream, Encoding encoding, int bufferSize); // 0x00000001815B83F0-0x00000001815B8410
		public StreamWriter(Stream stream, Encoding encoding, int bufferSize, bool leaveOpen); // 0x00000001815B7B90-0x00000001815B7DE0
		public StreamWriter(string path); // 0x00000001815B8250-0x00000001815B8300
		public StreamWriter(string path, bool append); // 0x00000001815B8190-0x00000001815B8250
		public StreamWriter(string path, bool append, Encoding encoding); // 0x00000001815B8300-0x00000001815B8320
		public StreamWriter(string path, bool append, Encoding encoding, int bufferSize); // 0x00000001815B7E10-0x00000001815B80E0
		static StreamWriter(); // 0x00000001815B7A90-0x00000001815B7B90
	
		// Methods
		private void CheckAsyncTaskInProgress(); // 0x00000001815B5B00-0x00000001815B5B70
		private static void ThrowAsyncIOInProgress(); // 0x00000001815B6560-0x00000001815B65B0
		private void Init(Stream streamArg, Encoding encodingArg, int bufferSize, bool shouldLeaveOpen); // 0x00000001815B63F0-0x00000001815B6560
		public override void Close(); // 0x00000001815B5B70-0x00000001815B5BE0
		protected override void Dispose(bool disposing); // 0x00000001815B5BE0-0x00000001815B5C80
		public override void Flush(); // 0x00000001815B61D0-0x00000001815B6250
		private void Flush(bool flushStream, bool flushEncoder); // 0x00000001815B6250-0x00000001815B63F0
		public override void Write(char value); // 0x00000001815B7760-0x00000001815B7820
		public override void Write(char[] buffer); // 0x00000001815B7820-0x00000001815B7860
		public override void Write(char[] buffer, int index, int count); // 0x00000001815B7860-0x00000001815B7A90
		private void WriteSpan(ReadOnlySpan<char> buffer, bool appendNewLine); // 0x00000001815B7410-0x00000001815B76F0
		public override void Write(string value); // 0x00000001815B76F0-0x00000001815B7760
		public override void WriteLine(string value); // 0x00000001815B7350-0x00000001815B7410
		public override Task WriteAsync(char value); // 0x00000001815B69A0-0x00000001815B6C00
		private static async Task WriteAsyncInternal(StreamWriter _this, char value, char[] charBuffer, int charPos, int charLen, char[] coreNewLine, bool autoFlush, bool appendNewLine); // 0x00000001815B6860-0x00000001815B69A0
		public override Task WriteAsync(string value); // 0x00000001815B6C00-0x00000001815B6EF0
		private static async Task WriteAsyncInternal(StreamWriter _this, string value, char[] charBuffer, int charPos, int charLen, char[] coreNewLine, bool autoFlush, bool appendNewLine); // 0x00000001815B65B0-0x00000001815B6700
		public override Task WriteAsync(char[] buffer, int index, int count); // 0x00000001815B6EF0-0x00000001815B7350
		private static async Task WriteAsyncInternal(StreamWriter _this, ReadOnlyMemory<char> source, char[] charBuffer, int charPos, int charLen, char[] coreNewLine, bool autoFlush, bool appendNewLine, CancellationToken cancellationToken); // 0x00000001815B6700-0x00000001815B6860
		public override Task FlushAsync(); // 0x00000001815B60B0-0x00000001815B61D0
		private Task FlushAsyncInternal(bool flushStream, bool flushEncoder, char[] sCharBuffer, int sCharPos, CancellationToken cancellationToken = default); // 0x00000001815B5E10-0x00000001815B60B0
		private static async Task FlushAsyncInternal(StreamWriter _this, bool flushStream, bool flushEncoder, char[] charBuffer, int charPos, bool haveWrittenPreamble, Encoding encoding, Encoder encoder, byte[] byteBuffer, Stream stream, CancellationToken cancellationToken); // 0x00000001815B5C80-0x00000001815B5E10
	}
}
