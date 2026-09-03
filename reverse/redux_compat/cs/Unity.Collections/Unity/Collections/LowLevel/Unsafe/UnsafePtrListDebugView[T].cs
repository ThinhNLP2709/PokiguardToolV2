/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 12: Unity.Collections.dll - Assembly: Unity.Collections, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11420-11764

namespace Unity.Collections.LowLevel.Unsafe
{
	internal sealed class UnsafePtrListDebugView<T> // TypeDefIndex: 11711
		where T : struct
	{
		// Fields
		private UnsafePtrList<T> Data;
	
		// Properties
		public unsafe T*[] Items { get; }
	
		// Constructors
		public UnsafePtrListDebugView(UnsafePtrList<T> data);
	}
}
