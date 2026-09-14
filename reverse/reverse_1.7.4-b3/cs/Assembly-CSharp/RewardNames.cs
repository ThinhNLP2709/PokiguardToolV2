/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class RewardNames // TypeDefIndex: 1451
{
	// Fields
	private static readonly Dictionary<long, string> _petNames; // 0x00
	private static readonly Dictionary<long, string> _cardNames; // 0x08
	private static readonly StringBuilder _sb; // 0x10

	// Constructors
	static RewardNames(); // 0x00000001807E8330-0x00000001807E8580

	// Methods
	public static void RegisterPet(long id, string name); // 0x00000001807E7210-0x00000001807E72D0
	public static string BaseName(string rewardType, long id); // 0x00000001807E72D0-0x00000001807E7FF0
	public static string For(RewardDisplayHelper.Entry e); // 0x00000001807E7FF0-0x00000001807E8100
	public static string Summary(List<RewardDisplayHelper.Entry> list, int max); // 0x00000001807E8100-0x00000001807E8330
}

