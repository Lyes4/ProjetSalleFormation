using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSalleFormation;

public class Report
{
    public int Id { get; set; }
    [Display(Name = "Etudiant")]
    public int StudentId { get; set; }
    [ForeignKey("StudentId")]
    public virtual Student? Student { get; set; }
    [Display(Name = "Note")]
    [Range(0,20)]
    public int Grade { get; set; }
    [Display(Name = "Type d'examen")]
    [MaxLength(50)]
    public string TypeOfExam { get; set; }
    [Display(Name = "Date d'examen")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime Date { get; set; }


    public Report(int id, int grade, string exam, DateTime date) {
        StudentId = id;
        Grade = grade;
        TypeOfExam = exam;
        Date = date;
    }

    public Report()
    {
        StudentId = -1;
        Grade = 0;
        TypeOfExam = "";
        Date = DateTime.Now;
    }

}
