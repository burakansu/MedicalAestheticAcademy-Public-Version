using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VeronaAkademi.Data.Entities.Base;

namespace VeronaAkademi.Data.Entities
{
    public class Form : BaseEntity
    {
        [Key]
        public int FormId { get; set; }

        // 1: Advisor
        // 2: Student
        public int Type { get; set; }

        // Relations
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int AdvisorId { get; set; }
        public Advisor Advisor { get; set; }



        // ** Form Attributes **
        public string PanaromicXRay { get; set; }

        //Intra Oral Photos
        public string FrontProfile { get; set; }
        public string RightProfile { get; set; }
        public string LeftProfile { get; set; }
        public string UpperOkluzal { get; set; }
        public string BottomOkluzal { get; set; }
        public string İnnerNoiseSmilePhoto { get; set; }

        //Extra Oral Photos
        public string FrontProfileRelax { get; set; }
        public string FrontProfileSmile { get; set; }
        public string FrontProfileMounth { get; set; }
        public string ProfileRelax { get; set; }
        public string ProfileSmile { get; set; }
        public string ProfileMounth { get; set; }

        public string UpperAndLowerPlasterModel_WaxClosure { get; set; }


        // Hand Ankle Film
        public string HandAnkleFilm { get; set; }
    }
}
