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
	public class AvatarTooltipView : MonoBehaviour // TypeDefIndex: 2770
	{
		// Fields
		public const string FLAG = "infoplayer.avatartip"; // Metadata: 0x005F17CA
		public const string ROOT_NAME = "AvatarTooltip"; // Metadata: 0x005F17DF
		public const string AVT_DIR = "Image/Avt/"; // Metadata: 0x005F17ED
		private const float D_W = 560f; // Metadata: 0x005F17F8
		private const float D_H = 330f; // Metadata: 0x005F17FC
		private const float D_PAD = 22f; // Metadata: 0x005F1800
		private const float D_FRAME_X = 22f; // Metadata: 0x005F1804
		private const float D_FRAME_Y = 22f; // Metadata: 0x005F1808
		private const float D_FRAME = 124f; // Metadata: 0x005F180C
		private const float D_AVT_INSET = 8f; // Metadata: 0x005F1810
		private const float D_BADGE = 60f; // Metadata: 0x005F1814
		private const float D_BADGE_FS = 22f; // Metadata: 0x005F1818
		private const float D_DOT = 18f; // Metadata: 0x005F181C
		private const float D_COL_X = 166f; // Metadata: 0x005F1820
		private const float D_COL_W = 370f; // Metadata: 0x005F1824
		private const float D_NAME_Y = 22f; // Metadata: 0x005F1828
		private const float D_NAME_H = 40f; // Metadata: 0x005F182C
		private const float D_NAME_FS = 34f; // Metadata: 0x005F1830
		private const float D_VIP_W = 84f; // Metadata: 0x005F1834
		private const float D_VIP_H = 28f; // Metadata: 0x005F1838
		private const float D_VIP_FS = 18f; // Metadata: 0x005F183C
		private const float D_LEVEL_Y = 64f; // Metadata: 0x005F1840
		private const float D_LEVEL_H = 28f; // Metadata: 0x005F1844
		private const float D_LEVEL_FS = 22f; // Metadata: 0x005F1848
		private const float D_EXP_Y = 96f; // Metadata: 0x005F184C
		private const float D_EXP_H = 12f; // Metadata: 0x005F1850
		private const float D_GUILD_Y = 114f; // Metadata: 0x005F1854
		private const float D_GUILD_H = 28f; // Metadata: 0x005F1858
		private const float D_GUILD_FS = 22f; // Metadata: 0x005F185C
		private const float D_COLL_Y = 142f; // Metadata: 0x005F1860
		private const float D_COLL_H = 26f; // Metadata: 0x005F1864
		private const float D_COLL_FS = 20f; // Metadata: 0x005F1868
		private const float D_DIV_Y = 176f; // Metadata: 0x005F186C
		private const float D_TILE_Y = 188f; // Metadata: 0x005F1870
		private const float D_TILE_H = 64f; // Metadata: 0x005F1874
		private const float D_TILE_W = 166f; // Metadata: 0x005F1878
		private const float D_TILE_STEP = 178f; // Metadata: 0x005F187C
		private const float D_CAP_Y = 6f; // Metadata: 0x005F1880
		private const float D_CAP_H = 24f; // Metadata: 0x005F1884
		private const float D_CAP_FS = 18f; // Metadata: 0x005F1888
		private const float D_VAL_Y = 28f; // Metadata: 0x005F188C
		private const float D_VAL_H = 34f; // Metadata: 0x005F1890
		private const float D_VAL_FS = 28f; // Metadata: 0x005F1894
		private const float D_BTN_W = 150f; // Metadata: 0x005F1898
		private const float D_BTN_H = 44f; // Metadata: 0x005F189C
		private const float D_BTN_FS = 22f; // Metadata: 0x005F18A0
		private const float D_BTN_MARGIN = 20f; // Metadata: 0x005F18A4
		private const float D_BTN_GAP = 8f; // Metadata: 0x005F18A8
		private const float D_BTN_BOTTOM = 14f; // Metadata: 0x005F18AC
		public const float GAP = 11.7f; // Metadata: 0x005F18B0
		public const float MARGIN = 10.4f; // Metadata: 0x005F18B4
		private const float BLOCKER_ALPHA = 0.25f; // Metadata: 0x005F18B8
		private const int TILE_COUNT = 3; // Metadata: 0x005F18BC
		private static readonly Color OnlineColor; // 0x00
		private static readonly Color ExpBackTint; // 0x10
		private static readonly Color ExpFillTint; // 0x20
		private static readonly Color AvatarFallback; // 0x30
		private static readonly Color FriendTint; // 0x40
		private static readonly Color CopyTint; // 0x50
		public RectTransform panel; // 0x20
		public Button blocker; // 0x28
		public Image imgShadow; // 0x30
		public Image imgPanel; // 0x38
		public Image imgAvatarFrame; // 0x40
		public Image imgAvatar; // 0x48
		public Image imgLevelBadge; // 0x50
		public Image imgOnlineDot; // 0x58
		public Image imgExpBack; // 0x60
		public Image imgExpFill; // 0x68
		public UnityEngine.UI.Text txtLevelBadge; // 0x70
		public UnityEngine.UI.Text txtVip; // 0x78
		public UnityEngine.UI.Text txtName; // 0x80
		public UnityEngine.UI.Text txtLevel; // 0x88
		public UnityEngine.UI.Text txtGuild; // 0x90
		public UnityEngine.UI.Text txtCollection; // 0x98
		public InfoPlayerTooltipKit.Chip[] tiles; // 0xA0
		public UnityEngine.UI.Text[] txtCaption; // 0xA8
		public UnityEngine.UI.Text[] txtValue; // 0xB0
		public Button btnCopyName; // 0xB8
		public Button btnAddFriend; // 0xC0
		private CanvasGroup _group; // 0xC8
		private bool _built; // 0xD0
		private Action _copyAction; // 0xD8
		private Action _friendAction; // 0xE0
		private int _avatarToken; // 0xE8
		private static AvatarTooltipView _instance; // 0x60
	
		// Properties
		public static bool Enabled { get; } // 0x0000000180CB9550-0x0000000180CB95C0 
		public static bool IsShowing { get; } // 0x0000000180CB95C0-0x0000000180CB9750 
		public static float PanelW { get; } // 0x0000000180CB9F40-0x0000000180CB9F50 
		public static float PanelH { get; } // 0x0000000180CB9F50-0x0000000180CB9F60 
	
		// Nested types
		public struct Actions // TypeDefIndex: 2771
		{
			// Fields
			public Action CopyName; // 0x00
			public Action AddFriend; // 0x08
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass105_0 // TypeDefIndex: 2772
		{
			// Fields
			public int token; // 0x10
			public AvatarTooltipView __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass105_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _ApplyAvatar_b__0(Sprite sp); // 0x0000000180CBE020-0x0000000180CBE220
		}
	
		// Constructors
		public AvatarTooltipView(); // 0x0000000180CBDC30-0x0000000180CBDE00
		static AvatarTooltipView(); // 0x0000000180CBDE00-0x0000000180CBDED0
	
		// Methods
		public static void Show(RectTransform anchor, ProfileDTO profile, Actions actions); // 0x0000000180CB9750-0x0000000180CB98C0
		public static void Hide(); // 0x0000000180CB98C0-0x0000000180CB9A70
		private static AvatarTooltipView Resolve(); // 0x0000000180CB9A70-0x0000000180CB9DA0
		public static AvatarTooltipView Spawn(); // 0x0000000180CB9DA0-0x0000000180CB9F40
		private void Awake(); // 0x0000000180CB9F60-0x0000000180CBA160
		private void OnDestroy(); // 0x0000000180CBA160-0x0000000180CBA340
		private void OnDisable(); // 0x0000000180CBA340-0x0000000180CBA580
		private void EnsureBuilt(); // 0x0000000180CBA580-0x0000000180CBC430
		private void Present(RectTransform anchor, ProfileDTO profile, Actions actions); // 0x0000000180CBC430-0x0000000180CBC730
		public void Fill(ProfileDTO p); // 0x0000000180CBC730-0x0000000180CBD240
		private void ApplyAvatar(int avtId); // 0x0000000180CBD240-0x0000000180CBD6D0
		public void SetActions(Actions actions); // 0x0000000180CBD6D0-0x0000000180CBD900
		private void OnCopyNameClicked(); // 0x0000000180CBD900-0x0000000180CBD920
		private void OnAddFriendClicked(); // 0x0000000180CBD920-0x0000000180CBDA20
		private void ClosePanel(); // 0x0000000180CBDA20-0x0000000180CBDC30
		[CompilerGenerated]
		private void _ClosePanel_b__109_0(); // 0x0000000180CBDED0-0x0000000180CBE020
	}
}
