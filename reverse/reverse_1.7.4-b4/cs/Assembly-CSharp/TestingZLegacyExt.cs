/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

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
		static __c(); // 0x0000000180D93CA0-0x0000000180D93D40
		public __c(); // 0x000000018028A320-0x000000018028A330

		// Methods
		internal void _cycleThroughExamples_b__20_0(float val); // 0x0000000180D90900-0x0000000180D90960
	}

	// Constructors
	public TestingZLegacyExt(); // 0x0000000180D93990-0x0000000180D93CA0

	// Methods
	private void Start(); // 0x0000000180D90960-0x0000000180D90B10
	private void pauseNow(); // 0x0000000180D90B10-0x0000000180D90BC0
	private void OnGUI(); // 0x0000000180D90BC0-0x0000000180D90E90
	private void endlessCallback(); // 0x0000000180D90E90-0x0000000180D90F00
	private void cycleThroughExamples(); // 0x0000000180D90F00-0x0000000180D91370
	public void updateValue3Example(); // 0x0000000180D91370-0x0000000180D91680
	public void updateValue3ExampleUpdate(Vector3 val); // 0x000000018028A320-0x000000018028A330
	public void updateValue3ExampleCallback(Vector3 val); // 0x0000000180D91680-0x0000000180D916D0
	public void loopTestClamp(); // 0x0000000180D916D0-0x0000000180D91980
	public void loopTestPingPong(); // 0x0000000180D91980-0x0000000180D91C00
	public void colorExample(); // 0x0000000180D91C00-0x0000000180D91D20
	public void moveOnACurveExample(); // 0x0000000180D91D20-0x0000000180D922C0
	public void customTweenExample(); // 0x0000000180D922C0-0x0000000180D92540
	public void moveExample(); // 0x0000000180D92540-0x0000000180D92640
	public void rotateExample(); // 0x0000000180D92640-0x0000000180D92900
	public void rotateOnUpdate(float val); // 0x000000018028A320-0x000000018028A330
	public void rotateFinished(object hash); // 0x0000000180D92900-0x0000000180D92A20
	public void scaleExample(); // 0x0000000180D92A20-0x0000000180D92C00
	public void updateValueExample(); // 0x0000000180D92C00-0x0000000180D92ED0
	public void updateValueExampleCallback(float val, object hash); // 0x0000000180D92ED0-0x0000000180D92FE0
	public void delayedCallExample(); // 0x0000000180D92FE0-0x0000000180D930F0
	public void delayedCallExampleCallback(); // 0x0000000180D930F0-0x0000000180D932D0
	public void alphaExample(); // 0x0000000180D932D0-0x0000000180D93440
	public void moveLocalExample(); // 0x0000000180D93440-0x0000000180D93680
	public void rotateAroundExample(); // 0x0000000180D93680-0x0000000180D937C0
	public void loopPause(); // 0x0000000180D937C0-0x0000000180D93850
	public void loopResume(); // 0x0000000180D93850-0x0000000180D938E0
	public void punchTest(); // 0x0000000180D938E0-0x0000000180D93990
}

