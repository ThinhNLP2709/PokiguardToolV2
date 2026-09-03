/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json
{
	[Nullable(0)]
	[NullableContext(2)]
	public abstract class JsonReader : IDisposable // TypeDefIndex: 9984
	{
		// Fields
		private JsonToken _tokenType; // 0x10
		private object _value; // 0x18
		internal char _quoteChar; // 0x20
		internal State _currentState; // 0x24
		private JsonPosition _currentPosition; // 0x28
		private CultureInfo _culture; // 0x40
		private DateTimeZoneHandling _dateTimeZoneHandling; // 0x48
		private int? _maxDepth; // 0x4C
		private bool _hasExceededMaxDepth; // 0x54
		internal DateParseHandling _dateParseHandling; // 0x58
		internal FloatParseHandling _floatParseHandling; // 0x5C
		private string _dateFormatString; // 0x60
		private List<JsonPosition> _stack; // 0x68
		[CompilerGenerated]
		private bool _CloseInput_k__BackingField; // 0x70
		[CompilerGenerated]
		private bool _SupportMultipleContent_k__BackingField; // 0x71
	
		// Properties
		protected State CurrentState { get; } // 0x0000000180D17D10-0x0000000180D17D20 
		public bool CloseInput { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180643BD0-0x0000000180643BE0 0x0000000180C4A240-0x0000000180C4A250
		public bool SupportMultipleContent { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018030D9D0-0x000000018030D9E0 0x00000001803CB1F0-0x00000001803CB200
		public virtual char QuoteChar { get; protected internal set; } // 0x00000001816A1C50-0x00000001816A1C60 0x00000001816A1E50-0x00000001816A1E60
		public DateTimeZoneHandling DateTimeZoneHandling { get; set; } // 0x000000018033D1C0-0x000000018033D1D0 0x00000001816A1CE0-0x00000001816A1D50
		public DateParseHandling DateParseHandling { get; set; } // 0x000000018033D260-0x000000018033D270 0x00000001816A1C70-0x00000001816A1CE0
		public FloatParseHandling FloatParseHandling { get; set; } // 0x000000018033D270-0x000000018033D280 0x00000001816A1D50-0x00000001816A1DC0
		public string DateFormatString { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
		public int? MaxDepth { get; set; } // 0x00000001816A1B50-0x00000001816A1B60 0x00000001816A1DC0-0x00000001816A1E50
		public virtual JsonToken TokenType { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public virtual object Value { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public virtual Type ValueType { get; } // 0x00000001816A1C60-0x00000001816A1C70 
		public virtual int Depth { get; } // 0x00000001816A1B00-0x00000001816A1B50 
		[Nullable(1)]
		public virtual string Path { [NullableContext(1)] get; } // 0x00000001816A1B60-0x00000001816A1C50 
		[Nullable(1)]
		public CultureInfo Culture { [NullableContext(1)] get; [NullableContext(1)] set; } // 0x00000001816A1AC0-0x00000001816A1B00 0x0000000180378120-0x0000000180378130
	
		// Nested types
		[NullableContext(0)]
		protected internal enum State // TypeDefIndex: 9985
		{
			Start = 0,
			Complete = 1,
			Property = 2,
			ObjectStart = 3,
			Object = 4,
			ArrayStart = 5,
			Array = 6,
			Closed = 7,
			PostValue = 8,
			ConstructorStart = 9,
			Constructor = 10,
			Error = 11,
			Finished = 12
		}
	
		[CompilerGenerated]
		private struct _MoveToContentFromNonContentAsync_d__14 : IAsyncStateMachine // TypeDefIndex: 9986
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<bool> __t__builder; // 0x08
			[Nullable(0)]
			public JsonReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001816B3FD0-0x00000001816B4210
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816B4210-0x00000001816B4270
		}
	
		[CompilerGenerated]
		private struct _ReadAndMoveToContentAsync_d__12 : IAsyncStateMachine // TypeDefIndex: 9987
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<bool> __t__builder; // 0x08
			[Nullable(0)]
			public JsonReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001816B4270-0x00000001816B4680
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816B4680-0x00000001816B46E0
		}
	
		[CompilerGenerated]
		private struct _ReadArrayIntoByteArrayAsync_d__5 : IAsyncStateMachine // TypeDefIndex: 9988
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<byte[]> __t__builder; // 0x08
			[Nullable(0)]
			public JsonReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			private List<byte> _buffer_5__2; // 0x30
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816B46E0-0x00000001816B49F0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816B49F0-0x00000001816B4A50
		}
	
		[CompilerGenerated]
		private struct _ReaderReadAndAssertAsync_d__2 : IAsyncStateMachine // TypeDefIndex: 9989
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001816B4A50-0x00000001816B4C30
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816B4C30-0x00000001816B4C90
		}
	
		[CompilerGenerated]
		private struct _SkipAsync_d__1 : IAsyncStateMachine // TypeDefIndex: 9990
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonReader __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x30
			private int _depth_5__2; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816B4C90-0x00000001816B4FE0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816B4FE0-0x00000001816B5040
		}
	
		// Constructors
		protected JsonReader(); // 0x00000001816A1A70-0x00000001816A1AC0
	
		// Methods
		[NullableContext(1)]
		public virtual Task<bool> ReadAsync(CancellationToken cancellationToken = default); // 0x000000018169FE50-0x000000018169FEE0
		[NullableContext(1)]
		public async Task SkipAsync(CancellationToken cancellationToken = default); // 0x00000001816A1590-0x00000001816A1680
		[NullableContext(1)]
		internal async Task ReaderReadAndAssertAsync(CancellationToken cancellationToken); // 0x00000001816A10E0-0x00000001816A11C0
		[NullableContext(1)]
		public virtual Task<bool?> ReadAsBooleanAsync(CancellationToken cancellationToken = default); // 0x000000018169DB20-0x000000018169DBF0
		public virtual Task<byte[]> ReadAsBytesAsync(CancellationToken cancellationToken = default); // 0x000000018169DF70-0x000000018169E040
		internal async Task<byte[]> ReadArrayIntoByteArrayAsync(CancellationToken cancellationToken); // 0x000000018169D920-0x000000018169DA20
		[NullableContext(1)]
		public virtual Task<DateTime?> ReadAsDateTimeAsync(CancellationToken cancellationToken = default); // 0x000000018169E490-0x000000018169E570
		[NullableContext(1)]
		public virtual Task<DateTimeOffset?> ReadAsDateTimeOffsetAsync(CancellationToken cancellationToken = default); // 0x000000018169E570-0x000000018169E660
		[NullableContext(1)]
		public virtual Task<decimal?> ReadAsDecimalAsync(CancellationToken cancellationToken = default); // 0x000000018169EC50-0x000000018169ED40
		[NullableContext(1)]
		public virtual Task<double?> ReadAsDoubleAsync(CancellationToken cancellationToken = default); // 0x000000018169F1D0-0x000000018169F260
		[NullableContext(1)]
		public virtual Task<int?> ReadAsInt32Async(CancellationToken cancellationToken = default); // 0x000000018169F5B0-0x000000018169F680
		public virtual Task<string> ReadAsStringAsync(CancellationToken cancellationToken = default); // 0x000000018169FA70-0x000000018169FB40
		[NullableContext(1)]
		internal async Task<bool> ReadAndMoveToContentAsync(CancellationToken cancellationToken); // 0x000000018169D590-0x000000018169D690
		[NullableContext(1)]
		internal Task<bool> MoveToContentAsync(CancellationToken cancellationToken); // 0x000000018169CE30-0x000000018169CFA0
		[NullableContext(1)]
		private async Task<bool> MoveToContentFromNonContentAsync(CancellationToken cancellationToken); // 0x000000018169CFA0-0x000000018169D0A0
		internal JsonPosition GetPosition(int depth); // 0x000000018169CCD0-0x000000018169CD40
		private void Push(JsonContainerType value); // 0x000000018169D1F0-0x000000018169D530
		private JsonContainerType Pop(); // 0x000000018169D100-0x000000018169D1F0
		private JsonContainerType Peek(); // 0x0000000180377930-0x0000000180377940
		public abstract bool Read();
		public virtual int? ReadAsInt32(); // 0x000000018169F680-0x000000018169FA70
		internal int? ReadInt32String(string s); // 0x00000001816A0CC0-0x00000001816A0E40
		public virtual string ReadAsString(); // 0x000000018169FB40-0x000000018169FE50
		public virtual byte[] ReadAsBytes(); // 0x000000018169E040-0x000000018169E490
		[NullableContext(1)]
		internal byte[] ReadArrayIntoByteArray(); // 0x000000018169DA20-0x000000018169DB20
		[NullableContext(1)]
		private bool ReadArrayElementIntoByteArrayReportDone(List<byte> buffer); // 0x000000018169D6F0-0x000000018169D920
		public virtual double? ReadAsDouble(); // 0x000000018169F260-0x000000018169F5B0
		internal double? ReadDoubleString(string s); // 0x00000001816A0830-0x00000001816A09B0
		public virtual bool? ReadAsBoolean(); // 0x000000018169DBF0-0x000000018169DF70
		internal bool? ReadBooleanString(string s); // 0x000000018169FEE0-0x00000001816A0050
		public virtual decimal? ReadAsDecimal(); // 0x000000018169ED40-0x000000018169F1D0
		internal decimal? ReadDecimalString(string s); // 0x00000001816A0570-0x00000001816A0830
		public virtual DateTime? ReadAsDateTime(); // 0x000000018169E970-0x000000018169EC50
		internal DateTime? ReadDateTimeString(string s); // 0x00000001816A0320-0x00000001816A0570
		public virtual DateTimeOffset? ReadAsDateTimeOffset(); // 0x000000018169E660-0x000000018169E970
		internal DateTimeOffset? ReadDateTimeOffsetString(string s); // 0x00000001816A0050-0x00000001816A0320
		internal void ReaderReadAndAssert(); // 0x00000001816A11C0-0x00000001816A1210
		[NullableContext(1)]
		internal JsonReaderException CreateUnexpectedEndException(); // 0x000000018169CBF0-0x000000018169CC30
		internal void ReadIntoWrappedTypeObject(); // 0x00000001816A0E40-0x00000001816A10E0
		public void Skip(); // 0x00000001816A1680-0x00000001816A1740
		protected void SetToken(JsonToken newToken); // 0x00000001816A1570-0x00000001816A1590
		protected void SetToken(JsonToken newToken, object value); // 0x00000001816A1550-0x00000001816A1570
		protected void SetToken(JsonToken newToken, object value, bool updateIndex); // 0x00000001816A1370-0x00000001816A1550
		internal void SetPostValueState(bool updateIndex); // 0x00000001816A1230-0x00000001816A1260
		private void UpdateScopeWithFinishedValue(); // 0x00000001816A17B0-0x00000001816A17C0
		private void ValidateEnd(JsonToken endToken); // 0x00000001816A17C0-0x00000001816A1A70
		protected void SetStateBasedOnCurrent(); // 0x00000001816A1260-0x00000001816A1370
		private void SetFinished(); // 0x00000001816A1210-0x00000001816A1230
		private JsonContainerType GetTypeForCloseToken(JsonToken token); // 0x000000018169CD40-0x000000018169CE30
		void IDisposable.Dispose(); // 0x00000001816A1740-0x00000001816A17B0
		protected virtual void Dispose(bool disposing); // 0x000000018169CC30-0x000000018169CC60
		public virtual void Close(); // 0x000000018169CBD0-0x000000018169CBF0
		internal void ReadAndAssert(); // 0x000000018169D530-0x000000018169D590
		internal void ReadForTypeAndAssert(JsonContract contract, bool hasConverter); // 0x00000001816A09B0-0x00000001816A0A00
		internal bool ReadForType(JsonContract contract, bool hasConverter); // 0x00000001816A0A00-0x00000001816A0CC0
		internal bool ReadAndMoveToContent(); // 0x000000018169D690-0x000000018169D6F0
		internal bool MoveToContent(); // 0x000000018169D0A0-0x000000018169D100
		private JsonToken GetContentToken(); // 0x000000018169CC60-0x000000018169CCD0
	}
}
