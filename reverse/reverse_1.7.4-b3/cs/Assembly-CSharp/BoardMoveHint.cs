/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class BoardMoveHint : MonoBehaviour // TypeDefIndex: 2239
{
	// Fields
	public static readonly bool Enabled; // 0x00
	private const float IdleBeforeHintSec = 4.5f; // Metadata: 0x005F0864
	private const float HintVisibleSec = 1.2f; // Metadata: 0x005F0868
	private const float HintRepeatGapSec = 3f; // Metadata: 0x005F086C
	private const float PollSec = 0.5f; // Metadata: 0x005F0870
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
	public BoardMoveHint(); // 0x0000000180AC5740-0x0000000180AC5790
	static BoardMoveHint(); // 0x0000000180AC5790-0x0000000180AC5900

	// Methods
	private void Awake(); // 0x0000000180AC39B0-0x0000000180AC3BC0
	private void OnEnable(); // 0x0000000180AC3BC0-0x0000000180AC3C20
	private void OnDisable(); // 0x0000000180AC3C20-0x0000000180AC3C40
	private void OnDestroy(); // 0x0000000180AC3C20-0x0000000180AC3C40
	private void TrySubscribe(); // 0x0000000180AC3C40-0x0000000180AC3E20
	private void Unsubscribe(); // 0x0000000180AC3E20-0x0000000180AC4000
	private void HandleTurnEnd(); // 0x0000000180AC4000-0x0000000180AC4060
	private void HandleOpsApplied(List<MatchOpDTO> ops); // 0x0000000180AC4000-0x0000000180AC4060
	private void MarkActivity(); // 0x00000001803D9EB0-0x00000001803D9F10
	private void Update(); // 0x0000000180AC4060-0x0000000180AC43C0
	private bool CanShowHint(); // 0x0000000180AC43C0-0x0000000180AC4820
	private void ShowHint(); // 0x0000000180AC4820-0x0000000180AC4AB0
	private void StopHint(); // 0x0000000180AC4AB0-0x0000000180AC4D80
	private static void StopHintOn(GameObject go); // 0x0000000180AC4D80-0x0000000180AC4EA0
	private bool TryFindHintMove(out GameObject a, out GameObject b); // 0x0000000180AC4EA0-0x0000000180AC5740
}

