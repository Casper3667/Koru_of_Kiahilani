namespace BachelorProject.GameLogic
{
    /// <summary>
    /// Areas that contain the overall theme for their sub-areas.
    /// </summary>
    /// <param name="name">Name of the area</param>
    /// <param name="description">Description of the area</param>
    /// <param name="subArea">Sub-areas</param>
    public class Area(string name, string description, List<SubArea> subArea)
    {
        public string Name { get; set; } = name;
        public string Description { get; set; } = description;
        public List<SubArea> SubArea { get; } = subArea;
    }
}
