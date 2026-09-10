/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using EasyUI.PickerWheelUI;
using UnityEngine;
using UnityEngine.Events;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

[DisallowMultipleComponent]
public class WheelSpinEngine : MonoBehaviour // TypeDefIndex: 1157
{
	// Fields
	public const float CruiseSpeed = 480f; // Metadata: 0x0068C646
	public const float AccelTime = 0.35f; // Metadata: 0x0068C64A
	public const float DecelMin = 2.2f; // Metadata: 0x0068C64E
	public const float DecelMax = 3.2f; // Metadata: 0x0068C652
	public const float AbortTime = 0.8f; // Metadata: 0x0068C656
	public UnityAction OnTick; // 0x20
	private Transform _circle; // 0x28
	private int _pieceCount; // 0x30
	private float _pieceAngle; // 0x34
	private State _state; // 0x38
	private float _angle; // 0x3C
	private float _speed; // 0x40
	private float _stateTime; // 0x44
	private float _elapsed; // 0x48
	private float _decelDuration; // 0x4C
	private float _decelStartAngle; // 0x50
	private float _v0; // 0x54
	private float _a; // 0x58
	private float _b; // 0x5C
	private float _targetAngle; // 0x60
	private Action _onStopped; // 0x68
	private float _tickAccum; // 0x70

	// Properties
	public State Current { get; } // 0x000000018056F320-0x000000018056F330 
	public bool IsSpinning { get; } // 0x000000018056F340-0x000000018056F350 
	public bool IsWaitingForServer { get; } // 0x000000018056F350-0x000000018056F370 
	public float Elapsed { get; } // 0x000000018056F330-0x000000018056F340 

	// Nested types
	public enum State // TypeDefIndex: 1158
	{
		Idle = 0,
		Accel = 1,
		Cruise = 2,
		Decel = 3,
		Aborting = 4
	}

	// Constructors
	public WheelSpinEngine(); // 0x000000018056F300-0x000000018056F320

	// Methods
	public void Bind(PickerWheel wheel); // 0x000000018056EAD0-0x000000018056EBF0
	public void Stop(); // 0x000000018056ED40-0x000000018056ED80
	private void OnDisable(); // 0x000000018056ED40-0x000000018056ED80
	public void BeginFreeSpin(); // 0x000000018056EA10-0x000000018056EAD0
	public void ResolveTo(int slotIndex, Action onStopped); // 0x000000018056ED80-0x000000018056EFA0
	public void Abort(); // 0x000000018056E790-0x000000018056E850
	private void Update(); // 0x000000018056EFA0-0x000000018056F300
	private void Apply(float previous); // 0x000000018056E850-0x000000018056EA10
	private void EmitTicks(float previous, float current); // 0x000000018056EBF0-0x000000018056ED10
	private static float Norm(float deg); // 0x000000018056ED10-0x000000018056ED40
}

