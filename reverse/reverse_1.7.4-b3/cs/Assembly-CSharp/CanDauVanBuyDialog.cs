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
public class CanDauVanBuyDialog : MonoBehaviour // TypeDefIndex: 388
{
	// Fields
	public const float W = 760f; // Metadata: 0x005EDD5C
	public const float H = 440f; // Metadata: 0x005EDD60
	public const float TITLE_Y = 22f; // Metadata: 0x005EDD64
	public const float TITLE_H = 52f; // Metadata: 0x005EDD68
	public const float TITLE_FONT = 36f; // Metadata: 0x005EDD6C
	public const float BODY_X = 40f; // Metadata: 0x005EDD70
	public const float BODY_Y = 88f; // Metadata: 0x005EDD74
	public const float BODY_W = 680f; // Metadata: 0x005EDD78
	public const float BODY_H = 72f; // Metadata: 0x005EDD7C
	public const float BODY_FONT = 24f; // Metadata: 0x005EDD80
	public const float STEP_Y = 180f; // Metadata: 0x005EDD84
	public const float STEP_H = 80f; // Metadata: 0x005EDD88
	public const float MINUS_X = 190f; // Metadata: 0x005EDD8C
	public const float PLUS_X = 474f; // Metadata: 0x005EDD90
	public const float STEP_BTN_W = 96f; // Metadata: 0x005EDD94
	public const float QTY_X = 300f; // Metadata: 0x005EDD98
	public const float QTY_W = 160f; // Metadata: 0x005EDD9C
	public const float QTY_FONT = 44f; // Metadata: 0x005EDDA0
	public const float COST_Y = 278f; // Metadata: 0x005EDDA4
	public const float COST_H = 48f; // Metadata: 0x005EDDA8
	public const float COST_FONT = 30f; // Metadata: 0x005EDDAC
	public const float SAFIA_X = 246f; // Metadata: 0x005EDDB0
	public const float SAFIA = 48f; // Metadata: 0x005EDDB4
	public const float COST_X = 304f; // Metadata: 0x005EDDB8
	public const float COST_W = 300f; // Metadata: 0x005EDDBC
	public const float BTN_Y = 350f; // Metadata: 0x005EDDC0
	public const float BTN_W = 230f; // Metadata: 0x005EDDC4
	public const float BTN_H = 64f; // Metadata: 0x005EDDC8
	public const float BTN_FONT = 26f; // Metadata: 0x005EDDCC
	public const float CANCEL_X = 120f; // Metadata: 0x005EDDD0
	public const float OK_X = 410f; // Metadata: 0x005EDDD4
	public const string LABEL_OK = "MUA"; // Metadata: 0x005EDDD8
	public const string LABEL_CANCEL = "HU\u1EF6"; // Metadata: 0x005EDDDC
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
	public bool IsOpen { get; } // 0x00000001803297C0-0x0000000180329920 
	public int Qty { get; } // 0x0000000180329920-0x0000000180329930 

	// Constructors
	public CanDauVanBuyDialog(); // 0x000000018032B7B0-0x000000018032B810

	// Methods
	public static CanDauVanBuyDialog Build(MonoBehaviour host, Transform parent); // 0x0000000180329930-0x0000000180329D00
	private void BuildBody(); // 0x0000000180329D00-0x000000018032AAE0
	public void Show(CanDauVanState s, Action<int> onBuy); // 0x000000018032AAE0-0x000000018032B1D0
	public void Hide(); // 0x000000018032B1D0-0x000000018032B550
	public void SetBusy(bool busy); // 0x000000018032B550-0x000000018032B560
	private void Step(int d); // 0x000000018032B560-0x000000018032B5A0
	private void RenderQty(); // 0x000000018032B5A0-0x000000018032B6E0
	private void OnOk(); // 0x000000018032B6E0-0x000000018032B7B0
	[CompilerGenerated]
	private void _BuildBody_b__54_0(); // 0x000000018032B810-0x000000018032B850
	[CompilerGenerated]
	private void _BuildBody_b__54_1(); // 0x000000018032B850-0x000000018032B890
}

