/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class RewardNames // TypeDefIndex: 1072
{
	// Fields
	private static readonly Dictionary<long, string> _petNames; // 0x00
	private static readonly Dictionary<long, string> _cardNames; // 0x08
	private static readonly StringBuilder _sb; // 0x10

	// Constructors
	static RewardNames(); // 0x000000018051E990-0x000000018051EAB0

	// Methods
	public static void RegisterPet(long id, string name); // 0x000000018051E6E0-0x000000018051E780
	public static void RegisterCard(long id, string name); // 0x000000018051E640-0x000000018051E6E0
	public static string BaseName(string rewardType, long id); // 0x000000018051D930-0x000000018051E530
	public static string For(RewardDisplayHelper.Entry e); // 0x000000018051E530-0x000000018051E640
	public static string Summary(List<RewardDisplayHelper.Entry> list, int max); // 0x000000018051E780-0x000000018051E990
}

