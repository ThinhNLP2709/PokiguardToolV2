/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class ChatEmojiCatalog // TypeDefIndex: 377
{
	// Fields
	public static readonly IReadOnlyList<Entry> All; // 0x00
	private static readonly Dictionary<string, Entry> _byId; // 0x08
	private static readonly Dictionary<string, Sprite[]> _frameCache; // 0x10

	// Properties
	public static Sprite UiFrameEmoji { get; } // 0x000000018031C750-0x000000018031C7B0 
	public static Sprite UiIconChat { get; } // 0x000000018031C7B0-0x000000018031C810 
	public static Sprite UiTabActive { get; } // 0x000000018031C810-0x000000018031C870 
	public static Sprite UiTabInactive { get; } // 0x000000018031C870-0x000000018031C8D0 

	// Nested types
	public class Entry // TypeDefIndex: 378
	{
		// Fields
		public string Id; // 0x10
		public string[] FramePaths; // 0x18
		public float Fps; // 0x20

		// Constructors
		public Entry(string id, float fps, params string[] framePaths); // 0x000000018032ADB0-0x000000018032AE10
	}

	// Constructors
	static ChatEmojiCatalog(); // 0x000000018031B400-0x000000018031C750

	// Methods
	private static Dictionary<string, Entry> BuildIndex(); // 0x000000018031AC10-0x000000018031AEF0
	public static bool IsValid(string id); // 0x000000018031AFA0-0x000000018031B030
	public static Entry Get(string id); // 0x000000018031AEF0-0x000000018031AFA0
	public static Sprite[] LoadFrames(string id); // 0x000000018031B030-0x000000018031B400
}

