/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class PokiContentChannel // TypeDefIndex: 1579
{
	// Fields
	private static readonly string[] ALLOWED_HOST_SUFFIXES; // 0x00
	private static string _base; // 0x08

	// Properties
	public static string Base { get; } // 0x0000000180874AF0-0x0000000180874B50 
	public static string LastAppliedContentVersion { get; } // 0x0000000180874B50-0x0000000180874BB0 

	// Constructors
	static PokiContentChannel(); // 0x0000000180875850-0x0000000180875A00

	// Methods
	public static void LoadPersisted(); // 0x0000000180874BB0-0x0000000180874DB0
	public static bool ApplyFromServer(string baseUrl, string contentVersion); // 0x0000000180874DB0-0x0000000180875450
	public static bool IsAllowed(string url); // 0x0000000180875450-0x0000000180875850
}

