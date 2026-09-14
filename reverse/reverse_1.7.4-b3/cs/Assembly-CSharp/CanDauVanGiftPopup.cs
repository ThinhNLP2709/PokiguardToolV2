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
public class CanDauVanGiftPopup : MonoBehaviour // TypeDefIndex: 408
{
	// Fields
	public const float W = 900f; // Metadata: 0x005EDDE6
	public const float H = 560f; // Metadata: 0x005EDDEA
	public const float TITLE_UP = 56f; // Metadata: 0x005EDDEE
	public const float TITLE_H = 52f; // Metadata: 0x005EDDF2
	public const float TITLE_FONT = 40f; // Metadata: 0x005EDDF6
	public const float TITLE_IN_Y = 18f; // Metadata: 0x005EDDFA
	public const float RAYS = 700f; // Metadata: 0x005EDDFE
	public const float ICON = 220f; // Metadata: 0x005EDE02
	public const float ICON_Y = 250f; // Metadata: 0x005EDE06
	public const float NAME_Y = 384f; // Metadata: 0x005EDE0A
	public const float NAME_H = 40f; // Metadata: 0x005EDE0E
	public const float NAME_FONT = 30f; // Metadata: 0x005EDE12
	public const float QTY_Y = 428f; // Metadata: 0x005EDE16
	public const float QTY_H = 36f; // Metadata: 0x005EDE1A
	public const float QTY_FONT = 26f; // Metadata: 0x005EDE1E
	public const float CLOSE = 64f; // Metadata: 0x005EDE22
	public const float CLOSE_PAD = 14f; // Metadata: 0x005EDE26
	public const float CLOSE_HIT = 96f; // Metadata: 0x005EDE2A
	public const float AUTO_CLOSE = 2.2f; // Metadata: 0x005EDE2E
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
	public bool IsOpen { get; } // 0x0000000180338610-0x0000000180338770 

	// Constructors
	public CanDauVanGiftPopup(); // 0x000000018033B870-0x000000018033B8C0

	// Methods
	public static CanDauVanGiftPopup Build(MonoBehaviour host, Transform parent, CanDauVanTheme theme); // 0x0000000180338770-0x0000000180338B70
	private void BuildBody(); // 0x0000000180338B70-0x0000000180339850
	private void Place(RectTransform rt, float yTop, float size); // 0x0000000180339850-0x0000000180339910
	public void Show(RechargeEventReward reward, string title, Action onClosed, CanDauVanRandomShard shard = null); // 0x0000000180339910-0x000000018033A770
	private void ApplyPiece(bool on); // 0x000000018033A770-0x000000018033AC10
	public void Close(); // 0x000000018033AC10-0x000000018033ADE0
	public void HideImmediate(); // 0x000000018033ADE0-0x000000018033B290
	private void FinishClose(bool silentReveal); // 0x000000018033B290-0x000000018033B710
	public static void RevealEquips(RechargeEventReward reward); // 0x000000018033B710-0x000000018033B870
	[CompilerGenerated]
	private void _Close_b__41_0(); // 0x000000018033B8C0-0x000000018033B8D0
}

