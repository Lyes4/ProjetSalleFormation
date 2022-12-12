using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjetSalleFormation;

public class Project
{
    public int Id { get; set; }
    [Display(Name = "Nom")]
    [MaxLength(50)]
    public string Name { get; set; }
    [Display(Name = "Description")]
    [MaxLength(200)]
    public string? Description { get; set; }
    [Display(Name = "Technologie")]
    [MaxLength(50)]
    public string Technology { get; set; }

    public Project(string name, string desc, string tech)
    {
        Name = name;
        Description = desc;
        Technology = tech;
    }

    public Project(string name, string tech)
    {
        Name = name;
        Description = "";
        Technology = tech;
    }

    public Project() {
        Name = "";
        Description = "";
        Technology = "";
    }

}
