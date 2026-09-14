/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class CanDauVanTileView : MonoBehaviour // TypeDefIndex: 436
{
	// Fields
	public const float TILE_W = 180f; // Metadata: 0x005EF3D9
	public const float TILE_H = 110f; // Metadata: 0x005EF3DD
	public const float ISLAND_BIG_W = 320f; // Metadata: 0x005EF3E1
	public const float ISLAND_BIG_H = 230f; // Metadata: 0x005EF3E5
	public const float ISLAND_SMALL_W = 300f; // Metadata: 0x005EF3E9
	public const float ISLAND_SMALL_H = 200f; // Metadata: 0x005EF3ED
	public const float ISLAND_DOWN = 20f; // Metadata: 0x005EF3F1
	public const float CLOUD_W = 180f; // Metadata: 0x005EF3F5
	public const float CLOUD_H = 110f; // Metadata: 0x005EF3F9
	public const float ICON = 72f; // Metadata: 0x005EF3FD
	public const float ICON_UP = 62f; // Metadata: 0x005EF401
	public const float MYSTERY = 84f; // Metadata: 0x005EF405
	public const float AMOUNT_W = 160f; // Metadata: 0x005EF409
	public const float AMOUNT_H = 32f; // Metadata: 0x005EF40D
	public const float AMOUNT_DOWN = 24f; // Metadata: 0x005EF411
	public const float AMOUNT_FONT = 28f; // Metadata: 0x005EF415
	public const float NAME_W = 260f; // Metadata: 0x005EF419
	public const float NAME_H = 30f; // Metadata: 0x005EF41D
	public const float NAME_FONT = 22f; // Metadata: 0x005EF421
	public const float NAME_GAP = 10f; // Metadata: 0x005EF425
	public const float GLOW_W = 220f; // Metadata: 0x005EF429
	public const float GLOW_H = 140f; // Metadata: 0x005EF42D
	private MonoBehaviour _host; // 0x20
	private CanDauVanTheme _theme; // 0x28
	private CanDauVanTile _tile; // 0x30
	private Image _island; // 0x38
	private Image _cloud; // 0x40
	private Image _icon; // 0x48
	private Image _glow; // 0x50
	private UnityEngine.UI.Text _amount; // 0x58
	private UnityEngine.UI.Text _name; // 0x60
	private Sprite _iconSprite; // 0x68
	[CompilerGenerated]
	private int _Idx_k__BackingField; // 0x70
	public const string SHARD_TYPE = "shard"; // Metadata: 0x005EF431

	// Properties
	public int Idx { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180356E10-0x0000000180356E20 0x0000000180356E20-0x0000000180356E30
	public CanDauVanTile Tile { get; } // 0x00000001802B4AE0-0x00000001802B4AF0 
	public RectTransform Rect { get; } // 0x0000000180356E30-0x0000000180356E90 
	public RectTransform IconRect { get; } // 0x0000000180356E90-0x0000000180356F90 
	public RectTransform AmountRect { get; } // 0x0000000180356F90-0x0000000180357090 
	public Image Glow { get; } // 0x00000001802D8C20-0x00000001802D8C30 
	public Sprite IconSprite { get; } // 0x0000000180345810-0x0000000180345820 
	public Vector3 IconWorld { get; } // 0x0000000180357090-0x0000000180357400 

	// Constructors
	public CanDauVanTileView(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static CanDauVanTileView Build(MonoBehaviour host, Transform parent, CanDauVanTile tile, CanDauVanTheme theme, Vector2 anchored); // 0x0000000180357400-0x0000000180357A30
	public void Bind(CanDauVanTile tile); // 0x0000000180357A30-0x0000000180358BA0
	public void ShowReward(RechargeEventReward reward, CanDauVanRandomShard shard = null); // 0x0000000180358BA0-0x0000000180359090
	public void ShowRandomShard(CanDauVanRandomShard shard); // 0x0000000180359090-0x00000001803593C0
	public void Restore(); // 0x00000001803593C0-0x00000001803593D0
	public void SetLit(bool on); // 0x00000001803593D0-0x0000000180359710
	public static RewardDisplayHelper.Entry FirstEntry(RechargeEventReward reward); // 0x0000000180359710-0x0000000180359720
	public static RewardDisplayHelper.Entry HeadlineEntry(RechargeEventReward reward, CanDauVanRandomShard shard); // 0x0000000180359720-0x0000000180359890
	private Image Centered(string name, float x, float y, float w, float h); // 0x0000000180359890-0x00000001803599B0
	private static void Center(RectTransform rt, float x, float y, float w, float h); // 0x00000001803599B0-0x0000000180359B30
}

