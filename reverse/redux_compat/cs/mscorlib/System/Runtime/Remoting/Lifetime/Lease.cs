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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting.Lifetime
{
	internal class Lease : MarshalByRefObject, ILease // TypeDefIndex: 2909
	{
		// Fields
		private DateTime _leaseExpireTime; // 0x18
		private LeaseState _currentState; // 0x20
		private TimeSpan _initialLeaseTime; // 0x28
		private TimeSpan _renewOnCallTime; // 0x30
		private TimeSpan _sponsorshipTimeout; // 0x38
		private ArrayList _sponsors; // 0x40
		private Queue _renewingSponsors; // 0x48
		private RenewalDelegate _renewalDelegate; // 0x50
	
		// Properties
		public TimeSpan CurrentLeaseTime { get; } // 0x00000001814BBA00-0x00000001814BBA60 
		public LeaseState CurrentState { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public TimeSpan RenewOnCallTime { get; } // 0x000000018031E110-0x000000018031E120 
	
		// Nested types
		private delegate TimeSpan RenewalDelegate(ILease lease); // TypeDefIndex: 2910; 0x00000001804A78A0-0x00000001804A78B0
	
		// Constructors
		public Lease(); // 0x00000001814BB880-0x00000001814BBA00
	
		// Methods
		public void Activate(); // 0x00000001814BAB20-0x00000001814BAB30
		public TimeSpan Renew(TimeSpan renewalTime); // 0x00000001814BB460-0x00000001814BB530
		public void Unregister(ISponsor obj); // 0x00000001814BB530-0x00000001814BB6A0
		internal void UpdateState(); // 0x00000001814BB6A0-0x00000001814BB880
		private void CheckNextSponsor(); // 0x00000001814BAB30-0x00000001814BAEB0
		private void ProcessSponsorResponse(object state, bool timedOut); // 0x00000001814BAEB0-0x00000001814BB460
	}
}
