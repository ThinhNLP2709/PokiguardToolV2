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
	public sealed class TypeBuilder : TypeInfo // TypeDefIndex: 3381
	{
		// Fields
		public const int UnspecifiedTypeSize = 0; // Metadata: 0x0064EDEE
	
		// Properties
		public override Assembly Assembly { get; } // 0x0000000181559CE0-0x0000000181559D20 
		public override string AssemblyQualifiedName { get; } // 0x0000000181559CA0-0x0000000181559CE0 
		public override Type BaseType { get; } // 0x0000000181559D20-0x0000000181559D60 
		public override string FullName { get; } // 0x0000000181559D60-0x0000000181559DA0 
		public override Guid GUID { get; } // 0x0000000181559DA0-0x0000000181559DE0 
		public override Module Module { get; } // 0x0000000181559DE0-0x0000000181559E20 
		public override string Name { get; } // 0x0000000181559E20-0x0000000181559E60 
		public override string Namespace { get; } // 0x0000000181559E60-0x0000000181559EA0 
		public override Type UnderlyingSystemType { get; } // 0x0000000181559EA0-0x0000000181559F30 
	
		// Methods
		protected override TypeAttributes GetAttributeFlagsImpl(); // 0x0000000181559660-0x00000001815596A0
		protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers); // 0x00000001815596A0-0x00000001815596E0
		[ComVisible(true)]
		public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr); // 0x00000001815596E0-0x0000000181559720
		public override object[] GetCustomAttributes(bool inherit); // 0x0000000181559720-0x0000000181559760
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x0000000181559760-0x00000001815597A0
		public override Type GetElementType(); // 0x00000001815597A0-0x00000001815597E0
		public override EventInfo GetEvent(string name, BindingFlags bindingAttr); // 0x00000001815597E0-0x0000000181559820
		public override EventInfo[] GetEvents(BindingFlags bindingAttr); // 0x0000000181559820-0x0000000181559860
		public override FieldInfo GetField(string name, BindingFlags bindingAttr); // 0x0000000181559860-0x00000001815598A0
		public override FieldInfo[] GetFields(BindingFlags bindingAttr); // 0x00000001815598A0-0x00000001815598E0
		public override Type[] GetInterfaces(); // 0x00000001815598E0-0x0000000181559920
		public override MemberInfo[] GetMembers(BindingFlags bindingAttr); // 0x0000000181559920-0x0000000181559960
		protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers); // 0x0000000181559960-0x00000001815599A0
		public override MethodInfo[] GetMethods(BindingFlags bindingAttr); // 0x00000001815599A0-0x00000001815599E0
		public override Type GetNestedType(string name, BindingFlags bindingAttr); // 0x00000001815599E0-0x0000000181559A20
		public override PropertyInfo[] GetProperties(BindingFlags bindingAttr); // 0x0000000181559A20-0x0000000181559A60
		protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers); // 0x0000000181559A60-0x0000000181559AA0
		protected override bool HasElementTypeImpl(); // 0x0000000181559AA0-0x0000000181559AE0
		public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters); // 0x0000000181559AE0-0x0000000181559B20
		protected override bool IsArrayImpl(); // 0x0000000181559B20-0x0000000181559B60
		protected override bool IsByRefImpl(); // 0x0000000181559B60-0x0000000181559BA0
		protected override bool IsCOMObjectImpl(); // 0x0000000181559BA0-0x0000000181559BE0
		public override bool IsDefined(Type attributeType, bool inherit); // 0x0000000181559BE0-0x0000000181559C20
		protected override bool IsPointerImpl(); // 0x0000000181559C20-0x0000000181559C60
		protected override bool IsPrimitiveImpl(); // 0x0000000181559C60-0x0000000181559CA0
	}
}
