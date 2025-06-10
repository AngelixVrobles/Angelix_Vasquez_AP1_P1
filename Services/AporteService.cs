using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Angelix_Vasquez_AP1_P1.Models;
using Angelix_Vasquez_AP1_P1.DAL;



namespace Angelix_Vasquez_AP1_P1.Services;
public class AporteService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Existe(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes.AnyAsync(c => c.AporteId == id);
    }

    public async Task<bool> Guardar(Aportes aporte)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var duplicadoNombre = await contexto.Aportes
            .AnyAsync(c => c.AporteId != aporte.AporteId &&
                           c.Nombres.ToLower() == aporte.Nombres.ToLower());

        if (duplicadoNombre)
            return false;


        if (aporte.AporteId == 0)
            contexto.Aportes.Add(aporte);
        else
            contexto.Aportes.Update(aporte);

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int aporteId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var cliente = await contexto.Aportes.FindAsync(aporteId);
        if (aporte == null)
            return false;

        contexto.Aportes.Remove(aporte);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Aportes?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes.AsNoTracking()
            .FirstOrDefaultAsync(c => c.AporteId == id);
    }

    public async Task<Aportes?> BuscarPor(Expression<Func<Aportes, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes.AsNoTracking()
            .FirstOrDefaultAsync(criterio);
    }

    public async Task<Aportes?> BuscarNombres(string nombre)
    {
        return await BuscarPor(c => c.Nombres.ToLower() == nombre.ToLower());
    }



    public async Task<List<Aportes>> Listar(Expression<Func<Aportes, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Aportes
            .AsNoTracking()
            .Where(criterio)
            .ToListAsync();
    }
}