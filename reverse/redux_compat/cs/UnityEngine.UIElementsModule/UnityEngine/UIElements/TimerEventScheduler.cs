/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[1] {"UnityEditor.GraphToolkitModule" })]
	internal class TimerEventScheduler // TypeDefIndex: 4346
	{
		// Fields
		private readonly List<ScheduledItem> m_ScheduledItems; // 0x10
		private bool m_TransactionMode; // 0x18
		private readonly List<ScheduledItem> m_ScheduleTransactions; // 0x20
		private readonly HashSet<ScheduledItem> m_UnscheduleTransactions; // 0x28
		private int m_LastUpdatedIndex; // 0x30
		private BaseVisualElementPanel panel; // 0x38
		private long frameCount; // 0x40
	
		// Properties
		public long FrameCount { get; set; } // 0x0000000180377940-0x0000000180377950 0x000000018172A470-0x000000018172A480
	
		// Constructors
		public TimerEventScheduler(BaseVisualElementPanel p); // 0x00000001824DE790-0x00000001824DE8A0
	
		// Methods
		public void Schedule(ScheduledItem item); // 0x00000001824DE020-0x00000001824DE200
		private bool RemovedScheduledItemAt(int index); // 0x00000001824DDFE0-0x00000001824DE020
		public void Unschedule(ScheduledItem item); // 0x00000001824DE200-0x00000001824DE470
		private bool PrivateUnSchedule(ScheduledItem sItem); // 0x00000001824DDF30-0x00000001824DDFE0
		public void UpdateScheduledEvents(); // 0x00000001824DE470-0x00000001824DE790
	}
}
