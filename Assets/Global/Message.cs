using UnityEngine;
using System.Collections;

public delegate void MessageHandle(object sender, BaseEventArgs e);
public class Message
{
    static public void RegeditMessageHandle(BASE_MESSAGE message, MessageHandle function)
    {
        message.addListener(function);
    }
    static public void RemoveMessageHandle(BASE_MESSAGE message, MessageHandle function)
    {
        message.removeListener(function);
    }
    static public void raiseOneMessage(BASE_MESSAGE message, object sender, BaseEventArgs e)
    {
        message.run(sender, e);
    }

    //static public int MAX_MESSAGE_NUMBER = 1;
    public class BASE_MESSAGE //: MonoBehaviour
    {
        static public event MessageHandle handle;
        public virtual void addListener(MessageHandle function)
        {
            handle += function;
        }
        public virtual void removeListener(MessageHandle function)
        {
            handle -= function;
        }
        public virtual void run(object sender, BaseEventArgs e)
        {
            if (handle != null)
            {
                handle(sender, e);
            }
        }
    }

    public class SCREEN_SIZE_INIT : BASE_MESSAGE{static public event MessageHandle handle;public override void addListener(MessageHandle function){handle += function;}public override void removeListener(MessageHandle function){handle -= function;}public override void run(object sender, BaseEventArgs e){if (handle != null){handle(sender, e);}}};
    public class SCREEN_SIZE_CHANGE : BASE_MESSAGE{static public event MessageHandle handle;public override void addListener(MessageHandle function){handle += function;}public override void removeListener(MessageHandle function){handle -= function;}public override void run(object sender, BaseEventArgs e){if (handle != null){handle(sender, e);}}};
    public class ON_PAUSE : BASE_MESSAGE { static public event MessageHandle handle; public override void addListener(MessageHandle function) { handle += function; } public override void removeListener(MessageHandle function) { handle -= function; } public override void run(object sender, BaseEventArgs e) { if (handle != null) { handle(sender, e); } } };
    public class ENEMY_DEAD : BASE_MESSAGE { static public event MessageHandle handle; public override void addListener(MessageHandle function) { handle += function; } public override void removeListener(MessageHandle function) { handle -= function; } public override void run(object sender, BaseEventArgs e) { if (handle != null) { handle(sender, e); } } };
    public class PLAYER_DEAD : BASE_MESSAGE { static public event MessageHandle handle; public override void addListener(MessageHandle function) { handle += function; } public override void removeListener(MessageHandle function) { handle -= function; } public override void run(object sender, BaseEventArgs e) { if (handle != null) { handle(sender, e); } } };

    public class LEVELISDONE : BASE_MESSAGE { static public event MessageHandle handle; public override void addListener(MessageHandle function) { handle += function; } public override void removeListener(MessageHandle function) { handle -= function; } public override void run(object sender, BaseEventArgs e) { if (handle != null) { handle(sender, e); } } };

    
}
