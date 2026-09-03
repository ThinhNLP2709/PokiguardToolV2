/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Threading;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Lifetime
{
	internal class LeaseManager // TypeDefIndex: 2911
	{
		// Fields
		private ArrayList _objects; // 0x10
		private Timer _timer; // 0x18
	
		// Constructors
		public LeaseManager(); // 0x00000001814BA800-0x00000001814BA870
	
		// Methods
		public void SetPollTime(TimeSpan timeSpan); // 0x00000001814BA290-0x00000001814BA380
		public void TrackLifetime(ServerIdentity identity); // 0x00000001814BA550-0x00000001814BA800
		public void StartManager(); // 0x00000001814BA380-0x00000001814BA510
		public void StopManager(); // 0x00000001814BA510-0x00000001814BA550
		public void ManageLeases(object state); // 0x00000001814BA010-0x00000001814BA290
	}
}
