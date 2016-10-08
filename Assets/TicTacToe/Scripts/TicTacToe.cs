using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class TicTacToe : MonoBehaviour {
    public int[] pos = new int[9];
    public int jogador = 1;
    public int vencedor;

    public GameObject painelVitoria;
    public Text textoVencedor;
    public GameObject painelVelha;

    public static TicTacToe main;

	void Awake () {
        main = this;
        LoadGame();
    }

    void Start()
    {
    }
	
    public void LoadGame()
    {
        string caminhoCompletoDoArquivo = Application.persistentDataPath + "/arquivoGravado01.meuformato";
        Debug.Log("Procurando arquivo " + caminhoCompletoDoArquivo);
        if(File.Exists(caminhoCompletoDoArquivo))
        {
            //existe arquivo
            Debug.Log("Encontrei SaveGame");
            FileStream fileStream = File.Open(caminhoCompletoDoArquivo, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            SaveGameData saveGameData = (SaveGameData) binaryFormatter.Deserialize(fileStream);
            fileStream.Close();

            this.pos[0] = saveGameData.pos11;
            this.pos[1] = saveGameData.pos12;
            this.pos[2] = saveGameData.pos13;
            this.pos[3] = saveGameData.pos21;
            this.pos[4] = saveGameData.pos22;
            this.pos[5] = saveGameData.pos23;
            this.pos[6] = saveGameData.pos31;
            this.pos[7] = saveGameData.pos32;
            this.pos[8] = saveGameData.pos33;
            //...
            this.jogador = saveGameData.jogador;
            this.vencedor = saveGameData.vencedor;

        }
        else
        {
            //não existe arquivo
            Debug.Log("Não encontrei SaveGame");
        }

    }

    // Update is called once per frame
    public void SaveGame () {
        SaveGameData saveGameData = new SaveGameData();
        saveGameData.pos11 = pos[0];
        saveGameData.pos12 = pos[1];
        saveGameData.pos13 = pos[2];
        saveGameData.pos21 = pos[3];
        saveGameData.pos22 = pos[4];
        saveGameData.pos23 = pos[5];
        saveGameData.pos31 = pos[6];
        saveGameData.pos32 = pos[7];
        saveGameData.pos33 = pos[8];
        saveGameData.jogador = this.jogador;
        saveGameData.vencedor = this.vencedor;

        string caminhoCompletoDoArquivo = Application.persistentDataPath + "/arquivoGravado01.meuformato";
        Debug.Log("Caminho do arquivo do savegame = " + caminhoCompletoDoArquivo);

        FileStream fileStream = File.Open(caminhoCompletoDoArquivo, FileMode.OpenOrCreate);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(fileStream, saveGameData);
        fileStream.Close();

    }

    public void VerificarVitoria()
    {
        if(pos[0] == pos[1]  &&  pos[1] == pos[2] && pos[2] != 0)
        {
            Vitoria(pos[2]);
        }
        else if (pos[3] == pos[4] && pos[4] == pos[5] && pos[5] != 0)
        {
            Vitoria(pos[5]);
        }
        else if (pos[6] == pos[7] && pos[7] == pos[8] && pos[8] != 0)
        {
            Vitoria(pos[8]);
        }
        else if (pos[0] == pos[3] && pos[3] == pos[6] && pos[6] != 0)
        {
            Vitoria(pos[6]);
        }
        else if (pos[1] == pos[4] && pos[4] == pos[7] && pos[7] != 0)
        {
            Vitoria(pos[7]);
        }
        else if (pos[2] == pos[5] && pos[5] == pos[8] && pos[8] != 0)
        {
            Vitoria(pos[8]);
        }
        else if (pos[0] == pos[4] && pos[4] == pos[8] && pos[8] != 0)
        {
            Vitoria(pos[8]);
        }
        else if (pos[2] == pos[4] && pos[4] == pos[6] && pos[6] != 0)
        {
            Vitoria(pos[6]);
        }
        else if (pos[0] != 0 &&
            pos[1] != 0 &&
            pos[2] != 0 &&
            pos[3] != 0 &&
            pos[4] != 0 &&
            pos[5] != 0 &&
            pos[6] != 0 &&
            pos[7] != 0 &&
            pos[8] != 0)
        {
            DeuVelha();
        }

    }

    void DeuVelha()
    {
        painelVelha.SetActive(true);
    }
    void Vitoria(int v)
    {
        vencedor = v;
        Debug.Log("Vitória do jogador" + vencedor);
        painelVitoria.SetActive(true);
        textoVencedor.text = v == 1 ? "X" : "O";
    }

    public void NovaPartida()
    {
        string caminhoCompletoDoArquivo = Application.persistentDataPath + "/arquivoGravado01.meuformato";
        File.Delete(caminhoCompletoDoArquivo);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
