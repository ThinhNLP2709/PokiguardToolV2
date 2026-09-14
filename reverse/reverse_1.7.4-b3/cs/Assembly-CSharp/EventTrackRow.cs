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
public class EventTrackRow : MonoBehaviour // TypeDefIndex: 646
{
	// Fields
	public const float ROW_W = 860f; // Metadata: 0x005EE575
	public const float ROW_H = 108f; // Metadata: 0x005EE579
	private const float CHEST_X = 12f; // Metadata: 0x005EE57D
	private const float CHEST_Y = 12f; // Metadata: 0x005EE581
	private const float CHEST = 84f; // Metadata: 0x005EE585
	private const float NEED_X = 108f; // Metadata: 0x005EE589
	private const float NEED_Y = 10f; // Metadata: 0x005EE58D
	private const float NEED_W = 220f; // Metadata: 0x005EE591
	private const float NEED_H = 34f; // Metadata: 0x005EE595
	private const float BAR_X = 108f; // Metadata: 0x005EE599
	private const float BAR_Y = 52f; // Metadata: 0x005EE59D
	private const float BAR_W = 220f; // Metadata: 0x005EE5A1
	private const float BAR_H = 18f; // Metadata: 0x005EE5A5
	private const float RW_X = 340f; // Metadata: 0x005EE5A9
	private const float RW_Y = 12f; // Metadata: 0x005EE5AD
	private const float RW_W = 380f; // Metadata: 0x005EE5B1
	private const float RW_H = 84f; // Metadata: 0x005EE5B5
	private const float BTN_X = 740f; // Metadata: 0x005EE5B9
	private const float BTN_Y = 26f; // Metadata: 0x005EE5BD
	private const float BTN_W = 110f; // Metadata: 0x005EE5C1
	private const float BTN_H = 56f; // Metadata: 0x005EE5C5
	private const float CELL = 64f; // Metadata: 0x005EE5C9
	private const float CELL_GAP = 8f; // Metadata: 0x005EE5CD
	private const int CELL_MAX = 5; // Metadata: 0x005EE5D1
	private const int CELL_WHEN_MORE = 4; // Metadata: 0x005EE5D2
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
	public long MilestoneId { get; } // 0x00000001802D8C60-0x00000001802D8C70 
	public RectTransform ClaimRect { get; } // 0x000000018044F230-0x000000018044F370 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass52_0 // TypeDefIndex: 647
	{
		// Fields
		public string captured; // 0x10

		// Constructors
		public __c__DisplayClass52_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _RenderRewards_b__0(); // 0x0000000180452C70-0x0000000180452CE0
	}

	// Constructors
	public EventTrackRow(); // 0x0000000180452BA0-0x0000000180452C70

	// Methods
	public static EventTrackRow Create(Transform parent, MonoBehaviour host); // 0x000000018044F370-0x000000018044F520
	private void Build(); // 0x000000018044F520-0x0000000180450410
	public void Bind(EventTrackMilestone m, EventTrackState s, bool busy, Action<long> onClaim); // 0x0000000180450410-0x0000000180450D90
	public void SetBusy(bool busy); // 0x0000000180450D90-0x0000000180450ED0
	private void ShowTick(bool claimed, Color accent); // 0x0000000180450ED0-0x0000000180451350
	private void RenderRewards(EventTrackMilestone m); // 0x0000000180451350-0x0000000180451D10
	private static string NameOf(RewardDisplayHelper.Entry e, string fallbackDesc); // 0x0000000180451D10-0x0000000180451E30
	private void SkinFromEvent(object theme); // 0x0000000180451E30-0x00000001804523B0
	private void RenderButton(EventTrackState s, long required, long total, bool claimed, bool canClaim, Color accent); // 0x00000001804523B0-0x00000001804529A0
	private void OnTapClaim(); // 0x00000001804529A0-0x00000001804529E0
	public void Recycle(); // 0x00000001804529E0-0x0000000180452BA0
}

