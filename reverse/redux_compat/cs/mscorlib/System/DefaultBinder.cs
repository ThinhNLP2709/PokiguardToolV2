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
	internal class DefaultBinder : Binder // TypeDefIndex: 2416
	{
		// Fields
		private static Primitives[] _primitiveConversions; // 0x00
	
		// Nested types
		internal class BinderState // TypeDefIndex: 2417
		{
			// Fields
			internal int[] m_argsMap; // 0x10
			internal int m_originalSize; // 0x18
			internal bool m_isParamArray; // 0x1C
	
			// Constructors
			internal BinderState(int[] argsMap, int originalSize, bool isParamArray); // 0x000000018162DD70-0x000000018162DDD0
		}
	
		[Flags]
		private enum Primitives // TypeDefIndex: 2418
		{
			Boolean = 8,
			Char = 16,
			SByte = 32,
			Byte = 64,
			Int16 = 128,
			UInt16 = 256,
			Int32 = 512,
			UInt32 = 1024,
			Int64 = 2048,
			UInt64 = 4096,
			Single = 8192,
			Double = 16384,
			Decimal = 32768,
			DateTime = 65536,
			String = 262144
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2419
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Predicate<Type> __9__2_0; // 0x08
	
			// Constructors
			static __c(); // 0x000000018164A550-0x000000018164A620
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _SelectProperty_b__2_0(Type t); // 0x000000018164A520-0x000000018164A550
		}
	
		// Constructors
		public DefaultBinder(); // 0x00000001802F4070-0x00000001802F4080
		static DefaultBinder(); // 0x0000000181634F00-0x0000000181634FB0
	
		// Methods
		public override MethodBase BindToMethod(BindingFlags bindingAttr, MethodBase[] match, ref object[] args, ParameterModifier[] modifiers, CultureInfo cultureInfo, string[] names, out object state); // 0x000000018162F020-0x0000000181631750
		public override FieldInfo BindToField(BindingFlags bindingAttr, FieldInfo[] match, object value, CultureInfo cultureInfo); // 0x000000018162E8C0-0x000000018162F020
		public override PropertyInfo SelectProperty(BindingFlags bindingAttr, PropertyInfo[] match, Type returnType, Type[] indexes, ParameterModifier[] modifiers); // 0x0000000181634300-0x0000000181634F00
		public override object ChangeType(object value, Type type, CultureInfo cultureInfo); // 0x0000000181631C10-0x0000000181631C70
		public override void ReorderArgumentArray(ref object[] args, object state); // 0x00000001816334A0-0x0000000181633830
		public static MethodBase ExactBinding(MethodBase[] match, Type[] types, ParameterModifier[] modifiers); // 0x0000000181632020-0x00000001816322F0
		public static PropertyInfo ExactPropertyBinding(PropertyInfo[] match, Type returnType, Type[] types, ParameterModifier[] modifiers); // 0x00000001816322F0-0x0000000181632610
		private static int FindMostSpecific(ParameterInfo[] p1, int[] paramOrder1, Type paramArrayType1, ParameterInfo[] p2, int[] paramOrder2, Type paramArrayType2, Type[] types, object[] args); // 0x0000000181633030-0x0000000181633420
		private static int FindMostSpecificType(Type c1, Type c2, Type t); // 0x0000000181632C90-0x0000000181633030
		private static int FindMostSpecificMethod(MethodBase m1, int[] paramOrder1, Type paramArrayType1, MethodBase m2, int[] paramOrder2, Type paramArrayType2, Type[] types, object[] args); // 0x00000001816328A0-0x0000000181632B70
		private static int FindMostSpecificField(FieldInfo cur1, FieldInfo cur2); // 0x0000000181632780-0x00000001816328A0
		private static int FindMostSpecificProperty(PropertyInfo cur1, PropertyInfo cur2); // 0x0000000181632B70-0x0000000181632C90
		internal static bool CompareMethodSigAndName(MethodBase m1, MethodBase m2); // 0x0000000181631C70-0x0000000181631DE0
		internal static int GetHierarchyDepth(Type t); // 0x0000000181633420-0x00000001816334A0
		internal static MethodBase FindMostDerivedNewSlotMeth(MethodBase[] match, int cMatches); // 0x0000000181632610-0x0000000181632780
		private static void ReorderParams(int[] paramOrder, object[] vars); // 0x0000000181633830-0x00000001816339E0
		private static bool CreateParamOrder(int[] paramOrder, ParameterInfo[] pars, string[] names); // 0x0000000181631DE0-0x0000000181632020
		private static bool CanConvertPrimitive(RuntimeType source, RuntimeType target); // 0x0000000181631950-0x0000000181631B40
		private static bool CanConvertPrimitiveObjectToType(object source, RuntimeType type); // 0x0000000181631850-0x0000000181631950
		internal static bool CompareMethodSig(MethodBase m1, MethodBase m2); // 0x0000000181631C70-0x0000000181631DE0
		public sealed override MethodBase SelectMethod(BindingFlags bindingAttr, MethodBase[] match, Type[] types, ParameterModifier[] modifiers); // 0x00000001816339E0-0x0000000181634300
		private static bool CanChangePrimitive(Type source, Type target); // 0x0000000181631750-0x0000000181631850
		private static bool CanPrimitiveWiden(Type source, Type target); // 0x0000000181631B40-0x0000000181631C10
	}
}
