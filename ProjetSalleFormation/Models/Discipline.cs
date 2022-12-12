using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSalleFormation;

public class Discipline
{

    public int Id { get; set; }
    [Display(Name = "Nom")]
    [MaxLength(50)]
    public string Name { get; set; }




    public Discipline(string Name)
    {
        this.Name = Name;
    }

    public Discipline()
    {
        this.Name = "";
    }

    //public void DisciplineInsert(string Name)
    //{
    //    this.Name = " ";
    //}

}

