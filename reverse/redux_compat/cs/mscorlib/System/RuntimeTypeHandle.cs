/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public struct RuntimeTypeHandle : ISerializable // TypeDefIndex: 2483
	{
		// Fields
		private IntPtr value; // 0x00
	
		// Properties
		public IntPtr Value { get; } // 0x00000001808BADD0-0x00000001808BADE0 
	
		// Constructors
		internal RuntimeTypeHandle(IntPtr val); // 0x0000000180CBE820-0x0000000180CBE830
		internal RuntimeTypeHandle(RuntimeType type); // 0x0000000181659D30-0x0000000181659D50
		private RuntimeTypeHandle(SerializationInfo info, StreamingContext context); // 0x0000000181659BB0-0x0000000181659D30
	
		// Methods
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181659530-0x0000000181659690
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public override bool Equals(object obj); // 0x00000001816593C0-0x0000000181659490
		public override int GetHashCode(); // 0x0000000180732D10-0x0000000180732D20
		internal static TypeAttributes GetAttributes(RuntimeType type); // 0x00000001816594B0-0x00000001816594C0
		private static int GetMetadataToken(RuntimeType type); // 0x0000000181659510-0x0000000181659520
		internal static int GetToken(RuntimeType type); // 0x0000000181659510-0x0000000181659520
		private static Type GetGenericTypeDefinition_impl(RuntimeType type); // 0x0000000181659500-0x0000000181659510
		internal static Type GetGenericTypeDefinition(RuntimeType type); // 0x0000000181659500-0x0000000181659510
		internal static bool IsPrimitive(RuntimeType type); // 0x0000000181659B30-0x0000000181659B60
		internal static bool IsByRef(RuntimeType type); // 0x0000000181659A20-0x0000000181659A40
		internal static bool IsPointer(RuntimeType type); // 0x0000000181659B10-0x0000000181659B30
		internal static bool IsArray(RuntimeType type); // 0x0000000181659A00-0x0000000181659A20
		internal static bool IsSzArray(RuntimeType type); // 0x0000000181659B90-0x0000000181659BB0
		internal static bool HasElementType(RuntimeType type); // 0x00000001816599B0-0x00000001816599E0
		internal static CorElementType GetCorElementType(RuntimeType type); // 0x00000001816594D0-0x00000001816594E0
		internal static bool HasInstantiation(RuntimeType type); // 0x00000001816599E0-0x00000001816599F0
		internal static bool IsComObject(RuntimeType type); // 0x0000000181449F80-0x0000000181449F90
		internal static bool IsInstanceOfType(RuntimeType type, object o); // 0x0000000181659AE0-0x0000000181659AF0
		internal static bool HasReferences(RuntimeType type); // 0x00000001816599F0-0x0000000181659A00
		internal static bool IsComObject(RuntimeType type, bool isGenericCOM); // 0x0000000181659A40-0x0000000181659A50
		internal static bool IsContextful(RuntimeType type); // 0x0000000181659A50-0x0000000181659AC0
		internal static bool IsEquivalentTo(RuntimeType rtType1, RuntimeType rtType2); // 0x00000001802E7840-0x00000001802E7850
		internal static bool IsInterface(RuntimeType type); // 0x0000000181659AF0-0x0000000181659B10
		internal static int GetArrayRank(RuntimeType type); // 0x0000000181659490-0x00000001816594A0
		internal static RuntimeAssembly GetAssembly(RuntimeType type); // 0x00000001816594A0-0x00000001816594B0
		internal static RuntimeType GetElementType(RuntimeType type); // 0x00000001816594E0-0x00000001816594F0
		internal static RuntimeModule GetModule(RuntimeType type); // 0x0000000181659520-0x0000000181659530
		internal static bool IsGenericVariable(RuntimeType type); // 0x0000000181659AD0-0x0000000181659AE0
		internal static RuntimeType GetBaseType(RuntimeType type); // 0x00000001816594C0-0x00000001816594D0
		internal static bool CanCastTo(RuntimeType type, RuntimeType target); // 0x00000001816593B0-0x00000001816593C0
		private static bool type_is_assignable_from(Type a, Type b); // 0x0000000181659D80-0x0000000181659D90
		internal static bool IsGenericTypeDefinition(RuntimeType type); // 0x0000000181659AC0-0x0000000181659AD0
		internal static IntPtr GetGenericParameterInfo(RuntimeType type); // 0x00000001816594F0-0x0000000181659500
		internal static bool IsSubclassOf(RuntimeType childType, RuntimeType baseType); // 0x0000000181659B60-0x0000000181659B90
		internal static bool is_subclass_of(IntPtr childType, IntPtr baseType); // 0x0000000181659D70-0x0000000181659D80
		private static RuntimeType internal_from_name(string name, ref StackCrawlMark stackMark, Assembly callerAssembly, bool throwOnError, bool ignoreCase, bool reflectionOnly); // 0x0000000181659D50-0x0000000181659D70
		internal static RuntimeType GetTypeByName(string typeName, bool throwOnError, bool ignoreCase, bool reflectionOnly, ref StackCrawlMark stackMark, bool loadTypeFromPartialName); // 0x0000000181659690-0x00000001816599B0
	}
}
