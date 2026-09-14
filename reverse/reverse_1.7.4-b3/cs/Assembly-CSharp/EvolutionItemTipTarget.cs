/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using PokyHome.InfoPlayer;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class EvolutionItemTipTarget : MonoBehaviour // TypeDefIndex: 1129
{
	// Fields
	[NonSerialized]
	private Func<InfoPlayerActionTooltip.Model> _build; // 0x20
	[NonSerialized]
	private RectTransform _anchor; // 0x28

	// Constructors
	public EvolutionItemTipTarget(); // 0x000000018028A560-0x000000018028A5B0

	// Methods
	public void Wire(Func<InfoPlayerActionTooltip.Model> build, RectTransform anchor); // 0x0000000180693100-0x0000000180693740
	public void Show(); // 0x0000000180693740-0x0000000180693910
}

