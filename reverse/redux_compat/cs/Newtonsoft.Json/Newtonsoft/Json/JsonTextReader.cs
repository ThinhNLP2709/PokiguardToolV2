/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Utilities;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json
{
	[Nullable(0)]
	[NullableContext(1)]
	public class JsonTextReader : JsonReader, IJsonLineInfo // TypeDefIndex: 9997
	{
		// Fields
		private readonly bool _safeAsync; // 0x78
		private const char UnicodeReplacementChar = '\xfffd'; // Metadata: 0x006A062A
		private const int MaximumJavascriptIntegerCharacterLength = 380; // Metadata: 0x006A062C
		private const int LargeBufferLength = 1073741823; // Metadata: 0x006A062E
		private readonly TextReader _reader; // 0x80
		[Nullable(2)]
		private char[] _chars; // 0x88
		private int _charsUsed; // 0x90
		private int _charPos; // 0x94
		private int _lineStartPos; // 0x98
		private int _lineNumber; // 0x9C
		private bool _isEndOfFile; // 0xA0
		private StringBuffer _stringBuffer; // 0xA8
		private StringReference _stringReference; // 0xB8
		[Nullable(2)]
		private IArrayPool<char> _arrayPool; // 0xC8
		[CompilerGenerated]
		[Nullable(2)]
		private JsonNameTable _PropertyNameTable_k__BackingField; // 0xD0
	
		// Properties
		[Nullable(2)]
		public JsonNameTable PropertyNameTable { [NullableContext(2)] [CompilerGenerated] get; [NullableContext(2)] [CompilerGenerated] set; } // 0x00000001806CCB60-0x00000001806CCB70 0x00000001806CCD80-0x00000001806CCDA0
		[Nullable(2)]
		public IArrayPool<char> ArrayPool { [NullableContext(2)] get; [NullableContext(2)] set; } // 0x00000001806CCB50-0x00000001806CCB60 0x00000001816B3ED0-0x00000001816B3F50
		public int LineNumber { get; } // 0x00000001816B3E70-0x00000001816B3EC0 
		public int LinePosition { get; } // 0x00000001816B3EC0-0x00000001816B3ED0 
	
		// Nested types
		[CompilerGenerated]
		private struct _DoReadAsBooleanAsync_d__40 : IAsyncStateMachine // TypeDefIndex: 9998
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<bool?> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x30
			private BigInteger _i_5__2; // 0x40
			private bool _isTrue_5__3; // 0x50
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x58
	
			// Methods
			private void MoveNext(); // 0x00000001816BD5F0-0x00000001816BE500
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816BE500-0x00000001816BE560
		}
	
		[CompilerGenerated]
		private struct _DoReadAsBytesAsync_d__42 : IAsyncStateMachine // TypeDefIndex: 9999
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<byte[]> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			private bool _isWrapped_5__2; // 0x30
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x38
			[Nullable(0)]
			private byte[] _data_5__3; // 0x48
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x50
			[Nullable(new byte[2] {0, 2 })]
			private ConfiguredTaskAwaitable<byte[]> __u__3; // 0x60
	
			// Methods
			private void MoveNext(); // 0x00000001816BE560-0x00000001816BF3F0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816BF3F0-0x00000001816BF450
		}
	
		[CompilerGenerated]
		private struct _DoReadAsDateTimeAsync_d__45 : IAsyncStateMachine // TypeDefIndex: 10000
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<DateTime?> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(new byte[2] {0, 2 })]
			private ConfiguredTaskAwaitable<object> __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001816BF450-0x00000001816BF660
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816BF660-0x00000001816BF6C0
		}
	
		[CompilerGenerated]
		private struct _DoReadAsDateTimeOffsetAsync_d__47 : IAsyncStateMachine // TypeDefIndex: 10001
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<DateTimeOffset?> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(new byte[2] {0, 2 })]
			private ConfiguredTaskAwaitable<object> __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001816BF6C0-0x00000001816BF8F0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816BF8F0-0x00000001816BF950
		}
	
		[CompilerGenerated]
		private struct _DoReadAsDecimalAsync_d__49 : IAsyncStateMachine // TypeDefIndex: 10002
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<decimal?> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(new byte[2] {0, 2 })]
			private ConfiguredTaskAwaitable<object> __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001816BF950-0x00000001816BFB80
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816BFB80-0x00000001816BFBE0
		}
	
		[CompilerGenerated]
		private struct _DoReadAsDoubleAsync_d__51 : IAsyncStateMachine // TypeDefIndex: 10003
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<double?> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(new byte[2] {0, 2 })]
			private ConfiguredTaskAwaitable<object> __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001816BFBE0-0x00000001816BFDF0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816BFDF0-0x00000001816BFE50
		}
	
		[CompilerGenerated]
		private struct _DoReadAsInt32Async_d__53 : IAsyncStateMachine // TypeDefIndex: 10004
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<int?> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(new byte[2] {0, 2 })]
			private ConfiguredTaskAwaitable<object> __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001816BFE50-0x00000001816C0050
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C0050-0x00000001816C00B0
		}
	
		[CompilerGenerated]
		private struct _DoReadAsStringAsync_d__55 : IAsyncStateMachine // TypeDefIndex: 10005
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<string> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(new byte[2] {0, 2 })]
			private ConfiguredTaskAwaitable<object> __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001816C00B0-0x00000001816C0290
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C0290-0x00000001816C02F0
		}
	
		[CompilerGenerated]
		private struct _DoReadAsync_d__3 : IAsyncStateMachine // TypeDefIndex: 10006
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<bool> __t__builder; // 0x08
			[Nullable(0)]
			public Task<bool> task; // 0x20
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x28
			public CancellationToken cancellationToken; // 0x30
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816C02F0-0x00000001816C0580
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C0580-0x00000001816C05E0
		}
	
		[CompilerGenerated]
		private struct _EatWhitespaceAsync_d__17 : IAsyncStateMachine // TypeDefIndex: 10007
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			private ConfiguredTaskAwaitable<int> __u__1; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816C05E0-0x00000001816C0970
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C0970-0x00000001816C09D0
		}
	
		[CompilerGenerated]
		private struct _HandleNullAsync_d__35 : IAsyncStateMachine // TypeDefIndex: 10008
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816C09D0-0x00000001816C0D80
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C0D80-0x00000001816C0DE0
		}
	
		[CompilerGenerated]
		private struct _MatchAndSetAsync_d__21 : IAsyncStateMachine // TypeDefIndex: 10009
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			[Nullable(0)]
			public string value; // 0x28
			public CancellationToken cancellationToken; // 0x30
			public JsonToken newToken; // 0x38
			[Nullable(0)]
			public object tokenValue; // 0x40
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x48
	
			// Methods
			private void MoveNext(); // 0x00000001816C0DE0-0x00000001816C1050
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C1050-0x00000001816C10B0
		}
	
		[CompilerGenerated]
		private struct _MatchValueAsync_d__19 : IAsyncStateMachine // TypeDefIndex: 10010
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<bool> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			[Nullable(0)]
			public string value; // 0x28
			public CancellationToken cancellationToken; // 0x30
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816C10B0-0x00000001816C12C0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C12C0-0x00000001816C1320
		}
	
		[CompilerGenerated]
		private struct _MatchValueWithTrailingSeparatorAsync_d__20 : IAsyncStateMachine // TypeDefIndex: 10011
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<bool> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			[Nullable(0)]
			public string value; // 0x28
			public CancellationToken cancellationToken; // 0x30
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816C1320-0x00000001816C1670
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C1670-0x00000001816C16D0
		}
	
		[CompilerGenerated]
		private struct _ParseCommentAsync_d__16 : IAsyncStateMachine // TypeDefIndex: 10012
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			public bool setToken; // 0x30
			private bool _singlelineComment_5__2; // 0x31
			private int _initialPosition_5__3; // 0x34
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x38
			[Nullable(0)]
			private ConfiguredTaskAwaitable<int> __u__2; // 0x48
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__3; // 0x58
	
			// Methods
			private void MoveNext(); // 0x00000001816C16D0-0x00000001816C1ED0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C1ED0-0x00000001816C1F30
		}
	
		[CompilerGenerated]
		private struct _ParseConstructorAsync_d__25 : IAsyncStateMachine // TypeDefIndex: 10013
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x30
			private int _initialPosition_5__2; // 0x40
			private int _endPosition_5__3; // 0x44
			[Nullable(0)]
			private string _constructorName_5__4; // 0x48
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x50
			[Nullable(0)]
			private ConfiguredTaskAwaitable<int> __u__3; // 0x60
	
			// Methods
			private void MoveNext(); // 0x00000001816C1F30-0x00000001816C2860
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C2860-0x00000001816C28C0
		}
	
		[CompilerGenerated]
		private struct _ParseNumberAsync_d__29 : IAsyncStateMachine // TypeDefIndex: 10014
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			public ReadType readType; // 0x30
			private char _firstChar_5__2; // 0x34
			private int _initialPosition_5__3; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816C28C0-0x00000001816C2AE0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C2AE0-0x00000001816C2B40
		}
	
		[CompilerGenerated]
		private struct _ParseNumberNaNAsync_d__26 : IAsyncStateMachine // TypeDefIndex: 10015
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<object> __t__builder; // 0x08
			public ReadType readType; // 0x20
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x28
			public CancellationToken cancellationToken; // 0x30
			private ReadType __7__wrap1; // 0x38
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816C2B40-0x00000001816C2D60
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C2D60-0x00000001816C2DC0
		}
	
		[CompilerGenerated]
		private struct _ParseNumberNegativeInfinityAsync_d__28 : IAsyncStateMachine // TypeDefIndex: 10016
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<object> __t__builder; // 0x08
			public ReadType readType; // 0x20
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x28
			public CancellationToken cancellationToken; // 0x30
			private ReadType __7__wrap1; // 0x38
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816C2DC0-0x00000001816C2FE0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C2FE0-0x00000001816C3040
		}
	
		[CompilerGenerated]
		private struct _ParseNumberPositiveInfinityAsync_d__27 : IAsyncStateMachine // TypeDefIndex: 10017
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<object> __t__builder; // 0x08
			public ReadType readType; // 0x20
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x28
			public CancellationToken cancellationToken; // 0x30
			private ReadType __7__wrap1; // 0x38
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816C3040-0x00000001816C3260
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C3260-0x00000001816C32C0
		}
	
		[CompilerGenerated]
		private struct _ParseObjectAsync_d__15 : IAsyncStateMachine // TypeDefIndex: 10018
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<bool> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			private ConfiguredTaskAwaitable<int> __u__1; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x40
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__3; // 0x50
	
			// Methods
			private void MoveNext(); // 0x00000001816C32C0-0x00000001816C3880
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C3880-0x00000001816C38E0
		}
	
		[CompilerGenerated]
		private struct _ParsePostValueAsync_d__4 : IAsyncStateMachine // TypeDefIndex: 10019
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<bool> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			public bool ignoreComments; // 0x30
			[Nullable(0)]
			private ConfiguredTaskAwaitable<int> __u__1; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x48
	
			// Methods
			private void MoveNext(); // 0x00000001816C38E0-0x00000001816C3F30
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C3F30-0x00000001816C3F90
		}
	
		[CompilerGenerated]
		private struct _ParsePropertyAsync_d__31 : IAsyncStateMachine // TypeDefIndex: 10020
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<bool> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			private char _quoteChar_5__2; // 0x30
			[Nullable(0)]
			private string _propertyName_5__3; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816C3F90-0x00000001816C4630
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C4630-0x00000001816C4690
		}
	
		[CompilerGenerated]
		private struct _ParseStringAsync_d__18 : IAsyncStateMachine // TypeDefIndex: 10021
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			public CancellationToken cancellationToken; // 0x20
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x28
			public char quote; // 0x30
			public ReadType readType; // 0x34
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816C4690-0x00000001816C4890
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C4890-0x00000001816C48F0
		}
	
		[CompilerGenerated]
		private struct _ParseUnicodeAsync_d__12 : IAsyncStateMachine // TypeDefIndex: 10022
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<char> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001816C48F0-0x00000001816C4AF0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C4AF0-0x00000001816C4B50
		}
	
		[CompilerGenerated]
		private struct _ParseUnquotedPropertyAsync_d__33 : IAsyncStateMachine // TypeDefIndex: 10023
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			private int _initialPosition_5__2; // 0x30
			[Nullable(0)]
			private ConfiguredTaskAwaitable<int> __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816C4B50-0x00000001816C4E20
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C4E20-0x00000001816C4E80
		}
	
		[CompilerGenerated]
		private struct _ParseValueAsync_d__8 : IAsyncStateMachine // TypeDefIndex: 10024
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<bool> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			private ConfiguredTaskAwaitable<int> __u__1; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x40
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__3; // 0x50
			[Nullable(new byte[2] {0, 1 })]
			private ConfiguredTaskAwaitable<object> __u__4; // 0x60
	
			// Methods
			private void MoveNext(); // 0x00000001816C4E80-0x00000001816C61B0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C61B0-0x00000001816C6210
		}
	
		[CompilerGenerated]
		private struct _ProcessCarriageReturnAsync_d__11 : IAsyncStateMachine // TypeDefIndex: 10025
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Task<bool> task; // 0x20
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x28
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001816C6210-0x00000001816C63B0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C63B0-0x00000001816C6410
		}
	
		[CompilerGenerated]
		private struct _ReadCharsAsync_d__14 : IAsyncStateMachine // TypeDefIndex: 10026
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<bool> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public int relativePosition; // 0x28
			public bool append; // 0x2C
			public CancellationToken cancellationToken; // 0x30
			private int _charsRequired_5__2; // 0x38
			[Nullable(0)]
			private ConfiguredTaskAwaitable<int> __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816C6410-0x00000001816C6650
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C6650-0x00000001816C66B0
		}
	
		[CompilerGenerated]
		private struct _ReadDataAsync_d__7 : IAsyncStateMachine // TypeDefIndex: 10027
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<int> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public bool append; // 0x28
			public int charsRequired; // 0x2C
			public CancellationToken cancellationToken; // 0x30
			[Nullable(0)]
			private ConfiguredTaskAwaitable<int> __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816C66B0-0x00000001816C6980
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C6980-0x00000001816C69E0
		}
	
		[CompilerGenerated]
		private struct _ReadFinishedAsync_d__36 : IAsyncStateMachine // TypeDefIndex: 10028
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816C69E0-0x00000001816C6EA0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C6EA0-0x00000001816C6F00
		}
	
		[CompilerGenerated]
		private struct _ReadFromFinishedAsync_d__5 : IAsyncStateMachine // TypeDefIndex: 10029
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<bool> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816C6F00-0x00000001816C73E0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C73E0-0x00000001816C7440
		}
	
		[CompilerGenerated]
		private struct _ReadIntoWrappedTypeObjectAsync_d__43 : IAsyncStateMachine // TypeDefIndex: 10030
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001816C7440-0x00000001816C79C0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C79C0-0x00000001816C7A20
		}
	
		[CompilerGenerated]
		private struct _ReadNullCharAsync_d__34 : IAsyncStateMachine // TypeDefIndex: 10031
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<bool> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			private ConfiguredTaskAwaitable<int> __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001816C7A20-0x00000001816C7C20
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C7C20-0x00000001816C7C80
		}
	
		[CompilerGenerated]
		private struct _ReadNumberIntoBufferAsync_d__32 : IAsyncStateMachine // TypeDefIndex: 10032
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			private int _charPos_5__2; // 0x30
			[Nullable(0)]
			private ConfiguredTaskAwaitable<int> __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816C7C80-0x00000001816C7EE0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C7EE0-0x00000001816C7F40
		}
	
		[CompilerGenerated]
		private struct _ReadNumberValueAsync_d__38 : IAsyncStateMachine // TypeDefIndex: 10033
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<object> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			public ReadType readType; // 0x30
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x48
			[Nullable(new byte[2] {0, 1 })]
			private ConfiguredTaskAwaitable<object> __u__3; // 0x58
	
			// Methods
			private void MoveNext(); // 0x00000001816C7F40-0x00000001816C8FB0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C8FB0-0x00000001816C9010
		}
	
		[CompilerGenerated]
		private struct _ReadStringIntoBufferAsync_d__9 : IAsyncStateMachine // TypeDefIndex: 10034
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			public char quote; // 0x30
			private int _charPos_5__2; // 0x34
			private int _initialPosition_5__3; // 0x38
			private int _lastWritePosition_5__4; // 0x3C
			private int _escapeStartPos_5__5; // 0x40
			private char _writeChar_5__6; // 0x44
			[Nullable(0)]
			private ConfiguredTaskAwaitable<int> __u__1; // 0x48
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__2; // 0x58
			[Nullable(0)]
			private ConfiguredTaskAwaitable<char> __u__3; // 0x68
			private bool _anotherHighSurrogate_5__7; // 0x78
			private char _highSurrogate_5__8; // 0x7A
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__4; // 0x80
	
			// Methods
			private void MoveNext(); // 0x00000001816C9010-0x00000001816C9CE0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816C9CE0-0x00000001816C9D40
		}
	
		[CompilerGenerated]
		private struct _ReadStringValueAsync_d__37 : IAsyncStateMachine // TypeDefIndex: 10035
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<object> __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			public ReadType readType; // 0x30
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x38
			[Nullable(0)]
			private string _expected_5__2; // 0x48
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x50
			[Nullable(new byte[2] {0, 1 })]
			private ConfiguredTaskAwaitable<object> __u__3; // 0x60
	
			// Methods
			private void MoveNext(); // 0x00000001816C9D40-0x00000001816CAFB0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816CAFB0-0x00000001816CB010
		}
	
		// Constructors
		public JsonTextReader(TextReader reader); // 0x00000001816B3D70-0x00000001816B3E70
	
		// Methods
		public override Task<bool> ReadAsync(CancellationToken cancellationToken = default); // 0x00000001816B0790-0x00000001816B0840
		internal Task<bool> DoReadAsync(CancellationToken cancellationToken); // 0x00000001816A6F60-0x00000001816A7590
		private async Task<bool> DoReadAsync(Task<bool> task, CancellationToken cancellationToken); // 0x00000001816A7590-0x00000001816A76B0
		private async Task<bool> ParsePostValueAsync(bool ignoreComments, CancellationToken cancellationToken); // 0x00000001816AACB0-0x00000001816AADD0
		private async Task<bool> ReadFromFinishedAsync(CancellationToken cancellationToken); // 0x00000001816B1000-0x00000001816B1100
		private Task<int> ReadDataAsync(bool append, CancellationToken cancellationToken); // 0x00000001816B0BC0-0x00000001816B0CE0
		private async Task<int> ReadDataAsync(bool append, int charsRequired, CancellationToken cancellationToken); // 0x00000001816B0AA0-0x00000001816B0BC0
		private async Task<bool> ParseValueAsync(CancellationToken cancellationToken); // 0x00000001816AD300-0x00000001816AD410
		private async Task ReadStringIntoBufferAsync(char quote, CancellationToken cancellationToken); // 0x00000001816B22C0-0x00000001816B23E0
		private Task ProcessCarriageReturnAsync(bool append, CancellationToken cancellationToken); // 0x00000001816ADE60-0x00000001816AE160
		private async Task ProcessCarriageReturnAsync(Task<bool> task); // 0x00000001816ADD70-0x00000001816ADE60
		private async Task<char> ParseUnicodeAsync(CancellationToken cancellationToken); // 0x00000001816ACD60-0x00000001816ACE60
		private Task<bool> EnsureCharsAsync(int relativePosition, bool append, CancellationToken cancellationToken); // 0x00000001816A7A20-0x00000001816A7BE0
		private async Task<bool> ReadCharsAsync(int relativePosition, bool append, CancellationToken cancellationToken); // 0x00000001816B0840-0x00000001816B0960
		private async Task<bool> ParseObjectAsync(CancellationToken cancellationToken); // 0x00000001816AA9A0-0x00000001816AAAB0
		private async Task ParseCommentAsync(bool setToken, CancellationToken cancellationToken); // 0x00000001816A8D30-0x00000001816A8E40
		private async Task EatWhitespaceAsync(CancellationToken cancellationToken); // 0x00000001816A76B0-0x00000001816A77A0
		private async Task ParseStringAsync(char quote, ReadType readType, CancellationToken cancellationToken); // 0x00000001816AC910-0x00000001816ACA20
		private async Task<bool> MatchValueAsync(string value, CancellationToken cancellationToken); // 0x00000001816A86E0-0x00000001816A8800
		private async Task<bool> MatchValueWithTrailingSeparatorAsync(string value, CancellationToken cancellationToken); // 0x00000001816A8800-0x00000001816A8920
		private async Task MatchAndSetAsync(string value, JsonToken newToken, [Nullable(2)] object tokenValue, CancellationToken cancellationToken); // 0x00000001816A85A0-0x00000001816A86E0
		private Task ParseTrueAsync(CancellationToken cancellationToken); // 0x00000001816ACA80-0x00000001816ACB30
		private Task ParseFalseAsync(CancellationToken cancellationToken); // 0x00000001816A96F0-0x00000001816A97A0
		private Task ParseNullAsync(CancellationToken cancellationToken); // 0x00000001816A9890-0x00000001816A9910
		private async Task ParseConstructorAsync(CancellationToken cancellationToken); // 0x00000001816A9210-0x00000001816A9310
		private async Task<object> ParseNumberNaNAsync(ReadType readType, CancellationToken cancellationToken); // 0x00000001816A9AD0-0x00000001816A9BE0
		private async Task<object> ParseNumberPositiveInfinityAsync(ReadType readType, CancellationToken cancellationToken); // 0x00000001816AA450-0x00000001816AA560
		private async Task<object> ParseNumberNegativeInfinityAsync(ReadType readType, CancellationToken cancellationToken); // 0x00000001816A9F90-0x00000001816AA0A0
		private async Task ParseNumberAsync(ReadType readType, CancellationToken cancellationToken); // 0x00000001816A99D0-0x00000001816A9AD0
		private Task ParseUndefinedAsync(CancellationToken cancellationToken); // 0x00000001816ACC20-0x00000001816ACCA0
		private async Task<bool> ParsePropertyAsync(CancellationToken cancellationToken); // 0x00000001816AB0F0-0x00000001816AB1F0
		private async Task ReadNumberIntoBufferAsync(CancellationToken cancellationToken); // 0x00000001816B14C0-0x00000001816B15B0
		private async Task ParseUnquotedPropertyAsync(CancellationToken cancellationToken); // 0x00000001816AD010-0x00000001816AD100
		private async Task<bool> ReadNullCharAsync(CancellationToken cancellationToken); // 0x00000001816B11E0-0x00000001816B12E0
		private async Task HandleNullAsync(CancellationToken cancellationToken); // 0x00000001816A8270-0x00000001816A8360
		private async Task ReadFinishedAsync(CancellationToken cancellationToken); // 0x00000001816B0DC0-0x00000001816B0EB0
		private async Task<object> ReadStringValueAsync(ReadType readType, CancellationToken cancellationToken); // 0x00000001816B2B00-0x00000001816B2C20
		private async Task<object> ReadNumberValueAsync(ReadType readType, CancellationToken cancellationToken); // 0x00000001816B17A0-0x00000001816B18C0
		public override Task<bool?> ReadAsBooleanAsync(CancellationToken cancellationToken = default); // 0x00000001816AE270-0x00000001816AE450
		internal async Task<bool?> DoReadAsBooleanAsync(CancellationToken cancellationToken); // 0x00000001816A6740-0x00000001816A6850
		public override Task<byte[]> ReadAsBytesAsync(CancellationToken cancellationToken = default); // 0x00000001816AEE50-0x00000001816AF020
		internal async Task<byte[]> DoReadAsBytesAsync(CancellationToken cancellationToken); // 0x00000001816A6850-0x00000001816A6960
		private async Task ReadIntoWrappedTypeObjectAsync(CancellationToken cancellationToken); // 0x00000001816B1100-0x00000001816B11E0
		public override Task<DateTime?> ReadAsDateTimeAsync(CancellationToken cancellationToken = default); // 0x00000001816AF920-0x00000001816AFB00
		internal async Task<DateTime?> DoReadAsDateTimeAsync(CancellationToken cancellationToken); // 0x00000001816A6960-0x00000001816A6A60
		public override Task<DateTimeOffset?> ReadAsDateTimeOffsetAsync(CancellationToken cancellationToken = default); // 0x00000001816AFB00-0x00000001816AFD00
		internal async Task<DateTimeOffset?> DoReadAsDateTimeOffsetAsync(CancellationToken cancellationToken); // 0x00000001816A6A60-0x00000001816A6B60
		public override Task<decimal?> ReadAsDecimalAsync(CancellationToken cancellationToken = default); // 0x00000001816AFE50-0x00000001816B0050
		internal async Task<decimal?> DoReadAsDecimalAsync(CancellationToken cancellationToken); // 0x00000001816A6B60-0x00000001816A6C60
		public override Task<double?> ReadAsDoubleAsync(CancellationToken cancellationToken = default); // 0x00000001816B0100-0x00000001816B02A0
		internal async Task<double?> DoReadAsDoubleAsync(CancellationToken cancellationToken); // 0x00000001816A6C60-0x00000001816A6D60
		public override Task<int?> ReadAsInt32Async(CancellationToken cancellationToken = default); // 0x00000001816B0340-0x00000001816B0500
		internal async Task<int?> DoReadAsInt32Async(CancellationToken cancellationToken); // 0x00000001816A6D60-0x00000001816A6E60
		public override Task<string> ReadAsStringAsync(CancellationToken cancellationToken = default); // 0x00000001816B0590-0x00000001816B0750
		internal async Task<string> DoReadAsStringAsync(CancellationToken cancellationToken); // 0x00000001816A6E60-0x00000001816A6F60
		private void EnsureBufferNotEmpty(); // 0x00000001816A7950-0x00000001816A79B0
		private void SetNewLine(bool hasNextChar); // 0x00000001816B3B10-0x00000001816B3B70
		private void OnNewLine(int pos); // 0x00000001816A8D20-0x00000001816A8D30
		private void ParseString(char quote, ReadType readType); // 0x00000001816ACA20-0x00000001816ACA80
		private void ParseReadString(char quote, ReadType readType); // 0x00000001816AC560-0x00000001816AC910
		private static void BlockCopyChars(char[] src, int srcOffset, char[] dst, int dstOffset, int count); // 0x00000001816A6410-0x00000001816A6430
		private void ShiftBufferIfNeeded(); // 0x00000001816B3B70-0x00000001816B3C50
		private int ReadData(bool append); // 0x00000001816B0CE0-0x00000001816B0CF0
		private void PrepareBufferForReadData(bool append, int charsRequired); // 0x00000001816ADB60-0x00000001816ADD70
		private int ReadData(bool append, int charsRequired); // 0x00000001816B0CF0-0x00000001816B0DC0
		private bool EnsureChars(int relativePosition, bool append); // 0x00000001816A7BE0-0x00000001816A7D30
		private bool ReadChars(int relativePosition, bool append); // 0x00000001816B0960-0x00000001816B0AA0
		public override bool Read(); // 0x00000001816B3800-0x00000001816B3B10
		public override int? ReadAsInt32(); // 0x00000001816B0500-0x00000001816B0590
		public override DateTime? ReadAsDateTime(); // 0x00000001816AFDB0-0x00000001816AFE50
		[NullableContext(2)]
		public override string ReadAsString(); // 0x00000001816B0750-0x00000001816B0790
		[NullableContext(2)]
		public override byte[] ReadAsBytes(); // 0x00000001816AF020-0x00000001816AF920
		[NullableContext(2)]
		private object ReadStringValue(ReadType readType); // 0x00000001816B2C20-0x00000001816B3690
		[NullableContext(2)]
		private object FinishReadQuotedStringValue(ReadType readType); // 0x00000001816A7EA0-0x00000001816A8160
		private JsonReaderException CreateUnexpectedCharacterException(char c); // 0x00000001816A66A0-0x00000001816A6740
		public override bool? ReadAsBoolean(); // 0x00000001816AE450-0x00000001816AEE50
		private void ProcessValueComma(); // 0x00000001816AE1F0-0x00000001816AE270
		[NullableContext(2)]
		private object ReadNumberValue(ReadType readType); // 0x00000001816B18C0-0x00000001816B22C0
		[NullableContext(2)]
		private object FinishReadQuotedNumber(ReadType readType); // 0x00000001816A7D30-0x00000001816A7EA0
		public override DateTimeOffset? ReadAsDateTimeOffset(); // 0x00000001816AFD00-0x00000001816AFDB0
		public override decimal? ReadAsDecimal(); // 0x00000001816B0050-0x00000001816B0100
		public override double? ReadAsDouble(); // 0x00000001816B02A0-0x00000001816B0340
		private void HandleNull(); // 0x00000001816A8360-0x00000001816A8470
		private void ReadFinished(); // 0x00000001816B0EB0-0x00000001816B1000
		private bool ReadNullChar(); // 0x00000001816B12E0-0x00000001816B1330
		private void EnsureBuffer(); // 0x00000001816A79B0-0x00000001816A7A20
		private void ReadStringIntoBuffer(char quote); // 0x00000001816B23E0-0x00000001816B2B00
		private void FinishReadStringIntoBuffer(int charPos, int initialPosition, int lastWritePosition); // 0x00000001816A8160-0x00000001816A8270
		private void WriteCharToBuffer(char writeChar, int lastWritePosition, int writeToPosition); // 0x00000001816B3D00-0x00000001816B3D70
		private char ConvertUnicode(bool enoughChars); // 0x00000001816A6500-0x00000001816A66A0
		private char ParseUnicode(); // 0x00000001816ACE60-0x00000001816AD010
		private void ReadNumberIntoBuffer(); // 0x00000001816B15B0-0x00000001816B17A0
		private bool ReadNumberCharIntoBuffer(char currentChar, int charPos); // 0x00000001816B1330-0x00000001816B14C0
		private void ClearRecentString(); // 0x00000001816A6430-0x00000001816A6450
		private bool ParsePostValue(bool ignoreComments); // 0x00000001816AADD0-0x00000001816AB0F0
		private bool ParseObject(); // 0x00000001816AAAB0-0x00000001816AACB0
		private bool ParseProperty(); // 0x00000001816AB1F0-0x00000001816AB4D0
		private bool ValidIdentifierChar(char value); // 0x00000001816B3CB0-0x00000001816B3D00
		private void ParseUnquotedProperty(); // 0x00000001816AD100-0x00000001816AD300
		private bool ReadUnquotedPropertyReportIfDone(char currentChar, int initialPosition); // 0x00000001816B3690-0x00000001816B3800
		private bool ParseValue(); // 0x00000001816AD410-0x00000001816ADB60
		private void ProcessLineFeed(); // 0x00000001816AE1D0-0x00000001816AE1F0
		private void ProcessCarriageReturn(bool append); // 0x00000001816AE160-0x00000001816AE1D0
		private void EatWhitespace(); // 0x00000001816A77A0-0x00000001816A7900
		private void ParseConstructor(); // 0x00000001816A9310-0x00000001816A96F0
		private void ParseNumber(ReadType readType); // 0x00000001816AA910-0x00000001816AA9A0
		private void ParseReadNumber(ReadType readType, char firstChar, int initialPosition); // 0x00000001816AB4D0-0x00000001816AC560
		private JsonReaderException ThrowReaderError(string message, [Nullable(2)] Exception ex = null); // 0x00000001816B3C50-0x00000001816B3CB0
		private static object BigIntegerParse(string number, CultureInfo culture); // 0x00000001816A6390-0x00000001816A6410
		private void ParseComment(bool setToken); // 0x00000001816A8E40-0x00000001816A9210
		private void EndComment(bool setToken, int initialPosition, int endPosition); // 0x00000001816A7900-0x00000001816A7950
		private bool MatchValue(string value); // 0x00000001816A8C30-0x00000001816A8D20
		private bool MatchValue(bool enoughChars, string value); // 0x00000001816A8B50-0x00000001816A8C30
		private bool MatchValueWithTrailingSeparator(string value); // 0x00000001816A8920-0x00000001816A8B50
		private bool IsSeparator(char c); // 0x00000001816A8470-0x00000001816A85A0
		private void ParseTrue(); // 0x00000001816ACB30-0x00000001816ACC20
		private void ParseNull(); // 0x00000001816A9910-0x00000001816A99D0
		private void ParseUndefined(); // 0x00000001816ACCA0-0x00000001816ACD60
		private void ParseFalse(); // 0x00000001816A97A0-0x00000001816A9890
		private object ParseNumberNegativeInfinity(ReadType readType); // 0x00000001816AA250-0x00000001816AA450
		private object ParseNumberNegativeInfinity(ReadType readType, bool matched); // 0x00000001816AA0A0-0x00000001816AA250
		private object ParseNumberPositiveInfinity(ReadType readType); // 0x00000001816AA710-0x00000001816AA910
		private object ParseNumberPositiveInfinity(ReadType readType, bool matched); // 0x00000001816AA560-0x00000001816AA710
		private object ParseNumberNaN(ReadType readType); // 0x00000001816A9BE0-0x00000001816A9DE0
		private object ParseNumberNaN(ReadType readType, bool matched); // 0x00000001816A9DE0-0x00000001816A9F90
		public override void Close(); // 0x00000001816A6450-0x00000001816A6500
		public bool HasLineInfo(); // 0x00000001802E7990-0x00000001802E79A0
	}
}
