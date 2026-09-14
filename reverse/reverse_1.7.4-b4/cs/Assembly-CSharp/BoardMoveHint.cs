/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class BoardMoveHint : MonoBehaviour // TypeDefIndex: 2246
{
	// Fields
	public static readonly bool Enabled; // 0x00
	private const float IdleBeforeHintSec = 4.5f; // Metadata: 0x005F1C7B
	private const float HintVisibleSec = 1.2f; // Metadata: 0x005F1C7F
	private const float HintRepeatGapSec = 3f; // Metadata: 0x005F1C83
	private const float PollSec = 0.5f; // Metadata: 0x005F1C87
	private static readonly int[][] HintDirections; // 0x08
	private Board _board; // 0x20
	private BoardPVP _boardPvp; // 0x28
	private float _lastActivityAt; // 0x30
	private float _nextPollAt; // 0x34
	private float _nextHintAt; // 0x38
	private float _hintHideAt; // 0x3C
	private GameObject _hintA; // 0x40
	private GameObject _hintB; // 0x48
	private bool _subscribed; // 0x50

	// Constructors
	public BoardMoveHint(); // 0x0000000180AD2600-0x0000000180AD2650
	static BoardMoveHint(); // 0x0000000180AD2650-0x0000000180AD27C0

	// Methods
	private void Awake(); // 0x0000000180AD0870-0x0000000180AD0A80
	private void OnEnable(); // 0x0000000180AD0A80-0x0000000180AD0AE0
	private void OnDisable(); // 0x0000000180AD0AE0-0x0000000180AD0B00
	private void OnDestroy(); // 0x0000000180AD0AE0-0x0000000180AD0B00
	private void TrySubscribe(); // 0x0000000180AD0B00-0x0000000180AD0CE0
	private void Unsubscribe(); // 0x0000000180AD0CE0-0x0000000180AD0EC0
	private void HandleTurnEnd(); // 0x0000000180AD0EC0-0x0000000180AD0F20
	private void HandleOpsApplied(List<MatchOpDTO> ops); // 0x0000000180AD0EC0-0x0000000180AD0F20
	private void MarkActivity(); // 0x00000001803DABF0-0x00000001803DAC50
	private void Update(); // 0x0000000180AD0F20-0x0000000180AD1280
	private bool CanShowHint(); // 0x0000000180AD1280-0x0000000180AD16E0
	private void ShowHint(); // 0x0000000180AD16E0-0x0000000180AD1970
	private void StopHint(); // 0x0000000180AD1970-0x0000000180AD1C40
	private static void StopHintOn(GameObject go); // 0x0000000180AD1C40-0x0000000180AD1D60
	private bool TryFindHintMove(out GameObject a, out GameObject b); // 0x0000000180AD1D60-0x0000000180AD2600
}

