using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSalleFormation;

public class Teacher : User
{
    //public int Id { get; set; }
    [DisplayName("Discipline associée")]
    public int DisciplineId { get; set; }
    [ForeignKey("DisciplineId")]
    public virtual Discipline? Discipline { get; set; }
    [DisplayName("CV")]
    public string? Resume { get; set; }
    //public int UserId;

    public Teacher(string LastName, string FirstName, DateTime BirthDate, string Gender, int discId, string res) : base(LastName, FirstName, BirthDate, Gender)
    {
        Role = RoleType.Teacher;
        this.DisciplineId = discId;
        this.Resume = res;
    }

    public Teacher()
    {
        DisciplineId = -1;
        Resume = "";
    }
}
