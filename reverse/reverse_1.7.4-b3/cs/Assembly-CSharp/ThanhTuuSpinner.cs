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
public sealed class ThanhTuuSpinner : MonoBehaviour // TypeDefIndex: 1306
{
	// Fields
	public const float SIZE = 150f; // Metadata: 0x005EF8BD
	public const float TEXT_W = 460f; // Metadata: 0x005EF8C1
	public const float TEXT_H = 50f; // Metadata: 0x005EF8C5
	public const float TEXT_GAP = 4f; // Metadata: 0x005EF8C9
	public const float FONT = 34f; // Metadata: 0x005EF8CD
	public const float BLOCK_BLEED = 4000f; // Metadata: 0x005EF8D1
	private MonoBehaviour _host; // 0x20
	private RectTransform _root; // 0x28
	private RectTransform _ring; // 0x30
	private Image _ringImg; // 0x38
	private Image _block; // 0x40
	private UnityEngine.UI.Text _txt; // 0x48
	private string _base; // 0x50
	private int _dots; // 0x58
	private int _spinId; // 0x5C
	private int _dotsId; // 0x60
	private float _shownAt; // 0x64

	// Properties
	public bool IsShowing { get; } // 0x000000018073FF80-0x00000001807400E0 
	public float ShownFor { get; } // 0x00000001807400E0-0x0000000180740150 
	public bool IsBlocking { get; } // 0x00000001807410E0-0x0000000180741240 

	// Constructors
	public ThanhTuuSpinner(); // 0x00000001807415E0-0x00000001807416C0

	// Methods
	public static ThanhTuuSpinner Build(MonoBehaviour host, RectTransform parent, float cx, float cy); // 0x0000000180740150-0x0000000180740900
	public void Rebind(); // 0x0000000180740900-0x0000000180740A60
	public void Show(string waiting); // 0x0000000180740A60-0x0000000180740DA0
	public void Hide(); // 0x0000000180740DA0-0x00000001807410E0
	public void SetBlocking(bool on); // 0x0000000180741240-0x0000000180741420
	private void SetDots(int n); // 0x0000000180741420-0x0000000180741580
	private void OnDisable(); // 0x0000000180741580-0x00000001807415E0
	[CompilerGenerated]
	private void _Show_b__23_0(float k); // 0x00000001807416C0-0x00000001807416E0
}

