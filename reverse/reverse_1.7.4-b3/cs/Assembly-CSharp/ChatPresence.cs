/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class ChatPresence // TypeDefIndex: 505
{
	// Fields
	private static readonly HashSet<string> _online; // 0x00
	[CompilerGenerated]
	private static bool _HasData_k__BackingField; // 0x08
	[CompilerGenerated]
	private static Action OnChanged; // 0x10

	// Properties
	public static bool HasData { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C5E0-0x000000018039C640 0x000000018039C640-0x000000018039C6A0
	public static bool Enabled { get; } // 0x000000018039C900-0x000000018039C970 

	// Events
	public static event Action OnChanged {
		add; // 0x000000018039C6A0-0x000000018039C7D0
		remove; // 0x000000018039C7D0-0x000000018039C900
	}

	// Constructors
	static ChatPresence(); // 0x000000018039D220-0x000000018039D3B0

	// Methods
	public static bool IsOnline(string username); // 0x000000018039C970-0x000000018039CBD0
	private static bool IsSelf(string username); // 0x000000018039CBD0-0x000000018039CDA0
	public static void ApplySnapshot(UserPresenceDTO[] users); // 0x000000018039CDA0-0x000000018039CF10
	public static void ApplyChange(string username, bool online); // 0x000000018039CF10-0x000000018039D020
	public static void Reset(); // 0x000000018039D020-0x000000018039D130
	private static void Raise(); // 0x000000018039D130-0x000000018039D220
}

