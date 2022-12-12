using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Security.Cryptography;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace ProjetSalleFormation;

public class User
{

    public enum RoleType { Student, Teacher, Admin }
    public int Id { get; set; }
    [Display(Name = "Nom")]
    [MaxLength(50)]
    public string LastName { get; set; }
    [Display(Name = "Prenom")]
    [MaxLength(50)]
    public string FirstName { get; set; }
    [Display(Name = "Date de naissance")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime BirthDate { get; set; }
    [Display(Name = "Civilité")]
    [MaxLength(50)]
    public string Gender { get; set; }
    [Display(Name = "Image de profil")]
    public string? Picture { get; set; }
    [Display(Name = "Identifiant")]
    [MaxLength(100)]
    public string UserName { get; set; }
    [Display(Name = "Mot de passe")]
    [MaxLength(50)]
    public string Password { get; set; }
    [Display(Name = "Role")]
    public RoleType Role { get; set; }


    public User(string LastName, string FirstName, DateTime BirthDate, string Gender, RoleType Role)
    {
        this.LastName = LastName;
        this.FirstName = FirstName;
        this.BirthDate = BirthDate;
        this.Gender = Gender;
        this.Role = Role;
        this.UserName = LastName + FirstName;
        this.Password = LastName + BirthDate.ToShortDateString();
    }

    public User(string LastName, string FirstName, DateTime BirthDate, string Gender)
    {
        this.LastName = LastName;
        this.FirstName = FirstName;
        this.BirthDate = BirthDate;
        this.Gender = Gender;
        this.UserName = LastName + FirstName;
        this.Password = LastName + BirthDate.ToShortDateString();
    }

    public User()
    {
        this.LastName = "";
        this.FirstName = "";
        this.BirthDate = DateTime.Now;
        this.Gender = "";
        this.Role = RoleType.Student;
        this.UserName = LastName+FirstName;
        this.Password = LastName;
    }

    
}
