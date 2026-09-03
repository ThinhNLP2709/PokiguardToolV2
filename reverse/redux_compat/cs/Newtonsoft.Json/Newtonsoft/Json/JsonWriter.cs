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
using Newtonsoft.Json.Utilities;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json
{
	[Nullable(0)]
	[NullableContext(1)]
	public abstract class JsonWriter : IDisposable // TypeDefIndex: 10063
	{
		// Fields
		private static readonly State[][] StateArray; // 0x00
		internal static readonly State[][] StateArrayTemplate; // 0x08
		[Nullable(2)]
		private List<JsonPosition> _stack; // 0x10
		private JsonPosition _currentPosition; // 0x18
		private State _currentState; // 0x30
		private Formatting _formatting; // 0x34
		[CompilerGenerated]
		private bool _CloseOutput_k__BackingField; // 0x38
		[CompilerGenerated]
		private bool _AutoCompleteOnClose_k__BackingField; // 0x39
		private DateFormatHandling _dateFormatHandling; // 0x3C
		private DateTimeZoneHandling _dateTimeZoneHandling; // 0x40
		private StringEscapeHandling _stringEscapeHandling; // 0x44
		private FloatFormatHandling _floatFormatHandling; // 0x48
		[Nullable(2)]
		private string _dateFormatString; // 0x50
		[Nullable(2)]
		private CultureInfo _culture; // 0x58
	
		// Properties
		public bool CloseOutput { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180476380-0x0000000180476390 0x00000001804763A0-0x00000001804763B0
		public bool AutoCompleteOnClose { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001814CFF30-0x00000001814CFF40 0x00000001816DA820-0x00000001816DA830
		protected internal int Top { get; } // 0x00000001816DA6D0-0x00000001816DA700 
		public WriteState WriteState { get; } // 0x00000001816DA700-0x00000001816DA820 
		internal string ContainerPath { get; } // 0x00000001816DA510-0x00000001816DA5A0 
		public string Path { get; } // 0x00000001816DA5E0-0x00000001816DA6D0 
		public Formatting Formatting { get; set; } // 0x000000018033D0F0-0x000000018033D100 0x00000001816DA980-0x00000001816DA9F0
		public DateFormatHandling DateFormatHandling { get; set; } // 0x00000001804EFAC0-0x00000001804EFAD0 0x00000001816DA830-0x00000001816DA8A0
		public DateTimeZoneHandling DateTimeZoneHandling { get; set; } // 0x000000018033D790-0x000000018033D7A0 0x00000001816DA8A0-0x00000001816DA910
		public StringEscapeHandling StringEscapeHandling { get; set; } // 0x000000018033D780-0x000000018033D790 0x00000001816DA9F0-0x00000001816DAA70
		public FloatFormatHandling FloatFormatHandling { get; set; } // 0x000000018033D1C0-0x000000018033D1D0 0x00000001816DA910-0x00000001816DA980
		[Nullable(2)]
		public string DateFormatString { [NullableContext(2)] get; [NullableContext(2)] set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		public CultureInfo Culture { get; set; } // 0x00000001816DA5A0-0x00000001816DA5E0 0x00000001802F4050-0x00000001802F4060
	
		// Nested types
		[NullableContext(0)]
		internal enum State // TypeDefIndex: 10064
		{
			Start = 0,
			Property = 1,
			ObjectStart = 2,
			Object = 3,
			ArrayStart = 4,
			Array = 5,
			ConstructorStart = 6,
			Constructor = 7,
			Closed = 8,
			Error = 9
		}
	
		[CompilerGenerated]
		private struct __InternalWriteEndAsync_g__AwaitEnd_11_2_d : IAsyncStateMachine // TypeDefIndex: 10065
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Task task; // 0x20
			[Nullable(0)]
			public JsonWriter __4__this; // 0x28
			public int LevelsToComplete; // 0x30
			public CancellationToken CancellationToken; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816DF380-0x00000001816DF5F0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DF5F0-0x00000001816DF650
		}
	
		[CompilerGenerated]
		private struct __InternalWriteEndAsync_g__AwaitIndent_11_1_d : IAsyncStateMachine // TypeDefIndex: 10066
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Task task; // 0x20
			[Nullable(0)]
			public JsonWriter __4__this; // 0x28
			public JsonToken token; // 0x30
			public CancellationToken CancellationToken; // 0x38
			public int LevelsToComplete; // 0x40
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x48
	
			// Methods
			private void MoveNext(); // 0x00000001816DF650-0x00000001816DF9B0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DF9B0-0x00000001816DFA10
		}
	
		[CompilerGenerated]
		private struct __InternalWriteEndAsync_g__AwaitProperty_11_0_d : IAsyncStateMachine // TypeDefIndex: 10067
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Task task; // 0x20
			[Nullable(0)]
			public JsonWriter __4__this; // 0x28
			public CancellationToken CancellationToken; // 0x30
			public JsonToken token; // 0x38
			public int LevelsToComplete; // 0x3C
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816DFA10-0x00000001816DFE60
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816DFE60-0x00000001816DFEC0
		}
	
		[CompilerGenerated]
		private struct __InternalWriteEndAsync_g__AwaitRemaining_11_3_d : IAsyncStateMachine // TypeDefIndex: 10068
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonWriter __4__this; // 0x20
			public CancellationToken CancellationToken; // 0x28
			public int LevelsToComplete; // 0x30
			private JsonToken _token_5__2; // 0x34
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x38
	
			// Methods
			private void MoveNext(); // 0x00000001816DFEC0-0x00000001816E02E0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816E02E0-0x00000001816E0340
		}
	
		[CompilerGenerated]
		private struct _AutoCompleteAsync_d__1 : IAsyncStateMachine // TypeDefIndex: 10069
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonWriter __4__this; // 0x20
			public CancellationToken cancellationToken; // 0x28
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x30
	
			// Methods
			private void MoveNext(); // 0x00000001816FA760-0x00000001816FA9F0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816FA9F0-0x00000001816FAA50
		}
	
		[CompilerGenerated]
		private struct _InternalWriteStartAsync_d__20 : IAsyncStateMachine // TypeDefIndex: 10070
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonWriter __4__this; // 0x20
			public JsonToken token; // 0x28
			public CancellationToken cancellationToken; // 0x30
			public JsonContainerType container; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816FAF40-0x00000001816FB110
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816FB110-0x00000001816FB170
		}
	
		[CompilerGenerated]
		private struct _WriteConstructorDateAsync_d__32 : IAsyncStateMachine // TypeDefIndex: 10071
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonReader reader; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			public JsonWriter __4__this; // 0x30
			private DateTime _date_5__2; // 0x38
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x40
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x50
	
			// Methods
			private void MoveNext(); // 0x00000001816FBB10-0x00000001816FC140
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816FC140-0x00000001816FC1A0
		}
	
		[CompilerGenerated]
		private struct _WriteTokenAsync_d__30 : IAsyncStateMachine // TypeDefIndex: 10072
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonWriter __4__this; // 0x20
			[Nullable(0)]
			public JsonReader reader; // 0x28
			public bool writeDateConstructorAsDate; // 0x30
			public CancellationToken cancellationToken; // 0x38
			public bool writeComments; // 0x40
			public bool writeChildren; // 0x41
			private int _initialDepth_5__2; // 0x44
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x48
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__2; // 0x58
	
			// Methods
			private void MoveNext(); // 0x00000001816FD1D0-0x00000001816FD7C0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816FD7C0-0x00000001816FD820
		}
	
		[CompilerGenerated]
		private struct _WriteTokenSyncReadingAsync_d__31 : IAsyncStateMachine // TypeDefIndex: 10073
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonWriter __4__this; // 0x20
			[Nullable(0)]
			public JsonReader reader; // 0x28
			public CancellationToken cancellationToken; // 0x30
			private int _initialDepth_5__2; // 0x38
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816FD820-0x00000001816FDC20
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816FDC20-0x00000001816FDCD0
		}
	
		// Constructors
		static JsonWriter(); // 0x00000001816DA170-0x00000001816DA4E0
		protected JsonWriter(); // 0x00000001816DA4E0-0x00000001816DA510
	
		// Methods
		internal Task AutoCompleteAsync(JsonToken tokenBeingWritten, CancellationToken cancellationToken); // 0x00000001816D00C0-0x00000001816D03C0
		private async Task AutoCompleteAsync(CancellationToken cancellationToken); // 0x00000001816D03C0-0x00000001816D04A0
		public virtual Task CloseAsync(CancellationToken cancellationToken = default); // 0x00000001816D0B20-0x00000001816D0BF0
		public virtual Task FlushAsync(CancellationToken cancellationToken = default); // 0x00000001816D0D10-0x00000001816D0DE0
		protected virtual Task WriteEndAsync(JsonToken token, CancellationToken cancellationToken); // 0x00000001816D2A80-0x00000001816D2B60
		protected virtual Task WriteIndentAsync(CancellationToken cancellationToken); // 0x00000001816D3090-0x00000001816D3160
		protected virtual Task WriteValueDelimiterAsync(CancellationToken cancellationToken); // 0x00000001816D8830-0x00000001816D8900
		protected virtual Task WriteIndentSpaceAsync(CancellationToken cancellationToken); // 0x00000001816D3160-0x00000001816D3230
		public virtual Task WriteRawAsync([Nullable(2)] string json, CancellationToken cancellationToken = default); // 0x00000001816D3520-0x00000001816D3600
		public virtual Task WriteEndAsync(CancellationToken cancellationToken = default); // 0x00000001816D29B0-0x00000001816D2A80
		internal Task WriteEndInternalAsync(CancellationToken cancellationToken); // 0x00000001816D2C40-0x00000001816D2DC0
		internal Task InternalWriteEndAsync(JsonContainerType type, CancellationToken cancellationToken); // 0x00000001816D0EC0-0x00000001816D1150
		public virtual Task WriteEndArrayAsync(CancellationToken cancellationToken = default); // 0x00000001816D28D0-0x00000001816D29A0
		public virtual Task WriteEndConstructorAsync(CancellationToken cancellationToken = default); // 0x00000001816D2B60-0x00000001816D2C30
		public virtual Task WriteEndObjectAsync(CancellationToken cancellationToken = default); // 0x00000001816D2DC0-0x00000001816D2E90
		public virtual Task WriteNullAsync(CancellationToken cancellationToken = default); // 0x00000001816D3230-0x00000001816D3300
		public virtual Task WritePropertyNameAsync(string name, CancellationToken cancellationToken = default); // 0x00000001816D3320-0x00000001816D3400
		public virtual Task WritePropertyNameAsync(string name, bool escape, CancellationToken cancellationToken = default); // 0x00000001816D3400-0x00000001816D3500
		internal Task InternalWritePropertyNameAsync(string name, CancellationToken cancellationToken); // 0x00000001816D1150-0x00000001816D1220
		public virtual Task WriteStartArrayAsync(CancellationToken cancellationToken = default); // 0x00000001816D3730-0x00000001816D3800
		internal async Task InternalWriteStartAsync(JsonToken token, JsonContainerType container, CancellationToken cancellationToken); // 0x00000001816D1250-0x00000001816D1360
		public virtual Task WriteCommentAsync([Nullable(2)] string text, CancellationToken cancellationToken = default); // 0x00000001816D2620-0x00000001816D2700
		internal Task InternalWriteCommentAsync(CancellationToken cancellationToken); // 0x00000001816D0EA0-0x00000001816D0EB0
		public virtual Task WriteRawValueAsync([Nullable(2)] string json, CancellationToken cancellationToken = default); // 0x00000001816D3600-0x00000001816D36E0
		public virtual Task WriteStartConstructorAsync(string name, CancellationToken cancellationToken = default); // 0x00000001816D3810-0x00000001816D38F0
		public virtual Task WriteStartObjectAsync(CancellationToken cancellationToken = default); // 0x00000001816D3900-0x00000001816D39D0
		public Task WriteTokenAsync(JsonReader reader, CancellationToken cancellationToken = default); // 0x00000001816D3B10-0x00000001816D3BA0
		public Task WriteTokenAsync(JsonReader reader, bool writeChildren, CancellationToken cancellationToken = default); // 0x00000001816D4540-0x00000001816D45E0
		public Task WriteTokenAsync(JsonToken token, CancellationToken cancellationToken = default); // 0x00000001816D45E0-0x00000001816D4600
		public Task WriteTokenAsync(JsonToken token, [Nullable(2)] object value, CancellationToken cancellationToken = default); // 0x00000001816D3BA0-0x00000001816D4540
		internal virtual async Task WriteTokenAsync(JsonReader reader, bool writeChildren, bool writeDateConstructorAsDate, bool writeComments, CancellationToken cancellationToken); // 0x00000001816D39E0-0x00000001816D3B10
		internal async Task WriteTokenSyncReadingAsync(JsonReader reader, CancellationToken cancellationToken); // 0x00000001816D4600-0x00000001816D4710
		private async Task WriteConstructorDateAsync(JsonReader reader, CancellationToken cancellationToken); // 0x00000001816D2700-0x00000001816D2810
		public virtual Task WriteValueAsync(bool value, CancellationToken cancellationToken = default); // 0x00000001816D7140-0x00000001816D7220
		public virtual Task WriteValueAsync(bool? value, CancellationToken cancellationToken = default); // 0x00000001816D5DA0-0x00000001816D5E80
		public virtual Task WriteValueAsync(byte value, CancellationToken cancellationToken = default); // 0x00000001816D5CC0-0x00000001816D5DA0
		public virtual Task WriteValueAsync(byte? value, CancellationToken cancellationToken = default); // 0x00000001816D6B00-0x00000001816D6BE0
		public virtual Task WriteValueAsync([Nullable(2)] byte[] value, CancellationToken cancellationToken = default); // 0x00000001816D5BE0-0x00000001816D5CC0
		public virtual Task WriteValueAsync(char value, CancellationToken cancellationToken = default); // 0x00000001816D65B0-0x00000001816D6690
		public virtual Task WriteValueAsync(char? value, CancellationToken cancellationToken = default); // 0x00000001816D6CC0-0x00000001816D6DA0
		public virtual Task WriteValueAsync(DateTime value, CancellationToken cancellationToken = default); // 0x00000001816D5F60-0x00000001816D6040
		public virtual Task WriteValueAsync(DateTime? value, CancellationToken cancellationToken = default); // 0x00000001816D8480-0x00000001816D8570
		public virtual Task WriteValueAsync(DateTimeOffset value, CancellationToken cancellationToken = default); // 0x00000001816D64C0-0x00000001816D65B0
		public virtual Task WriteValueAsync(DateTimeOffset? value, CancellationToken cancellationToken = default); // 0x00000001816D8650-0x00000001816D8750
		public virtual Task WriteValueAsync(decimal value, CancellationToken cancellationToken = default); // 0x00000001816D6DA0-0x00000001816D6E90
		public virtual Task WriteValueAsync(decimal? value, CancellationToken cancellationToken = default); // 0x00000001816D6040-0x00000001816D6140
		public virtual Task WriteValueAsync(double value, CancellationToken cancellationToken = default); // 0x00000001816D63E0-0x00000001816D64C0
		public virtual Task WriteValueAsync(double? value, CancellationToken cancellationToken = default); // 0x00000001816D5590-0x00000001816D5680
		public virtual Task WriteValueAsync(float value, CancellationToken cancellationToken = default); // 0x00000001816D6300-0x00000001816D63E0
		public virtual Task WriteValueAsync(float? value, CancellationToken cancellationToken = default); // 0x00000001816D6940-0x00000001816D6A20
		public virtual Task WriteValueAsync(Guid value, CancellationToken cancellationToken = default); // 0x00000001816D5A00-0x00000001816D5AF0
		public virtual Task WriteValueAsync(Guid? value, CancellationToken cancellationToken = default); // 0x00000001816D7050-0x00000001816D7140
		public virtual Task WriteValueAsync(int value, CancellationToken cancellationToken = default); // 0x00000001816D8750-0x00000001816D8830
		public virtual Task WriteValueAsync(int? value, CancellationToken cancellationToken = default); // 0x00000001816D6140-0x00000001816D6220
		public virtual Task WriteValueAsync(long value, CancellationToken cancellationToken = default); // 0x00000001816D6780-0x00000001816D6860
		public virtual Task WriteValueAsync(long? value, CancellationToken cancellationToken = default); // 0x00000001816D54A0-0x00000001816D5590
		public virtual Task WriteValueAsync([Nullable(2)] object value, CancellationToken cancellationToken = default); // 0x00000001816D5E80-0x00000001816D5F60
		[CLSCompliant(false)]
		public virtual Task WriteValueAsync(sbyte value, CancellationToken cancellationToken = default); // 0x00000001816D8570-0x00000001816D8650
		[CLSCompliant(false)]
		public virtual Task WriteValueAsync(sbyte? value, CancellationToken cancellationToken = default); // 0x00000001816D5920-0x00000001816D5A00
		public virtual Task WriteValueAsync(short value, CancellationToken cancellationToken = default); // 0x00000001816D6220-0x00000001816D6300
		public virtual Task WriteValueAsync(short? value, CancellationToken cancellationToken = default); // 0x00000001816D6E90-0x00000001816D6F70
		public virtual Task WriteValueAsync([Nullable(2)] string value, CancellationToken cancellationToken = default); // 0x00000001816D6860-0x00000001816D6940
		public virtual Task WriteValueAsync(TimeSpan value, CancellationToken cancellationToken = default); // 0x00000001816D6A20-0x00000001816D6B00
		public virtual Task WriteValueAsync(TimeSpan? value, CancellationToken cancellationToken = default); // 0x00000001816D6690-0x00000001816D6780
		[CLSCompliant(false)]
		public virtual Task WriteValueAsync(uint value, CancellationToken cancellationToken = default); // 0x00000001816D7220-0x00000001816D7300
		[CLSCompliant(false)]
		public virtual Task WriteValueAsync(uint? value, CancellationToken cancellationToken = default); // 0x00000001816D6BE0-0x00000001816D6CC0
		[CLSCompliant(false)]
		public virtual Task WriteValueAsync(ulong value, CancellationToken cancellationToken = default); // 0x00000001816D6F70-0x00000001816D7050
		[CLSCompliant(false)]
		public virtual Task WriteValueAsync(ulong? value, CancellationToken cancellationToken = default); // 0x00000001816D5AF0-0x00000001816D5BE0
		public virtual Task WriteValueAsync([Nullable(2)] Uri value, CancellationToken cancellationToken = default); // 0x00000001816D5840-0x00000001816D5920
		[CLSCompliant(false)]
		public virtual Task WriteValueAsync(ushort value, CancellationToken cancellationToken = default); // 0x00000001816D5680-0x00000001816D5760
		[CLSCompliant(false)]
		public virtual Task WriteValueAsync(ushort? value, CancellationToken cancellationToken = default); // 0x00000001816D5760-0x00000001816D5840
		public virtual Task WriteUndefinedAsync(CancellationToken cancellationToken = default); // 0x00000001816D53B0-0x00000001816D5480
		public virtual Task WriteWhitespaceAsync(string ws, CancellationToken cancellationToken = default); // 0x00000001816DA090-0x00000001816DA170
		internal Task InternalWriteValueAsync(JsonToken token, CancellationToken cancellationToken); // 0x00000001816D14E0-0x00000001816D15A0
		protected Task SetWriteStateAsync(JsonToken token, object value, CancellationToken cancellationToken); // 0x00000001816D1AC0-0x00000001816D1E30
		internal static Task WriteValueAsync(JsonWriter writer, PrimitiveTypeCode typeCode, object value, CancellationToken cancellationToken); // 0x00000001816D7300-0x00000001816D8480
		internal static State[][] BuildStateArray(); // 0x00000001816D0790-0x00000001816D0960
		internal virtual void OnStringEscapeHandlingChanged(); // 0x00000001802E76C0-0x00000001802E76D0
		internal void UpdateScopeWithFinishedValue(); // 0x00000001816D2610-0x00000001816D2620
		private void Push(JsonContainerType value); // 0x00000001816D17D0-0x00000001816D1940
		private JsonContainerType Pop(); // 0x00000001816D1700-0x00000001816D17D0
		private JsonContainerType Peek(); // 0x0000000180B23260-0x0000000180B23270
		public abstract void Flush();
		public virtual void Close(); // 0x00000001816D0BF0-0x00000001816D0C40
		public virtual void WriteStartObject(); // 0x00000001816D39D0-0x00000001816D39E0
		public virtual void WriteEndObject(); // 0x00000001816D2E90-0x00000001816D2EA0
		public virtual void WriteStartArray(); // 0x00000001816D3800-0x00000001816D3810
		public virtual void WriteEndArray(); // 0x00000001816D29A0-0x00000001816D29B0
		public virtual void WriteStartConstructor(string name); // 0x00000001816D38F0-0x00000001816D3900
		public virtual void WriteEndConstructor(); // 0x00000001816D2C30-0x00000001816D2C40
		public virtual void WritePropertyName(string name); // 0x00000001816D1220-0x00000001816D1250
		public virtual void WritePropertyName(string name, bool escape); // 0x00000001816D3500-0x00000001816D3520
		public virtual void WriteEnd(); // 0x00000001816D2EA0-0x00000001816D2FA0
		public void WriteToken(JsonReader reader); // 0x00000001816D4A90-0x00000001816D4AA0
		public void WriteToken(JsonReader reader, bool writeChildren); // 0x00000001816D5320-0x00000001816D53B0
		[NullableContext(2)]
		public void WriteToken(JsonToken token, object value); // 0x00000001816D4AB0-0x00000001816D5320
		public void WriteToken(JsonToken token); // 0x00000001816D4AA0-0x00000001816D4AB0
		internal virtual void WriteToken(JsonReader reader, bool writeChildren, bool writeDateConstructorAsDate, bool writeComments); // 0x00000001816D4710-0x00000001816D4A90
		private bool IsWriteTokenIncomplete(JsonReader reader, bool writeChildren, int initialDepth); // 0x00000001816D1620-0x00000001816D1700
		private int CalculateWriteTokenInitialDepth(JsonReader reader); // 0x00000001816D0AB0-0x00000001816D0B20
		private int CalculateWriteTokenFinalDepth(JsonReader reader); // 0x00000001816D0A40-0x00000001816D0AB0
		private void WriteConstructorDate(JsonReader reader); // 0x00000001816D2810-0x00000001816D28D0
		private void WriteEnd(JsonContainerType type); // 0x00000001816D2FA0-0x00000001816D3090
		private void AutoCompleteAll(); // 0x00000001816D0070-0x00000001816D00C0
		private JsonToken GetCloseTokenForType(JsonContainerType type); // 0x00000001816D0DE0-0x00000001816D0EA0
		private void AutoCompleteClose(JsonContainerType type); // 0x00000001816D04A0-0x00000001816D0560
		private int CalculateLevelsToComplete(JsonContainerType type); // 0x00000001816D0960-0x00000001816D0A40
		private void UpdateCurrentState(); // 0x00000001816D2540-0x00000001816D2610
		protected virtual void WriteEnd(JsonToken token); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void WriteIndent(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void WriteValueDelimiter(); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void WriteIndentSpace(); // 0x00000001802E76C0-0x00000001802E76D0
		internal void AutoComplete(JsonToken tokenBeingWritten); // 0x00000001816D0560-0x00000001816D0790
		public virtual void WriteNull(); // 0x00000001816D3300-0x00000001816D3320
		public virtual void WriteUndefined(); // 0x00000001816D5480-0x00000001816D54A0
		[NullableContext(2)]
		public virtual void WriteRaw(string json); // 0x00000001802E76C0-0x00000001802E76D0
		[NullableContext(2)]
		public virtual void WriteRawValue(string json); // 0x00000001816D36E0-0x00000001816D3730
		[NullableContext(2)]
		public virtual void WriteValue(string value); // 0x00000001816D8B00-0x00000001816D8B20
		public virtual void WriteValue(int value); // 0x00000001816D8930-0x00000001816D8950
		[CLSCompliant(false)]
		public virtual void WriteValue(uint value); // 0x00000001816D8930-0x00000001816D8950
		public virtual void WriteValue(long value); // 0x00000001816D8930-0x00000001816D8950
		[CLSCompliant(false)]
		public virtual void WriteValue(ulong value); // 0x00000001816D8930-0x00000001816D8950
		public virtual void WriteValue(float value); // 0x00000001816D8A30-0x00000001816D8A50
		public virtual void WriteValue(double value); // 0x00000001816D8A30-0x00000001816D8A50
		public virtual void WriteValue(bool value); // 0x00000001816D8B90-0x00000001816D8BB0
		public virtual void WriteValue(short value); // 0x00000001816D8930-0x00000001816D8950
		[CLSCompliant(false)]
		public virtual void WriteValue(ushort value); // 0x00000001816D8930-0x00000001816D8950
		public virtual void WriteValue(char value); // 0x00000001816D8B00-0x00000001816D8B20
		public virtual void WriteValue(byte value); // 0x00000001816D8930-0x00000001816D8950
		[CLSCompliant(false)]
		public virtual void WriteValue(sbyte value); // 0x00000001816D8930-0x00000001816D8950
		public virtual void WriteValue(decimal value); // 0x00000001816D8A30-0x00000001816D8A50
		public virtual void WriteValue(DateTime value); // 0x00000001816D8950-0x00000001816D8970
		public virtual void WriteValue(DateTimeOffset value); // 0x00000001816D8950-0x00000001816D8970
		public virtual void WriteValue(Guid value); // 0x00000001816D8B00-0x00000001816D8B20
		public virtual void WriteValue(TimeSpan value); // 0x00000001816D8B00-0x00000001816D8B20
		public virtual void WriteValue(int? value); // 0x00000001816D9FE0-0x00000001816DA010
		[CLSCompliant(false)]
		public virtual void WriteValue(uint? value); // 0x00000001816D8AD0-0x00000001816D8B00
		public virtual void WriteValue(long? value); // 0x00000001816D9D70-0x00000001816D9DB0
		[CLSCompliant(false)]
		public virtual void WriteValue(ulong? value); // 0x00000001816D8BB0-0x00000001816D8BF0
		public virtual void WriteValue(float? value); // 0x00000001816D8A50-0x00000001816D8A90
		public virtual void WriteValue(double? value); // 0x00000001816D8B20-0x00000001816D8B60
		public virtual void WriteValue(bool? value); // 0x00000001816D9F80-0x00000001816D9FB0
		public virtual void WriteValue(short? value); // 0x00000001816D8BF0-0x00000001816D8C20
		[CLSCompliant(false)]
		public virtual void WriteValue(ushort? value); // 0x00000001816DA060-0x00000001816DA090
		public virtual void WriteValue(char? value); // 0x00000001816D8900-0x00000001816D8930
		public virtual void WriteValue(byte? value); // 0x00000001816D8B60-0x00000001816D8B90
		[CLSCompliant(false)]
		public virtual void WriteValue(sbyte? value); // 0x00000001816D8A00-0x00000001816D8A30
		public virtual void WriteValue(decimal? value); // 0x00000001816D89B0-0x00000001816D8A00
		public virtual void WriteValue(DateTime? value); // 0x00000001816D8970-0x00000001816D89B0
		public virtual void WriteValue(DateTimeOffset? value); // 0x00000001816D8C20-0x00000001816D8C70
		public virtual void WriteValue(Guid? value); // 0x00000001816DA010-0x00000001816DA060
		public virtual void WriteValue(TimeSpan? value); // 0x00000001816D8A90-0x00000001816D8AD0
		[NullableContext(2)]
		public virtual void WriteValue(byte[] value); // 0x00000001816D9FB0-0x00000001816D9FE0
		[NullableContext(2)]
		public virtual void WriteValue(Uri value); // 0x00000001816D9DB0-0x00000001816D9E50
		[NullableContext(2)]
		public virtual void WriteValue(object value); // 0x00000001816D9E50-0x00000001816D9F80
		[NullableContext(2)]
		public virtual void WriteComment(string text); // 0x00000001816D0EB0-0x00000001816D0EC0
		public virtual void WriteWhitespace(string ws); // 0x00000001816D15C0-0x00000001816D1620
		void IDisposable.Dispose(); // 0x00000001816D2050-0x00000001816D20C0
		protected virtual void Dispose(bool disposing); // 0x00000001816D0CE0-0x00000001816D0D10
		internal static void WriteValue(JsonWriter writer, PrimitiveTypeCode typeCode, object value); // 0x00000001816D8C70-0x00000001816D9D70
		private static void ResolveConvertibleValue(IConvertible convertible, out PrimitiveTypeCode typeCode, out object value); // 0x00000001816D1940-0x00000001816D1AC0
		private static JsonWriterException CreateUnsupportedTypeException(JsonWriter writer, object value); // 0x00000001816D0C40-0x00000001816D0CE0
		protected void SetWriteState(JsonToken token, object value); // 0x00000001816D1E30-0x00000001816D2050
		internal void InternalWriteEnd(JsonContainerType container); // 0x00000001816D04A0-0x00000001816D0560
		internal void InternalWritePropertyName(string name); // 0x00000001816D1220-0x00000001816D1250
		internal void InternalWriteRaw(); // 0x00000001802E76C0-0x00000001802E76D0
		internal void InternalWriteStart(JsonToken token, JsonContainerType container); // 0x00000001816D1360-0x00000001816D14E0
		internal void InternalWriteValue(JsonToken token); // 0x00000001816D15A0-0x00000001816D15C0
		internal void InternalWriteWhitespace(string ws); // 0x00000001816D15C0-0x00000001816D1620
		internal void InternalWriteComment(); // 0x00000001816D0EB0-0x00000001816D0EC0
		[CompilerGenerated]
		private async Task _InternalWriteEndAsync_g__AwaitProperty_11_0(Task task, int LevelsToComplete, JsonToken token, CancellationToken CancellationToken); // 0x00000001816D2310-0x00000001816D2440
		[CompilerGenerated]
		private async Task _InternalWriteEndAsync_g__AwaitIndent_11_1(Task task, int LevelsToComplete, JsonToken token, CancellationToken CancellationToken); // 0x00000001816D21E0-0x00000001816D2310
		[CompilerGenerated]
		private async Task _InternalWriteEndAsync_g__AwaitEnd_11_2(Task task, int LevelsToComplete, CancellationToken CancellationToken); // 0x00000001816D20C0-0x00000001816D21E0
		[CompilerGenerated]
		private async Task _InternalWriteEndAsync_g__AwaitRemaining_11_3(int LevelsToComplete, CancellationToken CancellationToken); // 0x00000001816D2440-0x00000001816D2540
	}
}
