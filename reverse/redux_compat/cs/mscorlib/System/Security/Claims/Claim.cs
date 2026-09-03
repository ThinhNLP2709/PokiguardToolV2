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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Claims
{
	[Serializable]
	public class Claim // TypeDefIndex: 2863
	{
		// Fields
		private string m_issuer; // 0x10
		private string m_originalIssuer; // 0x18
		private string m_type; // 0x20
		private string m_value; // 0x28
		private string m_valueType; // 0x30
		[NonSerialized]
		private byte[] m_userSerializationData; // 0x38
		private Dictionary<string, string> m_properties; // 0x40
		[NonSerialized]
		private object m_propertyLock; // 0x48
		[NonSerialized]
		private ClaimsIdentity m_subject; // 0x50
	
		// Properties
		public IDictionary<string, string> Properties { get; } // 0x00000001814AF3B0-0x00000001814AF4D0 
		public ClaimsIdentity Subject { get; internal set; } // 0x00000001806CCC00-0x00000001806CCC10 0x00000001806CCE80-0x00000001806CCE90
		public string Type { get; } // 0x00000001802F8630-0x00000001802F8640 
		public string Value { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Constructors
		public Claim(string type, string value, string valueType, string issuer, string originalIssuer, ClaimsIdentity subject); // 0x00000001814AED80-0x00000001814AEDD0
		internal Claim(string type, string value, string valueType, string issuer, string originalIssuer, ClaimsIdentity subject, string propertyKey, string propertyValue); // 0x00000001814AF100-0x00000001814AF3B0
		protected Claim(Claim other, ClaimsIdentity subject); // 0x00000001814AEDD0-0x00000001814AF100
	
		// Methods
		[OnDeserialized]
		private void OnDeserializedMethod(StreamingContext context); // 0x00000001814AECD0-0x00000001814AED10
		public virtual Claim Clone(ClaimsIdentity identity); // 0x00000001814AEC60-0x00000001814AECD0
		public override string ToString(); // 0x00000001814AED10-0x00000001814AED80
	}
}
