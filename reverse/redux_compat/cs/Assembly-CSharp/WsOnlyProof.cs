/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class WsOnlyProof : MonoBehaviour // TypeDefIndex: 1277
{
	// Fields
	public const string PREF_ENABLED = "ws_only_proof"; // Metadata: 0x0064D5A1
	public const string PREF_SEVER = "ws_only_proof_sever"; // Metadata: 0x0064D5AF
	private static WsOnlyProof _instance; // 0x00
	private bool _inMatch; // 0x20
	private string _matchId; // 0x28
	private string _matchType; // 0x30
	private float _matchStartTime; // 0x38
	private int _wsIn; // 0x3C
	private int _wsOut; // 0x40
	private readonly Dictionary<string, int> _wsInByType; // 0x48
	private string _lastVerdict; // 0x50
	private bool _showOverlay; // 0x58
	private float _nextPoll; // 0x5C

	// Properties
	public static bool IsEnabled { get; } // 0x00000001804EF390-0x00000001804EF3D0 

	// Constructors
	public WsOnlyProof(); // 0x00000001804EF2E0-0x00000001804EF390

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void AutoInit(); // 0x00000001804EDF20-0x00000001804EE070
	private void Awake(); // 0x00000001804EE070-0x00000001804EE190
	private void OnDestroy(); // 0x00000001804EE900-0x00000001804EE9B0
	[Conditional("UNITY_EDITOR")]
	[Conditional("DEVELOPMENT_BUILD")]
	public static void NoteWsIn(string type); // 0x00000001804EE710-0x00000001804EE870
	[Conditional("UNITY_EDITOR")]
	[Conditional("DEVELOPMENT_BUILD")]
	public static void NoteWsOut(string type); // 0x00000001804EE870-0x00000001804EE900
	private void Update(); // 0x00000001804EEE90-0x00000001804EF0F0
	private void BeginMatch(MatchService ms); // 0x00000001804EE190-0x00000001804EE290
	private void EndMatch(); // 0x00000001804EE290-0x00000001804EE6C0
	private void WriteReport(string body); // 0x00000001804EF0F0-0x00000001804EF2E0
	private static string Mark(bool ok); // 0x00000001804EE6C0-0x00000001804EE710
	private void OnGUI(); // 0x00000001804EE9B0-0x00000001804EEE90
}

