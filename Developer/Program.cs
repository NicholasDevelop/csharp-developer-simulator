using Libreria;
/* lo viluppatore legge le attività del suo file di attività (developerActivity) da risolvere
 * per risolvere le attività ci impiega dai 3 ai 15 secondi.
 se le risolve le elimina dalla lista.
se non le risolve la porta in fondo alla lista per farle in un secondo momento*/

//sviluppi

//1. creare il reader
//2. aprire il file developerActivity.txt
//3. leggo la riga facendo dei controlli (perchè può essere che non ci siano ancora task)
//4. bool risolta = true || false ---> Random().NextDouble() > 0.5;
//5. risolta == false ---> dobbiamo scrivere il file di modo che l'ultima riga sia il task corrente.
//5.1risolta == true ---> dobbiamo scrivere il file in modo che la lista sia aggiornata senza il task corrente (eliminarlo).
//6. ripeto dal punto 


void UpdateActivity()
{
    string path = "C:/Users/black/source/repos/Live coding pome/csharp-developer-simulator/DeveloperActivity.txt";
    string[] developerActivity = File.ReadAllLines(path);

    List<string> developerActivityList = developerActivity.ToList();

    if(developerActivityList.Count > 0)
    {
        while(developerActivityList.Count > 0)
        {
            string activity = developerActivityList[0];
            if(activity != "")
            {
                Console.WriteLine($"presa in carico di {activity}");
                Thread.Sleep(new Random().Next(2000, 7000));

                if(new Random().NextDouble() > 0.5)
                {
                    developerActivityList = File.ReadAllLines(path).ToList();
                    developerActivityList.Remove(activity);
                    File.WriteAllLines(path, developerActivityList);
                    Console.WriteLine("Task completata");
                }
                else
                {
                    developerActivityList = File.ReadAllLines(path).ToList();
                    developerActivityList.Remove(activity);
                    developerActivityList.Add(activity);
                    File.WriteAllLines(path, developerActivityList);
                    Console.WriteLine("Task rimandata");
                }
            }
        }
    }
    else
    {
        Console.WriteLine("Attualmente non ci sono task da svolgere");
    }
}

UpdateActivity();