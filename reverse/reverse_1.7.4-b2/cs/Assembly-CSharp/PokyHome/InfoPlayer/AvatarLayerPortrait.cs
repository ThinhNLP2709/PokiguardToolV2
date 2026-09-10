/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class AvatarLayerPortrait : MonoBehaviour // TypeDefIndex: 2333
	{
		// Fields
		public const string BODY_DIR = "Image/EquipUI/Body/"; // Metadata: 0x0068E982
		public const string FLAG_KEEP_STAGE = "infoplayer.avatarfx"; // Metadata: 0x0068E996
		public static readonly EquipSlot[] BackToFront; // 0x00
		public static readonly EquipSlot BodyBaseBefore; // 0x08
		public static readonly string[] LayerNodeNames; // 0x10
		public const string NODE_BASE_BODY = "img_BaseBody"; // Metadata: 0x0068E9AA
		[Header("M\u01B0\u1EDDi m\u1ED9t l\u1EDBp, th\u1EE9 t\u1EF1 sau \u2192 tr\u01B0\u1EDBc (xem BackToFront)")]
		public Image[] layers; // 0x20
		[Header("Th\u00E2n ng\u01B0\u1EDDi n\u1EC1n")]
		[Tooltip("Nh\u00E2n v\u1EADt tr\u1EA7n, lu\u00F4n hi\u1EC7n \u2014 nh\u1EDD n\u00F3, m\u1ED9t b\u1ED9 \u0111\u1ED3 thi\u1EBFu m\u00F3n v\u1EABn ra m\u1ED9t nh\u00E2n v\u1EADt ch\u1EE9 kh\u00F4ng ph\u1EA3i v\u00E0i m\u1EA3nh v\u1EA3i l\u01A1 l\u1EEDng. T\u1EAFt khi m\u1EB7c b\u1ED9 avatar li\u1EC1n.")]
		public Image baseBody; // 0x28
		[Header("\u1EA2nh minh ho\u1EA1 thay th\u1EBF")]
		[Tooltip("B\u1EE9c c\u00F3 s\u1EB5n trong khung. T\u1EAFt ngay khi c\u00F3 th\u00E2n ng\u01B0\u1EDDi ho\u1EB7c c\u00F3 m\u00F3n \u2014 n\u1EBFu kh\u00F4ng, b\u1ED9 \u0111\u1ED3 v\u1EEBa ph\u1ED1i n\u1EB1m ch\u1ED3ng l\u00EAn m\u1ED9t b\u1EE9c tranh kh\u00E1c.")]
		public Image placeholderArt; // 0x30
		private readonly int[] _iconToken; // 0x38
		private EquipSlotDTO[] _lastSlots; // 0x40
		private bool _avatarSetHidden; // 0x48
		private Image _fittedLayer; // 0x50
		private Vector2 _fitSavedPosition; // 0x58
		private Vector2 _fitSavedSize; // 0x60
		private Vector3 _fitSavedScale; // 0x68
	
		// Properties
		public static bool KeepStageWithSet { get; } // 0x00000001807B1020-0x00000001807B1080 
		public bool AvatarSetHidden { get; } // 0x00000001805F17F0-0x00000001805F1800 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass24_0 // TypeDefIndex: 2334
		{
			// Fields
			public AvatarLayerPortrait __4__this; // 0x10
			public Image layer; // 0x18
			public int slotIndex; // 0x20
			public int token; // 0x24
			public bool legacy; // 0x28
	
			// Constructors
			public __c__DisplayClass24_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _LoadLayer_b__0(Sprite sp); // 0x00000001807C6EE0-0x00000001807C6FC0
		}
	
		// Constructors
		public AvatarLayerPortrait(); // 0x00000001807B0F90-0x00000001807B1020
		static AvatarLayerPortrait(); // 0x00000001807B0CB0-0x00000001807B0F90
	
		// Methods
		private void Awake(); // 0x00000001807AF670-0x00000001807AF680
		private void OnDisable(); // 0x00000001807AFA50-0x00000001807AFAB0
		public void AutoWire(); // 0x00000001807AF280-0x00000001807AF670
		public void EnsureDrawOrder(); // 0x00000001807AFD30-0x00000001807B01E0
		private static void PlaceSibling(Transform t, ref int index); // 0x00000001807B0A70-0x00000001807B0AB0
		public void Bind(EquipSlotDTO[] slots, bool avatarSetHidden); // 0x00000001807AF680-0x00000001807AFA50
		public void SetAvatarSetHidden(bool hidden); // 0x00000001807B0BE0-0x00000001807B0C00
		public void Clear(); // 0x00000001807AFAF0-0x00000001807AFD30
		private void LoadLayer(Image layer, int slot, long iconId); // 0x00000001807B0780-0x00000001807B09E0
		private void PlaceLayer(Image layer, Sprite sprite, bool legacyWeapon); // 0x00000001807B09E0-0x00000001807B0A70
		private void FitLegacyWeapon(Image layer, Sprite icon); // 0x00000001807B01E0-0x00000001807B04E0
		private void RestoreFittedLayer(Image only); // 0x00000001807B0AB0-0x00000001807B0BE0
		private static void SetLayerSprite(Image layer, Sprite sprite); // 0x00000001807B0C00-0x00000001807B0CB0
		private Image LayerFor(EquipSlot slot); // 0x00000001807B0640-0x00000001807B0780
		public static int IndexOf(EquipSlot slot); // 0x00000001807B0550-0x00000001807B0640
		private static bool HasItem(EquipSlotDTO[] slots, EquipSlot slot); // 0x00000001807B04E0-0x00000001807B0550
		private void Cancel(int slot); // 0x00000001807AFAB0-0x00000001807AFAF0
		private void CancelAll(); // 0x00000001807AFA50-0x00000001807AFAB0
	}
}
