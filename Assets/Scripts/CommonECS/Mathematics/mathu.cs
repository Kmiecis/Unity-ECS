using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace CommonECS.Mathematics
{
	/// <summary>
	/// Utility math library
	/// </summary>
	public static class mathu
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static quaternion rotate_towards(quaternion a, quaternion b, float radians)
		{
			float angle = mathu.angle(a, b);
			if (angle == 0.0f)
				return b;
			return math.slerp(a, b, math.min(1.0f, radians / angle));
		}


		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float angle(quaternion a, quaternion b)
		{
			var dot = math.dot(a, b);
			return (dot > 1.0f - mathx.EPSILON) ? 0.0f : math.acos(math.min(math.abs(dot), 1.0f)) * 2.0f;
		}
		

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float smooth_damp(float current, float target, float speed, float time, float delta_time, ref float velocity)
		{
			float output = 0.0f;

			// Based on Game Programming Gems 4 Chapter 1.10
			time = math.max(0.0001f, time);
			float omega = 2.0f / time;

			float x = omega * delta_time;
			float exp = 1.0f / (1.0f + x + 0.48f * x * x + 0.235f * x * x * x);

			float change = current - target;
			float originalTo = target;

			// Clamp maximum speed
			float maxChange = speed * time;

			float maxChangeSq = maxChange * maxChange;
			float sqrmag = change * change;
			if (sqrmag > maxChangeSq)
			{
				var mag = math.sqrt(sqrmag);
				change = change / mag * maxChange;
			}

			target = current - change;

			float temp = (velocity + omega * change) * delta_time;

			velocity = (velocity - omega * temp) * exp;

			output = target + (change + temp) * exp;

			// Prevent overshooting
			float origMinusCurrent = originalTo - current;
			float outMinusOrig = output - originalTo;

			if (origMinusCurrent * outMinusOrig > 0)
			{
				output = originalTo;

				velocity = (output - originalTo) / delta_time;
			}

			return output;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 smooth_damp(float2 current, float2 target, float speed, float time, float delta_time, ref float2 velocity)
		{
			float output_x = 0.0f;
			float output_y = 0.0f;

			// Based on Game Programming Gems 4 Chapter 1.10
			time = math.max(0.0001f, time);
			float omega = 2.0f / time;

			float x = omega * delta_time;
			float exp = 1.0f / (1.0f + x + 0.48f * x * x + 0.235f * x * x * x);

			float change_x = current.x - target.x;
			float change_y = current.y - target.y;
			float2 originalTo = target;

			// Clamp maximum speed
			float maxChange = speed * time;

			float maxChangeSq = maxChange * maxChange;
			float sqrmag = change_x * change_x + change_y * change_y;
			if (sqrmag > maxChangeSq)
			{
				var mag = (float)math.sqrt(sqrmag);
				change_x = change_x / mag * maxChange;
				change_y = change_y / mag * maxChange;
			}

			target.x = current.x - change_x;
			target.y = current.y - change_y;

			float temp_x = (velocity.x + omega * change_x) * delta_time;
			float temp_y = (velocity.y + omega * change_y) * delta_time;

			velocity.x = (velocity.x - omega * temp_x) * exp;
			velocity.y = (velocity.y - omega * temp_y) * exp;

			output_x = target.x + (change_x + temp_x) * exp;
			output_y = target.y + (change_y + temp_y) * exp;

			// Prevent overshooting
			float origMinusCurrent_x = originalTo.x - current.x;
			float origMinusCurrent_y = originalTo.y - current.y;
			float outMinusOrig_x = output_x - originalTo.x;
			float outMinusOrig_y = output_y - originalTo.y;

			if (origMinusCurrent_x * outMinusOrig_x + origMinusCurrent_y * outMinusOrig_y > 0)
			{
				output_x = originalTo.x;
				output_y = originalTo.y;

				velocity.x = (output_x - originalTo.x) / delta_time;
				velocity.y = (output_y - originalTo.y) / delta_time;
			}

			return new float2(output_x, output_y);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 smooth_damp(float3 current, float3 target, float speed, float time, float delta_time, ref float3 velocity)
		{
			float output_x = 0.0f;
			float output_y = 0.0f;
			float output_z = 0.0f;

			// Based on Game Programming Gems 4 Chapter 1.10
			time = math.max(0.0001f, time);
			float omega = 2.0f / time;

			float x = omega * delta_time;
			float exp = 1.0f / (1.0f + x + 0.48f * x * x + 0.235f * x * x * x);

			float change_x = current.x - target.x;
			float change_y = current.y - target.y;
			float change_z = current.z - target.z;
			float3 originalTo = target;

			// Clamp maximum speed
			float maxChange = speed * time;

			float maxChangeSq = maxChange * maxChange;
			float sqrmag = change_x * change_x + change_y * change_y + change_z * change_z;
			if (sqrmag > maxChangeSq)
			{
				var mag = (float)math.sqrt(sqrmag);
				change_x = change_x / mag * maxChange;
				change_y = change_y / mag * maxChange;
				change_z = change_z / mag * maxChange;
			}

			target.x = current.x - change_x;
			target.y = current.y - change_y;
			target.z = current.z - change_z;

			float temp_x = (velocity.x + omega * change_x) * delta_time;
			float temp_y = (velocity.y + omega * change_y) * delta_time;
			float temp_z = (velocity.z + omega * change_z) * delta_time;

			velocity.x = (velocity.x - omega * temp_x) * exp;
			velocity.y = (velocity.y - omega * temp_y) * exp;
			velocity.z = (velocity.z - omega * temp_z) * exp;

			output_x = target.x + (change_x + temp_x) * exp;
			output_y = target.y + (change_y + temp_y) * exp;
			output_z = target.z + (change_z + temp_z) * exp;

			// Prevent overshooting
			float origMinusCurrent_x = originalTo.x - current.x;
			float origMinusCurrent_y = originalTo.y - current.y;
			float origMinusCurrent_z = originalTo.z - current.z;
			float outMinusOrig_x = output_x - originalTo.x;
			float outMinusOrig_y = output_y - originalTo.y;
			float outMinusOrig_z = output_z - originalTo.z;

			if (origMinusCurrent_x * outMinusOrig_x + origMinusCurrent_y * outMinusOrig_y + origMinusCurrent_z * outMinusOrig_z > 0)
			{
				output_x = originalTo.x;
				output_y = originalTo.y;
				output_z = originalTo.z;

				velocity.x = (output_x - originalTo.x) / delta_time;
				velocity.y = (output_y - originalTo.y) / delta_time;
				velocity.z = (output_z - originalTo.z) / delta_time;
			}

			return new float3(output_x, output_y, output_z);
		}
	}
}