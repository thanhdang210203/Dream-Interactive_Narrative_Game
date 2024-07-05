using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class noteManage : MonoBehaviour
{
    public static noteManage instance;
    TextData textData;
    public Image notePanel;
    public GameObject note;
    public TextMeshProUGUI noteText;
    public CanvasGroup notePageCanvas;
    public CanvasGroup noteTextCanvas;

    public float notePagePos;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        noteText = note.GetComponentInChildren<TextMeshProUGUI>();
        textData = Resources.Load<TextData>("TextData");
        notePageCanvas = note.GetComponent<CanvasGroup>();
        noteTextCanvas = noteText.GetComponent<CanvasGroup>();
    }

    public IEnumerator openNote(int index)
    {
        float fromValue = 1f;
        notePanel.DOFade(1f, 1f).SetEase(Ease.Linear);
        note.SetActive(true);
        note.transform.DOLocalMoveY(notePagePos, 0.5f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.5f);
        noteText.text = textData.PCTexts[index];
        noteText.transform.DOLocalMove(Vector3.zero, 0.5f).SetEase(Ease.Linear);
        DOTween.To(() => fromValue, x => fromValue = x, 1, 0.2f)
            .OnUpdate(() =>
            {
                notePageCanvas.alpha = fromValue;
                noteTextCanvas.alpha = fromValue;
            });
    }

    public void closeNote()
    {
        float fromValue = 0f;
        notePanel.DOFade(0, 1f).SetEase(Ease.Linear);
        noteText.transform.DOLocalMove(new Vector3(0, -1500, 0), 0.5f).SetEase(Ease.Linear);
        DOTween.To(() => fromValue, x => fromValue = x, 0, 0.2f)
            .OnUpdate(() =>
            {
                notePageCanvas.alpha = fromValue;
                noteTextCanvas.alpha = fromValue;
            });
    }
    public void backToGame()
    {
        closeNote();
    }
}
