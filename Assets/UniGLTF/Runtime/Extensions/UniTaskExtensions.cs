using System.Collections;
using Cysharp.Threading.Tasks;

namespace UniGLTF
{
    public static class UniTaskExtensions
    {
        public static UniTask<T> Wait<T>(this UniTask<T> t)
        {
            static void WaitCoroutine(IEnumerator func) {
                while (func.MoveNext ()) {
                    if (func.Current is IEnumerator current) {
                        WaitCoroutine(current);
                    }
                }
            }
            
            WaitCoroutine(t.ToCoroutine());
            return t;
        }
    }
}