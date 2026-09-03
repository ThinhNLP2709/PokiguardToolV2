/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class RechargeEventItemView : MonoBehaviour // TypeDefIndex: 724
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
	private const float GIFT_CELL = 100f; // Metadata: 0x0064C87A
	private long _milestoneId; // 0x48
	private Action<long> _onClaim; // 0x50
	private Action _onRecharge; // 0x58

	// Properties
	public long MilestoneId { get; } // 0x00000001803272B0-0x00000001803272C0 

	// Constructors
	public RechargeEventItemView(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public void Bind(long milestoneId, string title, string progress, RechargeMilestoneStatus status, RechargeEventReward reward, bool busy, Action<long> onClaim, Action onRecharge); // 0x00000001803E7E40-0x00000001803E7FF0
	public void SetBusy(bool busy, RechargeMilestoneStatus status); // 0x00000001803E8300-0x00000001803E8320
	private void RenderButtons(RechargeMilestoneStatus status, bool busy); // 0x00000001803E8040-0x00000001803E8270
	private void RenderRewards(RechargeEventReward reward); // 0x00000001803E8270-0x00000001803E8300
	private void OnClickReceive(); // 0x00000001803E7FF0-0x00000001803E8020
	private void OnClickRecharge(); // 0x00000001803E8020-0x00000001803E8040
	private static void SetLabel(Button b, string text); // 0x00000001803E8320-0x00000001803E83E0
	private static void Wire(Button b, UnityAction action); // 0x00000001803E83E0-0x00000001803E84B0
}

