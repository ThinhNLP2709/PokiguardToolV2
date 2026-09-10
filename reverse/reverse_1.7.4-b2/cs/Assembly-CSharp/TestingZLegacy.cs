/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class TestingZLegacy : MonoBehaviour // TypeDefIndex: 297
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
	public delegate void NextFunc(); // TypeDefIndex: 298; 0x00000001802EBAF0-0x00000001802EBB90

	public enum TimingType // TypeDefIndex: 299
	{
		SteadyNormalTime = 0,
		IgnoreTimeScale = 1,
		HalfTimeScale = 2,
		VariableTimeScale = 3,
		Length = 4
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 300
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<float> __9__20_0; // 0x08

		// Constructors
		static __c(); // 0x00000001808741F0-0x0000000180874260
		public __c(); // 0x00000001802E9CB0-0x00000001802E9CC0

		// Methods
		internal void _cycleThroughExamples_b__20_0(float val); // 0x0000000180873820-0x0000000180873830
	}

	// Constructors
	public TestingZLegacy(); // 0x0000000180871500-0x00000001808717E0

	// Methods
	private void Awake(); // 0x0000000180871250-0x00000001808712A0
	private void Start(); // 0x0000000180871400-0x0000000180871500
	private void pauseNow(); // 0x0000000180872B20-0x0000000180872B80
	private void OnGUI(); // 0x00000001808712A0-0x0000000180871400
	private void endlessCallback(); // 0x0000000180872140-0x00000001808721A0
	private void cycleThroughExamples(); // 0x0000000180871B70-0x0000000180871EF0
	public void updateValue3Example(); // 0x0000000180873280-0x00000001808734F0
	public void updateValue3ExampleUpdate(Vector3 val); // 0x00000001802EB6C0-0x00000001802EB6D0
	public void updateValue3ExampleCallback(Vector3 val); // 0x0000000180873230-0x0000000180873280
	public void loopTestClamp(); // 0x0000000180872280-0x0000000180872420
	public void loopTestPingPong(); // 0x0000000180872420-0x00000001808725A0
	public void colorExample(); // 0x00000001808718E0-0x00000001808719D0
	public void moveOnACurveExample(); // 0x0000000180872860-0x0000000180872B20
	public void customTweenExample(); // 0x00000001808719D0-0x0000000180871B70
	public void moveExample(); // 0x00000001808725A0-0x00000001808726D0
	public void rotateExample(); // 0x0000000180872D40-0x0000000180872FD0
	public void rotateOnUpdate(float val); // 0x00000001802EB6C0-0x00000001802EB6D0
	public void rotateFinished(object hash); // 0x0000000180872FD0-0x00000001808730D0
	public void scaleExample(); // 0x00000001808730D0-0x0000000180873230
	public void updateValueExample(); // 0x0000000180873590-0x00000001808737A0
	public void updateValueExampleCallback(float val, object hash); // 0x00000001808734F0-0x0000000180873590
	public void delayedCallExample(); // 0x0000000180872050-0x0000000180872140
	public void delayedCallExampleCallback(); // 0x0000000180871EF0-0x0000000180872050
	public void alphaExample(); // 0x00000001808717E0-0x00000001808718E0
	public void moveLocalExample(); // 0x00000001808726D0-0x0000000180872860
	public void rotateAroundExample(); // 0x0000000180872C20-0x0000000180872D40
	public void loopPause(); // 0x00000001808721A0-0x0000000180872210
	public void loopResume(); // 0x0000000180872210-0x0000000180872280
	public void punchTest(); // 0x0000000180872B80-0x0000000180872C20
}

