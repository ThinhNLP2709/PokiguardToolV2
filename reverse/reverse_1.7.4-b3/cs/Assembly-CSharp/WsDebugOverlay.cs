/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class WsDebugOverlay : MonoBehaviour // TypeDefIndex: 591
{
	// Fields
	private const int MAX_ENTRIES = 80; // Metadata: 0x005EE410
	private const int SUMMARY_MAX_CHARS = 700; // Metadata: 0x005EE412
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
	private struct Entry // TypeDefIndex: 592
	{
		// Fields
		public string time; // 0x00
		public bool incoming; // 0x08
		public string type; // 0x10
		public string summary; // 0x18
	}

	// Constructors
	public WsDebugOverlay(); // 0x000000018041D280-0x000000018041D450

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void AutoInit(); // 0x000000018041B750-0x000000018041B770
	private static void EnsureInstance(); // 0x000000018041B770-0x000000018041B950
	public static bool IsEnabled(); // 0x000000018041B950-0x000000018041BA70
	public static void SetEnabled(bool on); // 0x000000018041BA70-0x000000018041BC30
	public static void LogIncoming(string type, string rawJson); // 0x000000018041BC30-0x000000018041BCC0
	public static void LogOutgoing(string type, string rawJson); // 0x000000018041BCC0-0x000000018041BD50
	private void Push(bool incoming, string type, string rawJson); // 0x000000018041BD50-0x000000018041C0F0
	private void OnGUI(); // 0x000000018041C0F0-0x000000018041CDC0
	private string BuildHeader(); // 0x000000018041CDC0-0x000000018041D050
	private void EnsureStyles(float s); // 0x000000018041D050-0x000000018041D280
}

