/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class DailyCheckInSpawner : MonoBehaviour // TypeDefIndex: 983
{
	// Fields
	public const string SKIN_KEY = "PanelDiemdanh"; // Metadata: 0x0064D097
	[Header("Prefab")]
	[Tooltip("Drag PanelDiemDanh prefab v\u00E0o \u0111\u00E2y")]
	public GameObject panelDiemDanhPrefab; // 0x20
	[Header("Parent")]
	[Tooltip("Canvas \u0111\u1EC3 spawn v\u00E0o (th\u01B0\u1EDDng l\u00E0 Canvas ch\u00EDnh)")]
	public Transform canvasTransform; // 0x28
	[Header("Debug")]
	public bool debugMode; // 0x30
	private GameObject spawnedPanelObject; // 0x38
	private DailyCheckInManager spawnedPanelManager; // 0x40

	// Constructors
	public DailyCheckInSpawner(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Start(); // 0x0000000180481220-0x0000000180481370
	public void OpenDailyCheckIn(); // 0x0000000180480B40-0x0000000180480C70
	public void CloseDailyCheckIn(); // 0x0000000180480990-0x00000001804809A0
	private void SpawnPanel(); // 0x0000000180480F30-0x0000000180481220
	private void SetupCloseCallback(); // 0x0000000180480C70-0x0000000180480F30
	private void DestroyPanel(); // 0x00000001804809A0-0x0000000180480A80
	public bool IsPanelOpen(); // 0x0000000180480A80-0x0000000180480AD0
	public void TogglePanel(); // 0x0000000180481380-0x0000000180481400
	private void OnDestroy(); // 0x0000000180480AD0-0x0000000180480B40
	[ContextMenu("Test - Open Panel")]
	public void TestOpenPanel(); // 0x0000000180481370-0x0000000180481380
	[ContextMenu("Test - Close Panel")]
	public void TestClosePanel(); // 0x0000000180480990-0x00000001804809A0
	[ContextMenu("Test - Toggle Panel")]
	public void TestTogglePanel(); // 0x0000000180481380-0x0000000180481400
	[ContextMenu("Test - Check Panel Status")]
	public void TestCheckStatus(); // 0x0000000180480A80-0x0000000180480AD0
	[CompilerGenerated]
	private void _SetupCloseCallback_b__10_0(); // 0x0000000180480990-0x00000001804809A0
	[CompilerGenerated]
	private void _SetupCloseCallback_b__10_1(); // 0x0000000180480990-0x00000001804809A0
}

