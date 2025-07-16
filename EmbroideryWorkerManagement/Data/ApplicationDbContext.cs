using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmbroideryWorkerManagement.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<EmbroideryWorkerManagement.Models.Worker> Worker { get; set; } = default!;

public DbSet<EmbroideryWorkerManagement.Models.Attendance> Attendance { get; set; } = default!;

public DbSet<EmbroideryWorkerManagement.Models.AdvanceSalary> AdvanceSalary { get; set; } = default!;

public DbSet<EmbroideryWorkerManagement.Models.Holiday> Holiday { get; set; } = default!;

//public DbSet<EmbroideryWorkerManagement.Models.OvertimePolicy> OvertimePolicy { get; set; } = default!;

public DbSet<EmbroideryWorkerManagement.Models.MachineWork> MachineWork { get; set; } = default!;

public DbSet<EmbroideryWorkerManagement.Models.MonthlyTarget> MonthlyTarget { get; set; } = default!;
    }
