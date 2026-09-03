/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace Unity.SpriteShape.External.LibTessDotNet
{
	internal class PriorityQueue<TValue> // TypeDefIndex: 13976
		where TValue : class
	{
		// Fields
		private PriorityHeap<TValue> _leq;
		private PriorityHeap<TValue> _heap;
		private TValue[] _keys;
		private int[] _order;
		private int _size;
		private int _max;
		private bool _initialized;
	
		// Properties
		public bool Empty { get; }
	
		// Nested types
		private class StackItem // TypeDefIndex: 13977
		{
			// Fields
			internal int p;
			internal int r;
	
			// Constructors
			public StackItem();
		}
	
		// Constructors
		public PriorityQueue(int initialSize, PriorityHeap<TValue> leq);
	
		// Methods
		private static void Swap(ref int a, ref int b);
		public void Init();
		public PQHandle Insert(TValue value);
		public TValue ExtractMin();
		public TValue Minimum();
		public void Remove(PQHandle handle);
	}
}
