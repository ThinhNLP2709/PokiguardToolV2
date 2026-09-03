/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class PvpRankingRequest // TypeDefIndex: 1096
{
	// Methods
	public static EncryptedBody BuildTopRequest(int limit); // 0x00000001804A6CC0-0x00000001804A6D20
	public static EncryptedBody BuildUserRequest(int userId); // 0x00000001804A6D20-0x00000001804A6D80
	public static EncryptedBody BuildHistoryRequest(int userId, int page = 0 /* Metadata: 0x0064D30B */, int size = 20 /* Metadata: 0x0064D30C */); // 0x00000001804A6C20-0x00000001804A6CC0
	private static EncryptedBody Encrypt(string plainJson); // 0x00000001804A6D80-0x00000001804A6E60
}

