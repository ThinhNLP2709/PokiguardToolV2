namespace UnityEngine;

[NativeHeader("Runtime/Utilities/PlayerPrefs.h")]
public class PlayerPrefs
{

	public static void DeleteKey(string key) { }

	private static void DeleteKey_Injected(ref ManagedSpanWrapper key) { }

	public static float GetFloat(string key, float defaultValue) { }

	private static float GetFloat_Injected(ref ManagedSpanWrapper key, float defaultValue) { }

	public static int GetInt(string key, int defaultValue) { }

	public static int GetInt(string key) { }

	private static int GetInt_Injected(ref ManagedSpanWrapper key, int defaultValue) { }

	public static string GetString(string key, string defaultValue) { }

	public static string GetString(string key) { }

	private static void GetString_Injected(ref ManagedSpanWrapper key, ref ManagedSpanWrapper defaultValue, out ManagedSpanWrapper ret) { }

	public static bool HasKey(string key) { }

	private static bool HasKey_Injected(ref ManagedSpanWrapper key) { }

	[NativeMethod("Sync")]
	public static void Save() { }

	public static void SetFloat(string key, float value) { }

	public static void SetInt(string key, int value) { }

	public static void SetString(string key, string value) { }

	[NativeMethod("SetFloat")]
	private static bool TrySetFloat(string key, float value) { }

	private static bool TrySetFloat_Injected(ref ManagedSpanWrapper key, float value) { }

	[NativeMethod("SetInt")]
	private static bool TrySetInt(string key, int value) { }

	private static bool TrySetInt_Injected(ref ManagedSpanWrapper key, int value) { }

	[NativeMethod("SetString")]
	private static bool TrySetSetString(string key, string value) { }

	private static bool TrySetSetString_Injected(ref ManagedSpanWrapper key, ref ManagedSpanWrapper value) { }

}

