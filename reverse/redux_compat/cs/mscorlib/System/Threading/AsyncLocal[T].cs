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
	public sealed class AsyncLocal<T> : IAsyncLocal // TypeDefIndex: 2524
	{
		// Fields
		private readonly Action<AsyncLocalValueChangedArgs<T>> m_valueChangedHandler;
	
		// Properties
		public T Value { get; set; }
	
		// Constructors
		public AsyncLocal();
	
		// Methods
		void IAsyncLocal.OnValueChanged(object previousValueObj, object currentValueObj, bool contextChanged);
	}
}
