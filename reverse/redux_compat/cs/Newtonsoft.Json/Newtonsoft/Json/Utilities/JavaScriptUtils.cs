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

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal static class JavaScriptUtils // TypeDefIndex: 10152
	{
		// Fields
		internal static readonly bool[] SingleQuoteCharEscapeFlags; // 0x00
		internal static readonly bool[] DoubleQuoteCharEscapeFlags; // 0x08
		internal static readonly bool[] HtmlCharEscapeFlags; // 0x10
		private const int UnicodeTextLength = 6; // Metadata: 0x006A0D6D
		private const string EscapedUnicodeText = "!"; // Metadata: 0x006A0D6E
	
		// Nested types
		[CompilerGenerated]
		private struct _WriteCharAsync_d__14 : IAsyncStateMachine // TypeDefIndex: 10153
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Task task; // 0x20
			[Nullable(0)]
			public TextWriter writer; // 0x28
			public char c; // 0x30
			public CancellationToken cancellationToken; // 0x38
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x40
	
			// Methods
			private void MoveNext(); // 0x00000001816FB820-0x00000001816FBAB0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816FBAB0-0x00000001816FBB10
		}
	
		[CompilerGenerated]
		private struct _WriteDefinitelyEscapedJavaScriptStringWithoutDelimitersAsync_d__16 : IAsyncStateMachine // TypeDefIndex: 10154
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public char[] writeBuffer; // 0x20
			public int lastWritePosition; // 0x28
			[Nullable(0)]
			public JsonTextWriter client; // 0x30
			[Nullable(0)]
			public string s; // 0x38
			[Nullable(0)]
			public TextWriter writer; // 0x40
			public CancellationToken cancellationToken; // 0x48
			[Nullable(0)]
			public bool[] charEscapeFlags; // 0x50
			public StringEscapeHandling stringEscapeHandling; // 0x58
			private bool _isEscapedUnicodeText_5__2; // 0x5C
			[Nullable(0)]
			private string _escapedValue_5__3; // 0x60
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x68
			private int _i_5__4; // 0x78
	
			// Methods
			private void MoveNext(); // 0x00000001816FC1A0-0x00000001816FCD30
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816FCD30-0x00000001816FCD90
		}
	
		[CompilerGenerated]
		private struct _WriteEscapedJavaScriptStringWithDelimitersAsync_d__13 : IAsyncStateMachine // TypeDefIndex: 10155
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Task task; // 0x20
			[Nullable(0)]
			public string s; // 0x28
			[Nullable(0)]
			public TextWriter writer; // 0x30
			[Nullable(0)]
			public bool[] charEscapeFlags; // 0x38
			public StringEscapeHandling stringEscapeHandling; // 0x40
			[Nullable(0)]
			public JsonTextWriter client; // 0x48
			[Nullable(0)]
			public char[] writeBuffer; // 0x50
			public CancellationToken cancellationToken; // 0x58
			public char delimiter; // 0x60
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x68
	
			// Methods
			private void MoveNext(); // 0x00000001816FCD90-0x00000001816FD170
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816FD170-0x00000001816FD1D0
		}
	
		// Constructors
		static JavaScriptUtils(); // 0x00000001816F3710-0x00000001816F41B0
	
		// Methods
		public static bool[] GetCharEscapeFlags(StringEscapeHandling stringEscapeHandling, char quoteChar); // 0x00000001816F1970-0x00000001816F1A40
		public static bool ShouldEscapeJavaScriptString([Nullable(2)] string s, bool[] charEscapeFlags); // 0x00000001816F1A40-0x00000001816F1AD0
		[NullableContext(2)]
		public static void WriteEscapedJavaScriptString([Nullable(1)] TextWriter writer, string s, char delimiter, bool appendDelimiters, [Nullable(1)] bool[] charEscapeFlags, StringEscapeHandling stringEscapeHandling, IArrayPool<char> bufferPool, ref char[] writeBuffer); // 0x00000001816F2ED0-0x00000001816F3710
		public static string ToEscapedJavaScriptString([Nullable(2)] string value, char delimiter, bool appendDelimiters, StringEscapeHandling stringEscapeHandling); // 0x00000001816F1AD0-0x00000001816F1D10
		private static int FirstCharToEscape(string s, bool[] charEscapeFlags, StringEscapeHandling stringEscapeHandling); // 0x00000001816F18C0-0x00000001816F1970
		public static Task WriteEscapedJavaScriptStringAsync(TextWriter writer, string s, char delimiter, bool appendDelimiters, bool[] charEscapeFlags, StringEscapeHandling stringEscapeHandling, JsonTextWriter client, char[] writeBuffer, CancellationToken cancellationToken = default); // 0x00000001816F2540-0x00000001816F2790
		private static Task WriteEscapedJavaScriptStringWithDelimitersAsync(TextWriter writer, string s, char delimiter, bool[] charEscapeFlags, StringEscapeHandling stringEscapeHandling, JsonTextWriter client, char[] writeBuffer, CancellationToken cancellationToken); // 0x00000001816F2900-0x00000001816F2C60
		private static async Task WriteEscapedJavaScriptStringWithDelimitersAsync(Task task, TextWriter writer, string s, char delimiter, bool[] charEscapeFlags, StringEscapeHandling stringEscapeHandling, JsonTextWriter client, char[] writeBuffer, CancellationToken cancellationToken); // 0x00000001816F2790-0x00000001816F2900
		public static async Task WriteCharAsync(Task task, TextWriter writer, char c, CancellationToken cancellationToken); // 0x00000001816F22C0-0x00000001816F23E0
		private static Task WriteEscapedJavaScriptStringWithoutDelimitersAsync(TextWriter writer, string s, bool[] charEscapeFlags, StringEscapeHandling stringEscapeHandling, JsonTextWriter client, char[] writeBuffer, CancellationToken cancellationToken); // 0x00000001816F2C60-0x00000001816F2ED0
		private static async Task WriteDefinitelyEscapedJavaScriptStringWithoutDelimitersAsync(TextWriter writer, string s, int lastWritePosition, bool[] charEscapeFlags, StringEscapeHandling stringEscapeHandling, JsonTextWriter client, char[] writeBuffer, CancellationToken cancellationToken); // 0x00000001816F23E0-0x00000001816F2540
		public static bool TryGetDateFromConstructorJson(JsonReader reader, out DateTime dateTime, [Nullable(2)] [NotNullWhen(false)] out string errorMessage); // 0x00000001816F1ED0-0x00000001816F22C0
		private static bool TryGetDateConstructorValue(JsonReader reader, out long? integer, [Nullable(2)] [NotNullWhen(false)] out string errorMessage); // 0x00000001816F1D10-0x00000001816F1ED0
	}
}
