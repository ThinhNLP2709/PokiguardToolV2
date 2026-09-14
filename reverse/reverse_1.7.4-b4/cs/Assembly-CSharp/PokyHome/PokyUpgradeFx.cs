/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyUpgradeFx : MonoBehaviour // TypeDefIndex: 2729
	{
		// Fields
		public const int KIND_COUNT = 5; // Metadata: 0x005F29F0
		public const string PREFAB_PATH = "Prefabs/UI/PokyUpgradeFx"; // Metadata: 0x005F29F1
		public const int SORTING_ORDER = 950; // Metadata: 0x005F2A0A
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
		public enum Kind // TypeDefIndex: 2730
		{
			LevelUp = 0,
			Forge = 1,
			Awaken = 2,
			Evolve = 3,
			Reward = 4
		}
	
		// Constructors
		public PokyUpgradeFx(); // 0x0000000180C73330-0x0000000180C734E0
	
		// Methods
		public static string KindPrefabPath(Kind kind); // 0x0000000180C71680-0x0000000180C71700
		public static void Play(RectTransform anchor, Kind kind, float scale = 1f /* Metadata: 0x005F29EC */); // 0x0000000180C71700-0x0000000180C71850
		public static void StopAll(); // 0x0000000180C71850-0x0000000180C71980
		private static PokyUpgradeFx Resolve(); // 0x0000000180C71980-0x0000000180C71DA0
		private void Awake(); // 0x0000000180C71DA0-0x0000000180C72190
		private void OnDestroy(); // 0x0000000180C72190-0x0000000180C72350
		private void Present(RectTransform anchor, Kind kind, float scale); // 0x0000000180C72350-0x0000000180C727B0
		private RectTransform LoadKind(Kind kind, int i); // 0x0000000180C727B0-0x0000000180C72BE0
		private Vector2 LocalPointOf(RectTransform anchor); // 0x0000000180C72BE0-0x0000000180C73060
		private void Update(); // 0x0000000180C73060-0x0000000180C73180
		private void Disable(int i); // 0x0000000180C73180-0x0000000180C73330
	}
}
