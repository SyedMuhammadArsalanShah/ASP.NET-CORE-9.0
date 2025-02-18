namespace Lecture13Mushaf_API_Integration.Models
{
    public class QuranResponse
    {
        public List<Surah> Data { get; set; }
    }

    public class Surah
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string EnglishNameTranslation { get; set; }
        public string RevelationType { get; set; }
    }

    public class SurahDetailsResponse
    {
        public SurahDetails Data { get; set; }
    }

    public class SurahDetails
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string EnglishNameTranslation { get; set; }
        public List<Ayah> Ayahs { get; set; }
    }

    public class Ayah
    {
        public int Number { get; set; }
        public string Text { get; set; }
    }
}
