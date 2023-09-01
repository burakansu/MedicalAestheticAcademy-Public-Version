using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class WebSiteData : BaseEntity
    {
        // Always Only One Register
        public int WebsiteDataId { get; set; }

        //Home Texts
        public string? HeaderFirst { get; set; }
        public string? HeaderSecondary { get; set; }
        public string? TextReccommendedCourses { get; set; }
        public string? TextStudentFeedback { get; set; }
        public string? TextReccommendedSkill { get; set; }

        //Layout Links
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public string? Linkedin { get; set; }
        public string? Adress { get; set; }

        // Privacy Policy
        public string? PrivacyPolicy { get; set; }
    }
}
