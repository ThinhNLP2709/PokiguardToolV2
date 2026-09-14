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
public class CanDauVanGiftPopup : MonoBehaviour // TypeDefIndex: 408
{
	// Fields
	public const float W = 900f; // Metadata: 0x005EF1B6
	public const float H = 560f; // Metadata: 0x005EF1BA
	public const float TITLE_UP = 56f; // Metadata: 0x005EF1BE
	public const float TITLE_H = 52f; // Metadata: 0x005EF1C2
	public const float TITLE_FONT = 40f; // Metadata: 0x005EF1C6
	public const float TITLE_IN_Y = 18f; // Metadata: 0x005EF1CA
	public const float RAYS = 700f; // Metadata: 0x005EF1CE
	public const float ICON = 220f; // Metadata: 0x005EF1D2
	public const float ICON_Y = 250f; // Metadata: 0x005EF1D6
	public const float NAME_Y = 384f; // Metadata: 0x005EF1DA
	public const float NAME_H = 40f; // Metadata: 0x005EF1DE
	public const float NAME_FONT = 30f; // Metadata: 0x005EF1E2
	public const float QTY_Y = 428f; // Metadata: 0x005EF1E6
	public const float QTY_H = 36f; // Metadata: 0x005EF1EA
	public const float QTY_FONT = 26f; // Metadata: 0x005EF1EE
	public const float CLOSE = 64f; // Metadata: 0x005EF1F2
	public const float CLOSE_PAD = 14f; // Metadata: 0x005EF1F6
	public const float CLOSE_HIT = 96f; // Metadata: 0x005EF1FA
	public const float AUTO_CLOSE = 2.2f; // Metadata: 0x005EF1FE
	private MonoBehaviour _host; // 0x20
	private CanDauVanTheme _theme; // 0x28
	private RectTransform _root; // 0x30
	private Image _dim; // 0x38
	private Image _frame; // 0x40
	private Image _rays; // 0x48
	private Image _icon; // 0x50
	private Image _piece; // 0x58
	private UnityEngine.UI.Text _title; // 0x60
	private UnityEngine.UI.Text _name; // 0x68
	private UnityEngine.UI.Text _qty; // 0x70
	private Action _onClosed; // 0x78
	private RechargeEventReward _reward; // 0x80
	private int _autoId; // 0x88
	private bool _closing; // 0x8C

	// Properties
	public bool IsOpen { get; } // 0x0000000180338730-0x0000000180338890 

	// Constructors
	public CanDauVanGiftPopup(); // 0x000000018033B990-0x000000018033B9E0

	// Methods
	public static CanDauVanGiftPopup Build(MonoBehaviour host, Transform parent, CanDauVanTheme theme); // 0x0000000180338890-0x0000000180338C90
	private void BuildBody(); // 0x0000000180338C90-0x0000000180339970
	private void Place(RectTransform rt, float yTop, float size); // 0x0000000180339970-0x0000000180339A30
	public void Show(RechargeEventReward reward, string title, Action onClosed, CanDauVanRandomShard shard = null); // 0x0000000180339A30-0x000000018033A890
	private void ApplyPiece(bool on); // 0x000000018033A890-0x000000018033AD30
	public void Close(); // 0x000000018033AD30-0x000000018033AF00
	public void HideImmediate(); // 0x000000018033AF00-0x000000018033B3B0
	private void FinishClose(bool silentReveal); // 0x000000018033B3B0-0x000000018033B830
	public static void RevealEquips(RechargeEventReward reward); // 0x000000018033B830-0x000000018033B990
	[CompilerGenerated]
	private void _Close_b__41_0(); // 0x000000018033B9E0-0x000000018033B9F0
}

