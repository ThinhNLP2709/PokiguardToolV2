/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class EventTrackHubButton : MonoBehaviour // TypeDefIndex: 625
{
	// Fields
	public const string NODE_NAME = "btnEventTrack"; // Metadata: 0x005EE43E
	private const float DOT = 28f; // Metadata: 0x005EE44C
	private const float FLOAT_BATCH = 1f; // Metadata: 0x005EE450
	private const float FLOAT_RISE = 46f; // Metadata: 0x005EE454
	private const float FLOAT_TIME = 0.7f; // Metadata: 0x005EE458
	private const long SOON_WINDOW_MS = 259200000; // Metadata: 0x005EE45C
	private string _key; // 0x20
	private Image _icon; // 0x28
	private GameObject _dot; // 0x30
	private UnityEngine.UI.Text _soon; // 0x38
	private string _boundPrefix; // 0x40
	private int _pendingFloat; // 0x48
	private bool _floatQueued; // 0x4C
	private bool _firstFetchDone; // 0x4D
	private readonly List<GameObject> _floaters; // 0x50

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass31_0 // TypeDefIndex: 626
	{
		// Fields
		public EventTrackHubButton __4__this; // 0x10
		public GameObject go; // 0x18

		// Constructors
		public __c__DisplayClass31_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SpawnFloater_b__0(); // 0x000000018043FE80-0x000000018043FEB0
	}

	// Constructors
	public EventTrackHubButton(); // 0x000000018043FCA0-0x000000018043FE80

	// Methods
	public static EventTrackHubButton Ensure(MonoBehaviour hub); // 0x000000018043C0E0-0x000000018043C5C0
	private static EventTrackHubButton FindExisting(); // 0x000000018043C5C0-0x000000018043C660
	private static Transform FallbackParent(MonoBehaviour hub); // 0x000000018043C660-0x000000018043C810
	private static EventTrackHubButton Build(Transform parent, HubRightGrid grid); // 0x000000018043C810-0x000000018043CEA0
	private static GameObject MakeDot(RectTransform parent); // 0x000000018043CEA0-0x000000018043D250
	private static UnityEngine.UI.Text MakeSoon(RectTransform parent); // 0x000000018043D250-0x000000018043D740
	private void OnEnable(); // 0x000000018043D740-0x000000018043DAE0
	private void OnDisable(); // 0x000000018043DAE0-0x000000018043DE90
	private void OnDestroy(); // 0x000000018043DE90-0x000000018043DEA0
	private void OpenPanel(); // 0x000000018043DEA0-0x000000018043DEB0
	private void HandleChanged(string key); // 0x000000018043DEB0-0x000000018043DF40
	private void Render(); // 0x000000018043DF40-0x000000018043E520
	private void BindIcon(EventTrackTheme theme); // 0x000000018043E520-0x000000018043E7B0
	private void BindBadge(EventTrackTheme theme); // 0x000000018043E7B0-0x000000018043EA80
	private void HandlePredictedGain(string key, int gain); // 0x000000018043EA80-0x000000018043EC30
	private void FlushFloat(); // 0x000000018043EC30-0x000000018043EE80
	private void SpawnFloater(string text); // 0x000000018043EE80-0x000000018043F7B0
	private void KillFloater(GameObject go); // 0x000000018043F7B0-0x000000018043F980
	private void ClearFloaters(); // 0x000000018043F980-0x000000018043FBF0
	private static long NowMs(); // 0x000000018043FBF0-0x000000018043FCA0
}

