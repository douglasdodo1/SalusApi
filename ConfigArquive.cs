using System;
using System.IO;
using System.Threading.Tasks;

public class ConfigArquives {
    public static void createFolder(string folderName) {
        string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));
        string folderPath = Path.Combine(projectRoot, folderName);
        Console.WriteLine(folderPath);

        Directory.CreateDirectory(folderPath);
        Console.WriteLine($"Pasta '{folderName}' criada em: {projectRoot}");
    }

    public static async Task create(string arquiveName) {
        string[] folderList = ["Controllers", "Models", "Services", "Repositorys"];
        string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));

        foreach (var folder in folderList) {
            string type = folder.Substring(0, folder.Length - 1);

            string arquive = Path.Combine(projectRoot, folder, arquiveName + type + ".cs");
            string interfaceArquive = Path.Combine(projectRoot, "Interfaces", arquiveName, 'I' + arquiveName + type + ".cs");

            if (!File.Exists(arquive)) {
                using (File.Create(arquive)) { }

                if (folder == "Models") {
                    CreateModel.WriteModel(arquive, arquiveName);
                    Console.WriteLine($"Arquivo '{arquiveName}' criado em {arquive}");
                }


                if (folder != "Models") {
                    string folderName = char.ToUpper(arquiveName[0]) + arquiveName.Substring(1);
                    createFolder($"Interfaces/{folderName}");

                    if (folder == "Controllers") {
                        await using (File.Create(interfaceArquive)) { }
                        CreateInterfaceController.writeController($"Interfaces/{folderName}/I{arquiveName}{type}" + ".cs", arquiveName);
                        CreateController.writeController(arquive, arquiveName);
                    }

                    else if (folder == "Services") {
                        await using (File.Create(interfaceArquive)) { }
                        CreateInterfaceService.writeService($"Interfaces/{folderName}/I{arquiveName}{type}" + ".cs", arquiveName);
                        CreateService.writeService(arquive, arquiveName);
                    }

                    else if (folder == "Repositorys") {
                        await using (File.Create(interfaceArquive)) { }
                        CreateInterfaceRepository.writeRepository($"Interfaces/{folderName}/I{arquiveName}{type}" + ".cs", arquiveName);
                        CreateRepository.writeRepository(arquive, arquiveName);
                    }

                    Console.WriteLine($"Arquivo '{arquiveName}' criado em {interfaceArquive}");
                }

                Console.WriteLine($"Arquivo '{arquiveName}' criado em {arquive}");

            }
        }
    }
}
