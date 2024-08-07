using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    [SerializeField] private Image gameLogo;

    private void Start()
    {
        gameLogo.DOFade(1, 0.5f);
        StartCoroutine(LogoOut());
    }
    private IEnumerator LogoOut()
    {
        yield return new WaitForSeconds(1f);
        gameLogo.DOFade(0, 1f);
    }
}
