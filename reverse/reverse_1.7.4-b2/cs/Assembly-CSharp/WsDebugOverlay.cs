/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class WsDebugOverlay : MonoBehaviour // TypeDefIndex: 538
{
	// Fields
	private const int MAX_ENTRIES = 80; // Metadata: 0x0068B63A
	private const int SUMMARY_MAX_CHARS = 700; // Metadata: 0x0068B63C
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
	private struct Entry // TypeDefIndex: 539
	{
		// Fields
		public string time; // 0x00
		public bool incoming; // 0x08
		public string type; // 0x10
		public string summary; // 0x18
	}

	// Constructors
	public WsDebugOverlay(); // 0x00000001803D7750-0x00000001803D7800

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void AutoInit(); // 0x00000001803D60F0-0x00000001803D6110
	private static void EnsureInstance(); // 0x00000001803D62F0-0x00000001803D63F0
	public static bool IsEnabled(); // 0x00000001803D6580-0x00000001803D6650
	public static void SetEnabled(bool on); // 0x00000001803D7660-0x00000001803D7750
	public static void LogIncoming(string type, string rawJson); // 0x00000001803D6650-0x00000001803D66D0
	public static void LogOutgoing(string type, string rawJson); // 0x00000001803D66D0-0x00000001803D6750
	private void Push(bool incoming, string type, string rawJson); // 0x00000001803D73B0-0x00000001803D7660
	private void OnGUI(); // 0x00000001803D6750-0x00000001803D73B0
	private string BuildHeader(); // 0x00000001803D6110-0x00000001803D62F0
	private void EnsureStyles(float s); // 0x00000001803D63F0-0x00000001803D6580
}

