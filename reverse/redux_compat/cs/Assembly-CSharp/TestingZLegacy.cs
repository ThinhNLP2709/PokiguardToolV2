/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class TestingZLegacy : MonoBehaviour // TypeDefIndex: 271
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
	public delegate void NextFunc(); // TypeDefIndex: 272; 0x0000000180313920-0x00000001803139C0

	public enum TimingType // TypeDefIndex: 273
	{
		SteadyNormalTime = 0,
		IgnoreTimeScale = 1,
		HalfTimeScale = 2,
		VariableTimeScale = 3,
		Length = 4
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 274
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<float> __9__20_0; // 0x08

		// Constructors
		static __c(); // 0x00000001806CAD40-0x00000001806CADB0
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _cycleThroughExamples_b__20_0(float val); // 0x00000001806C9D40-0x00000001806C9D50
	}

	// Constructors
	public TestingZLegacy(); // 0x00000001806C7960-0x00000001806C7C40

	// Methods
	private void Awake(); // 0x00000001806C76B0-0x00000001806C7700
	private void Start(); // 0x00000001806C7860-0x00000001806C7960
	private void pauseNow(); // 0x00000001806C8F80-0x00000001806C8FE0
	private void OnGUI(); // 0x00000001806C7700-0x00000001806C7860
	private void endlessCallback(); // 0x00000001806C85A0-0x00000001806C8600
	private void cycleThroughExamples(); // 0x00000001806C7FD0-0x00000001806C8350
	public void updateValue3Example(); // 0x00000001806C96E0-0x00000001806C9950
	public void updateValue3ExampleUpdate(Vector3 val); // 0x00000001802E76C0-0x00000001802E76D0
	public void updateValue3ExampleCallback(Vector3 val); // 0x00000001806C9690-0x00000001806C96E0
	public void loopTestClamp(); // 0x00000001806C86E0-0x00000001806C8880
	public void loopTestPingPong(); // 0x00000001806C8880-0x00000001806C8A00
	public void colorExample(); // 0x00000001806C7D40-0x00000001806C7E30
	public void moveOnACurveExample(); // 0x00000001806C8CC0-0x00000001806C8F80
	public void customTweenExample(); // 0x00000001806C7E30-0x00000001806C7FD0
	public void moveExample(); // 0x00000001806C8A00-0x00000001806C8B30
	public void rotateExample(); // 0x00000001806C91A0-0x00000001806C9430
	public void rotateOnUpdate(float val); // 0x00000001802E76C0-0x00000001802E76D0
	public void rotateFinished(object hash); // 0x00000001806C9430-0x00000001806C9530
	public void scaleExample(); // 0x00000001806C9530-0x00000001806C9690
	public void updateValueExample(); // 0x00000001806C99F0-0x00000001806C9C00
	public void updateValueExampleCallback(float val, object hash); // 0x00000001806C9950-0x00000001806C99F0
	public void delayedCallExample(); // 0x00000001806C84B0-0x00000001806C85A0
	public void delayedCallExampleCallback(); // 0x00000001806C8350-0x00000001806C84B0
	public void alphaExample(); // 0x00000001806C7C40-0x00000001806C7D40
	public void moveLocalExample(); // 0x00000001806C8B30-0x00000001806C8CC0
	public void rotateAroundExample(); // 0x00000001806C9080-0x00000001806C91A0
	public void loopPause(); // 0x00000001806C8600-0x00000001806C8670
	public void loopResume(); // 0x00000001806C8670-0x00000001806C86E0
	public void punchTest(); // 0x00000001806C8FE0-0x00000001806C9080
}

