/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public static class ValueChangeFx // TypeDefIndex: 1506
{
	// Fields
	public static readonly Color GainColor; // 0x00
	public static readonly Color LossColor; // 0x10
	private const float CountDuration = 0.45f; // Metadata: 0x0068D3A3
	private const float PunchUpTime = 0.1f; // Metadata: 0x0068D3A7
	private const float PunchDownTime = 0.16f; // Metadata: 0x0068D3AB
	private const float PunchScale = 1.14f; // Metadata: 0x0068D3AF
	private const float FlashFadeTime = 0.45f; // Metadata: 0x0068D3B3
	private static readonly Dictionary<EntityId, long> _lastValues; // 0x20
	private static readonly Dictionary<EntityId, Vector3> _baseScales; // 0x28
	private static readonly Dictionary<EntityId, Color> _baseColors; // 0x30
	private const int MAX_TRACKED = 512; // Metadata: 0x0068D3B7

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1507
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<long, string> __9__10_0; // 0x08

		// Constructors
		static __c(); // 0x00000001805EB340-0x00000001805EB3B0
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal string _SetNumber_b__10_0(long v); // 0x00000001805EA440-0x00000001805EA460
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 1508
	{
		// Fields
		public UnityEngine.UI.Text target; // 0x10
		public Func<long, string> formatter; // 0x18
		public long to; // 0x20
		public Color baseColor; // 0x28
		public Vector3 baseScale; // 0x38

		// Constructors
		public __c__DisplayClass15_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayCountUp_b__0(float v); // 0x00000001805EA930-0x00000001805EAA10
		internal void _PlayCountUp_b__1(); // 0x00000001805EAA10-0x00000001805EAB20
		internal void _PlayCountUp_b__2(Color c); // 0x00000001805EAB20-0x00000001805EABC0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 1509
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass16_0(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _PlayPunch_b__0(); // 0x00000001805EACE0-0x00000001805EADD0
	}

	// Constructors
	static ValueChangeFx(); // 0x00000001805ED920-0x00000001805EDAB0

	// Methods
	public static void SetNumber(UnityEngine.UI.Text target, long value, Func<long, string> formatter, bool animate = true /* Metadata: 0x0068D3A1 */); // 0x00000001805ED500-0x00000001805ED780
	public static void SetText(UnityEngine.UI.Text target, string value, bool animate = true /* Metadata: 0x0068D3A2 */); // 0x00000001805ED780-0x00000001805ED920
	public static void ResetAll(); // 0x00000001805ED460-0x00000001805ED500
	private static void Register(UnityEngine.UI.Text target, EntityId key); // 0x00000001805ED1E0-0x00000001805ED460
	private static void PlayCountUp(UnityEngine.UI.Text target, EntityId key, long from, long to, Func<long, string> formatter); // 0x00000001805ECB80-0x00000001805ECFB0
	private static void PlayPunch(GameObject go, EntityId key); // 0x00000001805ECFB0-0x00000001805ED1E0
}

