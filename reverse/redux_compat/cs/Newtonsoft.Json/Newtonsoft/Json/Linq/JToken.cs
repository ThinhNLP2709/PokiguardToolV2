/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq.Expressions;
using System.Numerics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Linq
{
	[Nullable(0)]
	[NullableContext(1)]
	public abstract class JToken : IJEnumerable<JToken>, IJsonLineInfo, ICloneable, IDynamicMetaObjectProvider // TypeDefIndex: 10328
	{
		// Fields
		[Nullable(2)]
		private static JTokenEqualityComparer _equalityComparer; // 0x00
		[Nullable(2)]
		private JContainer _parent; // 0x10
		[Nullable(2)]
		private JToken _previous; // 0x18
		[Nullable(2)]
		private JToken _next; // 0x20
		[Nullable(2)]
		private object _annotations; // 0x28
		private static readonly JTokenType[] BooleanTypes; // 0x08
		private static readonly JTokenType[] NumberTypes; // 0x10
		private static readonly JTokenType[] BigIntegerTypes; // 0x18
		private static readonly JTokenType[] StringTypes; // 0x20
		private static readonly JTokenType[] GuidTypes; // 0x28
		private static readonly JTokenType[] TimeSpanTypes; // 0x30
		private static readonly JTokenType[] UriTypes; // 0x38
		private static readonly JTokenType[] CharTypes; // 0x40
		private static readonly JTokenType[] DateTimeTypes; // 0x48
		private static readonly JTokenType[] BytesTypes; // 0x50
	
		// Properties
		public static JTokenEqualityComparer EqualityComparer { get; } // 0x00000001817495E0-0x00000001817496A0 
		[Nullable(2)]
		public JContainer Parent { [NullableContext(2)] [DebuggerStepThrough] get; [NullableContext(2)] internal set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public JToken Root { get; } // 0x0000000181749B80-0x0000000181749BB0 
		public abstract JTokenType Type { get; }
		public abstract bool HasValues { get; }
		[Nullable(2)]
		public JToken Next { [NullableContext(2)] get; [NullableContext(2)] internal set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
		[Nullable(2)]
		public JToken Previous { [NullableContext(2)] get; [NullableContext(2)] internal set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public string Path { get; } // 0x00000001817498B0-0x0000000181749B80 
		[Nullable(2)]
		public virtual JToken this[object key] { get => default; set {} } // 0x0000000181749750-0x0000000181749800 0x0000000181750250-0x0000000181750300
		[Nullable(2)]
		public virtual JToken First { [NullableContext(2)] get; } // 0x00000001817496A0-0x0000000181749750 
		[Nullable(2)]
		public virtual JToken Last { [NullableContext(2)] get; } // 0x0000000181749800-0x00000001817498B0 
		IJEnumerable<JToken> Newtonsoft.Json.Linq.IJEnumerable<Newtonsoft.Json.Linq.JToken>.this[object key] { get => default; } // 0x00000001817465A0-0x00000001817465C0 
		int IJsonLineInfo.LineNumber { get; } // 0x0000000181746500-0x0000000181746550 
		int IJsonLineInfo.LinePosition { get; } // 0x0000000181746550-0x00000001817465A0 
	
		// Nested types
		[NullableContext(0)]
		private class LineInfoAnnotation // TypeDefIndex: 10329
		{
			// Fields
			internal readonly int LineNumber; // 0x10
			internal readonly int LinePosition; // 0x14
	
			// Constructors
			public LineInfoAnnotation(int lineNumber, int linePosition); // 0x0000000181750680-0x00000001817506C0
		}
	
		[CompilerGenerated]
		private sealed class _AfterSelf_d__49 : IEnumerable<JToken>, IEnumerator<JToken> // TypeDefIndex: 10330
		{
			// Fields
			private int __1__state; // 0x10
			private JToken __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			[Nullable(0)]
			public JToken __4__this; // 0x28
			[Nullable(0)]
			private JToken _o_5__2; // 0x30
	
			// Properties
			JToken IEnumerator<Newtonsoft.Json.Linq.JToken>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _AfterSelf_d__49(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x00000001817506C0-0x0000000181750760
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181750800-0x0000000181750840
			[DebuggerHidden]
			IEnumerator<JToken> IEnumerable<JToken>.GetEnumerator(); // 0x0000000181750760-0x0000000181750800
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181750760-0x0000000181750800
		}
	
		[CompilerGenerated]
		private sealed class _Annotations_d__185<T> : IEnumerable<T>, IEnumerator<T> // TypeDefIndex: 10331
			where T : class
		{
			// Fields
			private int __1__state;
			private T __2__current;
			private int __l__initialThreadId;
			[Nullable(0)]
			public JToken __4__this;
			[Nullable(new byte[2] {0, 1 })]
			private object[] _annotations_5__2;
			private int _i_5__3;
	
			// Properties
			T IEnumerator<T>.Current { [DebuggerHidden] get; }
			object IEnumerator.Current { [DebuggerHidden] get; }
	
			// Constructors
			[DebuggerHidden]
			public _Annotations_d__185(int __1__state);
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose();
			private bool MoveNext();
			[DebuggerHidden]
			void IEnumerator.Reset();
			[DebuggerHidden]
			IEnumerator<T> IEnumerable<T>.GetEnumerator();
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator();
		}
	
		[CompilerGenerated]
		private sealed class _Annotations_d__186 : IEnumerable<object>, IEnumerator<object> // TypeDefIndex: 10332
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			[Nullable(0)]
			private Type type; // 0x28
			[Nullable(0)]
			public Type __3__type; // 0x30
			[Nullable(0)]
			public JToken __4__this; // 0x38
			[Nullable(new byte[2] {0, 1 })]
			private object[] _annotations_5__2; // 0x40
			private int _i_5__3; // 0x48
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _Annotations_d__186(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x0000000181750840-0x0000000181750A70
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181750B20-0x0000000181750B60
			[DebuggerHidden]
			IEnumerator<object> IEnumerable<object>.GetEnumerator(); // 0x0000000181750A70-0x0000000181750B20
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181750A70-0x0000000181750B20
		}
	
		[CompilerGenerated]
		private sealed class _BeforeSelf_d__50 : IEnumerable<JToken>, IEnumerator<JToken> // TypeDefIndex: 10333
		{
			// Fields
			private int __1__state; // 0x10
			private JToken __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			[Nullable(0)]
			public JToken __4__this; // 0x28
			[Nullable(0)]
			private JToken _o_5__2; // 0x30
	
			// Properties
			JToken IEnumerator<Newtonsoft.Json.Linq.JToken>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _BeforeSelf_d__50(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x0000000181750B60-0x0000000181750C30
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181750CD0-0x0000000181750D10
			[DebuggerHidden]
			IEnumerator<JToken> IEnumerable<JToken>.GetEnumerator(); // 0x0000000181750C30-0x0000000181750CD0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181750C30-0x0000000181750CD0
		}
	
		[CompilerGenerated]
		private sealed class _GetAncestors_d__48 : IEnumerable<JToken>, IEnumerator<JToken> // TypeDefIndex: 10334
		{
			// Fields
			private int __1__state; // 0x10
			private JToken __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			private bool self; // 0x24
			public bool __3__self; // 0x25
			[Nullable(0)]
			public JToken __4__this; // 0x28
			[Nullable(0)]
			private JToken _current_5__2; // 0x30
	
			// Properties
			JToken IEnumerator<Newtonsoft.Json.Linq.JToken>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _GetAncestors_d__48(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x00000001817512B0-0x0000000181751350
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181751400-0x0000000181751440
			[DebuggerHidden]
			IEnumerator<JToken> IEnumerable<JToken>.GetEnumerator(); // 0x0000000181751350-0x0000000181751400
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181751350-0x0000000181751400
		}
	
		[CompilerGenerated]
		private struct _ReadFromAsync_d__3 : IAsyncStateMachine // TypeDefIndex: 10335
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<JToken> __t__builder; // 0x08
			[Nullable(0)]
			public JsonReader reader; // 0x20
			[Nullable(0)]
			public JsonLoadSettings settings; // 0x28
			public CancellationToken cancellationToken; // 0x30
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x38
			[Nullable(new byte[2] {0, 1 })]
			private ConfiguredTaskAwaitable<JObject> __u__2; // 0x48
			[Nullable(new byte[2] {0, 1 })]
			private ConfiguredTaskAwaitable<JArray> __u__3; // 0x58
			[Nullable(new byte[2] {0, 1 })]
			private ConfiguredTaskAwaitable<JConstructor> __u__4; // 0x68
			[Nullable(new byte[2] {0, 1 })]
			private ConfiguredTaskAwaitable<JProperty> __u__5; // 0x78
	
			// Methods
			private void MoveNext(); // 0x0000000181753CA0-0x00000001817545A0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001817545A0-0x0000000181754600
		}
	
		// Constructors
		internal JToken(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static JToken(); // 0x0000000181749200-0x00000001817495E0
	
		// Methods
		public virtual Task WriteToAsync(JsonWriter writer, CancellationToken cancellationToken, params JsonConverter[] converters); // 0x0000000181749190-0x00000001817491D0
		public Task WriteToAsync(JsonWriter writer, params JsonConverter[] converters); // 0x00000001817491D0-0x0000000181749200
		public static Task<JToken> ReadFromAsync(JsonReader reader, CancellationToken cancellationToken = default); // 0x0000000181746900-0x0000000181746960
		public static async Task<JToken> ReadFromAsync(JsonReader reader, [Nullable(2)] JsonLoadSettings settings, CancellationToken cancellationToken = default); // 0x00000001817467D0-0x0000000181746900
		public static Task<JToken> LoadAsync(JsonReader reader, CancellationToken cancellationToken = default); // 0x0000000181746330-0x00000001817463D0
		public static Task<JToken> LoadAsync(JsonReader reader, [Nullable(2)] JsonLoadSettings settings, CancellationToken cancellationToken = default); // 0x00000001817462C0-0x0000000181746330
		internal abstract JToken CloneToken([Nullable(2)] JsonCloneSettings settings);
		internal abstract bool DeepEquals(JToken node);
		[NullableContext(2)]
		public static bool DeepEquals(JToken t1, JToken t2); // 0x0000000181745D30-0x0000000181745D60
		[NullableContext(2)]
		public void AddAfterSelf(object content); // 0x0000000181745440-0x00000001817454F0
		[NullableContext(2)]
		public void AddBeforeSelf(object content); // 0x00000001817457B0-0x0000000181745860
		public IEnumerable<JToken> Ancestors(); // 0x00000001817458F0-0x0000000181745900
		public IEnumerable<JToken> AncestorsAndSelf(); // 0x00000001817458E0-0x00000001817458F0
		[IteratorStateMachine(typeof(_GetAncestors_d__48))]
		internal IEnumerable<JToken> GetAncestors(bool self); // 0x00000001817460B0-0x0000000181746140
		[IteratorStateMachine(typeof(_AfterSelf_d__49))]
		public IEnumerable<JToken> AfterSelf(); // 0x0000000181745860-0x00000001817458E0
		[IteratorStateMachine(typeof(_BeforeSelf_d__50))]
		public IEnumerable<JToken> BeforeSelf(); // 0x0000000181745B10-0x0000000181745B90
		[NullableContext(2)]
		public virtual T Value<T>([Nullable(1)] object key);
		public virtual JEnumerable<JToken> Children(); // 0x0000000181745B90-0x0000000181745BE0
		[NullableContext(0)]
		public JEnumerable<T> Children<T>()
			where T : JToken;
		[NullableContext(2)]
		public virtual IEnumerable<T> Values<T>();
		public void Remove(); // 0x0000000181746FC0-0x0000000181747040
		public void Replace(JToken value); // 0x0000000181747040-0x00000001817470C0
		public abstract void WriteTo(JsonWriter writer, params JsonConverter[] converters);
		public override string ToString(); // 0x0000000181748E70-0x0000000181748EF0
		public string ToString(Formatting formatting, params JsonConverter[] converters); // 0x0000000181748EF0-0x00000001817490B0
		private static JValue EnsureValue(JToken value); // 0x0000000181745D60-0x0000000181745E80
		private static string GetType(JToken token); // 0x00000001817461E0-0x00000001817462C0
		private static bool ValidateToken(JToken o, JTokenType[] validTypes, bool nullable); // 0x00000001817490B0-0x0000000181749190
		public static explicit operator bool(JToken value); // 0x000000018174C2D0-0x000000018174C530
		public static explicit operator DateTimeOffset(JToken value); // 0x000000018174AEE0-0x000000018174B170
		[NullableContext(2)]
		public static explicit operator bool?(JToken value); // 0x000000018174DA00-0x000000018174DC70
		public static explicit operator long(JToken value); // 0x000000018174E590-0x000000018174E7D0
		[NullableContext(2)]
		public static explicit operator DateTime?(JToken value); // 0x000000018174D540-0x000000018174D760
		[NullableContext(2)]
		public static explicit operator DateTimeOffset?(JToken value); // 0x000000018174ABD0-0x000000018174AEE0
		[NullableContext(2)]
		public static explicit operator decimal?(JToken value); // 0x000000018174D030-0x000000018174D2E0
		[NullableContext(2)]
		public static explicit operator double?(JToken value); // 0x000000018174EE80-0x000000018174F0C0
		[NullableContext(2)]
		public static explicit operator char?(JToken value); // 0x000000018174B3B0-0x000000018174B600
		public static explicit operator int(JToken value); // 0x000000018174BDE0-0x000000018174C020
		public static explicit operator short(JToken value); // 0x000000018174C730-0x000000018174C970
		[CLSCompliant(false)]
		public static explicit operator ushort(JToken value); // 0x000000018174DC70-0x000000018174DEB0
		[CLSCompliant(false)]
		public static explicit operator char(JToken value); // 0x000000018174DEB0-0x000000018174E0F0
		public static explicit operator byte(JToken value); // 0x000000018174F0C0-0x000000018174F300
		[CLSCompliant(false)]
		public static explicit operator sbyte(JToken value); // 0x000000018174CBB0-0x000000018174CDF0
		[NullableContext(2)]
		public static explicit operator int?(JToken value); // 0x000000018174D2E0-0x000000018174D540
		[NullableContext(2)]
		public static explicit operator short?(JToken value); // 0x000000018174B930-0x000000018174BB80
		[CLSCompliant(false)]
		[NullableContext(2)]
		public static explicit operator ushort?(JToken value); // 0x000000018174E0F0-0x000000018174E340
		[NullableContext(2)]
		public static explicit operator byte?(JToken value); // 0x000000018174A4F0-0x000000018174A740
		[CLSCompliant(false)]
		[NullableContext(2)]
		public static explicit operator sbyte?(JToken value); // 0x000000018174E340-0x000000018174E590
		public static explicit operator DateTime(JToken value); // 0x000000018174A9A0-0x000000018174ABD0
		[NullableContext(2)]
		public static explicit operator long?(JToken value); // 0x000000018174CDF0-0x000000018174D030
		[NullableContext(2)]
		public static explicit operator float?(JToken value); // 0x000000018174A050-0x000000018174A2B0
		public static explicit operator decimal(JToken value); // 0x0000000181749DF0-0x000000018174A050
		[CLSCompliant(false)]
		[NullableContext(2)]
		public static explicit operator uint?(JToken value); // 0x000000018174BB80-0x000000018174BDE0
		[CLSCompliant(false)]
		[NullableContext(2)]
		public static explicit operator ulong?(JToken value); // 0x000000018174C970-0x000000018174CBB0
		public static explicit operator double(JToken value); // 0x000000018174EA00-0x000000018174EC40
		public static explicit operator float(JToken value); // 0x000000018174B170-0x000000018174B3B0
		[NullableContext(2)]
		public static explicit operator string(JToken value); // 0x000000018174D760-0x000000018174DA00
		[CLSCompliant(false)]
		public static explicit operator uint(JToken value); // 0x000000018174A2B0-0x000000018174A4F0
		[CLSCompliant(false)]
		public static explicit operator ulong(JToken value); // 0x0000000181749BB0-0x0000000181749DF0
		[NullableContext(2)]
		public static explicit operator byte[](JToken value); // 0x000000018174B600-0x000000018174B930
		public static explicit operator Guid(JToken value); // 0x000000018174A740-0x000000018174A9A0
		[NullableContext(2)]
		public static explicit operator Guid?(JToken value); // 0x000000018174C020-0x000000018174C2D0
		public static explicit operator TimeSpan(JToken value); // 0x000000018174EC40-0x000000018174EE80
		[NullableContext(2)]
		public static explicit operator TimeSpan?(JToken value); // 0x000000018174E7D0-0x000000018174EA00
		[NullableContext(2)]
		public static explicit operator Uri(JToken value); // 0x000000018174C530-0x000000018174C730
		private static BigInteger ToBigInteger(JToken value); // 0x0000000181747960-0x0000000181747B10
		private static BigInteger? ToBigIntegerNullable(JToken value); // 0x0000000181747710-0x0000000181747960
		public static implicit operator JToken(bool value); // 0x000000018174FB40-0x000000018174FBA0
		public static implicit operator JToken(DateTimeOffset value); // 0x000000018174F460-0x000000018174F4C0
		public static implicit operator JToken(byte value); // 0x000000018174FF50-0x000000018174FFB0
		public static implicit operator JToken(byte? value); // 0x000000018174FFB0-0x0000000181750030
		[CLSCompliant(false)]
		public static implicit operator JToken(sbyte value); // 0x000000018174F5C0-0x000000018174F620
		[CLSCompliant(false)]
		public static implicit operator JToken(sbyte? value); // 0x000000018174F360-0x000000018174F3E0
		public static implicit operator JToken(bool? value); // 0x000000018174F4C0-0x000000018174F540
		public static implicit operator JToken(long value); // 0x000000018174FAE0-0x000000018174FB40
		public static implicit operator JToken(DateTime? value); // 0x000000018174F950-0x000000018174F9D0
		public static implicit operator JToken(DateTimeOffset? value); // 0x000000018174FE60-0x000000018174FEF0
		public static implicit operator JToken(decimal? value); // 0x000000018174F620-0x000000018174F6B0
		public static implicit operator JToken(double? value); // 0x000000018174FD20-0x000000018174FDA0
		[CLSCompliant(false)]
		public static implicit operator JToken(short value); // 0x000000018174FCC0-0x000000018174FD20
		[CLSCompliant(false)]
		public static implicit operator JToken(ushort value); // 0x000000018174F300-0x000000018174F360
		public static implicit operator JToken(int value); // 0x000000018174FEF0-0x000000018174FF50
		public static implicit operator JToken(int? value); // 0x000000018174F790-0x000000018174F810
		public static implicit operator JToken(DateTime value); // 0x000000018174F810-0x000000018174F870
		public static implicit operator JToken(long? value); // 0x00000001817501D0-0x0000000181750250
		public static implicit operator JToken(float? value); // 0x000000018174F8D0-0x000000018174F950
		public static implicit operator JToken(decimal value); // 0x0000000181750030-0x0000000181750090
		[CLSCompliant(false)]
		public static implicit operator JToken(short? value); // 0x000000018174F710-0x000000018174F790
		[CLSCompliant(false)]
		public static implicit operator JToken(ushort? value); // 0x000000018174F540-0x000000018174F5C0
		[CLSCompliant(false)]
		public static implicit operator JToken(uint? value); // 0x000000018174F3E0-0x000000018174F460
		[CLSCompliant(false)]
		public static implicit operator JToken(ulong? value); // 0x000000018174FA60-0x000000018174FAE0
		public static implicit operator JToken(double value); // 0x000000018174F870-0x000000018174F8D0
		public static implicit operator JToken(float value); // 0x000000018174FDA0-0x000000018174FE00
		public static implicit operator JToken([Nullable(2)] string value); // 0x000000018174FC60-0x000000018174FCC0
		[CLSCompliant(false)]
		public static implicit operator JToken(uint value); // 0x000000018174FC00-0x000000018174FC60
		[CLSCompliant(false)]
		public static implicit operator JToken(ulong value); // 0x000000018174FE00-0x000000018174FE60
		public static implicit operator JToken(byte[] value); // 0x000000018174F6B0-0x000000018174F710
		public static implicit operator JToken([Nullable(2)] Uri value); // 0x000000018174FBA0-0x000000018174FC00
		public static implicit operator JToken(TimeSpan value); // 0x0000000181750170-0x00000001817501D0
		public static implicit operator JToken(TimeSpan? value); // 0x00000001817500F0-0x0000000181750170
		public static implicit operator JToken(Guid value); // 0x0000000181750090-0x00000001817500F0
		public static implicit operator JToken(Guid? value); // 0x000000018174F9D0-0x000000018174FA60
		IEnumerator IEnumerable.GetEnumerator(); // 0x00000001817476B0-0x00000001817476F0
		IEnumerator<JToken> IEnumerable<JToken>.GetEnumerator(); // 0x0000000181747620-0x00000001817476B0
		internal abstract int GetDeepHashCode();
		public JsonReader CreateReader(); // 0x0000000181745C90-0x0000000181745CF0
		internal static JToken FromObjectInternal(object o, JsonSerializer jsonSerializer); // 0x0000000181745E80-0x0000000181745FF0
		public static JToken FromObject(object o); // 0x0000000181745FF0-0x0000000181746050
		public static JToken FromObject(object o, JsonSerializer jsonSerializer); // 0x0000000181746050-0x00000001817460B0
		[NullableContext(2)]
		public T ToObject<T>();
		public object ToObject(Type objectType); // 0x0000000181747D30-0x0000000181748E70
		[NullableContext(2)]
		public T ToObject<T>([Nullable(1)] JsonSerializer jsonSerializer);
		[NullableContext(2)]
		public object ToObject(Type objectType, [Nullable(1)] JsonSerializer jsonSerializer); // 0x0000000181747B10-0x0000000181747D30
		public static JToken ReadFrom(JsonReader reader); // 0x0000000181746CD0-0x0000000181746D20
		public static JToken ReadFrom(JsonReader reader, [Nullable(2)] JsonLoadSettings settings); // 0x0000000181746960-0x0000000181746CD0
		public static JToken Parse(string json); // 0x0000000181746780-0x00000001817467D0
		public static JToken Parse(string json, [Nullable(2)] JsonLoadSettings settings); // 0x00000001817465C0-0x0000000181746780
		public static JToken Load(JsonReader reader, [Nullable(2)] JsonLoadSettings settings); // 0x0000000181746460-0x00000001817464C0
		public static JToken Load(JsonReader reader); // 0x00000001817463D0-0x0000000181746460
		[NullableContext(2)]
		internal void SetLineInfo(IJsonLineInfo lineInfo, JsonLoadSettings settings); // 0x0000000181747530-0x0000000181747620
		internal void SetLineInfo(int lineNumber, int linePosition); // 0x00000001817474B0-0x0000000181747530
		bool IJsonLineInfo.HasLineInfo(); // 0x00000001817464C0-0x0000000181746500
		public JToken SelectToken(string path); // 0x00000001817472E0-0x00000001817472F0
		public JToken SelectToken(string path, bool errorWhenNoMatch); // 0x00000001817472F0-0x0000000181747380
		[NullableContext(2)]
		public JToken SelectToken([Nullable(1)] string path, JsonSelectSettings settings); // 0x00000001817470C0-0x00000001817472E0
		public IEnumerable<JToken> SelectTokens(string path); // 0x0000000181747380-0x0000000181747390
		public IEnumerable<JToken> SelectTokens(string path, bool errorWhenNoMatch); // 0x0000000181747390-0x0000000181747420
		public IEnumerable<JToken> SelectTokens(string path, [Nullable(2)] JsonSelectSettings settings); // 0x0000000181747420-0x00000001817474B0
		protected virtual DynamicMetaObject GetMetaObject(Expression parameter); // 0x0000000181746140-0x00000001817461E0
		DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter); // 0x00000001817476F0-0x0000000181747710
		object ICloneable.Clone(); // 0x0000000181745D10-0x0000000181745D30
		public JToken DeepClone(); // 0x0000000181745D10-0x0000000181745D30
		public JToken DeepClone(JsonCloneSettings settings); // 0x0000000181745CF0-0x0000000181745D10
		public void AddAnnotation(object annotation); // 0x00000001817454F0-0x00000001817457B0
		public T Annotation<T>()
			where T : class;
		public object Annotation(Type type); // 0x0000000181745900-0x0000000181745A80
		[IteratorStateMachine(typeof(_Annotations_d__185<T>))]
		public IEnumerable<T> Annotations<T>()
			where T : class;
		[IteratorStateMachine(typeof(_Annotations_d__186))]
		public IEnumerable<object> Annotations(Type type); // 0x0000000181745A80-0x0000000181745B10
		public void RemoveAnnotations<T>()
			where T : class;
		public void RemoveAnnotations(Type type); // 0x0000000181746D20-0x0000000181746FC0
		internal void CopyAnnotations(JToken target, JToken source); // 0x0000000181745BE0-0x0000000181745C90
	}
}
