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
	[Serializable]
	public abstract class Type : MemberInfo // TypeDefIndex: 2356
	{
		// Fields
		private static Binder s_defaultBinder; // 0x00
		public static readonly char Delimiter; // 0x08
		public static readonly Type[] EmptyTypes; // 0x10
		public static readonly object Missing; // 0x18
		public static readonly MemberFilter FilterAttribute; // 0x20
		public static readonly MemberFilter FilterName; // 0x28
		public static readonly MemberFilter FilterNameIgnoreCase; // 0x30
		internal RuntimeTypeHandle _impl; // 0x10
	
		// Properties
		public virtual bool IsSerializable { get; } // 0x0000000181625B10-0x0000000181625CD0 
		public virtual bool ContainsGenericParameters { get; } // 0x00000001816251F0-0x0000000181625360 
		public bool IsVisible { get; } // 0x0000000181625D40-0x0000000181625F10 
		public override MemberTypes MemberType { get; } // 0x0000000180A2FAE0-0x0000000180A2FAF0 
		public abstract string Namespace { get; }
		public abstract string AssemblyQualifiedName { get; }
		public abstract string FullName { get; }
		public abstract Assembly Assembly { get; }
		public abstract new Module Module { get; }
		public bool IsNested { get; } // 0x00000001816259D0-0x0000000181625A10 
		public override Type DeclaringType { get; } // 0x00000001802E7860-0x00000001802E7870 
		public virtual MethodBase DeclaringMethod { get; } // 0x00000001802E7860-0x00000001802E7870 
		public override Type ReflectedType { get; } // 0x00000001802E7860-0x00000001802E7870 
		public abstract Type UnderlyingSystemType { get; }
		public bool IsArray { get; } // 0x0000000181625670-0x0000000181625690 
		public bool IsByRef { get; } // 0x0000000181625690-0x00000001816256B0 
		public bool IsPointer { get; } // 0x0000000181625A40-0x0000000181625A60 
		public virtual bool IsConstructedGenericType { get; } // 0x0000000181625720-0x0000000181625750 
		public virtual bool IsGenericParameter { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual bool IsGenericMethodParameter { get; } // 0x0000000181625820-0x0000000181625870 
		public virtual bool IsGenericType { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual bool IsGenericTypeDefinition { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual bool IsSZArray { get; } // 0x0000000181625AB0-0x0000000181625AE0 
		public virtual bool IsVariableBoundArray { get; } // 0x0000000181625CF0-0x0000000181625D40 
		public bool HasElementType { get; } // 0x00000001816255F0-0x0000000181625610 
		public virtual Type[] GenericTypeArguments { get; } // 0x0000000181625530-0x00000001816255F0 
		public virtual int GenericParameterPosition { get; } // 0x00000001816254E0-0x0000000181625530 
		public virtual GenericParameterAttributes GenericParameterAttributes { get; } // 0x00000001816254A0-0x00000001816254E0 
		public TypeAttributes Attributes { get; } // 0x00000001816251D0-0x00000001816251F0 
		public bool IsAbstract { get; } // 0x0000000181625640-0x0000000181625670 
		public bool IsSealed { get; } // 0x0000000181625AE0-0x0000000181625B10 
		public bool IsClass { get; } // 0x00000001816256D0-0x0000000181625720 
		public bool IsNestedAssembly { get; } // 0x0000000181625940-0x0000000181625970 
		public bool IsNestedPrivate { get; } // 0x0000000181625970-0x00000001816259A0 
		public bool IsNestedPublic { get; } // 0x00000001816259A0-0x00000001816259D0 
		public bool IsNotPublic { get; } // 0x0000000181625A10-0x0000000181625A40 
		public bool IsPublic { get; } // 0x0000000181625A80-0x0000000181625AB0 
		public bool IsExplicitLayout { get; } // 0x00000001816257F0-0x0000000181625820 
		public bool IsCOMObject { get; } // 0x00000001816256B0-0x00000001816256D0 
		public bool IsContextful { get; } // 0x0000000181625750-0x0000000181625770 
		public virtual bool IsCollectible { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public virtual bool IsEnum { get; } // 0x0000000181625770-0x00000001816257F0 
		public bool IsMarshalByRef { get; } // 0x0000000181625920-0x0000000181625940 
		public bool IsPrimitive { get; } // 0x0000000181625A60-0x0000000181625A80 
		public bool IsValueType { get; } // 0x0000000181625CD0-0x0000000181625CF0 
		public virtual bool IsSignatureType { get; } // 0x00000001802E7840-0x00000001802E7850 
		public virtual RuntimeTypeHandle TypeHandle { get; } // 0x0000000181625F70-0x0000000181625FB0 
		public abstract Guid GUID { get; }
		public abstract Type BaseType { get; }
		public static Binder DefaultBinder { get; } // 0x0000000181625360-0x0000000181625410 
		internal virtual bool IsSzArray { get; } // 0x00000001802E7840-0x00000001802E7850 
		public bool IsInterface { get; } // 0x0000000181625870-0x0000000181625920 
		internal string FullNameOrDefault { get; } // 0x0000000181625410-0x00000001816254A0 
		internal string InternalNameIfAvailable { get; } // 0x0000000181625610-0x0000000181625640 
		internal string NameOrDefault { get; } // 0x0000000181625F10-0x0000000181625F70 
	
		// Constructors
		protected Type(); // 0x00000001802F4070-0x00000001802F4080
		static Type(); // 0x0000000181624FC0-0x00000001816251D0
	
		// Methods
		public virtual bool IsEnumDefined(object value); // 0x00000001816244B0-0x00000001816249A0
		public virtual string GetEnumName(object value); // 0x0000000181622680-0x00000001816229B0
		public virtual string[] GetEnumNames(); // 0x00000001816229B0-0x0000000181622A60
		private Array GetEnumRawConstantValues(); // 0x0000000181622A60-0x0000000181622A90
		private void GetEnumData(out string[] enumNames, out Array enumValues); // 0x0000000181622230-0x0000000181622680
		private static int BinarySearch(Array array, object value); // 0x0000000181621430-0x0000000181621550
		internal static bool IsIntegerType(Type t); // 0x0000000181624A20-0x0000000181624BC0
		internal Type GetRootElementType(); // 0x0000000181623CC0-0x0000000181623D20
		[ComVisible(true)]
		public virtual bool IsSubclassOf(Type c); // 0x0000000181624CB0-0x0000000181624D20
		public virtual bool IsAssignableFrom(Type c); // 0x00000001816242B0-0x0000000181624430
		internal bool ImplementInterface(Type ifaceType); // 0x0000000181624130-0x0000000181624290
		private static bool FilterAttributeImpl(MemberInfo m, object filterCriteria); // 0x0000000181621640-0x00000001816219A0
		private static bool FilterNameImpl(MemberInfo m, object filterCriteria); // 0x0000000181621B50-0x0000000181621CF0
		private static bool FilterNameIgnoreCaseImpl(MemberInfo m, object filterCriteria); // 0x00000001816219A0-0x0000000181621B50
		public new Type GetType(); // 0x00000001816240F0-0x0000000181624100
		protected abstract bool IsArrayImpl();
		protected abstract bool IsByRefImpl();
		protected abstract bool IsPointerImpl();
		protected abstract bool HasElementTypeImpl();
		public abstract Type GetElementType();
		public virtual int GetArrayRank(); // 0x0000000181621D50-0x0000000181621DA0
		public virtual Type GetGenericTypeDefinition(); // 0x0000000181622DC0-0x0000000181622E10
		public virtual Type[] GetGenericArguments(); // 0x0000000181622CD0-0x0000000181622D20
		public virtual Type[] GetGenericParameterConstraints(); // 0x0000000181622D20-0x0000000181622DC0
		protected abstract TypeAttributes GetAttributeFlagsImpl();
		protected abstract bool IsCOMObjectImpl();
		protected virtual bool IsContextfulImpl(); // 0x0000000181624430-0x00000001816244B0
		protected virtual bool IsMarshalByRefImpl(); // 0x0000000181624BC0-0x0000000181624C40
		protected abstract bool IsPrimitiveImpl();
		protected virtual bool IsValueTypeImpl(); // 0x0000000181624D20-0x0000000181624DA0
		[ComVisible(true)]
		public ConstructorInfo GetConstructor(Type[] types); // 0x00000001816220A0-0x0000000181622210
		[ComVisible(true)]
		public ConstructorInfo GetConstructor(BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers); // 0x0000000181621DA0-0x0000000181621F20
		[ComVisible(true)]
		public ConstructorInfo GetConstructor(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers); // 0x0000000181621F20-0x00000001816220A0
		protected abstract ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers);
		[ComVisible(true)]
		public ConstructorInfo[] GetConstructors(); // 0x0000000181622210-0x0000000181622230
		[ComVisible(true)]
		public abstract ConstructorInfo[] GetConstructors(BindingFlags bindingAttr);
		public EventInfo GetEvent(string name); // 0x0000000181622C90-0x0000000181622CB0
		public abstract EventInfo GetEvent(string name, BindingFlags bindingAttr);
		public abstract EventInfo[] GetEvents(BindingFlags bindingAttr);
		public FieldInfo GetField(string name); // 0x0000000181622CB0-0x0000000181622CD0
		public abstract FieldInfo GetField(string name, BindingFlags bindingAttr);
		public abstract FieldInfo[] GetFields(BindingFlags bindingAttr);
		public MemberInfo[] GetMember(string name); // 0x0000000181622EA0-0x0000000181622EC0
		public virtual MemberInfo[] GetMember(string name, BindingFlags bindingAttr); // 0x0000000181622E70-0x0000000181622EA0
		public virtual MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr); // 0x0000000181622EC0-0x0000000181622F10
		public abstract MemberInfo[] GetMembers(BindingFlags bindingAttr);
		public MethodInfo GetMethod(string name); // 0x00000001816230E0-0x0000000181623180
		public MethodInfo GetMethod(string name, BindingFlags bindingAttr); // 0x0000000181623180-0x0000000181623210
		public MethodInfo GetMethod(string name, Type[] types); // 0x0000000181623210-0x00000001816233D0
		public MethodInfo GetMethod(string name, Type[] types, ParameterModifier[] modifiers); // 0x0000000181622F10-0x00000001816230E0
		public MethodInfo GetMethod(string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers); // 0x00000001816235B0-0x0000000181623780
		public MethodInfo GetMethod(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers); // 0x00000001816233D0-0x00000001816235B0
		protected abstract MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers);
		public MethodInfo[] GetMethods(); // 0x0000000181623780-0x00000001816237A0
		public abstract MethodInfo[] GetMethods(BindingFlags bindingAttr);
		public abstract Type GetNestedType(string name, BindingFlags bindingAttr);
		public PropertyInfo GetProperty(string name); // 0x0000000181623B00-0x0000000181623BA0
		public PropertyInfo GetProperty(string name, BindingFlags bindingAttr); // 0x0000000181623A70-0x0000000181623B00
		public PropertyInfo GetProperty(string name, Type returnType); // 0x0000000181623BA0-0x0000000181623CC0
		public PropertyInfo GetProperty(string name, Type returnType, Type[] types); // 0x00000001816238B0-0x00000001816239A0
		public PropertyInfo GetProperty(string name, Type returnType, Type[] types, ParameterModifier[] modifiers); // 0x00000001816237C0-0x00000001816238B0
		public PropertyInfo GetProperty(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers); // 0x00000001816239A0-0x0000000181623A70
		protected abstract PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers);
		public PropertyInfo[] GetProperties(); // 0x00000001816237A0-0x00000001816237C0
		public abstract PropertyInfo[] GetProperties(BindingFlags bindingAttr);
		public static RuntimeTypeHandle GetTypeHandle(object o); // 0x0000000181623F40-0x0000000181623FD0
		public static TypeCode GetTypeCode(Type type); // 0x0000000181623DF0-0x0000000181623E40
		protected virtual TypeCode GetTypeCodeImpl(); // 0x0000000181623D20-0x0000000181623DF0
		public static Type GetTypeFromCLSID(Guid clsid); // 0x0000000181623E40-0x0000000181623EA0
		public abstract object InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters);
		public abstract Type[] GetInterfaces();
		public virtual bool IsInstanceOfType(object o); // 0x00000001816249E0-0x0000000181624A20
		public virtual bool IsEquivalentTo(Type other); // 0x00000001816249A0-0x00000001816249E0
		public virtual Type GetEnumUnderlyingType(); // 0x0000000181622A90-0x0000000181622BE0
		public virtual Array GetEnumValues(); // 0x0000000181622BE0-0x0000000181622C90
		public virtual Type MakeArrayType(); // 0x0000000181624DA0-0x0000000181624DE0
		public virtual Type MakeArrayType(int rank); // 0x0000000181624DE0-0x0000000181624E20
		public virtual Type MakeByRefType(); // 0x0000000181624E20-0x0000000181624E60
		public virtual Type MakeGenericType(params Type[] typeArguments); // 0x0000000181624ED0-0x0000000181624F20
		public virtual Type MakePointerType(); // 0x0000000181624F20-0x0000000181624F60
		public static Type MakeGenericSignatureType(Type genericTypeDefinition, params Type[] typeArguments); // 0x0000000181624E60-0x0000000181624ED0
		public override string ToString(); // 0x0000000181624F60-0x0000000181624FC0
		public override bool Equals(object o); // 0x00000001816215D0-0x0000000181621640
		public override int GetHashCode(); // 0x0000000181622E10-0x0000000181622E70
		public virtual bool Equals(Type o); // 0x0000000181621550-0x00000001816215D0
		public static Type GetTypeFromHandle(RuntimeTypeHandle handle); // 0x0000000181623F00-0x0000000181623F40
		private static Type internal_from_handle(IntPtr handle); // 0x0000000181625FB0-0x0000000181625FC0
		internal string FormatTypeName(); // 0x0000000181621D30-0x0000000181621D50
		internal virtual string FormatTypeName(bool serialization); // 0x0000000181621CF0-0x0000000181621D30
		public static Type GetType(string typeName, bool throwOnError, bool ignoreCase); // 0x0000000181624080-0x00000001816240F0
		public static Type GetType(string typeName, bool throwOnError); // 0x0000000181623FD0-0x0000000181624030
		public static Type GetType(string typeName); // 0x0000000181624030-0x0000000181624080
		public static Type GetType(string typeName, Func<AssemblyName, Assembly> assemblyResolver, Func<Assembly, string, bool, Type> typeResolver, bool throwOnError); // 0x0000000181624100-0x0000000181624130
		public static bool operator ==(Type left, Type right); // 0x0000000180A29AB0-0x0000000180A29AC0
		public static bool operator !=(Type left, Type right); // 0x000000018126B560-0x000000018126B570
		public static Type GetTypeFromCLSID(Guid clsid, string server, bool throwOnError); // 0x0000000181623EA0-0x0000000181623F00
		internal bool IsRuntimeImplemented(); // 0x0000000181624C40-0x0000000181624CB0
		internal virtual string InternalGetNameIfAvailable(ref Type rootCauseForFailure); // 0x0000000181624290-0x00000001816242B0
	}
}
