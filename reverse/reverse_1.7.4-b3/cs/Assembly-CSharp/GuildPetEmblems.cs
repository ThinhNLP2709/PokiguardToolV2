/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class GuildPetEmblems // TypeDefIndex: 870
{
	// Fields
	private static int _ownerUserId; // 0x00
	private static List<int> _owned; // 0x08

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass5_0 // TypeDefIndex: 871
	{
		// Fields
		public int uid; // 0x10
		public Action<List<int>> done; // 0x18

		// Constructors
		public __c__DisplayClass5_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Load_b__0(PetsPaginatedDataDTO d); // 0x000000018054FDC0-0x000000018054FEE0
		internal void _Load_b__1(string err); // 0x000000018054FEE0-0x000000018054FF00
	}

	// Constructors
	static GuildPetEmblems(); // 0x000000018054FD80-0x000000018054FDC0

	// Methods
	public static List<int> Cached(int userId); // 0x000000018054F750-0x000000018054F7C0
	public static int DefaultPetId(); // 0x000000018054F7C0-0x000000018054F7D0
	public static void Load(GuildPanelController owner, Action<List<int>> done); // 0x000000018054F7D0-0x000000018054FBC0
	private static List<int> Distinct(PetsPaginatedDataDTO page); // 0x000000018054FBC0-0x000000018054FD80
}

