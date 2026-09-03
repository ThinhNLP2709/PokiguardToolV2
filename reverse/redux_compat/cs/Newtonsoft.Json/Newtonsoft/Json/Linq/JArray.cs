/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
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
	public class JArray : JContainer, IList<JToken> // TypeDefIndex: 10297
	{
		// Fields
		private readonly List<JToken> _values; // 0x58
	
		// Properties
		protected override IList<JToken> ChildrenTokens { get; } // 0x00000001802F4000-0x00000001802F4010 
		public override JTokenType Type { get; } // 0x0000000180476390-0x00000001804763A0 
		[Nullable(2)]
		public override JToken this[object key] { get => default; set {} } // 0x000000018171F860-0x000000018171F980 0x000000018171F9C0-0x000000018171FAF0
		public JToken this[int index] { get => default; set {} } // 0x000000018171F980-0x000000018171F9A0 0x000000018171F9A0-0x000000018171F9C0
		public bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
	
		// Nested types
		[CompilerGenerated]
		private struct _LoadAsync_d__2 : IAsyncStateMachine // TypeDefIndex: 10298
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<JArray> __t__builder; // 0x08
			[Nullable(0)]
			public JsonReader reader; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			public JsonLoadSettings settings; // 0x30
			[Nullable(0)]
			private JArray _a_5__2; // 0x38
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x40
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x50
	
			// Methods
			private void MoveNext(); // 0x0000000181737B60-0x00000001817380F0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001817380F0-0x0000000181738150
		}
	
		[CompilerGenerated]
		private struct _WriteToAsync_d__0 : IAsyncStateMachine // TypeDefIndex: 10299
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public JsonWriter writer; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			public JArray __4__this; // 0x30
			[Nullable(new byte[2] {0, 1 })]
			public JsonConverter[] converters; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
			private int _i_5__2; // 0x50
	
			// Methods
			private void MoveNext(); // 0x0000000181738A00-0x0000000181738E10
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x0000000181738E10-0x0000000181738E70
		}
	
		// Constructors
		public JArray(); // 0x000000018171F610-0x000000018171F690
		public JArray(JArray other); // 0x000000018171F730-0x000000018171F7C0
		internal JArray(JArray other, [Nullable(2)] JsonCloneSettings settings); // 0x000000018171F7C0-0x000000018171F860
		public JArray(params object[] content); // 0x000000018171F690-0x000000018171F730
		public JArray(object content); // 0x000000018171F690-0x000000018171F730
	
		// Methods
		public override async Task WriteToAsync(JsonWriter writer, CancellationToken cancellationToken, params JsonConverter[] converters); // 0x000000018171F410-0x000000018171F540
		public static new Task<JArray> LoadAsync(JsonReader reader, CancellationToken cancellationToken = default); // 0x000000018171ED30-0x000000018171EE50
		public static new async Task<JArray> LoadAsync(JsonReader reader, [Nullable(2)] JsonLoadSettings settings, CancellationToken cancellationToken = default); // 0x000000018171EE50-0x000000018171EF80
		internal override bool DeepEquals(JToken node); // 0x000000018171E880-0x000000018171E910
		internal override JToken CloneToken([Nullable(2)] JsonCloneSettings settings = null); // 0x000000018171E770-0x000000018171E840
		public static new JArray Load(JsonReader reader); // 0x000000018171F160-0x000000018171F170
		public static new JArray Load(JsonReader reader, [Nullable(2)] JsonLoadSettings settings); // 0x000000018171EF80-0x000000018171F160
		public static new JArray Parse(string json); // 0x000000018171F3C0-0x000000018171F3D0
		public static new JArray Parse(string json, [Nullable(2)] JsonLoadSettings settings); // 0x000000018171F260-0x000000018171F3C0
		public static new JArray FromObject(object o); // 0x000000018171E910-0x000000018171EAA0
		public static new JArray FromObject(object o, JsonSerializer jsonSerializer); // 0x000000018171EAA0-0x000000018171EC20
		public override void WriteTo(JsonWriter writer, params JsonConverter[] converters); // 0x000000018171F540-0x000000018171F610
		[NullableContext(2)]
		internal override int IndexOfItem(JToken item); // 0x000000018171ECC0-0x000000018171ECE0
		internal override void MergeItem(object content, [Nullable(2)] JsonMergeSettings settings); // 0x000000018171F170-0x000000018171F260
		public int IndexOf(JToken item); // 0x000000018171ECE0-0x000000018171ED00
		public void Insert(int index, JToken item); // 0x000000018171ED00-0x000000018171ED30
		public void RemoveAt(int index); // 0x000000018171F3D0-0x000000018171F3F0
		public IEnumerator<JToken> GetEnumerator(); // 0x000000018171EC30-0x000000018171ECC0
		public void Add(JToken item); // 0x000000018171E730-0x000000018171E750
		public void Clear(); // 0x000000018171E750-0x000000018171E770
		public bool Contains(JToken item); // 0x000000018171E840-0x000000018171E860
		public void CopyTo(JToken[] array, int arrayIndex); // 0x000000018171E860-0x000000018171E880
		public bool Remove(JToken item); // 0x000000018171F3F0-0x000000018171F410
		internal override int GetDeepHashCode(); // 0x000000018171EC20-0x000000018171EC30
	}
}
