/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class ThreadSafeStore<TKey, TValue> // TypeDefIndex: 10188
	{
		// Fields
		private readonly ConcurrentDictionary<TKey, TValue> _concurrentStore;
		private readonly Func<TKey, TValue> _creator;
	
		// Constructors
		public ThreadSafeStore(Func<TKey, TValue> creator);
	
		// Methods
		public TValue Get(TKey key);
	}
}
