/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class ChatPresence // TypeDefIndex: 451
{
	// Fields
	public const string FLAG_KEY = "chat.presenceDot"; // Metadata: 0x0068B2AF
	private static readonly HashSet<string> _online; // 0x00
	[CompilerGenerated]
	private static bool _HasData_k__BackingField; // 0x08
	[CompilerGenerated]
	private static Action OnChanged; // 0x10

	// Properties
	public static bool HasData { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180379960-0x00000001803799B0 0x0000000180379A80-0x0000000180379AE0
	public static bool Enabled { get; } // 0x0000000180379900-0x0000000180379960 

	// Events
	public static event Action OnChanged {
		add; // 0x0000000180379830-0x0000000180379900
		remove; // 0x00000001803799B0-0x0000000180379A80
	}

	// Constructors
	static ChatPresence(); // 0x0000000180379720-0x0000000180379830

	// Methods
	public static bool IsOnline(string username); // 0x0000000180379300-0x0000000180379450
	private static bool IsSelf(string username); // 0x0000000180379450-0x0000000180379520
	public static void ApplySnapshot(UserPresenceDTO[] users); // 0x00000001803791B0-0x0000000180379300
	public static void ApplyChange(string username, bool online); // 0x00000001803790C0-0x00000001803791B0
	public static void Reset(); // 0x0000000180379600-0x0000000180379720
	private static void Raise(); // 0x0000000180379520-0x0000000180379600
}

