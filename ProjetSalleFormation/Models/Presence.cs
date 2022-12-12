using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSalleFormation;

public class Presence
{
    public int Id { get; set; }
    [Display(Name = "Etudiant")]
    public int StudentId { get; set; }
    [ForeignKey("StudentId")]
    public virtual Student? Student { get; set; }
    [Display(Name = "Date de présence")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime Date { get; set; }
    [Display(Name = "Présent?")]
    public bool IsPresent { get; set; }

    public Presence(int studentId, DateTime date, bool isPresent)
    {
        StudentId = studentId;
        Date = date;
        IsPresent = isPresent;
    }

    public Presence()
    {
        StudentId = 0;
        Date = DateTime.Now;
        IsPresent = false;
    }

}
