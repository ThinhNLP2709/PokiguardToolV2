/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class UpgradeRequestBuilder // TypeDefIndex: 1199
{
	// Methods
	public static EncryptedBody BuildPetUpgrade(long userId, long userPetId, long[] stoneIds, bool preventDowngrade, bool boost15Percent); // 0x00000001806D0710-0x00000001806D0A00
	public static EncryptedBody BuildStoneUpgrade(long userId, long[] stoneIds, bool upgradeAll); // 0x00000001806D0A00-0x00000001806D0C20
	public static EncryptedBody BuildBatchStoneUpgrade(long userId, StoneGroupPayload[] groups); // 0x00000001806D0C20-0x00000001806D0E80
	private static EncryptedBody Encrypt(string plainJson); // 0x00000001806D0E80-0x00000001806D0FF0
	private static string SerializeLongArray(long[] arr); // 0x00000001806D0FF0-0x00000001806D1140
}

