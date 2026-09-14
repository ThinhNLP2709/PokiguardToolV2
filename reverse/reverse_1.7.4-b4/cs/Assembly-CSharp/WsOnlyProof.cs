/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class WsOnlyProof : MonoBehaviour // TypeDefIndex: 1895
{
	// Fields
	public const string PREF_ENABLED = "ws_only_proof"; // Metadata: 0x005F1670
	public const string PREF_SEVER = "ws_only_proof_sever"; // Metadata: 0x005F167E
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
	public static bool IsEnabled { get; } // 0x00000001809253E0-0x0000000180925430 

	// Constructors
	public WsOnlyProof(); // 0x0000000180927190-0x0000000180927300

	// Methods
	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
	private static void AutoInit(); // 0x0000000180925430-0x0000000180925660
	private void Awake(); // 0x0000000180925660-0x0000000180925930
	private void OnDestroy(); // 0x0000000180925930-0x0000000180925AF0
	[Conditional("UNITY_EDITOR")]
	[Conditional("DEVELOPMENT_BUILD")]
	public static void NoteWsIn(string type); // 0x0000000180925AF0-0x0000000180925D30
	[Conditional("UNITY_EDITOR")]
	[Conditional("DEVELOPMENT_BUILD")]
	public static void NoteWsOut(string type); // 0x0000000180925D30-0x0000000180925E50
	private void Update(); // 0x0000000180925E50-0x0000000180926080
	private void BeginMatch(MatchService ms); // 0x0000000180926080-0x0000000180926270
	private void EndMatch(); // 0x0000000180926270-0x0000000180926970
	private void WriteReport(string body); // 0x0000000180926970-0x0000000180926BF0
	private static string Mark(bool ok); // 0x0000000180926BF0-0x0000000180926C50
	private void OnGUI(); // 0x0000000180926C50-0x0000000180927190
}

