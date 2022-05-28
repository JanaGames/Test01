using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EventLog 
{
    string getNameCategory();
    int getCount();
    void increaseCount(int i);
}
[System.Serializable]
public class AttackEvent : EventLog
{
    public int count;

    public string getNameCategory() {return "Attack";}
    public int getCount() {return count;}
    public void increaseCount(int i) {count += i;}
}
[System.Serializable]
public class KillEvent : EventLog
{
    public int count;

    public string getNameCategory() {return "Kill";}
    public int getCount() {return count;}
    public void increaseCount(int i) {count += i;}
}
[System.Serializable]
public class MissEvent : EventLog
{
    public int count;

    public string getNameCategory() {return "Miss";}
    public int getCount() {return count;}
    public void increaseCount(int i) {count += i;}
}
public class EventsController : MonoBehaviour
{
    public AttackEvent attackEvents;
    public MissEvent missEvents;
    public KillEvent killEvents;

    public string startGame = "";
    public string endGame = "";

    public string finalText = "Potracheno";

    public static EventsController instance;
    public static EventsController Instance 
    {
        get
        {
            if (instance == null) Debug.LogWarning("EventsController is a empty");
            return instance;
        }
    }
    private void Start() {
        instance = this;
    }
    public void LoadTime(string time) 
    {
        if (startGame == "") startGame = time;
        else endGame = time;
    }
}
