/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.InteropServices
{
	public static class Marshal // TypeDefIndex: 3154
	{
		// Fields
		public static readonly int SystemMaxDBCSCharSize; // 0x00
		public static readonly int SystemDefaultCharSize; // 0x04
		internal static Dictionary<ValueTuple<Type, string>, ICustomMarshaler> MarshalerInstanceCache; // 0x08
		internal static readonly object MarshalerInstanceCacheLock; // 0x10
	
		// Nested types
		internal delegate IntPtr SecureStringAllocator(int len); // TypeDefIndex: 3155; 0x00000001804A78A0-0x00000001804A78B0
	
		internal class MarshalerInstanceKeyComparer : IEqualityComparer<ValueTuple<Type, string>> // TypeDefIndex: 3156
		{
			// Constructors
			public MarshalerInstanceKeyComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public bool Equals(ValueTuple<Type, string> lhs, ValueTuple<Type, string> rhs); // 0x0000000181511920-0x0000000181511980
			public int GetHashCode(ValueTuple<Type, string> key); // 0x0000000181511980-0x00000001815119C0
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3157
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<Dictionary<ValueTuple<Type, string>, ICustomMarshaler>> __9__201_0; // 0x08
	
			// Constructors
			static __c(); // 0x000000018151C160-0x000000018151C1D0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal Dictionary<ValueTuple<Type, string>, ICustomMarshaler> _GetCustomMarshalerInstance_b__201_0(); // 0x000000018151BDB0-0x000000018151BE40
		}
	
		// Constructors
		static Marshal(); // 0x0000000181511640-0x00000001815116D0
	
		// Methods
		private static int AddRefInternal(IntPtr pUnk); // 0x000000018150DE40-0x000000018150DE50
		public static int AddRef(IntPtr pUnk); // 0x000000018150DE50-0x000000018150DED0
		public static IntPtr AllocCoTaskMem(int cb); // 0x000000018150DEE0-0x000000018150DEF0
		internal static IntPtr AllocCoTaskMemSize(UIntPtr sizet); // 0x000000018150DED0-0x000000018150DEE0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static IntPtr AllocHGlobal(IntPtr cb); // 0x000000018150DEF0-0x000000018150DF00
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static IntPtr AllocHGlobal(int cb); // 0x000000018150DF00-0x000000018150DF40
		internal static void copy_to_unmanaged(Array source, int startIndex, IntPtr destination, int length); // 0x0000000181511760-0x00000001815117D0
		private static unsafe void copy_to_unmanaged_fixed(Array source, int startIndex, IntPtr destination, int length, void* fixed_source_element); // 0x0000000181511750-0x0000000181511760
		private static bool skip_fixed(Array array, int startIndex); // 0x00000001815118F0-0x0000000181511920
		internal static void copy_to_unmanaged(byte[] source, int startIndex, IntPtr destination, int length); // 0x0000000181511860-0x00000001815118F0
		internal static void copy_to_unmanaged(char[] source, int startIndex, IntPtr destination, int length); // 0x00000001815117D0-0x0000000181511860
		public static void Copy(byte[] source, int startIndex, IntPtr destination, int length); // 0x000000018150EF50-0x000000018150F000
		public static void Copy(short[] source, int startIndex, IntPtr destination, int length); // 0x000000018150F160-0x000000018150F210
		public static void Copy(int[] source, int startIndex, IntPtr destination, int length); // 0x000000018150F000-0x000000018150F0B0
		public static void Copy(IntPtr[] source, int startIndex, IntPtr destination, int length); // 0x000000018150F0B0-0x000000018150F160
		internal static void copy_from_unmanaged(IntPtr source, int startIndex, Array destination, int length); // 0x00000001815116E0-0x0000000181511750
		private static unsafe void copy_from_unmanaged_fixed(IntPtr source, int startIndex, Array destination, int length, void* fixed_destination_element); // 0x00000001815116D0-0x00000001815116E0
		public static void Copy(IntPtr source, byte[] destination, int startIndex, int length); // 0x000000018150F420-0x000000018150F4D0
		public static void Copy(IntPtr source, char[] destination, int startIndex, int length); // 0x000000018150F210-0x000000018150F2C0
		public static void Copy(IntPtr source, int[] destination, int startIndex, int length); // 0x000000018150F2C0-0x000000018150F370
		public static void Copy(IntPtr source, IntPtr[] destination, int startIndex, int length); // 0x000000018150F370-0x000000018150F420
		public static void FreeBSTR(IntPtr ptr); // 0x000000018150F4D0-0x000000018150F4E0
		public static void FreeCoTaskMem(IntPtr ptr); // 0x000000018150F4E0-0x000000018150F4F0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static void FreeHGlobal(IntPtr hglobal); // 0x000000018150F4F0-0x000000018150F500
		private static void ClearUnicode(IntPtr ptr); // 0x000000018150DF50-0x000000018150E050
		public static void ZeroFreeGlobalAllocUnicode(IntPtr s); // 0x0000000181511510-0x0000000181511640
		private static IntPtr GetCCW(object o, Type T); // 0x000000018150F500-0x000000018150F510
		private static IntPtr GetComInterfaceForObjectInternal(object o, Type T); // 0x000000018150F510-0x000000018150F550
		public static IntPtr GetComInterfaceForObject(object o, Type T); // 0x000000018150F550-0x000000018150F620
		public static int GetHRForException(Exception e); // 0x0000000181510150-0x0000000181510160
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int GetHRForLastWin32Error(); // 0x0000000181510160-0x00000001815101A0
		public static void GetNativeVariantForObject(object obj, IntPtr pDstNativeVariant); // 0x00000001815101B0-0x0000000181510260
		private static object GetObjectForCCW(IntPtr pUnk); // 0x0000000181510260-0x0000000181510270
		public static object GetObjectForIUnknown(IntPtr pUnk); // 0x0000000181510270-0x00000001815102A0
		public static bool IsComObject(object o); // 0x00000001815102A0-0x00000001815102B0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int GetLastWin32Error(); // 0x00000001815101A0-0x00000001815101B0
		public static IntPtr OffsetOf(Type t, string fieldName); // 0x00000001815102B0-0x00000001815102C0
		public static string PtrToStringAnsi(IntPtr ptr); // 0x00000001815102C0-0x00000001815102D0
		public static string PtrToStringAnsi(IntPtr ptr, int len); // 0x00000001815102D0-0x00000001815102E0
		public static string PtrToStringUni(IntPtr ptr); // 0x00000001815102E0-0x00000001815102F0
		public static string PtrToStringUni(IntPtr ptr, int len); // 0x00000001815102F0-0x0000000181510300
		[ComVisible(true)]
		public static object PtrToStructure(IntPtr ptr, Type structureType); // 0x0000000181510300-0x0000000181510310
		public static T PtrToStructure<T>(IntPtr ptr);
		private static int QueryInterfaceInternal(IntPtr pUnk, ref Guid iid, out IntPtr ppv); // 0x0000000181510310-0x0000000181510320
		public static int QueryInterface(IntPtr pUnk, ref Guid iid, out IntPtr ppv); // 0x0000000181510320-0x00000001815103C0
		public static short ReadInt16(IntPtr ptr, int ofs); // 0x00000001815103C0-0x0000000181510410
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int ReadInt32(IntPtr ptr); // 0x0000000181510410-0x0000000181510450
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static long ReadInt64(IntPtr ptr); // 0x0000000181510450-0x00000001815104B0
		public static long ReadInt64(IntPtr ptr, int ofs); // 0x00000001815104B0-0x0000000181510500
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static IntPtr ReadIntPtr(IntPtr ptr); // 0x0000000181510500-0x00000001815105E0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		private static int ReleaseInternal(IntPtr pUnk); // 0x00000001815105E0-0x00000001815105F0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public static int Release(IntPtr pUnk); // 0x00000001815105F0-0x0000000181510670
		public static int SizeOf(Type t); // 0x0000000181510AB0-0x0000000181510AC0
		public static int SizeOf<T>();
		public static int SizeOf<T>(T structure);
		public static IntPtr StringToBSTR(string s); // 0x0000000181510C40-0x0000000181510CA0
		public static IntPtr StringToCoTaskMemAnsi(string s); // 0x0000000181510CA0-0x0000000181510E30
		public static IntPtr StringToCoTaskMemAuto(string s); // 0x0000000181510E30-0x00000001815110C0
		public static IntPtr StringToCoTaskMemUni(string s); // 0x00000001815110C0-0x00000001815111D0
		private static unsafe IntPtr StringToHGlobalAnsi(char* s, int length); // 0x00000001815111D0-0x00000001815111E0
		public static IntPtr StringToHGlobalAnsi(string s); // 0x00000001815111E0-0x0000000181511240
		public static IntPtr StringToAllocatedMemoryUTF8(string s); // 0x0000000181510AC0-0x0000000181510C40
		private static unsafe IntPtr StringToHGlobalUni(char* s, int length); // 0x00000001815112A0-0x00000001815112B0
		public static IntPtr StringToHGlobalUni(string s); // 0x0000000181511240-0x00000001815112A0
		internal static IntPtr SecureStringGlobalAllocator(int len); // 0x0000000181510670-0x00000001815106C0
		internal static IntPtr SecureStringToUnicode(SecureString s, SecureStringAllocator allocator); // 0x0000000181510820-0x0000000181510AB0
		public static IntPtr SecureStringToGlobalAllocUnicode(SecureString s); // 0x00000001815106C0-0x0000000181510820
		[ComVisible(true)]
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public static void StructureToPtr(object structure, IntPtr ptr, bool fDeleteOld); // 0x00000001815112B0-0x00000001815112C0
		public static void StructureToPtr<T>(T structure, IntPtr ptr, bool fDeleteOld);
		public static void ThrowExceptionForHR(int errorCode); // 0x00000001815112C0-0x0000000181511340
		private static unsafe IntPtr BufferToBSTR(char* ptr, int slen); // 0x000000018150DF40-0x000000018150DF50
		public static IntPtr UnsafeAddrOfPinnedArrayElement(Array arr, int index); // 0x0000000181511340-0x0000000181511350
		public static IntPtr UnsafeAddrOfPinnedArrayElement<T>(T[] arr, int index);
		public static void WriteInt16(IntPtr ptr, int ofs, short val); // 0x0000000181511350-0x00000001815113A0
		public static void WriteInt32(IntPtr ptr, int val); // 0x00000001815113A0-0x00000001815113E0
		public static void WriteInt64(IntPtr ptr, long val); // 0x00000001815113E0-0x0000000181511420
		public static void WriteIntPtr(IntPtr ptr, IntPtr val); // 0x0000000181511420-0x0000000181511510
		private static Exception ConvertHrToException(int errorCode); // 0x000000018150E050-0x000000018150EF50
		public static Exception GetExceptionForHR(int errorCode); // 0x0000000181510080-0x00000001815100C0
		public static Exception GetExceptionForHR(int errorCode, IntPtr errorInfo); // 0x0000000181510050-0x0000000181510080
		private static Delegate GetDelegateForFunctionPointerInternal(IntPtr ptr, Type t); // 0x000000018150FE20-0x000000018150FE30
		public static Delegate GetDelegateForFunctionPointer(IntPtr ptr, Type t); // 0x000000018150FE30-0x0000000181510050
		public static TDelegate GetDelegateForFunctionPointer<TDelegate>(IntPtr ptr);
		private static IntPtr GetFunctionPointerForDelegateInternal(Delegate d); // 0x00000001815100C0-0x00000001815100D0
		public static IntPtr GetFunctionPointerForDelegate(Delegate d); // 0x00000001815100D0-0x0000000181510150
		public static IntPtr GetFunctionPointerForDelegate<TDelegate>(TDelegate d);
		internal static ICustomMarshaler GetCustomMarshalerInstance(Type type, string cookie); // 0x000000018150F620-0x000000018150FE20
	}
}
