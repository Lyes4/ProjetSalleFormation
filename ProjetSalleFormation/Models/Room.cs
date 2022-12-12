using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProjetSalleFormation;

public class Room
{
    public int Id { get; set; }
    [Display(Name = "Nom de la salle")]
    [MaxLength(50)]
    public string Name { get; set; }
    [Display(Name = "Batiment")]
    [MaxLength(50)]
    public string Building { get; set; }
    [Display(Name = "Etage")]
    public int Floor { get; set; }
    [Display(Name = "Occupé ?")]
    public bool Occuped { get; set; }
    [Display(Name = "Capacité")]
    [Range(0, int.MaxValue)]
    public int Capacity { get; set; }


    public Room(string Name, string Building, int Floor, bool Occuped, int Capacity)
    {
        this.Name = Name;
        this.Building = Building;
        this.Floor = Floor;
        this.Occuped = Occuped;
        this.Capacity = Capacity;
    }

    public Room()
    {
        this.Name = "";
        this.Building = "";
        this.Floor = 0;
        this.Occuped = false;
        this.Capacity = 30;
    }

}
