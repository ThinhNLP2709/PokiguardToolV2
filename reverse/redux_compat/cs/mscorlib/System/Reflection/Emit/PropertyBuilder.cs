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
	public sealed class PropertyBuilder : PropertyInfo // TypeDefIndex: 3379
	{
		// Properties
		public override bool CanRead { get; } // 0x0000000181552510-0x0000000181552550 
		public override bool CanWrite { get; } // 0x0000000181552550-0x0000000181552590 
		public override Type DeclaringType { get; } // 0x0000000181552590-0x00000001815525D0 
		public override string Name { get; } // 0x00000001815525D0-0x0000000181552610 
		public override Type PropertyType { get; } // 0x0000000181552610-0x0000000181552650 
		public override Type ReflectedType { get; } // 0x0000000181552650-0x0000000181552690 
	
		// Methods
		public override object[] GetCustomAttributes(bool inherit); // 0x0000000181552350-0x0000000181552390
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x0000000181552310-0x0000000181552350
		public override MethodInfo GetGetMethod(bool nonPublic); // 0x0000000181552390-0x00000001815523D0
		public override ParameterInfo[] GetIndexParameters(); // 0x00000001815523D0-0x0000000181552410
		public override MethodInfo GetSetMethod(bool nonPublic); // 0x0000000181552410-0x0000000181552450
		public override object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture); // 0x0000000181552450-0x0000000181552490
		public override bool IsDefined(Type attributeType, bool inherit); // 0x0000000181552490-0x00000001815524D0
		public override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture); // 0x00000001815524D0-0x0000000181552510
	}
}
