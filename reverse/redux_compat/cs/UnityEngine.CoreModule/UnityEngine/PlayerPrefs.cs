/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/Utilities/PlayerPrefs.h")]
	public class PlayerPrefs // TypeDefIndex: 7682
	{
		// Methods
		[NativeMethod("SetInt")]
		private static bool TrySetInt(string key, int value); // 0x00000001821F61A0-0x00000001821F6300
		[NativeMethod("SetFloat")]
		private static bool TrySetFloat(string key, float value); // 0x00000001821F6000-0x00000001821F6160
		[NativeMethod("SetString")]
		private static bool TrySetSetString(string key, string value); // 0x00000001821F6350-0x00000001821F6590
		public static void SetInt(string key, int value); // 0x00000001821F5ED0-0x00000001821F5F40
		public static int GetInt(string key, int defaultValue); // 0x00000001821F5830-0x00000001821F5990
		public static int GetInt(string key); // 0x00000001821F5820-0x00000001821F5830
		public static void SetFloat(string key, float value); // 0x00000001821F5E60-0x00000001821F5ED0
		public static float GetFloat(string key, float defaultValue); // 0x00000001821F5670-0x00000001821F57E0
		public static void SetString(string key, string value); // 0x00000001821F5F40-0x00000001821F5FB0
		public static string GetString(string key, string defaultValue); // 0x00000001821F5A30-0x00000001821F5CA0
		public static string GetString(string key); // 0x00000001821F59F0-0x00000001821F5A30
		public static bool HasKey(string key); // 0x00000001821F5CE0-0x00000001821F5E30
		public static void DeleteKey(string key); // 0x00000001821F54E0-0x00000001821F5620
		[NativeMethod("Sync")]
		public static void Save(); // 0x00000001821F5E30-0x00000001821F5E60
		private static bool TrySetInt_Injected(ref ManagedSpanWrapper key, int value); // 0x00000001821F6160-0x00000001821F61A0
		private static bool TrySetFloat_Injected(ref ManagedSpanWrapper key, float value); // 0x00000001821F5FB0-0x00000001821F6000
		private static bool TrySetSetString_Injected(ref ManagedSpanWrapper key, ref ManagedSpanWrapper value); // 0x00000001821F6300-0x00000001821F6350
		private static int GetInt_Injected(ref ManagedSpanWrapper key, int defaultValue); // 0x00000001821F57E0-0x00000001821F5820
		private static float GetFloat_Injected(ref ManagedSpanWrapper key, float defaultValue); // 0x00000001821F5620-0x00000001821F5670
		private static void GetString_Injected(ref ManagedSpanWrapper key, ref ManagedSpanWrapper defaultValue, ); // 0x00000001821F5990-0x00000001821F59F0
		private static bool HasKey_Injected(ref ManagedSpanWrapper key); // 0x00000001821F5CA0-0x00000001821F5CE0
		private static void DeleteKey_Injected(ref ManagedSpanWrapper key); // 0x00000001821F54A0-0x00000001821F54E0
	}
}
