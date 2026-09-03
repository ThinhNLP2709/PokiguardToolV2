/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[DebuggerDisplay("Item count = {m_Count}")]
	internal struct TextProcessingStack<T> // TypeDefIndex: 12721
	{
		// Fields
		public T[] itemStack;
		public int index;
		private T m_DefaultItem;
		private int m_Capacity;
		private int m_RolloverSize;
		private int m_Count;
	
		// Properties
		public int Count { get; }
		public T current { get; }
	
		// Constructors
		public TextProcessingStack(T[] stack);
		public TextProcessingStack(int capacity);
		public TextProcessingStack(int capacity, int rolloverSize);
	
		// Methods
		internal static void SetDefault(TextProcessingStack<T>[] stack, T item);
		public void Clear();
		public void SetDefault(T item);
		public void Add(T item);
		public T Remove();
		public void Push(T item);
		public T Pop();
		public T Peek();
		public T CurrentItem();
	}
}
