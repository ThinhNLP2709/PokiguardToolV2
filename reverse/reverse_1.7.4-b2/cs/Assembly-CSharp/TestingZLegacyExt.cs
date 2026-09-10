/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class TestingZLegacyExt : MonoBehaviour // TypeDefIndex: 301
{
	// Fields
	public AnimationCurve customAnimationCurve; // 0x20
	public Transform pt1; // 0x28
	public Transform pt2; // 0x30
	public Transform pt3; // 0x38
	public Transform pt4; // 0x40
	public Transform pt5; // 0x48
	private int exampleIter; // 0x50
	private string[] exampleFunctions; // 0x58
	public bool useEstimatedTime; // 0x60
	private Transform ltLogo; // 0x68
	private TimingType timingType; // 0x70
	private int descrTimeScaleChangeId; // 0x74
	private Vector3 origin; // 0x78

	// Nested types
	public delegate void NextFunc(); // TypeDefIndex: 302; 0x00000001802EBAF0-0x00000001802EBB90

	public enum TimingType // TypeDefIndex: 303
	{
		SteadyNormalTime = 0,
		IgnoreTimeScale = 1,
		HalfTimeScale = 2,
		VariableTimeScale = 3,
		Length = 4
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 304
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<float> __9__20_0; // 0x08

		// Constructors
		static __c(); // 0x00000001808742D0-0x0000000180874450
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _cycleThroughExamples_b__20_0(float val); // 0x0000000180873820-0x0000000180873830
	}

	// Constructors
	public TestingZLegacyExt(); // 0x000000018086F420-0x000000018086F6F0

	// Methods
	private void Awake(); // 0x00000001802EB6C0-0x00000001802EB6D0
	private void Start(); // 0x000000018086F310-0x000000018086F420
	private void pauseNow(); // 0x00000001808707A0-0x0000000180870800
	private void OnGUI(); // 0x000000018086F1B0-0x000000018086F310
	private void endlessCallback(); // 0x000000018086FF30-0x000000018086FF90
	private void cycleThroughExamples(); // 0x000000018086FA00-0x000000018086FD50
	public void updateValue3Example(); // 0x0000000180870DC0-0x0000000180870FF0
	public void updateValue3ExampleUpdate(Vector3 val); // 0x00000001802EB6C0-0x00000001802EB6D0
	public void updateValue3ExampleCallback(Vector3 val); // 0x0000000180870D70-0x0000000180870DC0
	public void loopTestClamp(); // 0x0000000180870010-0x0000000180870190
	public void loopTestPingPong(); // 0x0000000180870190-0x00000001808702E0
	public void colorExample(); // 0x000000018086F7D0-0x000000018086F890
	public void moveOnACurveExample(); // 0x0000000180870520-0x00000001808707A0
	public void customTweenExample(); // 0x000000018086F890-0x000000018086FA00
	public void moveExample(); // 0x00000001808702E0-0x00000001808703D0
	public void rotateExample(); // 0x0000000180870930-0x0000000180870B80
	public void rotateOnUpdate(float val); // 0x00000001802EB6C0-0x00000001802EB6D0
	public void rotateFinished(object hash); // 0x0000000180870B80-0x0000000180870C80
	public void scaleExample(); // 0x0000000180870C80-0x0000000180870D70
	public void updateValueExample(); // 0x0000000180871080-0x0000000180871250
	public void updateValueExampleCallback(float val, object hash); // 0x0000000180870FF0-0x0000000180871080
	public void delayedCallExample(); // 0x000000018086FE40-0x000000018086FF30
	public void delayedCallExampleCallback(); // 0x000000018086FD50-0x000000018086FE40
	public void alphaExample(); // 0x000000018086F6F0-0x000000018086F7D0
	public void moveLocalExample(); // 0x00000001808703D0-0x0000000180870520
	public void rotateAroundExample(); // 0x0000000180870860-0x0000000180870930
	public void loopPause(); // 0x000000018086FF90-0x000000018086FFD0
	public void loopResume(); // 0x000000018086FFD0-0x0000000180870010
	public void punchTest(); // 0x0000000180870800-0x0000000180870860
}

