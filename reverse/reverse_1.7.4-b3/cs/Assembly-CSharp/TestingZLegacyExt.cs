/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public class TestingZLegacyExt : MonoBehaviour // TypeDefIndex: 299
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
	public enum TimingType // TypeDefIndex: 300
	{
		SteadyNormalTime = 0,
		IgnoreTimeScale = 1,
		HalfTimeScale = 2,
		VariableTimeScale = 3,
		Length = 4
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class __c // TypeDefIndex: 301
	{
		// Fields
		public static readonly __c __9; // 0x00
		public static Action<float> __9__20_0; // 0x08

		// Constructors
		static __c(); // 0x0000000180D85EC0-0x0000000180D85F60
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _cycleThroughExamples_b__20_0(float val); // 0x0000000180D82B20-0x0000000180D82B80
	}

	// Constructors
	public TestingZLegacyExt(); // 0x0000000180D85BB0-0x0000000180D85EC0

	// Methods
	private void Start(); // 0x0000000180D82B80-0x0000000180D82D30
	private void pauseNow(); // 0x0000000180D82D30-0x0000000180D82DE0
	private void OnGUI(); // 0x0000000180D82DE0-0x0000000180D830B0
	private void endlessCallback(); // 0x0000000180D830B0-0x0000000180D83120
	private void cycleThroughExamples(); // 0x0000000180D83120-0x0000000180D83590
	public void updateValue3Example(); // 0x0000000180D83590-0x0000000180D838A0
	public void updateValue3ExampleUpdate(Vector3 val); // 0x000000018028A320-0x000000018028A330
	public void updateValue3ExampleCallback(Vector3 val); // 0x0000000180D838A0-0x0000000180D838F0
	public void loopTestClamp(); // 0x0000000180D838F0-0x0000000180D83BA0
	public void loopTestPingPong(); // 0x0000000180D83BA0-0x0000000180D83E20
	public void colorExample(); // 0x0000000180D83E20-0x0000000180D83F40
	public void moveOnACurveExample(); // 0x0000000180D83F40-0x0000000180D844E0
	public void customTweenExample(); // 0x0000000180D844E0-0x0000000180D84760
	public void moveExample(); // 0x0000000180D84760-0x0000000180D84860
	public void rotateExample(); // 0x0000000180D84860-0x0000000180D84B20
	public void rotateOnUpdate(float val); // 0x000000018028A320-0x000000018028A330
	public void rotateFinished(object hash); // 0x0000000180D84B20-0x0000000180D84C40
	public void scaleExample(); // 0x0000000180D84C40-0x0000000180D84E20
	public void updateValueExample(); // 0x0000000180D84E20-0x0000000180D850F0
	public void updateValueExampleCallback(float val, object hash); // 0x0000000180D850F0-0x0000000180D85200
	public void delayedCallExample(); // 0x0000000180D85200-0x0000000180D85310
	public void delayedCallExampleCallback(); // 0x0000000180D85310-0x0000000180D854F0
	public void alphaExample(); // 0x0000000180D854F0-0x0000000180D85660
	public void moveLocalExample(); // 0x0000000180D85660-0x0000000180D858A0
	public void rotateAroundExample(); // 0x0000000180D858A0-0x0000000180D859E0
	public void loopPause(); // 0x0000000180D859E0-0x0000000180D85A70
	public void loopResume(); // 0x0000000180D85A70-0x0000000180D85B00
	public void punchTest(); // 0x0000000180D85B00-0x0000000180D85BB0
}

