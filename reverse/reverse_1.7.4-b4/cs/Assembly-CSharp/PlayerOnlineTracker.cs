/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class PlayerOnlineTracker : MonoBehaviour // TypeDefIndex: 51
{
	// Fields
	[CompilerGenerated]
	private static PlayerOnlineTracker _Instance_k__BackingField; // 0x00
	internal string myUsername; // 0x20
	internal bool manualBusy; // 0x28

	// Properties
	internal static PlayerOnlineTracker Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802CA7B0-0x00000001802CA7F0 0x00000001802CA7F0-0x00000001802CA890
	public bool InMatchScene { get; } // 0x00000001802CA890-0x00000001802CA8A0 
	public bool InPVPScene { get; } // 0x00000001802CA8A0-0x00000001802CA8B0 
	public bool InAnyMatch { get; } // 0x00000001802CA8B0-0x00000001802CA8E0 

	// Constructors
	public PlayerOnlineTracker(); // 0x00000001802CB9E0-0x00000001802CBAB0

	// Methods
	private void Awake(); // 0x00000001802CA8E0-0x00000001802CAB70
	private void OnDestroy(); // 0x00000001802CAB70-0x00000001802CAB90
	private void OnEnable(); // 0x00000001802CAB90-0x00000001802CACE0
	private void OnDisable(); // 0x00000001802CACE0-0x00000001802CAE30
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x00000001802CAE30-0x00000001802CAE70
	private void OnMatchHostEnterExit(MatchKind kind); // 0x00000001802CAE30-0x00000001802CAE70
	private static void StopSearchingIfNeeded(); // 0x00000001802CAE70-0x00000001802CAF90
	public void SetUsernameAndGoOnline(string username); // 0x00000001802CAF90-0x00000001802CB000
	private void SyncBusyToChat(); // 0x00000001802CB000-0x00000001802CB130
	private void TryReportOffline(); // 0x00000001802CB130-0x00000001802CB240
	public void SetManualBusy(bool busy); // 0x00000001802CB240-0x00000001802CB250
	public static int GetInviteListBusyState(); // 0x00000001802CB250-0x00000001802CB4D0
	private void HandlePause(); // 0x00000001802CB4D0-0x00000001802CB5B0
	private void HandleResume(); // 0x00000001802CB5B0-0x00000001802CB6C0
	private void ResetReturnToRoomFlags(); // 0x00000001802CB6C0-0x00000001802CB900
	public void Logout(); // 0x00000001802CB900-0x00000001802CB9B0
	private void OnApplicationQuit(); // 0x00000001802CB9B0-0x00000001802CB9E0
}

