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
    public TextData textData;
    public Transform notePanel;
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
        notePageCanvas = note.GetComponent<CanvasGroup>();
        noteTextCanvas = noteText.GetComponent<CanvasGroup>();
    }

    public void openNote(int index)
    {
        AudioManager.instance.PlaySoundEffect(2);
        float fromValue = 1f;
        notePanel.DOScale(1, 0.3f).SetEase(Ease.Linear);
        note.SetActive(true);
        note.transform.DOLocalMoveY(notePagePos, 0.5f).SetEase(Ease.Linear);
        noteText.text = textData.PCTexts[index];
        noteText.transform.DOLocalMove(Vector3.zero, 0.5f).SetEase(Ease.Linear);
        DOTween.To(() => fromValue, x => fromValue = x, 1, 0.2f)
            .OnUpdate(() =>
            {
                notePageCanvas.alpha = fromValue;
                noteTextCanvas.alpha = fromValue;
            });
    }

    public void simnpleNoteOpen(int index)
    {
        noteText.text = textData.PCTexts[index];
    }

    public void closeNote()
    {
        AudioManager.instance.PlaySoundEffect(3);
        float fromValue = 0f;
        notePanel.DOScale(0, 0.3f).SetEase(Ease.Linear);
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
