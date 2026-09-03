/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
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
	public class ClaimsPrincipal : IPrincipal // TypeDefIndex: 2866
	{
		// Fields
		[OptionalField(VersionAdded = 2)]
		private string m_version; // 0x10
		[OptionalField(VersionAdded = 2)]
		private string m_serializedClaimsIdentities; // 0x18
		[NonSerialized]
		private List<ClaimsIdentity> m_identities; // 0x20
		[NonSerialized]
		private static Func<IEnumerable<ClaimsIdentity>, ClaimsIdentity> s_identitySelector; // 0x00
		[NonSerialized]
		private static Func<ClaimsPrincipal> s_principalSelector; // 0x08
	
		// Properties
		public static Func<ClaimsPrincipal> ClaimsPrincipalSelector { get; } // 0x00000001814B31B0-0x00000001814B3200 
		public virtual IIdentity Identity { get; } // 0x00000001814B3200-0x00000001814B3290 
	
		// Constructors
		public ClaimsPrincipal(); // 0x00000001814B3110-0x00000001814B31B0
		protected ClaimsPrincipal(SerializationInfo info, StreamingContext context); // 0x00000001814B2F20-0x00000001814B3110
		static ClaimsPrincipal(); // 0x00000001814B2E40-0x00000001814B2F20
	
		// Methods
		private static ClaimsIdentity SelectPrimaryIdentity(IEnumerable<ClaimsIdentity> identities); // 0x00000001814B2490-0x00000001814B2710
		[OnSerializing]
		private void OnSerializingMethod(StreamingContext context); // 0x00000001814B2430-0x00000001814B2490
		[OnDeserialized]
		private void OnDeserializedMethod(StreamingContext context); // 0x00000001814B23C0-0x00000001814B2430
		private void Deserialize(SerializationInfo info, StreamingContext context); // 0x00000001814B2260-0x00000001814B23C0
		private void DeserializeIdentities(string identities); // 0x00000001814B1D30-0x00000001814B2260
		private string SerializeIdentities(); // 0x00000001814B2710-0x00000001814B2E40
	}
}
