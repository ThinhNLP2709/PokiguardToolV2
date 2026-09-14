/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class MatchRewardTipTarget : MonoBehaviour // TypeDefIndex: 2360
{
	// Fields
	private static readonly string[] IconNames; // 0x00
	private const string HIT_NAME = "tipHit"; // Metadata: 0x005F1F48
	[NonSerialized]
	private string _title; // 0x20
	[NonSerialized]
	private string _body; // 0x28
	[NonSerialized]
	private string _amount; // 0x30

	// Properties
	public string Title { get; } // 0x00000001802A8720-0x00000001802A8730 
	public string Body { get; } // 0x00000001802A8730-0x00000001802A8740 

	// Constructors
	public MatchRewardTipTarget(); // 0x000000018028A560-0x000000018028A5B0
	static MatchRewardTipTarget(); // 0x0000000180B52810-0x0000000180B529A0

	// Methods
	public void Wire(string title, string body, string amountText); // 0x0000000180B50AF0-0x0000000180B50EE0
	public void Show(); // 0x0000000180B50EE0-0x0000000180B51030
	private Sprite CurrentIcon(); // 0x0000000180B51030-0x0000000180B51820
	private void EnsureHitArea(); // 0x0000000180B51820-0x0000000180B52810
}

