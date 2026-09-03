/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[Preserve]
public static class PokiContentChannel // TypeDefIndex: 975
{
	// Fields
	public const string CHANNEL = "a1"; // Metadata: 0x0064D045
	public const string DEFAULT_BASE = "https://cdn.pokiguard.online/addressables/a1"; // Metadata: 0x0064D048
	private static readonly string[] ALLOWED_HOST_SUFFIXES; // 0x00
	private const string PREF_BASE_URL = "ContentBaseUrl"; // Metadata: 0x0064D075
	private const string PREF_CONTENT_VERSION = "LastContentVersion"; // Metadata: 0x0064D084
	private static string _base; // 0x08

	// Properties
	[Preserve]
	public static string Base { get; } // 0x0000000180475540-0x0000000180475590 
	public static string LastAppliedContentVersion { get; } // 0x0000000180475590-0x00000001804755E0 

	// Constructors
	static PokiContentChannel(); // 0x0000000180475420-0x0000000180475540

	// Methods
	public static void LoadPersisted(); // 0x0000000180475290-0x0000000180475420
	public static bool ApplyFromServer(string baseUrl, string contentVersion); // 0x0000000180474B30-0x00000001804750E0
	public static bool IsAllowed(string url); // 0x00000001804750E0-0x0000000180475290
}

