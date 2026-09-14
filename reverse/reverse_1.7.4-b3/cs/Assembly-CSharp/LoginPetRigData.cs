/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Linq;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class LoginPetRigData // TypeDefIndex: 1082
{
	// Fields
	[CompilerGenerated]
	private Vector2 _Frame_k__BackingField; // 0x10
	[CompilerGenerated]
	private List<Part> _Parts_k__BackingField; // 0x18
	[CompilerGenerated]
	private Anim _Motion_k__BackingField; // 0x20

	// Properties
	public Vector2 Frame { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180668FC0-0x0000000180668FE0 0x000000018054F500-0x000000018054F510
	public List<Part> Parts { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018028EDE0-0x000000018028EDF0 0x00000001802B4F80-0x00000001802B4FE0
	public Anim Motion { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802A8720-0x00000001802A8730 0x00000001802B4BC0-0x00000001802B4C20

	// Nested types
	public class Part // TypeDefIndex: 1083
	{
		// Fields
		public string name; // 0x10
		public string sprite; // 0x18
		public Rect bbox; // 0x20
		public Vector2 pivot; // 0x30
		public string parent; // 0x38
		public int z; // 0x40

		// Constructors
		public Part(); // 0x000000018066B8F0-0x000000018066B9E0
	}

	public class Anim // TypeDefIndex: 1084
	{
		// Fields
		public float driftX; // 0x10
		public float driftY; // 0x14
		public float driftPeriod; // 0x18
		public float cloudBobAmp; // 0x1C
		public float cloudBobPeriod; // 0x20
		public float bodyBobAmp; // 0x24
		public float bodyBobPeriod; // 0x28
		public float bodyTilt; // 0x2C
		public float squash; // 0x30
		public float headTilt; // 0x34
		public float headPeriod; // 0x38
		public float headPhase; // 0x3C
		public float earSway; // 0x40
		public float earPeriod; // 0x44
		public float earPhaseR; // 0x48
		public float armSwing; // 0x4C
		public float armPeriod; // 0x50
		public float armPhaseR; // 0x54
		public float warmUp; // 0x58

		// Constructors
		public Anim(); // 0x000000018066B9E0-0x000000018066BA70
	}

	// Constructors
	private LoginPetRigData(); // 0x0000000180668FE0-0x0000000180669210

	// Methods
	public Rect Union(); // 0x0000000180669210-0x00000001806694E0
	public static LoginPetRigData Default(); // 0x00000001806694E0-0x00000001806695A0
	public static LoginPetRigData Parse(string json); // 0x00000001806695A0-0x0000000180669630
	private static LoginPetRigData ParseOrNull(string json); // 0x0000000180669630-0x0000000180669C60
	private static Part ReadPart(JObject o, int index); // 0x0000000180669C60-0x000000018066A270
	private static void ReadAnim(JObject o, Anim a); // 0x000000018066A270-0x000000018066B1E0
	private static void Sanitize(Anim a); // 0x000000018066B1E0-0x000000018066B670
	private static float Safe(float v, float lo, float hi); // 0x000000018066B670-0x000000018066B6A0
	private static float Num(JToken t, float fallback); // 0x000000018066B6A0-0x000000018066B840
	private static string Str(JToken t, string fallback); // 0x000000018066B840-0x000000018066B8F0
}

