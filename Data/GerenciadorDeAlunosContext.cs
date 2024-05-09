using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GerenciamentoDeAlunos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class GerenciadorDeAlunosContext : IdentityDbContext
{
    public GerenciadorDeAlunosContext(DbContextOptions<GerenciadorDeAlunosContext> options)
        : base(options)
    {
    }

    public DbSet<Aluno> Aluno { get; set; } = default!;
    public DbSet<Cidade> Cidades { get; set; } = default!;
    public DbSet<Estado> Estados { get; set; } = default!;
    public DbSet<InstituicaoEnsino> InstituicoesEnsino { get; set; } = default!;
}
