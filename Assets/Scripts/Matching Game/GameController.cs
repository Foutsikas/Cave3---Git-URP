using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private Sprite bgImage;
    public Sprite[] pieces;
    public List<Sprite> gamePieces = new List<Sprite>();
    public List<Button> btns = new List<Button>();
    private bool firstGuess, secondGuess;
    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;

    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessPiece, secondGuessPiece;

    public GameObject GameWin_Popup;
    public TMP_Text GameOverText;

    void Awake()
    {
        pieces = Resources.LoadAll<Sprite> ("Sprites/Minigames_Sprites/Cards");
    }

    void Start()
    {
        GetButtons();
        AddListeners();
        AddGamePieces();
        Shuffle(gamePieces);
        gameGuesses = gamePieces.Count / 2;
    }

    void GetButtons()//Sets the button on the game.
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag ("PieceButton");

        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }

    void AddGamePieces()
    {
        int looper = btns.Count; //Sets the looper's value as the total number of the buttons.
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2) //If index's value is the same as looper's divided by 2 then set the index to zero again.
            {
                index = 0;
            }
            gamePieces.Add(pieces[index]);
            index++;
        }
    }

    void AddListeners() //On piece click calls the PickAPiece debug log.
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => PickAPiece());
        }
    }
    public void PickAPiece()
    {
        if(!firstGuess)
        {
            firstGuess = true;

            firstGuessIndex = int.Parse(EventSystem.current.currentSelectedGameObject.name);

            firstGuessPiece = gamePieces[firstGuessIndex].name;

            btns[firstGuessIndex].image.sprite = gamePieces[firstGuessIndex];
            transform.rotation = Quaternion.AngleAxis( 180, new Vector3(0, 0, 1) );
            btns[firstGuessIndex].interactable = false;

        }else if (!secondGuess)
        {
            secondGuess = true;

            secondGuessIndex = int.Parse(EventSystem.current.currentSelectedGameObject.name);

            secondGuessPiece = gamePieces[secondGuessIndex].name;

            btns[secondGuessIndex].image.sprite = gamePieces[secondGuessIndex];
            transform.rotation = Quaternion.AngleAxis( 180, new Vector3(0, 0, 1) );
            btns[secondGuessIndex].interactable = false;

            countGuesses++;

            StartCoroutine (CheckIfThePiecesMatch());
        }
    }
    IEnumerator CheckIfThePiecesMatch()
    {
        yield return new WaitForSeconds (1f);

        if (firstGuessPiece == secondGuessPiece) // If the guess is correct the buttons turn uninteractable and turn them invinsible
        {
            yield return new WaitForSeconds(.5f);

            btns[firstGuessIndex].image.color = btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinished();
        }else
        {
            btns[firstGuessIndex].image.sprite = btns[secondGuessIndex].image.sprite = bgImage;
            btns[firstGuessIndex].interactable = btns[secondGuessIndex].interactable = true;
        }

        yield return new WaitForSeconds(.5f);

        firstGuess = secondGuess = false;
    }

    void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;

        if(countCorrectGuesses == gameGuesses)
        {
            Debug.Log("Game Finished");
            GameWin_Popup.SetActive(true);
            Debug.Log("It took you " + countGuesses + " guesses to finish the game");
            GameOverText.text = "Σου πήρε " + countGuesses + " προσπάθειες για να κερδίσεις!";
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(0, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
