/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class PlayerOnlineTracker : MonoBehaviour // TypeDefIndex: 42
{
	// Fields
	[CompilerGenerated]
	private static PlayerOnlineTracker _Instance_k__BackingField; // 0x00
	internal string myUsername; // 0x20
	internal bool manualBusy; // 0x28

	// Properties
	internal static PlayerOnlineTracker Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180304200-0x0000000180304240 0x0000000180304240-0x00000001803042A0
	public bool InMatchScene { get; } // 0x00000001803041E0-0x00000001803041F0 
	public bool InPVPScene { get; } // 0x00000001803041F0-0x0000000180304200 
	public bool InAnyMatch { get; } // 0x00000001803041B0-0x00000001803041E0 

	// Constructors
	public PlayerOnlineTracker(); // 0x0000000180304160-0x00000001803041B0

	// Methods
	private void Awake(); // 0x00000001803036A0-0x00000001803037D0
	private void OnDestroy(); // 0x0000000180303BB0-0x0000000180303BD0
	private void OnEnable(); // 0x0000000180303D00-0x0000000180303E30
	private void OnDisable(); // 0x0000000180303BD0-0x0000000180303D00
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x0000000180303E30-0x0000000180303E70
	private void OnMatchHostEnterExit(MatchKind kind); // 0x0000000180303E30-0x0000000180303E70
	private static void StopSearchingIfNeeded(); // 0x0000000180303F70-0x0000000180304010
	public void SetUsernameAndGoOnline(string username); // 0x0000000180303F20-0x0000000180303F70
	private void SyncBusyToChat(); // 0x0000000180304010-0x00000001803040C0
	private void TryReportOffline(); // 0x00000001803040C0-0x0000000180304160
	public void SetManualBusy(bool busy); // 0x0000000180303F10-0x0000000180303F20
	public static int GetInviteListBusyState(); // 0x00000001803037D0-0x0000000180303950
	private void HandlePause(); // 0x0000000180303950-0x0000000180303A20
	private void HandleResume(); // 0x0000000180303A20-0x0000000180303B20
	private void ResetReturnToRoomFlags(); // 0x0000000180303E70-0x0000000180303F10
	public void Logout(); // 0x0000000180303B20-0x0000000180303B80
	private void OnApplicationQuit(); // 0x0000000180303B80-0x0000000180303BB0
}

