/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IntegerTime;
using UnityEngine;

// Image 43: UnityEngine.InputForUIModule.dll - Assembly: UnityEngine.InputForUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15251-15301

namespace UnityEngine.InputForUI
{
	internal class NavigationEventRepeatHelper // TypeDefIndex: 15296
	{
		// Fields
		private int m_ConsecutiveMoveCount; // 0x10
		private NavigationEvent.Direction m_LastDirection; // 0x14
		private DiscreteTime m_PrevActionTime; // 0x18
		private readonly DiscreteTime m_InitialRepeatDelay; // 0x20
		private readonly DiscreteTime m_ConsecutiveRepeatDelay; // 0x28
	
		// Constructors
		public NavigationEventRepeatHelper(); // 0x00000001822AAD10-0x00000001822AADC0
	
		// Methods
		public void Reset(); // 0x00000001822AABB0-0x00000001822AAC10
		public bool ShouldSendMoveEvent(DiscreteTime timestamp, NavigationEvent.Direction direction, bool axisButtonsWherePressedThisFrame); // 0x00000001822AAC10-0x00000001822AAD10
	}
}
