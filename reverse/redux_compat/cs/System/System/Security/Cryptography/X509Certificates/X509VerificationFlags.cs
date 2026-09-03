/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Security.Cryptography.X509Certificates
{
	[Flags]
	public enum X509VerificationFlags // TypeDefIndex: 8772
	{
		NoFlag = 0,
		IgnoreNotTimeValid = 1,
		IgnoreCtlNotTimeValid = 2,
		IgnoreNotTimeNested = 4,
		IgnoreInvalidBasicConstraints = 8,
		AllowUnknownCertificateAuthority = 16,
		IgnoreWrongUsage = 32,
		IgnoreInvalidName = 64,
		IgnoreInvalidPolicy = 128,
		IgnoreEndRevocationUnknown = 256,
		IgnoreCtlSignerRevocationUnknown = 512,
		IgnoreCertificateAuthorityRevocationUnknown = 1024,
		IgnoreRootRevocationUnknown = 2048,
		AllFlags = 4095
	}
}
