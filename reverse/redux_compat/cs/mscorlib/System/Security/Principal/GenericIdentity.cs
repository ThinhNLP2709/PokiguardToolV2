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
using System.Security.Claims;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Principal
{
	[Serializable]
	public class GenericIdentity : ClaimsIdentity // TypeDefIndex: 2855
	{
		// Fields
		private readonly string m_name; // 0x78
		private readonly string m_type; // 0x80
	
		// Properties
		public override IEnumerable<Claim> Claims { get; } // 0x00000001814B1BA0-0x00000001814B1C20 
		public override string Name { get; } // 0x000000018033D4E0-0x000000018033D4F0 
		public override string AuthenticationType { get; } // 0x000000018033D4A0-0x000000018033D4B0 
		public override bool IsAuthenticated { get; } // 0x00000001814B96A0-0x00000001814B96F0 
	
		// Constructors
		public GenericIdentity(string name, string type); // 0x00000001814B9420-0x00000001814B96A0
		private GenericIdentity(); // 0x00000001814B1000-0x00000001814B1030
		protected GenericIdentity(GenericIdentity identity); // 0x00000001814B93C0-0x00000001814B9420
	
		// Methods
		public override ClaimsIdentity Clone(); // 0x00000001814B9330-0x00000001814B93C0
		private void AddNameClaim(); // 0x00000001814B91B0-0x00000001814B9330
	}
}
