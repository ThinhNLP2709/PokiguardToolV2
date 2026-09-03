/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Reflection
{
	internal abstract class SignatureType : Type // TypeDefIndex: 3324
	{
		// Properties
		public sealed override bool IsSignatureType { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public abstract bool IsSZArray { get; }
		public abstract bool IsVariableBoundArray { get; }
		public sealed override bool IsGenericType { get; } // 0x000000018153E150-0x000000018153E1A0 
		public abstract bool IsGenericTypeDefinition { get; }
		public abstract bool IsConstructedGenericType { get; }
		public abstract bool IsGenericParameter { get; }
		public abstract bool IsGenericMethodParameter { get; }
		public abstract bool ContainsGenericParameters { get; }
		public sealed override MemberTypes MemberType { get; } // 0x0000000180A2FAE0-0x0000000180A2FAF0 
		public abstract Type[] GenericTypeArguments { get; }
		public abstract int GenericParameterPosition { get; }
		internal abstract SignatureType ElementType { get; }
		public sealed override Type UnderlyingSystemType { get; } // 0x0000000180370C60-0x0000000180370C70 
		public abstract string Name { get; }
		public abstract string Namespace { get; }
		public sealed override string FullName { get; } // 0x00000001802E7860-0x00000001802E7870 
		public sealed override string AssemblyQualifiedName { get; } // 0x00000001802E7860-0x00000001802E7870 
		public sealed override Assembly Assembly { get; } // 0x000000018153DF20-0x000000018153DF70 
		public sealed override Module Module { get; } // 0x000000018153E240-0x000000018153E290 
		public sealed override Type ReflectedType { get; } // 0x000000018153E290-0x000000018153E2E0 
		public sealed override Type BaseType { get; } // 0x000000018153DF70-0x000000018153DFC0 
		public sealed override int MetadataToken { get; } // 0x000000018153E1F0-0x000000018153E240 
		public sealed override Type DeclaringType { get; } // 0x000000018153E010-0x000000018153E060 
		public sealed override MethodBase DeclaringMethod { get; } // 0x000000018153DFC0-0x000000018153E010 
		public sealed override GenericParameterAttributes GenericParameterAttributes { get; } // 0x000000018153E0B0-0x000000018153E100 
		public sealed override Guid GUID { get; } // 0x000000018153E060-0x000000018153E0B0 
		public sealed override bool IsEnum { get; } // 0x000000018153E100-0x000000018153E150 
		public sealed override bool IsSerializable { get; } // 0x000000018153E1A0-0x000000018153E1F0 
		public sealed override RuntimeTypeHandle TypeHandle { get; } // 0x000000018153E2E0-0x000000018153E330 
	
		// Constructors
		protected SignatureType(); // 0x000000018153DEF0-0x000000018153DF20
	
		// Methods
		protected abstract bool HasElementTypeImpl();
		protected abstract bool IsArrayImpl();
		protected abstract bool IsByRefImpl();
		protected abstract bool IsPointerImpl();
		public sealed override Type MakeArrayType(); // 0x000000018153DC50-0x000000018153DCD0
		public sealed override Type MakeArrayType(int rank); // 0x000000018153DCD0-0x000000018153DDA0
		public sealed override Type MakeByRefType(); // 0x000000018153DDA0-0x000000018153DE20
		public sealed override Type MakePointerType(); // 0x000000018153DE70-0x000000018153DEF0
		public sealed override Type MakeGenericType(params Type[] typeArguments); // 0x000000018153DE20-0x000000018153DE70
		public sealed override Type GetElementType(); // 0x000000018153D280-0x000000018153D2A0
		public abstract int GetArrayRank();
		public abstract Type GetGenericTypeDefinition();
		public abstract Type[] GetGenericArguments();
		public abstract string ToString();
		public sealed override Type[] GetInterfaces(); // 0x000000018153D570-0x000000018153D5C0
		public sealed override bool IsAssignableFrom(Type c); // 0x000000018153D8E0-0x000000018153D930
		public sealed override Type[] GetGenericParameterConstraints(); // 0x000000018153D520-0x000000018153D570
		public sealed override bool IsEnumDefined(object value); // 0x000000018153DA20-0x000000018153DA70
		public sealed override string GetEnumName(object value); // 0x000000018153D2A0-0x000000018153D2F0
		public sealed override string[] GetEnumNames(); // 0x000000018153D2F0-0x000000018153D340
		public sealed override Type GetEnumUnderlyingType(); // 0x000000018153D340-0x000000018153D390
		public sealed override Array GetEnumValues(); // 0x000000018153D390-0x000000018153D3E0
		protected sealed override TypeCode GetTypeCodeImpl(); // 0x000000018153D840-0x000000018153D890
		protected sealed override TypeAttributes GetAttributeFlagsImpl(); // 0x000000018153D0A0-0x000000018153D0F0
		public sealed override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr); // 0x000000018153D140-0x000000018153D190
		public sealed override EventInfo GetEvent(string name, BindingFlags bindingAttr); // 0x000000018153D3E0-0x000000018153D430
		public sealed override EventInfo[] GetEvents(BindingFlags bindingAttr); // 0x000000018153D430-0x000000018153D480
		public sealed override FieldInfo GetField(string name, BindingFlags bindingAttr); // 0x000000018153D480-0x000000018153D4D0
		public sealed override FieldInfo[] GetFields(BindingFlags bindingAttr); // 0x000000018153D4D0-0x000000018153D520
		public sealed override MemberInfo[] GetMembers(BindingFlags bindingAttr); // 0x000000018153D660-0x000000018153D6B0
		public sealed override MethodInfo[] GetMethods(BindingFlags bindingAttr); // 0x000000018153D700-0x000000018153D750
		public sealed override Type GetNestedType(string name, BindingFlags bindingAttr); // 0x000000018153D750-0x000000018153D7A0
		public sealed override PropertyInfo[] GetProperties(BindingFlags bindingAttr); // 0x000000018153D7A0-0x000000018153D7F0
		public sealed override object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters); // 0x000000018153D890-0x000000018153D8E0
		protected sealed override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers); // 0x000000018153D6B0-0x000000018153D700
		protected sealed override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers); // 0x000000018153D7F0-0x000000018153D840
		public sealed override MemberInfo[] GetMember(string name, BindingFlags bindingAttr); // 0x000000018153D610-0x000000018153D660
		public sealed override MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr); // 0x000000018153D5C0-0x000000018153D610
		public sealed override object[] GetCustomAttributes(bool inherit); // 0x000000018153D1E0-0x000000018153D230
		public sealed override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x000000018153D230-0x000000018153D280
		public sealed override bool IsDefined(Type attributeType, bool inherit); // 0x000000018153D9D0-0x000000018153DA20
		public sealed override IList<CustomAttributeData> GetCustomAttributesData(); // 0x000000018153D190-0x000000018153D1E0
		protected sealed override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers); // 0x000000018153D0F0-0x000000018153D140
		protected sealed override bool IsCOMObjectImpl(); // 0x000000018153D930-0x000000018153D980
		protected sealed override bool IsPrimitiveImpl(); // 0x000000018153DB60-0x000000018153DBB0
		protected sealed override bool IsContextfulImpl(); // 0x000000018153D980-0x000000018153D9D0
		public sealed override bool IsEquivalentTo(Type other); // 0x000000018153DA70-0x000000018153DAC0
		public sealed override bool IsInstanceOfType(object o); // 0x000000018153DAC0-0x000000018153DB10
		protected sealed override bool IsMarshalByRefImpl(); // 0x000000018153DB10-0x000000018153DB60
		public sealed override bool IsSubclassOf(Type c); // 0x000000018153DBB0-0x000000018153DC00
		protected sealed override bool IsValueTypeImpl(); // 0x000000018153DC00-0x000000018153DC50
	}
}
