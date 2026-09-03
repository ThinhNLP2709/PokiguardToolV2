/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Principal;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Claims
{
	[Serializable]
	[ComVisible(true)]
	public class ClaimsIdentity : IIdentity // TypeDefIndex: 2864
	{
		// Fields
		[NonSerialized]
		private byte[] m_userSerializationData; // 0x10
		[NonSerialized]
		private List<Claim> m_instanceClaims; // 0x18
		[NonSerialized]
		private Collection<IEnumerable<Claim>> m_externalClaims; // 0x20
		[NonSerialized]
		private string m_nameType; // 0x28
		[NonSerialized]
		private string m_roleType; // 0x30
		[OptionalField(VersionAdded = 2)]
		private string m_version; // 0x38
		[OptionalField(VersionAdded = 2)]
		private ClaimsIdentity m_actor; // 0x40
		[OptionalField(VersionAdded = 2)]
		private string m_authenticationType; // 0x48
		[OptionalField(VersionAdded = 2)]
		private object m_bootstrapContext; // 0x50
		[OptionalField(VersionAdded = 2)]
		private string m_label; // 0x58
		[OptionalField(VersionAdded = 2)]
		private string m_serializedNameType; // 0x60
		[OptionalField(VersionAdded = 2)]
		private string m_serializedRoleType; // 0x68
		[OptionalField(VersionAdded = 2)]
		private string m_serializedClaims; // 0x70
	
		// Properties
		public virtual string AuthenticationType { get; } // 0x00000001803272B0-0x00000001803272C0 
		public virtual bool IsAuthenticated { get; } // 0x00000001814B1C20-0x00000001814B1C40 
		public ClaimsIdentity Actor { get; set; } // 0x0000000180377940-0x0000000180377950 0x00000001814B1C70-0x00000001814B1D30
		public virtual IEnumerable<Claim> Claims { [IteratorStateMachine(typeof(_get_Claims_d__51))] get; } // 0x00000001814B1BA0-0x00000001814B1C20 
		public virtual string Name { get; } // 0x00000001814B1C40-0x00000001814B1C70 
		public string NameClaimType { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Nested types
		[CompilerGenerated]
		private sealed class _get_Claims_d__51 : IEnumerable<Claim>, IEnumerator<Claim> // TypeDefIndex: 2865
		{
			// Fields
			private int __1__state; // 0x10
			private Claim __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			public ClaimsIdentity __4__this; // 0x28
			private int _i_5__2; // 0x30
			private IEnumerator<Claim> __7__wrap2; // 0x38
	
			// Properties
			Claim IEnumerator<System.Security.Claims.Claim>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _get_Claims_d__51(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001814CA9E0-0x00000001814CAA80
			private bool MoveNext(); // 0x00000001814CA5C0-0x00000001814CA900
			private void __m__Finally1(); // 0x00000001814CAA80-0x00000001814CAAD0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001814CA9A0-0x00000001814CA9E0
			[DebuggerHidden]
			IEnumerator<Claim> IEnumerable<Claim>.GetEnumerator(); // 0x00000001814CA900-0x00000001814CA9A0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x00000001814CA900-0x00000001814CA9A0
		}
	
		// Constructors
		public ClaimsIdentity(); // 0x00000001814B1000-0x00000001814B1030
		public ClaimsIdentity(IEnumerable<Claim> claims); // 0x00000001814B0FD0-0x00000001814B1000
		public ClaimsIdentity(IIdentity identity, IEnumerable<Claim> claims, string authenticationType, string nameType, string roleType); // 0x00000001814B18F0-0x00000001814B1920
		internal ClaimsIdentity(IIdentity identity, IEnumerable<Claim> claims, string authenticationType, string nameType, string roleType, bool checkAuthType); // 0x00000001814B11F0-0x00000001814B18F0
		protected ClaimsIdentity(ClaimsIdentity other); // 0x00000001814B1920-0x00000001814B1BA0
		protected ClaimsIdentity(SerializationInfo info, StreamingContext context); // 0x00000001814B1030-0x00000001814B11F0
	
		// Methods
		public virtual ClaimsIdentity Clone(); // 0x00000001814AF5B0-0x00000001814AF780
		public virtual void AddClaim(Claim claim); // 0x00000001814AF4D0-0x00000001814AF5B0
		private void SafeAddClaims(IEnumerable<Claim> claims); // 0x00000001814B0BD0-0x00000001814B0E10
		private void SafeAddClaim(Claim claim); // 0x00000001814B0A80-0x00000001814B0BD0
		public virtual Claim FindFirst(string type); // 0x00000001814B0120-0x00000001814B0320
		[OnSerializing]
		private void OnSerializingMethod(StreamingContext context); // 0x00000001814B0A00-0x00000001814B0A80
		[OnDeserialized]
		private void OnDeserializedMethod(StreamingContext context); // 0x00000001814B0840-0x00000001814B0920
		[OnDeserializing]
		private void OnDeserializingMethod(StreamingContext context); // 0x00000001814B0920-0x00000001814B0A00
		protected virtual void GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001814B0320-0x00000001814B07F0
		private void DeserializeClaims(string serializedClaims); // 0x00000001814AF780-0x00000001814AFA20
		private string SerializeClaims(); // 0x00000001814B0E10-0x00000001814B0FD0
		private bool IsCircular(ClaimsIdentity subject); // 0x00000001814B07F0-0x00000001814B0840
		private void Deserialize(SerializationInfo info, StreamingContext context, bool useContext); // 0x00000001814AFA20-0x00000001814B0120
	}
}
