/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using Unity.Collections;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("TextAsset", PersistentTypeId = 49)]
	[NativeHeader("Runtime/Scripting/TextAsset.h")]
	public class TextAsset : Object // TypeDefIndex: 7775
	{
		// Properties
		public byte[] bytes { get; } // 0x00000001821FAAF0-0x00000001821FAB50 
		public string text { get; } // 0x00000001821FAB50-0x00000001821FABD0 
		public long dataSize { get; } // 0x00000001821FA390-0x00000001821FA3F0 
	
		// Nested types
		internal enum CreateOptions // TypeDefIndex: 7776
		{
			None = 0,
			CreateNativeObject = 1
		}
	
		private static class EncodingUtility // TypeDefIndex: 7777
		{
			// Fields
			[NoAutoStaticsCleanup]
			internal static readonly KeyValuePair<byte[], Encoding>[] encodingLookup; // 0x00
			[NoAutoStaticsCleanup]
			internal static readonly Encoding targetEncoding; // 0x08
	
			// Constructors
			static EncodingUtility(); // 0x00000001821E5A00-0x00000001821E5E50
		}
	
		// Constructors
		public TextAsset(); // 0x00000001821FA7E0-0x00000001821FA840
		public TextAsset(string text); // 0x00000001821FA8F0-0x00000001821FA960
		public TextAsset(ReadOnlySpan<byte> bytes); // 0x00000001821FA840-0x00000001821FA8F0
		internal TextAsset(CreateOptions options, string text); // 0x00000001821FA960-0x00000001821FA9E0
		internal TextAsset(CreateOptions options, ReadOnlySpan<byte> bytes); // 0x00000001821FA9E0-0x00000001821FAAB0
	
		// Methods
		private byte[] GetPreviewBytes(int maxByteCount); // 0x00000001821FA430-0x00000001821FA490
		private static void Internal_CreateInstance([Writable] TextAsset self, string text); // 0x00000001821FA610-0x00000001821FA760
		private static void Internal_CreateInstanceFromBytes([Writable] TextAsset self, ReadOnlySpan<byte> bytes); // 0x00000001821FA550-0x00000001821FA5C0
		private IntPtr GetDataPtr(); // 0x00000001821FA2F0-0x00000001821FA350
		private long GetDataSize(); // 0x00000001821FA390-0x00000001821FA3F0
		public override string ToString(); // 0x00000001821FA760-0x00000001821FA7E0
		public NativeArray<T> GetData<T>()
			where T : struct;
		internal string GetPreview(int maxChars); // 0x00000001821FA490-0x00000001821FA500
		internal static string DecodeString(byte[] bytes); // 0x00000001821FA040-0x00000001821FA2B0
		private static byte[] get_bytes_Injected(IntPtr _unity_self); // 0x00000001821FAAB0-0x00000001821FAAF0
		private static byte[] GetPreviewBytes_Injected(IntPtr _unity_self, int maxByteCount); // 0x00000001821FA3F0-0x00000001821FA430
		private static void Internal_CreateInstance_Injected([Writable] TextAsset self, ref ManagedSpanWrapper text); // 0x00000001821FA5C0-0x00000001821FA610
		private static void Internal_CreateInstanceFromBytes_Injected([Writable] TextAsset self, ref ManagedSpanWrapper bytes); // 0x00000001821FA500-0x00000001821FA550
		private static IntPtr GetDataPtr_Injected(IntPtr _unity_self); // 0x00000001821FA2B0-0x00000001821FA2F0
		private static long GetDataSize_Injected(IntPtr _unity_self); // 0x00000001821FA350-0x00000001821FA390
	}
}
