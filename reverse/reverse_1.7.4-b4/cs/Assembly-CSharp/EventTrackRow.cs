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
public class EventTrackRow : MonoBehaviour // TypeDefIndex: 647
{
	// Fields
	public const float ROW_W = 860f; // Metadata: 0x005EF946
	public const float ROW_H = 108f; // Metadata: 0x005EF94A
	private const float CHEST_X = 12f; // Metadata: 0x005EF94E
	private const float CHEST_Y = 12f; // Metadata: 0x005EF952
	private const float CHEST = 84f; // Metadata: 0x005EF956
	private const float NEED_X = 108f; // Metadata: 0x005EF95A
	private const float NEED_Y = 10f; // Metadata: 0x005EF95E
	private const float NEED_W = 220f; // Metadata: 0x005EF962
	private const float NEED_H = 34f; // Metadata: 0x005EF966
	private const float BAR_X = 108f; // Metadata: 0x005EF96A
	private const float BAR_Y = 52f; // Metadata: 0x005EF96E
	private const float BAR_W = 220f; // Metadata: 0x005EF972
	private const float BAR_H = 18f; // Metadata: 0x005EF976
	private const float RW_X = 340f; // Metadata: 0x005EF97A
	private const float RW_Y = 12f; // Metadata: 0x005EF97E
	private const float RW_W = 380f; // Metadata: 0x005EF982
	private const float RW_H = 84f; // Metadata: 0x005EF986
	private const float BTN_X = 740f; // Metadata: 0x005EF98A
	private const float BTN_Y = 26f; // Metadata: 0x005EF98E
	private const float BTN_W = 110f; // Metadata: 0x005EF992
	private const float BTN_H = 56f; // Metadata: 0x005EF996
	private const float CELL = 64f; // Metadata: 0x005EF99A
	private const float CELL_GAP = 8f; // Metadata: 0x005EF99E
	private const int CELL_MAX = 5; // Metadata: 0x005EF9A2
	private const int CELL_WHEN_MORE = 4; // Metadata: 0x005EF9A3
	private MonoBehaviour _host; // 0x20
	private RectTransform _root; // 0x28
	private Image _bg; // 0x30
	private Image _chest; // 0x38
	private Image _tick; // 0x40
	private UnityEngine.UI.Text _need; // 0x48
	private Image _barFill; // 0x50
	private RectTransform _rewards; // 0x58
	private UnityEngine.UI.Text _more; // 0x60
	private Button _btnClaim; // 0x68
	private Image _btnImg; // 0x70
	private UnityEngine.UI.Text _lblClaim; // 0x78
	private long _milestoneId; // 0x80
	private string _status; // 0x88
	private bool _busy; // 0x90
	private Action<long> _onClaim; // 0x98
	private bool _plateSkinned; // 0xA0
	private bool _btnSkinned; // 0xA1

	// Properties
	public long MilestoneId { get; } // 0x00000001802D8C90-0x00000001802D8CA0 
	public RectTransform ClaimRect { get; } // 0x00000001804503B0-0x00000001804504F0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass52_0 // TypeDefIndex: 648
	{
		// Fields
		public string captured; // 0x10

		// Constructors
		public __c__DisplayClass52_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RenderRewards_b__0(); // 0x0000000180453DF0-0x0000000180453E60
	}

	// Constructors
	public EventTrackRow(); // 0x0000000180453D20-0x0000000180453DF0

	// Methods
	public static EventTrackRow Create(Transform parent, MonoBehaviour host); // 0x00000001804504F0-0x00000001804506A0
	private void Build(); // 0x00000001804506A0-0x0000000180451590
	public void Bind(EventTrackMilestone m, EventTrackState s, bool busy, Action<long> onClaim); // 0x0000000180451590-0x0000000180451F10
	public void SetBusy(bool busy); // 0x0000000180451F10-0x0000000180452050
	private void ShowTick(bool claimed, Color accent); // 0x0000000180452050-0x00000001804524D0
	private void RenderRewards(EventTrackMilestone m); // 0x00000001804524D0-0x0000000180452E90
	private static string NameOf(RewardDisplayHelper.Entry e, string fallbackDesc); // 0x0000000180452E90-0x0000000180452FB0
	private void SkinFromEvent(object theme); // 0x0000000180452FB0-0x0000000180453530
	private void RenderButton(EventTrackState s, long required, long total, bool claimed, bool canClaim, Color accent); // 0x0000000180453530-0x0000000180453B20
	private void OnTapClaim(); // 0x0000000180453B20-0x0000000180453B60
	public void Recycle(); // 0x0000000180453B60-0x0000000180453D20
}

