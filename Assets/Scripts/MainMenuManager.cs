using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{

    public TextMeshProUGUI moneyText;
    public float moneyAmount = 999999;
    public GameObject ShopButtonSelected;


    private void Awake()
    {
        DOTween.Init();
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Se ha salido con éxito");
    }

    public void LogOut()
    {
        SceneManager.LoadScene("LoginScreen");
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }


    //ShopScripts
    public void SelectButton(GameObject newButton)
    {
        ShopButtonSelected = newButton;
    }
    public void SoldButton()
    {
        moneyAmount -= 100;
        moneyText.text = moneyAmount.ToString();
        ShopButtonSelected.GetComponent<Button>().interactable = false;
        ShopButtonSelected.GetComponent<Button>().transform.GetChild(1).gameObject.SetActive(false);
        ShopButtonSelected.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You already own this item";
        ShopButtonSelected = null;
    }

    public void BuyCurrency(int currency)
    {
        moneyAmount += currency;
        moneyText.text = moneyAmount.ToString();
    }

    public void ClearInput(TMP_InputField addFriendInput)
    {
        addFriendInput.text = string.Empty;
    }


}
