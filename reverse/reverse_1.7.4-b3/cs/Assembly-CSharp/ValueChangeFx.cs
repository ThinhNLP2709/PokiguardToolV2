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

public static class ValueChangeFx // TypeDefIndex: 1889
{
	// Fields
	public static readonly Color GainColor; // 0x00
	public static readonly Color LossColor; // 0x10
	private static readonly Dictionary<EntityId, long> _lastValues; // 0x20
	private static readonly Dictionary<EntityId, Vector3> _baseScales; // 0x28
	private static readonly Dictionary<EntityId, Color> _baseColors; // 0x30

	// Nested types
	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 1890
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Func<long, string> __9__10_0; // 0x08

		// Constructors
		static __c(); // 0x00000001809217B0-0x0000000180921850
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal string _SetNumber_b__10_0(long v); // 0x0000000180921850-0x00000001809218C0
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass15_0 // TypeDefIndex: 1891
	{
		// Fields
		public UnityEngine.UI.Text target; // 0x10
		public Func<long, string> formatter; // 0x18
		public long to; // 0x20
		public Color baseColor; // 0x28
		public Vector3 baseScale; // 0x38

		// Constructors
		public __c__DisplayClass15_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayCountUp_b__0(float v); // 0x00000001809218C0-0x0000000180921A30
		internal void _PlayCountUp_b__1(); // 0x0000000180921A30-0x0000000180921C10
		internal void _PlayCountUp_b__2(Color c); // 0x0000000180921C10-0x0000000180921D30
	}

	[CompilerGenerated]
	private sealed class __c__DisplayClass16_0 // TypeDefIndex: 1892
	{
		// Fields
		public GameObject go; // 0x10
		public Vector3 baseScale; // 0x18

		// Constructors
		public __c__DisplayClass16_0(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _PlayPunch_b__0(); // 0x0000000180921D30-0x0000000180921EA0
	}

	// Constructors
	static ValueChangeFx(); // 0x0000000180921390-0x00000001809217B0

	// Methods
	public static void SetNumber(UnityEngine.UI.Text target, long value, Func<long, string> formatter, bool animate = true /* Metadata: 0x005F029D */); // 0x0000000180920050-0x00000001809203C0
	public static void SetText(UnityEngine.UI.Text target, string value, bool animate = true /* Metadata: 0x005F029E */); // 0x00000001809203C0-0x0000000180920660
	public static void ResetAll(); // 0x0000000180920660-0x00000001809207F0
	private static void Register(UnityEngine.UI.Text target, EntityId key); // 0x00000001809207F0-0x0000000180920AA0
	private static void PlayCountUp(UnityEngine.UI.Text target, EntityId key, long from, long to, Func<long, string> formatter); // 0x0000000180920AA0-0x00000001809210F0
	private static void PlayPunch(GameObject go, EntityId key); // 0x00000001809210F0-0x0000000180921390
}

