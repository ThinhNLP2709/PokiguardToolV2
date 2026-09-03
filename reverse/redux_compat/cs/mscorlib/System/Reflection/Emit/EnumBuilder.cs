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
	public sealed class EnumBuilder : TypeInfo // TypeDefIndex: 3367
	{
		// Properties
		public override Assembly Assembly { get; } // 0x00000001815286F0-0x0000000181528730 
		public override string AssemblyQualifiedName { get; } // 0x00000001815286B0-0x00000001815286F0 
		public override Type BaseType { get; } // 0x0000000181528730-0x0000000181528770 
		public override string FullName { get; } // 0x0000000181528770-0x00000001815287B0 
		public override Guid GUID { get; } // 0x00000001815287B0-0x00000001815287F0 
		public override Module Module { get; } // 0x00000001815287F0-0x0000000181528830 
		public override string Name { get; } // 0x0000000181528830-0x0000000181528870 
		public override string Namespace { get; } // 0x0000000181528870-0x00000001815288B0 
		public override Type UnderlyingSystemType { get; } // 0x00000001815288B0-0x00000001815288F0 
	
		// Methods
		protected override TypeAttributes GetAttributeFlagsImpl(); // 0x0000000181528070-0x00000001815280B0
		protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers); // 0x00000001815280B0-0x00000001815280F0
		[ComVisible(true)]
		public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr); // 0x00000001815280F0-0x0000000181528130
		public override object[] GetCustomAttributes(bool inherit); // 0x0000000181528170-0x00000001815281B0
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x0000000181528130-0x0000000181528170
		public override Type GetElementType(); // 0x00000001815281B0-0x00000001815281F0
		public override EventInfo GetEvent(string name, BindingFlags bindingAttr); // 0x00000001815281F0-0x0000000181528230
		public override EventInfo[] GetEvents(BindingFlags bindingAttr); // 0x0000000181528230-0x0000000181528270
		public override FieldInfo GetField(string name, BindingFlags bindingAttr); // 0x0000000181528270-0x00000001815282B0
		public override FieldInfo[] GetFields(BindingFlags bindingAttr); // 0x00000001815282B0-0x00000001815282F0
		public override Type[] GetInterfaces(); // 0x00000001815282F0-0x0000000181528330
		public override MemberInfo[] GetMembers(BindingFlags bindingAttr); // 0x0000000181528330-0x0000000181528370
		protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers); // 0x0000000181528370-0x00000001815283B0
		public override MethodInfo[] GetMethods(BindingFlags bindingAttr); // 0x00000001815283B0-0x00000001815283F0
		public override Type GetNestedType(string name, BindingFlags bindingAttr); // 0x00000001815283F0-0x0000000181528430
		public override PropertyInfo[] GetProperties(BindingFlags bindingAttr); // 0x0000000181528430-0x0000000181528470
		protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers); // 0x0000000181528470-0x00000001815284B0
		protected override bool HasElementTypeImpl(); // 0x00000001815284B0-0x00000001815284F0
		public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters); // 0x00000001815284F0-0x0000000181528530
		protected override bool IsArrayImpl(); // 0x0000000181528530-0x0000000181528570
		protected override bool IsByRefImpl(); // 0x0000000181528570-0x00000001815285B0
		protected override bool IsCOMObjectImpl(); // 0x00000001815285B0-0x00000001815285F0
		public override bool IsDefined(Type attributeType, bool inherit); // 0x00000001815285F0-0x0000000181528630
		protected override bool IsPointerImpl(); // 0x0000000181528630-0x0000000181528670
		protected override bool IsPrimitiveImpl(); // 0x0000000181528670-0x00000001815286B0
	}
}
