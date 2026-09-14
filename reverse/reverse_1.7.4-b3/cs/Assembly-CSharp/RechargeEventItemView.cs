/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class RechargeEventItemView : MonoBehaviour // TypeDefIndex: 1173
{
	// Fields
	[Header("\u00D4 ch\u1EEF")]
	public UnityEngine.UI.Text txtTitle; // 0x20
	public UnityEngine.UI.Text txtProgress; // 0x28
	[Header("Hai n\u00FAt \u0111\u1ED5i vai (ch\u1EC9 M\u1ED8T n\u00FAt b\u1EADt c\u00F9ng l\u00FAc)")]
	public Button btnReceive; // 0x30
	public Button btnRecharge; // 0x38
	[Header("Khay qu\u00E0 (HorizontalLayoutGroup scale 0,8 c\u1EE7a bundle)")]
	public RectTransform giftContainer; // 0x40
	private const float GIFT_CELL = 100f; // Metadata: 0x005EF526
	private long _milestoneId; // 0x48
	private Action<long> _onClaim; // 0x50
	private Action _onRecharge; // 0x58

	// Properties
	public long MilestoneId { get; } // 0x00000001802D8B80-0x00000001802D8B90 

	// Constructors
	public RechargeEventItemView(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void Bind(long milestoneId, string title, string progress, RechargeMilestoneStatus status, RechargeEventReward reward, bool busy, Action<long> onClaim, Action onRecharge); // 0x00000001806C0020-0x00000001806C03E0
	public void SetBusy(bool busy, RechargeMilestoneStatus status); // 0x00000001806C03E0-0x00000001806C0400
	private void RenderButtons(RechargeMilestoneStatus status, bool busy); // 0x00000001806C0400-0x00000001806C0810
	private void RenderRewards(RechargeEventReward reward); // 0x00000001806C0810-0x00000001806C0950
	private void OnClickReceive(); // 0x00000001806C0950-0x00000001806C0980
	private void OnClickRecharge(); // 0x00000001806C0980-0x00000001806C09A0
	private static void SetLabel(Button b, string text); // 0x00000001806C09A0-0x00000001806C0B50
	private static void Wire(Button b, UnityAction action); // 0x00000001806C0B50-0x00000001806C0CE0
}

