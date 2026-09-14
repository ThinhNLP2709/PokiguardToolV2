/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using EasyUI.PickerWheelUI;
using UnityEngine;
using UnityEngine.Events;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

[DisallowMultipleComponent]
public class WheelSpinEngine : MonoBehaviour // TypeDefIndex: 1564
{
	// Fields
	public const float CruiseSpeed = 480f; // Metadata: 0x005F1213
	public const float AccelTime = 0.35f; // Metadata: 0x005F1217
	public const float DecelMin = 2.2f; // Metadata: 0x005F121B
	public const float DecelMax = 3.2f; // Metadata: 0x005F121F
	public const float AbortTime = 0.8f; // Metadata: 0x005F1223
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
	public State Current { get; } // 0x0000000180855D10-0x0000000180855D20 
	public bool IsSpinning { get; } // 0x0000000180855D20-0x0000000180855D30 
	public bool IsWaitingForServer { get; } // 0x0000000180855D30-0x0000000180855D50 
	public float Elapsed { get; } // 0x0000000180855D50-0x0000000180855D60 

	// Nested types
	public enum State // TypeDefIndex: 1565
	{
		Idle = 0,
		Accel = 1,
		Cruise = 2,
		Decel = 3,
		Aborting = 4
	}

	// Constructors
	public WheelSpinEngine(); // 0x0000000180856EB0-0x0000000180856F10

	// Methods
	public void Bind(PickerWheel wheel); // 0x0000000180855D60-0x0000000180856090
	public void Stop(); // 0x0000000180856090-0x00000001808560F0
	private void OnDisable(); // 0x0000000180856090-0x00000001808560F0
	public void BeginFreeSpin(); // 0x00000001808560F0-0x0000000180856300
	public void ResolveTo(int slotIndex, Action onStopped); // 0x0000000180856300-0x00000001808565F0
	public void Abort(); // 0x00000001808565F0-0x00000001808567D0
	private void Update(); // 0x00000001808567D0-0x0000000180856BC0
	private void Apply(float previous); // 0x0000000180856BC0-0x0000000180856DA0
	private void EmitTicks(float previous, float current); // 0x0000000180856DA0-0x0000000180856E80
	private static float Norm(float deg); // 0x0000000180856E80-0x0000000180856EB0
}

