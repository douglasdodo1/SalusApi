public class CreateModel {
    public async static void WriteModel(string path, string name) {
        string upName = name.ToUpper()[0] + name.Substring(1);

        await File.WriteAllTextAsync(path,
        $"public class {upName}Model " + "{\n" +
        $"  public {upName}Model()" + "{\n  }\n" +
        "}");
    }
}