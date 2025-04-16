public class CreateInterfaceRepository {
    public async static void writeRepository(string path, string name) {
        string parameter = $"[FromBody] {name}Model {name.ToLower()}";

        await File.WriteAllTextAsync(path,
        "using Microsoft.AspNetCore.Mvc;\n" +
        $"public interface I{name}Repository" + "{\n" +
        $"  Task<IActionResult> Add({parameter});\n" +
        $"  Task<IActionResult> FindById(int id);\n" +
        $"  Task<IActionResult> FindAll();\n" +
        $"  Task<IActionResult> Update({parameter}ToUpdate, {parameter}Finded);\n" +
        $"  Task<IActionResult> Remove({parameter});\n" +
        "}");
    }
}