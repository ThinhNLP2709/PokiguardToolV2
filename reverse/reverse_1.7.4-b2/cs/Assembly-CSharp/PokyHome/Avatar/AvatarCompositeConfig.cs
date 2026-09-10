/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace PokyHome.Avatar
{
	public static class AvatarCompositeConfig // TypeDefIndex: 2461
	{
		// Fields
		public const string FLAG = "avatar.composite"; // Metadata: 0x0068F52F
		public const string FLAG_BG = "avatar.composite.bg"; // Metadata: 0x0068F540
		public const string FLAG_FX = "avatar.composite.fx"; // Metadata: 0x0068F554
		public const string BODY_DIR = "Image/EquipUI/Body/"; // Metadata: 0x0068F568
		public const string LEGACY_AVATAR_DIR = "Image/Avt/"; // Metadata: 0x0068F57C
		public const long LEGACY_AVATAR_ICON_BASE = 9801000; // Metadata: 0x0068F587
		public const long LEGACY_AVATAR_ICON_MAX = 9801999; // Metadata: 0x0068F58F
		public const string BODY_BASE_PATH = "Image/EquipUI/Body/body_base"; // Metadata: 0x0068F597
		public const int SOURCE_FRAME = 512; // Metadata: 0x0068F5B4
		public const int BAKE_SIZE = 384; // Metadata: 0x0068F5B6
		public const int LRU_CAP = 40; // Metadata: 0x0068F5B8
		public const byte ALPHA_EDGE = 8; // Metadata: 0x0068F5B9
		public const bool FLIP_Y = false; // Metadata: 0x0068F5BA
		public const int BODY_ROW_TOP = 128; // Metadata: 0x0068F5BB
		public const int BODY_ROW_BOTTOM = 393; // Metadata: 0x0068F5BD
		public const int BODY_COL_LEFT = 209; // Metadata: 0x0068F5BF
		public const int BODY_COL_RIGHT = 365; // Metadata: 0x0068F5C1
		public const float REF_FRAME_HEIGHT_UNITS = 420f; // Metadata: 0x0068F5C3
		public const float LAYER_TIMEOUT = 15f; // Metadata: 0x0068F5C7
		public const float CROSSFADE = 0.18f; // Metadata: 0x0068F5CB
		public const float POP = 0.22f; // Metadata: 0x0068F5CF
		public const float POP_SCALE = 1.05f; // Metadata: 0x0068F5D3
		public const float SCALE = 0.75f; // Metadata: 0x0068F5D7
		public const int BODY_HEIGHT_PX = 266; // Metadata: 0x0068F5DB
		public const float WORLD_PPU = 0.9142857f; // Metadata: 0x0068F5DD
		public const float UI_PPU = 100f; // Metadata: 0x0068F5E1
		public const float BODY_CENTER_BAKE_X = 215.25f; // Metadata: 0x0068F5E5
		public const float BODY_CENTER_BAKE_Y = 187.875f; // Metadata: 0x0068F5E9
		public const string SPEC_PREFIX = "1|"; // Metadata: 0x0068F5ED
		public const int MAX_PAIRS = 16; // Metadata: 0x0068F5F0
		public const long MAX_ICON_ID = 999999999; // Metadata: 0x0068F5F1
	
		// Methods
		public static bool IsLegacyAvatarIcon(long iconId); // 0x00000001807FD6E0-0x00000001807FD700
		public static bool IsLegacyAvatarPath(string resourcePath); // 0x00000001807FD700-0x00000001807FD770
	}
}
