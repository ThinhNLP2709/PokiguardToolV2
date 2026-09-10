/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class PvpRankingRequest // TypeDefIndex: 1310
{
	// Methods
	public static EncryptedBody BuildTopRequest(int limit); // 0x00000001805A1370-0x00000001805A13D0
	public static EncryptedBody BuildUserRequest(int userId); // 0x00000001805A13D0-0x00000001805A1430
	public static EncryptedBody BuildHistoryRequest(int userId, int page = 0 /* Metadata: 0x0068CE62 */, int size = 20 /* Metadata: 0x0068CE63 */); // 0x00000001805A12D0-0x00000001805A1370
	private static EncryptedBody Encrypt(string plainJson); // 0x00000001805A1430-0x00000001805A1510
}

