/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 71: UnityEngine.JSONSerializeModule.dll - Assembly: UnityEngine.JSONSerializeModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15862-15865

namespace UnityEngine
{
	[NativeHeader("Modules/JSONSerialize/Public/JsonUtility.bindings.h")]
	public static class JsonUtility // TypeDefIndex: 15865
	{
		// Methods
		[FreeFunction("ToJsonInternal", IsThreadSafe = true)]
		private static string ToJsonInternal([NotNull] object obj, bool prettyPrint); // 0x00000001822AEEF0-0x00000001822AF010
		[FreeFunction("FromJsonInternal", true, ThrowsException = true, IsThreadSafe = true)]
		private static object FromJsonInternal(string json, object objectToOverwrite, Type type); // 0x00000001822AEB90-0x00000001822AED00
		public static string ToJson(object obj); // 0x00000001822AF010-0x00000001822AF150
		public static string ToJson(object obj, bool prettyPrint); // 0x00000001822AF150-0x00000001822AF2A0
		public static T FromJson<T>(string json);
		public static object FromJson(string json, Type type); // 0x00000001822AED00-0x00000001822AEE90
		private static void ToJsonInternal_Injected(object obj, bool prettyPrint, ); // 0x00000001822AEE90-0x00000001822AEEF0
		private static object FromJsonInternal_Injected(ref ManagedSpanWrapper json, object objectToOverwrite, Type type); // 0x00000001822AEB30-0x00000001822AEB90
	}
}
