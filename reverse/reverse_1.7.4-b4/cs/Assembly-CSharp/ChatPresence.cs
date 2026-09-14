/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class ChatPresence // TypeDefIndex: 505
{
	// Fields
	private static readonly HashSet<string> _online; // 0x00
	[CompilerGenerated]
	private static bool _HasData_k__BackingField; // 0x08
	[CompilerGenerated]
	private static Action OnChanged; // 0x10

	// Properties
	public static bool HasData { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018039C7B0-0x000000018039C810 0x000000018039C810-0x000000018039C870
	public static bool Enabled { get; } // 0x000000018039CAD0-0x000000018039CB40 

	// Events
	public static event Action OnChanged {
		add; // 0x000000018039C870-0x000000018039C9A0
		remove; // 0x000000018039C9A0-0x000000018039CAD0
	}

	// Constructors
	static ChatPresence(); // 0x000000018039D3F0-0x000000018039D580

	// Methods
	public static bool IsOnline(string username); // 0x000000018039CB40-0x000000018039CDA0
	private static bool IsSelf(string username); // 0x000000018039CDA0-0x000000018039CF70
	public static void ApplySnapshot(UserPresenceDTO[] users); // 0x000000018039CF70-0x000000018039D0E0
	public static void ApplyChange(string username, bool online); // 0x000000018039D0E0-0x000000018039D1F0
	public static void Reset(); // 0x000000018039D1F0-0x000000018039D300
	private static void Raise(); // 0x000000018039D300-0x000000018039D3F0
}

