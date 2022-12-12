using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSalleFormation;

public class Indisponibility
{
    public int Id { get; set; }
    [Display(Name = "Professeur")]
    public int TeacherId { get; set; }
    [ForeignKey("TeacherId")]
    public virtual Teacher? Teacher { get; set; }
    [Display(Name = "Date d'indisponibilité")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime Date { get; set; }
    public string? Description { get; set; }

    public Indisponibility(int teacherId, DateTime date, string description)
    {
        TeacherId = teacherId;
        Date = date;
        Description = description;
    }

    public Indisponibility(int teacherId, DateTime date)
    {
        TeacherId = teacherId;
        Date = date;
        Description = "";
    }
    public Indisponibility()
    {
        TeacherId = -1;
        Date = DateTime.Now;
        Description = "";
    }

    
}
