/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public static class LeanTweenExt // TypeDefIndex: 309
{
	// Extension methods
	public static LTDescr LeanAlpha(this GameObject gameObject, float to, float time); // 0x00000001806F7960-0x00000001806F79D0
	public static LTDescr LeanAlphaVertex(this GameObject gameObject, float to, float time); // 0x00000001806F7810-0x00000001806F7880
	public static LTDescr LeanAlpha(this RectTransform rectTransform, float to, float time); // 0x00000001806F78F0-0x00000001806F7960
	public static LTDescr LeanAlpha(this CanvasGroup canvas, float to, float time); // 0x00000001806F7880-0x00000001806F78F0
	public static LTDescr LeanAlphaText(this RectTransform rectTransform, float to, float time); // 0x00000001806F77A0-0x00000001806F7810
	public static void LeanCancel(this GameObject gameObject); // 0x00000001806F7A80-0x00000001806F7AD0
	public static void LeanCancel(this GameObject gameObject, bool callOnComplete); // 0x00000001806F79D0-0x00000001806F7A30
	public static void LeanCancel(this GameObject gameObject, int uniqueId, bool callOnComplete = false /* Metadata: 0x0064C1E2 */); // 0x00000001806F7AD0-0x00000001806F7B40
	public static void LeanCancel(this RectTransform rectTransform); // 0x00000001806F7A30-0x00000001806F7A80
	public static LTDescr LeanColor(this GameObject gameObject, Color to, float time); // 0x00000001806F7BC0-0x00000001806F7C40
	public static LTDescr LeanColorText(this RectTransform rectTransform, Color to, float time); // 0x00000001806F7B40-0x00000001806F7BC0
	public static LTDescr LeanDelayedCall(this GameObject gameObject, float delayTime, Action callback); // 0x00000001806F7D30-0x00000001806F7DA0
	public static LTDescr LeanDelayedCall(this GameObject gameObject, float delayTime, Action<object> callback); // 0x00000001806F7CC0-0x00000001806F7D30
	public static bool LeanIsPaused(this GameObject gameObject); // 0x00000001806F7DA0-0x00000001806F7DF0
	public static bool LeanIsPaused(this RectTransform rectTransform); // 0x00000001806F7DF0-0x00000001806F7E40
	public static bool LeanIsTweening(this GameObject gameObject); // 0x00000001806F7E40-0x00000001806F7E90
	public static LTDescr LeanMove(this GameObject gameObject, Vector3 to, float time); // 0x00000001806F8C00-0x00000001806F8C80
	public static LTDescr LeanMove(this Transform transform, Vector3 to, float time); // 0x00000001806F8F20-0x00000001806F8FC0
	public static LTDescr LeanMove(this RectTransform rectTransform, Vector3 to, float time); // 0x00000001806F8D80-0x00000001806F8E00
	public static LTDescr LeanMove(this GameObject gameObject, Vector2 to, float time); // 0x00000001806F8FC0-0x00000001806F9030
	public static LTDescr LeanMove(this Transform transform, Vector2 to, float time); // 0x00000001806F8E90-0x00000001806F8F20
	public static LTDescr LeanMove(this GameObject gameObject, Vector3[] to, float time); // 0x00000001806F8C80-0x00000001806F8CF0
	public static LTDescr LeanMove(this GameObject gameObject, LTBezierPath to, float time); // 0x00000001806F9130-0x00000001806F91A0
	public static LTDescr LeanMove(this GameObject gameObject, LTSpline to, float time); // 0x00000001806F90C0-0x00000001806F9130
	public static LTDescr LeanMove(this Transform transform, Vector3[] to, float time); // 0x00000001806F8E00-0x00000001806F8E90
	public static LTDescr LeanMove(this Transform transform, LTBezierPath to, float time); // 0x00000001806F8CF0-0x00000001806F8D80
	public static LTDescr LeanMove(this Transform transform, LTSpline to, float time); // 0x00000001806F9030-0x00000001806F90C0
	public static LTDescr LeanMoveLocal(this GameObject gameObject, Vector3 to, float time); // 0x00000001806F8220-0x00000001806F82A0
	public static LTDescr LeanMoveLocal(this GameObject gameObject, LTBezierPath to, float time); // 0x00000001806F82A0-0x00000001806F8310
	public static LTDescr LeanMoveLocal(this GameObject gameObject, LTSpline to, float time); // 0x00000001806F83A0-0x00000001806F8410
	public static LTDescr LeanMoveLocal(this Transform transform, Vector3 to, float time); // 0x00000001806F8410-0x00000001806F84B0
	public static LTDescr LeanMoveLocal(this Transform transform, LTBezierPath to, float time); // 0x00000001806F8190-0x00000001806F8220
	public static LTDescr LeanMoveLocal(this Transform transform, LTSpline to, float time); // 0x00000001806F8310-0x00000001806F83A0
	public static LTDescr LeanMoveLocalX(this GameObject gameObject, float to, float time); // 0x00000001806F7E90-0x00000001806F7F00
	public static LTDescr LeanMoveLocalY(this GameObject gameObject, float to, float time); // 0x00000001806F8020-0x00000001806F8090
	public static LTDescr LeanMoveLocalZ(this GameObject gameObject, float to, float time); // 0x00000001806F8090-0x00000001806F8100
	public static LTDescr LeanMoveLocalX(this Transform transform, float to, float time); // 0x00000001806F7F00-0x00000001806F7F90
	public static LTDescr LeanMoveLocalY(this Transform transform, float to, float time); // 0x00000001806F7F90-0x00000001806F8020
	public static LTDescr LeanMoveLocalZ(this Transform transform, float to, float time); // 0x00000001806F8100-0x00000001806F8190
	public static LTDescr LeanMoveSpline(this GameObject gameObject, Vector3[] to, float time); // 0x00000001806F85B0-0x00000001806F8620
	public static LTDescr LeanMoveSpline(this GameObject gameObject, LTSpline to, float time); // 0x00000001806F8620-0x00000001806F8690
	public static LTDescr LeanMoveSpline(this Transform transform, Vector3[] to, float time); // 0x00000001806F8720-0x00000001806F87B0
	public static LTDescr LeanMoveSpline(this Transform transform, LTSpline to, float time); // 0x00000001806F8690-0x00000001806F8720
	public static LTDescr LeanMoveSplineLocal(this GameObject gameObject, Vector3[] to, float time); // 0x00000001806F84B0-0x00000001806F8520
	public static LTDescr LeanMoveSplineLocal(this Transform transform, Vector3[] to, float time); // 0x00000001806F8520-0x00000001806F85B0
	public static LTDescr LeanMoveX(this GameObject gameObject, float to, float time); // 0x00000001806F87B0-0x00000001806F8820
	public static LTDescr LeanMoveX(this Transform transform, float to, float time); // 0x00000001806F8820-0x00000001806F88B0
	public static LTDescr LeanMoveX(this RectTransform rectTransform, float to, float time); // 0x00000001806F88B0-0x00000001806F8920
	public static LTDescr LeanMoveY(this GameObject gameObject, float to, float time); // 0x00000001806F89B0-0x00000001806F8A20
	public static LTDescr LeanMoveY(this Transform transform, float to, float time); // 0x00000001806F8920-0x00000001806F89B0
	public static LTDescr LeanMoveY(this RectTransform rectTransform, float to, float time); // 0x00000001806F8A20-0x00000001806F8A90
	public static LTDescr LeanMoveZ(this GameObject gameObject, float to, float time); // 0x00000001806F8B00-0x00000001806F8B70
	public static LTDescr LeanMoveZ(this Transform transform, float to, float time); // 0x00000001806F8B70-0x00000001806F8C00
	public static LTDescr LeanMoveZ(this RectTransform rectTransform, float to, float time); // 0x00000001806F8A90-0x00000001806F8B00
	public static void LeanPause(this GameObject gameObject); // 0x00000001806F91A0-0x00000001806F91F0
	public static LTDescr LeanPlay(this RectTransform rectTransform, Sprite[] sprites); // 0x00000001806F91F0-0x00000001806F9250
	public static void LeanResume(this GameObject gameObject); // 0x00000001806F9250-0x00000001806F92A0
	public static LTDescr LeanRotate(this GameObject gameObject, Vector3 to, float time); // 0x00000001806F9980-0x00000001806F9A00
	public static LTDescr LeanRotate(this Transform transform, Vector3 to, float time); // 0x00000001806F9A80-0x00000001806F9B20
	public static LTDescr LeanRotate(this RectTransform rectTransform, Vector3 to, float time); // 0x00000001806F9A00-0x00000001806F9A80
	public static LTDescr LeanRotateAround(this GameObject gameObject, Vector3 axis, float add, float time); // 0x00000001806F9540-0x00000001806F95E0
	public static LTDescr LeanRotateAround(this Transform transform, Vector3 axis, float add, float time); // 0x00000001806F9490-0x00000001806F9540
	public static LTDescr LeanRotateAround(this RectTransform rectTransform, Vector3 axis, float add, float time); // 0x00000001806F95E0-0x00000001806F9680
	public static LTDescr LeanRotateAroundLocal(this GameObject gameObject, Vector3 axis, float add, float time); // 0x00000001806F92A0-0x00000001806F9340
	public static LTDescr LeanRotateAroundLocal(this Transform transform, Vector3 axis, float add, float time); // 0x00000001806F93E0-0x00000001806F9490
	public static LTDescr LeanRotateAroundLocal(this RectTransform rectTransform, Vector3 axis, float add, float time); // 0x00000001806F9340-0x00000001806F93E0
	public static LTDescr LeanRotateX(this GameObject gameObject, float to, float time); // 0x00000001806F9710-0x00000001806F9780
	public static LTDescr LeanRotateX(this Transform transform, float to, float time); // 0x00000001806F9680-0x00000001806F9710
	public static LTDescr LeanRotateY(this GameObject gameObject, float to, float time); // 0x00000001806F9780-0x00000001806F97F0
	public static LTDescr LeanRotateY(this Transform transform, float to, float time); // 0x00000001806F97F0-0x00000001806F9880
	public static LTDescr LeanRotateZ(this GameObject gameObject, float to, float time); // 0x00000001806F9910-0x00000001806F9980
	public static LTDescr LeanRotateZ(this Transform transform, float to, float time); // 0x00000001806F9880-0x00000001806F9910
	public static LTDescr LeanScale(this GameObject gameObject, Vector3 to, float time); // 0x00000001806F9E20-0x00000001806F9EA0
	public static LTDescr LeanScale(this Transform transform, Vector3 to, float time); // 0x00000001806F9EA0-0x00000001806F9F40
	public static LTDescr LeanScale(this RectTransform rectTransform, Vector3 to, float time); // 0x00000001806F9F40-0x00000001806F9FC0
	public static LTDescr LeanScaleX(this GameObject gameObject, float to, float time); // 0x00000001806F9B20-0x00000001806F9B90
	public static LTDescr LeanScaleX(this Transform transform, float to, float time); // 0x00000001806F9B90-0x00000001806F9C20
	public static LTDescr LeanScaleY(this GameObject gameObject, float to, float time); // 0x00000001806F9C20-0x00000001806F9C90
	public static LTDescr LeanScaleY(this Transform transform, float to, float time); // 0x00000001806F9C90-0x00000001806F9D20
	public static LTDescr LeanScaleZ(this GameObject gameObject, float to, float time); // 0x00000001806F9D20-0x00000001806F9D90
	public static LTDescr LeanScaleZ(this Transform transform, float to, float time); // 0x00000001806F9D90-0x00000001806F9E20
	public static LTDescr LeanSize(this RectTransform rectTransform, Vector2 to, float time); // 0x00000001806FA2C0-0x00000001806FA330
	public static LTDescr LeanValue(this GameObject gameObject, Color from, Color to, float time); // 0x00000001806FA620-0x00000001806FA6C0
	public static LTDescr LeanValue(this GameObject gameObject, float from, float to, float time); // 0x00000001806FA8C0-0x00000001806FA950
	public static LTDescr LeanValue(this GameObject gameObject, Vector2 from, Vector2 to, float time); // 0x00000001806FA4E0-0x00000001806FA570
	public static LTDescr LeanValue(this GameObject gameObject, Vector3 from, Vector3 to, float time); // 0x00000001806FA570-0x00000001806FA620
	public static LTDescr LeanValue(this GameObject gameObject, Action<float> callOnUpdate, float from, float to, float time); // 0x00000001806FA3C0-0x00000001806FA450
	public static LTDescr LeanValue(this GameObject gameObject, Action<float, float> callOnUpdate, float from, float to, float time); // 0x00000001806FA6C0-0x00000001806FA750
	public static LTDescr LeanValue(this GameObject gameObject, Action<float, object> callOnUpdate, float from, float to, float time); // 0x00000001806FA450-0x00000001806FA4E0
	public static LTDescr LeanValue(this GameObject gameObject, Action<Color> callOnUpdate, Color from, Color to, float time); // 0x00000001806FA750-0x00000001806FA800
	public static LTDescr LeanValue(this GameObject gameObject, Action<Vector2> callOnUpdate, Vector2 from, Vector2 to, float time); // 0x00000001806FA330-0x00000001806FA3C0
	public static LTDescr LeanValue(this GameObject gameObject, Action<Vector3> callOnUpdate, Vector3 from, Vector3 to, float time); // 0x00000001806FA800-0x00000001806FA8C0
	public static void LeanSetPosX(this Transform transform, float val); // 0x00000001806FA140-0x00000001806FA1C0
	public static void LeanSetPosY(this Transform transform, float val); // 0x00000001806FA1C0-0x00000001806FA240
	public static void LeanSetPosZ(this Transform transform, float val); // 0x00000001806FA240-0x00000001806FA2C0
	public static void LeanSetLocalPosX(this Transform transform, float val); // 0x00000001806F9FC0-0x00000001806FA040
	public static void LeanSetLocalPosY(this Transform transform, float val); // 0x00000001806FA040-0x00000001806FA0C0
	public static void LeanSetLocalPosZ(this Transform transform, float val); // 0x00000001806FA0C0-0x00000001806FA140
	public static Color LeanColor(this Transform transform); // 0x00000001806F7C40-0x00000001806F7CC0
}

