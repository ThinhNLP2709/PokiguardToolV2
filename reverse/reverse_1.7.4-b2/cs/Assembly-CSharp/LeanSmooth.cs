/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

public class LeanSmooth // TypeDefIndex: 315
{
	// Constructors
	public LeanSmooth(); // 0x00000001802E9CB0-0x00000001802E9CC0

	// Methods
	public static float damp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0068ADAF */, float deltaTime = -1f /* Metadata: 0x0068ADB3 */); // 0x000000018031E6F0-0x000000018031E880
	public static Vector3 damp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0068ADB7 */, float deltaTime = -1f /* Metadata: 0x0068ADBB */); // 0x000000018031E450-0x000000018031E580
	public static Color damp(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0068ADBF */, float deltaTime = -1f /* Metadata: 0x0068ADC3 */); // 0x000000018031E580-0x000000018031E6F0
	public static float spring(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0068ADC7 */, float deltaTime = -1f /* Metadata: 0x0068ADCB */, float friction = 2f /* Metadata: 0x0068ADCF */, float accelRate = 0.5f /* Metadata: 0x0068ADD3 */); // 0x000000018031EB10-0x000000018031EBF0
	public static Vector3 spring(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0068ADD7 */, float deltaTime = -1f /* Metadata: 0x0068ADDB */, float friction = 2f /* Metadata: 0x0068ADDF */, float accelRate = 0.5f /* Metadata: 0x0068ADE3 */); // 0x000000018031EBF0-0x000000018031ED70
	public static Color spring(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0068ADE7 */, float deltaTime = -1f /* Metadata: 0x0068ADEB */, float friction = 2f /* Metadata: 0x0068ADEF */, float accelRate = 0.5f /* Metadata: 0x0068ADF3 */); // 0x000000018031ED70-0x000000018031EF40
	public static float linear(float current, float target, float moveSpeed, float deltaTime = -1f /* Metadata: 0x0068ADF7 */); // 0x000000018031E960-0x000000018031EA00
	public static Vector3 linear(Vector3 current, Vector3 target, float moveSpeed, float deltaTime = -1f /* Metadata: 0x0068ADFB */); // 0x000000018031E880-0x000000018031E960
	public static Color linear(Color current, Color target, float moveSpeed); // 0x000000018031EA00-0x000000018031EB10
	public static float bounceOut(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0068ADFF */, float deltaTime = -1f /* Metadata: 0x0068AE03 */, float friction = 2f /* Metadata: 0x0068AE07 */, float accelRate = 0.5f /* Metadata: 0x0068AE0B */, float hitDamping = 0.9f /* Metadata: 0x0068AE0F */); // 0x000000018031E190-0x000000018031E2B0
	public static Vector3 bounceOut(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0068AE13 */, float deltaTime = -1f /* Metadata: 0x0068AE17 */, float friction = 2f /* Metadata: 0x0068AE1B */, float accelRate = 0.5f /* Metadata: 0x0068AE1F */, float hitDamping = 0.9f /* Metadata: 0x0068AE23 */); // 0x000000018031E2B0-0x000000018031E450
	public static Color bounceOut(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0068AE27 */, float deltaTime = -1f /* Metadata: 0x0068AE2B */, float friction = 2f /* Metadata: 0x0068AE2F */, float accelRate = 0.5f /* Metadata: 0x0068AE33 */, float hitDamping = 0.9f /* Metadata: 0x0068AE37 */); // 0x000000018031DF90-0x000000018031E190
}

