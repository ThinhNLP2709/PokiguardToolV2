/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Linq
{
	internal struct Buffer<TElement> // TypeDefIndex: 12014
	{
		// Fields
		internal TElement[] items;
		internal int count;
	
		// Constructors
		internal Buffer(IEnumerable<TElement> source);
	
		// Methods
		internal TElement[] ToArray();
	}
}
