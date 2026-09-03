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
	public sealed class GenericTypeParameterBuilder : TypeInfo // TypeDefIndex: 3370
	{
		// Properties
		public override Assembly Assembly { get; } // 0x000000018152A500-0x000000018152A540 
		public override string AssemblyQualifiedName { get; } // 0x000000018152A4C0-0x000000018152A500 
		public override Type BaseType { get; } // 0x000000018152A540-0x000000018152A580 
		public override string FullName { get; } // 0x000000018152A580-0x000000018152A5C0 
		public override Guid GUID { get; } // 0x000000018152A5C0-0x000000018152A600 
		public override Module Module { get; } // 0x000000018152A600-0x000000018152A640 
		public override string Name { get; } // 0x000000018152A640-0x000000018152A680 
		public override string Namespace { get; } // 0x000000018152A680-0x000000018152A6C0 
		public override Type UnderlyingSystemType { get; } // 0x000000018152A6C0-0x000000018152A700 
	
		// Methods
		protected override TypeAttributes GetAttributeFlagsImpl(); // 0x0000000181529E80-0x0000000181529EC0
		protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers); // 0x0000000181529EC0-0x0000000181529F00
		[ComVisible(true)]
		public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr); // 0x0000000181529F00-0x0000000181529F40
		public override object[] GetCustomAttributes(bool inherit); // 0x0000000181529F80-0x0000000181529FC0
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x0000000181529F40-0x0000000181529F80
		public override Type GetElementType(); // 0x0000000181529FC0-0x000000018152A000
		public override EventInfo GetEvent(string name, BindingFlags bindingAttr); // 0x000000018152A000-0x000000018152A040
		public override EventInfo[] GetEvents(BindingFlags bindingAttr); // 0x000000018152A040-0x000000018152A080
		public override FieldInfo GetField(string name, BindingFlags bindingAttr); // 0x000000018152A080-0x000000018152A0C0
		public override FieldInfo[] GetFields(BindingFlags bindingAttr); // 0x000000018152A0C0-0x000000018152A100
		public override Type[] GetInterfaces(); // 0x000000018152A100-0x000000018152A140
		public override MemberInfo[] GetMembers(BindingFlags bindingAttr); // 0x000000018152A140-0x000000018152A180
		protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers); // 0x000000018152A180-0x000000018152A1C0
		public override MethodInfo[] GetMethods(BindingFlags bindingAttr); // 0x000000018152A1C0-0x000000018152A200
		public override Type GetNestedType(string name, BindingFlags bindingAttr); // 0x000000018152A200-0x000000018152A240
		public override PropertyInfo[] GetProperties(BindingFlags bindingAttr); // 0x000000018152A240-0x000000018152A280
		protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers); // 0x000000018152A280-0x000000018152A2C0
		protected override bool HasElementTypeImpl(); // 0x000000018152A2C0-0x000000018152A300
		public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters); // 0x000000018152A300-0x000000018152A340
		protected override bool IsArrayImpl(); // 0x000000018152A340-0x000000018152A380
		protected override bool IsByRefImpl(); // 0x000000018152A380-0x000000018152A3C0
		protected override bool IsCOMObjectImpl(); // 0x000000018152A3C0-0x000000018152A400
		public override bool IsDefined(Type attributeType, bool inherit); // 0x000000018152A400-0x000000018152A440
		protected override bool IsPointerImpl(); // 0x000000018152A440-0x000000018152A480
		protected override bool IsPrimitiveImpl(); // 0x000000018152A480-0x000000018152A4C0
	}
}
