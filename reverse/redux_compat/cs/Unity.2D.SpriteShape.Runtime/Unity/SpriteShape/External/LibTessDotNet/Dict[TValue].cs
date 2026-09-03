/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace Unity.SpriteShape.External.LibTessDotNet
{
	internal class Dict<TValue> // TypeDefIndex: 13960
		where TValue : class
	{
		// Fields
		private LessOrEqual _leq;
		private Node _head;
	
		// Nested types
		public class Node // TypeDefIndex: 13961
		{
			// Fields
			internal TValue _key;
			internal Node<TValue> _prev;
			internal Node<TValue> _next;
	
			// Properties
			public TValue Key { get; }
			public Node<TValue> Prev { get; }
			public Node<TValue> Next { get; }
	
			// Constructors
			public Node();
		}
	
		public delegate bool LessOrEqual(TValue lhs, TValue rhs); // TypeDefIndex: 13962; 0x00000000-0x00000000
	
		// Constructors
		public Dict(LessOrEqual leq);
	
		// Methods
		public Node Insert(TValue key);
		public Node InsertBefore(Node node, TValue key);
		public Node Find(TValue key);
		public Node Min();
		public void Remove(Node node);
	}
}
