using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSalleFormation;

public class HistoricTeacher
{
    public int Id { get; set; }
    [Display(Name = "Professeur")]
    public int TeacherId { get; set; }
    [ForeignKey("TeacherId")]
    public virtual Teacher? Teacher { get; set; }
    [Display(Name = "Date de début")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime EmployementStart { get; set; }
    [Display(Name = "Date de fin")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime EmployementEnd { get; set; }
    [Display(Name = "Description")]
    [MaxLength(200)]
    public string? Description { get; set; }

    public HistoricTeacher(int teacherId, DateTime employementStart, DateTime employementEnd, string description)
    {
        TeacherId = teacherId;
        EmployementStart = employementStart;
        EmployementEnd = employementEnd;
        Description = description;
    }

    public HistoricTeacher(int teacherId, DateTime employementStart, DateTime employementEnd)
    {
        TeacherId = teacherId;
        EmployementStart = employementStart;
        EmployementEnd = employementEnd;
        Description = "";
    }
    public HistoricTeacher()
    {
        EmployementStart = DateTime.Now;
        EmployementEnd = DateTime.Now;
        Description = "";
    }

}
