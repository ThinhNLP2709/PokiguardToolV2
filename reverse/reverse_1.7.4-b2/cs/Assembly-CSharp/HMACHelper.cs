/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class HMACHelper // TypeDefIndex: 1168
{
	// Fields
	private const string LEGACY_KEY = "YourSecretKey_ChangeThis_2025"; // Metadata: 0x0068C6A3
	private const string PREF_KEY = "SessionKey"; // Metadata: 0x0068C6C1
	private static string _sessionKey; // 0x00
	private static readonly string _aesKey; // 0x08
	private static long _timeOffset; // 0x10

	// Constructors
	static HMACHelper(); // 0x0000000180575630-0x0000000180575760

	// Methods
	public static void SetSessionKey(string key); // 0x0000000180575520-0x00000001805755D0
	public static string GenerateSignature(long userId, long petId, long timestamp); // 0x0000000180574D50-0x0000000180574FC0
	public static string GenerateWheelSignature(long userId, string spinType, long timestamp); // 0x0000000180575230-0x0000000180575480
	public static string GenerateSpinSignature(long userId, int multiplier, long timestamp); // 0x0000000180574FC0-0x0000000180575230
	public static string EncryptAES(string plainText); // 0x00000001805745A0-0x0000000180574B40
	public static string GenerateCoopSignature(string encryptedData, long timestamp); // 0x0000000180574B40-0x0000000180574D50
	public static void SetTimeOffset(long offset); // 0x00000001805755D0-0x0000000180575630
	public static long GetTimestamp(); // 0x0000000180575480-0x0000000180575520
}

