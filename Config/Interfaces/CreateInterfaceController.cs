public class CreateInterfaceController {
    public async static void writeController(string path, string name) {
        string parameter = $"[FromBody] {name}Model {name.ToLower()}";

        await File.WriteAllTextAsync(path,
        "using Microsoft.AspNetCore.Mvc;\n" +
        $"public interface I{name}Controller" + "{\n" +
        $"  Task<IActionResult> Add({parameter});\n" +
        $"  Task<IActionResult> FindById(int id);\n" +
        $"  Task<IActionResult> FindAll();\n" +
        $"  Task<IActionResult> Update(int id, {parameter});\n" +
        $"  Task<IActionResult> Remove(int id);\n" +
        "}");
    }
}