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

namespace System.Threading
{
	[IsReadOnly]
	public struct AsyncLocalValueChangedArgs<T> // TypeDefIndex: 2526
	{
		// Fields
		[CompilerGenerated]
		private readonly T _PreviousValue_k__BackingField;
		[CompilerGenerated]
		private readonly T _CurrentValue_k__BackingField;
		[CompilerGenerated]
		private readonly bool _ThreadContextChanged_k__BackingField;
	
		// Constructors
		internal AsyncLocalValueChangedArgs(T previousValue, T currentValue, bool contextChanged);
	}
}
