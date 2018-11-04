namespace ModelApp.Common.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        #region Properties
        [Display(Name = "Employee Id")]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "Employee Number")]
        public int EmployeeNumber { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }


        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Display(Name = "Job Title")]
        public int TitleID { get; set; }
        
        public virtual Title Title { get; set; }

        [Display(Name = "Region")]
        public int? RegionID { get; set; }
        
        public virtual Region Region { get; set; }

        [Display(Name = "Section")]
        public int? SectionID { get; set; }
        
        public virtual Section Section { get; set; }

        [Display(Name = "District")]
        public int DistrictID { get; set; }
        
        public virtual District District { get; set; }

        [Display(Name = "Nearest Manager")]
        public int? ManagerID { get; set; }
        
        public virtual Employee Manager { get; set; }

        public string Phone { get; set; }

        public string Mobil { get; set; }

        public string Email { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; } = true;

        public string Notes { get; set; }

        [Display(Name = "Image")]
        public string ImagePath { get; set; }

        [JsonIgnore]
        public virtual ICollection<Employee> Managers { get; set; }
        #endregion
    }


    public class Section
    {
        #region Properties
        [Display(Name = "Section Id")]
        public int SectionID { get; set; }

        [Display(Name = "Section Name")]
        public string SectionName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
        #endregion
    }


    public class Title
    {
        #region Properties
        [Display(Name = "Title Id")]
        public int TitleID { get; set; }

        [Required]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
        #endregion
    }

    public class District
    {
        #region Properties
        [Display(Name = "District Id")]
        public int DistrictID { get; set; }

        [Required]
        [Display(Name = "District Name")]
        public string DistrictName { get; set; }

        [Required]
        public string City { get; set; }    // stad

        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
        #endregion
    }

    public class Region
    {
        #region Properties
        [Display(Name = "Region Id")]
        public int RegionID { get; set; }


        [Display(Name = "Region Name")]
        public string RegionName { get; set; }   // område

        [Display(Name = "District")]
        public int DistrictID { get; set; }
        public virtual District District { get; set; }

        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
        #endregion
    }
}
