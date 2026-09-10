/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class DayButton : MonoBehaviour // TypeDefIndex: 1182
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
	public DayButton(); // 0x00000001802EBA70-0x00000001802EBAF0

	// Methods
	private void Start(); // 0x00000001805738D0-0x0000000180573960
	public void Setup(DailyCheckInData data, Action<DailyCheckInData> onClaim); // 0x00000001805732A0-0x00000001805738D0
	private void UpdateVisualState(); // 0x0000000180573A50-0x0000000180573B70
	private void OnButtonClick(); // 0x0000000180573200-0x00000001805732A0
	public void UpdateClaimStatus(bool claimed); // 0x0000000180573960-0x0000000180573A50
	private string FormatNumber(int number); // 0x0000000180573110-0x0000000180573200
}

