/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public interface IWheelSource // TypeDefIndex: 937
{
	// Properties
	WheelKind Kind { get; }
	bool SupportsBonusClaim { get; }
	long RatesId { get; }

	// Methods
	IEnumerator Load(int userId, Action<WheelBoardVM> ok, Action<string> err);
	IEnumerator Spin(int userId, int count, Action<WheelSpinOutcome> ok, Action<string> err);
	bool CanAfford(int count, out string why);
	IEnumerator ClaimBonus(int userId, long bonusId, Action<string> ok, Action<string> err);
}

