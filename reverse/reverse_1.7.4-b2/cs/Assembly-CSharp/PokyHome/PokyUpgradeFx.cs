/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome
{
	[DisallowMultipleComponent]
	public class PokyUpgradeFx : MonoBehaviour // TypeDefIndex: 2286
	{
		// Fields
		public const int KIND_COUNT = 5; // Metadata: 0x0068E583
		public const string PREFAB_PATH = "Prefabs/UI/PokyUpgradeFx"; // Metadata: 0x0068E584
		public const int SORTING_ORDER = 950; // Metadata: 0x0068E59D
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
		public enum Kind // TypeDefIndex: 2287
		{
			LevelUp = 0,
			Forge = 1,
			Awaken = 2,
			Evolve = 3,
			Reward = 4
		}
	
		// Constructors
		public PokyUpgradeFx(); // 0x00000001807A9090-0x00000001807A9140
	
		// Methods
		public static string KindPrefabPath(Kind kind); // 0x00000001807A83A0-0x00000001807A8410
		public static void Play(RectTransform anchor, Kind kind, float scale = 1f /* Metadata: 0x0068E57F */); // 0x00000001807A89D0-0x00000001807A8AA0
		public static void StopAll(); // 0x00000001807A8ED0-0x00000001807A8F80
		private static PokyUpgradeFx Resolve(); // 0x00000001807A8CB0-0x00000001807A8ED0
		private void Awake(); // 0x00000001807A80E0-0x00000001807A82C0
		private void OnDestroy(); // 0x00000001807A8920-0x00000001807A89D0
		private void Present(RectTransform anchor, Kind kind, float scale); // 0x00000001807A8AA0-0x00000001807A8CB0
		private RectTransform LoadKind(Kind kind, int i); // 0x00000001807A8410-0x00000001807A86E0
		private Vector2 LocalPointOf(RectTransform anchor); // 0x00000001807A86E0-0x00000001807A8920
		private void Update(); // 0x00000001807A8F80-0x00000001807A9090
		private void Disable(int i); // 0x00000001807A82C0-0x00000001807A83A0
	}
}
