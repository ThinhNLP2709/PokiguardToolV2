/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class DailyCheckInManager : MonoBehaviour // TypeDefIndex: 1581
{
	// Fields
	[Header("Panel References")]
	public GameObject PanelDiemDanh; // 0x20
	public GameObject bg; // 0x28
	public Transform list; // 0x30
	public GameObject Day; // 0x38
	public UnityEngine.UI.Text txtDiemdanh; // 0x40
	public Button btnBack; // 0x48
	[Header("Sprites")]
	public Sprite goldSprite; // 0x50
	public Sprite starWhiteSprite; // 0x58
	public Sprite starRedSprite; // 0x60
	public Sprite rubySprite; // 0x68
	public Sprite energySprite; // 0x70
	public Sprite wheelDaySprite; // 0x78
	[Header("Notification")]
	public GameObject notificationPanel; // 0x80
	public UnityEngine.UI.Text txtNotificationMessage; // 0x88
	public Button btnCloseNotification; // 0x90
	[Header("Loading")]
	public GameObject loadingPanel; // 0x98
	[Header("Debug")]
	public bool debugMode; // 0xA0
	private RectTransform _fxDayAnchor; // 0xA8
	private List<DayButton> dayButtons; // 0xB0

	// Constructors
	public DailyCheckInManager(); // 0x0000000180875FF0-0x00000001808760F0

	// Methods
	private void Awake(); // 0x0000000180873770-0x0000000180873B10
	private int GetUserId(); // 0x0000000180873B10-0x0000000180873B50
	public void OpenPanel(); // 0x0000000180873B50-0x0000000180873C30
	private void LoadCheckInData(int userId); // 0x0000000180873C30-0x0000000180873F80
	private void OnCheckInDataLoaded(List<DailyCheckInData> checkIns); // 0x0000000180873F80-0x0000000180874790
	private void OnCheckInDataError(string error); // 0x0000000180874790-0x0000000180874980
	private void OnClaimButtonClicked(DailyCheckInData checkInData); // 0x0000000180874980-0x0000000180875040
	private void OnClaimSuccess(ClaimDailyRewardResponse response); // 0x0000000180875040-0x0000000180875780
	private void OnClaimError(string error); // 0x0000000180875780-0x0000000180875A00
	private void ShowNotification(string message); // 0x0000000180875A00-0x0000000180875C20
	private void CloseNotification(); // 0x0000000180875C20-0x0000000180875D70
	private string FormatNumber(int number); // 0x0000000180875D70-0x0000000180875F40
	private void OnDestroy(); // 0x0000000180875F40-0x0000000180875FF0
}

