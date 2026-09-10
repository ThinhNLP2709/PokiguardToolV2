/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[Preserve]
public static class PokiContentChannel // TypeDefIndex: 1173
{
	// Fields
	public const string CHANNEL = "a1"; // Metadata: 0x0068CB9C
	public const string DEFAULT_BASE = "https://cdn.pokiguard.online/addressables/a1"; // Metadata: 0x0068CB9F
	private static readonly string[] ALLOWED_HOST_SUFFIXES; // 0x00
	private const string PREF_BASE_URL = "ContentBaseUrl"; // Metadata: 0x0068CBCC
	private const string PREF_CONTENT_VERSION = "LastContentVersion"; // Metadata: 0x0068CBDB
	private static string _base; // 0x08

	// Properties
	[Preserve]
	public static string Base { get; } // 0x000000018058B370-0x000000018058B3C0 
	public static string LastAppliedContentVersion { get; } // 0x000000018058B3C0-0x000000018058B410 

	// Constructors
	static PokiContentChannel(); // 0x000000018058B250-0x000000018058B370

	// Methods
	public static void LoadPersisted(); // 0x000000018058B0C0-0x000000018058B250
	public static bool ApplyFromServer(string baseUrl, string contentVersion); // 0x000000018058A960-0x000000018058AF10
	public static bool IsAllowed(string url); // 0x000000018058AF10-0x000000018058B0C0
}

