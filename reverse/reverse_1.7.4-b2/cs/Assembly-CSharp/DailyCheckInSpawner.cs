/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class DailyCheckInSpawner : MonoBehaviour // TypeDefIndex: 1181
{
	// Fields
	public const string SKIN_KEY = "PanelDiemdanh"; // Metadata: 0x0068CBEE
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
	public DailyCheckInSpawner(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Start(); // 0x0000000180572F30-0x0000000180573080
	public void OpenDailyCheckIn(); // 0x00000001805727A0-0x00000001805728D0
	public void CloseDailyCheckIn(); // 0x00000001805725F0-0x0000000180572600
	private void SpawnPanel(); // 0x0000000180572B90-0x0000000180572F30
	private void SetupCloseCallback(); // 0x00000001805728D0-0x0000000180572B90
	private void DestroyPanel(); // 0x0000000180572600-0x00000001805726E0
	public bool IsPanelOpen(); // 0x00000001805726E0-0x0000000180572730
	public void TogglePanel(); // 0x0000000180573090-0x0000000180573110
	private void OnDestroy(); // 0x0000000180572730-0x00000001805727A0
	[ContextMenu("Test - Open Panel")]
	public void TestOpenPanel(); // 0x0000000180573080-0x0000000180573090
	[ContextMenu("Test - Close Panel")]
	public void TestClosePanel(); // 0x00000001805725F0-0x0000000180572600
	[ContextMenu("Test - Toggle Panel")]
	public void TestTogglePanel(); // 0x0000000180573090-0x0000000180573110
	[ContextMenu("Test - Check Panel Status")]
	public void TestCheckStatus(); // 0x00000001805726E0-0x0000000180572730
	[CompilerGenerated]
	private void _SetupCloseCallback_b__10_0(); // 0x00000001805725F0-0x0000000180572600
	[CompilerGenerated]
	private void _SetupCloseCallback_b__10_1(); // 0x00000001805725F0-0x0000000180572600
}

