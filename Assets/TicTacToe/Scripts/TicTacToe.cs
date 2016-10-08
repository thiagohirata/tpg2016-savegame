using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class TicTacToe : MonoBehaviour {
    public int[] pos = new int[9];
    public int jogador = 1;
    public int vencedor;

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
}
