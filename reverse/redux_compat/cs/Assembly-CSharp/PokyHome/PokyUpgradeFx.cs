/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyUpgradeFx : MonoBehaviour // TypeDefIndex: 1960
	{
		// Fields
		public const int KIND_COUNT = 5; // Metadata: 0x0064E0FF
		public const string PREFAB_PATH = "Prefabs/UI/PokyUpgradeFx"; // Metadata: 0x0064E100
		public const int SORTING_ORDER = 950; // Metadata: 0x0064E119
		[Tooltip("Nh\u00E1nh con c\u1EE7a t\u1EEBng Kind \u2014 n\u1EA1p L\u01AF\u1EDCI l\u00FAc ch\u1EA1y, kh\u00F4ng g\u00E1n s\u1EB5n trong prefab.")]
		public RectTransform[] kinds; // 0x20
		[Tooltip("Th\u1EDDi l\u01B0\u1EE3ng (gi\u00E2y) tr\u01B0\u1EDBc khi t\u1EF1 t\u1EAFt nh\u00E1nh \u2014 builder g\u00E1n theo s\u1ED1 frame th\u1EADt.")]
		public float[] durations; // 0x28
		private static PokyUpgradeFx _instance; // 0x00
		private static bool _prefabMissingLogged; // 0x08
		private RectTransform _canvasRect; // 0x30
		private Canvas _canvas; // 0x38
		private readonly float[] _offAt; // 0x40
	
		// Nested types
		public enum Kind // TypeDefIndex: 1961
		{
			LevelUp = 0,
			Forge = 1,
			Awaken = 2,
			Evolve = 3,
			Reward = 4
		}
	
		// Constructors
		public PokyUpgradeFx(); // 0x000000018066B9C0-0x000000018066BA70
	
		// Methods
		public static string KindPrefabPath(Kind kind); // 0x000000018066AD50-0x000000018066ADC0
		public static void Play(RectTransform anchor, Kind kind, float scale = 1f /* Metadata: 0x0064E0FB */); // 0x000000018066B380-0x000000018066B450
		public static void StopAll(); // 0x000000018066B880-0x000000018066B930
		private static PokyUpgradeFx Resolve(); // 0x000000018066B660-0x000000018066B880
		private void Awake(); // 0x000000018066AA90-0x000000018066AC70
		private void OnDestroy(); // 0x000000018066B2D0-0x000000018066B380
		private void Present(RectTransform anchor, Kind kind, float scale); // 0x000000018066B450-0x000000018066B660
		private RectTransform LoadKind(Kind kind, int i); // 0x000000018066ADC0-0x000000018066B090
		private Vector2 LocalPointOf(RectTransform anchor); // 0x000000018066B090-0x000000018066B2D0
		private void Update(); // 0x000000018066B930-0x000000018066B9C0
		private void Disable(int i); // 0x000000018066AC70-0x000000018066AD50
	}
}
