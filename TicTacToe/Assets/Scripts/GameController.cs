using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text[] buttonList;
    public GameObject gameOverPanel;
    public Text gameOverText;
    public GameObject restartButton;

    private int moveCount;
    private string playerSide;

    private void Awake() {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
        restartButton.SetActive(false);
    }

    void SetGameControllerReferenceOnButtons() {

        for (int i = 0; i < buttonList.Length; i++) {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide() {

        return playerSide;
    }

    public void EndTurn() {

        moveCount++;

        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide) {
            GameOver(playerSide);
        }

        if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide) {
            GameOver(playerSide);
        }

        if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide) {
            GameOver(playerSide);
        }

        if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide) {
            GameOver(playerSide);
        }

        if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide) {
            GameOver(playerSide);
        }

        if (buttonList[6].text == playerSide && buttonList[4].text == playerSide && buttonList[2].text == playerSide) {
            GameOver(playerSide);
        }

        if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide) {
            GameOver(playerSide);
        }

        if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide) {
            GameOver(playerSide);
        }

        if (moveCount >= 9) {

            GameOver("Draw");
        }

        ChangeSides();
    }

    void GameOver(string winningPlayer) {

        restartButton.SetActive(true);
        SetBoardInteractable(false);
        SetGameOverText(playerSide + " Wins!");

        if (winningPlayer == "draw") {

            SetGameOverText("It's a Draw!");
        } 
        
        else {

            SetGameOverText(winningPlayer + " Wins!");
        }
    }

    void ChangeSides() {

        playerSide = (playerSide == "X") ? "O" : "X";
    }

    void SetGameOverText(string value) {

        gameOverPanel.SetActive(true);
        gameOverText.text = value;
    }

    public void RestartGame() {

        playerSide = "X";
        moveCount = 0;
        gameOverPanel.SetActive(false);
        SetBoardInteractable(true);
        restartButton.SetActive(false);

        for (int i = 0; i < buttonList.Length; i++) {

            buttonList[i].text = "";
        }
    }

    void SetBoardInteractable(bool toggle) {

        for (int i = 0; i < buttonList.Length; i++) {

            buttonList[i].GetComponentInParent<Button>().interactable = toggle;
        }
    }
}