/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class MatchContext // TypeDefIndex: 830
{
	// Fields
	public const string COOP_SCENE = "Match"; // Metadata: 0x0068BCE0
	public const string PVP_SCENE = "MatchPVP"; // Metadata: 0x0068BCE6
	public const string BATTLE_SCENE = "battleScene"; // Metadata: 0x0068BCEF

	// Properties
	public static bool InCoopMatch { get; } // 0x000000018049C070-0x000000018049C130 
	public static bool InPvpMatch { get; } // 0x000000018049C130-0x000000018049C1F0 
	public static bool InAnyMatch { get; } // 0x000000018030D880-0x000000018030D8B0 

	// Methods
	public static bool InMatchOfSceneName(string sceneName); // 0x000000018049BF70-0x000000018049BFF0
	private static bool IsSceneLoaded(string sceneName); // 0x000000018049BFF0-0x000000018049C070
}

