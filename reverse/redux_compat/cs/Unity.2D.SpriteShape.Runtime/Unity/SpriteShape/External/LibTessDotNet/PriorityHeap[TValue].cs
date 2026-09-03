/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace Unity.SpriteShape.External.LibTessDotNet
{
	internal class PriorityHeap<TValue> // TypeDefIndex: 13973
		where TValue : class
	{
		// Fields
		private LessOrEqual _leq;
		private int[] _nodes;
		private HandleElem[] _handles;
		private int _size;
		private int _max;
		private int _freeList;
		private bool _initialized;
	
		// Properties
		public bool Empty { get; }
	
		// Nested types
		public delegate bool LessOrEqual(TValue lhs, TValue rhs); // TypeDefIndex: 13974; 0x00000000-0x00000000
	
		protected class HandleElem // TypeDefIndex: 13975
		{
			// Fields
			internal TValue _key;
			internal int _node;
	
			// Constructors
			public HandleElem();
		}
	
		// Constructors
		public PriorityHeap(int initialSize, LessOrEqual leq);
	
		// Methods
		private void FloatDown(int curr);
		private void FloatUp(int curr);
		public void Init();
		public PQHandle Insert(TValue value);
		public TValue ExtractMin();
		public TValue Minimum();
		public void Remove(PQHandle handle);
	}
}
