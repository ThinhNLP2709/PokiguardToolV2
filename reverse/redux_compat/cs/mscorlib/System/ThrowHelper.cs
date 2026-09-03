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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[StackTraceHidden]
	internal static class ThrowHelper // TypeDefIndex: 2385
	{
		// Methods
		internal static void ThrowArgumentNullException(ExceptionArgument argument); // 0x000000018161F780-0x000000018161F7B0
		private static Exception CreateArgumentNullException(ExceptionArgument argument); // 0x000000018161E650-0x000000018161E6E0
		internal static void ThrowArrayTypeMismatchException(); // 0x000000018161F970-0x000000018161F9A0
		private static Exception CreateArrayTypeMismatchException(); // 0x000000018161E7C0-0x000000018161E810
		internal static void ThrowArgumentException_DestinationTooShort(); // 0x000000018161F670-0x000000018161F6A0
		private static Exception CreateArgumentException_DestinationTooShort(); // 0x000000018161E5F0-0x000000018161E650
		internal static void ThrowIndexOutOfRangeException(); // 0x000000018161FA20-0x000000018161FA50
		private static Exception CreateIndexOutOfRangeException(); // 0x000000018161E810-0x000000018161E860
		internal static void ThrowArgumentOutOfRangeException(); // 0x000000018161F8D0-0x000000018161F900
		private static Exception CreateArgumentOutOfRangeException(); // 0x000000018161E6E0-0x000000018161E730
		internal static void ThrowArgumentOutOfRangeException(ExceptionArgument argument); // 0x000000018161F8A0-0x000000018161F8D0
		private static Exception CreateArgumentOutOfRangeException(ExceptionArgument argument); // 0x000000018161E730-0x000000018161E7C0
		internal static void ThrowNotSupportedException(); // 0x000000018161FD60-0x000000018161FD90
		private static Exception CreateThrowNotSupportedException(); // 0x000000018161E860-0x000000018161E8B0
		internal static void ThrowWrongKeyTypeArgumentException(object key, Type targetType); // 0x000000018161FE30-0x000000018161FF10
		internal static void ThrowWrongValueTypeArgumentException(object value, Type targetType); // 0x000000018161FF10-0x000000018161FFF0
		internal static void ThrowArgumentException(ExceptionResource resource); // 0x000000018161F720-0x000000018161F780
		internal static void ThrowArgumentException(ExceptionResource resource, ExceptionArgument argument); // 0x000000018161F6A0-0x000000018161F720
		internal static void ThrowArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource); // 0x000000018161F7B0-0x000000018161F8A0
		internal static void ThrowInvalidOperationException(ExceptionResource resource); // 0x000000018161FC20-0x000000018161FC80
		internal static void ThrowSerializationException(ExceptionResource resource); // 0x000000018161FD90-0x000000018161FDF0
		internal static void ThrowNotSupportedException(ExceptionResource resource); // 0x000000018161FD00-0x000000018161FD60
		internal static void ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion(); // 0x000000018161FAE0-0x000000018161FB30
		internal static void ThrowInvalidOperationException_InvalidOperation_EnumOpCantHappen(); // 0x000000018161FB80-0x000000018161FBD0
		internal static void ThrowInvalidOperationException_InvalidOperation_EnumNotStarted(); // 0x000000018161FB30-0x000000018161FB80
		internal static void ThrowInvalidOperationException_InvalidOperation_EnumEnded(); // 0x000000018161FA90-0x000000018161FAE0
		internal static void ThrowInvalidOperationException_InvalidOperation_NoValue(); // 0x000000018161FBD0-0x000000018161FC20
		private static ArgumentOutOfRangeException GetArgumentOutOfRangeException(ExceptionArgument argument, string resource); // 0x000000018161ED30-0x000000018161EDA0
		internal static void ThrowArgumentOutOfRange_IndexException(); // 0x000000018161F900-0x000000018161F940
		internal static void ThrowIndexArgumentOutOfRange_NeedNonNegNumException(); // 0x000000018161F9E0-0x000000018161FA20
		internal static void ThrowArgumentException_Argument_InvalidArrayType(); // 0x000000018161F620-0x000000018161F670
		private static ArgumentException GetAddingDuplicateWithKeyArgumentException(object key); // 0x000000018161E8B0-0x000000018161E930
		internal static void ThrowAddingDuplicateWithKeyArgumentException(object key); // 0x000000018161F5F0-0x000000018161F620
		private static KeyNotFoundException GetKeyNotFoundException(object key); // 0x000000018161EFE0-0x000000018161F060
		internal static void ThrowKeyNotFoundException(object key); // 0x000000018161FCF0-0x000000018161FD00
		internal static void ThrowInvalidTypeWithPointersNotSupported(Type targetType); // 0x000000018161FC80-0x000000018161FCF0
		internal static void ThrowInvalidOperationException_ConcurrentOperationsNotSupported(); // 0x000000018161FA50-0x000000018161FA90
		internal static InvalidOperationException GetInvalidOperationException(string str); // 0x000000018161EF80-0x000000018161EFE0
		internal static void ThrowArraySegmentCtorValidationFailedExceptions(Array array, int offset, int count); // 0x000000018161F940-0x000000018161F970
		private static Exception GetArraySegmentCtorValidationFailedException(Array array, int offset, int count); // 0x000000018161EE50-0x000000018161EF80
		private static ArgumentException GetArgumentException(ExceptionResource resource); // 0x000000018161E930-0x000000018161E9C0
		private static ArgumentNullException GetArgumentNullException(ExceptionArgument argument); // 0x000000018161ECD0-0x000000018161ED30
		internal static void IfNullAndNullsAreIllegalThenThrow<T>(object value, ExceptionArgument argName);
		internal static string GetArgumentName(ExceptionArgument argument); // 0x000000018161E9C0-0x000000018161ECD0
		private static ArgumentOutOfRangeException GetArgumentOutOfRangeException(ExceptionArgument argument, ExceptionResource resource); // 0x000000018161EDA0-0x000000018161EE50
		internal static void ThrowStartIndexArgumentOutOfRange_ArgumentOutOfRange_Index(); // 0x000000018161FDF0-0x000000018161FE30
		internal static void ThrowCountArgumentOutOfRange_ArgumentOutOfRange_Count(); // 0x000000018161F9A0-0x000000018161F9E0
		internal static string GetResourceName(ExceptionResource resource); // 0x000000018161F060-0x000000018161F5F0
	}
}
