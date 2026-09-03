/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Net.Security;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class ServerCertValidationCallback // TypeDefIndex: 9108
	{
		// Fields
		private readonly RemoteCertificateValidationCallback m_ValidationCallback; // 0x10
		private readonly ExecutionContext m_Context; // 0x18
	
		// Properties
		internal RemoteCertificateValidationCallback ValidationCallback { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Nested types
		private class CallbackContext // TypeDefIndex: 9109
		{
			// Fields
			internal readonly object request; // 0x10
			internal readonly X509Certificate certificate; // 0x18
			internal readonly X509Chain chain; // 0x20
			internal readonly SslPolicyErrors sslPolicyErrors; // 0x28
			internal bool result; // 0x2C
	
			// Constructors
			internal CallbackContext(object request, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors); // 0x0000000181BFBC00-0x0000000181BFBC80
		}
	
		// Constructors
		internal ServerCertValidationCallback(RemoteCertificateValidationCallback validationCallback); // 0x0000000181C11480-0x0000000181C11500
	
		// Methods
		internal void Callback(object state); // 0x0000000181C11260-0x0000000181C11310
		internal bool Invoke(object request, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors); // 0x0000000181C11310-0x0000000181C11480
	}
}
