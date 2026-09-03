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
using System.Runtime.Serialization;
using System.Threading;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	internal class RuntimeType : TypeInfo, ISerializable, ICloneable // TypeDefIndex: 2430
	{
		// Fields
		internal static readonly RuntimeType ValueType; // 0x00
		internal static readonly RuntimeType EnumType; // 0x08
		private static readonly RuntimeType ObjectType; // 0x10
		private static readonly RuntimeType StringType; // 0x18
		private static readonly RuntimeType DelegateType; // 0x20
		private static Type[] s_SICtorParamTypes; // 0x28
		internal static Func<Type, Type[], Type> MakeTypeBuilderInstantiation; // 0x30
		private const BindingFlags MemberBindingMask = BindingFlags.Default | BindingFlags.IgnoreCase | BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy; // Metadata: 0x0064E618
		private const BindingFlags InvocationMask = BindingFlags.Default | BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty; // Metadata: 0x0064E61A
		private const BindingFlags BinderNonCreateInstance = BindingFlags.Default | BindingFlags.InvokeMethod | BindingFlags.GetField | BindingFlags.SetField | BindingFlags.GetProperty | BindingFlags.SetProperty; // Metadata: 0x0064E61E
		private const BindingFlags BinderGetSetProperty = BindingFlags.Default | BindingFlags.GetProperty | BindingFlags.SetProperty; // Metadata: 0x0064E622
		private const BindingFlags BinderSetInvokeProperty = BindingFlags.Default | BindingFlags.InvokeMethod | BindingFlags.SetProperty; // Metadata: 0x0064E626
		private const BindingFlags BinderGetSetField = BindingFlags.Default | BindingFlags.GetField | BindingFlags.SetField; // Metadata: 0x0064E62A
		private const BindingFlags BinderSetInvokeField = BindingFlags.Default | BindingFlags.InvokeMethod | BindingFlags.SetField; // Metadata: 0x0064E62C
		private const BindingFlags BinderNonFieldGetSet = BindingFlags.Default | BindingFlags.InvokeMethod | BindingFlags.CreateInstance | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty | BindingFlags.ExactBinding | BindingFlags.SuppressChangeType | BindingFlags.OptionalParamBinding; // Metadata: 0x0064E62E
		private const BindingFlags ClassicBindingMask = BindingFlags.Default | BindingFlags.InvokeMethod | BindingFlags.GetProperty | BindingFlags.SetProperty | BindingFlags.PutDispProperty | BindingFlags.PutRefDispProperty; // Metadata: 0x0064E632
		private static RuntimeType s_typedRef; // 0x38
		[NonSerialized]
		private MonoTypeInfo type_info; // 0x18
		internal object GenericCache; // 0x20
		private RuntimeConstructorInfo m_serializationCtor; // 0x28
		private const int GenericParameterCountAny = -1; // Metadata: 0x0064E636
	
		// Properties
		public override Module Module { get; } // 0x0000000181643F50-0x0000000181643F60 
		public override Assembly Assembly { get; } // 0x0000000181643F40-0x0000000181643F50 
		public override RuntimeTypeHandle TypeHandle { get; } // 0x0000000181648980-0x00000001816489B0 
		public override Type BaseType { get; } // 0x0000000181648370-0x0000000181648380 
		public override Type UnderlyingSystemType { get; } // 0x0000000180370C60-0x0000000180370C70 
		public override bool IsEnum { get; } // 0x0000000181648810-0x0000000181648850 
		public override GenericParameterAttributes GenericParameterAttributes { get; } // 0x0000000181648660-0x0000000181648730 
		internal override bool IsSzArray { get; } // 0x00000001816488E0-0x00000001816488F0 
		public override bool IsGenericTypeDefinition { get; } // 0x0000000181648860-0x0000000181648870 
		public override bool IsGenericParameter { get; } // 0x0000000181648850-0x0000000181648860 
		public override int GenericParameterPosition { get; } // 0x0000000181648730-0x00000001816487C0 
		public override bool IsGenericType { get; } // 0x0000000181648870-0x0000000181648880 
		public override bool IsConstructedGenericType { get; } // 0x00000001816487C0-0x0000000181648810 
		public override MemberTypes MemberType { get; } // 0x00000001816488F0-0x0000000181648930 
		public override Type ReflectedType { get; } // 0x0000000181648960-0x0000000181648980 
		public override int MetadataToken { get; } // 0x0000000181648930-0x0000000181648940 
		public override bool ContainsGenericParameters { get; } // 0x0000000181648380-0x00000001816484A0 
		public override Guid GUID { get; } // 0x00000001816485D0-0x0000000181648660 
		public override MethodBase DeclaringMethod { get; } // 0x00000001816484A0-0x00000001816484B0 
		public override string AssemblyQualifiedName { get; } // 0x0000000181648360-0x0000000181648370 
		public override Type DeclaringType { get; } // 0x00000001816484B0-0x00000001816484C0 
		public override string Name { get; } // 0x0000000181648940-0x0000000181648950 
		public override string Namespace { get; } // 0x0000000181648950-0x0000000181648960 
		public override string FullName { get; } // 0x00000001816484C0-0x00000001816485D0 
		public override bool IsSZArray { get; } // 0x0000000181648880-0x00000001816488E0 
	
		// Nested types
		internal enum MemberListType // TypeDefIndex: 2431
		{
			All = 0,
			CaseSensitive = 1,
			CaseInsensitive = 2,
			HandleToInfo = 3
		}
	
		private struct ListBuilder<T> // TypeDefIndex: 2432
			where T : class
		{
			// Fields
			private T[] _items;
			private T _item;
			private int _count;
			private int _capacity;
	
			// Properties
			public T this[int index] { get => default; }
			public int Count { get; }
	
			// Constructors
			public ListBuilder(int capacity);
	
			// Methods
			public T[] ToArray();
			public void CopyTo(object[] array, int index);
			public void Add(T item);
		}
	
		// Constructors
		internal RuntimeType(); // 0x0000000181648300-0x0000000181648350
		static RuntimeType(); // 0x0000000181647E50-0x0000000181648300
	
		// Methods
		internal static RuntimeType GetType(string typeName, bool throwOnError, bool ignoreCase, bool reflectionOnly, ref StackCrawlMark stackMark); // 0x0000000181644220-0x00000001816442A0
		private static void ThrowIfTypeNeverValidGenericArgument(RuntimeType type); // 0x0000000181647AE0-0x0000000181647C10
		internal static void SanityCheckGenericArguments(RuntimeType[] genericArguments, RuntimeType[] genericParamters); // 0x0000000181647770-0x00000001816479D0
		private static void SplitName(string fullname, out string name, out string ns); // 0x00000001816479D0-0x0000000181647AE0
		internal static BindingFlags FilterPreCalculate(bool isPublic, bool isInherited, bool isStatic); // 0x000000018163E610-0x000000018163E650
		private static void FilterHelper(BindingFlags bindingFlags, ref string name, bool allowPrefixLookup, out bool prefixLookup, out bool ignoreCase, out MemberListType listType); // 0x000000018163E4C0-0x000000018163E610
		private static void FilterHelper(BindingFlags bindingFlags, ref string name, out bool ignoreCase, out MemberListType listType); // 0x000000018163E3E0-0x000000018163E4C0
		private static bool FilterApplyPrefixLookup(MemberInfo memberInfo, string name, bool ignoreCase); // 0x000000018163E260-0x000000018163E2E0
		private static bool FilterApplyBase(MemberInfo memberInfo, BindingFlags bindingFlags, bool isPublic, bool isNonProtectedInternal, bool isStatic, string name, bool prefixLookup); // 0x000000018163DDA0-0x000000018163DF80
		private static bool FilterApplyType(Type type, BindingFlags bindingFlags, string name, bool prefixLookup, string ns); // 0x000000018163E2E0-0x000000018163E3E0
		private static bool FilterApplyMethodInfo(RuntimeMethodInfo method, BindingFlags bindingFlags, CallingConventions callConv, Type[] argumentTypes); // 0x000000018163DF80-0x000000018163E010
		private static bool FilterApplyConstructorInfo(RuntimeConstructorInfo constructor, BindingFlags bindingFlags, CallingConventions callConv, Type[] argumentTypes); // 0x000000018163DF80-0x000000018163E010
		private static bool FilterApplyMethodBase(MethodBase methodBase, BindingFlags methodFlags, BindingFlags bindingFlags, CallingConventions callConv, Type[] argumentTypes); // 0x000000018163E010-0x000000018163E260
		private ListBuilder<MethodInfo> GetMethodCandidates(string name, BindingFlags bindingAttr, CallingConventions callConv, Type[] types, int genericParamCount, bool allowPrefixLookup); // 0x0000000181641E70-0x0000000181642160
		private ListBuilder<ConstructorInfo> GetConstructorCandidates(string name, BindingFlags bindingAttr, CallingConventions callConv, Type[] types, bool allowPrefixLookup); // 0x000000018163EA80-0x000000018163EDB0
		private ListBuilder<PropertyInfo> GetPropertyCandidates(string name, BindingFlags bindingAttr, Type[] types, bool allowPrefixLookup); // 0x00000001816439D0-0x0000000181643C80
		private ListBuilder<EventInfo> GetEventCandidates(string name, BindingFlags bindingAttr, bool allowPrefixLookup); // 0x000000018163FD80-0x000000018163FFE0
		private ListBuilder<FieldInfo> GetFieldCandidates(string name, BindingFlags bindingAttr, bool allowPrefixLookup); // 0x0000000181640500-0x0000000181640760
		private ListBuilder<Type> GetNestedTypeCandidates(string fullname, BindingFlags bindingAttr, bool allowPrefixLookup); // 0x0000000181642AF0-0x0000000181642EB0
		public override MethodInfo[] GetMethods(BindingFlags bindingAttr); // 0x00000001816428F0-0x0000000181642AF0
		[ComVisible(true)]
		public override ConstructorInfo[] GetConstructors(BindingFlags bindingAttr); // 0x000000018163F280-0x000000018163F320
		public override PropertyInfo[] GetProperties(BindingFlags bindingAttr); // 0x0000000181643940-0x00000001816439D0
		public override EventInfo[] GetEvents(BindingFlags bindingAttr); // 0x0000000181640460-0x00000001816404F0
		public override FieldInfo[] GetFields(BindingFlags bindingAttr); // 0x0000000181640E60-0x0000000181640EF0
		public override MemberInfo[] GetMembers(BindingFlags bindingAttr); // 0x00000001816416B0-0x0000000181641BD0
		protected override ConstructorInfo GetConstructorImpl(BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers); // 0x000000018163EDB0-0x000000018163F030
		protected override PropertyInfo GetPropertyImpl(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers); // 0x0000000181643C80-0x0000000181643F40
		public override EventInfo GetEvent(string name, BindingFlags bindingAttr); // 0x000000018163FFE0-0x0000000181640220
		public override FieldInfo GetField(string name, BindingFlags bindingAttr); // 0x0000000181640760-0x0000000181640BA0
		public override Type GetNestedType(string fullname, BindingFlags bindingAttr); // 0x0000000181642EB0-0x0000000181643280
		public override MemberInfo[] GetMember(string name, MemberTypes type, BindingFlags bindingAttr); // 0x00000001816412C0-0x00000001816416B0
		internal RuntimeModule GetRuntimeModule(); // 0x0000000181643F50-0x0000000181643F60
		internal RuntimeAssembly GetRuntimeAssembly(); // 0x0000000181643F40-0x0000000181643F50
		public override bool IsInstanceOfType(object o); // 0x0000000181646DE0-0x0000000181646DF0
		public override bool IsAssignableFrom(Type c); // 0x0000000181645960-0x0000000181645A30
		public override bool IsEquivalentTo(Type other); // 0x0000000181646D50-0x0000000181646DE0
		private RuntimeType GetBaseType(); // 0x000000018163E850-0x000000018163EA10
		protected override TypeAttributes GetAttributeFlagsImpl(); // 0x000000018163E840-0x000000018163E850
		protected override bool IsContextfulImpl(); // 0x0000000181645A50-0x0000000181645A60
		protected override bool IsByRefImpl(); // 0x0000000181645A30-0x0000000181645A40
		protected override bool IsPrimitiveImpl(); // 0x0000000181646E00-0x0000000181646E10
		protected override bool IsPointerImpl(); // 0x0000000181646DF0-0x0000000181646E00
		protected override bool IsCOMObjectImpl(); // 0x0000000181645A40-0x0000000181645A50
		protected override bool IsValueTypeImpl(); // 0x0000000181646EE0-0x0000000181646F90
		protected override bool HasElementTypeImpl(); // 0x00000001816442A0-0x00000001816442B0
		protected override bool IsArrayImpl(); // 0x0000000181645950-0x0000000181645960
		public override int GetArrayRank(); // 0x000000018163E7B0-0x000000018163E840
		public override Type GetElementType(); // 0x000000018163F800-0x000000018163F810
		public override string[] GetEnumNames(); // 0x000000018163FA30-0x000000018163FB60
		public override Array GetEnumValues(); // 0x000000018163FC10-0x000000018163FD80
		public override Type GetEnumUnderlyingType(); // 0x000000018163FB60-0x000000018163FC10
		public override bool IsEnumDefined(object value); // 0x0000000181646780-0x0000000181646D50
		public override string GetEnumName(object value); // 0x000000018163F810-0x000000018163FA30
		internal RuntimeType[] GetGenericArgumentsInternal(); // 0x0000000181640F10-0x0000000181640F80
		public override Type[] GetGenericArguments(); // 0x0000000181640F90-0x0000000181641010
		public override Type MakeGenericType(params Type[] instantiation); // 0x0000000181647070-0x0000000181647690
		public override Type GetGenericTypeDefinition(); // 0x0000000181641180-0x0000000181641210
		[DebuggerHidden]
		[DebuggerStepThrough]
		public override object InvokeMember(string name, BindingFlags bindingFlags, Binder binder, object target, object[] providedArgs, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParams); // 0x00000001816442B0-0x0000000181645950
		public override bool Equals(object obj); // 0x000000018163DD90-0x000000018163DDA0
		public static bool operator ==(RuntimeType left, RuntimeType right); // 0x0000000180A29AB0-0x0000000180A29AC0
		public static bool operator !=(RuntimeType left, RuntimeType right); // 0x000000018126B560-0x000000018126B570
		public object Clone(); // 0x0000000180370C60-0x0000000180370C70
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181643600-0x0000000181643670
		public override object[] GetCustomAttributes(bool inherit); // 0x000000018163F340-0x000000018163F3E0
		public override object[] GetCustomAttributes(Type attributeType, bool inherit); // 0x000000018163F3E0-0x000000018163F570
		public override bool IsDefined(Type attributeType, bool inherit); // 0x00000001816465F0-0x0000000181646780
		public override IList<CustomAttributeData> GetCustomAttributesData(); // 0x000000018163F330-0x000000018163F340
		internal override string FormatTypeName(bool serialization); // 0x000000018163E650-0x000000018163E7B0
		private void CreateInstanceCheckThis(); // 0x000000018163CD70-0x000000018163CFE0
		internal object CreateInstanceImpl(BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes, ref StackCrawlMark stackMark); // 0x000000018163D220-0x000000018163DA90
		[DebuggerHidden]
		[DebuggerStepThrough]
		internal object CreateInstanceDefaultCtor(bool publicOnly, bool skipCheckThis, bool fillCache, bool wrapExceptions, ref StackCrawlMark stackMark); // 0x000000018163CFE0-0x000000018163D0E0
		internal RuntimeConstructorInfo GetDefaultConstructor(); // 0x000000018163F570-0x000000018163F720
		private string GetDefaultMemberName(); // 0x000000018163F720-0x000000018163F800
		internal RuntimeConstructorInfo GetSerializationCtor(); // 0x0000000181643F60-0x0000000181644190
		internal object CreateInstanceSlow(bool publicOnly, bool wrapExceptions, bool skipCheckThis, bool fillCache); // 0x000000018163DD40-0x000000018163DD90
		private object CreateInstanceMono(bool nonPublic, bool wrapExceptions); // 0x000000018163DAA0-0x000000018163DD40
		internal object CheckValue(object value, Binder binder, CultureInfo culture, BindingFlags invokeAttr); // 0x000000018163CB80-0x000000018163CD70
		private object TryConvertToType(object value, ref bool failed); // 0x0000000181647C20-0x0000000181647E50
		private static object IsConvertibleToPrimitiveType(object value, Type targetType); // 0x0000000181645A60-0x00000001816465F0
		private string GetCachedName(TypeNameKind kind); // 0x000000018163EA10-0x000000018163EA80
		private Type make_array_type(int rank); // 0x00000001816489B0-0x00000001816489C0
		public override Type MakeArrayType(); // 0x0000000181646F90-0x0000000181646FA0
		public override Type MakeArrayType(int rank); // 0x0000000181646FA0-0x0000000181647000
		private Type make_byref_type(); // 0x00000001816489C0-0x00000001816489D0
		public override Type MakeByRefType(); // 0x0000000181647000-0x0000000181647070
		private static Type MakePointerType(Type type); // 0x00000001816476A0-0x00000001816476B0
		public override Type MakePointerType(); // 0x00000001816476B0-0x0000000181647770
		public override Type[] GetGenericParameterConstraints(); // 0x0000000181641060-0x0000000181641170
		internal static object CreateInstanceForAnotherGenericParameter(Type genericType, RuntimeType genericArgument); // 0x000000018163D0E0-0x000000018163D220
		private static Type MakeGenericType(Type gt, Type[] types); // 0x0000000181647690-0x00000001816476A0
		internal IntPtr GetMethodsByName_native(IntPtr namePtr, BindingFlags bindingAttr, MemberListType listType); // 0x00000001816428E0-0x00000001816428F0
		internal RuntimeMethodInfo[] GetMethodsByName(string name, BindingFlags bindingAttr, MemberListType listType, RuntimeType reflectedType); // 0x0000000181642620-0x00000001816428E0
		private IntPtr GetPropertiesByName_native(IntPtr name, BindingFlags bindingAttr, MemberListType listType); // 0x0000000181643930-0x0000000181643940
		private IntPtr GetConstructors_native(BindingFlags bindingAttr); // 0x000000018163F320-0x000000018163F330
		private RuntimeConstructorInfo[] GetConstructors_internal(BindingFlags bindingAttr, RuntimeType reflectedType); // 0x000000018163F030-0x000000018163F280
		private RuntimePropertyInfo[] GetPropertiesByName(string name, BindingFlags bindingAttr, MemberListType listType, RuntimeType reflectedType); // 0x0000000181643670-0x0000000181643930
		private static void GetGUID(Type type, byte[] guid); // 0x0000000181640F00-0x0000000181640F10
		internal static Type GetTypeFromCLSIDImpl(Guid clsid, string server, bool throwOnError); // 0x00000001816441D0-0x0000000181644220
		protected override TypeCode GetTypeCodeImpl(); // 0x00000001816441A0-0x00000001816441D0
		private static TypeCode GetTypeCodeImplInternal(Type type); // 0x0000000181644190-0x00000001816441A0
		public override string ToString(); // 0x0000000181647C10-0x0000000181647C20
		private bool IsGenericCOMObjectImpl(); // 0x00000001802E7840-0x00000001802E7850
		private static object CreateInstanceInternal(Type type); // 0x000000018163DA90-0x000000018163DAA0
		internal string getFullName(bool full_name, bool assembly_qualified); // 0x0000000181648350-0x0000000181648360
		private Type[] GetGenericArgumentsInternal(bool runtimeArray); // 0x0000000181640F80-0x0000000181640F90
		private GenericParameterAttributes GetGenericParameterAttributes(); // 0x0000000181641010-0x0000000181641060
		private int GetGenericParameterPosition(); // 0x0000000181641170-0x0000000181641180
		private IntPtr GetEvents_native(IntPtr name, MemberListType listType); // 0x00000001816404F0-0x0000000181640500
		private IntPtr GetFields_native(IntPtr name, BindingFlags bindingAttr, MemberListType listType); // 0x0000000181640EF0-0x0000000181640F00
		private RuntimeFieldInfo[] GetFields_internal(string name, BindingFlags bindingAttr, MemberListType listType, RuntimeType reflectedType); // 0x0000000181640BA0-0x0000000181640E60
		private RuntimeEventInfo[] GetEvents_internal(string name, BindingFlags bindingAttr, MemberListType listType, RuntimeType reflectedType); // 0x0000000181640220-0x0000000181640460
		public override Type[] GetInterfaces(); // 0x00000001816412B0-0x00000001816412C0
		private IntPtr GetNestedTypes_native(IntPtr name, BindingFlags bindingAttr, MemberListType listType); // 0x00000001816435F0-0x0000000181643600
		private RuntimeType[] GetNestedTypes_internal(string displayName, BindingFlags bindingAttr, MemberListType listType); // 0x0000000181643280-0x00000001816435F0
		public override int GetHashCode(); // 0x0000000181641210-0x00000001816412B0
		[ComVisible(true)]
		public override bool IsSubclassOf(Type type); // 0x0000000181646E10-0x0000000181646EE0
		protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConv, Type[] types, ParameterModifier[] modifiers); // 0x00000001816425D0-0x0000000181642620
		private MethodInfo GetMethodImplCommon(string name, int genericParameterCount, BindingFlags bindingAttr, Binder binder, CallingConventions callConv, Type[] types, ParameterModifier[] modifiers); // 0x0000000181642160-0x00000001816425D0
		private ListBuilder<MethodInfo> GetMethodCandidates(string name, int genericParameterCount, BindingFlags bindingAttr, CallingConventions callConv, Type[] types, bool allowPrefixLookup); // 0x0000000181641BD0-0x0000000181641E70
	}
}
