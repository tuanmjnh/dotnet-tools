using System.Collections.Generic;
namespace dotnet_tools
{
  public class Tool
  {
    public int id { get; set; }
    public string name { get; set; }
    public string value { get; set; }
    public Tool(int id, string name, string value)
    {
      this.id = id;
      this.name = name;
      this.value = value;
    }
  }
  public static class Tools
  {
    public static List<Tool> items = new List<Tool>(){
      new Tool(id: 1, name: "Rename Files", value: "RenameFiles"),
      new Tool(id: 2, name: "Hidden Files", value: "HiddenFiles")
    };
  }
  // RenameFiles = 1,  // Rename multipe Files
  // HiddenFiles = 2,  // hidden multipe Files
}