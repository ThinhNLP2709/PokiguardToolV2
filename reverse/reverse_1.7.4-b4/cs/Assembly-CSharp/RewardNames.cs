/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class RewardNames // TypeDefIndex: 1453
{
	// Fields
	private static readonly Dictionary<long, string> _petNames; // 0x00
	private static readonly Dictionary<long, string> _cardNames; // 0x08
	private static readonly StringBuilder _sb; // 0x10

	// Constructors
	static RewardNames(); // 0x00000001807EA3A0-0x00000001807EA5F0

	// Methods
	public static void RegisterPet(long id, string name); // 0x00000001807E9280-0x00000001807E9340
	public static string BaseName(string rewardType, long id); // 0x00000001807E9340-0x00000001807EA060
	public static string For(RewardDisplayHelper.Entry e); // 0x00000001807EA060-0x00000001807EA170
	public static string Summary(List<RewardDisplayHelper.Entry> list, int max); // 0x00000001807EA170-0x00000001807EA3A0
}

