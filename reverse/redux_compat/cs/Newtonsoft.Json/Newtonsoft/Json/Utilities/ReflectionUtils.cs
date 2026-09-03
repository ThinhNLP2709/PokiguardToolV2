/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal static class ReflectionUtils // TypeDefIndex: 10175
	{
		// Fields
		public static readonly Type[] EmptyTypes; // 0x00
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 10176
		{
			// Fields
			[Nullable(0)]
			public static readonly __c __9; // 0x00
			[Nullable(0)]
			public static Func<ConstructorInfo, bool> __9__11_0; // 0x08
			[Nullable(0)]
			public static Func<MemberInfo, string> __9__31_0; // 0x10
			[Nullable(0)]
			public static Func<ParameterInfo, Type> __9__39_0; // 0x18
			[Nullable(0)]
			public static Func<FieldInfo, bool> __9__41_0; // 0x20
	
			// Constructors
			static __c(); // 0x000000018171DF90-0x000000018171E000
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(0)]
			internal bool _GetDefaultConstructor_b__11_0(ConstructorInfo c); // 0x000000018171CDF0-0x000000018171CE50
			[NullableContext(0)]
			internal string _GetFieldsAndProperties_b__31_0(MemberInfo m); // 0x000000018171D300-0x000000018171D330
			[NullableContext(0)]
			internal Type _GetMemberInfoFromType_b__39_0(ParameterInfo p); // 0x00000001813FDD30-0x00000001813FDD60
			[NullableContext(0)]
			internal bool _GetChildPrivateFields_b__41_0(FieldInfo f); // 0x000000018171CDD0-0x000000018171CDF0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass31_0 // TypeDefIndex: 10177
		{
			// Fields
			[Nullable(0)]
			public MemberInfo memberInfo; // 0x10
	
			// Constructors
			public __c__DisplayClass31_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(0)]
			internal bool _GetFieldsAndProperties_b__1(MemberInfo m); // 0x000000018171D430-0x000000018171D4C0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass44_0 // TypeDefIndex: 10178
		{
			// Fields
			[Nullable(0)]
			public PropertyInfo subTypeProperty; // 0x10
	
			// Constructors
			public __c__DisplayClass44_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(0)]
			internal bool _GetChildPrivateProperties_b__0(PropertyInfo p); // 0x000000018171D4F0-0x000000018171D560
			[NullableContext(0)]
			internal bool _GetChildPrivateProperties_b__1(PropertyInfo p); // 0x000000018171D560-0x000000018171D650
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass44_1 // TypeDefIndex: 10179
		{
			// Fields
			[Nullable(0)]
			public Type subTypePropertyDeclaringType; // 0x10
			[Nullable(0)]
			public __c__DisplayClass44_0 CS___8__locals1; // 0x18
	
			// Constructors
			public __c__DisplayClass44_1(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(0)]
			internal bool _GetChildPrivateProperties_b__2(PropertyInfo p); // 0x000000018171D650-0x000000018171D7A0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass45_0 // TypeDefIndex: 10180
		{
			// Fields
			[Nullable(0)]
			public string method; // 0x10
			[Nullable(0)]
			public Type methodDeclaringType; // 0x18
	
			// Constructors
			public __c__DisplayClass45_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(0)]
			internal bool _IsMethodOverridden_b__0(MethodInfo info); // 0x000000018171D7A0-0x000000018171D8A0
		}
	
		// Constructors
		static ReflectionUtils(); // 0x00000001816FA6E0-0x00000001816FA760
	
		// Methods
		public static bool IsPublic(PropertyInfo property); // 0x00000001816FA0D0-0x00000001816FA170
		[NullableContext(2)]
		public static Type GetObjectType(object v); // 0x00000001816F8D50-0x00000001816F8D60
		public static string GetTypeName(Type t, TypeNameAssemblyFormatHandling assemblyFormat, [Nullable(2)] ISerializationBinder binder); // 0x00000001816F9000-0x00000001816F9310
		private static string GetFullyQualifiedTypeName(Type t, [Nullable(2)] ISerializationBinder binder); // 0x00000001816F8470-0x00000001816F85C0
		private static string RemoveAssemblyDetails(string fullyQualifiedTypeName); // 0x00000001816FA260-0x00000001816FA390
		public static bool HasDefaultConstructor(Type t, bool nonPublic); // 0x00000001816F9310-0x00000001816F93E0
		public static ConstructorInfo GetDefaultConstructor(Type t); // 0x00000001816F7670-0x00000001816F76C0
		public static ConstructorInfo GetDefaultConstructor(Type t, bool nonPublic); // 0x00000001816F7540-0x00000001816F7670
		public static bool IsNullable(Type t); // 0x00000001816F9E70-0x00000001816F9EF0
		public static bool IsNullableType(Type t); // 0x00000001816F9DB0-0x00000001816F9E70
		public static Type EnsureNotNullableType(Type t); // 0x00000001816F6620-0x00000001816F6680
		public static Type EnsureNotByRefType(Type t); // 0x00000001816F65C0-0x00000001816F6620
		public static bool IsGenericDefinition(Type type, Type genericInterfaceDefinition); // 0x00000001816F9BA0-0x00000001816F9C20
		public static bool ImplementsGenericDefinition(Type type, Type genericInterfaceDefinition); // 0x00000001816F9690-0x00000001816F9700
		public static bool ImplementsGenericDefinition(Type type, Type genericInterfaceDefinition, [Nullable(2)] [NotNullWhen(true)] out Type implementingType); // 0x00000001816F93E0-0x00000001816F9690
		public static bool InheritsGenericDefinition(Type type, Type genericClassDefinition); // 0x00000001816F9A20-0x00000001816F9A90
		public static bool InheritsGenericDefinition(Type type, Type genericClassDefinition, [Nullable(2)] out Type implementingType); // 0x00000001816F9810-0x00000001816F9A20
		private static bool InheritsGenericDefinitionInternal(Type type, Type genericClassDefinition, [Nullable(2)] out Type implementingType); // 0x00000001816F9700-0x00000001816F9810
		public static Type GetCollectionItemType(Type type); // 0x00000001816F72D0-0x00000001816F7540
		[NullableContext(2)]
		public static void GetDictionaryKeyValueTypes([Nullable(1)] Type dictionaryType, out Type keyType, out Type valueType); // 0x00000001816F79A0-0x00000001816F7C30
		public static Type GetMemberUnderlyingType(MemberInfo member); // 0x00000001816F8840-0x00000001816F8A90
		public static bool IsByRefLikeType(Type type); // 0x00000001816F9A90-0x00000001816F9BA0
		public static bool IsIndexedProperty(PropertyInfo property); // 0x00000001816F9C20-0x00000001816F9C90
		public static object GetMemberValue(MemberInfo member, object target); // 0x00000001816F8A90-0x00000001816F8D50
		public static void SetMemberValue(MemberInfo member, object target, [Nullable(2)] object value); // 0x00000001816FA3B0-0x00000001816FA5B0
		public static bool CanReadMemberValue(MemberInfo member, bool nonPublic); // 0x00000001816F6320-0x00000001816F6450
		public static bool CanSetMemberValue(MemberInfo member, bool nonPublic, bool canSetReadOnly); // 0x00000001816F6450-0x00000001816F65C0
		public static List<MemberInfo> GetFieldsAndProperties(Type type, BindingFlags bindingAttr); // 0x00000001816F7C30-0x00000001816F8360
		private static bool IsOverridenGenericMember(MemberInfo memberInfo, BindingFlags bindingAttr); // 0x00000001816F9EF0-0x00000001816FA0D0
		public static T GetAttribute<T>(object attributeProvider)
			where T : Attribute;
		public static T GetAttribute<T>(object attributeProvider, bool inherit)
			where T : Attribute;
		public static T[] GetAttributes<T>(object attributeProvider, bool inherit)
			where T : Attribute;
		public static Attribute[] GetAttributes(object attributeProvider, [Nullable(2)] Type attributeType, bool inherit); // 0x00000001816F6720-0x00000001816F6BA0
		public static StructMultiKey<string, string> SplitFullyQualifiedTypeName(string fullyQualifiedTypeName); // 0x00000001816FA5B0-0x00000001816FA6E0
		private static int? GetAssemblyDelimiterIndex(string fullyQualifiedTypeName); // 0x00000001816F6680-0x00000001816F6720
		public static MemberInfo GetMemberInfoFromType(Type targetType, MemberInfo memberInfo); // 0x00000001816F85C0-0x00000001816F8840
		public static IEnumerable<FieldInfo> GetFields(Type targetType, BindingFlags bindingAttr); // 0x00000001816F8360-0x00000001816F8470
		private static void GetChildPrivateFields(IList<MemberInfo> initialFields, Type type, BindingFlags bindingAttr); // 0x00000001816F6C90-0x00000001816F6E80
		public static IEnumerable<PropertyInfo> GetProperties(Type targetType, BindingFlags bindingAttr); // 0x00000001816F8D60-0x00000001816F9000
		private static void GetChildPrivateProperties(IList<PropertyInfo> initialProperties, Type type, BindingFlags bindingAttr); // 0x00000001816F6E80-0x00000001816F72D0
		public static bool IsMethodOverridden(Type currentType, Type methodDeclaringType, string method); // 0x00000001816F9C90-0x00000001816F9DB0
		public static object GetDefaultValue(Type type); // 0x00000001816F76C0-0x00000001816F79A0
	
		// Extension methods
		public static bool IsVirtual(this PropertyInfo propertyInfo); // 0x00000001816FA170-0x00000001816FA260
		public static MethodInfo GetBaseDefinition(this PropertyInfo propertyInfo); // 0x00000001816F6BA0-0x00000001816F6C90
		public static BindingFlags RemoveFlag(this BindingFlags bindingAttr, BindingFlags flag); // 0x00000001816FA390-0x00000001816FA3B0
	}
}
