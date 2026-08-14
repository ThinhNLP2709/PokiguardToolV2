namespace UnityEngine;

public class GUILayout
{

	public static void BeginArea(Rect screenRect) { }

	public static void BeginArea(Rect screenRect, GUIContent content, GUIStyle style) { }

	public static void BeginHorizontal(GUILayoutOption[] options) { }

	public static void BeginHorizontal(GUIContent content, GUIStyle style, GUILayoutOption[] options) { }

	public static Vector2 BeginScrollView(Vector2 scrollPosition, bool alwaysShowHorizontal, bool alwaysShowVertical, GUIStyle horizontalScrollbar, GUIStyle verticalScrollbar, GUIStyle background, GUILayoutOption[] options) { }

	public static Vector2 BeginScrollView(Vector2 scrollPosition, GUILayoutOption[] options) { }

	public static bool Button(string text, GUILayoutOption[] options) { }

	private static bool DoButton(GUIContent content, GUIStyle style, GUILayoutOption[] options) { }

	private static void DoLabel(GUIContent content, GUIStyle style, GUILayoutOption[] options) { }

	private static string DoTextField(string text, int maxLength, bool multiline, GUIStyle style, GUILayoutOption[] options) { }

	public static void EndArea() { }

	public static void EndHorizontal() { }

	internal static void EndScrollView(bool handleScrollWheel) { }

	public static void EndScrollView() { }

	public static GUILayoutOption ExpandHeight(bool expand) { }

	public static GUILayoutOption ExpandWidth(bool expand) { }

	public static void FlexibleSpace() { }

	public static GUILayoutOption Height(float height) { }

	public static void Label(string text, GUIStyle style, GUILayoutOption[] options) { }

	public static void Label(string text, GUILayoutOption[] options) { }

	public static string TextField(string text, GUILayoutOption[] options) { }

	public static GUILayoutOption Width(float width) { }

}

