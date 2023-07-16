using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("BUTTONS")]
    [SerializeField] private RectTransform playButton;
    [SerializeField] private RectTransform gameplayButton;
    [SerializeField] private RectTransform quitButton;
    [SerializeField] private RectTransform volumeButton;

    [Space(6)]
    [Header("IMAGES")]
    [SerializeField] private CanvasGroup gameName;
    [SerializeField] private CanvasGroup fadeScreen;

    [Space(6)]
    [Header("PANELS")]
    [SerializeField] private RectTransform gameplayPanel;

    [Space(6)]
    [Header("SPRITES")]
    [SerializeField] private Sprite volumeOffSprite;
    [SerializeField] private Sprite volumeOnSprite;

    [Space(6)]
    [Header("MUSIC")]
    [SerializeField] private AudioSource menuMusic;

    [Space(6)]
    [Header("TIMERS")]
    [SerializeField] private float buttonOpeningTime = .6f;
    [SerializeField] private float fadeTime = 1f;
    [SerializeField] private float panelTime = 1f;

    private void Start()
    {
        StartCoroutine(StartUI());
    }

    private IEnumerator StartUI()
    {
        fadeScreen.blocksRaycasts = true;
        fadeScreen.DOFade(0f, fadeTime);
        yield return new WaitForSeconds(fadeTime);

        gameName.DOFade(1f, fadeTime);
        yield return new WaitForSeconds(fadeTime);

        //menuMusic.Play();

        playButton.DOScale(1f, buttonOpeningTime).SetEase(Ease.InQuint);
        yield return new WaitForSeconds(buttonOpeningTime);

        gameplayButton.DOScale(1f, buttonOpeningTime).SetEase(Ease.InQuint);
        yield return new WaitForSeconds(buttonOpeningTime);

        quitButton.DOScale(1f, buttonOpeningTime).SetEase(Ease.InQuint);
        yield return new WaitForSeconds(buttonOpeningTime);

        //volumeButton.DOScale(1f, buttonOpeningTime).SetEase(Ease.InQuint);
        yield return new WaitForSeconds(buttonOpeningTime);

        fadeScreen.blocksRaycasts = false;
    }

    #region BUTTON FUNCTIONS
    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }

    private IEnumerator PlayRoutine()
    {
        SoundManager.Instance.PlaySoundEffect(0);
        fadeScreen.blocksRaycasts = true;
        fadeScreen.DOFade(1f, fadeTime);
        yield return new WaitForSeconds(fadeTime);

        SceneManager.LoadScene("MainGameScene");
    }

    public void Gameplay()
    {
        StartCoroutine(OpenPanelRoutine(gameplayPanel));
    }

    public void Quit()
    {
        StartCoroutine(QuitRoutine());
    }

    private IEnumerator QuitRoutine()
    {
        SoundManager.Instance.PlaySoundEffect(0);
        fadeScreen.blocksRaycasts = true;
        fadeScreen.DOFade(1f, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        Application.Quit();
    }

    public void VolumeOnOff()
    {
        SoundManager.Instance.PlaySoundEffect(0);
        if (volumeButton.GetComponent<Image>().sprite == volumeOnSprite)
        {
            menuMusic.volume = 0;
            volumeButton.GetComponent<Image>().sprite = volumeOffSprite;
        }
        else if (volumeButton.GetComponent<Image>().sprite == volumeOffSprite)
        {
            menuMusic.volume = 1;
            volumeButton.GetComponent<Image>().sprite = volumeOnSprite;
        }
    }

    public void Back(RectTransform panel)
    {
        StartCoroutine(BackRoutine(panel));
    }

    private IEnumerator BackRoutine(RectTransform panel)
    {
        SoundManager.Instance.PlaySoundEffect(0);
        panel.DOScale(0f, 1f);
        fadeScreen.DOFade(0f, panelTime);
        yield return new WaitForSeconds(panelTime);
        panel.gameObject.SetActive(false);
        fadeScreen.blocksRaycasts = false;
    }

    private IEnumerator OpenPanelRoutine(RectTransform panel)
    {
        SoundManager.Instance.PlaySoundEffect(0);
        panel.gameObject.SetActive(true);
        yield return null;

        fadeScreen.blocksRaycasts = true;
        fadeScreen.DOFade(.5f, panelTime);
        panel.DOScale(1f, panelTime);
    }
    #endregion
}
