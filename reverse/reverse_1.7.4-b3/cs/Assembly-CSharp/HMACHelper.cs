/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class HMACHelper // TypeDefIndex: 1573
{
	// Fields
	private static string _sessionKey; // 0x00
	private static readonly string _aesKey; // 0x08
	private static long _timeOffset; // 0x10

	// Constructors
	static HMACHelper(); // 0x0000000180868F40-0x0000000180869140

	// Methods
	public static void SetSessionKey(string key); // 0x0000000180869140-0x0000000180869270
	public static string GenerateSignature(long userId, long petId, long timestamp); // 0x0000000180869270-0x00000001808696C0
	public static string GenerateWheelSignature(long userId, string spinType, long timestamp); // 0x00000001808696C0-0x0000000180869AF0
	public static string GenerateSpinSignature(long userId, int multiplier, long timestamp); // 0x0000000180869AF0-0x0000000180869F30
	public static string EncryptAES(string plainText); // 0x0000000180869F30-0x000000018086A640
	public static string GenerateCoopSignature(string encryptedData, long timestamp); // 0x000000018086A640-0x000000018086AA50
	public static void SetTimeOffset(long offset); // 0x000000018086AA50-0x000000018086AAB0
	public static long GetTimestamp(); // 0x000000018086AAB0-0x000000018086ABB0
}

