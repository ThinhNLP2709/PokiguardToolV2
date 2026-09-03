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

namespace System.Reflection.Emit
{
	public sealed class MethodBuilder : MethodInfo // TypeDefIndex: 3373
	{
		// Properties
		public override MethodAttributes Attributes { get; } // 0x000000018152D0C0-0x000000018152D100 
		public override Type DeclaringType { get; } // 0x000000018152D100-0x000000018152D140 
		public override RuntimeMethodHandle MethodHandle { get; } // 0x000000018152D140-0x000000018152D180 
		public override string Name { get; } // 0x000000018152D180-0x000000018152D1C0 
		public override Type ReflectedType { get; } // 0x000000018152D1C0-0x000000018152D200 
	
		// Methods
		public override MethodInfo GetBaseDefinition(); // 0x000000018152CF00-0x000000018152CF40
		public override object[] GetCustomAttributes(bool inherit); // 0x000000018152CF40-0x000000018152CF80
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x000000018152CF80-0x000000018152CFC0
		public override MethodImplAttributes GetMethodImplementationFlags(); // 0x000000018152CFC0-0x000000018152D000
		public override ParameterInfo[] GetParameters(); // 0x000000018152D000-0x000000018152D040
		public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture); // 0x000000018152D040-0x000000018152D080
		public override bool IsDefined(Type attributeType, bool inherit); // 0x000000018152D080-0x000000018152D0C0
	}
}
