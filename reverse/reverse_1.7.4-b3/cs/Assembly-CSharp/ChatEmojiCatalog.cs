/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class ChatEmojiCatalog // TypeDefIndex: 483
{
	// Fields
	public static readonly IReadOnlyList<Entry> All; // 0x00
	private static readonly Dictionary<string, Entry> _byId; // 0x08
	private static readonly Dictionary<string, Sprite[]> _frameCache; // 0x10

	// Properties
	public static Sprite UiFrameEmoji { get; } // 0x0000000180390CE0-0x0000000180390D50 
	public static Sprite UiIconChat { get; } // 0x0000000180390D50-0x0000000180390DC0 
	public static Sprite UiTabActive { get; } // 0x0000000180390DC0-0x0000000180390E30 
	public static Sprite UiTabInactive { get; } // 0x0000000180390E30-0x0000000180390EA0 

	// Nested types
	public class Entry // TypeDefIndex: 484
	{
		// Fields
		public string Id; // 0x10
		public string[] FramePaths; // 0x18
		public float Fps; // 0x20

		// Constructors
		public Entry(string id, float fps, params string[] framePaths); // 0x0000000180391FD0-0x0000000180392090
	}

	// Constructors
	static ChatEmojiCatalog(); // 0x0000000180390EA0-0x0000000180391FD0

	// Methods
	private static Dictionary<string, Entry> BuildIndex(); // 0x00000001803903F0-0x00000001803906E0
	public static bool IsValid(string id); // 0x00000001803906E0-0x0000000180390790
	public static Entry Get(string id); // 0x0000000180390790-0x0000000180390850
	public static Sprite[] LoadFrames(string id); // 0x0000000180390850-0x0000000180390CE0
}

