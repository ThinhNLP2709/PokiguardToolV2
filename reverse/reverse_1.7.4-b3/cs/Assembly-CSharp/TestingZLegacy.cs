/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

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
		static __c(); // 0x0000000180D82A80-0x0000000180D82B20
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _cycleThroughExamples_b__20_0(float val); // 0x0000000180D82B20-0x0000000180D82B80
	}

	// Constructors
	public TestingZLegacy(); // 0x0000000180D82770-0x0000000180D82A80

	// Methods
	private void Awake(); // 0x0000000180D7F760-0x0000000180D7F810
	private void Start(); // 0x0000000180D7F810-0x0000000180D7F9C0
	private void pauseNow(); // 0x0000000180D7F9C0-0x0000000180D7FA70
	private void OnGUI(); // 0x0000000180D7FA70-0x0000000180D7FD40
	private void endlessCallback(); // 0x0000000180D7FD40-0x0000000180D7FDB0
	private void cycleThroughExamples(); // 0x0000000180D7FDB0-0x0000000180D80220
	public void updateValue3Example(); // 0x0000000180D80220-0x0000000180D80520
	public void updateValue3ExampleUpdate(Vector3 val); // 0x000000018028A320-0x000000018028A330
	public void updateValue3ExampleCallback(Vector3 val); // 0x0000000180D80520-0x0000000180D80570
	public void loopTestClamp(); // 0x0000000180D80570-0x0000000180D80800
	public void loopTestPingPong(); // 0x0000000180D80800-0x0000000180D80A70
	public void colorExample(); // 0x0000000180D80A70-0x0000000180D80B70
	public void moveOnACurveExample(); // 0x0000000180D80B70-0x0000000180D810F0
	public void customTweenExample(); // 0x0000000180D810F0-0x0000000180D81310
	public void moveExample(); // 0x0000000180D81310-0x0000000180D81520
	public void rotateExample(); // 0x0000000180D81520-0x0000000180D817C0
	public void rotateOnUpdate(float val); // 0x000000018028A320-0x000000018028A330
	public void rotateFinished(object hash); // 0x0000000180D817C0-0x0000000180D818E0
	public void scaleExample(); // 0x0000000180D818E0-0x0000000180D81AB0
	public void updateValueExample(); // 0x0000000180D81AB0-0x0000000180D81D90
	public void updateValueExampleCallback(float val, object hash); // 0x0000000180D81D90-0x0000000180D81EB0
	public void delayedCallExample(); // 0x0000000180D81EB0-0x0000000180D81FC0
	public void delayedCallExampleCallback(); // 0x0000000180D81FC0-0x0000000180D82190
	public void alphaExample(); // 0x0000000180D82190-0x0000000180D822B0
	public void moveLocalExample(); // 0x0000000180D822B0-0x0000000180D824A0
	public void rotateAroundExample(); // 0x0000000180D824A0-0x0000000180D825D0
	public void loopPause(); // 0x0000000180D825D0-0x0000000180D82650
	public void loopResume(); // 0x0000000180D82650-0x0000000180D826D0
	public void punchTest(); // 0x0000000180D826D0-0x0000000180D82770
}

