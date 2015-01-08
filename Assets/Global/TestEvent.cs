//using UnityEngine;
//using System.Collections;

//public class TestEvent : MonoBehaviour
//{
//    int width;
//    int height;
//    // Use this for initialization
//    void Start()
//    {
//        Message.RegeditMessageHandle(new Message.SCREEN_SIZE_CHANGE(), f);
//        width = Screen.width;
//        height = Screen.height;
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (Screen.width != width || Screen.height != height)
//        {
//            //Message.SCREEN_SIZE_CHANGE(this, new BaseEventArgs());
//            Message.raiseOneMessage(new Message.SCREEN_SIZE_CHANGE(), this, new BaseEventArgs());
//            width = Screen.width;
//            height = Screen.height;
//        }
//    }

//    void f(object sender, BaseEventArgs e)
//    {
//        print(1);
//    }
//}
