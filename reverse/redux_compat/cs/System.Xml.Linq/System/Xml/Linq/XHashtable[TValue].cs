/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 47: System.Xml.Linq.dll - Assembly: System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35 - Types 15375-15412

namespace System.Xml.Linq
{
	internal sealed class XHashtable<TValue> // TypeDefIndex: 15391
	{
		// Fields
		private XHashtableState _state;
	
		// Nested types
		public delegate string ExtractKeyDelegate(TValue value); // TypeDefIndex: 15392; 0x00000000-0x00000000
	
		private sealed class XHashtableState // TypeDefIndex: 15393
		{
			// Fields
			private int[] _buckets;
			private Entry[] _entries;
			private int _numEntries;
			private ExtractKeyDelegate<TValue> _extractKey;
	
			// Nested types
			private struct Entry // TypeDefIndex: 15394
			{
				// Fields
				public TValue Value;
				public int HashCode;
				public int Next;
			}
	
			// Constructors
			public XHashtableState(ExtractKeyDelegate<TValue> extractKey, int capacity);
	
			// Methods
			public XHashtableState<TValue> Resize();
			public bool TryGetValue(string key, int index, int count, out ref TValue value);
			public bool TryAdd(TValue value, out ref TValue newValue);
			private bool FindEntry(int hashCode, string key, int index, int count, ref int entryIndex);
			private static int ComputeHashCode(string key, int index, int count);
		}
	
		// Constructors
		public XHashtable(ExtractKeyDelegate extractKey, int capacity);
	
		// Methods
		public bool TryGetValue(string key, int index, int count, out ref TValue value);
		public TValue Add(TValue value);
	}
}
