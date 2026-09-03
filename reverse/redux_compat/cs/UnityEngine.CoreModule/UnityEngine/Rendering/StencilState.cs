/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct StencilState : IEquatable<UnityEngine.Rendering.StencilState> // TypeDefIndex: 8443
	{
		// Fields
		private byte m_Enabled; // 0x00
		private byte m_ReadMask; // 0x01
		private byte m_WriteMask; // 0x02
		private byte m_Padding; // 0x03
		private byte m_CompareFunctionFront; // 0x04
		private byte m_PassOperationFront; // 0x05
		private byte m_FailOperationFront; // 0x06
		private byte m_ZFailOperationFront; // 0x07
		private byte m_CompareFunctionBack; // 0x08
		private byte m_PassOperationBack; // 0x09
		private byte m_FailOperationBack; // 0x0A
		private byte m_ZFailOperationBack; // 0x0B
	
		// Properties
		public static StencilState defaultValue { get; } // 0x000000018226E1A0-0x000000018226E210 
		public bool enabled { get; set; } // 0x000000018226E210-0x000000018226E260 0x000000018226E270-0x000000018226E2D0
		public byte readMask { get; set; } // 0x0000000180C572C0-0x0000000180C572D0 0x0000000181CE2B40-0x0000000181CE2B50
		public byte writeMask { get; set; } // 0x000000018166C8F0-0x000000018166C900 0x0000000181CE28A0-0x0000000181CE28B0
		public CompareFunction compareFunctionFront { get; set; } // 0x00000001813282D0-0x00000001813282E0 0x0000000181CCFCF0-0x0000000181CCFD00
		public StencilOp passOperationFront { get; set; } // 0x0000000181CCF9E0-0x0000000181CCF9F0 0x000000018226E2E0-0x000000018226E2F0
		public StencilOp failOperationFront { get; set; } // 0x000000018225CCA0-0x000000018225CCB0 0x000000018226E2D0-0x000000018226E2E0
		public StencilOp zFailOperationFront { get; set; } // 0x000000018226E260-0x000000018226E270 0x000000018226E300-0x000000018226E310
		public CompareFunction compareFunctionBack { get; set; } // 0x0000000181325D60-0x0000000181325D70 0x0000000181E6F9C0-0x0000000181E6F9D0
		public StencilOp passOperationBack { get; set; } // 0x0000000181577100-0x0000000181577110 0x0000000181E6F9E0-0x0000000181E6F9F0
		public StencilOp failOperationBack { get; set; } // 0x00000001815770F0-0x0000000181577100 0x0000000181E6F9D0-0x0000000181E6F9E0
		public StencilOp zFailOperationBack { get; set; } // 0x0000000181A2AC20-0x0000000181A2AC30 0x000000018226E2F0-0x000000018226E300
	
		// Constructors
		public StencilState(bool enabled = true /* Metadata: 0x0069DBD5 */, byte readMask = 255 /* Metadata: 0x0069DBD6 */, byte writeMask = 255 /* Metadata: 0x0069DBD7 */, CompareFunction compareFunction = CompareFunction.Always /* Metadata: 0x0069DBD8 */, StencilOp passOperation = StencilOp.Keep /* Metadata: 0x0069DBD9 */, StencilOp failOperation = StencilOp.Keep /* Metadata: 0x0069DBDA */, StencilOp zFailOperation = StencilOp.Keep /* Metadata: 0x0069DBDB */); // 0x000000018226E0F0-0x000000018226E1A0
		public StencilState(bool enabled, byte readMask, byte writeMask, CompareFunction compareFunctionFront, StencilOp passOperationFront, StencilOp failOperationFront, StencilOp zFailOperationFront, CompareFunction compareFunctionBack, StencilOp passOperationBack, StencilOp failOperationBack, StencilOp zFailOperationBack); // 0x000000018226E020-0x000000018226E0F0
	
		// Methods
		public void SetCompareFunction(CompareFunction value); // 0x000000018226DFE0-0x000000018226DFF0
		public void SetPassOperation(StencilOp value); // 0x000000018226E000-0x000000018226E010
		public void SetFailOperation(StencilOp value); // 0x000000018226DFF0-0x000000018226E000
		public void SetZFailOperation(StencilOp value); // 0x000000018226E010-0x000000018226E020
		public bool Equals(StencilState other); // 0x000000018226DD00-0x000000018226DD70
		public override bool Equals(object obj); // 0x000000018226DD70-0x000000018226DEB0
		public override int GetHashCode(); // 0x000000018226DEB0-0x000000018226DFE0
	}
}
