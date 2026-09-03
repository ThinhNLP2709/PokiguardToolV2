/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Collections.Generic
{
	public sealed class LinkedListNode<T> // TypeDefIndex: 8975
	{
		// Fields
		internal LinkedList<T> list;
		internal LinkedListNode<T> next;
		internal LinkedListNode<T> prev;
		internal T item;
	
		// Properties
		public LinkedListNode<T> Next { get; }
		public LinkedListNode<T> Previous { get; }
		public T Value { get; set; }
	
		// Constructors
		public LinkedListNode(T value);
		internal LinkedListNode(LinkedList<T> list, T value);
	
		// Methods
		internal void Invalidate();
	}
}
