/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class HomeFeatureRouter : MonoBehaviour // TypeDefIndex: 604
{
	// Fields
	private const float COOLDOWN_SEC = 0.8f; // Metadata: 0x0064C603
	[CompilerGenerated]
	private static HomeFeatureRouter _Instance_k__BackingField; // 0x00
	[Header("Popup n\u1ED9i b\u1ED9 c\u1EE7a Home")]
	public HomeGatePopup gateArena; // 0x20
	public HomeGatePopup gateWheel; // 0x28
	public HomeSettingsPopup settingsPopup; // 0x30
	public HomeEventStrip eventStrip; // 0x38
	[Tooltip("Ngu\u1ED3n ti\u1EBFng b\u1EA5m. N\u00FAt Home ch\u1EA1y b\u1EB1ng HomePressScale (kh\u00F4ng c\u00F3 component Button) n\u00EAn ButtonClickSound kh\u00F4ng b\u1EAFt \u0111\u01B0\u1EE3c \u2014 ph\u1EA3i ph\u00E1t th\u1EE7 c\u00F4ng t\u1EA1i \u0111\u00E2y.")]
	public HomeAudio homeAudio; // 0x40
	private float _lastRouteAt; // 0x48

	// Properties
	public static HomeFeatureRouter Instance { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001803B0AC0-0x00000001803B0B00 0x00000001803B0B00-0x00000001803B0B60

	// Constructors
	public HomeFeatureRouter(); // 0x00000001803B0AB0-0x00000001803B0AC0

	// Methods
	private void Awake(); // 0x00000001803AFF90-0x00000001803AFFF0
	private void OnDestroy(); // 0x00000001803B0230-0x00000001803B0300
	public void OpenModule(HomeModuleView view); // 0x00000001803B0300-0x00000001803B03A0
	public void Open(string routeKey); // 0x00000001803B03A0-0x00000001803B03E0
	public void Open(string routeKey, int requireLevel, string label, string flagKey, HomeModuleView view); // 0x00000001803B03E0-0x00000001803B0980
	public void GoToHub(string routeKey); // 0x00000001803AFFF0-0x00000001803B0230
	private void PushHistory(); // 0x00000001803B0980-0x00000001803B0AB0
}

