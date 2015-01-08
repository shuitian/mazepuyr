using UnityEngine;
using System.Collections;
using System;

public class BaseEventArgs : EventArgs
{
}

public class ScreenSizeEvent : BaseEventArgs
{
    public int newWidth;
    public int newHeight;
    public ScreenSizeEvent(int width, int height)
    {
        newWidth = width;
        newHeight = height;
    }
}

public class DeadEvent : BaseEventArgs
{
    public object dead;
    public object killer;
    public DeadEvent()
    {
    }
    public DeadEvent(object dead, object killer)
    {
        this.dead = dead;
        this.killer = killer;
    }
}

public class EnemyDeadEvent : DeadEvent
{
    public EnemyDeadEvent(object dead, object killer)
    {
        this.dead = dead;
        this.killer = killer;
    }
}

public class PlayerDeadEvent : DeadEvent
{
    public PlayerDeadEvent(object dead, object killer)
    {
        this.dead = dead;
        this.killer = killer;
    }
}

public class DamagedEvent : BaseEventArgs
{
    public float damage;
    public object beDamaged;
    public object damager;
    public DamagedEvent(object damager, object beDamaged, float damage)
    {
        this.damage = damage;
        this.beDamaged = beDamaged ;
        this.damager = damager;
    }
}