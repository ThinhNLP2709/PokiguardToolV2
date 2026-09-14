/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class DayButton : MonoBehaviour // TypeDefIndex: 1585
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
	public DayButton(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	private void Start(); // 0x0000000180879A30-0x0000000180879B80
	public void Setup(DailyCheckInData data, Action<DailyCheckInData> onClaim); // 0x0000000180879B80-0x000000018087A530
	private void UpdateVisualState(); // 0x000000018087A530-0x000000018087A7C0
	private void OnButtonClick(); // 0x000000018087A7C0-0x000000018087A870
	public void UpdateClaimStatus(bool claimed); // 0x000000018087A870-0x000000018087AAB0
	private string FormatNumber(int number); // 0x000000018087AAB0-0x000000018087AC80
}

