/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[Serializable]
public class ServerSignedBattleResultDTO // TypeDefIndex: 1141
{
	// Fields
	public long userId; // 0x10
	public long bossScheduleId; // 0x18
	public int damageDealt; // 0x20
	public bool victory; // 0x24
	public int turnCount; // 0x28
	public string signature; // 0x30
	public long serverTimestamp; // 0x38
	public string sessionToken; // 0x40
	public string deviceId; // 0x48
	public string nonce; // 0x50
	public string gameVersion; // 0x58
	public string checksum; // 0x60

	// Constructors
	public ServerSignedBattleResultDTO(); // 0x00000001802E5CB0-0x00000001802E5CC0

	// Methods
	public static ServerSignedBattleResultDTO CreateFromServerResponse(long userId, long bossScheduleId, int damageDealt, bool victory, int turnCount, ServerSignatureHelper.SignatureResponse serverResponse, string originalDeviceId, string originalNonce); // 0x00000001804B9A20-0x00000001804B9BB0
}

