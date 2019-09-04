//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;

//public class DockManager : MonoBehaviour
//{
//    /// <summary>
//    /// キャラクタのアイコンに設定されたボタン
//    /// inspecter上で追加
//    /// </summary>
//    public GameObject[] CharaIcons;
//    private List<UIButton> CharaButtons;
//    /// <summary>
//    /// CardのGameObject
//    /// inspecter上で追加
//    /// </summary>
//    public GameObject[] Cards;

//    /// <summary>
//    /// indexで指定されたキャラクタを表示
//    /// </summary>
//    /// <param name="index">Index.</param>
//    public void GoToChara(int index)
//    {
//        setDockButton(CharaButtons[index]);
//        setCard(Cards[index]);
//    }

//    void Start()
//    {
//        //初期化 ButtonPropertyのIndexはインスペクター上で設定しても良い。
//        CharaButtons = new List<UIButton>();
//        for (int i = 0; i < CharaIcons.Length; i++)
//        {
//            ButtonProperty bp = CharaIcons[i].GetComponent<ButtonProperty>();
//            bp.Index = i;
//            CharaButtons.Add(CharaIcons[i].GetComponent<UIButton>());
//        }
//    }

//    /// <summary>
//    /// フォーカスされているアイコンは選択不可、それ以外は選択可に変更
//    /// </summary>
//    /// <param name="focusButton">Focus button.</param>
//    private void setDockButton(UIButton focusButton)
//    {
//        foreach (UIButton button in CharaButtons)
//        {
//            button.isEnabled = true;
//        }
//        focusButton.isEnabled = false;
//    }

//    /// <summary>
//    /// フォーカスされたカードのみ表示
//    /// </summary>
//    /// <param name="focusCard">Focus card.</param>
//    private void setCard(GameObject focusCard)
//    {
//        foreach (GameObject card in Cards)
//        {
//            card.SetActive(false);
//        }
//        focusCard.SetActive(true);
//    }
//}