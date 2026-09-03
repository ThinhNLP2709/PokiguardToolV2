/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mono.Security;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.X509
{
	public class X520 // TypeDefIndex: 13832
	{
		// Nested types
		public abstract class AttributeTypeAndValue // TypeDefIndex: 13833
		{
			// Fields
			private string oid; // 0x10
			private string attrValue; // 0x18
			private int upperBound; // 0x20
			private byte encoding; // 0x24
	
			// Properties
			public string Value { set; } // 0x00000001814006E0-0x00000001814007A0
	
			// Constructors
			protected AttributeTypeAndValue(string oid, int upperBound); // 0x0000000181400630-0x0000000181400680
			protected AttributeTypeAndValue(string oid, int upperBound, byte encoding); // 0x0000000181400680-0x00000001814006E0
	
			// Methods
			internal ASN1 GetASN1(byte encoding); // 0x0000000181400290-0x00000001814005C0
			internal ASN1 GetASN1(); // 0x0000000181400280-0x0000000181400290
			private byte SelectBestEncoding(); // 0x00000001814005C0-0x0000000181400630
		}
	
		public class CommonName : AttributeTypeAndValue // TypeDefIndex: 13834
		{
			// Constructors
			public CommonName(); // 0x0000000181403A60-0x0000000181403AC0
		}
	
		public class SerialNumber : AttributeTypeAndValue // TypeDefIndex: 13835
		{
			// Constructors
			public SerialNumber(); // 0x000000018140DB70-0x000000018140DBD0
		}
	
		public class LocalityName : AttributeTypeAndValue // TypeDefIndex: 13836
		{
			// Constructors
			public LocalityName(); // 0x0000000181405100-0x0000000181405160
		}
	
		public class StateOrProvinceName : AttributeTypeAndValue // TypeDefIndex: 13837
		{
			// Constructors
			public StateOrProvinceName(); // 0x000000018140EC90-0x000000018140ECF0
		}
	
		public class OrganizationName : AttributeTypeAndValue // TypeDefIndex: 13838
		{
			// Constructors
			public OrganizationName(); // 0x00000001814051A0-0x0000000181405200
		}
	
		public class OrganizationalUnitName : AttributeTypeAndValue // TypeDefIndex: 13839
		{
			// Constructors
			public OrganizationalUnitName(); // 0x0000000181405200-0x0000000181405260
		}
	
		public class EmailAddress : AttributeTypeAndValue // TypeDefIndex: 13840
		{
			// Constructors
			public EmailAddress(); // 0x0000000181404B10-0x0000000181404B70
		}
	
		public class DomainComponent : AttributeTypeAndValue // TypeDefIndex: 13841
		{
			// Constructors
			public DomainComponent(); // 0x0000000181404AB0-0x0000000181404B10
		}
	
		public class UserId : AttributeTypeAndValue // TypeDefIndex: 13842
		{
			// Constructors
			public UserId(); // 0x000000018140EDB0-0x000000018140EE10
		}
	
		public class Oid : AttributeTypeAndValue // TypeDefIndex: 13843
		{
			// Constructors
			public Oid(string oid); // 0x0000000181405160-0x00000001814051A0
		}
	
		public class Title : AttributeTypeAndValue // TypeDefIndex: 13844
		{
			// Constructors
			public Title(); // 0x000000018140ED50-0x000000018140EDB0
		}
	
		public class CountryName : AttributeTypeAndValue // TypeDefIndex: 13845
		{
			// Constructors
			public CountryName(); // 0x0000000181404000-0x0000000181404060
		}
	
		public class DnQualifier : AttributeTypeAndValue // TypeDefIndex: 13846
		{
			// Constructors
			public DnQualifier(); // 0x0000000181404A50-0x0000000181404AB0
		}
	
		public class Surname : AttributeTypeAndValue // TypeDefIndex: 13847
		{
			// Constructors
			public Surname(); // 0x000000018140ECF0-0x000000018140ED50
		}
	
		public class GivenName : AttributeTypeAndValue // TypeDefIndex: 13848
		{
			// Constructors
			public GivenName(); // 0x0000000181405030-0x0000000181405090
		}
	
		public class Initial : AttributeTypeAndValue // TypeDefIndex: 13849
		{
			// Constructors
			public Initial(); // 0x0000000181405090-0x00000001814050F0
		}
	}
}
