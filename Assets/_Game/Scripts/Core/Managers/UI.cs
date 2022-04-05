using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    public Canvas startCanvas;
    public Canvas inGameHUDCanvas;
    public Canvas endCanvas;

    public Button startButton;
    public Button continueButton;

    public TMP_Text inGame_QuestDescription_Text;
    public TMP_Text inGame_ItemRequired_Text;
    public TMP_Text inGame_TimeLimit_Text;
    public TMP_Text inGame_currItemsCollected_Text;

    public TMP_Text endQuestStatus_Text;

    void Start()
    {
        GameEvents.current.onGameStart += GameStartHUD;
        GameEvents.current.onGameEnd += GameEndHUD;
        GameEvents.current.onUpdateTask += UpdateTaskInGameHUD;
        SwitchToCanvas(startCanvas);

        startButton.onClick.AddListener(() =>
        {
            GameEvents.current.GameStart();
            QuestController.Instance.isQuestActive = true;
        });

        continueButton.onClick.AddListener(() =>
       {
           UnityEngine.SceneManagement.SceneManager.LoadScene(0);
       });
    }

    void Update()
    {
        if (!QuestController.Instance.isQuestActive) return;
        inGame_TimeLimit_Text.text = QuestController.Instance.timer.ToString("F2");
    }

    void GameStartHUD()
    {
        SwitchToCanvas(inGameHUDCanvas);
        inGame_ItemRequired_Text.text = QuestController.Instance.currQuest.itemsRequired.ToString();
        inGame_QuestDescription_Text.text = QuestController.Instance.currQuest.description.ToString();
        inGame_TimeLimit_Text.text = QuestController.Instance.currQuest.timeLimit.ToString();
    }

    void GameEndHUD()
    {
        SwitchToCanvas(endCanvas);
        endQuestStatus_Text.text = QuestController.Instance.questResult;
    }
    

    void UpdateTaskInGameHUD()
    {
        inGame_currItemsCollected_Text.text = QuestController.Instance.currItemsCounter.ToString();
    }

    void SwitchToCanvas(Canvas canvas)
    {
        print(canvas.name);
        startCanvas.gameObject.SetActive(false);
        inGameHUDCanvas.gameObject.SetActive(false);
        endCanvas.gameObject.SetActive(false);
        canvas.gameObject.SetActive(true);
    }

    void OnDisable()
    {
        GameEvents.current.onGameStart -= GameStartHUD;
        GameEvents.current.onGameEnd -= GameEndHUD;
        GameEvents.current.onUpdateTask -= UpdateTaskInGameHUD;
    }
}
