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
	public class JProperty : JContainer // TypeDefIndex: 10315
	{
		// Fields
		private readonly JPropertyList _content; // 0x58
		private readonly string _name; // 0x60
	
		// Properties
		protected override IList<JToken> ChildrenTokens { get; } // 0x00000001802F4000-0x00000001802F4010 
		public string Name { [DebuggerStepThrough] get; } // 0x0000000180333260-0x0000000180333490 
		public JToken Value { [DebuggerStepThrough] get; set; } // 0x0000000181744FA0-0x0000000181744FC0 0x0000000181744FC0-0x0000000181745050
		public override JTokenType Type { [DebuggerStepThrough] get; } // 0x00000001804CB980-0x00000001804CB990 
	
		// Nested types
		[Nullable(0)]
		private class JPropertyList : IList<JToken> // TypeDefIndex: 10316
		{
			// Fields
			[Nullable(2)]
			internal JToken _token; // 0x10
	
			// Properties
			public int Count { get; } // 0x00000001817438A0-0x00000001817438B0 
			public bool IsReadOnly { get; } // 0x00000001802E7840-0x00000001802E7850 
			public JToken this[int index] { get => default; set {} } // 0x00000001817438B0-0x0000000181743910 0x0000000181743910-0x0000000181743970
	
			// Nested types
			[CompilerGenerated]
			private sealed class _GetEnumerator_d__1 : IEnumerator<JToken> // TypeDefIndex: 10317
			{
				// Fields
				private int __1__state; // 0x10
				private JToken __2__current; // 0x18
				[Nullable(0)]
				public JPropertyList __4__this; // 0x20
	
				// Properties
				JToken IEnumerator<Newtonsoft.Json.Linq.JToken>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
				object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
				// Constructors
				[DebuggerHidden]
				public _GetEnumerator_d__1(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
				// Methods
				[DebuggerHidden]
				void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
				private bool MoveNext(); // 0x0000000181751B70-0x0000000181751BE0
				[DebuggerHidden]
				void IEnumerator.Reset(); // 0x0000000181751BE0-0x0000000181751C20
			}
	
			// Constructors
			public JPropertyList(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[IteratorStateMachine(typeof(_GetEnumerator_d__1))]
			public IEnumerator<JToken> GetEnumerator(); // 0x00000001817437B0-0x0000000181743820
			IEnumerator IEnumerable.GetEnumerator(); // 0x00000001817437B0-0x0000000181743820
			public void Add(JToken item); // 0x00000001803780D0-0x00000001803780E0
			public void Clear(); // 0x0000000181547240-0x0000000181547260
			public bool Contains(JToken item); // 0x0000000181743720-0x0000000181743730
			public void CopyTo(JToken[] array, int arrayIndex); // 0x0000000181743730-0x00000001817437B0
			public bool Remove(JToken item); // 0x0000000181743870-0x00000001817438A0
			public int IndexOf(JToken item); // 0x0000000181743820-0x0000000181743830
			public void Insert(int index, JToken item); // 0x0000000181743830-0x0000000181743850
			public void RemoveAt(int index); // 0x0000000181743850-0x0000000181743870
		}
	
		[CompilerGenerated]
		private struct _LoadAsync_d__4 : IAsyncStateMachine // TypeDefIndex: 10318
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<JProperty> __t__builder; // 0x08
			[Nullable(0)]
			public JsonReader reader; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			public JsonLoadSettings settings; // 0x30
			[Nullable(0)]
			private JProperty _p_5__2; // 0x38
			[Nullable(0)]
			private ConfiguredTaskAwaitable<bool> __u__1; // 0x40
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__2; // 0x50
	
			// Methods
			private void MoveNext(); // 0x0000000181752C70-0x0000000181753250
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x0000000181753250-0x00000001817532B0
		}
	
		[CompilerGenerated]
		private struct _WriteToAsync_d__1 : IAsyncStateMachine // TypeDefIndex: 10319
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Task task; // 0x20
			[Nullable(0)]
			public JProperty __4__this; // 0x28
			[Nullable(0)]
			public JsonWriter writer; // 0x30
			public CancellationToken cancellationToken; // 0x38
			[Nullable(new byte[2] {0, 1 })]
			public JsonConverter[] converters; // 0x40
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x48
	
			// Methods
			private void MoveNext(); // 0x00000001817555E0-0x00000001817558B0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001817558B0-0x0000000181755E80
		}
	
		// Constructors
		public JProperty(JProperty other); // 0x0000000181744BD0-0x0000000181744C70
		internal JProperty(JProperty other, [Nullable(2)] JsonCloneSettings settings); // 0x0000000181744C70-0x0000000181744D20
		internal JProperty(string name); // 0x0000000181744D20-0x0000000181744E00
		public JProperty(string name, params object[] content); // 0x0000000181744BC0-0x0000000181744BD0
		public JProperty(string name, [Nullable(2)] object content); // 0x0000000181744E00-0x0000000181744FA0
	
		// Methods
		public override Task WriteToAsync(JsonWriter writer, CancellationToken cancellationToken, params JsonConverter[] converters); // 0x00000001817448B0-0x0000000181744AB0
		private async Task WriteToAsync(Task task, JsonWriter writer, CancellationToken cancellationToken, params JsonConverter[] converters); // 0x0000000181744780-0x00000001817448B0
		private Task WriteValueAsync(JsonWriter writer, CancellationToken cancellationToken, JsonConverter[] converters); // 0x0000000181744B50-0x0000000181744BC0
		public static new Task<JProperty> LoadAsync(JsonReader reader, CancellationToken cancellationToken = default); // 0x0000000181743F70-0x0000000181743F80
		public static new async Task<JProperty> LoadAsync(JsonReader reader, [Nullable(2)] JsonLoadSettings settings, CancellationToken cancellationToken = default); // 0x0000000181743E40-0x0000000181743F70
		internal override JToken GetItem(int index); // 0x0000000181743C60-0x0000000181743CD0
		[NullableContext(2)]
		internal override void SetItem(int index, JToken item); // 0x0000000181744490-0x0000000181744780
		[NullableContext(2)]
		internal override bool RemoveItem(JToken item); // 0x00000001817443B0-0x0000000181744490
		internal override void RemoveItemAt(int index); // 0x00000001817442D0-0x00000001817443B0
		[NullableContext(2)]
		internal override int IndexOfItem(JToken item); // 0x0000000181743CD0-0x0000000181743D10
		[NullableContext(2)]
		internal override bool InsertItem(int index, JToken item, bool skipParentCheck, bool copyAnnotations); // 0x0000000181743D10-0x0000000181743E40
		[NullableContext(2)]
		internal override bool ContainsItem(JToken item); // 0x0000000181743B20-0x0000000181743B40
		internal override void MergeItem(object content, [Nullable(2)] JsonMergeSettings settings); // 0x00000001817441C0-0x00000001817442D0
		internal override void ClearItems(); // 0x0000000181743970-0x0000000181743A50
		internal override bool DeepEquals(JToken node); // 0x0000000181743B40-0x0000000181743BE0
		internal override JToken CloneToken([Nullable(2)] JsonCloneSettings settings); // 0x0000000181743A50-0x0000000181743B20
		public override void WriteTo(JsonWriter writer, params JsonConverter[] converters); // 0x0000000181744AB0-0x0000000181744B50
		internal override int GetDeepHashCode(); // 0x0000000181743BE0-0x0000000181743C60
		public static new JProperty Load(JsonReader reader); // 0x0000000181743F80-0x0000000181743F90
		public static new JProperty Load(JsonReader reader, [Nullable(2)] JsonLoadSettings settings); // 0x0000000181743F90-0x00000001817441C0
	}
}
