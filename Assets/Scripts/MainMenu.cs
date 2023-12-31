using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private Button previousButton;
    [SerializeField] private TextMeshProUGUI levelDifficultlyText;

    private void Start()
    {
        playButton.onClick.AddListener(delegate ()
        {
            SceneManager.LoadScene(1);
        });

        settingsButton.onClick.AddListener(delegate ()
        {
            playButton.gameObject.SetActive(false);
            settingsButton.gameObject.SetActive(false);
            quitButton.gameObject.SetActive(false);
            dropdown.gameObject.SetActive(true);
            previousButton.gameObject.SetActive(true);
            levelDifficultlyText.gameObject.SetActive(true);

            previousButton.onClick.AddListener(delegate ()
            {
                playButton.gameObject.SetActive(true);
                settingsButton.gameObject.SetActive(true);
                quitButton.gameObject.SetActive(true);
                dropdown.gameObject.SetActive(false);
                previousButton.gameObject.SetActive(false);
                levelDifficultlyText.gameObject.SetActive(false);
            });

        });

        quitButton.onClick.AddListener(delegate ()
        {
            Application.Quit();
        });
    }
}