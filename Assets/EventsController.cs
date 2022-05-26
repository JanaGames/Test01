using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EventLog 
{
    public string getNameCategory();
    public int getCount();
    public void increaseCount(int i);
}
public class AttackEvent : EventLog
{
    public int count;

    public string getNameCategory() {return "Attack";}
    public int getCount() {return count;}
    public void increaseCount(int i) {count += i;}
}
public class KillEvent : EventLog
{
    public int count;

    public string getNameCategory() {return "KillEvent";}
    public int getCount() {return count;}
    public void increaseCount(int i) {count += i;}
}
public class EventsController : MonoBehaviour
{
    public AttackEvent attackEvents;
    public KillEvent killEvents;

    public static EventsController instance;
    public static EventsController Instance 
    {
        get
        {
            if (instance == null) Debug.LogWarning("EventsController is a empty");
            return instance;
        }
    }
}
