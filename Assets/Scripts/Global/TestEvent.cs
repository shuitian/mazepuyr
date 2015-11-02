using UnityEngine;
using System.Collections;
using UnityTool.Libgame;
public class TestEvent : MonoBehaviour
{
    void Awake()
    {
        print("Awake");
        f();
        Message.RegeditMessageHandle<string>("Test", test);
    }

    void OnDestroy()
    {
        print("OnDestroy");
        Message.UnregeditMessageHandle<string>("Test", test);
    }

    public void f()
    {
        print(this);
    }

    public void test(string messageName, object sender, string e)
    {
        print(messageName);
        print(sender);
        print(e);
    }
}
