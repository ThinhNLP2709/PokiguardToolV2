/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace DentedPixel.LTExamples
{
	public class TestingUnitTests : MonoBehaviour // TypeDefIndex: 2924
	{
		// Fields
		public GameObject cube1; // 0x20
		public GameObject cube2; // 0x28
		public GameObject cube3; // 0x30
		public GameObject cube4; // 0x38
		public GameObject cubeAlpha1; // 0x40
		public GameObject cubeAlpha2; // 0x48
		private bool eventGameObjectWasCalled; // 0x50
		private bool eventGeneralWasCalled; // 0x51
		private int lt1Id; // 0x54
		private LTDescr lt2; // 0x58
		private LTDescr lt3; // 0x60
		private LTDescr lt4; // 0x68
		private LTDescr[] groupTweens; // 0x70
		private GameObject[] groupGOs; // 0x78
		private int groupTweensCnt; // 0x80
		private int rotateRepeat; // 0x84
		private int rotateRepeatAngle; // 0x88
		private GameObject boxNoCollider; // 0x90
		private float timeElapsedNormalTimeScale; // 0x98
		private float timeElapsedIgnoreTimeScale; // 0x9C
		private bool pauseTweenDidFinish; // 0xA0
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 2925
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Action __9__22_3; // 0x08
			public static Action __9__22_22; // 0x10
			public static Action __9__22_7; // 0x18
			public static Action<float> __9__22_12; // 0x20
			public static Action __9__22_18; // 0x28
			public static Action __9__26_0; // 0x30
	
			// Constructors
			static __c(); // 0x0000000180D56700-0x0000000180D567A0
			public __c(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Start_b__22_3(); // 0x0000000180D567A0-0x0000000180D56810
			internal void _Start_b__22_22(); // 0x000000018028A320-0x000000018028A330
			internal void _Start_b__22_7(); // 0x0000000180D56810-0x0000000180D56880
			internal void _Start_b__22_12(float val); // 0x0000000180D56880-0x0000000180D56910
			internal void _Start_b__22_18(); // 0x0000000180D56910-0x0000000180D569D0
			internal void _pauseTimeNow_b__26_0(); // 0x0000000180D569D0-0x0000000180D56A20
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass22_0 // TypeDefIndex: 2926
		{
			// Fields
			public TestingUnitTests __4__this; // 0x10
			public GameObject[] cubes; // 0x18
			public int[] tweenIds; // 0x20
			public int onCompleteCount; // 0x28
			public GameObject cubeToTrans; // 0x30
			public Vector3 cubeDestEnd; // 0x38
			public GameObject cubeSpline; // 0x48
			public int jumpTimeId; // 0x50
			public GameObject jumpCube; // 0x58
			public GameObject zeroCube; // 0x60
			public GameObject cubeScale; // 0x68
			public GameObject cubeRotate; // 0x70
			public GameObject cubeRotateA; // 0x78
			public GameObject cubeRotateB; // 0x80
			public float onStartTime; // 0x88
			public Vector3 beforePos; // 0x8C
			public Vector3 beforePos2; // 0x98
			public int totalEasingCheck; // 0xA4
			public int totalEasingCheckSuccess; // 0xA8
			public bool value2UpdateCalled; // 0xAC
			public Action __9__21; // 0xB0
	
			// Constructors
			public __c__DisplayClass22_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Start_b__0(); // 0x0000000180D56A20-0x0000000180D56B40
			internal void _Start_b__1(); // 0x0000000180D56B40-0x0000000180D56D80
			internal void _Start_b__21(); // 0x0000000180D56D80-0x0000000180D56E00
			internal void _Start_b__2(); // 0x0000000180D56E00-0x0000000180D56F60
			internal void _Start_b__4(); // 0x0000000180D56F60-0x0000000180D57100
			internal void _Start_b__5(); // 0x0000000180D57100-0x0000000180D57410
			internal void _Start_b__6(); // 0x0000000180D57410-0x0000000180D57600
			internal void _Start_b__8(); // 0x0000000180D57600-0x0000000180D57880
			internal void _Start_b__9(); // 0x0000000180D57880-0x0000000180D57B40
			internal void _Start_b__10(); // 0x0000000180D57B40-0x0000000180D57E10
			internal void _Start_b__11(); // 0x0000000180D57E10-0x0000000180D58110
			internal void _Start_b__13(object completeObj); // 0x0000000180D58110-0x0000000180D58320
			internal void _Start_b__14(); // 0x0000000180D58320-0x0000000180D58650
			internal void _Start_b__15(); // 0x0000000180D58650-0x0000000180D586B0
			internal void _Start_b__16(); // 0x0000000180D586B0-0x0000000180D58890
			internal void _Start_b__17(); // 0x0000000180D58890-0x0000000180D58D20
			internal void _Start_b__19(Vector2 value); // 0x0000000180D58D20-0x0000000180D58D30
			internal void _Start_b__20(); // 0x0000000180D58D30-0x0000000180D58DB0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass22_1 // TypeDefIndex: 2927
		{
			// Fields
			public float beforeX; // 0x10
			public __c__DisplayClass22_0 CS___8__locals1; // 0x18
	
			// Constructors
			public __c__DisplayClass22_1(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Start_b__23(); // 0x0000000180D58E00-0x0000000180D59320
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass22_2 // TypeDefIndex: 2928
		{
			// Fields
			public int totalTweenTypeLength; // 0x10
			public __c__DisplayClass22_0 CS___8__locals2; // 0x18
			public Action<object> __9__24; // 0x20
	
			// Constructors
			public __c__DisplayClass22_2(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Start_b__24(object obj); // 0x0000000180D59320-0x0000000180D594D0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass24_0 // TypeDefIndex: 2929
		{
			// Fields
			public TestingUnitTests __4__this; // 0x10
			public int pauseCount; // 0x18
			public GameObject cubeRound; // 0x20
			public Vector3 onStartPos; // 0x28
			public Vector3 onStartPosSpline; // 0x34
			public GameObject cubeSpline; // 0x40
			public GameObject cubeSeq; // 0x48
			public GameObject cubeBounds; // 0x50
			public bool didPassBounds; // 0x58
			public Vector3 failPoint; // 0x5C
			public int setOnStartNum; // 0x68
			public bool setPosOnUpdate; // 0x6C
			public int setPosNum; // 0x70
			public bool hasGroupTweensCheckStarted; // 0x74
			public float previousXlt4; // 0x78
			public bool onUpdateWasCalled; // 0x7C
			public float start; // 0x80
			public float expectedTime; // 0x84
			public bool didGetCorrectOnUpdate; // 0x88
			public Action __9__13; // 0x90
			public Action<Vector3> __9__14; // 0x98
			public Action __9__16; // 0xA0
			public Action<object> __9__15; // 0xA8
	
			// Constructors
			public __c__DisplayClass24_0(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _timeBasedTesting_b__0(); // 0x0000000180D594D0-0x0000000180D59530
			internal void _timeBasedTesting_b__1(); // 0x0000000180D59530-0x0000000180D59590
			internal void _timeBasedTesting_b__2(float val); // 0x0000000180D59590-0x0000000180D595A0
			internal void _timeBasedTesting_b__3(); // 0x0000000180D595A0-0x0000000180D59810
			internal void _timeBasedTesting_b__4(); // 0x0000000180D59810-0x0000000180D59CF0
			internal void _timeBasedTesting_b__5(); // 0x0000000180D59CF0-0x0000000180D5A070
			internal void _timeBasedTesting_b__6(float val); // 0x0000000180D5A070-0x0000000180D5A4B0
			internal void _timeBasedTesting_b__7(); // 0x0000000180D5A4B0-0x0000000180D5A640
			internal void _timeBasedTesting_b__13(); // 0x0000000180D5A640-0x0000000180D5A650
			internal void _timeBasedTesting_b__14(Vector3 newPosition); // 0x0000000180D5A650-0x0000000180D5A710
			internal void _timeBasedTesting_b__15(object param); // 0x0000000180D5A710-0x0000000180D5AAA0
			internal void _timeBasedTesting_b__16(); // 0x0000000180D5AAA0-0x0000000180D5AE10
			internal void _timeBasedTesting_b__8(); // 0x0000000180D5AE10-0x0000000180D5B2E0
			internal void _timeBasedTesting_b__9(float val); // 0x0000000180D5B2E0-0x0000000180D5B2F0
			internal void _timeBasedTesting_b__10(); // 0x0000000180D5B2F0-0x0000000180D5B6D0
			internal void _timeBasedTesting_b__11(Vector3 val); // 0x0000000180D5B6D0-0x0000000180D5B720
			internal void _timeBasedTesting_b__12(); // 0x0000000180D5B720-0x0000000180D5B7A0
		}
	
		[CompilerGenerated]
		private sealed class _lotsOfCancels_d__25 : IEnumerator<object> // TypeDefIndex: 2930
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public TestingUnitTests __4__this; // 0x20
			private int _cubeCount_5__2; // 0x28
			private int[] _tweensA_5__3; // 0x30
			private GameObject[] _aGOs_5__4; // 0x38
			private int[] _tweensB_5__5; // 0x40
			private GameObject[] _bGOs_5__6; // 0x48
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _lotsOfCancels_d__25(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x0000000180D5B7A0-0x0000000180D5B900
			private bool MoveNext(); // 0x0000000180D5B900-0x0000000180D5D2A0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180D5D2A0-0x0000000180D5D2E0
		}
	
		[CompilerGenerated]
		private sealed class _pauseTimeNow_d__26 : IEnumerator<object> // TypeDefIndex: 2931
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public TestingUnitTests __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _pauseTimeNow_d__26(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B6B60-0x00000001802B6B70
			private bool MoveNext(); // 0x0000000180D5D2E0-0x0000000180D5D560
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180D5D560-0x0000000180D5D5A0
		}
	
		[CompilerGenerated]
		private sealed class _timeBasedTesting_d__24 : IEnumerator<object> // TypeDefIndex: 2932
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public TestingUnitTests __4__this; // 0x20
			private __c__DisplayClass24_0 __8__1; // 0x28
			private int _descriptionMatchCount_5__2; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x000000018028EDE0-0x000000018028EDF0 
	
			// Constructors
			[DebuggerHidden]
			public _timeBasedTesting_d__24(int __1__state); // 0x000000018028E160-0x000000018028E170
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802B51C0-0x00000001802B5230
			private bool MoveNext(); // 0x0000000180D5D5A0-0x0000000180D5FEC0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180D5FEC0-0x0000000180D5FF60
		}
	
		// Constructors
		public TestingUnitTests(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void Awake(); // 0x0000000180D53590-0x0000000180D536E0
		private void Start(); // 0x0000000180D536E0-0x0000000180D56080
		private GameObject cubeNamed(string name); // 0x0000000180D56080-0x0000000180D56120
		[IteratorStateMachine(typeof(_timeBasedTesting_d__24))]
		private IEnumerator timeBasedTesting(); // 0x0000000180D56120-0x0000000180D561C0
		[IteratorStateMachine(typeof(_lotsOfCancels_d__25))]
		private IEnumerator lotsOfCancels(); // 0x0000000180D561C0-0x0000000180D56260
		[IteratorStateMachine(typeof(_pauseTimeNow_d__26))]
		private IEnumerator pauseTimeNow(); // 0x0000000180D56260-0x0000000180D56300
		private void rotateRepeatFinished(); // 0x0000000180D56300-0x0000000180D563F0
		private void rotateRepeatAllFinished(); // 0x0000000180D563F0-0x0000000180D56660
		private void eventGameObjectCalled(LTEvent e); // 0x0000000180B99D90-0x0000000180B99DA0
		private void eventGeneralCalled(LTEvent e); // 0x0000000180D56660-0x0000000180D56670
		[CompilerGenerated]
		private void _lotsOfCancels_b__25_0(); // 0x0000000180D56670-0x0000000180D56680
		[CompilerGenerated]
		private void _pauseTimeNow_b__26_1(); // 0x0000000180D56680-0x0000000180D56700
	}
}
