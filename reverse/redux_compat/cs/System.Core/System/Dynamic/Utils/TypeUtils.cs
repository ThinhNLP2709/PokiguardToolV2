/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Dynamic.Utils
{
	internal static class TypeUtils // TypeDefIndex: 12593
	{
		// Fields
		private static readonly Type[] s_arrayAssignableInterfaces; // 0x00
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 12594
		{
			// Fields
			public static readonly __c __9; // 0x00
	
			// Constructors
			static __c(); // 0x000000018180E140-0x000000018180E1B0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _.cctor_b__44_0(Type i); // 0x000000018180E0A0-0x000000018180E0D0
			internal Type _.cctor_b__44_1(Type i); // 0x000000018180E0D0-0x000000018180E100
		}
	
		// Constructors
		static TypeUtils(); // 0x000000018180D5F0-0x000000018180D7C0
	
		// Methods
		public static bool IsValidInstanceType(MemberInfo member, Type instanceType); // 0x000000018180CB50-0x000000018180CFE0
		private static bool HasArrayToInterfaceConversion(Type source, Type dest); // 0x000000018180AAC0-0x000000018180ACB0
		private static bool HasInterfaceToArrayConversion(Type source, Type dest); // 0x000000018180B1B0-0x000000018180B3A0
		private static bool IsCovariant(Type t); // 0x000000018180B8A0-0x000000018180B8D0
		private static bool IsContravariant(Type t); // 0x000000018180B7A0-0x000000018180B7D0
		private static bool IsInvariant(Type t); // 0x000000018180C2D0-0x000000018180C300
		private static bool IsDelegate(Type t); // 0x000000018180B8D0-0x000000018180B940
		public static bool IsLegalExplicitVariantDelegateConversion(Type source, Type dest); // 0x000000018180C300-0x000000018180C680
		public static bool HasReferenceEquality(Type left, Type right); // 0x000000018180B560-0x000000018180B640
		public static bool HasBuiltInEqualityOperator(Type left, Type right); // 0x000000018180ACB0-0x000000018180AE90
		public static MethodInfo GetUserDefinedCoercionMethod(Type convertFrom, Type convertToType); // 0x000000018180A8A0-0x000000018180AAC0
		private static MethodInfo FindConversionOperator(MethodInfo[] methods, Type typeFrom, Type typeTo); // 0x0000000181809CE0-0x0000000181809F70
		private static bool IsImplicitNumericConversion(Type source, Type destination); // 0x000000018180BB60-0x000000018180BD20
		private static bool IsImplicitReferenceConversion(Type source, Type destination); // 0x00000001817C2BB0-0x00000001817C2BE0
		private static bool IsImplicitBoxingConversion(Type source, Type destination); // 0x000000018180B940-0x000000018180BA40
		private static bool IsImplicitNullableConversion(Type source, Type destination); // 0x000000018180BA40-0x000000018180BB60
		public static Type FindGenericType(Type definition, Type type); // 0x0000000181809F70-0x000000018180A330
		public static MethodInfo GetBooleanOperator(Type type, string name); // 0x000000018180A330-0x000000018180A540
		public static bool AreEquivalent(Type t1, Type t2); // 0x0000000181809B70-0x0000000181809BE0
		public static bool AreReferenceAssignable(Type dest, Type src); // 0x0000000181809BE0-0x0000000181809CE0
		public static bool IsSameOrSubclass(Type type, Type subType); // 0x000000018180C9A0-0x000000018180CA70
		public static void ValidateType(Type type, string paramName); // 0x000000018180D490-0x000000018180D500
		public static void ValidateType(Type type, string paramName, bool allowByRef, bool allowPointer); // 0x000000018180D2F0-0x000000018180D490
		public static bool ValidateType(Type type, string paramName, int index); // 0x000000018180D500-0x000000018180D5F0
	
		// Extension methods
		public static Type GetNonNullableType(this Type type); // 0x000000018180A590-0x000000018180A6A0
		public static Type GetNullableType(this Type type); // 0x000000018180A6F0-0x000000018180A8A0
		public static bool IsNullableType(this Type type); // 0x000000018180C760-0x000000018180C7F0
		public static bool IsNullableOrReferenceType(this Type type); // 0x000000018180C680-0x000000018180C760
		public static bool IsBool(this Type type); // 0x000000018180B710-0x000000018180B7A0
		public static bool IsNumeric(this Type type); // 0x000000018180C8D0-0x000000018180C9A0
		public static bool IsInteger(this Type type); // 0x000000018180C200-0x000000018180C2D0
		public static bool IsArithmetic(this Type type); // 0x000000018180B640-0x000000018180B710
		public static bool IsUnsignedInt(this Type type); // 0x000000018180CA70-0x000000018180CB50
		public static bool IsIntegerOrBool(this Type type); // 0x000000018180C120-0x000000018180C200
		public static bool IsNumericOrBool(this Type type); // 0x000000018180C7F0-0x000000018180C8D0
		public static bool HasIdentityPrimitiveOrNullableConversionTo(this Type source, Type dest); // 0x000000018180AE90-0x000000018180B1B0
		public static bool HasReferenceConversionTo(this Type source, Type dest); // 0x000000018180B3A0-0x000000018180B560
		private static bool StrictHasReferenceConversionTo(this Type source, Type dest, bool skipNonArray); // 0x000000018180CFE0-0x000000018180D2F0
		public static bool IsConvertible(this Type type); // 0x000000018180B7D0-0x000000018180B8A0
		public static bool IsImplicitlyConvertibleTo(this Type source, Type destination); // 0x000000018180BD20-0x000000018180C120
		public static Type GetNonRefType(this Type type); // 0x000000018180A6A0-0x000000018180A6F0
		public static MethodInfo GetInvokeMethod(this Type delegateType); // 0x000000018180A540-0x000000018180A590
	}
}
