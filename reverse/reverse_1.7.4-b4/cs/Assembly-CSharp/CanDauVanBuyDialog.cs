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
public class CanDauVanBuyDialog : MonoBehaviour // TypeDefIndex: 388
{
	// Fields
	public const float W = 760f; // Metadata: 0x005EF12C
	public const float H = 440f; // Metadata: 0x005EF130
	public const float TITLE_Y = 22f; // Metadata: 0x005EF134
	public const float TITLE_H = 52f; // Metadata: 0x005EF138
	public const float TITLE_FONT = 36f; // Metadata: 0x005EF13C
	public const float BODY_X = 40f; // Metadata: 0x005EF140
	public const float BODY_Y = 88f; // Metadata: 0x005EF144
	public const float BODY_W = 680f; // Metadata: 0x005EF148
	public const float BODY_H = 72f; // Metadata: 0x005EF14C
	public const float BODY_FONT = 24f; // Metadata: 0x005EF150
	public const float STEP_Y = 180f; // Metadata: 0x005EF154
	public const float STEP_H = 80f; // Metadata: 0x005EF158
	public const float MINUS_X = 190f; // Metadata: 0x005EF15C
	public const float PLUS_X = 474f; // Metadata: 0x005EF160
	public const float STEP_BTN_W = 96f; // Metadata: 0x005EF164
	public const float QTY_X = 300f; // Metadata: 0x005EF168
	public const float QTY_W = 160f; // Metadata: 0x005EF16C
	public const float QTY_FONT = 44f; // Metadata: 0x005EF170
	public const float COST_Y = 278f; // Metadata: 0x005EF174
	public const float COST_H = 48f; // Metadata: 0x005EF178
	public const float COST_FONT = 30f; // Metadata: 0x005EF17C
	public const float SAFIA_X = 246f; // Metadata: 0x005EF180
	public const float SAFIA = 48f; // Metadata: 0x005EF184
	public const float COST_X = 304f; // Metadata: 0x005EF188
	public const float COST_W = 300f; // Metadata: 0x005EF18C
	public const float BTN_Y = 350f; // Metadata: 0x005EF190
	public const float BTN_W = 230f; // Metadata: 0x005EF194
	public const float BTN_H = 64f; // Metadata: 0x005EF198
	public const float BTN_FONT = 26f; // Metadata: 0x005EF19C
	public const float CANCEL_X = 120f; // Metadata: 0x005EF1A0
	public const float OK_X = 410f; // Metadata: 0x005EF1A4
	public const string LABEL_OK = "MUA"; // Metadata: 0x005EF1A8
	public const string LABEL_CANCEL = "HU\u1EF6"; // Metadata: 0x005EF1AC
	private MonoBehaviour _host; // 0x20
	private RectTransform _root; // 0x28
	private Image _dim; // 0x30
	private UnityEngine.UI.Text _title; // 0x38
	private UnityEngine.UI.Text _body; // 0x40
	private UnityEngine.UI.Text _qtyText; // 0x48
	private UnityEngine.UI.Text _cost; // 0x50
	private Button _minus; // 0x58
	private Button _plus; // 0x60
	private Button _ok; // 0x68
	private Button _cancel; // 0x70
	private int _qty; // 0x78
	private int _max; // 0x7C
	private int _price; // 0x80
	private Action<int> _onBuy; // 0x88
	private bool _busy; // 0x90

	// Properties
	public bool IsOpen { get; } // 0x00000001803298E0-0x0000000180329A40 
	public int Qty { get; } // 0x0000000180329A40-0x0000000180329A50 

	// Constructors
	public CanDauVanBuyDialog(); // 0x000000018032B8D0-0x000000018032B930

	// Methods
	public static CanDauVanBuyDialog Build(MonoBehaviour host, Transform parent); // 0x0000000180329A50-0x0000000180329E20
	private void BuildBody(); // 0x0000000180329E20-0x000000018032AC00
	public void Show(CanDauVanState s, Action<int> onBuy); // 0x000000018032AC00-0x000000018032B2F0
	public void Hide(); // 0x000000018032B2F0-0x000000018032B670
	public void SetBusy(bool busy); // 0x000000018032B670-0x000000018032B680
	private void Step(int d); // 0x000000018032B680-0x000000018032B6C0
	private void RenderQty(); // 0x000000018032B6C0-0x000000018032B800
	private void OnOk(); // 0x000000018032B800-0x000000018032B8D0
	[CompilerGenerated]
	private void _BuildBody_b__54_0(); // 0x000000018032B930-0x000000018032B970
	[CompilerGenerated]
	private void _BuildBody_b__54_1(); // 0x000000018032B970-0x000000018032B9B0
}

