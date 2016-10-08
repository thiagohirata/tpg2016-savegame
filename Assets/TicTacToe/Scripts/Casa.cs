using UnityEngine;
using UnityEngine.UI;


public class Casa : MonoBehaviour {
    public int indiceDoTabuleiro;
	// Use this for initialization
	void Start () {
        GetComponent<Button>().onClick.AddListener(OnClick);

        int valorDoTabuleiro = TicTacToe.main.pos[indiceDoTabuleiro];

        if (valorDoTabuleiro == 1)
        {
            GetComponentInChildren<Text>().text = "X";
        }
        else if (valorDoTabuleiro == 2)
        {
            GetComponentInChildren<Text>().text = "O";
        }


    }

    void Update()
    {
        if(TicTacToe.main.vencedor != 0)
        {
            GetComponent<Button>().interactable = false;
        }
    }

    public void OnClick()
    {
        GetComponent<Button>().interactable = false;

        TicTacToe.main.pos[indiceDoTabuleiro] = TicTacToe.main.jogador;


        if(TicTacToe.main.jogador == 1)
        {
            GetComponentInChildren<Text>().text = "X";
            TicTacToe.main.jogador = 2;
        } else
        {
            GetComponentInChildren<Text>().text = "O";
            TicTacToe.main.jogador = 1;
        }
        TicTacToe.main.VerificarVitoria();
        TicTacToe.main.SaveGame();
    }
}
