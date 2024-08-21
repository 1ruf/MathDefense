using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class StartUI : MonoBehaviour
{
    [SerializeField] private GameObject setUI;
    [SerializeField] private TMP_Text mainTitle;
    [SerializeField] private Image gameLogo, background,blocker;
    [SerializeField] private Button playBtn,settingBtn,quitBtn;
    private RectTransform pBtn, sBtn, qBtn, sUI;

    private bool isBtnActing,isSetOpened;
    private void Awake()
    {
        pBtn = playBtn.GetComponent<RectTransform>();
        sBtn = settingBtn.GetComponent<RectTransform>();
        qBtn = quitBtn.GetComponent<RectTransform>();
        sUI = setUI.GetComponent<RectTransform>();
    }

    private void Start()
    {
        ResetPos();
        gameLogo.DOFade(1, 0.5f);
        StartCoroutine(LogoDisable());
    }
    private void ResetPos()
    {
        sUI.anchoredPosition = new Vector2(-1500,0);
        pBtn.DOMoveY(-100, 0);
        sBtn.DOMoveY(-100, 0);
        qBtn.DOMoveY(-100, 0);
        mainTitle.DOFade(0, 0);
    }
    private IEnumerator BtnEnable()
    {
        yield return new WaitForSeconds(0.5f);
        pBtn.DOMoveY(200, 1).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.2f);
        sBtn.DOMoveY(200, 1).SetEase(Ease.OutBack);
        background.DOFade(1, 1);
        yield return new WaitForSeconds(0.2f);
        qBtn.DOMoveY(200, 1).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.2f);
        mainTitle.DOFade(1, 2);
    }
    private IEnumerator BtnDisable()
    {
        pBtn.DOMoveY(-200, 0.7f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.2f);
        sBtn.DOMoveY(-200, 0.7f).SetEase(Ease.InBack);
        //background.DOFade(1, 1);
        yield return new WaitForSeconds(0.2f);
        qBtn.DOMoveY(-200, 0.7f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.2f);
        mainTitle.DOFade(0, 1);
    }
    private IEnumerator LogoDisable()
    {
        yield return new WaitForSeconds(1f);
        gameLogo.DOFade(0, 1f);
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(BtnEnable());
    }
    public void PlayBtnClicked()
    {
        blocker.DOFade(1, 2f).OnComplete(()=>SceneManager.LoadScene("MainScene"));
        StartCoroutine(BtnDisable());
    }
    public void MainSettingBtnClicked()
    {
        if (isSetOpened == false)
        {
            sUI.DOMoveX(960, 1);
            isSetOpened = true;
        }
        else
        {
            sUI.DOMoveX(-1500, 1);
            isSetOpened = false;
        }
    }
    public void InGameSetBtnClicked()
    {
        sUI.DOMoveX(-1500, 1);
        isSetOpened = false;
        StartCoroutine(BtnDisable());
    }
    public void QuitBtnClicked()
    {
        Application.Quit();
    }
}
