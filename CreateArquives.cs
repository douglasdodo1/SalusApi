using System;
using System.IO;

public class CreateArquives {
    public static void createFolder(string folderName) {
        string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));
        string folderPath = Path.Combine(projectRoot, folderName);
        Console.WriteLine(folderPath);

        Directory.CreateDirectory(folderPath);
        Console.WriteLine($"Pasta '{folderName}' criada em: {projectRoot}");
    }

    public static void create(string arquiveName) {
        string[] folderList = ["Controllers", "Models", "Services", "Repositorys"];
        string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));

        foreach (var folder in folderList) {
            string type = folder.Substring(0, folder.Length - 1);

            string arquive = Path.Combine(projectRoot, folder, arquiveName + type + ".cs");
            string interfaceArquive = Path.Combine(projectRoot, "Interfaces", arquiveName, 'I' + arquiveName + type + ".cs");

            if (!File.Exists(arquive)) {
                using (File.Create(arquive)) { }
                ;

                if (folder != "Models") {
                    string folderName = char.ToUpper(folder[0]) + folder.Substring(1);
                    createFolder($"Interfaces/{folderName}");
                    using (File.Create(interfaceArquive)) { }

                }

                Console.WriteLine($"Arquivo '{arquiveName}' criado em {arquive}");
                Console.WriteLine($"Arquivo '{arquiveName}' criado em {interfaceArquive}");
            }
        }
    }
}
