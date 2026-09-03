/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace DentedPixel.LTExamples
{
	public class TestingUnitTests : MonoBehaviour // TypeDefIndex: 2015
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
		private sealed class __c // TypeDefIndex: 2016
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
			static __c(); // 0x000000018067B900-0x000000018067B970
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Start_b__22_3(); // 0x0000000180677A80-0x0000000180677AE0
			internal void _Start_b__22_22(); // 0x00000001802E76C0-0x00000001802E76D0
			internal void _Start_b__22_7(); // 0x0000000180677AE0-0x0000000180677B40
			internal void _Start_b__22_12(float val); // 0x0000000180677980-0x0000000180677A00
			internal void _Start_b__22_18(); // 0x0000000180677A00-0x0000000180677A80
			internal void _pauseTimeNow_b__26_0(); // 0x0000000180677C90-0x0000000180677CA0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass22_0 // TypeDefIndex: 2017
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
			public __c__DisplayClass22_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Start_b__0(); // 0x0000000180677CA0-0x0000000180677D60
			internal void _Start_b__1(); // 0x0000000180678850-0x0000000180678A80
			internal void _Start_b__21(); // 0x0000000180678AF0-0x0000000180678B70
			internal void _Start_b__2(); // 0x0000000180678B70-0x0000000180678C50
			internal void _Start_b__4(); // 0x0000000180678C50-0x0000000180678D90
			internal void _Start_b__5(); // 0x0000000180678D90-0x0000000180678F80
			internal void _Start_b__6(); // 0x0000000180678F80-0x00000001806790B0
			internal void _Start_b__8(); // 0x00000001806790B0-0x0000000180679220
			internal void _Start_b__9(); // 0x0000000180679220-0x0000000180679390
			internal void _Start_b__10(); // 0x0000000180677D60-0x0000000180677ED0
			internal void _Start_b__11(); // 0x0000000180677ED0-0x00000001806780C0
			internal void _Start_b__13(object completeObj); // 0x00000001806780C0-0x0000000180678200
			internal void _Start_b__14(); // 0x0000000180678200-0x00000001806783F0
			internal void _Start_b__15(); // 0x00000001806783F0-0x0000000180678410
			internal void _Start_b__16(); // 0x0000000180678410-0x0000000180678510
			internal void _Start_b__17(); // 0x0000000180678510-0x0000000180678840
			internal void _Start_b__19(Vector2 value); // 0x0000000180678840-0x0000000180678850
			internal void _Start_b__20(); // 0x0000000180678A80-0x0000000180678AF0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass22_1 // TypeDefIndex: 2018
		{
			// Fields
			public float beforeX; // 0x10
			public __c__DisplayClass22_0 CS___8__locals1; // 0x18
	
			// Constructors
			public __c__DisplayClass22_1(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Start_b__23(); // 0x0000000180679390-0x00000001806796C0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass22_2 // TypeDefIndex: 2019
		{
			// Fields
			public int totalTweenTypeLength; // 0x10
			public __c__DisplayClass22_0 CS___8__locals2; // 0x18
			public Action<object> __9__24; // 0x20
	
			// Constructors
			public __c__DisplayClass22_2(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _Start_b__24(object obj); // 0x00000001806796C0-0x0000000180679800
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass24_0 // TypeDefIndex: 2020
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
			public __c__DisplayClass24_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _timeBasedTesting_b__0(); // 0x0000000180679800-0x0000000180679830
			internal void _timeBasedTesting_b__1(); // 0x000000018067A0F0-0x000000018067A120
			internal void _timeBasedTesting_b__2(float val); // 0x000000018067A120-0x000000018067A130
			internal void _timeBasedTesting_b__3(); // 0x000000018067A130-0x000000018067A2E0
			internal void _timeBasedTesting_b__4(); // 0x000000018067A2E0-0x000000018067A6B0
			internal void _timeBasedTesting_b__5(); // 0x000000018067A6B0-0x000000018067A8A0
			internal void _timeBasedTesting_b__6(float val); // 0x000000018067A8A0-0x000000018067AA50
			internal void _timeBasedTesting_b__7(); // 0x000000018067AA50-0x000000018067ABF0
			internal void _timeBasedTesting_b__13(); // 0x0000000180679B80-0x0000000180679B90
			internal void _timeBasedTesting_b__14(Vector3 newPosition); // 0x0000000180679B90-0x0000000180679BF0
			internal void _timeBasedTesting_b__15(object param); // 0x0000000180679BF0-0x0000000180679E90
			internal void _timeBasedTesting_b__16(); // 0x0000000180679E90-0x000000018067A0F0
			internal void _timeBasedTesting_b__8(); // 0x000000018067ABF0-0x000000018067AEF0
			internal void _timeBasedTesting_b__9(float val); // 0x000000018067AEF0-0x000000018067AF00
			internal void _timeBasedTesting_b__10(); // 0x0000000180679830-0x0000000180679AC0
			internal void _timeBasedTesting_b__11(Vector3 val); // 0x0000000180679AC0-0x0000000180679B10
			internal void _timeBasedTesting_b__12(); // 0x0000000180679B10-0x0000000180679B80
		}
	
		[CompilerGenerated]
		private sealed class _lotsOfCancels_d__25 : IEnumerator<object> // TypeDefIndex: 2021
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
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _lotsOfCancels_d__25(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018067CD70-0x000000018067CDD0
			private bool MoveNext(); // 0x000000018067BE60-0x000000018067CD30
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018067CD30-0x000000018067CD70
		}
	
		[CompilerGenerated]
		private sealed class _pauseTimeNow_d__26 : IEnumerator<object> // TypeDefIndex: 2022
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public TestingUnitTests __4__this; // 0x20
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _pauseTimeNow_d__26(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x000000018067CDD0-0x000000018067CFD0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018067CFD0-0x000000018067D010
		}
	
		[CompilerGenerated]
		private sealed class _timeBasedTesting_d__24 : IEnumerator<object> // TypeDefIndex: 2023
		{
			// Fields
			private int __1__state; // 0x10
			private object __2__current; // 0x18
			public TestingUnitTests __4__this; // 0x20
			private __c__DisplayClass24_0 __8__1; // 0x28
			private int _descriptionMatchCount_5__2; // 0x30
	
			// Properties
			object IEnumerator<System.Object>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _timeBasedTesting_d__24(int __1__state); // 0x00000001802F9040-0x00000001802F9070
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9D90-0x00000001802F9DC0
			private bool MoveNext(); // 0x000000018067D010-0x000000018067F3A0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018067F3A0-0x000000018067F3E0
		}
	
		// Constructors
		public TestingUnitTests(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private void Awake(); // 0x0000000180674800-0x00000001806748C0
		private void Start(); // 0x00000001806748C0-0x0000000180676A30
		private GameObject cubeNamed(string name); // 0x0000000180676AB0-0x0000000180676B40
		[IteratorStateMachine(typeof(_timeBasedTesting_d__24))]
		private IEnumerator timeBasedTesting(); // 0x0000000180676E40-0x0000000180676EB0
		[IteratorStateMachine(typeof(_lotsOfCancels_d__25))]
		private IEnumerator lotsOfCancels(); // 0x0000000180676B50-0x0000000180676BC0
		[IteratorStateMachine(typeof(_pauseTimeNow_d__26))]
		private IEnumerator pauseTimeNow(); // 0x0000000180676BC0-0x0000000180676C30
		private void rotateRepeatFinished(); // 0x0000000180676DE0-0x0000000180676E40
		private void rotateRepeatAllFinished(); // 0x0000000180676C30-0x0000000180676DE0
		private void eventGameObjectCalled(LTEvent e); // 0x00000001805FB010-0x00000001805FB020
		private void eventGeneralCalled(LTEvent e); // 0x0000000180676B40-0x0000000180676B50
		[CompilerGenerated]
		private void _lotsOfCancels_b__25_0(); // 0x0000000180676A30-0x0000000180676A40
		[CompilerGenerated]
		private void _pauseTimeNow_b__26_1(); // 0x0000000180676A40-0x0000000180676AB0
	}
}
