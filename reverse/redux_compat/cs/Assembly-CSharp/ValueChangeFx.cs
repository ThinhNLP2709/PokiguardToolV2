/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class ValueChangeFx // TypeDefIndex: 1273
{
	// Fields
	public static readonly Color GainColor; // 0x00
	public static readonly Color LossColor; // 0x10
	private const float CountDuration = 0.45f; // Metadata: 0x0064D58B
	private const float PunchUpTime = 0.1f; // Metadata: 0x0064D58F
	private const float PunchDownTime = 0.16f; // Metadata: 0x0064D593
	private const float PunchScale = 1.14f; // Metadata: 0x0064D597
	private const float FlashFadeTime = 0.45f; // Metadata: 0x0064D59B
	private static readonly Dictionary<EntityId, long> _lastValues; // 0x20
	private static readonly Dictionary<EntityId, Vector3> _baseScales; // 0x28
	private static readonly Dictionary<EntityId, Color> _baseColors; // 0x30
	private const int MAX_TRACKED = 512; // Metadata: 0x0064D59F

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1274
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<long, string> __9__10_0; // 0x08

		// Constructors
		static __c(); // 0x00000001804EABC0-0x00000001804EAC30
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal string _SetNumber_b__10_0(long v); // 0x00000001804EA470-0x00000001804EA490
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 1275
	{
		// Fields
		public UnityEngine.UI.Text target; // 0x10
		public Func<long, string> formatter; // 0x18
		public long to; // 0x20
		public Color baseColor; // 0x28
		public Vector3 baseScale; // 0x38

		// Constructors
		public __c__DisplayClass15_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayCountUp_b__0(float v); // 0x00000001804EA4D0-0x00000001804EA640
		internal void _PlayCountUp_b__1(); // 0x00000001804EA640-0x00000001804EA750
		internal void _PlayCountUp_b__2(Color c); // 0x00000001804EA750-0x00000001804EA7F0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 1276
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass16_0(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _PlayPunch_b__0(); // 0x00000001804EA7F0-0x00000001804EA8E0
	}

	// Constructors
	static ValueChangeFx(); // 0x00000001804EDD90-0x00000001804EDF20

	// Methods
	public static void SetNumber(UnityEngine.UI.Text target, long value, Func<long, string> formatter, bool animate = true /* Metadata: 0x0064D589 */); // 0x00000001804ED970-0x00000001804EDBF0
	public static void SetText(UnityEngine.UI.Text target, string value, bool animate = true /* Metadata: 0x0064D58A */); // 0x00000001804EDBF0-0x00000001804EDD90
	public static void ResetAll(); // 0x00000001804ED8D0-0x00000001804ED970
	private static void Register(UnityEngine.UI.Text target, EntityId key); // 0x00000001804ED650-0x00000001804ED8D0
	private static void PlayCountUp(UnityEngine.UI.Text target, EntityId key, long from, long to, Func<long, string> formatter); // 0x00000001804ECFF0-0x00000001804ED420
	private static void PlayPunch(GameObject go, EntityId key); // 0x00000001804ED420-0x00000001804ED650
}

