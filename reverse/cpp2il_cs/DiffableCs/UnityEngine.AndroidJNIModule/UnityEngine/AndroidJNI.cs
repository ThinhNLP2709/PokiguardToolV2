namespace UnityEngine;

[NativeConditional("PLATFORM_ANDROID")]
[NativeHeader("Modules/AndroidJNI/Public/AndroidJNIBindingsHelpers.h")]
[StaticAccessor("AndroidJNIBindingsHelpers", StaticAccessorType::DoubleColon (2))]
public static class AndroidJNI
{
	private struct JStringBinding : IDisposable
	{
		private IntPtr javaString; //Field offset: 0x0
		private IntPtr chars; //Field offset: 0x8
		private int length; //Field offset: 0x10
		private bool ownsRef; //Field offset: 0x14

		public override void Dispose() { }

		public virtual string ToString() { }

	}


	public static bool CallBooleanMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static bool CallBooleanMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static char CallCharMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static char CallCharMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static double CallDoubleMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static double CallDoubleMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static float CallFloatMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static float CallFloatMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static int CallIntMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static int CallIntMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static long CallLongMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static long CallLongMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static IntPtr CallObjectMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static IntPtr CallObjectMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static sbyte CallSByteMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static sbyte CallSByteMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static short CallShortMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static short CallShortMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	public static bool CallStaticBooleanMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static bool CallStaticBooleanMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static char CallStaticCharMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static char CallStaticCharMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static double CallStaticDoubleMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static double CallStaticDoubleMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static float CallStaticFloatMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static float CallStaticFloatMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static int CallStaticIntMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static int CallStaticIntMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static long CallStaticLongMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static long CallStaticLongMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static IntPtr CallStaticObjectMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static IntPtr CallStaticObjectMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static sbyte CallStaticSByteMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static sbyte CallStaticSByteMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static short CallStaticShortMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static short CallStaticShortMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	public static string CallStaticStringMethod(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	public static string CallStaticStringMethod(IntPtr clazz, IntPtr methodID, jvalue[] args) { }

	public static string CallStaticStringMethodUnsafe(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	[ThreadSafe]
	private static JStringBinding CallStaticStringMethodUnsafeInternal(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	private static void CallStaticStringMethodUnsafeInternal_Injected(IntPtr clazz, IntPtr methodID, jvalue* args, out JStringBinding ret) { }

	public static string CallStringMethod(IntPtr obj, IntPtr methodID, Span<jvalue> args) { }

	public static string CallStringMethod(IntPtr obj, IntPtr methodID, jvalue[] args) { }

	public static string CallStringMethodUnsafe(IntPtr obj, IntPtr methodID, jvalue* args) { }

	[ThreadSafe]
	private static JStringBinding CallStringMethodUnsafeInternal(IntPtr obj, IntPtr methodID, jvalue* args) { }

	private static void CallStringMethodUnsafeInternal_Injected(IntPtr obj, IntPtr methodID, jvalue* args, out JStringBinding ret) { }

	[ThreadSafe]
	public static void DeleteLocalRef(IntPtr obj) { }

	[ThreadSafe]
	public static void DeleteWeakGlobalRef(IntPtr obj) { }

	[ThreadSafe]
	public static void ExceptionClear() { }

	[ThreadSafe]
	public static IntPtr ExceptionOccurred() { }

	[ThreadSafe]
	public static IntPtr FindClass(string name) { }

	private static IntPtr FindClass_Injected(ref ManagedSpanWrapper name) { }

	[ThreadSafe]
	public static Boolean[] FromBooleanArray(IntPtr array) { }

	private static void FromBooleanArray_Injected(IntPtr array, out BlittableArrayWrapper ret) { }

	[Obsolete("AndroidJNI.FromByteArray is obsolete. Use AndroidJNI.FromSByteArray method instead")]
	[ThreadSafe]
	public static Byte[] FromByteArray(IntPtr array) { }

	private static void FromByteArray_Injected(IntPtr array, out BlittableArrayWrapper ret) { }

	[ThreadSafe]
	public static Char[] FromCharArray(IntPtr array) { }

	[ThreadSafe]
	public static Double[] FromDoubleArray(IntPtr array) { }

	[ThreadSafe]
	public static Single[] FromFloatArray(IntPtr array) { }

	[ThreadSafe]
	public static Int32[] FromIntArray(IntPtr array) { }

	[ThreadSafe]
	public static Int64[] FromLongArray(IntPtr array) { }

	[ThreadSafe]
	public static IntPtr FromReflectedMethod(IntPtr refMethod) { }

	[ThreadSafe]
	public static SByte[] FromSByteArray(IntPtr array) { }

	[ThreadSafe]
	public static Int16[] FromShortArray(IntPtr array) { }

	[ThreadSafe]
	public static int GetArrayLength(IntPtr array) { }

	[ThreadSafe]
	public static IntPtr GetMethodID(IntPtr clazz, string name, string sig) { }

	private static IntPtr GetMethodID_Injected(IntPtr clazz, ref ManagedSpanWrapper name, ref ManagedSpanWrapper sig) { }

	[ThreadSafe]
	public static IntPtr GetObjectArrayElement(IntPtr array, int index) { }

	[ThreadSafe]
	public static IntPtr GetObjectClass(IntPtr obj) { }

	[ThreadSafe]
	public static IntPtr GetStaticMethodID(IntPtr clazz, string name, string sig) { }

	private static IntPtr GetStaticMethodID_Injected(IntPtr clazz, ref ManagedSpanWrapper name, ref ManagedSpanWrapper sig) { }

	public static string GetStringChars(IntPtr str) { }

	[ThreadSafe]
	private static JStringBinding GetStringCharsInternal(IntPtr str) { }

	private static void GetStringCharsInternal_Injected(IntPtr str, out JStringBinding ret) { }

	[RequiredByNativeCode]
	private static void InvokeAction(Action action) { }

	[ThreadSafe]
	public static bool IsSameObject(IntPtr obj1, IntPtr obj2) { }

	[ThreadSafe]
	public static IntPtr NewGlobalRef(IntPtr obj) { }

	[ThreadSafe]
	public static IntPtr NewLocalRef(IntPtr obj) { }

	public static IntPtr NewObject(IntPtr clazz, IntPtr methodID, Span<jvalue> args) { }

	[ThreadSafe]
	public static IntPtr NewObjectA(IntPtr clazz, IntPtr methodID, jvalue* args) { }

	[ThreadSafe]
	public static IntPtr NewObjectArray(int size, IntPtr clazz, IntPtr obj) { }

	public static IntPtr NewString(string chars) { }

	[ThreadSafe]
	private static IntPtr NewStringFromStr(string chars) { }

	private static IntPtr NewStringFromStr_Injected(ref ManagedSpanWrapper chars) { }

	[ThreadSafe]
	public static IntPtr NewWeakGlobalRef(IntPtr obj) { }

	[ThreadSafe]
	public static IntPtr PopLocalFrame(IntPtr ptr) { }

	[ThreadSafe]
	public static int PushLocalFrame(int capacity) { }

	[ThreadSafe]
	internal static void QueueDeleteGlobalRef(IntPtr obj) { }

	[ThreadSafe]
	private static void ReleaseStringChars(JStringBinding str) { }

	private static void ReleaseStringChars_Injected(in JStringBinding str) { }

	[ThreadSafe]
	public static void SetObjectArrayElement(IntPtr array, int index, IntPtr obj) { }

	[ThreadSafe]
	public static IntPtr ToBooleanArray(Boolean[] array) { }

	private static IntPtr ToBooleanArray_Injected(ref ManagedSpanWrapper array) { }

	[Obsolete("AndroidJNI.ToByteArray is obsolete. Use AndroidJNI.ToSByteArray method instead")]
	[ThreadSafe]
	public static IntPtr ToByteArray(Byte[] array) { }

	private static IntPtr ToByteArray_Injected(ref ManagedSpanWrapper array) { }

	public static IntPtr ToCharArray(Char[] array) { }

	[ThreadSafe]
	public static IntPtr ToCharArray(Char* array, int length) { }

	[ThreadSafe]
	public static IntPtr ToDoubleArray(Double* array, int length) { }

	public static IntPtr ToDoubleArray(Double[] array) { }

	public static IntPtr ToFloatArray(Single[] array) { }

	[ThreadSafe]
	public static IntPtr ToFloatArray(Single* array, int length) { }

	public static IntPtr ToIntArray(Int32[] array) { }

	[ThreadSafe]
	public static IntPtr ToIntArray(Int32* array, int length) { }

	public static IntPtr ToLongArray(Int64[] array) { }

	[ThreadSafe]
	public static IntPtr ToLongArray(Int64* array, int length) { }

	public static IntPtr ToObjectArray(IntPtr[] array, IntPtr arrayClass) { }

	[ThreadSafe]
	public static IntPtr ToObjectArray(IntPtr* array, int length, IntPtr arrayClass) { }

	[ThreadSafe]
	public static IntPtr ToSByteArray(SByte* array, int length) { }

	public static IntPtr ToSByteArray(SByte[] array) { }

	public static IntPtr ToShortArray(Int16[] array) { }

	[ThreadSafe]
	public static IntPtr ToShortArray(Int16* array, int length) { }

}

