public class CreateInterfaceService {
    public async static void writeService(string path, string name) {
        string parameter = $"[FromBody] {name}Model {name.ToLower()}";

        await File.WriteAllTextAsync(path,
        "using Microsoft.AspNetCore.Mvc;\n" +
        $"public interface I{name}Service" + "{\n" +
        $"  Task<{name}Model> Add({parameter});\n" +
        $"  Task<{name}Model> FindById(int id);\n" +
        $"  Task<List<{name}Model>> FindAll();\n" +
        $"  Task<{name}Model> Update(int id, {parameter});\n" +
        $"  Task<{name}Model> Remove(int id);\n" +
        "}");
    }
}