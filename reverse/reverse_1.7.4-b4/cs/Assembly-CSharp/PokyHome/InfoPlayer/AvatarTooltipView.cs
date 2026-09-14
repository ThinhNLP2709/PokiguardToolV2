/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace PokyHome.InfoPlayer
{
	[DisallowMultipleComponent]
	public class AvatarTooltipView : MonoBehaviour // TypeDefIndex: 2777
	{
		// Fields
		public const string FLAG = "infoplayer.avatartip"; // Metadata: 0x005F2BE1
		public const string ROOT_NAME = "AvatarTooltip"; // Metadata: 0x005F2BF6
		public const string AVT_DIR = "Image/Avt/"; // Metadata: 0x005F2C04
		private const float D_W = 560f; // Metadata: 0x005F2C0F
		private const float D_H = 330f; // Metadata: 0x005F2C13
		private const float D_PAD = 22f; // Metadata: 0x005F2C17
		private const float D_FRAME_X = 22f; // Metadata: 0x005F2C1B
		private const float D_FRAME_Y = 22f; // Metadata: 0x005F2C1F
		private const float D_FRAME = 124f; // Metadata: 0x005F2C23
		private const float D_AVT_INSET = 8f; // Metadata: 0x005F2C27
		private const float D_BADGE = 60f; // Metadata: 0x005F2C2B
		private const float D_BADGE_FS = 22f; // Metadata: 0x005F2C2F
		private const float D_DOT = 18f; // Metadata: 0x005F2C33
		private const float D_COL_X = 166f; // Metadata: 0x005F2C37
		private const float D_COL_W = 370f; // Metadata: 0x005F2C3B
		private const float D_NAME_Y = 22f; // Metadata: 0x005F2C3F
		private const float D_NAME_H = 40f; // Metadata: 0x005F2C43
		private const float D_NAME_FS = 34f; // Metadata: 0x005F2C47
		private const float D_VIP_W = 84f; // Metadata: 0x005F2C4B
		private const float D_VIP_H = 28f; // Metadata: 0x005F2C4F
		private const float D_VIP_FS = 18f; // Metadata: 0x005F2C53
		private const float D_LEVEL_Y = 64f; // Metadata: 0x005F2C57
		private const float D_LEVEL_H = 28f; // Metadata: 0x005F2C5B
		private const float D_LEVEL_FS = 22f; // Metadata: 0x005F2C5F
		private const float D_EXP_Y = 96f; // Metadata: 0x005F2C63
		private const float D_EXP_H = 12f; // Metadata: 0x005F2C67
		private const float D_GUILD_Y = 114f; // Metadata: 0x005F2C6B
		private const float D_GUILD_H = 28f; // Metadata: 0x005F2C6F
		private const float D_GUILD_FS = 22f; // Metadata: 0x005F2C73
		private const float D_COLL_Y = 142f; // Metadata: 0x005F2C77
		private const float D_COLL_H = 26f; // Metadata: 0x005F2C7B
		private const float D_COLL_FS = 20f; // Metadata: 0x005F2C7F
		private const float D_DIV_Y = 176f; // Metadata: 0x005F2C83
		private const float D_TILE_Y = 188f; // Metadata: 0x005F2C87
		private const float D_TILE_H = 64f; // Metadata: 0x005F2C8B
		private const float D_TILE_W = 166f; // Metadata: 0x005F2C8F
		private const float D_TILE_STEP = 178f; // Metadata: 0x005F2C93
		private const float D_CAP_Y = 6f; // Metadata: 0x005F2C97
		private const float D_CAP_H = 24f; // Metadata: 0x005F2C9B
		private const float D_CAP_FS = 18f; // Metadata: 0x005F2C9F
		private const float D_VAL_Y = 28f; // Metadata: 0x005F2CA3
		private const float D_VAL_H = 34f; // Metadata: 0x005F2CA7
		private const float D_VAL_FS = 28f; // Metadata: 0x005F2CAB
		private const float D_BTN_W = 150f; // Metadata: 0x005F2CAF
		private const float D_BTN_H = 44f; // Metadata: 0x005F2CB3
		private const float D_BTN_FS = 22f; // Metadata: 0x005F2CB7
		private const float D_BTN_MARGIN = 20f; // Metadata: 0x005F2CBB
		private const float D_BTN_GAP = 8f; // Metadata: 0x005F2CBF
		private const float D_BTN_BOTTOM = 14f; // Metadata: 0x005F2CC3
		public const float GAP = 11.7f; // Metadata: 0x005F2CC7
		public const float MARGIN = 10.4f; // Metadata: 0x005F2CCB
		private const float BLOCKER_ALPHA = 0.25f; // Metadata: 0x005F2CCF
		private const int TILE_COUNT = 3; // Metadata: 0x005F2CD3
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
		public static bool Enabled { get; } // 0x0000000180CC6D70-0x0000000180CC6DE0 
		public static bool IsShowing { get; } // 0x0000000180CC6DE0-0x0000000180CC6F70 
		public static float PanelW { get; } // 0x0000000180CC7760-0x0000000180CC7770 
		public static float PanelH { get; } // 0x0000000180CC7770-0x0000000180CC7780 
	
		// Nested types
		public struct Actions // TypeDefIndex: 2778
		{
			// Fields
			public Action CopyName; // 0x00
			public Action AddFriend; // 0x08
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass105_0 // TypeDefIndex: 2779
		{
			// Fields
			public int token; // 0x10
			public AvatarTooltipView __4__this; // 0x18
	
			// Constructors
			public __c__DisplayClass105_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _ApplyAvatar_b__0(Sprite sp); // 0x0000000180CCB840-0x0000000180CCBA40
		}
	
		// Constructors
		public AvatarTooltipView(); // 0x0000000180CCB450-0x0000000180CCB620
		static AvatarTooltipView(); // 0x0000000180CCB620-0x0000000180CCB6F0
	
		// Methods
		public static void Show(RectTransform anchor, ProfileDTO profile, Actions actions); // 0x0000000180CC6F70-0x0000000180CC70E0
		public static void Hide(); // 0x0000000180CC70E0-0x0000000180CC7290
		private static AvatarTooltipView Resolve(); // 0x0000000180CC7290-0x0000000180CC75C0
		public static AvatarTooltipView Spawn(); // 0x0000000180CC75C0-0x0000000180CC7760
		private void Awake(); // 0x0000000180CC7780-0x0000000180CC7980
		private void OnDestroy(); // 0x0000000180CC7980-0x0000000180CC7B60
		private void OnDisable(); // 0x0000000180CC7B60-0x0000000180CC7DA0
		private void EnsureBuilt(); // 0x0000000180CC7DA0-0x0000000180CC9C50
		private void Present(RectTransform anchor, ProfileDTO profile, Actions actions); // 0x0000000180CC9C50-0x0000000180CC9F50
		public void Fill(ProfileDTO p); // 0x0000000180CC9F50-0x0000000180CCAA60
		private void ApplyAvatar(int avtId); // 0x0000000180CCAA60-0x0000000180CCAEF0
		public void SetActions(Actions actions); // 0x0000000180CCAEF0-0x0000000180CCB120
		private void OnCopyNameClicked(); // 0x0000000180CCB120-0x0000000180CCB140
		private void OnAddFriendClicked(); // 0x0000000180CCB140-0x0000000180CCB240
		private void ClosePanel(); // 0x0000000180CCB240-0x0000000180CCB450
		[CompilerGenerated]
		private void _ClosePanel_b__109_0(); // 0x0000000180CCB6F0-0x0000000180CCB840
	}
}
