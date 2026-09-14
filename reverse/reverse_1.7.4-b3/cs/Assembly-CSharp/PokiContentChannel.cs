/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class PokiContentChannel // TypeDefIndex: 1577
{
	// Fields
	private static readonly string[] ALLOWED_HOST_SUFFIXES; // 0x00
	private static string _base; // 0x08

	// Properties
	public static string Base { get; } // 0x0000000180872860-0x00000001808728C0 
	public static string LastAppliedContentVersion { get; } // 0x00000001808728C0-0x0000000180872920 

	// Constructors
	static PokiContentChannel(); // 0x00000001808735C0-0x0000000180873770

	// Methods
	public static void LoadPersisted(); // 0x0000000180872920-0x0000000180872B20
	public static bool ApplyFromServer(string baseUrl, string contentVersion); // 0x0000000180872B20-0x00000001808731C0
	public static bool IsAllowed(string url); // 0x00000001808731C0-0x00000001808735C0
}

