using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSalleFormation;

public class Student : User
{
    [Display(Name = "Formation")]
    public int FormationGroupId { get; set; }
    [ForeignKey("FormationGroupId")]
    public virtual FormationGroup? FormationGroup { get; set; }
    [Display(Name = "Projet")]
    public int? ProjectGroupId { get; set; }
    [ForeignKey("ProjectGroupId")]
    public virtual ProjectGroup? ProjectGroup { get; set; }
    [Display(Name = "Paiement")]
    [MaxLength(50)]
    public string Paiement { get; set; }

    public Student(string LastName, string FirstName, DateTime BirthDate, string Gender, int formId, int projId, string paiement, int id) : base(LastName, FirstName, BirthDate, Gender)
    {
        Role = RoleType.Student;
        this.FormationGroupId = formId;
        this.ProjectGroupId = projId;
        this.Paiement = paiement;
    }

    public Student(string LastName, string FirstName, DateTime BirthDate, string Gender) : base(LastName, FirstName, BirthDate, Gender)
    {
        FormationGroupId = -1;
        ProjectGroupId = -1;
        Paiement = "";
    }

    public Student()
    {
        FormationGroupId = -1;
        ProjectGroupId = -1;
        Paiement = "";
    }

}
