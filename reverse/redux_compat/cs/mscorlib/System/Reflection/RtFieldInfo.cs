/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Reflection
{
	internal abstract class RtFieldInfo : FieldInfo // TypeDefIndex: 3350
	{
		// Constructors
		protected RtFieldInfo(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal abstract object UnsafeGetValue(object obj);
		internal abstract void UnsafeSetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture);
		internal abstract void CheckConsistency(object target);
	}
}
