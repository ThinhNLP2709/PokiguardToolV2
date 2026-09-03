/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class TestingZLegacyExt : MonoBehaviour // TypeDefIndex: 275
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
	public delegate void NextFunc(); // TypeDefIndex: 276; 0x0000000180313920-0x00000001803139C0

	public enum TimingType // TypeDefIndex: 277
	{
		SteadyNormalTime = 0,
		IgnoreTimeScale = 1,
		HalfTimeScale = 2,
		VariableTimeScale = 3,
		Length = 4
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 278
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<float> __9__20_0; // 0x08

		// Constructors
		static __c(); // 0x00000001806CAE20-0x00000001806CAE90
		public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0

		// Methods
		internal void _cycleThroughExamples_b__20_0(float val); // 0x00000001806C9D40-0x00000001806C9D50
	}

	// Constructors
	public TestingZLegacyExt(); // 0x00000001806C5880-0x00000001806C5B50

	// Methods
	private void Awake(); // 0x00000001802E76C0-0x00000001802E76D0
	private void Start(); // 0x00000001806C5770-0x00000001806C5880
	private void pauseNow(); // 0x00000001806C6C00-0x00000001806C6C60
	private void OnGUI(); // 0x00000001806C5610-0x00000001806C5770
	private void endlessCallback(); // 0x00000001806C6390-0x00000001806C63F0
	private void cycleThroughExamples(); // 0x00000001806C5E60-0x00000001806C61B0
	public void updateValue3Example(); // 0x00000001806C7220-0x00000001806C7450
	public void updateValue3ExampleUpdate(Vector3 val); // 0x00000001802E76C0-0x00000001802E76D0
	public void updateValue3ExampleCallback(Vector3 val); // 0x00000001806C71D0-0x00000001806C7220
	public void loopTestClamp(); // 0x00000001806C6470-0x00000001806C65F0
	public void loopTestPingPong(); // 0x00000001806C65F0-0x00000001806C6740
	public void colorExample(); // 0x00000001806C5C30-0x00000001806C5CF0
	public void moveOnACurveExample(); // 0x00000001806C6980-0x00000001806C6C00
	public void customTweenExample(); // 0x00000001806C5CF0-0x00000001806C5E60
	public void moveExample(); // 0x00000001806C6740-0x00000001806C6830
	public void rotateExample(); // 0x00000001806C6D90-0x00000001806C6FE0
	public void rotateOnUpdate(float val); // 0x00000001802E76C0-0x00000001802E76D0
	public void rotateFinished(object hash); // 0x00000001806C6FE0-0x00000001806C70E0
	public void scaleExample(); // 0x00000001806C70E0-0x00000001806C71D0
	public void updateValueExample(); // 0x00000001806C74E0-0x00000001806C76B0
	public void updateValueExampleCallback(float val, object hash); // 0x00000001806C7450-0x00000001806C74E0
	public void delayedCallExample(); // 0x00000001806C62A0-0x00000001806C6390
	public void delayedCallExampleCallback(); // 0x00000001806C61B0-0x00000001806C62A0
	public void alphaExample(); // 0x00000001806C5B50-0x00000001806C5C30
	public void moveLocalExample(); // 0x00000001806C6830-0x00000001806C6980
	public void rotateAroundExample(); // 0x00000001806C6CC0-0x00000001806C6D90
	public void loopPause(); // 0x00000001806C63F0-0x00000001806C6430
	public void loopResume(); // 0x00000001806C6430-0x00000001806C6470
	public void punchTest(); // 0x00000001806C6C60-0x00000001806C6CC0
}

