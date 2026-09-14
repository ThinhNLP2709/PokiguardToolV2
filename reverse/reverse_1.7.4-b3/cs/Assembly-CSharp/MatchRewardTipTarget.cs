/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class MatchRewardTipTarget : MonoBehaviour // TypeDefIndex: 2353
{
	// Fields
	private static readonly string[] IconNames; // 0x00
	private const string HIT_NAME = "tipHit"; // Metadata: 0x005F0B31
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
	static MatchRewardTipTarget(); // 0x0000000180B45590-0x0000000180B45720

	// Methods
	public void Wire(string title, string body, string amountText); // 0x0000000180B43870-0x0000000180B43C60
	public void Show(); // 0x0000000180B43C60-0x0000000180B43DB0
	private Sprite CurrentIcon(); // 0x0000000180B43DB0-0x0000000180B445A0
	private void EnsureHitArea(); // 0x0000000180B445A0-0x0000000180B45590
}

