/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class PlayerOnlineTracker : MonoBehaviour // TypeDefIndex: 51
{
	// Fields
	[CompilerGenerated]
	private static PlayerOnlineTracker _Instance_k__BackingField; // 0x00
	internal string myUsername; // 0x20
	internal bool manualBusy; // 0x28

	// Properties
	internal static PlayerOnlineTracker Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802CA780-0x00000001802CA7C0 0x00000001802CA7C0-0x00000001802CA860
	public bool InMatchScene { get; } // 0x00000001802CA860-0x00000001802CA870 
	public bool InPVPScene { get; } // 0x00000001802CA870-0x00000001802CA880 
	public bool InAnyMatch { get; } // 0x00000001802CA880-0x00000001802CA8B0 

	// Constructors
	public PlayerOnlineTracker(); // 0x00000001802CB9B0-0x00000001802CBA80

	// Methods
	private void Awake(); // 0x00000001802CA8B0-0x00000001802CAB40
	private void OnDestroy(); // 0x00000001802CAB40-0x00000001802CAB60
	private void OnEnable(); // 0x00000001802CAB60-0x00000001802CACB0
	private void OnDisable(); // 0x00000001802CACB0-0x00000001802CAE00
	private void OnSceneLoaded(Scene scene, LoadSceneMode mode); // 0x00000001802CAE00-0x00000001802CAE40
	private void OnMatchHostEnterExit(MatchKind kind); // 0x00000001802CAE00-0x00000001802CAE40
	private static void StopSearchingIfNeeded(); // 0x00000001802CAE40-0x00000001802CAF60
	public void SetUsernameAndGoOnline(string username); // 0x00000001802CAF60-0x00000001802CAFD0
	private void SyncBusyToChat(); // 0x00000001802CAFD0-0x00000001802CB100
	private void TryReportOffline(); // 0x00000001802CB100-0x00000001802CB210
	public void SetManualBusy(bool busy); // 0x00000001802CB210-0x00000001802CB220
	public static int GetInviteListBusyState(); // 0x00000001802CB220-0x00000001802CB4A0
	private void HandlePause(); // 0x00000001802CB4A0-0x00000001802CB580
	private void HandleResume(); // 0x00000001802CB580-0x00000001802CB690
	private void ResetReturnToRoomFlags(); // 0x00000001802CB690-0x00000001802CB8D0
	public void Logout(); // 0x00000001802CB8D0-0x00000001802CB980
	private void OnApplicationQuit(); // 0x00000001802CB980-0x00000001802CB9B0
}

