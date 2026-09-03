/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp
{
	internal class WebSocketFrame : IEnumerable<byte> // TypeDefIndex: 13253
	{
		// Fields
		private byte[] _extPayloadLength; // 0x10
		private Fin _fin; // 0x18
		private Mask _mask; // 0x19
		private byte[] _maskingKey; // 0x20
		private Opcode _opcode; // 0x28
		private PayloadData _payloadData; // 0x30
		private byte _payloadLength; // 0x38
		private Rsv _rsv1; // 0x39
		private Rsv _rsv2; // 0x3A
		private Rsv _rsv3; // 0x3B
	
		// Properties
		internal ulong ExactPayloadLength { get; } // 0x0000000182602D00-0x0000000182602D90 
		internal int ExtendedPayloadLengthWidth { get; } // 0x0000000182602D90-0x0000000182602DB0 
		public byte[] ExtendedPayloadLength { get; } // 0x00000001825D8700-0x00000001825D8710 
		public Fin Fin { get; } // 0x00000001825EF930-0x00000001825EF940 
		public bool IsBinary { get; } // 0x0000000182602DB0-0x0000000182602DC0 
		public bool IsClose { get; } // 0x0000000182602DC0-0x0000000182602DD0 
		public bool IsCompressed { get; } // 0x0000000182602DD0-0x0000000182602DE0 
		public bool IsContinuation { get; } // 0x0000000182602DE0-0x0000000182602DF0 
		public bool IsControl { get; } // 0x0000000182602DF0-0x0000000182602E00 
		public bool IsData { get; } // 0x0000000182602E00-0x0000000182602E20 
		public bool IsFinal { get; } // 0x0000000182602E20-0x0000000182602E30 
		public bool IsFragment { get; } // 0x0000000182602E30-0x0000000182602E50 
		public bool IsMasked { get; } // 0x00000001825DDB70-0x00000001825DDB80 
		public bool IsPing { get; } // 0x0000000182602E50-0x0000000182602E60 
		public bool IsPong { get; } // 0x0000000182602E60-0x0000000182602E70 
		public bool IsText { get; } // 0x0000000182602E70-0x0000000182602E80 
		public ulong Length { get; } // 0x0000000182602E80-0x0000000182602ED0 
		public Mask Mask { get; } // 0x00000001825DDB80-0x00000001825DDB90 
		public byte[] MaskingKey { get; } // 0x00000001825DE400-0x00000001825DE410 
		public Opcode Opcode { get; } // 0x0000000182602ED0-0x0000000182602EE0 
		public PayloadData PayloadData { get; } // 0x00000001825F1D40-0x00000001825F1D50 
		public byte PayloadLength { get; } // 0x00000001825F1D50-0x00000001825F1D60 
		public Rsv Rsv1 { get; } // 0x0000000182602EE0-0x0000000182602EF0 
		public Rsv Rsv2 { get; } // 0x0000000182602EF0-0x0000000182602F00 
		public Rsv Rsv3 { get; } // 0x0000000182602F00-0x0000000182602F10 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass65_0 // TypeDefIndex: 13254
		{
			// Fields
			public StringBuilder buff; // 0x10
			public string lineFmt; // 0x18
	
			// Constructors
			public __c__DisplayClass65_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Action<string, string, string, string> _dump_b__0(); // 0x0000000182600710-0x00000001826007C0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass65_1 // TypeDefIndex: 13255
		{
			// Fields
			public long lineCnt; // 0x10
			public __c__DisplayClass65_0 CS___8__locals1; // 0x18
	
			// Constructors
			public __c__DisplayClass65_1(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _dump_b__1(string arg1, string arg2, string arg3, string arg4); // 0x00000001826007C0-0x0000000182600A00
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass69_0 // TypeDefIndex: 13256
		{
			// Fields
			public int len; // 0x10
			public WebSocketFrame frame; // 0x18
			public Action<WebSocketFrame> completed; // 0x20
	
			// Constructors
			public __c__DisplayClass69_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _readExtendedPayloadLengthAsync_b__0(byte[] bytes); // 0x0000000182600A00-0x0000000182600AB0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass71_0 // TypeDefIndex: 13257
		{
			// Fields
			public Action<WebSocketFrame> completed; // 0x10
	
			// Constructors
			public __c__DisplayClass71_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _readHeaderAsync_b__0(byte[] bytes); // 0x0000000182600AB0-0x0000000182600AF0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass73_0 // TypeDefIndex: 13258
		{
			// Fields
			public int len; // 0x10
			public WebSocketFrame frame; // 0x18
			public Action<WebSocketFrame> completed; // 0x20
	
			// Constructors
			public __c__DisplayClass73_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _readMaskingKeyAsync_b__0(byte[] bytes); // 0x0000000182600AF0-0x0000000182600BA0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass75_0 // TypeDefIndex: 13259
		{
			// Fields
			public long len; // 0x10
			public WebSocketFrame frame; // 0x18
			public Action<WebSocketFrame> completed; // 0x20
	
			// Constructors
			public __c__DisplayClass75_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _readPayloadDataAsync_b__0(byte[] bytes); // 0x0000000182600BA0-0x0000000182600CB0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass82_0 // TypeDefIndex: 13260
		{
			// Fields
			public Stream stream; // 0x10
			public bool unmask; // 0x18
			public Action<WebSocketFrame> completed; // 0x20
			public Action<Exception> error; // 0x28
			public Action<WebSocketFrame> __9__3; // 0x30
			public Action<WebSocketFrame> __9__2; // 0x38
			public Action<WebSocketFrame> __9__1; // 0x40
	
			// Constructors
			public __c__DisplayClass82_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _ReadFrameAsync_b__0(WebSocketFrame frame); // 0x0000000182600CB0-0x0000000182600ED0
			internal void _ReadFrameAsync_b__1(WebSocketFrame frame1); // 0x0000000182600ED0-0x00000001826010E0
			internal void _ReadFrameAsync_b__2(WebSocketFrame frame2); // 0x00000001826010E0-0x00000001826011A0
			internal void _ReadFrameAsync_b__3(WebSocketFrame frame3); // 0x00000001826011A0-0x00000001826011F0
		}
	
		[CompilerGenerated]
		private sealed class _GetEnumerator_d__84 : IEnumerator<byte> // TypeDefIndex: 13261
		{
			// Fields
			private int __1__state; // 0x10
			private byte __2__current; // 0x14
			public WebSocketFrame __4__this; // 0x18
			private byte[] __s__1; // 0x20
			private int __s__2; // 0x28
			private byte _b_5__3; // 0x2C
	
			// Properties
			byte IEnumerator<System.Byte>.Current { [DebuggerHidden] get; } // 0x0000000181102980-0x0000000181102990 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001826004E0-0x0000000182600510 
	
			// Constructors
			[DebuggerHidden]
			public _GetEnumerator_d__84(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x0000000182600510-0x00000001826005D0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001826005D0-0x0000000182600610
		}
	
		// Constructors
		private WebSocketFrame(); // 0x00000001802E5CB0-0x00000001802E5CC0
		internal WebSocketFrame(Opcode opcode, PayloadData payloadData, bool mask); // 0x0000000182602530-0x0000000182602560
		internal WebSocketFrame(Fin fin, Opcode opcode, byte[] data, bool compressed, bool mask); // 0x0000000182602480-0x0000000182602530
		internal WebSocketFrame(Fin fin, Opcode opcode, PayloadData payloadData, bool compressed, bool mask); // 0x0000000182602240-0x0000000182602480
	
		// Methods
		private static byte[] createMaskingKey(); // 0x0000000182602560-0x0000000182602600
		private static string dump(WebSocketFrame frame); // 0x0000000182602600-0x0000000182602D00
		private static string print(WebSocketFrame frame); // 0x0000000182602F10-0x0000000182603490
		private static WebSocketFrame processHeader(byte[] header); // 0x0000000182603490-0x00000001826037F0
		private static WebSocketFrame readExtendedPayloadLength(Stream stream, WebSocketFrame frame); // 0x00000001826039B0-0x0000000182603AE0
		private static void readExtendedPayloadLengthAsync(Stream stream, WebSocketFrame frame, Action<WebSocketFrame> completed, Action<Exception> error); // 0x00000001826037F0-0x00000001826039B0
		private static WebSocketFrame readHeader(Stream stream); // 0x0000000182603BE0-0x0000000182603C40
		private static void readHeaderAsync(Stream stream, Action<WebSocketFrame> completed, Action<Exception> error); // 0x0000000182603AE0-0x0000000182603BE0
		private static WebSocketFrame readMaskingKey(Stream stream, WebSocketFrame frame); // 0x0000000182603DE0-0x0000000182603F00
		private static void readMaskingKeyAsync(Stream stream, WebSocketFrame frame, Action<WebSocketFrame> completed, Action<Exception> error); // 0x0000000182603C40-0x0000000182603DE0
		private static WebSocketFrame readPayloadData(Stream stream, WebSocketFrame frame); // 0x0000000182604160-0x0000000182604340
		private static void readPayloadDataAsync(Stream stream, WebSocketFrame frame, Action<WebSocketFrame> completed, Action<Exception> error); // 0x0000000182603F00-0x0000000182604160
		private static string utf8Decode(byte[] bytes); // 0x0000000182604340-0x0000000182604400
		internal static WebSocketFrame CreateCloseFrame(PayloadData payloadData, bool mask); // 0x0000000182601710-0x0000000182601790
		internal static WebSocketFrame CreatePingFrame(bool mask); // 0x0000000182601790-0x0000000182601840
		internal static WebSocketFrame CreatePingFrame(byte[] data, bool mask); // 0x0000000182601840-0x00000001826018E0
		internal static WebSocketFrame CreatePongFrame(PayloadData payloadData, bool mask); // 0x00000001826018E0-0x0000000182601960
		internal static WebSocketFrame ReadFrame(Stream stream, bool unmask); // 0x0000000182601C20-0x0000000182601EB0
		internal static void ReadFrameAsync(Stream stream, bool unmask, Action<WebSocketFrame> completed, Action<Exception> error); // 0x0000000182601A60-0x0000000182601C20
		internal void Unmask(); // 0x00000001826021B0-0x0000000182602240
		public IEnumerator<byte> GetEnumerator(); // 0x0000000182601960-0x00000001826019D0
		public void Print(bool dumped); // 0x00000001826019F0-0x0000000182601A60
		public string PrintToString(bool dumped); // 0x00000001826019D0-0x00000001826019F0
		public byte[] ToArray(); // 0x0000000182601EB0-0x0000000182602190
		public override string ToString(); // 0x0000000182602190-0x00000001826021B0
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000182601960-0x00000001826019D0
	}
}
