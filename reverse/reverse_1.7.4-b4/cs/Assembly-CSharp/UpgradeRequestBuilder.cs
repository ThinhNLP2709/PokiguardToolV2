/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class UpgradeRequestBuilder // TypeDefIndex: 1201
{
	// Methods
	public static EncryptedBody BuildPetUpgrade(long userId, long userPetId, long[] stoneIds, bool preventDowngrade, bool boost15Percent); // 0x00000001806D2330-0x00000001806D2620
	public static EncryptedBody BuildStoneUpgrade(long userId, long[] stoneIds, bool upgradeAll); // 0x00000001806D2620-0x00000001806D2840
	public static EncryptedBody BuildBatchStoneUpgrade(long userId, StoneGroupPayload[] groups); // 0x00000001806D2840-0x00000001806D2AA0
	private static EncryptedBody Encrypt(string plainJson); // 0x00000001806D2AA0-0x00000001806D2C10
	private static string SerializeLongArray(long[] arr); // 0x00000001806D2C10-0x00000001806D2D60
}

