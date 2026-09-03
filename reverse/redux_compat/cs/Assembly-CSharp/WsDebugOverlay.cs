/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class WsDebugOverlay : MonoBehaviour // TypeDefIndex: 451
{
	// Fields
	private const int MAX_ENTRIES = 80; // Metadata: 0x0064C436
	private const int SUMMARY_MAX_CHARS = 700; // Metadata: 0x0064C438
	private static WsDebugOverlay _instance; // 0x00
	private static bool _enabledCached; // 0x08
	private static bool _enabledResolved; // 0x09
	private readonly List<Entry> _entries; // 0x20
	private bool _expanded; // 0x28
	private bool _paused; // 0x29
	private Vector2 _scroll; // 0x2C
	private string _filter; // 0x38
	private GUIStyle _entryStyle; // 0x40
	private GUIStyle _headerStyle; // 0x48

	// Nested types
	private struct Entry // TypeDefIndex: 452
	{
		// Fields
		public string time; // 0x00
		public bool incoming; // 0x08
		public string type; // 0x10
		public string summary; // 0x18
	}

	// Constructors
	public WsDebugOverlay(); // 0x00000001803707B0-0x0000000180370860

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void AutoInit(); // 0x000000018036F150-0x000000018036F170
	private static void EnsureInstance(); // 0x000000018036F350-0x000000018036F450
	public static bool IsEnabled(); // 0x000000018036F5E0-0x000000018036F6B0
	public static void SetEnabled(bool on); // 0x00000001803706C0-0x00000001803707B0
	public static void LogIncoming(string type, string rawJson); // 0x000000018036F6B0-0x000000018036F730
	public static void LogOutgoing(string type, string rawJson); // 0x000000018036F730-0x000000018036F7B0
	private void Push(bool incoming, string type, string rawJson); // 0x0000000180370410-0x00000001803706C0
	private void OnGUI(); // 0x000000018036F7B0-0x0000000180370410
	private string BuildHeader(); // 0x000000018036F170-0x000000018036F350
	private void EnsureStyles(float s); // 0x000000018036F450-0x000000018036F5E0
}

