/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class SpinBtn : MonoBehaviour // TypeDefIndex: 1665
{
	// Fields
	[SerializeField]
	private UnityEngine.UI.Text label; // 0x20
	[Header("Spin View")]
	[SerializeField]
	private Sprite spinSp; // 0x28
	[SerializeField]
	private Color spinColor; // 0x30
	[Header("Stop View")]
	[SerializeField]
	private Sprite stopSp; // 0x40
	[SerializeField]
	private Color stopColor; // 0x48
	private SlotMachine _parent; // 0x58
	private bool _isSpin; // 0x60
	private Image _background; // 0x68

	// Constructors
	public SpinBtn(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void Initialize(SlotMachine parent); // 0x00000001808AF790-0x00000001808AF930
	private void OnClick(); // 0x00000001808AF930-0x00000001808AFB60
	public void SetViewAsSpin(); // 0x00000001808AFB60-0x00000001808AFBE0
	public void SetViewAsStop(); // 0x00000001808AFBE0-0x00000001808AFC60
}

