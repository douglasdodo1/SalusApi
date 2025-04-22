public class CreateInterfaceRepository {
    public async static void writeRepository(string path, string name) {
        string parameter = $"[FromBody] {name}Model {name.ToLower()}";

        await File.WriteAllTextAsync(path,
        "using Microsoft.AspNetCore.Mvc;\n" +
        $"public interface I{name}Repository" + "{\n" +
        $"  Task<{name}Model> Add({parameter});\n" +
        $"  Task<{name}Model> FindById(int id);\n" +
        $"  Task<List<{name}Model>> FindAll();\n" +
        $"  Task<{name}Model> Update({parameter}ToUpdate, {parameter}Finded);\n" +
        $"  Task<{name}Model> Remove({parameter});\n" +
        "}");
    }
}