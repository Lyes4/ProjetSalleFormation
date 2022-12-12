using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetSalleFormation;

public class Equipment
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public bool Movable { get; set; }



    public Equipment(string Name, int Quantity, bool Movable)
    {
        this.Name = Name;
        this.Quantity = Quantity;
        this.Movable = Movable;
    }

    public Equipment()
    {
        this.Name = "";
        this.Quantity = 0;
        this.Movable = true;
    }

}
