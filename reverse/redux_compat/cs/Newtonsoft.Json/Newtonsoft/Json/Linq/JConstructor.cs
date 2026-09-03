/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	public class JConstructor : JContainer // TypeDefIndex: 10300
	{
		// Fields
		[Nullable(2)]
		private string _name; // 0x58
		private readonly List<JToken> _values; // 0x60
	
		// Properties
		protected override IList<JToken> ChildrenTokens { get; } // 0x0000000180333260-0x0000000180333490 
		[Nullable(2)]
		public string Name { [NullableContext(2)] get; [NullableContext(2)] set; } // 0x00000001802F4000-0x00000001802F4010 0x00000001802F4050-0x00000001802F4060
		public override JTokenType Type { get; } // 0x000000018071E4A0-0x000000018071E4B0 
		[Nullable(2)]
		public override JToken this[object key] { get => default; set {} } // 0x0000000181739C90-0x0000000181739DB0 0x0000000181739DB0-0x0000000181739EE0
	
		// Nested types
		[CompilerGenerated]
		private struct _LoadAsync_d__2 : IAsyncStateMachine // TypeDefIndex: 10301
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<JConstructor> __t__builder; // 0x08
			[Nullable(0)]
			public JsonReader reader; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			public JsonLoadSettings settings; // 0x30
			[Nullable(0)]
			private JConstructor _c_5__2; // 0x38
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x40
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x50
	
			// Methods
			private void MoveNext(); // 0x00000001817525D0-0x0000000181752BB0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x0000000181752C10-0x0000000181752C70
		}
	
		[CompilerGenerated]
		private struct _WriteToAsync_d__0 : IAsyncStateMachine // TypeDefIndex: 10302
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonWriter writer; // 0x20
			[Nullable(0)]
			public JConstructor __4__this; // 0x28
			public CancellationToken cancellationToken; // 0x30
			[Nullable(new byte[2] {0, 1 })]
			public JsonConverter[] converters; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
			private int _i_5__2; // 0x50
	
			// Methods
			private void MoveNext(); // 0x0000000181755150-0x0000000181755580
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x0000000181755580-0x00000001817555E0
		}
	
		// Constructors
		public JConstructor(); // 0x0000000181739BE0-0x0000000181739C90
		public JConstructor(JConstructor other); // 0x00000001817398F0-0x00000001817399A0
		internal JConstructor(JConstructor other, [Nullable(2)] JsonCloneSettings settings); // 0x0000000181739B20-0x0000000181739BE0
		public JConstructor(string name, params object[] content); // 0x00000001817398B0-0x00000001817398F0
		public JConstructor(string name, object content); // 0x00000001817398B0-0x00000001817398F0
		public JConstructor(string name); // 0x00000001817399A0-0x0000000181739B20
	
		// Methods
		public override async Task WriteToAsync(JsonWriter writer, CancellationToken cancellationToken, params JsonConverter[] converters); // 0x00000001817396A0-0x00000001817397D0
		public static new Task<JConstructor> LoadAsync(JsonReader reader, CancellationToken cancellationToken = default); // 0x00000001817393B0-0x00000001817393C0
		public static new async Task<JConstructor> LoadAsync(JsonReader reader, [Nullable(2)] JsonLoadSettings settings, CancellationToken cancellationToken = default); // 0x0000000181739280-0x00000001817393B0
		[NullableContext(2)]
		internal override int IndexOfItem(JToken item); // 0x0000000181739260-0x0000000181739280
		internal override void MergeItem(object content, [Nullable(2)] JsonMergeSettings settings); // 0x0000000181739600-0x00000001817396A0
		internal override bool DeepEquals(JToken node); // 0x0000000181739170-0x0000000181739210
		internal override JToken CloneToken([Nullable(2)] JsonCloneSettings settings = null); // 0x0000000181739090-0x0000000181739170
		public override void WriteTo(JsonWriter writer, params JsonConverter[] converters); // 0x00000001817397D0-0x00000001817398B0
		internal override int GetDeepHashCode(); // 0x0000000181739210-0x0000000181739260
		public static new JConstructor Load(JsonReader reader); // 0x00000001817393C0-0x00000001817393D0
		public static new JConstructor Load(JsonReader reader, [Nullable(2)] JsonLoadSettings settings); // 0x00000001817393D0-0x0000000181739600
	}
}
