/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class SpinBtn : MonoBehaviour // TypeDefIndex: 1065
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
	public SpinBtn(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public void Initialize(SlotMachine parent); // 0x00000001804A83A0-0x00000001804A8490
	private void OnClick(); // 0x00000001804A8490-0x00000001804A85B0
	public void SetViewAsSpin(); // 0x00000001804A85B0-0x00000001804A8620
	public void SetViewAsStop(); // 0x00000001804A8620-0x00000001804A8690
}

