/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class GuildPetEmblems // TypeDefIndex: 760
{
	// Fields
	private const int PAGE_SIZE = 300; // Metadata: 0x0068BAE6
	private static int _ownerUserId; // 0x00
	private static List<int> _owned; // 0x08

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass5_0 // TypeDefIndex: 761
	{
		// Fields
		public int uid; // 0x10
		public Action<List<int>> done; // 0x18

		// Constructors
		public __c__DisplayClass5_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _Load_b__0(PetsPaginatedDataDTO d); // 0x000000018047F320-0x000000018047F550
		internal void _Load_b__1(string err); // 0x000000018047F550-0x000000018047F570
	}

	// Constructors
	static GuildPetEmblems(); // 0x00000001804794B0-0x00000001804794F0

	// Methods
	public static List<int> Cached(int userId); // 0x0000000180479020-0x0000000180479080
	public static int DefaultPetId(); // 0x0000000180479080-0x0000000180479090
	public static void Load(GuildPanelController owner, Action<List<int>> done); // 0x0000000180479210-0x00000001804794B0
	private static List<int> Distinct(PetsPaginatedDataDTO page); // 0x0000000180479090-0x0000000180479210
}

