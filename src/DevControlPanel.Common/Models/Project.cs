namespace DevControlPanel.Common.Models
{
    public sealed class Project<TConfiguration> where TConfiguration : ProjectConfiguration
    {
        public string Path { get; set; }

        public string Name { get; set; }

        public TConfiguration Configuration { get; set; }
    }
}
