/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	public static class TMPro_ExtensionMethods // TypeDefIndex: 11927
	{
		// Methods
		private static byte GammaToLinear(byte value); // 0x00000001820F4540-0x00000001820F45F0
	
		// Extension methods
		internal static int TagToInt(this string s); // 0x00000001820F48E0-0x00000001820F4990
		public static int[] ToIntArray(this string text); // 0x00000001820F4A80-0x00000001820F4B20
		public static string ArrayToString(this char[] chars); // 0x00000001820F4270-0x00000001820F4340
		public static string IntToString(this int[] unicodes); // 0x00000001820F4640-0x00000001820F46D0
		internal static string UintToString(this List<uint> unicodes); // 0x00000001820F4B20-0x00000001820F4BD0
		public static string IntToString(this int[] unicodes, int start, int length); // 0x00000001820F46D0-0x00000001820F47D0
		public static int FindInstanceID<T>(this List<T> list, T target)
			where T : UnityEngine.Object;
		public static bool Compare(this Color32 a, Color32 b); // 0x00000001820F43A0-0x00000001820F43E0
		public static bool CompareRGB(this Color32 a, Color32 b); // 0x00000001820F4370-0x00000001820F43A0
		public static bool Compare(this Color a, Color b); // 0x000000018192E0B0-0x000000018192E0F0
		public static bool CompareRGB(this Color a, Color b); // 0x00000001820F4340-0x00000001820F4370
		public static Color32 Multiply(this Color32 c1, Color32 c2); // 0x00000001820F4800-0x00000001820F48E0
		public static Color32 Tint(this Color32 c1, Color32 c2); // 0x00000001820F4800-0x00000001820F48E0
		public static Color32 Tint(this Color32 c1, float tint); // 0x00000001820F4990-0x00000001820F4A80
		internal static Color32 GammaToLinear(this Color32 c); // 0x00000001820F45F0-0x00000001820F4640
		public static Color MinAlpha(this Color c1, Color c2); // 0x00000001820F47D0-0x00000001820F4800
		public static bool Compare(this Vector3 v1, Vector3 v2, int accuracy); // 0x00000001820F44B0-0x00000001820F4540
		public static bool Compare(this Quaternion q1, Quaternion q2, int accuracy); // 0x00000001820F43E0-0x00000001820F44B0
	}
}
