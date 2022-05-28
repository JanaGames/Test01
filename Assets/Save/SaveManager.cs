using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void Save() 
    {
        Save saveMain = new Save();
        saveMain.attackEventsSave = new SaveEvent(EventsController.Instance.attackEvents); 
        saveMain.missEventsSave = new SaveEvent(EventsController.Instance.missEvents); 
        saveMain.killEventsSave = new SaveEvent(EventsController.Instance.killEvents); 
        saveMain.startGame = EventsController.Instance.startGame;
        saveMain.endGame = EventsController.Instance.endGame;
        string nameSaveMain = "GameStat";
        SaveSystem.Save(nameSaveMain, saveMain);
    }
    public Save Load() 
    {
        //if error loading
        Save saveMain = new Save();
        
        string nameSaveMain = "GameStat";
        saveMain = SaveSystem.Load(nameSaveMain);
        return saveMain;
    }
}
