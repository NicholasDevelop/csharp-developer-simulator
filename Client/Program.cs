using Libreria;
/* Il cliente assegna delle attività allo sviluppatore (dal suo file al file dello sviluppatore)
 * questa attività avviene casualmente in un intervallo 5-10 secondi; ( Thread.Sleep(1000);
 qualche volta però il cliente viene distratto (il programma si chiude casualmente? - oppure c'è un'eccezione?
quindi il cliente deve ricominciare possibilmente senza riassegnare task già assegnati allo sviluppatore ( )*/


//sviluppi

//1. creare i reader e i writer per leggere dal file ClientActiviti.txt al file DeveloperActivity
//   quindi apertura in lettura di un file e in scrittura di un altro file.

//2. Leggere la linea = attività e salvarla da qualche parte ---> read su clientActivity.txt
//3. Scrivere l'attività che abbiamo recuperato nell'altro file ---> write su developerActivity.txt

//4. Tread.Sleep(...tot secondi casuali...)

//5. si ricomincia da punto 2 fino alla fine del file clientActivity.txt (con un ciclo)

StreamReader tasks = File.OpenText("C:/Users/black/source/repos/Live coding pome/csharp-developer-simulator/ClientActivity.txt");
//StreamWriter developerTasks = new StreamWriter("C:/Users/black/source/repos/Live coding pome/csharp-developer-simulator/DeveloperActivity.txt");

List<string> list = new List<string>();
List<string> corruptList = new List<string>();

while (!tasks.EndOfStream)
{
    try
    {
        string task = tasks.ReadLine();

        list.Add(task);
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("File corrotto");
    }
}

tasks.Close();

string path = "C:/Users/black/source/repos/Live coding pome/csharp-developer-simulator/DeveloperActivity.txt";
if(File.Exists(path))
{
    foreach(string activity in list)
    {
        StreamWriter developerTasks = File.AppendText(path);
        developerTasks.WriteLine(activity);
        Console.WriteLine(activity);
        developerTasks.Close();
        Thread.Sleep(new Random().Next(3000, 5000));
    }
}


//Print(list);

//void Print(List<Task> list)
//{
//    Console.WriteLine($"\tIndex\tName\t");
//    foreach (Task task in list)
//    {
//        Console.WriteLine($"\t{task.Index}\t{task.Name}\t");
//    }
//}


//public class Task
//{
//    public string Index;
//    public string Name;


//    public Task(string index, string name)
//    {
//        Index = index;
//        Name = name;
//    }
//}