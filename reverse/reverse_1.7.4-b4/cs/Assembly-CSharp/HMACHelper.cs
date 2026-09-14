/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class HMACHelper // TypeDefIndex: 1575
{
	// Fields
	private static string _sessionKey; // 0x00
	private static readonly string _aesKey; // 0x08
	private static long _timeOffset; // 0x10

	// Constructors
	static HMACHelper(); // 0x000000018086B1D0-0x000000018086B3D0

	// Methods
	public static void SetSessionKey(string key); // 0x000000018086B3D0-0x000000018086B500
	public static string GenerateSignature(long userId, long petId, long timestamp); // 0x000000018086B500-0x000000018086B950
	public static string GenerateWheelSignature(long userId, string spinType, long timestamp); // 0x000000018086B950-0x000000018086BD80
	public static string GenerateSpinSignature(long userId, int multiplier, long timestamp); // 0x000000018086BD80-0x000000018086C1C0
	public static string EncryptAES(string plainText); // 0x000000018086C1C0-0x000000018086C8D0
	public static string GenerateCoopSignature(string encryptedData, long timestamp); // 0x000000018086C8D0-0x000000018086CCE0
	public static void SetTimeOffset(long offset); // 0x000000018086CCE0-0x000000018086CD40
	public static long GetTimestamp(); // 0x000000018086CD40-0x000000018086CE40
}

