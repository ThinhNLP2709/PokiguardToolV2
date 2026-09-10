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
	public class AvatarTooltipView : MonoBehaviour // TypeDefIndex: 2335
	{
		// Fields
		public const string FLAG = "infoplayer.avatartip"; // Metadata: 0x0068E9B7
		public const string ROOT_NAME = "AvatarTooltip"; // Metadata: 0x0068E9CC
		public const string AVT_DIR = "Image/Avt/"; // Metadata: 0x0068E9DA
		private const float D_W = 560f; // Metadata: 0x0068E9E5
		private const float D_H = 330f; // Metadata: 0x0068E9E9
		private const float D_PAD = 22f; // Metadata: 0x0068E9ED
		private const float D_FRAME_X = 22f; // Metadata: 0x0068E9F1
		private const float D_FRAME_Y = 22f; // Metadata: 0x0068E9F5
		private const float D_FRAME = 124f; // Metadata: 0x0068E9F9
		private const float D_AVT_INSET = 8f; // Metadata: 0x0068E9FD
		private const float D_BADGE = 60f; // Metadata: 0x0068EA01
		private const float D_BADGE_FS = 22f; // Metadata: 0x0068EA05
		private const float D_DOT = 18f; // Metadata: 0x0068EA09
		private const float D_COL_X = 166f; // Metadata: 0x0068EA0D
		private const float D_COL_W = 370f; // Metadata: 0x0068EA11
		private const float D_NAME_Y = 22f; // Metadata: 0x0068EA15
		private const float D_NAME_H = 40f; // Metadata: 0x0068EA19
		private const float D_NAME_FS = 34f; // Metadata: 0x0068EA1D
		private const float D_VIP_W = 84f; // Metadata: 0x0068EA21
		private const float D_VIP_H = 28f; // Metadata: 0x0068EA25
		private const float D_VIP_FS = 18f; // Metadata: 0x0068EA29
		private const float D_LEVEL_Y = 64f; // Metadata: 0x0068EA2D
		private const float D_LEVEL_H = 28f; // Metadata: 0x0068EA31
		private const float D_LEVEL_FS = 22f; // Metadata: 0x0068EA35
		private const float D_EXP_Y = 96f; // Metadata: 0x0068EA39
		private const float D_EXP_H = 12f; // Metadata: 0x0068EA3D
		private const float D_GUILD_Y = 114f; // Metadata: 0x0068EA41
		private const float D_GUILD_H = 28f; // Metadata: 0x0068EA45
		private const float D_GUILD_FS = 22f; // Metadata: 0x0068EA49
		private const float D_COLL_Y = 142f; // Metadata: 0x0068EA4D
		private const float D_COLL_H = 26f; // Metadata: 0x0068EA51
		private const float D_COLL_FS = 20f; // Metadata: 0x0068EA55
		private const float D_DIV_Y = 176f; // Metadata: 0x0068EA59
		private const float D_TILE_Y = 188f; // Metadata: 0x0068EA5D
		private const float D_TILE_H = 64f; // Metadata: 0x0068EA61
		private const float D_TILE_W = 166f; // Metadata: 0x0068EA65
		private const float D_TILE_STEP = 178f; // Metadata: 0x0068EA69
		private const float D_CAP_Y = 6f; // Metadata: 0x0068EA6D
		private const float D_CAP_H = 24f; // Metadata: 0x0068EA71
		private const float D_CAP_FS = 18f; // Metadata: 0x0068EA75
		private const float D_VAL_Y = 28f; // Metadata: 0x0068EA79
		private const float D_VAL_H = 34f; // Metadata: 0x0068EA7D
		private const float D_VAL_FS = 28f; // Metadata: 0x0068EA81
		private const float D_BTN_W = 150f; // Metadata: 0x0068EA85
		private const float D_BTN_H = 44f; // Metadata: 0x0068EA89
		private const float D_BTN_FS = 22f; // Metadata: 0x0068EA8D
		private const float D_BTN_MARGIN = 20f; // Metadata: 0x0068EA91
		private const float D_BTN_GAP = 8f; // Metadata: 0x0068EA95
		private const float D_BTN_BOTTOM = 14f; // Metadata: 0x0068EA99
		public const float GAP = 11.7f; // Metadata: 0x0068EA9D
		public const float MARGIN = 10.4f; // Metadata: 0x0068EAA1
		private const float BLOCKER_ALPHA = 0.25f; // Metadata: 0x0068EAA5
		private const int TILE_COUNT = 3; // Metadata: 0x0068EAA9
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
		public static bool Enabled { get; } // 0x00000001807B3E90-0x00000001807B3EF0 
		public static bool IsShowing { get; } // 0x00000001807B3EF0-0x00000001807B3FB0 
		public static float PanelW { get; } // 0x00000001807B3FC0-0x00000001807B3FD0 
		public static float PanelH { get; } // 0x00000001807B3FB0-0x00000001807B3FC0 
	
		// Nested types
		public struct Actions // TypeDefIndex: 2336
		{
			// Fields
			public Action CopyName; // 0x00
			public Action AddFriend; // 0x08
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass105_0 // TypeDefIndex: 2337
		{
			// Fields
			public int token; // 0x10
			public AvatarTooltipView __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass105_0(); // 0x00000001802E9CB0-0x00000001802E9CC0
	
			// Methods
			internal void _ApplyAvatar_b__0(Sprite sp); // 0x00000001807DC340-0x00000001807DC440
		}
	
		// Constructors
		public AvatarTooltipView(); // 0x00000001807B3DD0-0x00000001807B3E90
		static AvatarTooltipView(); // 0x00000001807B3D10-0x00000001807B3DD0
	
		// Methods
		public static void Show(RectTransform anchor, ProfileDTO profile, Actions actions); // 0x00000001807B3A30-0x00000001807B3B20
		public static void Hide(); // 0x00000001807B3080-0x00000001807B3160
		private static AvatarTooltipView Resolve(); // 0x00000001807B35A0-0x00000001807B3860
		public static AvatarTooltipView Spawn(); // 0x00000001807B3B20-0x00000001807B3C90
		private void Awake(); // 0x00000001807B1340-0x00000001807B1440
		private void OnDestroy(); // 0x00000001807B3230-0x00000001807B32F0
		private void OnDisable(); // 0x00000001807B32F0-0x00000001807B33D0
		private void EnsureBuilt(); // 0x00000001807B1570-0x00000001807B2830
		private void Present(RectTransform anchor, ProfileDTO profile, Actions actions); // 0x00000001807B33D0-0x00000001807B35A0
		public void Fill(ProfileDTO p); // 0x00000001807B2830-0x00000001807B3080
		private void ApplyAvatar(int avtId); // 0x00000001807B1080-0x00000001807B1340
		public void SetActions(Actions actions); // 0x00000001807B3860-0x00000001807B3A30
		private void OnCopyNameClicked(); // 0x00000001807B3210-0x00000001807B3230
		private void OnAddFriendClicked(); // 0x00000001807B3160-0x00000001807B3210
		private void ClosePanel(); // 0x00000001807B1440-0x00000001807B1570
		[CompilerGenerated]
		private void _ClosePanel_b__109_0(); // 0x00000001807B3C90-0x00000001807B3D10
	}
}
