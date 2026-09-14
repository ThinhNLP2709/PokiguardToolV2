/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using EasyUI.PickerWheelUI;
using UnityEngine;
using UnityEngine.Events;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

[DisallowMultipleComponent]
public class WheelSpinEngine : MonoBehaviour // TypeDefIndex: 1562
{
	// Fields
	public const float CruiseSpeed = 480f; // Metadata: 0x005EFE46
	public const float AccelTime = 0.35f; // Metadata: 0x005EFE4A
	public const float DecelMin = 2.2f; // Metadata: 0x005EFE4E
	public const float DecelMax = 3.2f; // Metadata: 0x005EFE52
	public const float AbortTime = 0.8f; // Metadata: 0x005EFE56
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
	public State Current { get; } // 0x0000000180853A80-0x0000000180853A90 
	public bool IsSpinning { get; } // 0x0000000180853A90-0x0000000180853AA0 
	public bool IsWaitingForServer { get; } // 0x0000000180853AA0-0x0000000180853AC0 
	public float Elapsed { get; } // 0x0000000180853AC0-0x0000000180853AD0 

	// Nested types
	public enum State // TypeDefIndex: 1563
	{
		Idle = 0,
		Accel = 1,
		Cruise = 2,
		Decel = 3,
		Aborting = 4
	}

	// Constructors
	public WheelSpinEngine(); // 0x0000000180854C20-0x0000000180854C80

	// Methods
	public void Bind(PickerWheel wheel); // 0x0000000180853AD0-0x0000000180853E00
	public void Stop(); // 0x0000000180853E00-0x0000000180853E60
	private void OnDisable(); // 0x0000000180853E00-0x0000000180853E60
	public void BeginFreeSpin(); // 0x0000000180853E60-0x0000000180854070
	public void ResolveTo(int slotIndex, Action onStopped); // 0x0000000180854070-0x0000000180854360
	public void Abort(); // 0x0000000180854360-0x0000000180854540
	private void Update(); // 0x0000000180854540-0x0000000180854930
	private void Apply(float previous); // 0x0000000180854930-0x0000000180854B10
	private void EmitTicks(float previous, float current); // 0x0000000180854B10-0x0000000180854BF0
	private static float Norm(float deg); // 0x0000000180854BF0-0x0000000180854C20
}

