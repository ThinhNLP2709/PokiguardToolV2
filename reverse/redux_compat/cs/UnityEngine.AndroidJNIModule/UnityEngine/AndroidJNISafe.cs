/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 33: UnityEngine.AndroidJNIModule.dll - Assembly: UnityEngine.AndroidJNIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14765-14805

namespace UnityEngine
{
	internal class AndroidJNISafe // TypeDefIndex: 14782
	{
		// Methods
		public static void CheckException(); // 0x0000000182149AB0-0x0000000182149CE0
		public static void QueueDeleteGlobalRef(IntPtr globalref); // 0x000000018214A6C0-0x000000018214A700
		public static void DeleteWeakGlobalRef(IntPtr globalref); // 0x0000000182149D20-0x0000000182149D60
		public static void DeleteLocalRef(IntPtr localref); // 0x0000000182149CE0-0x0000000182149D20
		public static IntPtr NewString(string chars); // 0x000000018214A610-0x000000018214A670
		public static string GetStringChars(IntPtr str); // 0x000000018214A4F0-0x000000018214A550
		public static IntPtr GetObjectClass(IntPtr ptr); // 0x000000018214A400-0x000000018214A480
		public static IntPtr GetStaticMethodID(IntPtr clazz, string name, string sig); // 0x000000018214A480-0x000000018214A4F0
		public static IntPtr GetMethodID(IntPtr obj, string name, string sig); // 0x000000018214A300-0x000000018214A370
		public static IntPtr FromReflectedMethod(IntPtr refMethod); // 0x000000018214A100-0x000000018214A180
		public static IntPtr FindClass(string name); // 0x0000000182149D60-0x0000000182149DC0
		public static void PushLocalFrame(int capacity); // 0x000000018214A670-0x000000018214A6C0
		public static IntPtr NewObject(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x000000018214A550-0x000000018214A610
		public static IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, jvalue[] args); // 0x0000000182149760-0x00000001821497B0
		public static IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x00000001821496A0-0x0000000182149760
		public static string CallStaticStringMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x0000000182149930-0x00000001821499F0
		public static char CallStaticCharMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x00000001821492C0-0x0000000182149380
		public static double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x0000000182149380-0x0000000182149450
		public static float CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x0000000182149450-0x0000000182149520
		public static long CallStaticLongMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x00000001821495E0-0x00000001821496A0
		public static short CallStaticShortMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x0000000182149870-0x0000000182149930
		public static sbyte CallStaticSByteMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x00000001821497B0-0x0000000182149870
		public static bool CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x0000000182149200-0x00000001821492C0
		public static int CallStaticIntMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args); // 0x0000000182149520-0x00000001821495E0
		public static IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x0000000182148FC0-0x0000000182149080
		public static string CallStringMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x00000001821499F0-0x0000000182149AB0
		public static char CallCharMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x0000000182148BE0-0x0000000182148CA0
		public static double CallDoubleMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x0000000182148CA0-0x0000000182148D70
		public static float CallFloatMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x0000000182148D70-0x0000000182148E40
		public static long CallLongMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x0000000182148F00-0x0000000182148FC0
		public static short CallShortMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x0000000182149140-0x0000000182149200
		public static sbyte CallSByteMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x0000000182149080-0x0000000182149140
		public static bool CallBooleanMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x0000000182148B20-0x0000000182148BE0
		public static int CallIntMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args); // 0x0000000182148E40-0x0000000182148F00
		public static char[] FromCharArray(IntPtr array); // 0x0000000182149E80-0x0000000182149F00
		public static double[] FromDoubleArray(IntPtr array); // 0x0000000182149F00-0x0000000182149F80
		public static float[] FromFloatArray(IntPtr array); // 0x0000000182149F80-0x000000018214A000
		public static long[] FromLongArray(IntPtr array); // 0x000000018214A080-0x000000018214A100
		public static short[] FromShortArray(IntPtr array); // 0x000000018214A200-0x000000018214A280
		public static byte[] FromByteArray(IntPtr array); // 0x0000000182149E20-0x0000000182149E80
		public static sbyte[] FromSByteArray(IntPtr array); // 0x000000018214A180-0x000000018214A200
		public static bool[] FromBooleanArray(IntPtr array); // 0x0000000182149DC0-0x0000000182149E20
		public static int[] FromIntArray(IntPtr array); // 0x000000018214A000-0x000000018214A080
		public static IntPtr ToObjectArray(IntPtr[] array, IntPtr type); // 0x000000018214AC10-0x000000018214ACD0
		public static IntPtr ToCharArray(char[] array); // 0x000000018214A8A0-0x000000018214A950
		public static IntPtr ToDoubleArray(double[] array); // 0x000000018214A950-0x000000018214AA00
		public static IntPtr ToFloatArray(float[] array); // 0x000000018214AA00-0x000000018214AAB0
		public static IntPtr ToLongArray(long[] array); // 0x000000018214AB60-0x000000018214AC10
		public static IntPtr ToShortArray(short[] array); // 0x000000018214AD80-0x000000018214AE30
		public static IntPtr ToByteArray(byte[] array); // 0x000000018214A7D0-0x000000018214A8A0
		public static IntPtr ToSByteArray(sbyte[] array); // 0x000000018214ACD0-0x000000018214AD80
		public static IntPtr ToBooleanArray(bool[] array); // 0x000000018214A700-0x000000018214A7D0
		public static IntPtr ToIntArray(int[] array); // 0x000000018214AAB0-0x000000018214AB60
		public static IntPtr GetObjectArrayElement(IntPtr array, int index); // 0x000000018214A370-0x000000018214A400
		public static int GetArrayLength(IntPtr array); // 0x000000018214A280-0x000000018214A300
	}
}
