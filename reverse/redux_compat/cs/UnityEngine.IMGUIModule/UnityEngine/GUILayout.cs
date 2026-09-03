/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 23: UnityEngine.IMGUIModule.dll - Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13910-13956

namespace UnityEngine
{
	public class GUILayout // TypeDefIndex: 13927
	{
		// Methods
		public static void Label(string text, params GUILayoutOption[] options); // 0x0000000182280FE0-0x0000000182281080
		public static void Label(string text, GUIStyle style, params GUILayoutOption[] options); // 0x0000000182281080-0x0000000182281100
		private static void DoLabel(GUIContent content, GUIStyle style, GUILayoutOption[] options); // 0x00000001822802C0-0x0000000182280410
		public static bool Button(string text, params GUILayoutOption[] options); // 0x0000000182280050-0x00000001822801C0
		private static bool DoButton(GUIContent content, GUIStyle style, GUILayoutOption[] options); // 0x00000001822801C0-0x00000001822802C0
		public static string TextField(string text, params GUILayoutOption[] options); // 0x0000000182281100-0x0000000182281180
		private static string DoTextField(string text, int maxLength, bool multiline, GUIStyle style, GUILayoutOption[] options); // 0x0000000182280410-0x0000000182280740
		public static void FlexibleSpace(); // 0x0000000182280AE0-0x0000000182280F50
		public static void BeginHorizontal(params GUILayoutOption[] options); // 0x000000018227F970-0x000000018227FB40
		public static void BeginHorizontal(GUIContent content, GUIStyle style, params GUILayoutOption[] options); // 0x000000018227FB40-0x000000018227FCA0
		public static void EndHorizontal(); // 0x00000001822808B0-0x00000001822808F0
		public static void BeginArea(Rect screenRect); // 0x000000018227F610-0x000000018227F6C0
		public static void BeginArea(Rect screenRect, GUIContent content, GUIStyle style); // 0x000000018227F6C0-0x000000018227F970
		public static void EndArea(); // 0x0000000182280740-0x00000001822808B0
		public static Vector2 BeginScrollView(Vector2 scrollPosition, params GUILayoutOption[] options); // 0x000000018227FCA0-0x000000018227FD70
		public static Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background, params GUILayoutOption[] options); // 0x000000018227FD70-0x0000000182280050
		public static void EndScrollView(); // 0x00000001822808F0-0x0000000182280960
		internal static void EndScrollView(bool handleScrollWheel); // 0x0000000182280960-0x00000001822809E0
		public static GUILayoutOption Width(float width); // 0x0000000182281180-0x0000000182281210
		public static GUILayoutOption Height(float height); // 0x0000000182280F50-0x0000000182280FE0
		public static GUILayoutOption ExpandWidth(bool expand); // 0x0000000182280A60-0x0000000182280AE0
		public static GUILayoutOption ExpandHeight(bool expand); // 0x00000001822809E0-0x0000000182280A60
	}
}
