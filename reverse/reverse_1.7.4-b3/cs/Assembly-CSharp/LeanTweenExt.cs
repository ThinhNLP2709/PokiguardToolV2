/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class LeanTweenExt // TypeDefIndex: 332
{
	// Extension methods
	public static LTDescr LeanAlpha(this GameObject gameObject, float to, float time); // 0x00000001802FB380-0x00000001802FB400
	public static LTDescr LeanColor(this GameObject gameObject, Color to, float time); // 0x00000001802FB400-0x00000001802FB480
	public static LTDescr LeanDelayedCall(this GameObject gameObject, float delayTime, Action callback); // 0x00000001802FB480-0x00000001802FB4F0
	public static LTDescr LeanMove(this Transform transform, Vector3 to, float time); // 0x00000001802FB4F0-0x00000001802FB5F0
	public static LTDescr LeanMove(this Transform transform, Vector3[] to, float time); // 0x00000001802FB5F0-0x00000001802FB680
	public static LTDescr LeanMoveLocal(this GameObject gameObject, Vector3 to, float time); // 0x00000001802FB680-0x00000001802FB710
	public static LTDescr LeanMoveX(this GameObject gameObject, float to, float time); // 0x00000001802FB710-0x00000001802FB790
	public static LTDescr LeanMoveX(this Transform transform, float to, float time); // 0x00000001802FB790-0x00000001802FB820
	public static LTDescr LeanMoveY(this GameObject gameObject, float to, float time); // 0x00000001802FB820-0x00000001802FB8A0
	public static void LeanPause(this GameObject gameObject); // 0x00000001802FB8A0-0x00000001802FB8F0
	public static void LeanResume(this GameObject gameObject); // 0x00000001802FB8F0-0x00000001802FB940
	public static LTDescr LeanRotate(this Transform transform, Vector3 to, float time); // 0x00000001802FB940-0x00000001802FB9E0
	public static LTDescr LeanRotateAround(this GameObject gameObject, Vector3 axis, float add, float time); // 0x00000001802FB9E0-0x00000001802FBA80
	public static LTDescr LeanScale(this Transform transform, Vector3 to, float time); // 0x00000001802FBA80-0x00000001802FBB20
	public static LTDescr LeanScaleY(this Transform transform, float to, float time); // 0x00000001802FBB20-0x00000001802FBBB0
	public static LTDescr LeanScaleZ(this Transform transform, float to, float time); // 0x00000001802FBBB0-0x00000001802FBC40
	public static LTDescr LeanValue(this GameObject gameObject, float from, float to, float time); // 0x00000001802FBC40-0x00000001802FBCD0
	public static LTDescr LeanValue(this GameObject gameObject, Action<float, object> callOnUpdate, float from, float to, float time); // 0x00000001802FBCD0-0x00000001802FBD60
	public static LTDescr LeanValue(this GameObject gameObject, Action<Vector3> callOnUpdate, Vector3 from, Vector3 to, float time); // 0x00000001802FBD60-0x00000001802FBE20
	public static void LeanSetPosX(this Transform transform, float val); // 0x00000001802FBE20-0x00000001802FBFB0
	public static void LeanSetPosY(this Transform transform, float val); // 0x00000001802FBFB0-0x00000001802FC140
	public static void LeanSetPosZ(this Transform transform, float val); // 0x00000001802FC140-0x00000001802FC2D0
	public static void LeanSetLocalPosX(this Transform transform, float val); // 0x00000001802FC2D0-0x00000001802FC460
	public static void LeanSetLocalPosY(this Transform transform, float val); // 0x00000001802FC460-0x00000001802FC5F0
	public static void LeanSetLocalPosZ(this Transform transform, float val); // 0x00000001802FC5F0-0x00000001802FC780
	public static Color LeanColor(this Transform transform); // 0x00000001802FC780-0x00000001802FC880
}

