using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLogSlot : MonoBehaviour
{
    public QuestLogController QuestLogController;
    public void firstbtn()
    {
        QuestLogController.clickedBtn(0);
    }
    public void secbtn()
    {
        QuestLogController.clickedBtn(1);

    }
    public void trdbtn()
    {
        QuestLogController.clickedBtn(2);

    }
}
