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
public class SkillCardBadge : MonoBehaviour // TypeDefIndex: 1148
{
	// Fields
	public const string CFG_KEY = "evocard"; // Metadata: 0x005EF4DC
	public const string ICON_NODE = "imgCard"; // Metadata: 0x005EF4E4
	private const float PULSE_PERIOD = 1.6f; // Metadata: 0x005EF4EC
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
	public bool HasCard { get; } // 0x00000001806A3730-0x00000001806A3820 

	// Constructors
	public SkillCardBadge(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public static SkillCardBadge Ensure(Transform parent, string nodeName, Vector2 defaultPos, Vector2 defaultSize, string cfgKeyPrefix); // 0x00000001806A3820-0x00000001806A3D80
	private void Build(bool created, Vector2 defaultPos, Vector2 defaultSize, string cfgKeyPrefix); // 0x00000001806A3D80-0x00000001806A49D0
	private void ApplyRect(Vector2 pos, Vector2 size); // 0x00000001806A49D0-0x00000001806A4C10
	private void ApplyRemoteRect(string cfgKeyPrefix); // 0x00000001806A4C10-0x00000001806A4E30
	private static bool TryGetVector2(string prop, out Vector2 v); // 0x00000001806A4E30-0x00000001806A50C0
	private static Transform FindDeepByName(Transform root, string nodeName); // 0x00000001806A50C0-0x00000001806A5350
	public void Bind(long cardId, string cardName, string desc, int mana, int power); // 0x00000001806A5350-0x00000001806A5D70
	public static string CostLine(int mana, int power); // 0x00000001806A5D70-0x00000001806A5FC0
	public void ShowTooltip(); // 0x00000001806A5FC0-0x00000001806A62E0
	public void ShowFx(); // 0x00000001806A62E0-0x00000001806A65F0
	public void StartPulse(); // 0x00000001806A65F0-0x00000001806A6910
	public void StopFx(); // 0x00000001806A6910-0x00000001806A6B40
	private void PlayPunch(); // 0x00000001806A6B40-0x00000001806A6E60
	private void OnDisable(); // 0x00000001806A6E60-0x00000001806A7030
	[CompilerGenerated]
	private void _PlayPunch_b__27_0(); // 0x00000001806A7030-0x00000001806A71C0
}

