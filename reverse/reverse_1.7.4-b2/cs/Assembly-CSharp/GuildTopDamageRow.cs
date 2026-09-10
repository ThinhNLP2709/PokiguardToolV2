/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class GuildTopDamageRow : MonoBehaviour // TypeDefIndex: 792
{
	// Fields
	[SerializeField]
	private UnityEngine.UI.Text txtRank; // 0x20
	[SerializeField]
	private UnityEngine.UI.Text txtName; // 0x28
	[SerializeField]
	private UnityEngine.UI.Text txtDamage; // 0x30
	private static readonly Color SELF_TINT; // 0x00
	private const float ROW_W_DEFAULT = 400f; // Metadata: 0x0068BBC8
	private const float PAD = 8f; // Metadata: 0x0068BBCC
	private const float RANK_W = 44f; // Metadata: 0x0068BBD0
	private const float AVATAR_D = 40f; // Metadata: 0x0068BBD4
	private const float GAP = 6f; // Metadata: 0x0068BBD8
	private const float DAMAGE_W = 104f; // Metadata: 0x0068BBDC
	private const float TEXT_H = 30f; // Metadata: 0x0068BBE0
	private bool _wired; // 0x38
	private bool _laidOut; // 0x39

	// Constructors
	public GuildTopDamageRow(); // 0x00000001802EBA70-0x00000001802EBAF0
	static GuildTopDamageRow(); // 0x0000000180489610-0x0000000180489650

	// Methods
	private void Awake(); // 0x0000000180488950-0x0000000180488960
	private void EnsureWired(); // 0x0000000180488DC0-0x0000000180489010
	public void NormalizeLayout(); // 0x0000000180489010-0x00000001804893F0
	private static void Place(UnityEngine.UI.Text t, float left, float width, float pivotX, TextAnchor align, int min, int max); // 0x00000001804893F0-0x0000000180489610
	public void Bind(GuildDamageRow row, bool isSelf); // 0x0000000180488960-0x0000000180488DC0
}

