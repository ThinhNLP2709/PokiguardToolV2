/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[RequiredByNativeCode]
	public struct Keyframe // TypeDefIndex: 7475
	{
		// Fields
		private float m_Time; // 0x00
		private float m_Value; // 0x04
		private float m_InTangent; // 0x08
		private float m_OutTangent; // 0x0C
		private int m_WeightedMode; // 0x10
		private float m_InWeight; // 0x14
		private float m_OutWeight; // 0x18
	
		// Properties
		public float time { get; set; } // 0x000000018035C780-0x000000018035C790 0x0000000181DBFEC0-0x0000000181DBFED0
		public float value { get; set; } // 0x000000018035C790-0x000000018035C7A0 0x0000000181CE28C0-0x0000000181CE28D0
		public float inTangent { get; set; } // 0x00000001802DB050-0x00000001802DB060 0x0000000181DA9A50-0x0000000181DA9A60
		public float outTangent { get; set; } // 0x00000001802DB040-0x00000001802DB050 0x0000000181DD0800-0x0000000181DD0810
		public float inWeight { get; set; } // 0x0000000181120AA0-0x0000000181120AB0 0x0000000181C40AB0-0x0000000181C40AC0
		public float outWeight { get; set; } // 0x00000001806CB0A0-0x00000001806CB0B0 0x0000000180FB0A90-0x0000000180FB0AA0
		public WeightedMode weightedMode { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
	
		// Constructors
		public Keyframe(float time, float value); // 0x00000001821901A0-0x00000001821901C0
		public Keyframe(float time, float value, float inTangent, float outTangent); // 0x0000000182190170-0x00000001821901A0
	}
}
