using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.ProjetoFinal.BibliotecaCentral.Storage
{
    public static class Data
    {

        // PARAMETROS: O CAMINHO DO ARQUIVO PARA SER ESCRITO E A LISTA QUE VC DESEJA ESCREVER NO ARQUIVO
        public static void SaveData<T>(string FILE_PATH, List<T> listToSave)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (FileStream fileStream = new FileStream(FILE_PATH, FileMode.Create))
                {
                    formatter.Serialize(fileStream, listToSave);
                }
                Console.WriteLine("Dados salvos no arquivo binário.");
            }
            catch (IOException e)
            {
                Console.WriteLine("O arquivo não pôde ser aberto: " + e.Message);
            }
        }


        // PARAMETROS: O CAMINHO DO ARQUIVO PARA SER LIDO 
        // RETORNO: UMA LISTA DE OBJETOS DO TIPO T CARREGADA DO ARQUIVO
        public static List<T> LoadData<T>(string FILE_PATH)
        {
            List<T> loadedList = new List<T>();

            try
            {
                if (File.Exists(FILE_PATH))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    using (FileStream fileStream = new FileStream(FILE_PATH, FileMode.Open))
                    {
                        loadedList = (List<T>)formatter.Deserialize(fileStream);
                    }
                    Console.WriteLine("Dados carregados do arquivo binário.");
                }
                else
                {
                    Console.WriteLine("O arquivo binário não existe.");
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("O arquivo não pôde ser aberto: " + e.Message);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Erro ao desserializar os dados: " + e.Message);
            }

            return loadedList;
        }

    }
}
