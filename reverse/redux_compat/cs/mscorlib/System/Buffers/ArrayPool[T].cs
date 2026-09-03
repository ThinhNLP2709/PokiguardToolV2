/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Buffers
{
	public abstract class ArrayPool<T> // TypeDefIndex: 3623
	{
		// Fields
		[CompilerGenerated]
		private static readonly ArrayPool<T> _Shared_k__BackingField;
	
		// Properties
		public static ArrayPool<T> Shared { [CompilerGenerated] get; }
	
		// Constructors
		protected ArrayPool();
		static ArrayPool();
	
		// Methods
		public abstract T[] Rent(int minimumLength);
		public abstract void Return(T[] array, bool clearArray = false /* Metadata: 0x0064F091 */);
	}
}
