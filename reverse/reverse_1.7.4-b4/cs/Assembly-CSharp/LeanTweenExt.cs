/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public static class LeanTweenExt // TypeDefIndex: 332
{
	// Extension methods
	public static LTDescr LeanAlpha(this GameObject gameObject, float to, float time); // 0x00000001802FB3B0-0x00000001802FB430
	public static LTDescr LeanColor(this GameObject gameObject, Color to, float time); // 0x00000001802FB430-0x00000001802FB4B0
	public static LTDescr LeanDelayedCall(this GameObject gameObject, float delayTime, Action callback); // 0x00000001802FB4B0-0x00000001802FB520
	public static LTDescr LeanMove(this Transform transform, Vector3 to, float time); // 0x00000001802FB520-0x00000001802FB620
	public static LTDescr LeanMove(this Transform transform, Vector3[] to, float time); // 0x00000001802FB620-0x00000001802FB6B0
	public static LTDescr LeanMoveLocal(this GameObject gameObject, Vector3 to, float time); // 0x00000001802FB6B0-0x00000001802FB740
	public static LTDescr LeanMoveX(this GameObject gameObject, float to, float time); // 0x00000001802FB740-0x00000001802FB7C0
	public static LTDescr LeanMoveX(this Transform transform, float to, float time); // 0x00000001802FB7C0-0x00000001802FB850
	public static LTDescr LeanMoveY(this GameObject gameObject, float to, float time); // 0x00000001802FB850-0x00000001802FB8D0
	public static void LeanPause(this GameObject gameObject); // 0x00000001802FB8D0-0x00000001802FB920
	public static void LeanResume(this GameObject gameObject); // 0x00000001802FB920-0x00000001802FB970
	public static LTDescr LeanRotate(this Transform transform, Vector3 to, float time); // 0x00000001802FB970-0x00000001802FBA10
	public static LTDescr LeanRotateAround(this GameObject gameObject, Vector3 axis, float add, float time); // 0x00000001802FBA10-0x00000001802FBAB0
	public static LTDescr LeanScale(this Transform transform, Vector3 to, float time); // 0x00000001802FBAB0-0x00000001802FBB50
	public static LTDescr LeanScaleY(this Transform transform, float to, float time); // 0x00000001802FBB50-0x00000001802FBBE0
	public static LTDescr LeanScaleZ(this Transform transform, float to, float time); // 0x00000001802FBBE0-0x00000001802FBC70
	public static LTDescr LeanValue(this GameObject gameObject, float from, float to, float time); // 0x00000001802FBC70-0x00000001802FBD00
	public static LTDescr LeanValue(this GameObject gameObject, Action<float, object> callOnUpdate, float from, float to, float time); // 0x00000001802FBD00-0x00000001802FBD90
	public static LTDescr LeanValue(this GameObject gameObject, Action<Vector3> callOnUpdate, Vector3 from, Vector3 to, float time); // 0x00000001802FBD90-0x00000001802FBE50
	public static void LeanSetPosX(this Transform transform, float val); // 0x00000001802FBE50-0x00000001802FBFE0
	public static void LeanSetPosY(this Transform transform, float val); // 0x00000001802FBFE0-0x00000001802FC170
	public static void LeanSetPosZ(this Transform transform, float val); // 0x00000001802FC170-0x00000001802FC300
	public static void LeanSetLocalPosX(this Transform transform, float val); // 0x00000001802FC300-0x00000001802FC490
	public static void LeanSetLocalPosY(this Transform transform, float val); // 0x00000001802FC490-0x00000001802FC620
	public static void LeanSetLocalPosZ(this Transform transform, float val); // 0x00000001802FC620-0x00000001802FC7B0
	public static Color LeanColor(this Transform transform); // 0x00000001802FC7B0-0x00000001802FC8B0
}

