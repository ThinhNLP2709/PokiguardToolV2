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

namespace System
{
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_Activator))]
	[ComVisible(true)]
	public sealed class Activator // TypeDefIndex: 2410
	{
		// Methods
		public static object CreateInstance(Type type, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture); // 0x000000018162AEF0-0x000000018162AF20
		public static object CreateInstance(Type type, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes); // 0x000000018162AF60-0x000000018162B170
		public static object CreateInstance(Type type, params object[] args); // 0x000000018162B170-0x000000018162B1A0
		public static object CreateInstance(Type type, object[] args, object[] activationAttributes); // 0x000000018162AF20-0x000000018162AF50
		public static object CreateInstance(Type type); // 0x000000018162B1A0-0x000000018162B1B0
		public static object CreateInstance(Type type, bool nonPublic); // 0x000000018162AF50-0x000000018162AF60
		internal static object CreateInstance(Type type, bool nonPublic, bool wrapExceptions); // 0x000000018162AD60-0x000000018162AEF0
		public static T CreateInstance<T>();
	}
}
