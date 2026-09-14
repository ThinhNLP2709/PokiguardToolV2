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

public static class VipFx // TypeDefIndex: 1474
{
	// Fields
	private static int _flag; // 0x00
	private static readonly List<GameObject> _temp; // 0x08
	private static readonly List<Image> _sweeps; // 0x10
	private static readonly List<Transform> _pulsed; // 0x18

	// Properties
	public static bool Enabled { get; } // 0x0000000180800E90-0x0000000180800FF0 

	// Nested types
	[CompilerGenerated]
	private sealed class __c__DisplayClass11_0 // TypeDefIndex: 1475
	{
		// Fields
		public RectTransform node; // 0x10

		// Constructors
		public __c__DisplayClass11_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _BadgePulse_b__0(); // 0x0000000180803F00-0x0000000180804090
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass13_0 // TypeDefIndex: 1476
	{
		// Fields
		public Image g; // 0x10
		public RectTransform grt; // 0x18

		// Constructors
		public __c__DisplayClass13_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ClaimBurst_b__0(float k); // 0x0000000180804090-0x0000000180804300
		internal void _ClaimBurst_b__1(); // 0x0000000180804300-0x0000000180804430
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass13_1 // TypeDefIndex: 1477
	{
		// Fields
		public Image spark; // 0x10
		public RectTransform prt; // 0x18
		public Vector2 dir; // 0x20

		// Constructors
		public __c__DisplayClass13_1(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _ClaimBurst_b__2(float k); // 0x0000000180804430-0x00000001808046C0
		internal void _ClaimBurst_b__3(); // 0x00000001808046C0-0x00000001808047F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass14_0 // TypeDefIndex: 1478
	{
		// Fields
		public Image ray; // 0x10
		public RectTransform rt; // 0x18
		public float from; // 0x20
		public float to; // 0x24

		// Constructors
		public __c__DisplayClass14_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _CardSweep_b__0(float k); // 0x00000001808047F0-0x00000001808049E0
		internal void _CardSweep_b__1(); // 0x00000001808049E0-0x0000000180804A40
	}

	// Constructors
	static VipFx(); // 0x0000000180803B60-0x0000000180803F00

	// Methods
	public static void RefreshFlag(); // 0x0000000180800FF0-0x0000000180801050
	private static bool Sub(int which); // 0x0000000180801050-0x0000000180801100
	public static void FadeIn(CanvasGroup group); // 0x0000000180801100-0x00000001808012F0
	public static void PopIn(RectTransform box); // 0x00000001808012F0-0x0000000180801500
	public static void BadgePulse(RectTransform node); // 0x0000000180801500-0x0000000180801920
	public static void HubFlash(Image badge); // 0x0000000180801920-0x0000000180801A40
	public static void ClaimBurst(RectTransform anchor); // 0x0000000180801A40-0x0000000180802750
	public static void CardSweep(Image ray, RectTransform card); // 0x0000000180802750-0x0000000180802E60
	public static void CancelAll(); // 0x0000000180802E60-0x00000001808034D0
	private static void Rest(Image ray); // 0x00000001808034D0-0x0000000180803710
	private static void Kill(GameObject go); // 0x0000000180803710-0x00000001808038A0
	private static void Remember(Transform t); // 0x00000001808038A0-0x0000000180803B60
}

