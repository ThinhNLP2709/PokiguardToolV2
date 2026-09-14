/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace DentedPixel.LTExamples
{
	public class TestingUnitTests : MonoBehaviour // TypeDefIndex: 2917
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
		private sealed class __c // TypeDefIndex: 2918
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
			static __c(); // 0x0000000180D48990-0x0000000180D48A30
			public __c(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Start_b__22_3(); // 0x0000000180D48A30-0x0000000180D48AA0
			internal void _Start_b__22_22(); // 0x000000018028A320-0x000000018028A330
			internal void _Start_b__22_7(); // 0x0000000180D48AA0-0x0000000180D48B10
			internal void _Start_b__22_12(float val); // 0x0000000180D48B10-0x0000000180D48BA0
			internal void _Start_b__22_18(); // 0x0000000180D48BA0-0x0000000180D48C60
			internal void _pauseTimeNow_b__26_0(); // 0x0000000180D48C60-0x0000000180D48CB0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass22_0 // TypeDefIndex: 2919
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
			internal void _Start_b__0(); // 0x0000000180D48CB0-0x0000000180D48DD0
			internal void _Start_b__1(); // 0x0000000180D48DD0-0x0000000180D49010
			internal void _Start_b__21(); // 0x0000000180D49010-0x0000000180D49090
			internal void _Start_b__2(); // 0x0000000180D49090-0x0000000180D491F0
			internal void _Start_b__4(); // 0x0000000180D491F0-0x0000000180D49390
			internal void _Start_b__5(); // 0x0000000180D49390-0x0000000180D496A0
			internal void _Start_b__6(); // 0x0000000180D496A0-0x0000000180D49890
			internal void _Start_b__8(); // 0x0000000180D49890-0x0000000180D49B10
			internal void _Start_b__9(); // 0x0000000180D49B10-0x0000000180D49DD0
			internal void _Start_b__10(); // 0x0000000180D49DD0-0x0000000180D4A0A0
			internal void _Start_b__11(); // 0x0000000180D4A0A0-0x0000000180D4A3A0
			internal void _Start_b__13(object completeObj); // 0x0000000180D4A3A0-0x0000000180D4A5B0
			internal void _Start_b__14(); // 0x0000000180D4A5B0-0x0000000180D4A8E0
			internal void _Start_b__15(); // 0x0000000180D4A8E0-0x0000000180D4A940
			internal void _Start_b__16(); // 0x0000000180D4A940-0x0000000180D4AB20
			internal void _Start_b__17(); // 0x0000000180D4AB20-0x0000000180D4AFB0
			internal void _Start_b__19(Vector2 value); // 0x0000000180D4AFB0-0x0000000180D4AFC0
			internal void _Start_b__20(); // 0x0000000180D4AFC0-0x0000000180D4B040
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass22_1 // TypeDefIndex: 2920
		{
			// Fields
			public float beforeX; // 0x10
			public __c__DisplayClass22_0 CS___8__locals1; // 0x18
	
			// Constructors
			public __c__DisplayClass22_1(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Start_b__23(); // 0x0000000180D4B040-0x0000000180D4B560
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass22_2 // TypeDefIndex: 2921
		{
			// Fields
			public int totalTweenTypeLength; // 0x10
			public __c__DisplayClass22_0 CS___8__locals2; // 0x18
			public Action<object> __9__24; // 0x20
	
			// Constructors
			public __c__DisplayClass22_2(); // 0x000000018028A320-0x000000018028A330
	
			// Methods
			internal void _Start_b__24(object obj); // 0x0000000180D4B560-0x0000000180D4B710
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass24_0 // TypeDefIndex: 2922
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
			internal void _timeBasedTesting_b__0(); // 0x0000000180D4B710-0x0000000180D4B770
			internal void _timeBasedTesting_b__1(); // 0x0000000180D4B770-0x0000000180D4B7D0
			internal void _timeBasedTesting_b__2(float val); // 0x0000000180D4B7D0-0x0000000180D4B7E0
			internal void _timeBasedTesting_b__3(); // 0x0000000180D4B7E0-0x0000000180D4BA50
			internal void _timeBasedTesting_b__4(); // 0x0000000180D4BA50-0x0000000180D4BF30
			internal void _timeBasedTesting_b__5(); // 0x0000000180D4BF30-0x0000000180D4C2B0
			internal void _timeBasedTesting_b__6(float val); // 0x0000000180D4C2B0-0x0000000180D4C6F0
			internal void _timeBasedTesting_b__7(); // 0x0000000180D4C6F0-0x0000000180D4C880
			internal void _timeBasedTesting_b__13(); // 0x0000000180D4C880-0x0000000180D4C890
			internal void _timeBasedTesting_b__14(Vector3 newPosition); // 0x0000000180D4C890-0x0000000180D4C950
			internal void _timeBasedTesting_b__15(object param); // 0x0000000180D4C950-0x0000000180D4CCE0
			internal void _timeBasedTesting_b__16(); // 0x0000000180D4CCE0-0x0000000180D4D050
			internal void _timeBasedTesting_b__8(); // 0x0000000180D4D050-0x0000000180D4D520
			internal void _timeBasedTesting_b__9(float val); // 0x0000000180D4D520-0x0000000180D4D530
			internal void _timeBasedTesting_b__10(); // 0x0000000180D4D530-0x0000000180D4D910
			internal void _timeBasedTesting_b__11(Vector3 val); // 0x0000000180D4D910-0x0000000180D4D960
			internal void _timeBasedTesting_b__12(); // 0x0000000180D4D960-0x0000000180D4D9E0
		}
	
		[CompilerGenerated]
		private sealed class _lotsOfCancels_d__25 : IEnumerator<object> // TypeDefIndex: 2923
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
			void IDisposable.Dispose(); // 0x0000000180D4D9E0-0x0000000180D4DB40
			private bool MoveNext(); // 0x0000000180D4DB40-0x0000000180D4F4E0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180D4F4E0-0x0000000180D4F520
		}
	
		[CompilerGenerated]
		private sealed class _pauseTimeNow_d__26 : IEnumerator<object> // TypeDefIndex: 2924
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
			void IDisposable.Dispose(); // 0x00000001802B6B30-0x00000001802B6B40
			private bool MoveNext(); // 0x0000000180D4F520-0x0000000180D4F7A0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180D4F7A0-0x0000000180D4F7E0
		}
	
		[CompilerGenerated]
		private sealed class _timeBasedTesting_d__24 : IEnumerator<object> // TypeDefIndex: 2925
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
			private bool MoveNext(); // 0x0000000180D4F7E0-0x0000000180D52100
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000180D52100-0x0000000180D521A0
		}
	
		// Constructors
		public TestingUnitTests(); // 0x000000018028A560-0x000000018028A5B0
	
		// Methods
		private void Awake(); // 0x0000000180D45820-0x0000000180D45970
		private void Start(); // 0x0000000180D45970-0x0000000180D48310
		private GameObject cubeNamed(string name); // 0x0000000180D48310-0x0000000180D483B0
		[IteratorStateMachine(typeof(_timeBasedTesting_d__24))]
		private IEnumerator timeBasedTesting(); // 0x0000000180D483B0-0x0000000180D48450
		[IteratorStateMachine(typeof(_lotsOfCancels_d__25))]
		private IEnumerator lotsOfCancels(); // 0x0000000180D48450-0x0000000180D484F0
		[IteratorStateMachine(typeof(_pauseTimeNow_d__26))]
		private IEnumerator pauseTimeNow(); // 0x0000000180D484F0-0x0000000180D48590
		private void rotateRepeatFinished(); // 0x0000000180D48590-0x0000000180D48680
		private void rotateRepeatAllFinished(); // 0x0000000180D48680-0x0000000180D488F0
		private void eventGameObjectCalled(LTEvent e); // 0x0000000180B8C970-0x0000000180B8C980
		private void eventGeneralCalled(LTEvent e); // 0x0000000180D488F0-0x0000000180D48900
		[CompilerGenerated]
		private void _lotsOfCancels_b__25_0(); // 0x0000000180D48900-0x0000000180D48910
		[CompilerGenerated]
		private void _pauseTimeNow_b__26_1(); // 0x0000000180D48910-0x0000000180D48990
	}
}
