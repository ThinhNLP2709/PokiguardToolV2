/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
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
	public class JsonTextWriter : JsonWriter // TypeDefIndex: 10037
	{
		// Fields
		private readonly bool _safeAsync; // 0x60
		private const int IndentCharBufferSize = 12; // Metadata: 0x006A063D
		private readonly TextWriter _writer; // 0x68
		[Nullable(2)]
		private Base64Encoder _base64Encoder; // 0x70
		private char _indentChar; // 0x78
		private int _indentation; // 0x7C
		private char _quoteChar; // 0x80
		private bool _quoteName; // 0x82
		[Nullable(2)]
		private bool[] _charEscapeFlags; // 0x88
		[Nullable(2)]
		private char[] _writeBuffer; // 0x90
		[Nullable(2)]
		private IArrayPool<char> _arrayPool; // 0x98
		[Nullable(2)]
		private char[] _indentChars; // 0xA0
	
		// Properties
		private Base64Encoder Base64Encoder { get; } // 0x00000001816BD390-0x00000001816BD410 
		[Nullable(2)]
		public IArrayPool<char> ArrayPool { [NullableContext(2)] get; [NullableContext(2)] set; } // 0x00000001806CCBC0-0x00000001806CCBD0 0x00000001816BD440-0x00000001816BD4C0
		public int Indentation { get; set; } // 0x00000001816A5830-0x00000001816A5840 0x00000001816BD4F0-0x00000001816BD560
		public char QuoteChar { get; set; } // 0x00000001816BD420-0x00000001816BD430 0x00000001816BD560-0x00000001816BD5E0
		public char IndentChar { get; set; } // 0x00000001816BD410-0x00000001816BD420 0x00000001816BD4C0-0x00000001816BD4F0
		public bool QuoteName { get; set; } // 0x00000001816BD430-0x00000001816BD440 0x00000001816BD5E0-0x00000001816BD5F0
	
		// Nested types
		[CompilerGenerated]
		private struct _CloseBufferAndWriterAsync_d__9 : IAsyncStateMachine // TypeDefIndex: 10038
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x20
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x28
	
			// Methods
			private void MoveNext(); // 0x00000001816DAFE0-0x00000001816DB210
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DB210-0x00000001816DB270
		}
	
		[CompilerGenerated]
		private struct _DoCloseAsync_d__8 : IAsyncStateMachine // TypeDefIndex: 10039
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001816DB270-0x00000001816DB580
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DB580-0x00000001816DB5E0
		}
	
		[CompilerGenerated]
		private struct _DoWriteCommentAsync_d__115 : IAsyncStateMachine // TypeDefIndex: 10040
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			public string text; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816DB5E0-0x00000001816DBAF0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DBAF0-0x00000001816DBB50
		}
	
		[CompilerGenerated]
		private struct _DoWritePropertyNameAsync_d__30 : IAsyncStateMachine // TypeDefIndex: 10041
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Task task; // 0x20
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x28
			[Nullable(0)]
			public string name; // 0x30
			public CancellationToken cancellationToken; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816DBB50-0x00000001816DBED0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DBED0-0x00000001816DBF30
		}
	
		[CompilerGenerated]
		private struct _DoWritePropertyNameAsync_d__32 : IAsyncStateMachine // TypeDefIndex: 10042
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x20
			[Nullable(0)]
			public string name; // 0x28
			public CancellationToken cancellationToken; // 0x30
			public bool escape; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816DBF30-0x00000001816DC600
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DC600-0x00000001816DC660
		}
	
		[CompilerGenerated]
		private struct _DoWriteRawValueAsync_d__121 : IAsyncStateMachine // TypeDefIndex: 10043
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Task task; // 0x20
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x28
			[Nullable(0)]
			public string json; // 0x30
			public CancellationToken cancellationToken; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816DC660-0x00000001816DC8D0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DC8D0-0x00000001816DC930
		}
	
		[CompilerGenerated]
		private struct _DoWriteStartArrayAsync_d__35 : IAsyncStateMachine // TypeDefIndex: 10044
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Task task; // 0x20
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x28
			public CancellationToken cancellationToken; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816DC930-0x00000001816DCBC0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DCBC0-0x00000001816DCC20
		}
	
		[CompilerGenerated]
		private struct _DoWriteStartConstructorAsync_d__40 : IAsyncStateMachine // TypeDefIndex: 10045
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			public string name; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816DCC20-0x00000001816DD100
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DD100-0x00000001816DD160
		}
	
		[CompilerGenerated]
		private struct _DoWriteStartObjectAsync_d__38 : IAsyncStateMachine // TypeDefIndex: 10046
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Task task; // 0x20
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x28
			public CancellationToken cancellationToken; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816DD160-0x00000001816DD3F0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DD3F0-0x00000001816DD450
		}
	
		[CompilerGenerated]
		private struct _DoWriteUndefinedAsync_d__43 : IAsyncStateMachine // TypeDefIndex: 10047
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Task task; // 0x20
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x28
			public CancellationToken cancellationToken; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816DD450-0x00000001816DD720
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DD720-0x00000001816DD780
		}
	
		[CompilerGenerated]
		private struct _DoWriteValueAsync_d__60 : IAsyncStateMachine // TypeDefIndex: 10048
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			public DateTime value; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816DD780-0x00000001816DDE00
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DDE00-0x00000001816DDE60
		}
	
		[CompilerGenerated]
		private struct _DoWriteValueAsync_d__64 : IAsyncStateMachine // TypeDefIndex: 10049
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			public DateTimeOffset value; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816DDE60-0x00000001816DE4B0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DE4B0-0x00000001816DE510
		}
	
		[CompilerGenerated]
		private struct _DoWriteValueAsync_d__78 : IAsyncStateMachine // TypeDefIndex: 10050
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			public Guid value; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816DE510-0x00000001816DEA10
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DEA10-0x00000001816DEA70
		}
	
		[CompilerGenerated]
		private struct _DoWriteValueAsync_d__97 : IAsyncStateMachine // TypeDefIndex: 10051
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Task task; // 0x20
			[Nullable(0)]
			public string value; // 0x28
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x30
			public CancellationToken cancellationToken; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816DEA70-0x00000001816DED80
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DED80-0x00000001816DEDE0
		}
	
		[CompilerGenerated]
		private struct _DoWriteValueAsync_d__99 : IAsyncStateMachine // TypeDefIndex: 10052
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			public TimeSpan value; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816DEDE0-0x00000001816DF320
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DF320-0x00000001816DF380
		}
	
		[CompilerGenerated]
		private struct _WriteIndentAsync_d__13 : IAsyncStateMachine // TypeDefIndex: 10053
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x20
			public int newLineLen; // 0x28
			public int currentIndentCount; // 0x2C
			public CancellationToken cancellationToken; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816E04A0-0x00000001816E0890
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816E0890-0x00000001816E08F0
		}
	
		[CompilerGenerated]
		private struct _WriteIntegerValueAsync_d__24 : IAsyncStateMachine // TypeDefIndex: 10054
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Task task; // 0x20
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x28
			public ulong uvalue; // 0x30
			public bool negative; // 0x38
			public CancellationToken cancellationToken; // 0x40
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x48
	
			// Methods
			private void MoveNext(); // 0x00000001816E08F0-0x00000001816E0B70
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816E0B70-0x00000001816E0BD0
		}
	
		[CompilerGenerated]
		private struct _WriteValueInternalAsync_d__15 : IAsyncStateMachine // TypeDefIndex: 10055
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Task task; // 0x20
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x28
			[Nullable(0)]
			public string value; // 0x30
			public CancellationToken cancellationToken; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816E0BD0-0x00000001816E0E70
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816E0E70-0x00000001816E0ED0
		}
	
		[CompilerGenerated]
		private struct _WriteValueNonNullAsync_d__54 : IAsyncStateMachine // TypeDefIndex: 10056
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			public byte[] value; // 0x30
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816E0ED0-0x00000001816E1490
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816E1490-0x00000001816E14F0
		}
	
		[CompilerGenerated]
		private struct _WriteValueNotNullAsync_d__110 : IAsyncStateMachine // TypeDefIndex: 10057
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Task task; // 0x20
			[Nullable(0)]
			public JsonTextWriter __4__this; // 0x28
			[Nullable(0)]
			public Uri value; // 0x30
			public CancellationToken cancellationToken; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816E14F0-0x00000001816E1780
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816E1780-0x00000001816E17E0
		}
	
		// Constructors
		public JsonTextWriter(TextWriter textWriter); // 0x00000001816BD290-0x00000001816BD390
	
		// Methods
		public override Task FlushAsync(CancellationToken cancellationToken = default); // 0x00000001816B7900-0x00000001816B79A0
		internal Task DoFlushAsync(CancellationToken cancellationToken); // 0x00000001816B53E0-0x00000001816B5460
		protected override Task WriteValueDelimiterAsync(CancellationToken cancellationToken); // 0x00000001816BB3C0-0x00000001816BB440
		internal Task DoWriteValueDelimiterAsync(CancellationToken cancellationToken); // 0x00000001816B76E0-0x00000001816B7750
		protected override Task WriteEndAsync(JsonToken token, CancellationToken cancellationToken); // 0x00000001816B7E60-0x00000001816B8000
		internal Task DoWriteEndAsync(JsonToken token, CancellationToken cancellationToken); // 0x00000001816B5570-0x00000001816B56B0
		public override Task CloseAsync(CancellationToken cancellationToken = default); // 0x00000001816B5040-0x00000001816B5150
		internal async Task DoCloseAsync(CancellationToken cancellationToken); // 0x00000001816B5300-0x00000001816B53E0
		private async Task CloseBufferAndWriterAsync(); // 0x00000001816B5150-0x00000001816B5210
		public override Task WriteEndAsync(CancellationToken cancellationToken = default); // 0x00000001816B7E40-0x00000001816B7E60
		protected override Task WriteIndentAsync(CancellationToken cancellationToken); // 0x00000001816B8310-0x00000001816B84E0
		internal Task DoWriteIndentAsync(CancellationToken cancellationToken); // 0x00000001816B56B0-0x00000001816B5860
		private async Task WriteIndentAsync(int currentIndentCount, int newLineLen, CancellationToken cancellationToken); // 0x00000001816B84E0-0x00000001816B85F0
		private Task WriteValueInternalAsync(JsonToken token, string value, CancellationToken cancellationToken); // 0x00000001816BB5A0-0x00000001816BB730
		private async Task WriteValueInternalAsync(Task task, string value, CancellationToken cancellationToken); // 0x00000001816BB470-0x00000001816BB5A0
		protected override Task WriteIndentSpaceAsync(CancellationToken cancellationToken); // 0x00000001816B85F0-0x00000001816B8670
		internal Task DoWriteIndentSpaceAsync(CancellationToken cancellationToken); // 0x00000001816B5860-0x00000001816B58D0
		public override Task WriteRawAsync([Nullable(2)] string json, CancellationToken cancellationToken = default); // 0x00000001816B9370-0x00000001816B9400
		internal Task DoWriteRawAsync([Nullable(2)] string json, CancellationToken cancellationToken); // 0x00000001816B5DB0-0x00000001816B5E20
		public override Task WriteNullAsync(CancellationToken cancellationToken = default); // 0x00000001816B8E00-0x00000001816B8E20
		internal Task DoWriteNullAsync(CancellationToken cancellationToken); // 0x00000001816B58D0-0x00000001816B5950
		private Task WriteDigitsAsync(ulong uvalue, bool negative, CancellationToken cancellationToken); // 0x00000001816B7D30-0x00000001816B7E20
		private Task WriteIntegerValueAsync(ulong uvalue, bool negative, CancellationToken cancellationToken); // 0x00000001816B87D0-0x00000001816B8A20
		private async Task WriteIntegerValueAsync(Task task, ulong uvalue, bool negative, CancellationToken cancellationToken); // 0x00000001816B8A60-0x00000001816B8BA0
		internal Task WriteIntegerValueAsync(long value, CancellationToken cancellationToken); // 0x00000001816B8A20-0x00000001816B8A60
		internal Task WriteIntegerValueAsync(ulong uvalue, CancellationToken cancellationToken); // 0x00000001816B8BA0-0x00000001816B8BC0
		private Task WriteEscapedStringAsync(string value, bool quote, CancellationToken cancellationToken); // 0x00000001816B8130-0x00000001816B8210
		public override Task WritePropertyNameAsync(string name, CancellationToken cancellationToken = default); // 0x00000001816B9200-0x00000001816B9220
		internal Task DoWritePropertyNameAsync(string name, CancellationToken cancellationToken); // 0x00000001816B5BA0-0x00000001816B5DB0
		private async Task DoWritePropertyNameAsync(Task task, string name, CancellationToken cancellationToken); // 0x00000001816B5A70-0x00000001816B5BA0
		public override Task WritePropertyNameAsync(string name, bool escape, CancellationToken cancellationToken = default); // 0x00000001816B90C0-0x00000001816B9200
		internal async Task DoWritePropertyNameAsync(string name, bool escape, CancellationToken cancellationToken); // 0x00000001816B5950-0x00000001816B5A70
		public override Task WriteStartArrayAsync(CancellationToken cancellationToken = default); // 0x00000001816B9620-0x00000001816B97F0
		internal Task DoWriteStartArrayAsync(CancellationToken cancellationToken); // 0x00000001816B6100-0x00000001816B6290
		internal async Task DoWriteStartArrayAsync(Task task, CancellationToken cancellationToken); // 0x00000001816B6290-0x00000001816B63A0
		public override Task WriteStartObjectAsync(CancellationToken cancellationToken = default); // 0x00000001816B9A20-0x00000001816B9BF0
		internal Task DoWriteStartObjectAsync(CancellationToken cancellationToken); // 0x00000001816B64B0-0x00000001816B6640
		internal async Task DoWriteStartObjectAsync(Task task, CancellationToken cancellationToken); // 0x00000001816B6640-0x00000001816B6750
		public override Task WriteStartConstructorAsync(string name, CancellationToken cancellationToken = default); // 0x00000001816B9840-0x00000001816B9960
		internal async Task DoWriteStartConstructorAsync(string name, CancellationToken cancellationToken); // 0x00000001816B63A0-0x00000001816B64B0
		public override Task WriteUndefinedAsync(CancellationToken cancellationToken = default); // 0x00000001816B9C40-0x00000001816B9E30
		internal Task DoWriteUndefinedAsync(CancellationToken cancellationToken); // 0x00000001816B6750-0x00000001816B6900
		private async Task DoWriteUndefinedAsync(Task task, CancellationToken cancellationToken); // 0x00000001816B6900-0x00000001816B6A10
		public override Task WriteWhitespaceAsync(string ws, CancellationToken cancellationToken = default); // 0x00000001816BD1A0-0x00000001816BD240
		internal Task DoWriteWhitespaceAsync(string ws, CancellationToken cancellationToken); // 0x00000001816B7750-0x00000001816B77D0
		public override Task WriteValueAsync(bool value, CancellationToken cancellationToken = default); // 0x00000001816BA4E0-0x00000001816BA500
		internal Task DoWriteValueAsync(bool value, CancellationToken cancellationToken); // 0x00000001816B72F0-0x00000001816B7370
		public override Task WriteValueAsync(bool? value, CancellationToken cancellationToken = default); // 0x00000001816BAD20-0x00000001816BAD70
		internal Task DoWriteValueAsync(bool? value, CancellationToken cancellationToken); // 0x00000001816B72C0-0x00000001816B72F0
		public override Task WriteValueAsync(byte value, CancellationToken cancellationToken = default); // 0x00000001816BAFC0-0x00000001816BB000
		public override Task WriteValueAsync(byte? value, CancellationToken cancellationToken = default); // 0x00000001816BACD0-0x00000001816BAD20
		internal Task DoWriteValueAsync(byte? value, CancellationToken cancellationToken); // 0x00000001816B7280-0x00000001816B72C0
		public override Task WriteValueAsync([Nullable(2)] byte[] value, CancellationToken cancellationToken = default); // 0x00000001816BA9A0-0x00000001816BAAE0
		internal async Task WriteValueNonNullAsync(byte[] value, CancellationToken cancellationToken); // 0x00000001816BB760-0x00000001816BB870
		public override Task WriteValueAsync(char value, CancellationToken cancellationToken = default); // 0x00000001816BA5B0-0x00000001816BA5D0
		internal Task DoWriteValueAsync(char value, CancellationToken cancellationToken); // 0x00000001816B7170-0x00000001816B71F0
		public override Task WriteValueAsync(char? value, CancellationToken cancellationToken = default); // 0x00000001816BAF70-0x00000001816BAFC0
		internal Task DoWriteValueAsync(char? value, CancellationToken cancellationToken); // 0x00000001816B6D10-0x00000001816B6D40
		public override Task WriteValueAsync(DateTime value, CancellationToken cancellationToken = default); // 0x00000001816BA950-0x00000001816BA970
		internal async Task DoWriteValueAsync(DateTime value, CancellationToken cancellationToken); // 0x00000001816B7070-0x00000001816B7170
		public override Task WriteValueAsync(DateTime? value, CancellationToken cancellationToken = default); // 0x00000001816BA360-0x00000001816BA3B0
		internal Task DoWriteValueAsync(DateTime? value, CancellationToken cancellationToken); // 0x00000001816B7370-0x00000001816B7390
		public override Task WriteValueAsync(DateTimeOffset value, CancellationToken cancellationToken = default); // 0x00000001816BA5D0-0x00000001816BA600
		internal async Task DoWriteValueAsync(DateTimeOffset value, CancellationToken cancellationToken); // 0x00000001816B6E40-0x00000001816B6F40
		public override Task WriteValueAsync(DateTimeOffset? value, CancellationToken cancellationToken = default); // 0x00000001816BAAE0-0x00000001816BAB60
		internal Task DoWriteValueAsync(DateTimeOffset? value, CancellationToken cancellationToken); // 0x00000001816B6A10-0x00000001816B6A50
		public override Task WriteValueAsync(decimal value, CancellationToken cancellationToken = default); // 0x00000001816BA0C0-0x00000001816BA180
		internal Task DoWriteValueAsync(decimal value, CancellationToken cancellationToken); // 0x00000001816B7590-0x00000001816B7620
		public override Task WriteValueAsync(decimal? value, CancellationToken cancellationToken = default); // 0x00000001816B9F80-0x00000001816BA070
		internal Task DoWriteValueAsync(decimal? value, CancellationToken cancellationToken); // 0x00000001816B7390-0x00000001816B7440
		public override Task WriteValueAsync(double value, CancellationToken cancellationToken = default); // 0x00000001816BAB60-0x00000001816BAB90
		internal Task WriteValueAsync(double value, bool nullable, CancellationToken cancellationToken); // 0x00000001816B9EC0-0x00000001816B9F80
		public override Task WriteValueAsync(double? value, CancellationToken cancellationToken = default); // 0x00000001816BB000-0x00000001816BB070
		public override Task WriteValueAsync(float value, CancellationToken cancellationToken = default); // 0x00000001816BA970-0x00000001816BA9A0
		internal Task WriteValueAsync(float value, bool nullable, CancellationToken cancellationToken); // 0x00000001816BAB90-0x00000001816BAC50
		public override Task WriteValueAsync(float? value, CancellationToken cancellationToken = default); // 0x00000001816BA8F0-0x00000001816BA950
		public override Task WriteValueAsync(Guid value, CancellationToken cancellationToken = default); // 0x00000001816BAEC0-0x00000001816BAEF0
		internal async Task DoWriteValueAsync(Guid value, CancellationToken cancellationToken); // 0x00000001816B7490-0x00000001816B7590
		public override Task WriteValueAsync(Guid? value, CancellationToken cancellationToken = default); // 0x00000001816BA400-0x00000001816BA470
		internal Task DoWriteValueAsync(Guid? value, CancellationToken cancellationToken); // 0x00000001816B7620-0x00000001816B7660
		public override Task WriteValueAsync(int value, CancellationToken cancellationToken = default); // 0x00000001816BB300-0x00000001816BB350
		public override Task WriteValueAsync(int? value, CancellationToken cancellationToken = default); // 0x00000001816BB350-0x00000001816BB3C0
		internal Task DoWriteValueAsync(int? value, CancellationToken cancellationToken); // 0x00000001816B7440-0x00000001816B7490
		public override Task WriteValueAsync(long value, CancellationToken cancellationToken = default); // 0x00000001816BAE30-0x00000001816BAE80
		public override Task WriteValueAsync(long? value, CancellationToken cancellationToken = default); // 0x00000001816BAEF0-0x00000001816BAF70
		internal Task DoWriteValueAsync(long? value, CancellationToken cancellationToken); // 0x00000001816B6A70-0x00000001816B6AC0
		internal Task WriteValueAsync(BigInteger value, CancellationToken cancellationToken); // 0x00000001816BA840-0x00000001816BA8F0
		public override Task WriteValueAsync([Nullable(2)] object value, CancellationToken cancellationToken = default); // 0x00000001816BA180-0x00000001816BA360
		[CLSCompliant(false)]
		public override Task WriteValueAsync(sbyte value, CancellationToken cancellationToken = default); // 0x00000001816BAC80-0x00000001816BACD0
		[CLSCompliant(false)]
		public override Task WriteValueAsync(sbyte? value, CancellationToken cancellationToken = default); // 0x00000001816BADC0-0x00000001816BAE30
		internal Task DoWriteValueAsync(sbyte? value, CancellationToken cancellationToken); // 0x00000001816B7230-0x00000001816B7280
		public override Task WriteValueAsync(short value, CancellationToken cancellationToken = default); // 0x00000001816BA070-0x00000001816BA0C0
		public override Task WriteValueAsync(short? value, CancellationToken cancellationToken = default); // 0x00000001816BA470-0x00000001816BA4E0
		internal Task DoWriteValueAsync(short? value, CancellationToken cancellationToken); // 0x00000001816B6AC0-0x00000001816B6B10
		public override Task WriteValueAsync([Nullable(2)] string value, CancellationToken cancellationToken = default); // 0x00000001816BB0E0-0x00000001816BB300
		internal Task DoWriteValueAsync([Nullable(2)] string value, CancellationToken cancellationToken); // 0x00000001816B6B10-0x00000001816B6D10
		private async Task DoWriteValueAsync(Task task, [Nullable(2)] string value, CancellationToken cancellationToken); // 0x00000001816B6F40-0x00000001816B7070
		public override Task WriteValueAsync(TimeSpan value, CancellationToken cancellationToken = default); // 0x00000001816BB070-0x00000001816BB090
		internal async Task DoWriteValueAsync(TimeSpan value, CancellationToken cancellationToken); // 0x00000001816B6D40-0x00000001816B6E40
		public override Task WriteValueAsync(TimeSpan? value, CancellationToken cancellationToken = default); // 0x00000001816BB090-0x00000001816BB0E0
		internal Task DoWriteValueAsync(TimeSpan? value, CancellationToken cancellationToken); // 0x00000001816B6A50-0x00000001816B6A70
		[CLSCompliant(false)]
		public override Task WriteValueAsync(uint value, CancellationToken cancellationToken = default); // 0x00000001816BA500-0x00000001816BA540
		[CLSCompliant(false)]
		public override Task WriteValueAsync(uint? value, CancellationToken cancellationToken = default); // 0x00000001816BA3B0-0x00000001816BA400
		internal Task DoWriteValueAsync(uint? value, CancellationToken cancellationToken); // 0x00000001816B71F0-0x00000001816B7230
		[CLSCompliant(false)]
		public override Task WriteValueAsync(ulong value, CancellationToken cancellationToken = default); // 0x00000001816BAC50-0x00000001816BAC80
		[CLSCompliant(false)]
		public override Task WriteValueAsync(ulong? value, CancellationToken cancellationToken = default); // 0x00000001816BA540-0x00000001816BA5B0
		internal Task DoWriteValueAsync(ulong? value, CancellationToken cancellationToken); // 0x00000001816B76A0-0x00000001816B76E0
		public override Task WriteValueAsync([Nullable(2)] Uri value, CancellationToken cancellationToken = default); // 0x00000001816BA600-0x00000001816BA840
		internal Task WriteValueNotNullAsync(Uri value, CancellationToken cancellationToken); // 0x00000001816BB9A0-0x00000001816BBB60
		internal async Task WriteValueNotNullAsync(Task task, Uri value, CancellationToken cancellationToken); // 0x00000001816BB870-0x00000001816BB9A0
		[CLSCompliant(false)]
		public override Task WriteValueAsync(ushort value, CancellationToken cancellationToken = default); // 0x00000001816BAE80-0x00000001816BAEC0
		[CLSCompliant(false)]
		public override Task WriteValueAsync(ushort? value, CancellationToken cancellationToken = default); // 0x00000001816BAD70-0x00000001816BADC0
		internal Task DoWriteValueAsync(ushort? value, CancellationToken cancellationToken); // 0x00000001816B7660-0x00000001816B76A0
		public override Task WriteCommentAsync([Nullable(2)] string text, CancellationToken cancellationToken = default); // 0x00000001816B7B50-0x00000001816B7C70
		internal async Task DoWriteCommentAsync([Nullable(2)] string text, CancellationToken cancellationToken); // 0x00000001816B5460-0x00000001816B5570
		public override Task WriteEndArrayAsync(CancellationToken cancellationToken = default); // 0x00000001816B7E20-0x00000001816B7E40
		public override Task WriteEndConstructorAsync(CancellationToken cancellationToken = default); // 0x00000001816B8000-0x00000001816B8020
		public override Task WriteEndObjectAsync(CancellationToken cancellationToken = default); // 0x00000001816B8020-0x00000001816B8040
		public override Task WriteRawValueAsync([Nullable(2)] string json, CancellationToken cancellationToken = default); // 0x00000001816B9400-0x00000001816B95D0
		internal Task DoWriteRawValueAsync([Nullable(2)] string json, CancellationToken cancellationToken); // 0x00000001816B5E20-0x00000001816B5FD0
		private async Task DoWriteRawValueAsync(Task task, [Nullable(2)] string json, CancellationToken cancellationToken); // 0x00000001816B5FD0-0x00000001816B6100
		internal char[] EnsureWriteBuffer(int length, int copyTo); // 0x00000001816B77D0-0x00000001816B78B0
		public override void Flush(); // 0x000000018151DFC0-0x000000018151DFF0
		public override void Close(); // 0x00000001816B5280-0x00000001816B5300
		private void CloseBufferAndWriter(); // 0x00000001816B5210-0x00000001816B5280
		public override void WriteStartObject(); // 0x00000001816B9BF0-0x00000001816B9C40
		public override void WriteStartArray(); // 0x00000001816B97F0-0x00000001816B9840
		public override void WriteStartConstructor(string name); // 0x00000001816B9960-0x00000001816B9A20
		protected override void WriteEnd(JsonToken token); // 0x00000001816B8040-0x00000001816B8130
		public override void WritePropertyName(string name); // 0x00000001816B9220-0x00000001816B9280
		public override void WritePropertyName(string name, bool escape); // 0x00000001816B9280-0x00000001816B9370
		internal override void OnStringEscapeHandlingChanged(); // 0x00000001816B79A0-0x00000001816B79B0
		private void UpdateCharEscapeFlags(); // 0x00000001816B7AD0-0x00000001816B7B50
		protected override void WriteIndent(); // 0x00000001816B86A0-0x00000001816B87D0
		private int SetIndentChars(); // 0x00000001816B79B0-0x00000001816B7AD0
		protected override void WriteValueDelimiter(); // 0x00000001816BB440-0x00000001816BB470
		protected override void WriteIndentSpace(); // 0x00000001816B8670-0x00000001816B86A0
		private void WriteValueInternal(string value, JsonToken token); // 0x00000001816BB730-0x00000001816BB760
		[NullableContext(2)]
		public override void WriteValue(object value); // 0x00000001816BBF80-0x00000001816BC0A0
		public override void WriteNull(); // 0x00000001816B8E20-0x00000001816B8EB0
		public override void WriteUndefined(); // 0x00000001816B9E30-0x00000001816B9EC0
		[NullableContext(2)]
		public override void WriteRaw(string json); // 0x00000001816B95D0-0x00000001816B9620
		[NullableContext(2)]
		public override void WriteValue(string value); // 0x00000001816BC8E0-0x00000001816BC9A0
		private void WriteEscapedString(string value, bool quote); // 0x00000001816B8210-0x00000001816B8310
		public override void WriteValue(int value); // 0x00000001816BC0A0-0x00000001816BC0E0
		[CLSCompliant(false)]
		public override void WriteValue(uint value); // 0x00000001816BC340-0x00000001816BC3C0
		public override void WriteValue(long value); // 0x00000001816BCF70-0x00000001816BD000
		[CLSCompliant(false)]
		public override void WriteValue(ulong value); // 0x00000001816BCF30-0x00000001816BCF70
		public override void WriteValue(float value); // 0x00000001816BD000-0x00000001816BD0C0
		public override void WriteValue(float? value); // 0x00000001816BD0C0-0x00000001816BD1A0
		public override void WriteValue(double value); // 0x00000001816BCE70-0x00000001816BCF30
		public override void WriteValue(double? value); // 0x00000001816BC0E0-0x00000001816BC1D0
		public override void WriteValue(bool value); // 0x00000001816BC6C0-0x00000001816BC750
		public override void WriteValue(short value); // 0x00000001816BC1D0-0x00000001816BC210
		[CLSCompliant(false)]
		public override void WriteValue(ushort value); // 0x00000001816BC300-0x00000001816BC340
		public override void WriteValue(char value); // 0x00000001816BCDE0-0x00000001816BCE70
		public override void WriteValue(byte value); // 0x00000001816BCDA0-0x00000001816BCDE0
		[CLSCompliant(false)]
		public override void WriteValue(sbyte value); // 0x00000001816BC8A0-0x00000001816BC8E0
		public override void WriteValue(decimal value); // 0x00000001816BC750-0x00000001816BC7F0
		public override void WriteValue(DateTime value); // 0x00000001816BC9A0-0x00000001816BCCA0
		private int WriteValueToBuffer(DateTime value); // 0x00000001816BBD10-0x00000001816BBE90
		[NullableContext(2)]
		public override void WriteValue(byte[] value); // 0x00000001816BBE90-0x00000001816BBF80
		public override void WriteValue(DateTimeOffset value); // 0x00000001816BC3C0-0x00000001816BC6C0
		private int WriteValueToBuffer(DateTimeOffset value); // 0x00000001816BBB60-0x00000001816BBD10
		public override void WriteValue(Guid value); // 0x00000001816BC210-0x00000001816BC300
		public override void WriteValue(TimeSpan value); // 0x00000001816BCCA0-0x00000001816BCDA0
		[NullableContext(2)]
		public override void WriteValue(Uri value); // 0x00000001816BC7F0-0x00000001816BC8A0
		[NullableContext(2)]
		public override void WriteComment(string text); // 0x00000001816B7C70-0x00000001816B7D30
		public override void WriteWhitespace(string ws); // 0x00000001816BD240-0x00000001816BD290
		private void EnsureWriteBuffer(); // 0x00000001816B78B0-0x00000001816B7900
		private void WriteIntegerValue(long value); // 0x00000001816B8DA0-0x00000001816B8E00
		private void WriteIntegerValue(ulong value, bool negative); // 0x00000001816B8BC0-0x00000001816B8C50
		private int WriteNumberToBuffer(ulong value, bool negative); // 0x00000001816B8EB0-0x00000001816B8FD0
		private void WriteIntegerValue(int value); // 0x00000001816B8CE0-0x00000001816B8DA0
		private void WriteIntegerValue(uint value, bool negative); // 0x00000001816B8C50-0x00000001816B8CE0
		private int WriteNumberToBuffer(uint value, bool negative); // 0x00000001816B8FD0-0x00000001816B90C0
	}
}
