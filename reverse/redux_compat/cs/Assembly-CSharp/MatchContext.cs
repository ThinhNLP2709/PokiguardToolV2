/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class MatchContext // TypeDefIndex: 634
{
	// Fields
	public const string COOP_SCENE = "Match"; // Metadata: 0x0064C6B5
	public const string PVP_SCENE = "MatchPVP"; // Metadata: 0x0064C6BB
	public const string BATTLE_SCENE = "battleScene"; // Metadata: 0x0064C6C4

	// Properties
	public static bool InCoopMatch { get; } // 0x00000001803BA9C0-0x00000001803BAA80 
	public static bool InPvpMatch { get; } // 0x00000001803BAA80-0x00000001803BAB40 
	public static bool InAnyMatch { get; } // 0x00000001803041B0-0x00000001803041E0 

	// Methods
	public static bool InMatchOfSceneName(string sceneName); // 0x00000001803BA8C0-0x00000001803BA940
	private static bool IsSceneLoaded(string sceneName); // 0x00000001803BA940-0x00000001803BA9C0
}

