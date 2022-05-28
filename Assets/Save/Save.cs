using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveEvent 
{
    public int count;
    public string name;
    
    public SaveEvent(EventLog log) 
    {
        count = log.getCount();
        name = log.getNameCategory();
    }
}
[System.Serializable]
public class Save 
{
    public SaveEvent attackEventsSave;
    public SaveEvent missEventsSave;
    public SaveEvent killEventsSave;
    public string startGame;
    public string endGame;
}
