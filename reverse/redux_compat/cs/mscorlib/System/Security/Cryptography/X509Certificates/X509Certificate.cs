/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Security.Cryptography.X509Certificates
{
	[Serializable]
	public class X509Certificate : IDisposable, IDeserializationCallback, ISerializable // TypeDefIndex: 2852
	{
		// Fields
		private X509CertificateImpl impl; // 0x10
		private byte[] lazyCertHash; // 0x18
		private byte[] lazySerialNumber; // 0x20
		private string lazyIssuer; // 0x28
		private string lazySubject; // 0x30
		private string lazyKeyAlgorithm; // 0x38
		private byte[] lazyKeyAlgorithmParameters; // 0x40
		private byte[] lazyPublicKey; // 0x48
		private DateTime lazyNotBefore; // 0x50
		private DateTime lazyNotAfter; // 0x58
	
		// Properties
		public string Issuer { get; } // 0x00000001814CDE60-0x00000001814CDF10 
		public string Subject { get; } // 0x00000001814CDF10-0x00000001814CDFC0 
		internal X509CertificateImpl Impl { get; } // 0x0000000180377550-0x0000000180377560 
		internal bool IsValid { get; } // 0x00000001814CDE40-0x00000001814CDE60 
	
		// Constructors
		public X509Certificate(); // 0x00000001814CD990-0x00000001814CDA10
		public X509Certificate(byte[] data); // 0x00000001814CDAF0-0x00000001814CDC50
		public X509Certificate(byte[] rawData, string password); // 0x00000001814CD970-0x00000001814CD990
		public X509Certificate(byte[] rawData, string password, X509KeyStorageFlags keyStorageFlags); // 0x00000001814CDC50-0x00000001814CDE40
		internal X509Certificate(X509CertificateImpl impl); // 0x00000001814CDA30-0x00000001814CDAF0
		public X509Certificate(string fileName); // 0x00000001814CDA10-0x00000001814CDA30
		public X509Certificate(string fileName, string password, X509KeyStorageFlags keyStorageFlags); // 0x00000001814CD740-0x00000001814CD920
		public X509Certificate(X509Certificate cert); // 0x00000001814CD590-0x00000001814CD740
		public X509Certificate(SerializationInfo info, StreamingContext context); // 0x00000001814CD920-0x00000001814CD970
	
		// Methods
		public virtual void Reset(); // 0x00000001814CCC60-0x00000001814CCDE0
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x00000001814CCE20-0x00000001814CCE60
		void IDeserializationCallback.OnDeserialization(object sender); // 0x00000001814CCDE0-0x00000001814CCE20
		public void Dispose(); // 0x00000001814CBE20-0x00000001814CBE40
		protected virtual void Dispose(bool disposing); // 0x00000001814CBE40-0x00000001814CBE60
		public override bool Equals(object obj); // 0x00000001814CBF70-0x00000001814CC000
		public virtual bool Equals(X509Certificate other); // 0x00000001814CBE60-0x00000001814CBF70
		public virtual byte[] Export(X509ContentType contentType, string password); // 0x00000001814CC000-0x00000001814CC1E0
		public virtual byte[] GetCertHash(); // 0x00000001814CC3C0-0x00000001814CC470
		public virtual string GetCertHashString(); // 0x00000001814CC310-0x00000001814CC3C0
		private byte[] GetRawCertHash(); // 0x00000001814CC9A0-0x00000001814CCA10
		public virtual byte[] GetRawCertData(); // 0x00000001814CC920-0x00000001814CC9A0
		public override int GetHashCode(); // 0x00000001814CC470-0x00000001814CC530
		public virtual string GetKeyAlgorithm(); // 0x00000001814CC5E0-0x00000001814CC690
		public virtual byte[] GetKeyAlgorithmParameters(); // 0x00000001814CC530-0x00000001814CC5E0
		public virtual byte[] GetPublicKey(); // 0x00000001814CC870-0x00000001814CC920
		public virtual byte[] GetSerialNumber(); // 0x00000001814CCB30-0x00000001814CCC20
		public virtual string GetSerialNumberString(); // 0x00000001814CCA80-0x00000001814CCB30
		private byte[] GetRawSerialNumber(); // 0x00000001814CCA10-0x00000001814CCA80
		public override string ToString(); // 0x00000001814CCEC0-0x00000001814CCEE0
		public virtual string ToString(bool fVerbose); // 0x00000001814CCEE0-0x00000001814CD400
		internal DateTime GetNotAfter(); // 0x00000001814CC690-0x00000001814CC780
		internal DateTime GetNotBefore(); // 0x00000001814CC780-0x00000001814CC870
		protected static string FormatDate(DateTime date); // 0x00000001814CC1E0-0x00000001814CC310
		internal static void ValidateKeyStorageFlags(X509KeyStorageFlags keyStorageFlags); // 0x00000001814CD400-0x00000001814CD520
		private void VerifyContentType(X509ContentType contentType); // 0x00000001814CD520-0x00000001814CD590
		internal void ImportHandle(X509CertificateImpl impl); // 0x00000001814CCC20-0x00000001814CCC60
		internal void ThrowIfInvalid(); // 0x00000001814CCE60-0x00000001814CCEC0
	}
}
