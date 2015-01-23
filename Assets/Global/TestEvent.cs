using UnityEngine;
using System.Collections;

public class TestEvent : MonoBehaviour
{
    void Awake()
    {
        print("1");
        f();
    }

    public void f()
    {
        print(this);
    }
}
