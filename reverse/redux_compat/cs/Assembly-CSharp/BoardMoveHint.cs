/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class BoardMoveHint : MonoBehaviour // TypeDefIndex: 1609
{
	// Fields
	private const float IdleBeforeHintSec = 4.5f; // Metadata: 0x0064D7CD
	private const float HintVisibleSec = 1.2f; // Metadata: 0x0064D7D1
	private const float HintRepeatGapSec = 3f; // Metadata: 0x0064D7D5
	private const float PollSec = 0.5f; // Metadata: 0x0064D7D9
	private static readonly int[][] HintDirections; // 0x00
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
	public BoardMoveHint(); // 0x000000018059EBE0-0x000000018059EBF0
	static BoardMoveHint(); // 0x000000018059EAD0-0x000000018059EBE0

	// Methods
	private void Awake(); // 0x000000018059DA90-0x000000018059DB20
	private void OnEnable(); // 0x000000018059DD40-0x000000018059DD70
	private void OnDisable(); // 0x000000018059DD20-0x000000018059DD40
	private void OnDestroy(); // 0x000000018059DD20-0x000000018059DD40
	private void TrySubscribe(); // 0x000000018059E500-0x000000018059E690
	private void Unsubscribe(); // 0x000000018059E690-0x000000018059E820
	private void HandleTurnEnd(); // 0x000000018059DCF0-0x000000018059DD20
	private void HandleOpsApplied(List<MatchOpDTO> ops); // 0x000000018059DCF0-0x000000018059DD20
	private void MarkActivity(); // 0x000000018033ED70-0x000000018033ED90
	private void Update(); // 0x000000018059E820-0x000000018059EAD0
	private bool CanShowHint(); // 0x000000018059DB20-0x000000018059DCF0
	private void ShowHint(); // 0x000000018059DD70-0x000000018059DED0
	private void StopHint(); // 0x000000018059DF60-0x000000018059E060
	private static void StopHintOn(GameObject go); // 0x000000018059DED0-0x000000018059DF60
	private bool TryFindHintMove(out GameObject a, out GameObject b); // 0x000000018059E060-0x000000018059E500
}

