using System;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
	public static T Ins
	{
		get
		{
			return Singleton<T>.instance;
		}
	}

	public Singleton():base()
	{
		//FORALAND 单例问题
		// if (Singleton<T>.instance == null)
		// {
			Singleton<T>.instance = (this as T);
			return;
		// }
		// if (Singleton<T>.instance != this)
		// {
		// 	UnityEngine.Object.DestroyImmediate(this);
		// }
	}

	private static T instance;
}
