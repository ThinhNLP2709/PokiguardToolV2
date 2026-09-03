/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections
{
	public interface INativeList<T> : IIndexable<T> // TypeDefIndex: 11571
		where T : struct
	{
		// Properties
		int Capacity { get; set; }
		bool IsEmpty { get; }
		T this[int index] { get => default; set {} }
	
		// Methods
		void Clear();
	}
}
