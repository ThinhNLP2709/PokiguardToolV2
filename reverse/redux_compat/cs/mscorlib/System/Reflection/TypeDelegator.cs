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
	public class TypeDelegator : TypeInfo // TypeDefIndex: 3330
	{
		// Fields
		protected Type typeImpl; // 0x18
	
		// Properties
		public override Guid GUID { get; } // 0x000000018153EEB0-0x000000018153EEF0 
		public override int MetadataToken { get; } // 0x000000018153EFB0-0x000000018153EFE0 
		public override Module Module { get; } // 0x000000018153EFE0-0x000000018153F010 
		public override Assembly Assembly { get; } // 0x000000018153EE20-0x000000018153EE50 
		public override RuntimeTypeHandle TypeHandle { get; } // 0x000000018153F010-0x000000018153F040 
		public override string Name { get; } // 0x000000018153C330-0x000000018153C360 
		public override string FullName { get; } // 0x000000018153EE80-0x000000018153EEB0 
		public override string Namespace { get; } // 0x0000000181480EF0-0x0000000181480F20 
		public override string AssemblyQualifiedName { get; } // 0x000000018153EDF0-0x000000018153EE20 
		public override Type BaseType { get; } // 0x000000018153EE50-0x000000018153EE80 
		public override bool IsSZArray { get; } // 0x000000018153EF80-0x000000018153EFB0 
		public override bool IsGenericMethodParameter { get; } // 0x000000018153EF50-0x000000018153EF80 
		public override bool IsConstructedGenericType { get; } // 0x000000018153EF20-0x000000018153EF50 
		public override bool IsCollectible { get; } // 0x000000018153EEF0-0x000000018153EF20 
		public override Type UnderlyingSystemType { get; } // 0x000000018153F040-0x000000018153F070 
	
		// Constructors
		public TypeDelegator(Type delegatingType); // 0x000000018153ED30-0x000000018153EDF0
	
		// Methods
		public override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters); // 0x000000018153EC00-0x000000018153EC40
		protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers); // 0x000000018153E800-0x000000018153E830
		[ComVisible(true)]
		public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr); // 0x000000018153E830-0x000000018153E860
		protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers); // 0x000000018153EA40-0x000000018153EA80
		public override MethodInfo[] GetMethods(BindingFlags bindingAttr); // 0x000000018153EA80-0x000000018153EAB0
		public override FieldInfo GetField(string name, BindingFlags bindingAttr); // 0x000000018153E950-0x000000018153E980
		public override FieldInfo[] GetFields(BindingFlags bindingAttr); // 0x000000018153E980-0x000000018153E9B0
		public override Type[] GetInterfaces(); // 0x000000018153E9B0-0x000000018153E9E0
		public override EventInfo GetEvent(string name, BindingFlags bindingAttr); // 0x000000018153E8F0-0x000000018153E920
		protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers); // 0x000000018153EB10-0x000000018153EBE0
		public override PropertyInfo[] GetProperties(BindingFlags bindingAttr); // 0x000000018153EAE0-0x000000018153EB10
		public override EventInfo[] GetEvents(BindingFlags bindingAttr); // 0x000000018153E920-0x000000018153E950
		public override Type GetNestedType(string name, BindingFlags bindingAttr); // 0x000000018153EAB0-0x000000018153EAE0
		public override MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr); // 0x000000018153E9E0-0x000000018153EA10
		public override MemberInfo[] GetMembers(BindingFlags bindingAttr); // 0x000000018153EA10-0x000000018153EA40
		protected override TypeAttributes GetAttributeFlagsImpl(); // 0x000000018153E7E0-0x000000018153E800
		protected override bool IsArrayImpl(); // 0x000000018153EC40-0x000000018153EC60
		protected override bool IsPrimitiveImpl(); // 0x000000018153ECF0-0x000000018153ED10
		protected override bool IsByRefImpl(); // 0x000000018153EC60-0x000000018153EC80
		protected override bool IsPointerImpl(); // 0x000000018153ECD0-0x000000018153ECF0
		protected override bool IsValueTypeImpl(); // 0x000000018153ED10-0x000000018153ED30
		protected override bool IsCOMObjectImpl(); // 0x000000018153EC80-0x000000018153ECA0
		public override Type GetElementType(); // 0x000000018153E8C0-0x000000018153E8F0
		protected override bool HasElementTypeImpl(); // 0x000000018153EBE0-0x000000018153EC00
		public override object[] GetCustomAttributes(bool inherit); // 0x000000018153E890-0x000000018153E8C0
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x000000018153E860-0x000000018153E890
		public override bool IsDefined(Type attributeType, bool inherit); // 0x000000018153ECA0-0x000000018153ECD0
	}
}
