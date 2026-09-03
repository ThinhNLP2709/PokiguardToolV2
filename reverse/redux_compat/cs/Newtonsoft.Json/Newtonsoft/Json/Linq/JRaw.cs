/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
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
	public class JRaw : JValue // TypeDefIndex: 10322
	{
		// Nested types
		[CompilerGenerated]
		private struct _CreateAsync_d__0 : IAsyncStateMachine // TypeDefIndex: 10323
		{
			// Fields
			public int __1__state; // 0x00
			[Nullable(0)]
			public AsyncTaskMethodBuilder<JRaw> __t__builder; // 0x08
			[Nullable(0)]
			public JsonReader reader; // 0x20
			public CancellationToken cancellationToken; // 0x28
			[Nullable(0)]
			private StringWriter _sw_5__2; // 0x30
			[Nullable(0)]
			private JsonTextWriter _jsonWriter_5__3; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x0000000181750D10-0x0000000181751250
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x0000000181751250-0x00000001817512B0
		}
	
		// Constructors
		public JRaw(JRaw other); // 0x0000000181745420-0x0000000181745430
		internal JRaw(JRaw other, [Nullable(2)] JsonCloneSettings settings); // 0x0000000181745430-0x0000000181745440
		[NullableContext(2)]
		public JRaw(object rawJson); // 0x0000000181745410-0x0000000181745420
	
		// Methods
		public static async Task<JRaw> CreateAsync(JsonReader reader, CancellationToken cancellationToken = default); // 0x00000001817450C0-0x00000001817451C0
		public static JRaw Create(JsonReader reader); // 0x00000001817451C0-0x0000000181745410
		internal override JToken CloneToken([Nullable(2)] JsonCloneSettings settings); // 0x0000000181745050-0x00000001817450C0
	}
}
