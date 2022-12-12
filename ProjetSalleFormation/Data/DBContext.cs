using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetSalleFormation;

namespace ProjetSalleFormation.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<ProjetSalleFormation.Discipline> Discipline { get; set; } = default!;

        public DbSet<ProjetSalleFormation.Project> Project { get; set; }

        public DbSet<ProjetSalleFormation.User> User { get; set; }

        public DbSet<ProjetSalleFormation.Teacher> Teacher { get; set; }

        public DbSet<ProjetSalleFormation.Room> Room { get; set; }

        public DbSet<ProjetSalleFormation.FormationGroup> FormationGroup { get; set; }

        public DbSet<ProjetSalleFormation.ProjectGroup> ProjectGroup { get; set; }

        public DbSet<ProjetSalleFormation.Student> Student { get; set; }

        public DbSet<ProjetSalleFormation.HistoricTeacher> HistoricTeacher { get; set; }

        public DbSet<ProjetSalleFormation.Indisponibility> Indisponibility { get; set; }

        public DbSet<ProjetSalleFormation.Presence> Presence { get; set; }

        public DbSet<ProjetSalleFormation.Report> Report { get; set; }
    }
}
