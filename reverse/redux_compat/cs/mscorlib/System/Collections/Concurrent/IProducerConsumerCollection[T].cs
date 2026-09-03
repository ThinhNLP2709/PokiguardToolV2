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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.Concurrent
{
	public interface IProducerConsumerCollection<T> : IEnumerable<T>, ICollection // TypeDefIndex: 3549
	{
		// Methods
		bool TryAdd(T item);
		bool TryTake(out ref T item);
		T[] ToArray();
	}
}
