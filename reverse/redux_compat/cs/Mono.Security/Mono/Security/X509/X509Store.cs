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

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.X509
{
	public class X509Store // TypeDefIndex: 13829
	{
		// Fields
		private string _storePath; // 0x10
		private X509CertificateCollection _certificates; // 0x18
		private ArrayList _crls; // 0x20
		private bool _crl; // 0x28
		private bool _newFormat; // 0x29
	
		// Properties
		public X509CertificateCollection Certificates { get; } // 0x0000000181418BC0-0x0000000181418C00 
		public ArrayList Crls { get; } // 0x0000000181418C00-0x0000000181418C90 
	
		// Constructors
		internal X509Store(string path, bool crl, bool newFormat); // 0x0000000181418B60-0x0000000181418BC0
	
		// Methods
		private byte[] Load(string filename); // 0x00000001814189E0-0x0000000181418B60
		private X509Certificate LoadCertificate(string filename); // 0x0000000181418810-0x0000000181418880
		private X509Crl LoadCrl(string filename); // 0x0000000181418880-0x00000001814189E0
		private bool CheckStore(string path, bool throwException); // 0x00000001814187B0-0x0000000181418810
		private X509CertificateCollection BuildCertificatesCollection(string storeName); // 0x0000000181418490-0x0000000181418660
		private ArrayList BuildCrlsCollection(string storeName); // 0x0000000181418660-0x00000001814187B0
	}
}
