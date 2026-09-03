/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class RewardNames // TypeDefIndex: 871
{
	// Fields
	private static readonly Dictionary<long, string> _petNames; // 0x00
	private static readonly Dictionary<long, string> _cardNames; // 0x08
	private static readonly StringBuilder _sb; // 0x10

	// Constructors
	static RewardNames(); // 0x0000000180447B10-0x0000000180447C30

	// Methods
	public static void RegisterPet(long id, string name); // 0x0000000180447860-0x0000000180447900
	public static void RegisterCard(long id, string name); // 0x00000001804477C0-0x0000000180447860
	public static string BaseName(string rewardType, long id); // 0x0000000180446D50-0x00000001804476E0
	public static string For(RewardDisplayHelper.Entry e); // 0x00000001804476E0-0x00000001804477C0
	public static string Summary(List<RewardDisplayHelper.Entry> list, int max); // 0x0000000180447900-0x0000000180447B10
}

