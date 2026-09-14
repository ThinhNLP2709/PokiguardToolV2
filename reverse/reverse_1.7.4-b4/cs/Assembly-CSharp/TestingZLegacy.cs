/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class TestingZLegacy : MonoBehaviour // TypeDefIndex: 296
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
	private GameObject ltLogo; // 0x68
	private TimingType timingType; // 0x70
	private int descrTimeScaleChangeId; // 0x74
	private Vector3 origin; // 0x78

	// Nested types
	public enum TimingType // TypeDefIndex: 297
	{
		SteadyNormalTime = 0,
		IgnoreTimeScale = 1,
		HalfTimeScale = 2,
		VariableTimeScale = 3,
		Length = 4
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 298
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<float> __9__20_0; // 0x08

		// Constructors
		static __c(); // 0x0000000180D90860-0x0000000180D90900
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _cycleThroughExamples_b__20_0(float val); // 0x0000000180D90900-0x0000000180D90960
	}

	// Constructors
	public TestingZLegacy(); // 0x0000000180D90550-0x0000000180D90860

	// Methods
	private void Awake(); // 0x0000000180D8D540-0x0000000180D8D5F0
	private void Start(); // 0x0000000180D8D5F0-0x0000000180D8D7A0
	private void pauseNow(); // 0x0000000180D8D7A0-0x0000000180D8D850
	private void OnGUI(); // 0x0000000180D8D850-0x0000000180D8DB20
	private void endlessCallback(); // 0x0000000180D8DB20-0x0000000180D8DB90
	private void cycleThroughExamples(); // 0x0000000180D8DB90-0x0000000180D8E000
	public void updateValue3Example(); // 0x0000000180D8E000-0x0000000180D8E300
	public void updateValue3ExampleUpdate(Vector3 val); // 0x000000018028A320-0x000000018028A330
	public void updateValue3ExampleCallback(Vector3 val); // 0x0000000180D8E300-0x0000000180D8E350
	public void loopTestClamp(); // 0x0000000180D8E350-0x0000000180D8E5E0
	public void loopTestPingPong(); // 0x0000000180D8E5E0-0x0000000180D8E850
	public void colorExample(); // 0x0000000180D8E850-0x0000000180D8E950
	public void moveOnACurveExample(); // 0x0000000180D8E950-0x0000000180D8EED0
	public void customTweenExample(); // 0x0000000180D8EED0-0x0000000180D8F0F0
	public void moveExample(); // 0x0000000180D8F0F0-0x0000000180D8F300
	public void rotateExample(); // 0x0000000180D8F300-0x0000000180D8F5A0
	public void rotateOnUpdate(float val); // 0x000000018028A320-0x000000018028A330
	public void rotateFinished(object hash); // 0x0000000180D8F5A0-0x0000000180D8F6C0
	public void scaleExample(); // 0x0000000180D8F6C0-0x0000000180D8F890
	public void updateValueExample(); // 0x0000000180D8F890-0x0000000180D8FB70
	public void updateValueExampleCallback(float val, object hash); // 0x0000000180D8FB70-0x0000000180D8FC90
	public void delayedCallExample(); // 0x0000000180D8FC90-0x0000000180D8FDA0
	public void delayedCallExampleCallback(); // 0x0000000180D8FDA0-0x0000000180D8FF70
	public void alphaExample(); // 0x0000000180D8FF70-0x0000000180D90090
	public void moveLocalExample(); // 0x0000000180D90090-0x0000000180D90280
	public void rotateAroundExample(); // 0x0000000180D90280-0x0000000180D903B0
	public void loopPause(); // 0x0000000180D903B0-0x0000000180D90430
	public void loopResume(); // 0x0000000180D90430-0x0000000180D904B0
	public void punchTest(); // 0x0000000180D904B0-0x0000000180D90550
}

