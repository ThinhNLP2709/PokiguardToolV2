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

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal static class AsyncUtils // TypeDefIndex: 10091
	{
		// Fields
		public static readonly Task<bool> False; // 0x00
		public static readonly Task<bool> True; // 0x08
		internal static readonly Task CompletedTask; // 0x10
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 10092
		{
			// Fields
			[Nullable(0)]
			public static readonly __c __9; // 0x00
			[Nullable(0)]
			public static Action __9__5_0; // 0x08
	
			// Constructors
			static __c(); // 0x00000001816FB7B0-0x00000001816FB820
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _FromCanceled_b__5_0(); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c__6<T> // TypeDefIndex: 10093
		{
			// Fields
			[Nullable(0)]
			public static readonly __c__6<T> __9;
			[Nullable(0)]
			public static Func<T> __9__6_0;
	
			// Constructors
			static __c__6();
			public __c__6();
	
			// Methods
			[NullableContext(0)]
			internal T _FromCanceled_b__6_0();
		}
	
		// Constructors
		static AsyncUtils(); // 0x00000001816E1F80-0x00000001816E2080
	
		// Extension methods
		internal static Task<bool> ToAsync(this bool value); // 0x00000001816E1C90-0x00000001816E1D20
		[NullableContext(2)]
		public static Task CancelIfRequestedAsync(this CancellationToken cancellationToken); // 0x00000001816E19D0-0x00000001816E1A60
		[NullableContext(2)]
		public static Task<T> CancelIfRequestedAsync<T>(this CancellationToken cancellationToken);
		public static Task FromCanceled(this CancellationToken cancellationToken); // 0x00000001816E1A60-0x00000001816E1B70
		public static Task<T> FromCanceled<T>(this CancellationToken cancellationToken);
		public static Task WriteAsync(this TextWriter writer, char value, CancellationToken cancellationToken); // 0x00000001816E1EC0-0x00000001816E1F80
		public static Task WriteAsync(this TextWriter writer, [Nullable(2)] string value, CancellationToken cancellationToken); // 0x00000001816E1D20-0x00000001816E1DE0
		public static Task WriteAsync(this TextWriter writer, char[] value, int start, int count, CancellationToken cancellationToken); // 0x00000001816E1DE0-0x00000001816E1EC0
		public static Task<int> ReadAsync(this TextReader reader, char[] buffer, int index, int count, CancellationToken cancellationToken); // 0x00000001816E1BA0-0x00000001816E1C90
		public static bool IsCompletedSuccessfully(this Task task); // 0x00000001816E1B70-0x00000001816E1BA0
	}
}
