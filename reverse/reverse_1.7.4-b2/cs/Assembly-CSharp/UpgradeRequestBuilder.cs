/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class UpgradeRequestBuilder // TypeDefIndex: 941
{
	// Methods
	public static EncryptedBody BuildPetUpgrade(long userId, long userPetId, long[] stoneIds, bool preventDowngrade, bool boost15Percent); // 0x00000001804E1EC0-0x00000001804E2160
	public static EncryptedBody BuildStoneUpgrade(long userId, long[] stoneIds, bool upgradeAll); // 0x00000001804E2160-0x00000001804E2340
	public static EncryptedBody BuildBatchStoneUpgrade(long userId, StoneGroupPayload[] groups); // 0x00000001804E1C90-0x00000001804E1EC0
	private static EncryptedBody Encrypt(string plainJson); // 0x00000001804E2340-0x00000001804E2420
	private static string SerializeLongArray(long[] arr); // 0x00000001804E2420-0x00000001804E2560
}

