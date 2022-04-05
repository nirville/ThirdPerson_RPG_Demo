using UnityEngine;

public class QuestController : MonoBehaviour
{
    public static QuestController Instance;
    void Awake() => Instance = this;

    public Quest currQuest;
    public int currItemsCounter;
    public bool isQuestActive = false;
    public string questResult = "";
    public float timer = 0;

    void Start()
    {
        timer = currQuest.timeLimit;
    }

    void Update()
    {
        if (!isQuestActive) return;
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            isQuestActive = false;
            timer = 60;
            GameEvents.current.GameEnd();
        }
    }

    internal void PlayerCollectedItem()
    {
        currItemsCounter++;
        GameEvents.current.UpdateTask();

        if (currItemsCounter == currQuest.itemsRequired)
        {
            GameEvents.current.GameEnd();
            questResult = "You Win!";
        }
    }
}
