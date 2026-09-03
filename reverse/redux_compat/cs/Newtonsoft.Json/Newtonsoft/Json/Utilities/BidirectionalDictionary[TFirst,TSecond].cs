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

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class BidirectionalDictionary<TFirst, TSecond> // TypeDefIndex: 10096
	{
		// Fields
		private readonly IDictionary<TFirst, TSecond> _firstToSecond;
		private readonly IDictionary<TSecond, TFirst> _secondToFirst;
		private readonly string _duplicateFirstErrorMessage;
		private readonly string _duplicateSecondErrorMessage;
	
		// Constructors
		public BidirectionalDictionary();
		public BidirectionalDictionary(IEqualityComparer<TFirst> firstEqualityComparer, IEqualityComparer<TSecond> secondEqualityComparer);
		public BidirectionalDictionary(IEqualityComparer<TFirst> firstEqualityComparer, IEqualityComparer<TSecond> secondEqualityComparer, string duplicateFirstErrorMessage, string duplicateSecondErrorMessage);
	
		// Methods
		public void Set(TFirst first, TSecond second);
		public bool TryGetByFirst(TFirst first, [Nullable(2)] [NotNullWhen(true)] out ref TSecond second);
		public bool TryGetBySecond(TSecond second, [Nullable(2)] [NotNullWhen(true)] out ref TFirst first);
	}
}
