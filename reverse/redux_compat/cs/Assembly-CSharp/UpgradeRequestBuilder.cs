/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class UpgradeRequestBuilder // TypeDefIndex: 751
{
	// Methods
	public static EncryptedBody BuildPetUpgrade(long userId, long userPetId, long[] stoneIds, bool preventDowngrade, bool boost15Percent); // 0x000000018040B890-0x000000018040BB30
	public static EncryptedBody BuildStoneUpgrade(long userId, long[] stoneIds, bool upgradeAll); // 0x000000018040BB30-0x000000018040BD10
	public static EncryptedBody BuildBatchStoneUpgrade(long userId, StoneGroupPayload[] groups); // 0x000000018040B660-0x000000018040B890
	private static EncryptedBody Encrypt(string plainJson); // 0x000000018040BD10-0x000000018040BDF0
	private static string SerializeLongArray(long[] arr); // 0x000000018040BDF0-0x000000018040C020
}

