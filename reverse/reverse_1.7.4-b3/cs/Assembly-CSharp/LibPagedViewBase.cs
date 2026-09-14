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

public abstract class LibPagedViewBase : MonoBehaviour // TypeDefIndex: 2133
{
	// Fields
	protected const string NODE_SCROLL = "scroll"; // Metadata: 0x005F0619
	protected const string NODE_VIEWPORT = "viewport"; // Metadata: 0x005F0620
	protected const string NODE_CONTENT = "content"; // Metadata: 0x005F0629
	protected const string NODE_PAGER = "pager"; // Metadata: 0x005F0631
	protected const string NODE_BTN_PREV = "btnPrev"; // Metadata: 0x005F0637
	protected const string NODE_BTN_NEXT = "btnNext"; // Metadata: 0x005F063F
	protected const string NODE_TXT_PAGE = "txtPage"; // Metadata: 0x005F0647
	protected const string NODE_EMPTY = "txtEmpty"; // Metadata: 0x005F064F
	[Header("L\u01B0\u1EDBi")]
	[Tooltip("Node \'content\' mang GridLayoutGroup \u2014 cha c\u1EE7a c\u00E1c \u00F4.")]
	public Transform container; // 0x20
	[Tooltip("Prefab m\u1ED9t \u00F4 (PokyEffectLibCell / PokyCardLibCell).")]
	public GameObject cellPrefab; // 0x28
	public ScrollRect scroll; // 0x30
	[Header("Ph\u00E2n trang")]
	public Button btnPrev; // 0x38
	public Button btnNext; // 0x40
	public UnityEngine.UI.Text txtPage; // 0x48
	[Header("Tr\u1EA1ng th\u00E1i r\u1ED7ng")]
	[Tooltip("D\u00F2ng ch\u1EEF gi\u1EEFa v\u00F9ng cu\u1ED9n khi ch\u01B0a c\u00F3 m\u1EE5c n\u00E0o \u2014 l\u01B0\u1EDBi tr\u1ED1ng tr\u01A1n kh\u00F4ng n\u00F3i \u0111\u01B0\u1EE3c g\u00EC.")]
	public UnityEngine.UI.Text txtEmpty; // 0x50
	public int perPage; // 0x58
	protected int page; // 0x5C
	private bool _wired; // 0x60

	// Properties
	protected abstract int TotalCount { get; }
	protected virtual string EmptyMessage { get; } // 0x0000000180A0E770-0x0000000180A0E7B0 
	public int PageCount { get; } // 0x0000000180A0F530-0x0000000180A0F580 

	// Constructors
	protected LibPagedViewBase(); // 0x0000000180A0E6C0-0x0000000180A0E710

	// Methods
	protected abstract void BindCell(GameObject cell, int index);
	protected virtual void Awake(); // 0x0000000180A0E7B0-0x0000000180A0E7C0
	protected void AutoWire(); // 0x0000000180A0E7C0-0x0000000180A0F530
	public void PrevPage(); // 0x0000000180A0F580-0x0000000180A0F5A0
	public void NextPage(); // 0x0000000180A0F5A0-0x0000000180A0F600
	public void ResetPage(); // 0x0000000180A0F600-0x0000000180A0F610
	public void Render(); // 0x0000000180A0F610-0x0000000180A0FC60
	public void ClearCells(); // 0x0000000180A0FC60-0x0000000180A0FFF0
	private void UpdatePager(int total); // 0x0000000180A0FFF0-0x0000000180A104F0
	protected static bool FxOn(); // 0x0000000180A104F0-0x0000000180A10540
	private static void PopIn(GameObject cell, float delay); // 0x0000000180A10540-0x0000000180A108F0
	protected static string JoinParts(List<string> parts); // 0x0000000180A108F0-0x0000000180A10A00
}

