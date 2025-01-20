using MessagePack;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

public partial class InstantiateByAddComponent : MonoBehaviour
{

    void Start()
    {
        Debug.Log($"[InstantiateByAddComponent] 这个脚本通过AddComponent的方式实例化.");

        Test();
    }

    private void Test()
    {
        float t1, t2;

        t1 = Time.realtimeSinceStartup;
        GeneratedResolver.Instance.GetFormatterWithVerify<A1>();
        t2 = Time.realtimeSinceStartup;

        Debug.LogFormat("GetFormatter<A1>: {0:0.000}ms", (t2 - t1) * 1000);

        StartCoroutine(Test1());
    }

    private IEnumerator Test1()
    {
        yield return new WaitForSeconds(5);

        float t1, t2;

        t1 = Time.realtimeSinceStartup;

        RunGeneratedCode();

        t2 = Time.realtimeSinceStartup;

        Debug.LogFormat("RunGeneratedCode: {0:0.000}ms", (t2 - t1) * 1000);
    }
}
