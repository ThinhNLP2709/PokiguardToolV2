/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class ChatEmojiCatalog // TypeDefIndex: 483
{
	// Fields
	public static readonly IReadOnlyList<Entry> All; // 0x00
	private static readonly Dictionary<string, Entry> _byId; // 0x08
	private static readonly Dictionary<string, Sprite[]> _frameCache; // 0x10

	// Properties
	public static Sprite UiFrameEmoji { get; } // 0x0000000180390E90-0x0000000180390F00 
	public static Sprite UiIconChat { get; } // 0x0000000180390F00-0x0000000180390F70 
	public static Sprite UiTabActive { get; } // 0x0000000180390F70-0x0000000180390FE0 
	public static Sprite UiTabInactive { get; } // 0x0000000180390FE0-0x0000000180391050 

	// Nested types
	public class Entry // TypeDefIndex: 484
	{
		// Fields
		public string Id; // 0x10
		public string[] FramePaths; // 0x18
		public float Fps; // 0x20

		// Constructors
		public Entry(string id, float fps, params string[] framePaths); // 0x0000000180392180-0x0000000180392240
	}

	// Constructors
	static ChatEmojiCatalog(); // 0x0000000180391050-0x0000000180392180

	// Methods
	private static Dictionary<string, Entry> BuildIndex(); // 0x00000001803905A0-0x0000000180390890
	public static bool IsValid(string id); // 0x0000000180390890-0x0000000180390940
	public static Entry Get(string id); // 0x0000000180390940-0x0000000180390A00
	public static Sprite[] LoadFrames(string id); // 0x0000000180390A00-0x0000000180390E90
}

