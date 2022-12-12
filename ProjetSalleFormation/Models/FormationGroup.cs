using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjetSalleFormation;

public class FormationGroup
{
    public int Id { get; set; }
    [Display(Name = "Nom")]
    [MaxLength(50)]
    public string Name { get; set; }
    [Display(Name = "Numéro")]
    [Range(0,int.MaxValue)]
    public int Number { get; set; }
    [Display(Name = "Date de début")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime FormationStart { get; set; }
    [Display(Name = "Date de fin")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime FormationEnd { get; set; }
    [Display(Name = "Salle")]
    public int RoomId { get; set; }
    [ForeignKey("RoomId")]
    public virtual Room? Room { get; set; }
    [Display(Name = "Discipline")]
    public int DisciplineId { get; set; }
    [ForeignKey("DisciplineId")]
    public virtual Discipline? Discipline { get; set; }

    public FormationGroup(string formationName, int number, DateTime formationStart, DateTime formationEnd, int roomId, int disciplineId)
    {
        Name = formationName;
        Number = number;
        FormationStart = formationStart;
        FormationEnd = formationEnd;
        RoomId = roomId;
        DisciplineId = disciplineId;
    }

    public FormationGroup(string formationName, DateTime formationStart, DateTime formationEnd, int disciplineId)
    {
        Name = formationName;
        Number = -1;
        FormationStart = formationStart;
        FormationEnd = formationEnd;
        RoomId = -1;
        DisciplineId = disciplineId;
    }

    public FormationGroup()
    {
        Name = "";
        Number = -1;
        FormationStart = DateTime.Now;
        FormationEnd = DateTime.Now;
        RoomId = -1;
        DisciplineId = -1;
    }

}
