using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSalleFormation;

public class ProjectGroup
{
    public int Id { get; set; }
    [Display(Name = "Nom")]
    [MaxLength(50)]
    public string Name { get; set; }
    [Display(Name = "Numéro de groupe")]
    [Range(0,int.MaxValue)]
    public int Number { get; set; }
    [Display(Name = "Projet")]
    public int ProjectId { get; set; }
    [ForeignKey("ProjectId")]
    public virtual Project? Project { get; set; }

    public ProjectGroup(string name, int number, int projectId)
    {
        Name = name;
        Number = number;
        ProjectId = projectId;
    }

    public ProjectGroup(string name)
    {
        Name = name;
        Number = -1;
        ProjectId = -1;
    }

    public ProjectGroup()
    {
        Name = "";
        Number = -1;
        ProjectId = -1;
    }

}
