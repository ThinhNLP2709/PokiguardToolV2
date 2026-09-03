/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	internal sealed class UnsafeRingQueueDebugView<T> // TypeDefIndex: 11739
		where T : struct
	{
		// Fields
		private UnsafeRingQueue<T> Data;
	
		// Properties
		public T[] Items { get; }
	
		// Constructors
		public UnsafeRingQueueDebugView(UnsafeRingQueue<T> data);
	}
}
