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
public sealed class ThanhTuuSpinner : MonoBehaviour // TypeDefIndex: 1308
{
	// Fields
	public const float SIZE = 150f; // Metadata: 0x005F0C8A
	public const float TEXT_W = 460f; // Metadata: 0x005F0C8E
	public const float TEXT_H = 50f; // Metadata: 0x005F0C92
	public const float TEXT_GAP = 4f; // Metadata: 0x005F0C96
	public const float FONT = 34f; // Metadata: 0x005F0C9A
	public const float BLOCK_BLEED = 4000f; // Metadata: 0x005F0C9E
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
	public bool IsShowing { get; } // 0x0000000180741D30-0x0000000180741E90 
	public float ShownFor { get; } // 0x0000000180741E90-0x0000000180741F00 
	public bool IsBlocking { get; } // 0x0000000180742E90-0x0000000180742FF0 

	// Constructors
	public ThanhTuuSpinner(); // 0x0000000180743390-0x0000000180743470

	// Methods
	public static ThanhTuuSpinner Build(MonoBehaviour host, RectTransform parent, float cx, float cy); // 0x0000000180741F00-0x00000001807426B0
	public void Rebind(); // 0x00000001807426B0-0x0000000180742810
	public void Show(string waiting); // 0x0000000180742810-0x0000000180742B50
	public void Hide(); // 0x0000000180742B50-0x0000000180742E90
	public void SetBlocking(bool on); // 0x0000000180742FF0-0x00000001807431D0
	private void SetDots(int n); // 0x00000001807431D0-0x0000000180743330
	private void OnDisable(); // 0x0000000180743330-0x0000000180743390
	[CompilerGenerated]
	private void _Show_b__23_0(float k); // 0x0000000180743470-0x0000000180743490
}

