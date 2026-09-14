/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class GuildPetEmblems // TypeDefIndex: 872
{
	// Fields
	private static int _ownerUserId; // 0x00
	private static List<int> _owned; // 0x08

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass5_0 // TypeDefIndex: 873
	{
		// Fields
		public int uid; // 0x10
		public Action<List<int>> done; // 0x18

		// Constructors
		public __c__DisplayClass5_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _Load_b__0(PetsPaginatedDataDTO d); // 0x00000001805515D0-0x00000001805516F0
		internal void _Load_b__1(string err); // 0x00000001805516F0-0x0000000180551710
	}

	// Constructors
	static GuildPetEmblems(); // 0x0000000180551590-0x00000001805515D0

	// Methods
	public static List<int> Cached(int userId); // 0x0000000180550F60-0x0000000180550FD0
	public static int DefaultPetId(); // 0x0000000180550FD0-0x0000000180550FE0
	public static void Load(GuildPanelController owner, Action<List<int>> done); // 0x0000000180550FE0-0x00000001805513D0
	private static List<int> Distinct(PetsPaginatedDataDTO page); // 0x00000001805513D0-0x0000000180551590
}

