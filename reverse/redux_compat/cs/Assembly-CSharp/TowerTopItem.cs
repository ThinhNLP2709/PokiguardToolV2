/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

[DisallowMultipleComponent]
public class TowerTopItem : MonoBehaviour // TypeDefIndex: 803
{
	// Fields
	[Header("H\u1EA1ng")]
	public Image imgTopIcon; // 0x20
	public UnityEngine.UI.Text txtTop; // 0x28
	[Header("Ng\u01B0\u1EDDi ch\u01A1i")]
	public UnityEngine.UI.Text txtName; // 0x30
	public Image imgAvatar; // 0x38
	public UnityEngine.UI.Text txtLevel; // 0x40
	[Header("S\u1ED1 li\u1EC7u")]
	public UnityEngine.UI.Text txtPower; // 0x48
	public UnityEngine.UI.Text txtFloor; // 0x50
	[Header("N\u1EC1n d\u00F2ng (\u0111\u1ED5i m\u00E0u khi l\u00E0 ch\u00EDnh m\u00ECnh)")]
	public Image imgRowBg; // 0x58
	[Header("Huy ch\u01B0\u01A1ng h\u1EA1ng 1/2/3")]
	public Sprite iconTop1; // 0x60
	public Sprite iconTop2; // 0x68
	public Sprite iconTop3; // 0x70
	private Color _bgBase; // 0x78
	private bool _bgCached; // 0x88

	// Constructors
	public TowerTopItem(); // 0x00000001802E7A70-0x00000001802E7BC0

	// Methods
	public void Init(TowerTopRow row, bool isMe); // 0x0000000180431F70-0x0000000180432420
	private void ApplyRank(int rank); // 0x0000000180431DB0-0x0000000180431F70
}

