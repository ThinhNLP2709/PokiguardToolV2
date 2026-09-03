/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Timers
{
	[DefaultEvent("Elapsed")]
	[DefaultProperty("Interval")]
	public class Timer : Component // TypeDefIndex: 8688
	{
		// Fields
		private double interval; // 0x28
		private bool enabled; // 0x30
		private bool initializing; // 0x31
		private bool delayedEnable; // 0x32
		private ElapsedEventHandler onIntervalElapsed; // 0x38
		private bool autoReset; // 0x40
		private ISynchronizeInvoke synchronizingObject; // 0x48
		private bool disposed; // 0x50
		private Threading.Timer timer; // 0x58
		private TimerCallback callback; // 0x60
		private object cookie; // 0x68
	
		// Properties
		[Category("Behavior")]
		[DefaultValue(false)]
		[TimersDescription("Indicates whether the timer is enabled to fire events at a defined interval.")]
		public bool Enabled { set; } // 0x0000000181B727E0-0x0000000181B72A30
		public override ISite Site { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		[Browsable(false)]
		[DefaultValue(null)]
		[TimersDescription("The object used to marshal the event handler calls issued when an interval has elapsed.")]
		public ISynchronizeInvoke SynchronizingObject { get; } // 0x0000000181B72560-0x0000000181B72740 
	
		// Events
		[Category("Behavior")]
		[TimersDescription("Occurs when the Interval has elapsed.")]
		public event ElapsedEventHandler Elapsed {
			add; // 0x0000000181B724C0-0x0000000181B72560
			remove; // 0x0000000181B72740-0x0000000181B727E0
		}
	
		// Constructors
		public Timer(); // 0x0000000181B72400-0x0000000181B724C0
		public Timer(double interval); // 0x0000000181B72220-0x0000000181B72400
	
		// Methods
		private static int CalculateRoundedInterval(double interval, bool argumentCheck = false /* Metadata: 0x0069DFC8 */); // 0x0000000181B71C20-0x0000000181B71E00
		private void UpdateTimer(); // 0x0000000181B721D0-0x0000000181B72220
		public void Close(); // 0x0000000181B71E00-0x0000000181B71E50
		protected override void Dispose(bool disposing); // 0x0000000181B71E50-0x0000000181B71EB0
		private void MyTimerCallback(object state); // 0x0000000181B71EB0-0x0000000181B721D0
	}
}
