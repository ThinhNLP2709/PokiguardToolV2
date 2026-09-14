/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class CanDauVanTileView : MonoBehaviour // TypeDefIndex: 436
{
	// Fields
	public const float TILE_W = 180f; // Metadata: 0x005EE009
	public const float TILE_H = 110f; // Metadata: 0x005EE00D
	public const float ISLAND_BIG_W = 320f; // Metadata: 0x005EE011
	public const float ISLAND_BIG_H = 230f; // Metadata: 0x005EE015
	public const float ISLAND_SMALL_W = 300f; // Metadata: 0x005EE019
	public const float ISLAND_SMALL_H = 200f; // Metadata: 0x005EE01D
	public const float ISLAND_DOWN = 20f; // Metadata: 0x005EE021
	public const float CLOUD_W = 180f; // Metadata: 0x005EE025
	public const float CLOUD_H = 110f; // Metadata: 0x005EE029
	public const float ICON = 72f; // Metadata: 0x005EE02D
	public const float ICON_UP = 62f; // Metadata: 0x005EE031
	public const float MYSTERY = 84f; // Metadata: 0x005EE035
	public const float AMOUNT_W = 160f; // Metadata: 0x005EE039
	public const float AMOUNT_H = 32f; // Metadata: 0x005EE03D
	public const float AMOUNT_DOWN = 24f; // Metadata: 0x005EE041
	public const float AMOUNT_FONT = 28f; // Metadata: 0x005EE045
	public const float NAME_W = 260f; // Metadata: 0x005EE049
	public const float NAME_H = 30f; // Metadata: 0x005EE04D
	public const float NAME_FONT = 22f; // Metadata: 0x005EE051
	public const float NAME_GAP = 10f; // Metadata: 0x005EE055
	public const float GLOW_W = 220f; // Metadata: 0x005EE059
	public const float GLOW_H = 140f; // Metadata: 0x005EE05D
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
	public const string SHARD_TYPE = "shard"; // Metadata: 0x005EE061

	// Properties
	public int Idx { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180356C00-0x0000000180356C10 0x0000000180356C10-0x0000000180356C20
	public CanDauVanTile Tile { get; } // 0x00000001802B4AE0-0x00000001802B4AF0 
	public RectTransform Rect { get; } // 0x0000000180356C20-0x0000000180356C80 
	public RectTransform IconRect { get; } // 0x0000000180356C80-0x0000000180356D80 
	public RectTransform AmountRect { get; } // 0x0000000180356D80-0x0000000180356E80 
	public Image Glow { get; } // 0x00000001802D8BF0-0x00000001802D8C00 
	public Sprite IconSprite { get; } // 0x00000001803456F0-0x0000000180345700 
	public Vector3 IconWorld { get; } // 0x0000000180356E80-0x00000001803571F0 

	// Constructors
	public CanDauVanTileView(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static CanDauVanTileView Build(MonoBehaviour host, Transform parent, CanDauVanTile tile, CanDauVanTheme theme, Vector2 anchored); // 0x00000001803571F0-0x0000000180357820
	public void Bind(CanDauVanTile tile); // 0x0000000180357820-0x0000000180358990
	public void ShowReward(RechargeEventReward reward, CanDauVanRandomShard shard = null); // 0x0000000180358990-0x0000000180358E80
	public void ShowRandomShard(CanDauVanRandomShard shard); // 0x0000000180358E80-0x00000001803591B0
	public void Restore(); // 0x00000001803591B0-0x00000001803591C0
	public void SetLit(bool on); // 0x00000001803591C0-0x0000000180359500
	public static RewardDisplayHelper.Entry FirstEntry(RechargeEventReward reward); // 0x0000000180359500-0x0000000180359510
	public static RewardDisplayHelper.Entry HeadlineEntry(RechargeEventReward reward, CanDauVanRandomShard shard); // 0x0000000180359510-0x0000000180359680
	private Image Centered(string name, float x, float y, float w, float h); // 0x0000000180359680-0x00000001803597A0
	private static void Center(RectTransform rt, float x, float y, float w, float h); // 0x00000001803597A0-0x0000000180359920
}

