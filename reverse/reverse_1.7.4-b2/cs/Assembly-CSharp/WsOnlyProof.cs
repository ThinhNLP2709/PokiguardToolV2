/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class WsOnlyProof : MonoBehaviour // TypeDefIndex: 1510
{
	// Fields
	public const string PREF_ENABLED = "ws_only_proof"; // Metadata: 0x0068D3B9
	public const string PREF_SEVER = "ws_only_proof_sever"; // Metadata: 0x0068D3C7
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
	public static bool IsEnabled { get; } // 0x00000001805EEF20-0x00000001805EEF60 

	// Constructors
	public WsOnlyProof(); // 0x00000001805EEE70-0x00000001805EEF20

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void AutoInit(); // 0x00000001805EDAB0-0x00000001805EDC00
	private void Awake(); // 0x00000001805EDC00-0x00000001805EDD20
	private void OnDestroy(); // 0x00000001805EE490-0x00000001805EE540
	[Conditional("UNITY_EDITOR")]
	[Conditional("DEVELOPMENT_BUILD")]
	public static void NoteWsIn(string type); // 0x00000001805EE2A0-0x00000001805EE400
	[Conditional("UNITY_EDITOR")]
	[Conditional("DEVELOPMENT_BUILD")]
	public static void NoteWsOut(string type); // 0x00000001805EE400-0x00000001805EE490
	private void Update(); // 0x00000001805EEA20-0x00000001805EEC80
	private void BeginMatch(MatchService ms); // 0x00000001805EDD20-0x00000001805EDE20
	private void EndMatch(); // 0x00000001805EDE20-0x00000001805EE250
	private void WriteReport(string body); // 0x00000001805EEC80-0x00000001805EEE70
	private static string Mark(bool ok); // 0x00000001805EE250-0x00000001805EE2A0
	private void OnGUI(); // 0x00000001805EE540-0x00000001805EEA20
}

