/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class AvatarLayerPortrait : MonoBehaviour // TypeDefIndex: 2768
	{
		// Fields
		public const string BODY_DIR = "Image/EquipUI/Body/"; // Metadata: 0x005F1795
		public const string FLAG_KEEP_STAGE = "infoplayer.avatarfx"; // Metadata: 0x005F17A9
		public static readonly EquipSlot[] BackToFront; // 0x00
		public static readonly EquipSlot BodyBaseBefore; // 0x08
		public static readonly string[] LayerNodeNames; // 0x10
		public const string NODE_BASE_BODY = "img_BaseBody"; // Metadata: 0x005F17BD
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
		public static bool KeepStageWithSet { get; } // 0x0000000180CB60E0-0x0000000180CB6150 
		public bool AvatarSetHidden { get; } // 0x00000001806D8E70-0x00000001806D8E80 
	
		// Nested types
		[CompilerGenerated]
		private sealed class __c__DisplayClass24_0 // TypeDefIndex: 2769
		{
			// Fields
			public AvatarLayerPortrait __4__this; // 0x10
			public Image layer; // 0x18
			public int slotIndex; // 0x20
			public int token; // 0x24
			public bool legacy; // 0x28
	
			// Constructors
			public __c__DisplayClass24_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _LoadLayer_b__0(Sprite sp); // 0x0000000180CB9370-0x0000000180CB9550
		}
	
		// Constructors
		public AvatarLayerPortrait(); // 0x0000000180CB8EC0-0x0000000180CB9010
		static AvatarLayerPortrait(); // 0x0000000180CB9010-0x0000000180CB9370
	
		// Methods
		private void Awake(); // 0x0000000180CB6150-0x0000000180CB6160
		private void OnDisable(); // 0x0000000180CB6160-0x0000000180CB61C0
		public void AutoWire(); // 0x0000000180CB61C0-0x0000000180CB68E0
		public void EnsureDrawOrder(); // 0x0000000180CB68E0-0x0000000180CB70A0
		private static void PlaceSibling(Transform t, ref int index); // 0x0000000180CB70A0-0x0000000180CB7180
		public void Bind(EquipSlotDTO[] slots, bool avatarSetHidden); // 0x0000000180CB7180-0x0000000180CB7820
		public void SetAvatarSetHidden(bool hidden); // 0x0000000180CB7820-0x0000000180CB7840
		public void Clear(); // 0x0000000180CB7840-0x0000000180CB7BF0
		private void LoadLayer(Image layer, int slot, long iconId); // 0x0000000180CB7BF0-0x0000000180CB8000
		private void PlaceLayer(Image layer, Sprite sprite, bool legacyWeapon); // 0x0000000180CB8000-0x0000000180CB80A0
		private void FitLegacyWeapon(Image layer, Sprite icon); // 0x0000000180CB80A0-0x0000000180CB8600
		private void RestoreFittedLayer(Image only); // 0x0000000180CB8600-0x0000000180CB89D0
		private static void SetLayerSprite(Image layer, Sprite sprite); // 0x0000000180CB89D0-0x0000000180CB8BD0
		private Image LayerFor(EquipSlot slot); // 0x0000000180CB8BD0-0x0000000180CB8D20
		public static int IndexOf(EquipSlot slot); // 0x0000000180CB8D20-0x0000000180CB8E10
		private static bool HasItem(EquipSlotDTO[] slots, EquipSlot slot); // 0x0000000180CB8E10-0x0000000180CB8E80
		private void Cancel(int slot); // 0x0000000180CB8E80-0x0000000180CB8EC0
		private void CancelAll(); // 0x0000000180CB6160-0x0000000180CB61C0
	}
}
