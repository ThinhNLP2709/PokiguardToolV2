/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class PlayerOnlineTracker : MonoBehaviour // TypeDefIndex: 50
{
	// Fields
	[CompilerGenerated]
	private static PlayerOnlineTracker _Instance_k__BackingField; // 0x00
	internal string myUsername; // 0x20
	internal bool manualBusy; // 0x28

	// Properties
	internal static PlayerOnlineTracker Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018030D8D0-0x000000018030D910 0x000000018030D910-0x000000018030D970
	public bool InMatchScene { get; } // 0x000000018030D8B0-0x000000018030D8C0 
	public bool InPVPScene { get; } // 0x000000018030D8C0-0x000000018030D8D0 
	public bool InAnyMatch { get; } // 0x000000018030D880-0x000000018030D8B0 

	// Constructors
	public PlayerOnlineTracker(); // 0x000000018030D830-0x000000018030D880

	// Methods
	private void Awake(); // 0x000000018030CD70-0x000000018030CEA0
	private void OnDestroy(); // 0x000000018030D280-0x000000018030D2A0
	private void OnEnable(); // 0x000000018030D3D0-0x000000018030D500
	private void OnDisable(); // 0x000000018030D2A0-0x000000018030D3D0
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x000000018030D500-0x000000018030D540
	private void OnMatchHostEnterExit(MatchKind kind); // 0x000000018030D500-0x000000018030D540
	private static void StopSearchingIfNeeded(); // 0x000000018030D640-0x000000018030D6E0
	public void SetUsernameAndGoOnline(string username); // 0x000000018030D5F0-0x000000018030D640
	private void SyncBusyToChat(); // 0x000000018030D6E0-0x000000018030D790
	private void TryReportOffline(); // 0x000000018030D790-0x000000018030D830
	public void SetManualBusy(bool busy); // 0x000000018030D5E0-0x000000018030D5F0
	public static int GetInviteListBusyState(); // 0x000000018030CEA0-0x000000018030D020
	private void HandlePause(); // 0x000000018030D020-0x000000018030D0F0
	private void HandleResume(); // 0x000000018030D0F0-0x000000018030D1F0
	private void ResetReturnToRoomFlags(); // 0x000000018030D540-0x000000018030D5E0
	public void Logout(); // 0x000000018030D1F0-0x000000018030D250
	private void OnApplicationQuit(); // 0x000000018030D250-0x000000018030D280
}

