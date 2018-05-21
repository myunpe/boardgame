using UnityEngine;

namespace Framework
{
	public class Log
    {

#if RELEASE
		[System.Diagnostics.Conditional("DEBUG")]
#endif
		public static void D(string text)
        {
            Debug.Log(text);
        }
#if RELEASE
        [System.Diagnostics.Conditional("DEBUG")]
#endif
        public static void D<T>(string format, T t1)
        {
            Debug.Log(string.Format(format, t1.ToString()));
        }

#if RELEASE
		[System.Diagnostics.Conditional("DEBUG")]
#endif
        public static void D<T1, T2>(string format, T1 t, T2 t2)
        {
            Debug.Log(string.Format(format, t.ToString(), t2.ToString()));
        }

#if RELEASE
		[System.Diagnostics.Conditional("DEBUG")]
#endif
        public static void D<T1, T2, T3>(string format, T1 t, T2 t2, T3 t3)
        {
            Debug.Log(string.Format(format, t.ToString(), t2.ToString(), t3.ToString()));
        }

    }
}
