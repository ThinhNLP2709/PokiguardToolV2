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
	public class ConstructorBuilder : ConstructorInfo // TypeDefIndex: 3365
	{
		// Properties
		public override MethodAttributes Attributes { get; } // 0x0000000181524CE0-0x0000000181524D20 
		public override Type DeclaringType { get; } // 0x0000000181524D20-0x0000000181524D60 
		public override string Name { get; } // 0x0000000181524DA0-0x0000000181524DE0 
		public override RuntimeMethodHandle MethodHandle { get; } // 0x0000000181524D60-0x0000000181524DA0 
		public override Type ReflectedType { get; } // 0x0000000181524DE0-0x0000000181524E20 
	
		// Methods
		public override ParameterInfo[] GetParameters(); // 0x0000000181524BE0-0x0000000181524C20
		public override MethodImplAttributes GetMethodImplementationFlags(); // 0x0000000181524BA0-0x0000000181524BE0
		public override object Invoke(BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture); // 0x0000000181524C60-0x0000000181524CA0
		public override bool IsDefined(Type attributeType, bool inherit); // 0x0000000181524CA0-0x0000000181524CE0
		public override object[] GetCustomAttributes(bool inherit); // 0x0000000181524B20-0x0000000181524B60
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x0000000181524B60-0x0000000181524BA0
		public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture); // 0x0000000181524C20-0x0000000181524C60
	}
}
