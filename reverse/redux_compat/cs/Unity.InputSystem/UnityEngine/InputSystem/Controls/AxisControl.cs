/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

// Image 4: Unity.InputSystem.dll - Assembly: Unity.InputSystem, Version=1.19.0.0, Culture=neutral, PublicKeyToken=null - Types 6023-6671

namespace UnityEngine.InputSystem.Controls
{
	public class AxisControl : InputControl<float> // TypeDefIndex: 6559
	{
		// Fields
		public Clamp clamp; // 0x108
		public float clampMin; // 0x10C
		public float clampMax; // 0x110
		public float clampConstant; // 0x114
		public bool invert; // 0x118
		public bool normalize; // 0x119
		public float normalizeMin; // 0x11C
		public float normalizeMax; // 0x120
		public float normalizeZero; // 0x124
		public bool scale; // 0x128
		public float scaleFactor; // 0x12C
	
		// Nested types
		public enum Clamp // TypeDefIndex: 6560
		{
			None = 0,
			BeforeNormalize = 1,
			AfterNormalize = 2,
			ToConstantBeforeNormalize = 3
		}
	
		// Constructors
		public AxisControl(); // 0x0000000181CE4B10-0x0000000181CE4B80
	
		// Methods
		protected float Preprocess(float value); // 0x0000000181CE37F0-0x0000000181CE38E0
		private float Unpreprocess(float value); // 0x0000000181CE4970-0x0000000181CE49E0
		protected override void FinishSetup(); // 0x0000000181CE47D0-0x0000000181CE48B0
		public override unsafe float ReadUnprocessedValueFromState(void* statePtr); // 0x0000000181CE48B0-0x0000000181CE4970
		public override unsafe void WriteValueIntoState(float value, void* statePtr); // 0x0000000181CE49E0-0x0000000181CE4B10
		public override unsafe bool CompareValue(void* firstStatePtr, void* secondStatePtr); // 0x0000000181CE4520-0x0000000181CE45E0
		public override unsafe float EvaluateMagnitude(void* statePtr); // 0x0000000181CE46C0-0x0000000181CE47D0
		private float EvaluateMagnitude(float value); // 0x0000000181CE45E0-0x0000000181CE46C0
		protected override FourCC CalculateOptimizedControlDataType(); // 0x0000000181CE4440-0x0000000181CE4520
	}
}
