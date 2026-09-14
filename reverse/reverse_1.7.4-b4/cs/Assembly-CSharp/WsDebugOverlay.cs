/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class WsDebugOverlay : MonoBehaviour // TypeDefIndex: 592
{
	// Fields
	private const int MAX_ENTRIES = 80; // Metadata: 0x005EF7E1
	private const int SUMMARY_MAX_CHARS = 700; // Metadata: 0x005EF7E3
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
	private struct Entry // TypeDefIndex: 593
	{
		// Fields
		public string time; // 0x00
		public bool incoming; // 0x08
		public string type; // 0x10
		public string summary; // 0x18
	}

	// Constructors
	public WsDebugOverlay(); // 0x000000018041DFE0-0x000000018041E1B0

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void AutoInit(); // 0x000000018041C4B0-0x000000018041C4D0
	private static void EnsureInstance(); // 0x000000018041C4D0-0x000000018041C6B0
	public static bool IsEnabled(); // 0x000000018041C6B0-0x000000018041C7D0
	public static void SetEnabled(bool on); // 0x000000018041C7D0-0x000000018041C990
	public static void LogIncoming(string type, string rawJson); // 0x000000018041C990-0x000000018041CA20
	public static void LogOutgoing(string type, string rawJson); // 0x000000018041CA20-0x000000018041CAB0
	private void Push(bool incoming, string type, string rawJson); // 0x000000018041CAB0-0x000000018041CE50
	private void OnGUI(); // 0x000000018041CE50-0x000000018041DB20
	private string BuildHeader(); // 0x000000018041DB20-0x000000018041DDB0
	private void EnsureStyles(float s); // 0x000000018041DDB0-0x000000018041DFE0
}

