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
	public sealed class DynamicMethod : MethodInfo // TypeDefIndex: 3366
	{
		// Properties
		public override MethodAttributes Attributes { get; } // 0x0000000181527E30-0x0000000181527E70 
		public override CallingConventions CallingConvention { get; } // 0x0000000181527E70-0x0000000181527EB0 
		public override Type DeclaringType { get; } // 0x0000000181527EB0-0x0000000181527EF0 
		public override Module Module { get; } // 0x0000000181527F30-0x0000000181527F70 
		public override string Name { get; } // 0x0000000181527F70-0x0000000181527FB0 
		public override ParameterInfo ReturnParameter { get; } // 0x0000000181527FF0-0x0000000181528030 
		public override Type ReturnType { get; } // 0x0000000181528030-0x0000000181528070 
		public override RuntimeMethodHandle MethodHandle { get; } // 0x0000000181527EF0-0x0000000181527F30 
		public override Type ReflectedType { get; } // 0x0000000181527FB0-0x0000000181527FF0 
	
		// Constructors
		public DynamicMethod(string name, MethodAttributes attributes, CallingConventions callingConvention, Type returnType, Type[] parameterTypes, Module m, bool skipVisibility); // 0x0000000181527DE0-0x0000000181527E30
	
		// Methods
		public ILGenerator GetILGenerator(); // 0x0000000181527C60-0x0000000181527CA0
		public override ParameterInfo[] GetParameters(); // 0x0000000181527CE0-0x0000000181527D20
		public sealed override Delegate CreateDelegate(Type delegateType); // 0x0000000181527B60-0x0000000181527BA0
		public sealed override Delegate CreateDelegate(Type delegateType, object target); // 0x0000000181527B20-0x0000000181527B60
		public override object[] GetCustomAttributes(bool inherit); // 0x0000000181527C20-0x0000000181527C60
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x0000000181527BE0-0x0000000181527C20
		public override MethodImplAttributes GetMethodImplementationFlags(); // 0x0000000181527CA0-0x0000000181527CE0
		public override MethodInfo GetBaseDefinition(); // 0x0000000181527BA0-0x0000000181527BE0
		public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture); // 0x0000000181527D20-0x0000000181527D60
		public override bool IsDefined(Type attributeType, bool inherit); // 0x0000000181527D60-0x0000000181527DA0
		public override string ToString(); // 0x0000000181527DA0-0x0000000181527DE0
	}
}
