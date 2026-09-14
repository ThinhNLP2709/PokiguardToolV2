/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class DailyCheckInSpawner : MonoBehaviour // TypeDefIndex: 1582
{
	// Fields
	public const string SKIN_KEY = "PanelDiemdanh"; // Metadata: 0x005EFE89
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
	public DailyCheckInSpawner(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Start(); // 0x00000001808760F0-0x0000000180876410
	public void OpenDailyCheckIn(); // 0x0000000180876410-0x00000001808766D0
	public void CloseDailyCheckIn(); // 0x00000001808766D0-0x00000001808766E0
	private void SpawnPanel(); // 0x00000001808766E0-0x0000000180876DF0
	private void SetupCloseCallback(); // 0x0000000180876DF0-0x00000001808772B0
	private void DestroyPanel(); // 0x00000001808772B0-0x00000001808774F0
	public bool IsPanelOpen(); // 0x00000001808774F0-0x00000001808775D0
	public void TogglePanel(); // 0x00000001808775D0-0x0000000180877600
	private void OnDestroy(); // 0x0000000180877600-0x0000000180877730
	[ContextMenu("Test - Open Panel")]
	public void TestOpenPanel(); // 0x0000000180877730-0x0000000180877740
	[ContextMenu("Test - Close Panel")]
	public void TestClosePanel(); // 0x00000001808766D0-0x00000001808766E0
	[ContextMenu("Test - Toggle Panel")]
	public void TestTogglePanel(); // 0x00000001808775D0-0x0000000180877600
	[ContextMenu("Test - Check Panel Status")]
	public void TestCheckStatus(); // 0x0000000180877740-0x0000000180877750
	[CompilerGenerated]
	private void _SetupCloseCallback_b__10_0(); // 0x00000001808766D0-0x00000001808766E0
	[CompilerGenerated]
	private void _SetupCloseCallback_b__10_1(); // 0x00000001808766D0-0x00000001808766E0
}

