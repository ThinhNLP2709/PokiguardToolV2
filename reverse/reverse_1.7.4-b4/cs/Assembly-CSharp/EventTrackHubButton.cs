/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class EventTrackHubButton : MonoBehaviour // TypeDefIndex: 626
{
	// Fields
	public const string NODE_NAME = "btnEventTrack"; // Metadata: 0x005EF80F
	private const float DOT = 28f; // Metadata: 0x005EF81D
	private const float FLOAT_BATCH = 1f; // Metadata: 0x005EF821
	private const float FLOAT_RISE = 46f; // Metadata: 0x005EF825
	private const float FLOAT_TIME = 0.7f; // Metadata: 0x005EF829
	private const long SOON_WINDOW_MS = 259200000; // Metadata: 0x005EF82D
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
	private sealed class __c__DisplayClass31_0 // TypeDefIndex: 627
	{
		// Fields
		public EventTrackHubButton __4__this; // 0x10
		public GameObject go; // 0x18

		// Constructors
		public __c__DisplayClass31_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _SpawnFloater_b__0(); // 0x0000000180440F50-0x0000000180440F80
	}

	// Constructors
	public EventTrackHubButton(); // 0x0000000180440D70-0x0000000180440F50

	// Methods
	public static EventTrackHubButton Ensure(MonoBehaviour hub); // 0x000000018043D1B0-0x000000018043D690
	private static EventTrackHubButton FindExisting(); // 0x000000018043D690-0x000000018043D730
	private static Transform FallbackParent(MonoBehaviour hub); // 0x000000018043D730-0x000000018043D8E0
	private static EventTrackHubButton Build(Transform parent, HubRightGrid grid); // 0x000000018043D8E0-0x000000018043DF70
	private static GameObject MakeDot(RectTransform parent); // 0x000000018043DF70-0x000000018043E320
	private static UnityEngine.UI.Text MakeSoon(RectTransform parent); // 0x000000018043E320-0x000000018043E810
	private void OnEnable(); // 0x000000018043E810-0x000000018043EBB0
	private void OnDisable(); // 0x000000018043EBB0-0x000000018043EF60
	private void OnDestroy(); // 0x000000018043EF60-0x000000018043EF70
	private void OpenPanel(); // 0x000000018043EF70-0x000000018043EF80
	private void HandleChanged(string key); // 0x000000018043EF80-0x000000018043F010
	private void Render(); // 0x000000018043F010-0x000000018043F5F0
	private void BindIcon(EventTrackTheme theme); // 0x000000018043F5F0-0x000000018043F880
	private void BindBadge(EventTrackTheme theme); // 0x000000018043F880-0x000000018043FB50
	private void HandlePredictedGain(string key, int gain); // 0x000000018043FB50-0x000000018043FD00
	private void FlushFloat(); // 0x000000018043FD00-0x000000018043FF50
	private void SpawnFloater(string text); // 0x000000018043FF50-0x0000000180440880
	private void KillFloater(GameObject go); // 0x0000000180440880-0x0000000180440A50
	private void ClearFloaters(); // 0x0000000180440A50-0x0000000180440CC0
	private static long NowMs(); // 0x0000000180440CC0-0x0000000180440D70
}

