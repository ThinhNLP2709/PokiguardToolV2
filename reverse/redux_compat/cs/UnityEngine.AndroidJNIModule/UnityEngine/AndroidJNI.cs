/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 33: UnityEngine.AndroidJNIModule.dll - Assembly: UnityEngine.AndroidJNIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14765-14805

namespace UnityEngine
{
	[NativeConditional("PLATFORM_ANDROID")]
	[NativeHeader("Modules/AndroidJNI/Public/AndroidJNIBindingsHelpers.h")]
	[StaticAccessor("AndroidJNIBindingsHelpers", StaticAccessorType.DoubleColon)]
	public static class AndroidJNI // TypeDefIndex: 14780
	{
		// Nested types
		private struct JStringBinding : IDisposable // TypeDefIndex: 14781
		{
			// Fields
			private IntPtr javaString; // 0x00
			private IntPtr chars; // 0x08
			private int length; // 0x10
			private bool ownsRef; // 0x14
	
			// Methods
			public override string ToString(); // 0x0000000182150FD0-0x0000000182151030
			public void Dispose(); // 0x0000000182150F80-0x0000000182150FD0
		}
	
		// Methods
		[NativeMethod(IsThreadSafe = true)]
		private static void ReleaseStringChars(JStringBinding str); // 0x000000018214D6D0-0x000000018214D710
		[RequiredByNativeCode]
		private static void InvokeAction(Action action); // 0x000000018214D1E0-0x000000018214D210
		[NativeMethod(IsThreadSafe = true)]
		public static IntPtr FindClass(string name); // 0x000000018214C3F0-0x000000018214C540
		[NativeMethod(IsThreadSafe = true)]
		public static IntPtr FromReflectedMethod(IntPtr refMethod); // 0x000000018214C8E0-0x000000018214C920
		[NativeMethod(IsThreadSafe = true)]
		public static IntPtr ExceptionOccurred(); // 0x000000018214C380-0x000000018214C3B0
		[NativeMethod(IsThreadSafe = true)]
		public static void ExceptionClear(); // 0x000000018214C350-0x000000018214C380
		[NativeMethod(IsThreadSafe = true)]
		public static int PushLocalFrame(int capacity); // 0x000000018214D610-0x000000018214D650
		[NativeMethod(IsThreadSafe = true)]
		public static IntPtr PopLocalFrame(IntPtr ptr); // 0x000000018214D5D0-0x000000018214D610
		[NativeMethod(IsThreadSafe = true)]
		public static IntPtr NewGlobalRef(IntPtr obj); // 0x000000018214D260-0x000000018214D2A0
		[NativeMethod(IsThreadSafe = true)]
		internal static void QueueDeleteGlobalRef(IntPtr obj); // 0x000000018214D650-0x000000018214D690
		[NativeMethod(IsThreadSafe = true)]
		public static IntPtr NewWeakGlobalRef(IntPtr obj); // 0x000000018214D590-0x000000018214D5D0
		[NativeMethod(IsThreadSafe = true)]
		public static void DeleteWeakGlobalRef(IntPtr obj); // 0x000000018214C310-0x000000018214C350
		[NativeMethod(IsThreadSafe = true)]
		public static IntPtr NewLocalRef(IntPtr obj); // 0x000000018214D2A0-0x000000018214D2E0
		[NativeMethod(IsThreadSafe = true)]
		public static void DeleteLocalRef(IntPtr obj); // 0x000000018214C2D0-0x000000018214C310
		[NativeMethod(IsThreadSafe = true)]
		public static bool IsSameObject(IntPtr obj1, IntPtr obj2); // 0x000000018214D210-0x000000018214D260
		public static IntPtr NewObject(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x000000018214D390-0x000000018214D3F0
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe IntPtr NewObjectA(IntPtr clazz, IntPtr methodID, jvalue* args); // 0x000000018214D2E0-0x000000018214D340
		[NativeMethod(IsThreadSafe = true)]
		public static IntPtr GetObjectClass(IntPtr obj); // 0x000000018214CCD0-0x000000018214CD10
		[NativeMethod(IsThreadSafe = true)]
		public static IntPtr GetMethodID(IntPtr clazz, string name, string sig); // 0x000000018214CA40-0x000000018214CC90
		[NativeMethod(IsThreadSafe = true)]
		public static IntPtr GetStaticMethodID(IntPtr clazz, string name, string sig); // 0x000000018214CD70-0x000000018214CFC0
		public static IntPtr NewString(string chars); // 0x000000018214D580-0x000000018214D590
		[NativeMethod(IsThreadSafe = true)]
		private static IntPtr NewStringFromStr(string chars); // 0x000000018214D430-0x000000018214D580
		public static string GetStringChars(IntPtr str); // 0x000000018214D070-0x000000018214D1E0
		[NativeMethod(IsThreadSafe = true)]
		private static JStringBinding GetStringCharsInternal(IntPtr str); // 0x000000018214D010-0x000000018214D070
		public static string CallStringMethod(IntPtr obj, IntPtr methodID, jvalue[] args); // 0x000000018214C1A0-0x000000018214C210
		public static string CallStringMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x000000018214C160-0x000000018214C1A0
		public static unsafe string CallStringMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args); // 0x000000018214BFD0-0x000000018214C160
		[NativeMethod(IsThreadSafe = true)]
		private static unsafe JStringBinding CallStringMethodUnsafeInternal(IntPtr obj, IntPtr methodID, jvalue* args); // 0x000000018214BF50-0x000000018214BFD0
		public static IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x000000018214B310-0x000000018214B370
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe IntPtr CallObjectMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args); // 0x000000018214B2B0-0x000000018214B310
		public static int CallIntMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x000000018214B190-0x000000018214B1F0
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe int CallIntMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args); // 0x000000018214B130-0x000000018214B190
		public static bool CallBooleanMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x000000018214AE90-0x000000018214AEF0
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe bool CallBooleanMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args); // 0x000000018214AE30-0x000000018214AE90
		public static short CallShortMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x000000018214B490-0x000000018214B4F0
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe short CallShortMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args); // 0x000000018214B430-0x000000018214B490
		public static sbyte CallSByteMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x000000018214B3D0-0x000000018214B430
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe sbyte CallSByteMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args); // 0x000000018214B370-0x000000018214B3D0
		public static char CallCharMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x000000018214AF50-0x000000018214AFB0
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe char CallCharMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args); // 0x000000018214AEF0-0x000000018214AF50
		public static float CallFloatMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x000000018214B0D0-0x000000018214B130
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe float CallFloatMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args); // 0x000000018214B070-0x000000018214B0D0
		public static double CallDoubleMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x000000018214B010-0x000000018214B070
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe double CallDoubleMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args); // 0x000000018214AFB0-0x000000018214B010
		public static long CallLongMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x000000018214B250-0x000000018214B2B0
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe long CallLongMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args); // 0x000000018214B1F0-0x000000018214B250
		public static string CallStaticStringMethod(IntPtr clazz, IntPtr methodID, jvalue[] args); // 0x000000018214BE70-0x000000018214BEE0
		public static string CallStaticStringMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x000000018214BE30-0x000000018214BE70
		public static unsafe string CallStaticStringMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args); // 0x000000018214BCA0-0x000000018214BE30
		[NativeMethod(IsThreadSafe = true)]
		private static unsafe JStringBinding CallStaticStringMethodUnsafeInternal(IntPtr clazz, IntPtr methodID, jvalue* args); // 0x000000018214BC20-0x000000018214BCA0
		public static IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x000000018214B9D0-0x000000018214BA30
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe IntPtr CallStaticObjectMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args); // 0x000000018214B970-0x000000018214B9D0
		public static int CallStaticIntMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x000000018214B850-0x000000018214B8B0
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe int CallStaticIntMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args); // 0x000000018214B7F0-0x000000018214B850
		public static bool CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x000000018214B550-0x000000018214B5B0
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe bool CallStaticBooleanMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args); // 0x000000018214B4F0-0x000000018214B550
		public static short CallStaticShortMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x000000018214BB50-0x000000018214BBB0
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe short CallStaticShortMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args); // 0x000000018214BAF0-0x000000018214BB50
		public static sbyte CallStaticSByteMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x000000018214BA90-0x000000018214BAF0
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe sbyte CallStaticSByteMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args); // 0x000000018214BA30-0x000000018214BA90
		public static char CallStaticCharMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x000000018214B610-0x000000018214B670
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe char CallStaticCharMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args); // 0x000000018214B5B0-0x000000018214B610
		public static float CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x000000018214B790-0x000000018214B7F0
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe float CallStaticFloatMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args); // 0x000000018214B730-0x000000018214B790
		public static double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x000000018214B6D0-0x000000018214B730
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe double CallStaticDoubleMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args); // 0x000000018214B670-0x000000018214B6D0
		public static long CallStaticLongMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x000000018214B910-0x000000018214B970
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe long CallStaticLongMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args); // 0x000000018214B8B0-0x000000018214B910
		[NativeMethod(IsThreadSafe = true)]
		private static IntPtr ConvertToBooleanArray(bool[] array); // 0x000000018214C250-0x000000018214C2D0
		public static IntPtr ToBooleanArray(bool[] array); // 0x000000018214D760-0x000000018214D7E0
		[NativeMethod(IsThreadSafe = true)]
		[Obsolete("AndroidJNI.ToByteArray is obsolete. Use AndroidJNI.ToSByteArray method instead")]
		public static IntPtr ToByteArray(byte[] array); // 0x000000018214D820-0x000000018214D8A0
		public static IntPtr ToSByteArray(sbyte[] array); // 0x000000018214DCE0-0x000000018214DD50
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe IntPtr ToSByteArray(sbyte* array, int length); // 0x000000018214DD50-0x000000018214DD90
		public static IntPtr ToCharArray(char[] array); // 0x000000018214D8E0-0x000000018214D950
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe IntPtr ToCharArray(char* array, int length); // 0x000000018214D8A0-0x000000018214D8E0
		public static IntPtr ToShortArray(short[] array); // 0x000000018214DDD0-0x000000018214DE40
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe IntPtr ToShortArray(short* array, int length); // 0x000000018214DD90-0x000000018214DDD0
		public static IntPtr ToIntArray(int[] array); // 0x000000018214DAF0-0x000000018214DB60
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe IntPtr ToIntArray(int* array, int length); // 0x000000018214DAB0-0x000000018214DAF0
		public static IntPtr ToLongArray(long[] array); // 0x000000018214DB60-0x000000018214DBD0
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe IntPtr ToLongArray(long* array, int length); // 0x000000018214DBD0-0x000000018214DC10
		public static IntPtr ToFloatArray(float[] array); // 0x000000018214DA00-0x000000018214DA70
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe IntPtr ToFloatArray(float* array, int length); // 0x000000018214DA70-0x000000018214DAB0
		public static IntPtr ToDoubleArray(double[] array); // 0x000000018214D950-0x000000018214D9C0
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe IntPtr ToDoubleArray(double* array, int length); // 0x000000018214D9C0-0x000000018214DA00
		[NativeMethod(IsThreadSafe = true)]
		public static unsafe IntPtr ToObjectArray(IntPtr* array, int length, IntPtr arrayClass); // 0x000000018214DC90-0x000000018214DCE0
		public static IntPtr ToObjectArray(IntPtr[] array, IntPtr arrayClass); // 0x000000018214DC10-0x000000018214DC90
		[NativeMethod(IsThreadSafe = true)]
		public static bool[] FromBooleanArray(IntPtr array); // 0x000000018214C590-0x000000018214C670
		[NativeMethod(IsThreadSafe = true)]
		[Obsolete("AndroidJNI.FromByteArray is obsolete. Use AndroidJNI.FromSByteArray method instead")]
		public static byte[] FromByteArray(IntPtr array); // 0x000000018214C6C0-0x000000018214C7A0
		[NativeMethod(IsThreadSafe = true)]
		public static sbyte[] FromSByteArray(IntPtr array); // 0x000000018214C920-0x000000018214C960
		[NativeMethod(IsThreadSafe = true)]
		public static char[] FromCharArray(IntPtr array); // 0x000000018214C7A0-0x000000018214C7E0
		[NativeMethod(IsThreadSafe = true)]
		public static short[] FromShortArray(IntPtr array); // 0x000000018214C960-0x000000018214C9A0
		[NativeMethod(IsThreadSafe = true)]
		public static int[] FromIntArray(IntPtr array); // 0x000000018214C860-0x000000018214C8A0
		[NativeMethod(IsThreadSafe = true)]
		public static long[] FromLongArray(IntPtr array); // 0x000000018214C8A0-0x000000018214C8E0
		[NativeMethod(IsThreadSafe = true)]
		public static float[] FromFloatArray(IntPtr array); // 0x000000018214C820-0x000000018214C860
		[NativeMethod(IsThreadSafe = true)]
		public static double[] FromDoubleArray(IntPtr array); // 0x000000018214C7E0-0x000000018214C820
		[NativeMethod(IsThreadSafe = true)]
		public static int GetArrayLength(IntPtr array); // 0x000000018214C9A0-0x000000018214C9E0
		[NativeMethod(IsThreadSafe = true)]
		public static IntPtr NewObjectArray(int size, IntPtr clazz, IntPtr obj); // 0x000000018214D340-0x000000018214D390
		[NativeMethod(IsThreadSafe = true)]
		public static IntPtr GetObjectArrayElement(IntPtr array, int index); // 0x000000018214CC90-0x000000018214CCD0
		[NativeMethod(IsThreadSafe = true)]
		public static void SetObjectArrayElement(IntPtr array, int index, IntPtr obj); // 0x000000018214D710-0x000000018214D760
		private static void ReleaseStringChars_Injected(in JStringBinding str); // 0x000000018214D690-0x000000018214D6D0
		private static IntPtr FindClass_Injected(ref ManagedSpanWrapper name); // 0x000000018214C3B0-0x000000018214C3F0
		private static IntPtr GetMethodID_Injected(IntPtr clazz, ref ManagedSpanWrapper name, ref ManagedSpanWrapper sig); // 0x000000018214C9E0-0x000000018214CA40
		private static IntPtr GetStaticMethodID_Injected(IntPtr clazz, ref ManagedSpanWrapper name, ref ManagedSpanWrapper sig); // 0x000000018214CD10-0x000000018214CD70
		private static IntPtr NewStringFromStr_Injected(ref ManagedSpanWrapper chars); // 0x000000018214D3F0-0x000000018214D430
		private static void GetStringCharsInternal_Injected(IntPtr str, ); // 0x000000018214CFC0-0x000000018214D010
		private static unsafe void CallStringMethodUnsafeInternal_Injected(IntPtr obj, IntPtr methodID, jvalue* args, ); // 0x000000018214BEE0-0x000000018214BF50
		private static unsafe void CallStaticStringMethodUnsafeInternal_Injected(IntPtr clazz, IntPtr methodID, jvalue* args, ); // 0x000000018214BBB0-0x000000018214BC20
		private static IntPtr ConvertToBooleanArray_Injected(ref ManagedSpanWrapper array); // 0x000000018214C210-0x000000018214C250
		private static IntPtr ToByteArray_Injected(ref ManagedSpanWrapper array); // 0x000000018214D7E0-0x000000018214D820
		private static void FromBooleanArray_Injected(IntPtr array, ); // 0x000000018214C540-0x000000018214C590
		private static void FromByteArray_Injected(IntPtr array, ); // 0x000000018214C670-0x000000018214C6C0
	}
}
