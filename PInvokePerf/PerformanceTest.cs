﻿using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace PInvokePerf
{
	public class PerformanceTest
	{
		public delegate int CountDelegate(string[] array,int index);

		public static int ManagedCount(string[] arr,int i)
		{
			int sum = 0;
			for (int j = 0; j < arr [i].Length; j++) {
				sum+=(int)arr[i][j];
			}
	
			return sum;
		}

		public static bool Validate(string[] arr,CountDelegate d)
		{
			int sum = 0;

			for (int i = 0; i < arr.Length; i++) {
				sum = 0;
				for (int j = 0; j < arr [i].Length; j++) {
					sum += (int)arr [i] [j];
				}
				if (sum != d (arr, i))
					return false;
			}

			return true;
		}

        [DllImport("libperf.so", EntryPoint= "init")]
		public static extern void InitInternals();

		[DllImport ("libperf.so",EntryPoint="internalCount")]
		[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
		public static extern int InternalCount(string[] arr, int i);
	}
}

