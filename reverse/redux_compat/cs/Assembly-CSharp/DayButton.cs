/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class DayButton : MonoBehaviour // TypeDefIndex: 984
{
	// Fields
	[Header("UI Components")]
	public Image imgcheck; // 0x20
	public Image imgRW; // 0x28
	public UnityEngine.UI.Text txtCount; // 0x30
	public UnityEngine.UI.Text txtDay; // 0x38
	public Button btnDay; // 0x40
	[Header("Sprites")]
	public Sprite goldSprite; // 0x48
	public Sprite starWhiteSprite; // 0x50
	public Sprite starRedSprite; // 0x58
	public Sprite rubySprite; // 0x60
	public Sprite energySprite; // 0x68
	public Sprite wheelDaySprite; // 0x70
	private DailyCheckInData checkInData; // 0x78
	private Action<DailyCheckInData> onClaimCallback; // 0x80

	// Constructors
	public DayButton(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	private void Start(); // 0x0000000180481BC0-0x0000000180481C50
	public void Setup(DailyCheckInData data, Action<DailyCheckInData> onClaim); // 0x0000000180481590-0x0000000180481BC0
	private void UpdateVisualState(); // 0x0000000180481D40-0x0000000180481E60
	private void OnButtonClick(); // 0x00000001804814F0-0x0000000180481590
	public void UpdateClaimStatus(bool claimed); // 0x0000000180481C50-0x0000000180481D40
	private string FormatNumber(int number); // 0x0000000180481400-0x00000001804814F0
}

