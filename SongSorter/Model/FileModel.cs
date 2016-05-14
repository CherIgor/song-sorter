namespace SongSorter.Model
{
    public class FileModel
    {
        public string BeforeFilePath
        {
            get; set;
        }

        public string BeforeFileName
        {
            get; set;
        }

        public string AfterFileName
        {
            get; set;
        }

        public bool IsSelected
        {
            get; set;
        }

        public bool IsSystemOrHidden
        {
            get; set;
        }

        public override string ToString()
        {
            return string.Format("Selected: {0} | {1} | {2}", IsSelected, BeforeFileName, AfterFileName);
        }
    }
}
