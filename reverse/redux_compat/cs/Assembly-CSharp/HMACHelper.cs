/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class HMACHelper // TypeDefIndex: 971
{
	// Fields
	private const string LEGACY_KEY = "YourSecretKey_ChangeThis_2025"; // Metadata: 0x0064CEBE
	private const string PREF_KEY = "SessionKey"; // Metadata: 0x0064CEDC
	private static string _sessionKey; // 0x00
	private static readonly string _aesKey; // 0x08
	private static long _timeOffset; // 0x10

	// Constructors
	static HMACHelper(); // 0x0000000180473850-0x0000000180473980

	// Methods
	public static void SetSessionKey(string key); // 0x0000000180473740-0x00000001804737F0
	public static string GenerateSignature(long userId, long petId, long timestamp); // 0x0000000180472F70-0x00000001804731E0
	public static string GenerateWheelSignature(long userId, string spinType, long timestamp); // 0x0000000180473450-0x00000001804736A0
	public static string GenerateSpinSignature(long userId, int multiplier, long timestamp); // 0x00000001804731E0-0x0000000180473450
	public static string EncryptAES(string plainText); // 0x00000001804727C0-0x0000000180472D60
	public static string GenerateCoopSignature(string encryptedData, long timestamp); // 0x0000000180472D60-0x0000000180472F70
	public static void SetTimeOffset(long offset); // 0x00000001804737F0-0x0000000180473850
	public static long GetTimestamp(); // 0x00000001804736A0-0x0000000180473740
}

