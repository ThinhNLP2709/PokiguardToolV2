/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class SkillCardBadge : MonoBehaviour // TypeDefIndex: 892
{
	// Fields
	public const string CFG_KEY = "evocard"; // Metadata: 0x0068BEC3
	public const string ICON_NODE = "imgCard"; // Metadata: 0x0068BECB
	private const float PULSE_PERIOD = 1.6f; // Metadata: 0x0068BED3
	private RectTransform _rt; // 0x20
	private Button _btn; // 0x28
	private Image _imgCard; // 0x30
	private long _cardId; // 0x38
	private string _title; // 0x40
	private string _body; // 0x48
	private Sprite _icon; // 0x50
	private bool _pulsing; // 0x58
	private bool _wired; // 0x59
	private static SkillCardBadge _showing; // 0x00

	// Properties
	public bool HasCard { get; } // 0x00000001804C6620-0x00000001804C6680 

	// Constructors
	public SkillCardBadge(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	public static SkillCardBadge Ensure(Transform parent, string nodeName, Vector2 defaultPos, Vector2 defaultSize, string cfgKeyPrefix); // 0x00000001804C5660-0x00000001804C5910
	private void Build(bool created, Vector2 defaultPos, Vector2 defaultSize, string cfgKeyPrefix); // 0x00000001804C4CF0-0x00000001804C54B0
	private void ApplyRect(Vector2 pos, Vector2 size); // 0x00000001804C42C0-0x00000001804C4420
	private void ApplyRemoteRect(string cfgKeyPrefix); // 0x00000001804C4420-0x00000001804C45B0
	private static bool TryGetVector2(string prop, out Vector2 v); // 0x00000001804C6390-0x00000001804C6560
	private static Transform FindDeepByName(Transform root, string nodeName); // 0x00000001804C5910-0x00000001804C5A40
	public void Bind(long cardId, string cardName, string desc, int mana, int power); // 0x00000001804C45B0-0x00000001804C4CF0
	public static string CostLine(int mana, int power); // 0x00000001804C54B0-0x00000001804C5660
	public void ShowTooltip(); // 0x00000001804C5ED0-0x00000001804C6090
	public void ShowFx(); // 0x00000001804C5CF0-0x00000001804C5ED0
	public void StartPulse(); // 0x00000001804C6090-0x00000001804C6280
	public void StopFx(); // 0x00000001804C6280-0x00000001804C6390
	private void PlayPunch(); // 0x00000001804C5AF0-0x00000001804C5CF0
	private void OnDisable(); // 0x00000001804C5A40-0x00000001804C5AF0
	[CompilerGenerated]
	private void _PlayPunch_b__27_0(); // 0x00000001804C6560-0x00000001804C6620
}

